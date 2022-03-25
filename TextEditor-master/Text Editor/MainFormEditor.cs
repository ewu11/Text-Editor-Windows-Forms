/*
 * Programmer: Hunter Johnson
 * Name: Rich Text Editor
 * Date: November 1, 2016 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace Text_Editor
{
    public partial class MainFormEditor : Form
    {
        List<string> colorList = new List<string>();    // holds the System.Drawing.Color names
        string filenamee;    // file opened inside of RTB
        const int MIDDLE = 382;    // middle sum of RGB - max is 765
        int sumRGB;    // sum of the selected colors RGB
        int pos, line, column;    // for detecting line and column numbers

        //----for popup menu uses----
        TCPopupMenuSimple popMenuObj;
        TCPopupMenuFull popMenuObjFull;
        MatrixPopupMenu matrixPopupMenuObj;
        MatrixPopupMenuFull matrixPopupMenuFullObj;
        VertPopupMenu vertPopupMenuObj;
        HoriPopupMenu horiPopupMenuObj;
        int contextMenuOption; //by default; default context menu
        Bitmap bmp; //to store the check button design
        //----for popup menu uses----

        public MainFormEditor()
        {
            InitializeComponent();

            //to enable double buffering; thus reduce flicker
            //fix flickering issues to the rich text box
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
        }

        private void frmEditor_Load(object sender, EventArgs e)
        {
            //for popup menu uses
            popMenuObj = new TCPopupMenuSimple(this);
            //popMenuObjFull = new TCPopupMenuFull(this);
            matrixPopupMenuObj = new MatrixPopupMenu(this);
            matrixPopupMenuFullObj = new MatrixPopupMenuFull(this);
            vertPopupMenuObj = new VertPopupMenu(this);
            horiPopupMenuObj = new HoriPopupMenu(this);

            contextMenuOption = 1; //sets the choice of context menu to default on the menu strip

            //make default context menu selection checked
            defaultCMMenuItem.Checked = true;

            // draw bmp in image property of selected item, while its active
            //--used by ToolStripDropDown & zoomFactorContextStrip--
            bmp = new Bitmap(5, 5);
            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                gfx.FillEllipse(Brushes.Black, 1, 1, 3, 3);
            }
            //--used by ToolStripDropDown & zoomFactorContextStrip--

            richTextBox1.AllowDrop = true;     // to allow drag and drop to the RichTextBox
            richTextBox1.AcceptsTab = true;    // allow tab
            richTextBox1.WordWrap = false;    // disable word wrap on start
            richTextBox1.ShortcutsEnabled = true;    // allow shortcuts
            richTextBox1.DetectUrls = true;    // allow detect url
            fontDialog1.ShowColor = true;
            fontDialog1.ShowApply = true;
            fontDialog1.ShowHelp = true;
            colorDialog1.AllowFullOpen = true;
            colorDialog1.AnyColor = true;
            colorDialog1.SolidColorOnly = false;
            colorDialog1.ShowHelp = true;
            colorDialog1.AnyColor = true;
            leftAlignStripButton.Checked = true;
            centerAlignStripButton.Checked = false;
            rightAlignStripButton.Checked = false;
            boldStripButton3.Checked = false;
            italicStripButton.Checked = false;
            rightAlignStripButton.Checked = false;
            bulletListStripButton.Checked = false;
            wordWrapToolStripMenuItem.Image = null;
            MinimizeBox = true;
            MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // fill zoomDropDownButton item list
            zoomDropDownButton.DropDown.Items.Add("20%");
            zoomDropDownButton.DropDown.Items.Add("50%");
            zoomDropDownButton.DropDown.Items.Add("70%");
            zoomDropDownButton.DropDown.Items.Add("100%");
            zoomDropDownButton.DropDown.Items.Add("150%");
            zoomDropDownButton.DropDown.Items.Add("200%");
            zoomDropDownButton.DropDown.Items.Add("300%");
            zoomDropDownButton.DropDown.Items.Add("400%");
            zoomDropDownButton.DropDown.Items.Add("500%");
         
            // fill font sizes in combo box
            for (int i = 8; i < 80; i += 2)
            {
                fontSizeComboBox.Items.Add(i);
            }

            // fill colors in color drop down list
            foreach (System.Reflection.PropertyInfo prop in typeof(Color).GetProperties())
            {
                if (prop.PropertyType.FullName == "System.Drawing.Color")
                {
                    colorList.Add(prop.Name);     
                }
            }
           
            // fill the drop down items list
            foreach(string color in colorList)
            {
                colorStripDropDownButton.DropDownItems.Add(color);
            }

            // fill BackColor for each color in the DropDownItems list
            for (int i = 0; i < colorStripDropDownButton.DropDownItems.Count; i++)
            {
                // Create KnownColor object
                KnownColor selectedColor;
                selectedColor = (KnownColor)System.Enum.Parse(typeof(KnownColor), colorList[i]);    // parse to a KnownColor
                colorStripDropDownButton.DropDownItems[i].BackColor = Color.FromKnownColor(selectedColor);    // set the BackColor to its appropriate list item

                // Set the text color depending on if the barkground is darker or lighter
                // create Color object
                Color col = Color.FromName(colorList[i]);

                // 255,255,255 = White and 0,0,0 = Black
                // Max sum of RGB values is 765 -> (255 + 255 + 255)
                // Middle sum of RGB values is 382 -> (765/2)
                // Color is considered darker if its <= 382
                // Color is considered lighter if its > 382
                sumRGB = ConvertToRGB(col);    // get the color objects sum of the RGB value
                if (sumRGB <= MIDDLE)    // Darker Background
                {
                    colorStripDropDownButton.DropDownItems[i].ForeColor = Color.White;    // set to White text
                }
                else if (sumRGB > MIDDLE)    // Lighter Background
                {
                    colorStripDropDownButton.DropDownItems[i].ForeColor = Color.Black;    // set to Black text
                }
            }

            // fill fonts in font combo box
            InstalledFontCollection fonts = new InstalledFontCollection();
            foreach (FontFamily family in fonts.Families)
            {
                fontStripComboBox.Items.Add(family.Name);
            }

            // determines the line and column numbers of mouse position on the richTextBox
            int pos = richTextBox1.SelectionStart;
            int line = richTextBox1.GetLineFromCharIndex(pos);
            int column = richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexFromLine(line);
            lineColumnStatusLabel.Text = "Line " + (line + 1) + ", Column " + (column + 1);

            //---make ToolStripDropDown & zoomFactorContextStrip selection in default---
            zoomDropDownButton.DropDownItems[3].Image = bmp;
            matrixPopupMenuFullObj.zoomFactorContextStripSetterGetter.Items[3].Image = bmp;
            //---make ToolStripDropDown & zoomFactorContextStrip selection in default---
        }

        //******************************************************************************************************************************
        // ConvertToRGB - Accepts a Color object as its parameter. Gets the RGB values of the object passed to it, calculates the sum. *
        //******************************************************************************************************************************
        private int ConvertToRGB(System.Drawing.Color c)
        {
            int r = c.R, // RED component value
                g = c.G, // GREEN component value
                b = c.B; // BLUE component value
            int sum = 0;

            // calculate sum of RGB
            sum = r + g + b;

            return sum;
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();     // select all text
            richTextBox1.SelectAll();     // select all text
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // clear
            richTextBox1.Clear();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();     // paste text
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();      // copy text
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();     // cut text
        }

        private void boldStripButton3_Click(object sender, EventArgs e)
        {
           
            if (boldStripButton3.Checked == false)
            {
                boldStripButton3.Checked = true; // BOLD is true
            }
            else if (boldStripButton3.Checked == true)
            {
                boldStripButton3.Checked = false;    // BOLD is false
            }

            if (richTextBox1.SelectionFont == null)
            {
                return;
            }

            // create fontStyle object
            FontStyle style = richTextBox1.SelectionFont.Style;

            // determines the font style
            if (richTextBox1.SelectionFont.Bold)
            {
                style &= ~FontStyle.Bold; 
            }
            else
            {
                style |= FontStyle.Bold;

            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);     // sets the font style
        }

        private void underlineStripButton_Click(object sender, EventArgs e)
        {
            if (underlineStripButton.Checked == false)
            {
                underlineStripButton.Checked = true;     // UNDERLINE is active
            }
            else if (underlineStripButton.Checked == true)
            {
                underlineStripButton.Checked = false;    // UNDERLINE is not active
            }

            if (richTextBox1.SelectionFont == null)
            {
                return;
            }

            // create fontStyle object
            FontStyle style = richTextBox1.SelectionFont.Style;

            // determines the font style
            if (richTextBox1.SelectionFont.Underline)
            {
                style &= ~FontStyle.Underline;
            }
            else
            {
                style |= FontStyle.Underline;
            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);    // sets the font style
        }

        private void italicStripButton_Click(object sender, EventArgs e)
        {
            if (italicStripButton.Checked == false)
            {
                italicStripButton.Checked = true;    // ITALICS is active
            }
            else if (italicStripButton.Checked == true)
            {
                italicStripButton.Checked = false;    // ITALICS is not active
            }

            if (richTextBox1.SelectionFont == null)
            {
                return;
            }
            // create fontStyle object
            FontStyle style = richTextBox1.SelectionFont.Style;

            // determines font style
            if (richTextBox1.SelectionFont.Italic)
            {
                style &= ~FontStyle.Italic;
            }
            else
            {
                style |= FontStyle.Italic;
            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);    // sets the font style
        }

        private void fontSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont == null)
            {
                return;
            }
            // sets the font size when changed
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, Convert.ToInt32(fontSizeComboBox.Text), richTextBox1.SelectionFont.Style);
        }

        private void fontStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont == null)
            {
                // sets the Font Family style
                richTextBox1.SelectionFont = new Font(fontStripComboBox.Text, richTextBox1.Font.Size);
            }
            // sets the selected font famly style
            richTextBox1.SelectionFont = new Font(fontStripComboBox.Text, richTextBox1.SelectionFont.Size);
        }

        private void saveStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                //saveFileDialog1.ShowDialog();    // show the dialog
                string file;
                if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    string filename = saveFileDialog1.FileName;
                    // save the contents of the rich text box
                    richTextBox1.SaveFile(filename, RichTextBoxStreamType.PlainText);
                    file = Path.GetFileName(filename);    // get name of file
                    MessageBox.Show("File " + file + " was saved successfully.", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void openFileStripButton_Click(object sender, EventArgs e)
        {
            //openFileDialog1.ShowDialog();     // show the dialog
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                filenamee = openFileDialog1.FileName;
                // load the file into the richTextBox
                richTextBox1.LoadFile(filenamee, RichTextBoxStreamType.PlainText);    // loads it in regular text format
                // richTextBox1.LoadFile(filename, RichTextBoxStreamType.RichText);    // loads it in RTB format
            }
        }

        private void colorStripDropDownButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // creates a KnownColor object
            KnownColor selectedColor;
            selectedColor = (KnownColor)System.Enum.Parse(typeof(KnownColor), e.ClickedItem.Text);    // converts it to a Color Structure
            richTextBox1.SelectionColor = Color.FromKnownColor(selectedColor);    // sets the selected color
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            // highlight button border when buttons are true
            if (richTextBox1.SelectionFont != null)
            {
                boldStripButton3.Checked = richTextBox1.SelectionFont.Bold;
                italicStripButton.Checked = richTextBox1.SelectionFont.Italic;
                underlineStripButton.Checked = richTextBox1.SelectionFont.Underline;
            }
        }

        private void leftAlignStripButton_Click(object sender, EventArgs e)
        {
            // set properties
            centerAlignStripButton.Checked = false;
            rightAlignStripButton.Checked = false;
            if(leftAlignStripButton.Checked == false)
            {
                leftAlignStripButton.Checked = true;    // LEFT ALIGN is active
            }
            else if(leftAlignStripButton.Checked == true)
            {
                leftAlignStripButton.Checked = false;    // LEFT ALIGN is not active
            }
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;    // selects left alignment
        }

        private void centerAlignStripButton_Click(object sender, EventArgs e)
        {
            // set properties
            leftAlignStripButton.Checked = false;
            rightAlignStripButton.Checked = false;
            if (centerAlignStripButton.Checked == false)
            {
                centerAlignStripButton.Checked = true;    // CENTER ALIGN is active
            }
            else if (centerAlignStripButton.Checked == true)
            {
                centerAlignStripButton.Checked = false;    // CENTER ALIGN is not active
            }
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;     // selects center alignment
        }

        private void rightAlignStripButton_Click(object sender, EventArgs e)
        {
            // set properties
            leftAlignStripButton.Checked = false;
            centerAlignStripButton.Checked = false;

            if (rightAlignStripButton.Checked == false)
            {
                rightAlignStripButton.Checked = true;    // RIGHT ALIGN is active
            }
            else if (rightAlignStripButton.Checked == true)
            {
                rightAlignStripButton.Checked = false;    // RIGHT ALIGN is not active
            }
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;    // selects right alignment
        }

        public void bulletListStripButton_Click(object sender, EventArgs e)
        {
            if (bulletListStripButton.Checked == false)
            {
                bulletListStripButton.Checked = true;
                richTextBox1.SelectionBullet = true;    // BULLET LIST is active

                //--to update matrix popup button14--
                matrixPopupMenuFullObj.button14SetterGetter.FlatAppearance.BorderColor = SystemColors.GradientActiveCaption;
                matrixPopupMenuFullObj.button14SetterGetter.FlatAppearance.BorderSize = 3;
                matrixPopupMenuFullObj.bulletFlagSetterGetter = 1;
                //--to update matrix popup button14--
            }
            else if (bulletListStripButton.Checked == true)
            {
                bulletListStripButton.Checked = false;
                richTextBox1.SelectionBullet = false;    // BULLET LIST is not active

                //--to update matrix popup button14--
                matrixPopupMenuFullObj.button14SetterGetter.FlatAppearance.BorderColor = SystemColors.Window;
                matrixPopupMenuFullObj.button14SetterGetter.FlatAppearance.BorderSize = 0;
                matrixPopupMenuFullObj.bulletFlagSetterGetter = 0;
                //--to update matrix popup button14--
            }
        }

        private void increaseStripButton_Click(object sender, EventArgs e)
        {
            string fontSizeNum = fontSizeComboBox.Text;    // variable to hold selected size         
            try
            {
                int size = Convert.ToInt32(fontSizeNum) + 1;    // convert (fontSizeNum + 1)
                if (richTextBox1.SelectionFont == null)
                {
                    return;
                }
                // sets the updated font size
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily,size,richTextBox1.SelectionFont.Style);
                fontSizeComboBox.Text = size.ToString();    // update font size
            }
            //catch(Exception ex)
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); // show error message
                MessageBox.Show("Please select \"Font Size\"!", "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); // show error message
            }
        }

        private void decreaseStripButton_Click(object sender, EventArgs e)
        {
            string fontSizeNum = fontSizeComboBox.Text;    // variable to hold selected size            
            try
            {
                int size = Convert.ToInt32(fontSizeNum) - 1;    // convert (fontSizeNum - 1)
                if (richTextBox1.SelectionFont == null)
                {
                    return;
                }
                // sets the updated font size
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, size, richTextBox1.SelectionFont.Style);
                fontSizeComboBox.Text = size.ToString();    // update font size
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); // show error message
                MessageBox.Show("Please select \"Font Size\"!", "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); // show error message
            }
        }

        //*********************************************************************************************
        // richTextBox1_DragEnter - Custom Event. Copies text being dragged into the richTextBox      *
        //*********************************************************************************************
        private void richTextBox1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;    // copies data to the RTB
            else
                e.Effect = DragDropEffects.None;    // doesn't accept data into RTB
        }
        //***************************************************************************************************
        // richTextBox1_DragEnter - Custom Event. Drops the copied text being dragged onto the richTextBox  *
        //***************************************************************************************************
        private void richTextBox1_DragDrop(object sender,System.Windows.Forms.DragEventArgs e)
        {
            // variables
            int i;
            String s;

            // Get start position to drop the text.
            i = richTextBox1.SelectionStart;
            s = richTextBox1.Text.Substring(i);
            richTextBox1.Text = richTextBox1.Text.Substring(0, i);

            // Drop the text on to the RichTextBox.
            richTextBox1.Text += e.Data.GetData(DataFormats.Text).ToString();
            richTextBox1.Text += s;
        }

        private void undoStripButton_Click(object sender, EventArgs e)
        {           
            richTextBox1.Undo();     // undo move
        }

        public void redoStripButton_Click(object sender, EventArgs e)
        {            
            richTextBox1.Redo();    // redo move
        }

        public void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            this.Close();     // close the form
        }

        public void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            richTextBox1.Undo();     // undo move
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            richTextBox1.Redo();     // redo move
        }

        public void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {            
            richTextBox1.Cut();     // cut text
        }

        public void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            richTextBox1.Copy();     // copy text
        }

        public void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {           
            richTextBox1.Paste();    // paste text
        }

        public void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {            
            richTextBox1.SelectAll();    // select all text
        }

        public void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // clear the rich text box
            richTextBox1.Clear();
            richTextBox1.Focus();
        }

        public void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // delete selected text
            richTextBox1.SelectedText = "";
            richTextBox1.Focus();
        }

        public void OpenMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult openFileDialog = openFileDialog1.ShowDialog(this);

            if (openFileDialog == DialogResult.OK)
            {
                richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                // richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.RichText);  // loads the file in RTB format
            }
            else
            {
                this.Visible = true;
            }
        }

        public void newMenuItem_Click(object sender, EventArgs e)
        {
            
            if (richTextBox1.Text != string.Empty)    // RTB has contents - prompt user to save changes
            {
               // save changes message
               DialogResult result =  MessageBox.Show("Would you like to save your changes? Editor is not empty.", "Save Changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                
                if(result == DialogResult.Yes)
                {
                    // save the RTB contents if user selected yes
                    DialogResult saveFileDialog = saveFileDialog1.ShowDialog(this);    // show the dialog
                    string file;
                    if (saveFileDialog == DialogResult.OK)
                    {
                        string filename = saveFileDialog1.FileName;
                        // save the contents of the rich text box
                        richTextBox1.SaveFile(filename, RichTextBoxStreamType.PlainText);
                        file = Path.GetFileName(filename); // get name of file
                        MessageBox.Show("File " + file + " was saved successfully.", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // finally - clear the contents of the RTB 
                    richTextBox1.ResetText();
                    richTextBox1.Focus();
                }
                else if(result == DialogResult.No)
                {
                    // clear the contents of the RTB 
                    richTextBox1.ResetText();
                    richTextBox1.Focus();
                }               
            }
            else // RTB has no contents
            {
                // clear the contents of the RTB 
                richTextBox1.ResetText();
                richTextBox1.Focus();
            }
        }

        public void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult saveFileDialog = saveFileDialog1.ShowDialog(this);    // show the dialog
            string file; 

            if (saveFileDialog == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                // save the contents of the rich text box
                richTextBox1.SaveFile(filename, RichTextBoxStreamType.PlainText);
                file = Path.GetFileName(filenamee);    // get name of file
                MessageBox.Show("File " + file + " was saved successfully.", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.Visible = true;
            }
        }

        public void zoomDropDownButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //---logics responsible for zoom factor---
            float zoomPercent = Convert.ToSingle(e.ClickedItem.Text.Trim('%')); // convert
            richTextBox1.ZoomFactor = zoomPercent / 100;    // set zoom factor
            //---logics responsible for zoom factor---

            //----to update zoom factor selection in both ToolStripDropDown & zoomFactorContextStrip----
            //from ToolStripDropDown -> zoomFactorContextStrip
            for (int i = 0; i < matrixPopupMenuFullObj.zoomFactorContextStripSetterGetter.Items.Count; i++)
            {
                matrixPopupMenuFullObj.zoomFactorContextStripSetterGetter.Items[i].Image = null;

                if (zoomDropDownButton.DropDownItems[i].ToString() == e.ClickedItem.ToString())
                {
                    matrixPopupMenuFullObj.zoomFactorContextStripSetterGetter.Items[i].Image = bmp;
                }
                /*else
                {
                    Console.WriteLine("Error1!");
                }*/
            }

            //from zoomFactorContextStrip -> ToolStripDropDown
            for (int i = 0; i < matrixPopupMenuFullObj.zoomFactorContextStripSetterGetter.Items.Count; i++)
            {
                zoomDropDownButton.DropDownItems[i].Image = null;

                if (matrixPopupMenuFullObj.zoomFactorContextStripSetterGetter.Items[i].ToString() == e.ClickedItem.ToString())
                {
                    zoomDropDownButton.DropDownItems[i].Image = bmp;
                }
                /*else
                {
                    Console.WriteLine("Error2!");
                }*/
            }
            //----to update zoom factor selection in both ToolStripDropDown & zoomFactorContextStrip----
        }

        private void uppercaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = richTextBox1.SelectedText.ToUpper();    // text to CAPS
        }

        private void lowercaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = richTextBox1.SelectedText.ToLower();    // text to lowercase
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // draw bmp in image property of selected item, while its active
            Bitmap bmp = new Bitmap(5, 5);
            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                gfx.FillEllipse(Brushes.Black, 1, 1, 3, 3);
            }

            if (richTextBox1.WordWrap == false)
            {
                richTextBox1.WordWrap = true;    // WordWrap is active
                wordWrapToolStripMenuItem.Image = bmp;    // draw ellipse in image property
            }
            else if(richTextBox1.WordWrap == true)
            {
                richTextBox1.WordWrap = false;    // WordWrap is not active
                wordWrapToolStripMenuItem.Image = null;    // clear image property
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //I CHANGED THE LOGIC HERE
                //ELSE, THE DIALOG WILL OPEN TWICE  
                DialogResult fontDialogResult = fontDialog1.ShowDialog(this);

                System.Drawing.Font oldFont = this.Font;    // gets current font

                if (fontDialogResult == DialogResult.OK)
                {
                    fontDialog1_Apply(richTextBox1, new System.EventArgs());
                }
                // set back to the recent font
                else if (fontDialogResult == DialogResult.Cancel)
                {
                    // set current font back to the old font
                    this.Font = oldFont;

                    // sets the old font for the controls inside richTextBox1
                    foreach (Control containedControl in richTextBox1.Controls)
                    {
                        containedControl.Font = oldFont;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); // error
            }
        }

        private void fontDialog1_HelpRequest(object sender, EventArgs e)
        {
            // display HelpRequest message
            MessageBox.Show("Please choose a font and any other attributes; then hit Apply and OK.", "Font Dialog Help Request", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {
            fontDialog1.FontMustExist = true;    // error if font doesn't exist
            
            richTextBox1.Font = fontDialog1.Font;    // set selected font (Includes: FontFamily, Size, and, Effect. No need to set them separately)
            richTextBox1.ForeColor = fontDialog1.Color;    // set selected font color
            
            // sets the font for the controls inside richTextBox1
            foreach (Control containedControl in richTextBox1.Controls)
            {
                containedControl.Font = fontDialog1.Font;
            }
        }

        private void deleteStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = ""; // delete selected text
        }

        private void clearFormattingStripButton_Click(object sender, EventArgs e)
        {
            fontStripComboBox.Text = "Font Family";
            fontSizeComboBox.Text = "Font Size";
            string pureText = richTextBox1.Text;    // get the current Plain Text     
            richTextBox1.Clear();    // clear RTB
            richTextBox1.ForeColor = Color.Black;    // ensure the text color is back to Black
            richTextBox1.Font = default(Font);    // set default font
            richTextBox1.Text = pureText;    // Set it back to its orginial text, added as plain text
            rightAlignStripButton.Checked = false;
            centerAlignStripButton.Checked = false;
            leftAlignStripButton.Checked = true;           
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // draws the string onto the print document
            e.Graphics.DrawString(richTextBox1.Text, richTextBox1.Font, Brushes.Black, 100, 20);
            e.Graphics.PageUnit = GraphicsUnit.Inch; 
        }

        public void printStripButton_Click(object sender, EventArgs e)
        {
            // printDialog associates with PrintDocument
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog(this) == DialogResult.OK)
            {
                printDocument.Print(); // Print the document
            }
        }

        public void printPreviewStripButton_Click(object sender, EventArgs e)
        {
            printPreviewDialog.Document = printDocument; 
            // Show PrintPreview Dialog 
            printPreviewDialog.ShowDialog(this);
        }

        private void printStripMenuItem_Click(object sender, EventArgs e)
        {
            // printDialog associates with PrintDocument
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog(this) == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void printPreviewStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog.Document = printDocument;
            // Show PrintPreview Dialog 
            printPreviewDialog.ShowDialog(this);
        }

        private void colorDialog1_HelpRequest(object sender, EventArgs e)
        {
            // display HelpRequest message
            MessageBox.Show("Please select a color by clicking it. This will change the text color.", "Color Dialog Help Request", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void colorOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                // set the selected color to the RTB's forecolor
                richTextBox1.ForeColor = colorDialog1.Color;
            }
        }

        private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Control chosenContextMenu = richContextStrip; //by default, the default context menu;
            string cmMsj = ""; //message for status tool strip


            if (e.Button == MouseButtons.Right) //if rmb mouse clicked
            {
                //----with popup menu selection----
                switch (contextMenuOption)
                {
                    case 1:
                        chosenContextMenu = richContextStrip; //by default, the default context menu
                        break;
                    case 2:
                        richContextStrip.Visible = false; //disable the default context menu display
                        chosenContextMenu = popMenuObj; //two column, simple context menu
                        cmMsj = "Simple two-column context menu opened!";
                        break;
                    case 3:
                        richContextStrip.Visible = false; //disable the default context menu display
                        chosenContextMenu = popMenuObjFull; //two column, simple context menu
                        cmMsj = "Full two-column context menu, with icons opened!";
                        break;
                    case 33:
                        richContextStrip.Visible = false; //disable the default context menu display
                        chosenContextMenu = popMenuObjFull; //two column, simple context menu
                        cmMsj = "Full two-column context menu, without icons opened!";
                        break;
                    case 4:
                        richContextStrip.Visible = false; //disable the default context menu display
                        chosenContextMenu = matrixPopupMenuObj;
                        cmMsj = "Simple matrix context menu opened!";
                        break;
                    case 5:
                        richContextStrip.Visible = false; //disable the default context menu display
                        chosenContextMenu = matrixPopupMenuFullObj; //two column, simple context menu
                        cmMsj = "Full matrix context menu opened!";
                        break;
                    case 6:
                        richContextStrip.Visible = false; //disable the default context menu display
                        chosenContextMenu = vertPopupMenuObj; //two column, simple context menu
                        cmMsj = "Vertical context menu opened!";
                        break;
                    case 7:
                        richContextStrip.Visible = false; //disable the default context menu display
                        chosenContextMenu = horiPopupMenuObj; //two column, simple context menu
                        cmMsj = "Horizontal context menu opened!";
                        break;
                    default:
                        MessageBox.Show(this, "Context menu selection error!", "Alert!", MessageBoxButtons.OK);
                        break;
                }
                //finally, process the popup menu location and mouse coordinate
                //only for custom context menu, cuz default context menu has its own handler
                if (contextMenuOption != 1)
                {
                    chosenContextMenu.Location = SetPopupLocationLocal(Screen.FromControl(this), (Form)chosenContextMenu, (sender as Control).PointToScreen(e.Location)); //location with logic
                    Cursor.Position = SetCursorLocationLocal(chosenContextMenu.Location, (Form)chosenContextMenu);
                    chosenContextMenu.Visible = true;
                    toolStripStatusLabel1.Text = cmMsj;
                }
                else
                {
                    //for default context menu
                    toolStripStatusLabel1.Text = "Default context menu opened!";
                }
                //----with popup menu selection----
            }
        }

            //****************************************************************************************************************************************
            // richTextBox1_KeyUp - Determines which key was released and gets the line and column numbers of the current cursor position in the RTB *
            //**************************************************************************************************************************************** 
            private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            // determine key released
            switch (e.KeyCode)
            {
                case Keys.Down:
                    pos = richTextBox1.SelectionStart;    // get starting point
                    line = richTextBox1.GetLineFromCharIndex(pos);    // get line number
                    column = richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexFromLine(line);    // get column number
                    lineColumnStatusLabel.Text = "Line " + (line + 1) + ", Column " + (column + 1);
                    break;
                case Keys.Right:
                    pos = richTextBox1.SelectionStart; // get starting point
                    line = richTextBox1.GetLineFromCharIndex(pos); // get line number
                    column = richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexFromLine(line);    // get column number
                    lineColumnStatusLabel.Text = "Line " + (line + 1) + ", Column " + (column + 1);
                    break;
                case Keys.Up:
                    pos = richTextBox1.SelectionStart; // get starting point
                    line = richTextBox1.GetLineFromCharIndex(pos); // get line number
                    column = richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexFromLine(line);    // get column number
                    lineColumnStatusLabel.Text = "Line " + (line + 1) + ", Column " + (column + 1);
                    break;
                case Keys.Left:
                    pos = richTextBox1.SelectionStart; // get starting point
                    line = richTextBox1.GetLineFromCharIndex(pos); // get line number
                    column = richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexFromLine(line);    // get column number
                    lineColumnStatusLabel.Text = "Line " + (line + 1) + ", Column " + (column + 1);
                    break;
            }
        }

        //----setter getter methods-----
        public RichTextBox richTextBoxSetterGetter
        {
            get { return this.richTextBox1; }
            set { this.richTextBox1 = value; }
        }

        public ToolStripDropDownButton zoomDropDownSetterGetter
        {
            get { return zoomDropDownButton; }
            set { zoomDropDownButton = value; }
        }

        public ToolStripStatusLabel toolStripStatusLabelSetterGetter
        {
            get { return this.toolStripStatusLabel1; }
            set { this.toolStripStatusLabel1 = value; }
        }
        //----setter getter methods-----

        //----combine key and mouse events----
        [DllImport("user32.dll")]
        static extern ushort GetKeyState(int vKey);
        [DllImport("user32.dll")]
        static extern ushort GetAsyncKeyState(int vKey);

        private void richContextStrip_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            toolStripStatusLabel1.Text = "...";
        }

        //----to manage context menu tool strip selection----
        private void toolStripMenuItem1_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            manageCheckStatus(e);
        }

        private void defaultContextMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuOption = 1;
            this.toolStripStatusLabel1.Text = "Default context menu chosen!";
        }

        private void twocolumnContextMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuOption = 2;
            this.toolStripStatusLabel1.Text = "Simple two-column context menu chosen!";
        }

        //---item 3---
        private void fullTCCMMenuItem_Click(object sender, EventArgs e)
        {
            //clear existing object data
            popMenuObjFull = null;
        }

        private void withIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            popMenuObjFull = new TCPopupMenuFull(this, 1);

            contextMenuOption = 3;
            this.toolStripStatusLabel1.Text = "Full two-column context menu, with icons chosen!";
        }

        private void withoutIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            popMenuObjFull = new TCPopupMenuFull(this, 0);

            contextMenuOption = 33;
            this.toolStripStatusLabel1.Text = "Full two-column context menu, without icons chosen!";
        }
        //---item 3---

        private void simpleMatrixContextMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuOption = 4;
            this.toolStripStatusLabel1.Text = "Simple matrix context menu chosen!";
        }

        private void fullMatrixContextMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuOption = 5;
            this.toolStripStatusLabel1.Text = "Full matrix context menu chosen!";
        }

        private void vertiCMMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuOption = 6;
            this.toolStripStatusLabel1.Text = "Vertical context menu chosen!";
        }

        private void horiCMMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuOption = 7;
            this.toolStripStatusLabel1.Text = "Horizontal context menu chosen!";
        }
        //----to manage context menu tool strip selection----

        //----to position form location and mouse location----
        public Point SetPopupLocationLocal(Screen screen, Form form, Point initPosition)
        {
            var p = new Point();
            var wrkArea = screen.WorkingArea;
            p.X = wrkArea.Right - (initPosition.X + form.Width);
            p.Y = wrkArea.Bottom - (initPosition.Y + form.Height);
            p.X = p.X < 0 ? wrkArea.Right - form.Width : initPosition.X;
            p.Y = p.Y < 0 ? wrkArea.Bottom - form.Height : initPosition.Y;
            return p;
        }

        public Point SetCursorLocationLocal(Point thePopupLocation, Form theForm)
        {
            Point newCursorPoint = new Point();

            int popupWidth = theForm.Width;
            int popupHeight = theForm.Height;

            newCursorPoint.X = thePopupLocation.X + (popupWidth / 2);
            newCursorPoint.Y = thePopupLocation.Y + (popupHeight / 2);

            return newCursorPoint;
        }
        //----to position form location and mouse location----

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //AboutCustomContextMenu aboutDialog = new AboutCustomContextMenu();

            //aboutDialog.ShowDialog(this);

            AboutProjectForm aboutProjDialog = new AboutProjectForm();

            aboutProjDialog.ShowDialog(this);
        }

        private void fullTCCMMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            manageCheckStatus(e);

            /*if ((e.ClickedItem as ToolStripMenuItem).Checked)
            {
                fullTCCMMenuItem.Checked = true;
            }
            else
            {
                fullTCCMMenuItem.Checked = false;
            }*/
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            for(int i=0; i<fullTCCMMenuItem.DropDownItems.Count; i++)
            {
                if((fullTCCMMenuItem.DropDownItems[i] as ToolStripMenuItem).Checked == true)
                {
                    fullTCCMMenuItem.Checked = true;
                }
            }
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //to revert "selectionbackcolor"
            //this.richTextBox1.BackColor = Color.Empty;
            if(richTextBox1.SelectionBackColor != richTextBox1.BackColor)
            {
                richTextBox1.SelectionBackColor = richTextBox1.BackColor;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int startIndex = 0; //start the search from beginning of the richTextBox1
            int endIndex = this.richTextBox1.TextLength;
            this.richTextBox1.Select(startIndex, endIndex);

            if(endIndex != 0)
            {
                for(int i=startIndex; i< endIndex; i++)
                {
                    if (this.richTextBox1.Text[i].ToString().Contains(" ")) //skips white spaces
                    {
                        continue;
                    }
                    else
                    {
                        while ((this.richTextBox1.BackColor != Color.Empty))
                        {
                            if (this.richTextBox1.SelectionBackColor.R == 155 && this.richTextBox1.SelectionBackColor.G == 255 && this.richTextBox1.SelectionBackColor.B == 255)
                            {
                                this.richTextBox1.HideSelection = true; //to prevent text highlighted
                                MessageBox.Show(this, "Texts with RGB(155, 255, 255) found!", "", MessageBoxButtons.OK);
                                break;
                            }
                            else
                            {
                                this.richTextBox1.HideSelection = true;
                                MessageBox.Show(this, "Error!", "", MessageBoxButtons.OK);
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "richTextBox1 is empty!", "Alert!", MessageBoxButtons.OK);
            }
        }

        //to be used by other context menu forms, since they can access parent form
        public void showForm(Form theForm, int theFlag)
        {
            switch(theFlag)
            {
                case 0:
                    theForm.Visible = false;
                    break;
                case 1:
                    theForm.Visible = true;
                    break;
                default:
                    MessageBox.Show(this, "showForm() error!", "Alert!", MessageBoxButtons.OK);
                    break;
            }
        }

        //---manage drop down "check" statuses---
        //CHANGING THE IF ELSE SYNTAXES ON ALL CASES WILL AFFECT THE MENU ITEM CHECKED FUNCTIONALITY
        private void manageCheckStatus(ToolStripItemClickedEventArgs e)
        {
            //check only the one selected
            //except for "About" menu item
            if (e.ClickedItem.Name == "aboutToolStripMenuItem")
            {
                (e.ClickedItem as ToolStripMenuItem).CheckState = CheckState.Unchecked;

                for (int i = 0; i < toolStripMenuItem1.DropDownItems.Count; i++)
                {
                    //if any menu item is checked, just maintain
                    if ((toolStripMenuItem1.DropDownItems[i] as ToolStripMenuItem).Checked)
                    {
                        continue;
                    }
                }
            }

            else if (e.ClickedItem.Name == "fullTCCMMenuItem")
            {
                //without this, the "checked" status for fullTCCMMenuItem will not work properly
            }

            //if any other items are selected, clear the check status first
            //then only maintain the checked status on the chosen item
            else
            {
                for (int i = 0; i < toolStripMenuItem1.DropDownItems.Count; i++)
                {
                    (toolStripMenuItem1.DropDownItems[i] as ToolStripMenuItem).Checked = false;
                }

                for (int i = 0; i < fullTCCMMenuItem.DropDownItems.Count; i++)
                {
                    (fullTCCMMenuItem.DropDownItems[i] as ToolStripMenuItem).Checked = false;
                }

                (e.ClickedItem as ToolStripMenuItem).Checked = true;
            }
        }
    }
}
