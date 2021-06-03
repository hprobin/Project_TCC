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
    public partial class InputForm : Form
    {
        public static int design_concept = 1;
        public static double percentage;

        public static double EIeff_POS_Y;
        public static double EIeff_NEG_Y;
        public static double EIeff_POS_X;
        public static double EIeff_NEG_X;

        public static Form main_selectform;
        public static Form totalcheck;

        public static double EI_c;
        public static double EA_c;
        public static double a_c;
        public static double a_t;
        public static double gamma_t;
        public static double EI_t;
        public static double EA_t;
        public static double t_eff;
        public static double h_ceff;
        public static double gammatat;

        public static double gamma_s;
        public static double EA_s;
        public static double gamma_t_neg;
        public static double a_s;
        public static double gammatat_neg;
        public static double Es=200000;
        public static double steel_as;
        public InputForm()
        {
            InitializeComponent();
            Init();
            /*
            rbt_POS.Checked = true;
            rbt_BRI.Checked = true;

            rbt_POS.CheckedChanged += rbt_design_concept;
            rbt_NEG.CheckedChanged += rbt_design_concept;
            rbt_BRI.CheckedChanged += rbt_design_concept;
            rbt_YIE.CheckedChanged += rbt_design_concept;
            */

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
            calculate_EIeff_POS_Y();
            calculate_EIeff_POS_X();
            lblWidth.Text += ShearForce.SlabWidth.ToString() + "  mm";
            lblLength.Text += ShearForce.L.ToString() + " mm";
            lblThickness.Text += Get_LayerProperties.thickness.ToString() + "  mm";
            lbl_hc.Text += Get_LayerProperties.thickness.ToString() + " mm";
            lbl_seff.Text += Math.Round(Get_seff.s_eff, 2).ToString() + " mm";
            lbl_bc.Text += ShearForce.Bc.ToString() + " mm";
            lbl_bt.Text += Get_LayerProperties.Bt.ToString() + " mm";
            lbl_ht.Text += Get_LayerProperties.Ht.ToString() + " mm";
            lbl_t.Text += Get_LayerProperties.T.ToString() + " mm";
            lblLayer.Text += Get_LayerProperties.index.ToString();
            lbl_screwtype.Text += Get_ks.screwtype;
            label10.Text += Math.Round(Get_seff.K, 2).ToString() + " kN/mm2";
            
        }
        /*
        private void rbt_design_concept(object sender, EventArgs e)
        {
            if (rbt_POS.Checked && rbt_BRI.Checked == true)
            {
                design_concept = 1;
                POS_BOX();
                pbo_TCC1.Image = global::Project_TCC.Properties.Resources.TCC_POS1;
                pbo_TCC2.Image = global::Project_TCC.Properties.Resources.TCC_POS2;
                calculate_EIeff_POS();
            }
            if (rbt_NEG.Checked && rbt_BRI.Checked == true)
            {
                design_concept = 2;
                NEG_BOX();
                pbo_TCC1.Image = global::Project_TCC.Properties.Resources.TCC_NEG1;
                pbo_TCC2.Image = global::Project_TCC.Properties.Resources.TCC_NEG2;
                lbl_eat.Text = ":" + " " + Math.Round(EA_t, 2).ToString();
            }
            if (rbt_POS.Checked && rbt_YIE.Checked == true)
            {
                design_concept = 3;
                POS_BOX();
                pbo_TCC1.Image = global::Project_TCC.Properties.Resources.TCC_POS1;
                pbo_TCC2.Image = global::Project_TCC.Properties.Resources.TCC_POS2;
                calculate_EIeff_POS();
            }
            if (rbt_NEG.Checked && rbt_YIE.Checked == true)
            {
                design_concept = 4;
                NEG_BOX();
                pbo_TCC1.Image = global::Project_TCC.Properties.Resources.TCC_NEG1;
                pbo_TCC2.Image = global::Project_TCC.Properties.Resources.TCC_NEG2;
                lbl_eat.Text = ":" + " " + Math.Round(EA_t, 2).ToString();
            }

        }
        */
        public void calculate_EIeff_POS_Y()
        {                        
                EI_t = Get_LayerProperties.Et * Convert.ToDouble(Get_LayerProperties.Bt) * Convert.ToDouble(Math.Pow(Get_LayerProperties.Ht, 3)) / 12;
                EA_t = Get_LayerProperties.Et * Convert.ToDouble(Get_LayerProperties.Bt) * Convert.ToDouble(Get_LayerProperties.Ht);
                
                double K = Get_seff.K;
                double gamma_c = 1;
            if (ShearForce.span_split == 1) {
                gamma_t = 1 / (1 + (Math.Pow(Math.PI, 2) * EA_t / (Math.Pow(ShearForce.sin_pos_L, 2) * K)));
            }
            else if (ShearForce.span_split == 2)
            {
                gamma_t = 1 / (1 + (Math.Pow(Math.PI, 2) * EA_t / (Math.Pow(ShearForce.con_pos_L, 2) * K)));

            }
            double alpha = (gamma_t * EA_t) / (gamma_c * Get_LayerProperties.Ec * ShearForce.Bc);

                h_ceff = Math.Sqrt(Math.Pow(alpha, 2) + (alpha * (Get_LayerProperties.Ht + 2 * Get_LayerProperties.thickness + 2 * Get_LayerProperties.T))) - alpha;

                t_eff = Get_LayerProperties.T + Get_LayerProperties.thickness - h_ceff;

                double r = 0.5 * Get_LayerProperties.Ht + t_eff + 0.5 * h_ceff;
                EI_c = (Get_LayerProperties.Ec * ShearForce.Bc * Math.Pow(h_ceff, 3)) / 12;

                EA_c = Get_LayerProperties.Ec * ShearForce.Bc * h_ceff;

                a_c = (gamma_t * EA_t * r) / ((gamma_c * EA_c) + (gamma_t * EA_t));

                a_t = (gamma_c * EA_c * r) / (gamma_c * EA_c + gamma_t * EA_t);
                gammatat = gamma_t * a_t;
                
                EIeff_POS_Y = EI_c + EI_t + (gamma_c * EA_c * Math.Pow(a_c, 2)) + (gamma_t * EA_t * Math.Pow(a_t, 2));

                lbl_teff.Text = ":" + " " + Math.Round(t_eff, 2).ToString() + " mm";
                lbl_hceff.Text = ":" + " " + Math.Round(h_ceff, 2).ToString() + " mm";
                lbl_ac.Text = ":" + " " + Math.Round(a_c, 2).ToString() + " mm";
                lbl_at.Text = ":" + " " + Math.Round(a_t, 2).ToString() + " mm";
                lbl_gammatat.Text = ":" + " " + Math.Round(gammatat, 2).ToString() + " mm";
            
        }
        private void calculate_EIeff_NEG_Y()
        {
           
                double K = Get_seff.K;
                EI_t = Get_LayerProperties.Et * Convert.ToDouble(Get_LayerProperties.Bt) * Convert.ToDouble(Math.Pow(Get_LayerProperties.Ht, 3)) / 12;
                EA_t = Get_LayerProperties.Et * Convert.ToDouble(Get_LayerProperties.Bt) * Convert.ToDouble(Get_LayerProperties.Ht);
             if (ShearForce.span_split == 1)
            {
                gamma_t_neg = 1 / (1 + (Math.Pow(Math.PI, 2) * EA_t / (Math.Pow(ShearForce.sin_neg_L, 2) * K)));
            }
            else if (ShearForce.span_split == 2)
            {
                gamma_t_neg = 1 / (1 + (Math.Pow(Math.PI, 2) * EA_t / (Math.Pow(ShearForce.con_neg_L, 2) * K)));

            }

                gamma_s = Convert.ToDouble(tbo_gammas.Text);
                a_s = (EA_t * Convert.ToDouble(tbo_r.Text)) / (Convert.ToDouble(tbo_gammas.Text) * EA_s + gamma_t_neg * EA_t);

                a_t = (gamma_s * EA_s * Convert.ToDouble(tbo_r.Text)) / ((gamma_s * EA_s) + (gamma_t_neg * EA_t));
                EIeff_NEG_Y = EI_t + gamma_s * EA_s * Math.Pow(a_s, 2) + gamma_t_neg * EA_t * Math.Pow(a_t, 2);
                double gammatat_neg = gamma_t_neg * a_t;

                lbl_at_neg.Text = ":" + " " + Math.Round(a_t, 2).ToString() + " mm";
                lbl_as_neg.Text = ":" + " " + Math.Round(a_s, 2).ToString() + " mm";
                lbl_gammatat_neg.Text = ":" + " " + Math.Round(gammatat_neg, 2).ToString() + " mm";
                lbl_eat.Text = ":" + " " + Math.Round(EA_t, 2).ToString() + " N";                       
        }
        public void calculate_EIeff_POS_X()
        {
            EI_t = Get_LayerProperties.Et * Convert.ToDouble(Get_LayerProperties.Bt) * Convert.ToDouble(Math.Pow(Get_LayerProperties.Ht, 3)) / 12;
            EA_t = Get_LayerProperties.Et * Convert.ToDouble(Get_LayerProperties.Bt) * Convert.ToDouble(Get_LayerProperties.Ht);

            double K = Get_seff.K_m;
            double gamma_c = 1;
            if (ShearForce.span_split == 1)
            {
                gamma_t = 1 / (1 + (Math.Pow(Math.PI, 2) * EA_t / (Math.Pow(ShearForce.Bc, 2) * K)));
            }
            else if (ShearForce.span_split == 2)
            {
                gamma_t = 1 / (1 + (Math.Pow(Math.PI, 2) * EA_t / (Math.Pow(ShearForce.Bc, 2) * K)));

            }
            double alpha = (gamma_t * EA_t) / (gamma_c * Get_LayerProperties.Ec * ShearForce.Bc);

            h_ceff = Math.Sqrt(Math.Pow(alpha, 2) + (alpha * (Get_LayerProperties.Ht + 2 * Get_LayerProperties.thickness + 2 * Get_LayerProperties.T))) - alpha;

            t_eff = Get_LayerProperties.T + Get_LayerProperties.thickness - h_ceff;

            double r = 0.5 * Get_LayerProperties.Ht + t_eff + 0.5 * h_ceff;
            EI_c = (Get_LayerProperties.Ec * ShearForce.Bc * Math.Pow(h_ceff, 3)) / 12;

            EA_c = Get_LayerProperties.Ec * ShearForce.Bc * h_ceff;

            a_c = (gamma_t * EA_t * r) / ((gamma_c * EA_c) + (gamma_t * EA_t));

            a_t = (gamma_c * EA_c * r) / (gamma_c * EA_c + gamma_t * EA_t);
            gammatat = gamma_t * a_t;

            EIeff_POS_X = EI_c + EI_t + (gamma_c * EA_c * Math.Pow(a_c, 2)) + (gamma_t * EA_t * Math.Pow(a_t, 2))+600;

           

        }
        private void calculate_EIeff_NEG_X()
        {

            double K = Get_seff.K_m;
            EI_t = Get_LayerProperties.Et * Convert.ToDouble(Get_LayerProperties.Bt) * Convert.ToDouble(Math.Pow(Get_LayerProperties.Ht, 3)) / 12;
            EA_t = Get_LayerProperties.Et * Convert.ToDouble(Get_LayerProperties.Bt) * Convert.ToDouble(Get_LayerProperties.Ht);

            if (ShearForce.span_split == 1)
            {
                gamma_t_neg = 1 / (1 + (Math.Pow(Math.PI, 2) * EA_t / (Math.Pow(ShearForce.Bc, 2) * K)));
            }
            else if (ShearForce.span_split == 2)
            {
                gamma_t_neg = 1 / (1 + (Math.Pow(Math.PI, 2) * EA_t / (Math.Pow(ShearForce.Bc, 2) * K)));

            }

            gamma_s = Convert.ToDouble(tbo_gammas.Text);
            a_s = (EA_t * Convert.ToDouble(tbo_r.Text)) / (Convert.ToDouble(tbo_gammas.Text) * EA_s + gamma_t_neg * EA_t);

            a_t = (gamma_s * EA_s * Convert.ToDouble(tbo_r.Text)) / ((gamma_s * EA_s) + (gamma_t_neg * EA_t));
            EIeff_NEG_X = EI_t + gamma_s * EA_s * Math.Pow(a_s, 2) + gamma_t_neg * EA_t * Math.Pow(a_t, 2);
            double gammatat_neg = gamma_t_neg * a_t;

           

        }


        private void ChangeForm(object sender, EventArgs e)
        {
            if (sender.Equals(this.btnPrev))
            {
                this.Hide();
                Get_ks.get_seff.Show();
            }
            else if (sender.Equals(this.btnNext))
            {
                this.Hide();
                /*
                if (design_concept == 1)
                {
                    calculate_EIeff_POS();
                }
                if (design_concept == 2)
                {
                    calculate_EIeff_NEG();
                }
                if (design_concept == 3)
                {
                    calculate_EIeff_POS();
                }
                if (design_concept == 4)
                {
                    calculate_EIeff_NEG();
                }
                */
                //calculate_EIeff_NEG();
                totalcheck = new ULS_Check();
                totalcheck.Show();
            }
        }
        private void POS_BOX()
        {
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;

            //그림에 label
            lbl_hc.Visible = true;
            lbl_bc.Visible = true;
            lbl_bt.Visible = true;
            lbl_hceff.Visible = true;
            lbl_ht.Visible = true;
            lbl_t.Visible = true;
            lbl_teff.Visible = true;
            lbl_gammatat.Visible = true;
            lbl_at.Visible = true;
            lbl_ac.Visible = true;

            lbl_r.Visible = false;
            lbl_eas.Visible = false;
            lbl_at_neg123.Visible = false;


        }
        private void NEG_BOX()
        {
            groupBox4.Visible = true;
            groupBox5.Visible = true;
            groupBox6.Visible = true;
            groupBox7.Visible = true;
            //그림 label
            lbl_hc.Visible = false;
            lbl_bc.Visible = false;
            lbl_bt.Visible = false;
            lbl_hceff.Visible = false;
            lbl_ht.Visible = false;
            lbl_t.Visible = false;
            lbl_teff.Visible = false;
            lbl_gammatat.Visible = false;
            lbl_at.Visible = false;
            lbl_ac.Visible = false;

            lbl_r.Visible = true;
            lbl_eas.Visible = true;
            lbl_at_neg123.Visible = true;
        }
        private void ConfirmClose(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("프로그램을 종료하시겠습니까?", "종료", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        //그림에 있는 label달기
        private void tbo_r_TextChanged(object sender, EventArgs e)
        {
            if (tbo_r.Text != "")
                lbl_r.Text = ":" + "  " + Convert.ToString(tbo_r.Text) + " mm";
        }

        private void tbo_percentage_TextChanged(object sender, EventArgs e)
        {
            if (tbo_percentage.Text != "")
            {
                percentage = Convert.ToDouble(tbo_percentage.Text);
                steel_as= ShearForce.Bc * Get_LayerProperties.Hc * percentage / 100;
                EA_s = Es*steel_as;                
                lbl_eas.Text = ":" + " " + Math.Round(EA_s, 2).ToString()+" N";
                lbl_as.Text = ":" + " " + Math.Round(steel_as, 2).ToString() + " mm2";

            }
        }


        private void btn_apply_Click(object sender, EventArgs e)
        {
            calculate_EIeff_NEG_Y();
            calculate_EIeff_NEG_X();
        }
    }
}
