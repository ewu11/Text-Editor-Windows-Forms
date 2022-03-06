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
        private MainFormEditor parentFormObj;
        private Point zoomFactorCSLocation;

        //not used, no info of parents
        public MatrixPopupMenu()
        {
            InitializeComponent();
        }

        public MatrixPopupMenu(MainFormEditor parentForm)
        {
            this.parentFormObj = parentForm;

            InitializeComponent();
        }

        private void MatrixPopupMenu_Deactivate(object sender, EventArgs e)
        {
            this.Visible = false;

            parentFormObj.toolStripStatusLabelSetterGetter.Text = "...";

            if(zoomFactorContextStrip.Visible == true)
            {
                //zoomFactorContextStrip.Close();
                zoomFactorContextStrip.Visible = false;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            /*if((e as MouseEventArgs).Button == MouseButtons.Left)
            {
                zoomFactorContextStrip.Show(button15, zoomFactorCSLocation);
            }*/
        }

        private void MatrixPopupMenu_Load(object sender, EventArgs e)
        {
            zoomFactorCSLocation = new Point(0, this.button15.Height);
        }

        private void button15_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.TopMost = true;
                zoomFactorContextStrip.Show(button15, zoomFactorCSLocation);
                //zoomFactorContextStrip.Visible = true;
            }
        }

        private void button15_MouseDown(object sender, MouseEventArgs e)
        {
            zoomFactorContextStrip.Close();
            //zoomFactorContextStrip.Visible = false;
        }
    }
}
