using Project_TCC.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_TCC
{
    public partial class SelectForm : Form
    {
        public static Form get_layerproperties;
        public static Form shear_force;
        public static Form liveload;

        public static int slab;
        public SelectForm()
        {
            InitializeComponent();

            pbo_flat_slab.Click += ChangeForm;
            pbo_rib_slab.Click += ChangeForm;

            FormClosing += ConfirmClose;
        }
        private void ChangeForm(object sender, EventArgs e)
        {
            if (sender.Equals(this.pbo_flat_slab))
            {
                this.Hide();

                slab = 1;
                shear_force = new ShearForce();
                shear_force.Show();
                
            }
            else if (sender.Equals(this.pbo_rib_slab))
            {
                this.Hide();

                slab = 2;
                shear_force = new ShearForce();
                shear_force.Show();             
            }
            else if(sender.Equals(this.btnPrev))
            {
                this.Hide();

                liveload = new Select_LiveLoad();
                liveload.Show();
            }
        }
        private void ConfirmClose(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("프로그램을 종료하시겠습니까?", "종료", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
