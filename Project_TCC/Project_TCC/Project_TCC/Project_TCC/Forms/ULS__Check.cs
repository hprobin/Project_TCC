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
    public partial class ULS_Check : Form
    {
        public static Form newuls_check;

        public ULS_Check()
        {
            InitializeComponent();
            Init();
            btnEIeff.Click += ChangeForm;
            btnPrev.Click += ChangeForm;
            btnNext.Click += ChangeForm;

            FormClosing += ConfirmClose;
        }
        private void Init()
        {
            if (SelectForm.slab == 1)
            {
                lbl_Type_of_Slab.Text += " flat slab";
            }
            else if (SelectForm.slab == 2)
            {
                lbl_Type_of_Slab.Text += " rib slab";
            }

            lblEIeff_POS.Text = Math.Round(InputForm.EIeff_POS_Y/1000000000,2).ToString() + " kN⋅m²";
            lblEIeff_NEG.Text = Math.Round(InputForm.EIeff_NEG_Y / 1000000000, 2).ToString()+ " kN⋅m²";

            label25.Text = Math.Round(InputForm.EIeff_POS_X / 1000000000, 2).ToString() + " kN⋅m²";
            label23.Text = Math.Round(InputForm.EIeff_NEG_X / 1000000000, 2).ToString() + " kN⋅m²";


            if (Get_ks.screw_option==1)
                pboSystem.Image = global::Project_TCC.Properties.Resources.screw2;
            if (Get_ks.screw_option == 2)
                pboSystem.Image = global::Project_TCC.Properties.Resources.notch;
            if (Get_ks.screw_option == 3)
                pboSystem.Image = global::Project_TCC.Properties.Resources.metal;
            if (Get_ks.screw_option == 4)
                pboSystem.Image = global::Project_TCC.Properties.Resources.dowel;

            lblWidth.Text += ShearForce.SlabWidth.ToString() + "  mm";
            lblLength.Text += ShearForce.L.ToString() + " mm";
            lblThickness.Text += Get_LayerProperties.thickness.ToString() + "  mm";
            //lbl_hc.Text += Get_LayerProperties.thickness.ToString() + " mm";
            lbl_seff.Text += Math.Round(Get_seff.s_eff, 2).ToString() + " mm";
            //lbl_bc.Text += Get_LayerProperties.L.ToString() + " mm";
            //lbl_bt.Text += Get_LayerProperties.Bt.ToString() + " mm";
            //lbl_ht.Text += Get_LayerProperties.Ht.ToString() + " mm";
            //lbl_t.Text += Get_LayerProperties.T.ToString() + " mm";
            lblLayer.Text += Get_LayerProperties.index.ToString();
            lbl_screwtype.Text += Get_ks.screwtype;
            label10.Text += Math.Round(Get_seff.K, 2).ToString() + " kN/mm2";
            //lbl_as.Text += Math.Round(Get_LayerProperties.Bc * Get_LayerProperties.Hc, 2) + " mm2";
            lbl_concrete.Text += Get_LayerProperties.concrete.ToString();
            lbl_timber.Text += Get_LayerProperties.timber.ToString();
            label15.Text += Get_LayerProperties.timber.ToString() ;
            label16.Text += Get_LayerProperties.concrete.ToString();
            lbl_bc.Text += ShearForce.Bc.ToString() + " mm";
            label14.Text += Get_LayerProperties.thickness.ToString() + " mm";
            label17.Text += Get_LayerProperties.Ht.ToString() + " mm";
            label18.Text += Get_ks.d.ToString() + " mm";
            label20.Text += Get_LayerProperties.T.ToString() + "mm";
            label21.Text += (Get_LayerProperties.thickness + Get_LayerProperties.Ht + Get_LayerProperties.T).ToString() + "mm";
        }




        private void ChangeForm(object sender, EventArgs e)
        {
            if (sender.Equals(this.btnEIeff))
            {
                Form form = new EIeff_Detail_Form();
                form.Show();
            }
            else if (sender.Equals(this.btnPrev))
            {
                this.Hide();
                Get_seff.slabinputform.Show();
            }
            else if (sender.Equals(this.btnNext))
            {
                this.Hide();
                newuls_check = new NewULS();
                newuls_check.Show();
            
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
