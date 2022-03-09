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
    public partial class HoriPopupMenu : Form
    {
        //global variables
        MainFormEditor parentFormObj;
        public HoriPopupMenu()
        {
            InitializeComponent();
        }

        public HoriPopupMenu(MainFormEditor parentForm)
        {
            parentFormObj = parentForm;

            InitializeComponent();
        }

        private void HoriPopupMenu_Deactivate(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
