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
    public partial class PopupMenuFull : Form
    {
        //global variable(s)
        frmEditor parentFormObj;

        //not used; no parent info
        public PopupMenuFull()
        {
            InitializeComponent();
        }

        //used; cuz obtains parent's info; able to access parents data
        public PopupMenuFull(frmEditor parentForm)
        {
            this.parentFormObj = parentForm;
            InitializeComponent();
        }

        //-----popup menu button functions-----
        private void PopupMenuFull_Deactivate(object sender, EventArgs e)
        {
            this.Visible = false;

            parentFormObj.toolStripStatusLabelSetterGetter.Text = "...";

            //close the popup menu
            showPopupMenu(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parentFormObj.newMenuItem_Click(sender, e);
            showPopupMenu(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            parentFormObj.OpenMenuItem_Click(sender, e);
            showPopupMenu(0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            parentFormObj.saveToolStripMenuItem_Click(sender, e);
            showPopupMenu(0);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            parentFormObj.printStripButton_Click(sender, e);
            showPopupMenu(0);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            parentFormObj.printPreviewStripButton_Click(sender, e);
            showPopupMenu(0);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            parentFormObj.exitToolStripMenuItem_Click(sender, e);
            showPopupMenu(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parentFormObj.undoToolStripMenuItem_Click(sender, e);
            showPopupMenu(0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            parentFormObj.redoStripButton_Click(sender, e);
            showPopupMenu(0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            parentFormObj.cutToolStripMenuItem1_Click(sender, e);
            showPopupMenu(0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            parentFormObj.copyToolStripMenuItem1_Click(sender, e);
            showPopupMenu(0);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            parentFormObj.pasteToolStripMenuItem1_Click(sender, e);
            showPopupMenu(0);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            parentFormObj.deleteToolStripMenuItem_Click(sender, e);
            showPopupMenu(0);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            parentFormObj.selectAllToolStripMenuItem1_Click(sender, e);
            showPopupMenu(0);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            parentFormObj.clearAllToolStripMenuItem_Click(sender, e);
            showPopupMenu(0);
        }

        private void PopupMenuFull_Activated(object sender, EventArgs e)
        {
            parentFormObj.richTextBoxSetterGetter.HideSelection = false;
        }
        //-----popup menu button functions-----

        private void showPopupMenu(int flag)
        {
            switch(flag)
            {
                case 0: //hide the popup menu
                    this.Visible = false;
                    Console.WriteLine("Context menu closed!");
                    break;
                case 1: //show the popup menu
                    this.Visible = true;
                    Console.WriteLine("Context menu opened!");
                    break;
                default:
                    Console.WriteLine("Invalid function argument!");
                    break;

            }
        }
    }
}
