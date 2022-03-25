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
    public partial class MatrixPopupMenuFull : Form
    {
        //global variable(s)
        private MainFormEditor parentFormObj;
        private Point zoomFactorCSLocation;
        private int bulletFlag = 0; //0 in default; bulletList off

        //not used, no info of parents
        public MatrixPopupMenuFull()
        {
            InitializeComponent();
        }

        public MatrixPopupMenuFull(MainFormEditor parentForm)
        {
            this.parentFormObj = parentForm;

            InitializeComponent();
        }

        private void MatrixPopupMenu_Deactivate(object sender, EventArgs e)
        {
            if (zoomFactorContextStrip.Visible == true)
            {
                zoomFactorContextStrip.Visible = false;
            }

            parentFormObj.showForm(this, 0);

            parentFormObj.toolStripStatusLabelSetterGetter.Text = "...";
        }

        private void MatrixPopupMenu_Load(object sender, EventArgs e)
        {
            zoomFactorCSLocation = new Point(0, this.button15.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parentFormObj.newMenuItem_Click(sender, e);
            parentFormObj.showForm(this, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parentFormObj.OpenMenuItem_Click(sender, e);
            parentFormObj.showForm(this, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            parentFormObj.saveToolStripMenuItem_Click(sender, e);
            parentFormObj.showForm(this, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            parentFormObj.printStripButton_Click(sender, e);
            parentFormObj.showForm(this, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            parentFormObj.printPreviewStripButton_Click(sender, e);
            parentFormObj.showForm(this, 0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            parentFormObj.undoToolStripMenuItem_Click(sender, e);
            parentFormObj.showForm(this, 0);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            parentFormObj.redoStripButton_Click(sender, e);
            parentFormObj.showForm(this, 0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            parentFormObj.cutToolStripMenuItem1_Click(sender, e);
            parentFormObj.showForm(this, 0);
        }

        private void button9_Click(object sender, EventArgs e)
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
            parentFormObj.deleteToolStripMenuItem_Click(sender, e);
            parentFormObj.showForm(this, 0);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            parentFormObj.selectAllToolStripMenuItem1_Click(sender, e);
            parentFormObj.showForm(this, 0);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            parentFormObj.clearAllToolStripMenuItem_Click(sender, e);
            parentFormObj.showForm(this, 0);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //---update this button's appearance---
            if(bulletFlag == 0) //if bulletList is not yet clicked
            {
                this.button14.FlatAppearance.BorderColor = SystemColors.GradientActiveCaption;
                this.button14.FlatAppearance.BorderSize = 3;
                bulletFlag = 1;
            }
            else //if bulletList is already clicked
            {
                this.button14.FlatAppearance.BorderColor = SystemColors.Window;
                this.button14.FlatAppearance.BorderSize = 0;
                bulletFlag = 0;
            }
            //---update this button's appearance---

            parentFormObj.bulletListStripButton_Click(sender, e);
            parentFormObj.showForm(this, 0);
        }

        //---button15 is dropdown; special case---
        //dropdown is represented by a "contextmenustrip"
        private void button15_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.TopMost = true;
                zoomFactorContextStrip.Show(button15, zoomFactorCSLocation); //cant use "visible" property; cant manage its location
            }
        }

        private void button15_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                zoomFactorContextStrip.Close();
            }
        }
        //---button15 is dropdown; special case---

        private void button16_Click(object sender, EventArgs e)
        {
            parentFormObj.exitToolStripMenuItem_Click(sender, e);
            parentFormObj.showForm(this, 0);
        }

        private void zoomFactorContextStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //to remove "checked" status
            //somehow cant managed by the parent, so code this here
            foreach (ToolStripMenuItem item in zoomFactorContextStrip.Items)
            {
                item.Image = null;
            }

            parentFormObj.zoomDropDownButton_DropDownItemClicked(sender, e);

            parentFormObj.showForm(this, 0);
        }

        //-----setter getter methods-----
        public ContextMenuStrip zoomFactorContextStripSetterGetter
        {
            get { return zoomFactorContextStrip; }
            set { zoomFactorContextStrip = value; }
        }

        public int bulletFlagSetterGetter
        {
            get { return this.bulletFlag; }
            set { this.bulletFlag = value; }
        }

        public Button button14SetterGetter
        {
            get { return this.button14; }
            set { this.button14 = value; }
        }
        //-----setter getter methods-----
    }
}
