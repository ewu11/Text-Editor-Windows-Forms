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
    public partial class VertPopupMenu : Form
    {
        //global cariable(s)
        MainFormEditor parentFormObj;

        public VertPopupMenu()
        {
            InitializeComponent();
        }

        public VertPopupMenu(MainFormEditor parentForm)
        {
            parentFormObj = parentForm;
            InitializeComponent();
        }

        private void VertPopupMenu_Deactivate(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
