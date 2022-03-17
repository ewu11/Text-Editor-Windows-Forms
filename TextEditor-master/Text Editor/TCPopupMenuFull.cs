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
        int removeStyleStripPos; //only used for button 13; need to be calculated early to fix positioning issues
        //rectangle colours
        Bitmap[] squareIcon = new Bitmap[5]; //create 5 array items named "squareIcon" with type "Bitmap"
        //need to create array so that can be easily accessed
        SolidBrush[] squareBrushes = new SolidBrush[5] { new SolidBrush(Color.Blue), 
                                                         new SolidBrush(Color.Red), 
                                                         new SolidBrush(Color.Yellow), 
                                                         new SolidBrush(Color.Green), 
                                                         new SolidBrush(Color.Purple) };
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
                removeStyleStrip.Show(button13, new Point(removeStyleStripPos, 0)); //cant use "visible" property; cant manage its location
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
                styleTokenStrip.Show(button14, new Point(this.button14.Width, 0)); //cant use "visible" property; cant manage its location
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
            removeStyleStripPos = -(this.removeStyleStrip.Width);

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
                    colourize.FillRectangle(squareBrushes[i], 1, 1, 5, 5);
                }
            }

            //set images to the style strip
            for (int i = 0; i < totalSquares; i++)
            {
                styleTokenStrip.Items[i].Image = squareIcon[i];
                removeStyleStrip.Items[i].Image = squareIcon[i];
            }
        }
    }
}
