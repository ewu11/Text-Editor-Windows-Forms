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
    public partial class PopupMenu : Form
    {
        //global variables
        private MainFormEditor parentFormObj;

        public PopupMenu() //unused, 'cuz doesn't have parent's object info
        {
            InitializeComponent();
        }

        public PopupMenu(MainFormEditor parentForm) //used; 'cuz have required parents obj info
        {
            parentFormObj = parentForm;
            InitializeComponent();
        }

        private void PopupMenu_Deactivate(object sender, EventArgs e)
        {
            this.Visible = false; //close the popup menu

            parentFormObj.toolStripStatusLabelSetterGetter.Text = "...";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parentFormObj.cutToolStripMenuItem1_Click(sender, e);
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parentFormObj.copyToolStripMenuItem1_Click(sender, e);
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            parentFormObj.pasteToolStripMenuItem1_Click(sender, e);
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            parentFormObj.deleteToolStripMenuItem_Click(sender, e);
            this.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            parentFormObj.selectAllToolStripMenuItem1_Click(sender, e);
            this.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            parentFormObj.clearAllToolStripMenuItem_Click(sender, e);
            this.Visible = false;
        }

        private void PopupMenu_Activated(object sender, EventArgs e)
        {
            //to maintain highlighted text
            parentFormObj.richTextBoxSetterGetter.HideSelection = false;
        }
    }
}
