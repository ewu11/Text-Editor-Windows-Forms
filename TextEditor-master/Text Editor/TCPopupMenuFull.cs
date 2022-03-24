using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text_Editor
{
    public partial class TCPopupMenuFull : Form
    {
        //-----global variable(s)-----
        MainFormEditor parentFormObj;
        //int removeStyleStripXPos; //only used for button 13; need to be calculated early to fix positioning issues
        //rectangle colours
        Bitmap[] squareIcon = new Bitmap[5]; //create 5 array items named "squareIcon" with type "Bitmap"
        //need to create array so that can be easily accessed
        //static int alphaVal = 250;
        //--more solid colour--
        SolidBrush[] squareBrushes = new SolidBrush[5] { new SolidBrush(Color.FromArgb(0, 255, 255)),
                                                         new SolidBrush(Color.FromArgb(255, 128, 0)),
                                                         new SolidBrush(Color.FromArgb(255, 255, 0)),
                                                         new SolidBrush(Color.FromArgb(128, 0, 255)),
                                                         new SolidBrush(Color.FromArgb(0, 128, 0)) };
        //--more solid colour--

        //--readable colour--
        /*Color[] squareColors = new Color[5] { Color.FromArgb(alphaVal, 155, 255, 255),
                                              Color.FromArgb(alphaVal, 255, 205, 155),
                                              Color.FromArgb(alphaVal, 241, 241, 155),
                                              Color.FromArgb(alphaVal, 205, 155, 255),
                                              Color.FromArgb(alphaVal, 155, 205, 155) };*/

        Color[] squareColors = new Color[5] { Color.FromArgb(155, 255, 255),
                                              Color.FromArgb(255, 205, 155),
                                              Color.FromArgb(241, 241, 155),
                                              Color.FromArgb(205, 155, 255),
                                              Color.FromArgb(155, 205, 155) };
        //--readable colour--
        //-----global variable(s)-----

        //not used; no parent info
        public TCPopupMenuFull()
        {
            InitializeComponent();
        }

        //used; cuz obtains parent's info; able to access parents data
        public TCPopupMenuFull(MainFormEditor parentForm, int iconFlag) //without icons
        {
            this.parentFormObj = parentForm;
            InitializeComponent();

            switch(iconFlag)
            {
                case 0: //remove iconss
                    this.imageList1.Images.Clear();
                    this.Width -= 60;
                    /*foreach(var button in this.Controls.OfType<Button>())
                    {
                        button.Width -= 50;
                    }*/
                    //CHANGING THIS VALUE WILL AFFECT THE VERTICAL WIDTH SEPARATING THE COLUMNS
                    //ON THE FULL TWO COLUMN CONTEXT MENU "WITHOUT TEXT"!
                    button1.Width -= 8;
                    button2.Width -= 8;
                    button3.Width -= 8;
                    button4.Width -= 8;
                    button5.Width -= 8;
                    button6.Width -= 8;
                    button7.Width -= 8;
                    button8.Width -= 8;
                    button9.Width -= 8;
                    button10.Width -= 8;
                    button11.Width -= 8;
                    button12.Width -= 8;
                    button13.Width -= 8;
                    button14.Width -= 8;
                    button15.Width -= 8;
                    button16.Width -= 8;
                    break;
                case 1:
                    //do nothing
                    //cuz implemented in "InitializeComponent()"
                    break;
                default:
                    MessageBox.Show(this.Parent, "TCPopupMenuFull constructor error!", "Alert!", MessageBoxButtons.OK);
                    break;
            }
        }

        private void PopupMenuFull_Deactivate(object sender, EventArgs e)
        {
            if ((styleTokenStrip.Visible) || (removeStyleStrip.Visible))
            {
                styleTokenStrip.Close();
                removeStyleStrip.Close();
            }

            parentFormObj.showForm(this, 0);

            parentFormObj.toolStripStatusLabelSetterGetter.Text = "...";            
        }

        //-----popup menu button functions-----
        private void button1_Click(object sender, EventArgs e)
        {
            parentFormObj.newMenuItem_Click(sender, e);
            parentFormObj.showForm(this, 0);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            parentFormObj.OpenMenuItem_Click(sender, e);
            parentFormObj.showForm(this, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            parentFormObj.saveToolStripMenuItem_Click(sender, e);
            parentFormObj.showForm(this, 0);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            parentFormObj.printStripButton_Click(sender, e);
            parentFormObj.showForm(this, 0);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            parentFormObj.printPreviewStripButton_Click(sender, e);
            parentFormObj.showForm(this, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parentFormObj.undoToolStripMenuItem_Click(sender, e);
            parentFormObj.showForm(this, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            parentFormObj.redoStripButton_Click(sender, e);
            parentFormObj.showForm(this, 0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            parentFormObj.cutToolStripMenuItem1_Click(sender, e);
            parentFormObj.showForm(this, 0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            parentFormObj.copyToolStripMenuItem1_Click(sender, e);
            parentFormObj.showForm(this, 0);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            parentFormObj.pasteToolStripMenuItem1_Click(sender, e);
            parentFormObj.showForm(this, 0);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            parentFormObj.clearAllToolStripMenuItem_Click(sender, e);
            parentFormObj.showForm(this, 0);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            parentFormObj.deleteToolStripMenuItem_Click(sender, e);
            parentFormObj.showForm(this, 0);
        }

        //--involves dropdown--
        private void button13_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //this.TopMost = true;
                //removeStyleStrip.Show(button13, new Point(removeStyleStripXPos, 0)); //cant use "visible" property; cant manage its location

                var screenPos = button13.PointToScreen(Point.Empty);
                removeStyleStrip.Show(new Point(screenPos.X - removeStyleStrip.Width, screenPos.Y));
            }
        }

        private void button13_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                removeStyleStrip.Close();
            }
        }

        private void button14_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //this.TopMost = true;
                styleTokenStrip.Show(button14, new Point(this.button14.DisplayRectangle.Right, 0)); //cant use "visible" property; cant manage its location
            }
        }

        private void button14_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                styleTokenStrip.Close();
            }
        }
        //--involves dropdown--

        private void button15_Click(object sender, EventArgs e)
        {
            parentFormObj.exitToolStripMenuItem_Click(sender, e);
            parentFormObj.showForm(this, 0);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            parentFormObj.selectAllToolStripMenuItem1_Click(sender, e);
            parentFormObj.showForm(this, 0);
        }
        //-----popup menu button functions-----

        private void PopupMenuFull_Activated(object sender, EventArgs e)
        {
            parentFormObj.richTextBoxSetterGetter.HideSelection = false;
        }

        private void TCPopupMenuFull_Load(object sender, EventArgs e)
        {
            //removeStyleStripXPos = -(this.removeStyleStrip.Width);
            //removeStyleStripPos = removeStyleStrip.Right - this.button13.Left;
            //removeStyleStripXPos = this.button13.DisplayRectangle.Width - this.removeStyleStrip.Left;

            //add square bitmaps for the styles strip
            const int totalSquares = 5;

            //assign new bitmap object to squares object
            for (int i = 0; i < totalSquares; i++)
            {
                //instantiate squareIcons object
                squareIcon[i] = new Bitmap(5, 5);
            }

            //assign colours to the squareIcons objects
            for (int i = 0; i < totalSquares; i++)
            {
                using (Graphics colourize = Graphics.FromImage(squareIcon[i]))
                {
                    colourize.FillRectangle(squareBrushes[i], 1, 1, 4, 4);
                }
            }

            //set images to the style strip
            for (int i = 0; i < totalSquares; i++)
            {
                styleTokenStrip.Items[i].Image = squareIcon[i];
                removeStyleStrip.Items[i].Image = squareIcon[i];
            }
        }

        private void styleTokenStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //---get selected text lines---
            // Create a string array and store the contents of the Lines property.
            //string[] tempArray = this.parentFormObj.richTextBoxSetterGetter.Lines;

            // Loop through the array and send the contents of the array to debug window.
            //for (int counter = 0; counter < tempArray.Length; counter++)
            //{
            //    System.Diagnostics.Debug.WriteLine(tempArray[counter]);
            //}
            //---get lines---

            //SolidBrush textBgCol; //to store color brushes
            Color textBgCol2;

            if (e.ClickedItem.Name == "using1stStyleToolStripMenuItem")
            {
                //textBgCol = squareBrushes[0];
                textBgCol2 = squareColors[0];
            }
            else if (e.ClickedItem.Name == "using2ndStyleToolStripMenuItem")
            {
                //textBgCol = squareBrushes[1];
                textBgCol2 = squareColors[1];
            }
            else if (e.ClickedItem.Name == "using3rdStyleToolStripMenuItem")
            {
                //textBgCol = squareBrushes[2];
                textBgCol2 = squareColors[2];
            }
            else if (e.ClickedItem.Name == "using4thStyleToolStripMenuItem")
            {
                //textBgCol = squareBrushes[3];
                textBgCol2 = squareColors[3];
            }
            else if (e.ClickedItem.Name == "using5thStyleToolStripMenuItem")
            {
                //textBgCol = squareBrushes[4];
                textBgCol2 = squareColors[4];
            }
            else
            {
                //textBgCol = null;
                textBgCol2 = Color.Empty;
                MessageBox.Show(this.parentFormObj, "Style token menu item error!", "Alert!", MessageBoxButtons.OK);
            }

            //finally, set the colour changes
            //"-1" to prevent changing background color of white spaces
            /*int startSelectIndex = this.parentFormObj.richTextBoxSetterGetter.SelectionStart;
            int endSelectIndex;
            if(this.parentFormObj.richTextBoxSetterGetter.SelectedText.EndsWith(" "))
            {
                endSelectIndex = (this.parentFormObj.richTextBoxSetterGetter.SelectionLength - 1);
            }
            else
            {
                endSelectIndex = this.parentFormObj.richTextBoxSetterGetter.SelectionLength;
            }
            this.parentFormObj.richTextBoxSetterGetter.Select(startSelectIndex, endSelectIndex);*/

            isTextSelected(parentFormObj.richTextBoxSetterGetter);

            //cant explicitly change "solidbrush" to "color"; so use this way
            //this.parentFormObj.richTextBoxSetterGetter.SelectionBackColor = Color.FromArgb(alphaVal, textBgCol.Color.R, textBgCol.Color.G, textBgCol.Color.B);
            this.parentFormObj.richTextBoxSetterGetter.SelectionBackColor = textBgCol2;

            //after choosing the items, close the style strip and the context menu
            parentFormObj.richTextBoxSetterGetter.DeselectAll(); //unselect text in RTB
            parentFormObj.richTextBoxSetterGetter.Select(); //set focus back to the RTB
            this.styleTokenStrip.Visible = false;
            this.parentFormObj.showForm(this, 0);
        }

        private void removeStyleStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //-----OLD CODE-----
            /*int startIndex = 0; //start the search from beginning of the richTextBox1
            int endIndex = this.parentFormObj.richTextBoxSetterGetter.TextLength;
            //int endIndex = this.parentFormObj.richTextBoxSetterGetter.SelectionLength;
            this.parentFormObj.richTextBoxSetterGetter.Select(startIndex, endIndex);

            //my idea is to use loop to loop every single text in the richtextbox
            for(int i=startIndex; i<endIndex; i++)
            {
                *//*if(this.parentFormObj.richTextBoxSetterGetter.SelectionBackColor == squareColors[0])
                {
                    //MessageBox.Show(this.parentFormObj, "good!", ":D", MessageBoxButtons.OK);
                }
                else
                {
                    //MessageBox.Show(this.parentFormObj, "error laaa!", "eyh3x?!", MessageBoxButtons.OK);
                    //this.parentFormObj.toolStripStatusLabelSetterGetter.Text = "Hmm: " + this.parentFormObj.richTextBoxSetterGetter.BackColor.ToString();
                    
                }*//*
                Console.WriteLine("Hmm: " + this.parentFormObj.richTextBoxSetterGetter.SelectionBackColor.ToString());
            }

            *//*if (e.ClickedItem.Name == "clear1stToolStripMenuItem")
            {
                if(this.parentFormObj.richTextBoxSetterGetter.SelectionBackColor == squareColors[0])
                {
                    this.parentFormObj.richTextBoxSetterGetter.BackColor = SystemColors.Window;
                }
                else
                {
                    MessageBox.Show(this.parentFormObj, "xda ponn!", "hmm", MessageBoxButtons.OK);
                }
            }
            else if (e.ClickedItem.Name == "clear2ndToolStripMenuItem")
            {
                if (this.parentFormObj.richTextBoxSetterGetter.SelectionBackColor == squareColors[1])
                {
                    this.parentFormObj.richTextBoxSetterGetter.BackColor = SystemColors.Window;
                }
            }
            else if (e.ClickedItem.Name == "clear3rdToolStripMenuItem")
            {
                if (this.parentFormObj.richTextBoxSetterGetter.SelectionBackColor == squareColors[2])
                {
                    this.parentFormObj.richTextBoxSetterGetter.BackColor = SystemColors.Window;
                }
            }
            else if (e.ClickedItem.Name == "clear4thToolStripMenuItem")
            {
                if (this.parentFormObj.richTextBoxSetterGetter.SelectionBackColor == squareColors[3])
                {
                    this.parentFormObj.richTextBoxSetterGetter.BackColor = SystemColors.Window;
                }
            }
            else if (e.ClickedItem.Name == "clear5thToolStripMenuItem")
            {
                if (this.parentFormObj.richTextBoxSetterGetter.SelectionBackColor == squareColors[4])
                {
                    this.parentFormObj.richTextBoxSetterGetter.BackColor = SystemColors.Window;
                }
            }
            else if (e.ClickedItem.Name == "clearAllStylesToolStripMenuItem")
            {
                this.parentFormObj.richTextBoxSetterGetter.SelectionBackColor = SystemColors.Window;
            }
            else
            {
                MessageBox.Show(this.parentFormObj, "Remove style menu item error!", "Alert!", MessageBoxButtons.OK);
            }*//*

            //after choosing the items, close the style strip and the context menu
            this.removeStyleStrip.Visible = false;
            this.parentFormObj.showForm(this, 0);*/
            //-----OLD CODE-----

            //-----NEWER CODE-----
            //manage text selection first
            //--if user select text--
            //parentFormObj.richTextBoxSetterGetter.se
            //--if user select text--

            //--if user dont select text--
            //go through text one by one, skipping white lines
            int startIndex = 0;
            int endIndex = parentFormObj.richTextBoxSetterGetter.TextLength;
            parentFormObj.richTextBoxSetterGetter.SelectionStart = startIndex;
            parentFormObj.richTextBoxSetterGetter.SelectionLength = 1; //always 1 'cuz we want to assess each text one by one
            //--if user dont select text--

            //manage text selection
            //isTextSelected(parentFormObj.richTextBoxSetterGetter);
            //int endIndex = parentFormObj.richTextBoxSetterGetter.TextLength;

            //second, get which menu item was clicked
            if (e.ClickedItem.Name == "clear1stToolStripMenuItem")
            {
                while (parentFormObj.richTextBoxSetterGetter.SelectionStart < endIndex)
                {
                    //parentFormObj.richTextBoxSetterGetter.Select(parentFormObj.richTextBoxSetterGetter.SelectionStart, parentFormObj.richTextBoxSetterGetter.SelectionLength); //select the text first before processing

                    //--manage bg color of selected text in RTB--
                    if (parentFormObj.richTextBoxSetterGetter.SelectionBackColor == squareColors[0])
                    {
                        parentFormObj.richTextBoxSetterGetter.SelectionBackColor = SystemColors.Window;
                    }
                    //--manage bg color of selected text in RTB--

                    //testing purposes
                    //MessageBox.Show(this, "Color: " + parentFormObj.richTextBoxSetterGetter.SelectionBackColor, "Color info!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //so that able to go to next text
                    parentFormObj.richTextBoxSetterGetter.SelectionStart += 1;
                }

                /*if (parentFormObj.richTextBoxSetterGetter.SelectionBackColor == squareColors[0])
                {
                    parentFormObj.richTextBoxSetterGetter.SelectionBackColor = SystemColors.Window;
                }*/
            }
            else if(e.ClickedItem.Name == "clear2ndToolStripMenuItem")
            {
                while (parentFormObj.richTextBoxSetterGetter.SelectionStart < endIndex)
                {
                    //parentFormObj.richTextBoxSetterGetter.Select(parentFormObj.richTextBoxSetterGetter.SelectionStart, parentFormObj.richTextBoxSetterGetter.SelectionLength); //select the text first before processing

                    //--manage bg color of selected text in RTB--
                    if (parentFormObj.richTextBoxSetterGetter.SelectionBackColor == squareColors[1])
                    {
                        parentFormObj.richTextBoxSetterGetter.SelectionBackColor = SystemColors.Window;
                    }
                    //--manage bg color of selected text in RTB--

                    //testing purposes
                    //MessageBox.Show(this, "Color: " + parentFormObj.richTextBoxSetterGetter.SelectionBackColor, "Color info!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //so that able to go to next text
                    parentFormObj.richTextBoxSetterGetter.SelectionStart += 1;
                }
            }
            else if (e.ClickedItem.Name == "clear3rdToolStripMenuItem")
            {
                while (parentFormObj.richTextBoxSetterGetter.SelectionStart < endIndex)
                {
                    //parentFormObj.richTextBoxSetterGetter.Select(parentFormObj.richTextBoxSetterGetter.SelectionStart, parentFormObj.richTextBoxSetterGetter.SelectionLength); //select the text first before processing

                    //--manage bg color of selected text in RTB--
                    if (parentFormObj.richTextBoxSetterGetter.SelectionBackColor == squareColors[2])
                    {
                        parentFormObj.richTextBoxSetterGetter.SelectionBackColor = SystemColors.Window;
                    }
                    //--manage bg color of selected text in RTB--

                    //testing purposes
                    //MessageBox.Show(this, "Color: " + parentFormObj.richTextBoxSetterGetter.SelectionBackColor, "Color info!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //so that able to go to next text
                    parentFormObj.richTextBoxSetterGetter.SelectionStart += 1;
                }
            }
            else if (e.ClickedItem.Name == "clear4thToolStripMenuItem")
            {
                while (parentFormObj.richTextBoxSetterGetter.SelectionStart < endIndex)
                {
                    //parentFormObj.richTextBoxSetterGetter.Select(parentFormObj.richTextBoxSetterGetter.SelectionStart, parentFormObj.richTextBoxSetterGetter.SelectionLength); //select the text first before processing

                    //--manage bg color of selected text in RTB--
                    if (parentFormObj.richTextBoxSetterGetter.SelectionBackColor == squareColors[3])
                    {
                        parentFormObj.richTextBoxSetterGetter.SelectionBackColor = SystemColors.Window;
                    }
                    //--manage bg color of selected text in RTB--

                    //testing purposes
                    //MessageBox.Show(this, "Color: " + parentFormObj.richTextBoxSetterGetter.SelectionBackColor, "Color info!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //so that able to go to next text
                    parentFormObj.richTextBoxSetterGetter.SelectionStart += 1;
                }
            }
            else if (e.ClickedItem.Name == "clear5thToolStripMenuItem")
            {
                while (parentFormObj.richTextBoxSetterGetter.SelectionStart < endIndex)
                {
                    //parentFormObj.richTextBoxSetterGetter.Select(parentFormObj.richTextBoxSetterGetter.SelectionStart, parentFormObj.richTextBoxSetterGetter.SelectionLength); //select the text first before processing

                    //--manage bg color of selected text in RTB--
                    if (parentFormObj.richTextBoxSetterGetter.SelectionBackColor == squareColors[4])
                    {
                        parentFormObj.richTextBoxSetterGetter.SelectionBackColor = SystemColors.Window;
                    }
                    //--manage bg color of selected text in RTB--

                    //testing purposes
                    //MessageBox.Show(this, "Color: " + parentFormObj.richTextBoxSetterGetter.SelectionBackColor, "Color info!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //so that able to go to next text
                    parentFormObj.richTextBoxSetterGetter.SelectionStart += 1;
                }
            }
            else if (e.ClickedItem.Name == "clearAllStylesToolStripMenuItem")
            {
                while (parentFormObj.richTextBoxSetterGetter.SelectionStart < endIndex)
                {
                    //parentFormObj.richTextBoxSetterGetter.Select(parentFormObj.richTextBoxSetterGetter.SelectionStart, parentFormObj.richTextBoxSetterGetter.SelectionLength); //select the text first before processing

                    //--manage bg color of selected text in RTB--
                    parentFormObj.richTextBoxSetterGetter.SelectionBackColor = SystemColors.Window;
                    //--manage bg color of selected text in RTB--

                    //so that able to go to next text
                    parentFormObj.richTextBoxSetterGetter.SelectionStart += 1;
                }

                //show completion status
                parentFormObj.toolStripStatusLabelSetterGetter.Text = "All text background color cleared successfully!";
            }
            else
            {
                MessageBox.Show(this, "Remove style selection error!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //-----NEWER CODE-----

            //finally...
            parentFormObj.richTextBoxSetterGetter.DeselectAll(); //unselect text in RTB
            parentFormObj.richTextBoxSetterGetter.Select(); //set focus back to the RTB
            //after choosing the items, close the style strip and the context menu
            this.removeStyleStrip.Visible = false;
            this.parentFormObj.showForm(this, 0);
        }

        //flagger; checks whether user has text selected or not
        private bool isTextSelected(RichTextBox localRTB)
        {
            int startIndex;
            int endIndex;

            if (localRTB.SelectionLength.Equals(0)) //if user don't select any text
            {
                startIndex = 0; //from beginning of RTB
                endIndex = localRTB.TextLength; //'til the end of RTB

                //--manage selected text in the RTB--
                localRTB.SelectionStart = startIndex;
                localRTB.SelectionLength = endIndex;

                localRTB.Select(localRTB.SelectionStart, localRTB.SelectionLength);
                //--manage selected text in the RTB--

                return false;
            }
            else if (!(localRTB.SelectionLength.Equals(0))) //if user has text selected
            {
                startIndex = localRTB.SelectionStart; //from beginning of RTB
                endIndex = localRTB.SelectionLength; //'til the end of RTB

                if (localRTB.SelectedText.Contains(" ")) //skips whitespaces if selected together with text
                {
                    if (localRTB.SelectedText.EndsWith(" "))
                    {
                        endIndex -= 1;
                    }
                }

                localRTB.Select(startIndex, endIndex);
                //--manage selected text in the RTB--

                return true;
            }

            //by default
            return false;
        }
    }
}
