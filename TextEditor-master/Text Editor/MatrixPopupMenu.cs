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
        }
    }
}
