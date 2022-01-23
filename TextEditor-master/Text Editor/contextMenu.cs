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
    public partial class theContextMenu : Form
    {
        public theContextMenu()
        {
            InitializeComponent();
        }

        public bool ctrlKeyIsDownSetter
        {
            get { return ctrlKeyIsDown; }   // get method
            set { ctrlKeyIsDown = value; }  // set method
        }

        private void theContextMenu_Deactivate(object sender, EventArgs e)
        {
            ctrlKeyIsDown = false;
            this.Close();
        }
    }
}
