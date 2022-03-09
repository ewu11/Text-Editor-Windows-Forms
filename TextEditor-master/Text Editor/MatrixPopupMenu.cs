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
    public partial class MatrixPopupMenu : Form
    {
        //global variable(s)
        MainFormEditor parentFormObj;

        public MatrixPopupMenu()
        {
            InitializeComponent();
        }

        public MatrixPopupMenu(MainFormEditor parentForm)
        {
            parentFormObj = parentForm;

            InitializeComponent();
        }

        private void MatrixPopupMenu_Deactivate(object sender, EventArgs e)
        {
            this.Visible = false;

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
            parentFormObj.clearAllToolStripMenuItem_Click(sender, e);
            this.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            parentFormObj.selectAllToolStripMenuItem1_Click(sender, e);
            this.Visible = false;
        }

        private void MatrixPopupMenu_Activated(object sender, EventArgs e)
        {
            parentFormObj.richTextBoxSetterGetter.HideSelection = false;
        }        
    }
}
