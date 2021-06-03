using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_TCC.Forms
{
    public partial class Startpage : Form
    {
        public static Form liveload;

        public Startpage()
        {
            InitializeComponent();
        }

        private void Startpage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            liveload = new Select_LiveLoad();
            liveload.Show();
        }
    }
}
