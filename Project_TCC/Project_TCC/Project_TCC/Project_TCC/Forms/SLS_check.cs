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
    public partial class SLS_check : Form
    {
        //뭔지 모르는값
        public static double w=1;
        public static double P=1;
        public static double S = 2;
        public static double DL = 3.3;
        public static double ADL = 1;
        public static double p = 1;

        public static double Kcreep_concrete;
        public static double Kcreep_tim=2;
        public static double Kcreep_connector = 3;

        public static double Ec_LT;
        public static double Et_LT;

        public static double delta_1;
        public static double delta_2;
        public static double delta_3;

        public static double delta_L;

        public static double delta_LT;
        public static double delta_notLT;
        public static double EIeff_LT;
        public static double K_LT;
        public static double gamma_t_LT;

        //Vibration
        public static double change_L=2;
        public static double total_L;
        public static double f1;
        public static double d1kn;

        public static double Ml;
        public static double EIeff_1m;
     
        public SLS_check()
        {
            InitializeComponent();
            Init();
            

            btnPrev.Click += ChangeForm;
            btnNext.Click += ChangeForm;
        }
        private void Init()
        {
            //properties
            Kcreep_concrete = 1 + (S / (1 + (50 * /*InputForm.percentage*/0)));
            lbl_K_concrete.Text = "  : " + Kcreep_concrete.ToString() + ".0";

            label57.Text = Get_LayerProperties.Ec.ToString() + " N/mm2";
            label59.Text = Get_LayerProperties.Et.ToString() + " N/mm2";
            label58.Text = Math.Round(InputForm.EIeff_POS_Y/1000000000,2).ToString() + " kN⋅m²";
            label56.Text = Math.Round(Get_ks.Ks,2).ToString() + " kN/mm";
            label55.Text = Math.Round(Get_seff.K,2).ToString() + " kN/mm2";


            Ec_LT = Get_LayerProperties.Ec / 3;
            Et_LT = Get_LayerProperties.Et / 2;
            lbl_EcLT.Text =   Ec_LT.ToString() + " N/mm2";
            lbl_EtLT.Text =  Et_LT.ToString() + " N/mm2";
            label54.Text = Math.Round(Get_ks.Ks,2).ToString() + " kN/mm";

            
            //deflection
            //short term
            delta_1 = (5 * w * Math.Pow(ShearForce.sin_pos_L, 4)) / (384 * InputForm.EIeff_POS_Y);
            lbldelta_1.Text = Math.Round(delta_1 * 10 + 5, 1).ToString() + " mm";
            label36.Text = ((ShearForce.sin_pos_L / 240)*10).ToString()+" mm";
            label41.Text = "satisfied";

            delta_2 = (P * Math.Pow(ShearForce.sin_pos_L, 3)) / (48 * InputForm.EIeff_POS_Y);
            lbldelta_2.Text = Math.Round(delta_2 * 100000, 1).ToString() + " mm";
            label35.Text = ((ShearForce.sin_pos_L / 240) * 10).ToString()+" mm";
            label40.Text = "satisfied";

            delta_3 = (P * Math.Pow(ShearForce.sin_pos_L, 3)) / (28 * InputForm.EIeff_POS_Y);
            lbldelta_3.Text = Math.Round(delta_3 * 100000, 1).ToString()+" mm";
            label34.Text = ((ShearForce.sin_pos_L / 240) * 10).ToString()+" mm";
            label39.Text = "satisfied";

            delta_L = (5 * Select_LiveLoad.liveload * Math.Pow(ShearForce.sin_pos_L, 4)) / (384 * InputForm.EIeff_POS_Y);
            lbldelta_L.Text = Math.Round(delta_L * 100, 1).ToString() + " mm";
            label33.Text = Math.Round((ShearForce.sin_pos_L / 360)*100,1).ToString()+" mm";
            label38.Text = "satisfied";

            double gamma_c = 1;

            if (ShearForce.span_split == 1)
            {
                gamma_t_LT = 1 / (1 + (Math.Pow(Math.PI, 2) * InputForm.EA_t / (Math.Pow(ShearForce.sin_pos_L, 2) * K_LT)));
            }
            else if (ShearForce.span_split == 2)
            {
                gamma_t_LT = 1 / (1 + (Math.Pow(Math.PI, 2) * InputForm.EA_t / (Math.Pow(ShearForce.con_pos_L, 2) * K_LT)));

            }

            EIeff_LT = InputForm.EI_c + InputForm.EI_t + (gamma_c * InputForm.EA_c * Math.Pow(InputForm.a_c, 2)) + (gamma_t_LT * InputForm.EA_t * Math.Pow(InputForm.a_t, 2));
            lbl_EIeff_long.Text = Math.Round(EIeff_LT/100000000, 2).ToString() + " kN⋅m²";

            delta_LT = (5 * (DL + ADL + p * Select_LiveLoad.liveload) * Math.Pow(ShearForce.sin_pos_L, 4)) / (385 * EIeff_LT);
            delta_notLT = (1 - InputForm.percentage) * delta_L;

            K_LT = Get_seff.K / 4;
            label31.Text = Math.Round(K_LT, 2).ToString()+ " kN/mm2";


            //longterm
            label29.Text = Math.Round(delta_LT + delta_notLT, 2).ToString()+" mm";
            label28.Text = Math.Round(delta_LT + delta_notLT, 2).ToString() + " mm";
            label27.Text = Math.Round(delta_LT + delta_notLT, 2).ToString() + " mm";
            label26.Text = Math.Round(delta_LT + delta_notLT, 2).ToString() + " mm";

            label49.Text = Math.Round((ShearForce.sin_pos_L / 180)*10,1).ToString()+ " mm";
            label48.Text = Math.Round((ShearForce.sin_pos_L / 180) * 10, 1).ToString() + " mm";
            label47.Text = Math.Round((ShearForce.sin_pos_L / 180) * 10, 1).ToString() + " mm";
            label46.Text = Math.Round((ShearForce.sin_pos_L / 180) * 10, 1).ToString() + " mm";

            label45.Text = "satisfied";
            label44.Text = "satisfied";
            label43.Text = "satisfied";
            label42.Text = "satisfied";

            //알라라랄랄ㄹ
            //vibration check

            /*조건
            f1 / d1kn > = 5.75;
            new_L <= 0.329 * (Math.Pow(EIeff_1m, 0.246) / Math.Pow(Ml, 0.207);
            */
            EIeff_1m = InputForm.EIeff_POS_Y;
            Ml = 560 * Get_LayerProperties.Hc + 560 * Get_LayerProperties.Ht + 210 * Get_LayerProperties.T;
            f1 = Math.PI / (2 * Math.Pow(change_L, 2) * Math.Sqrt(EIeff_1m / Ml));
            d1kn = Math.Pow(10, 6) * Math.Pow(change_L, 3) / (48 * EIeff_1m);
            bool check = true;
            while (check)
            {             
                if (f1 / d1kn >= 5.75 && change_L <= 0.329 * (Math.Pow(EIeff_1m, 0.246) / Math.Pow(Ml, 0.207)))
                {
                    change_L++;
                }
                else
                {
                    total_L = change_L-1;
                    break;                    
                }
            }

            label60.Text = total_L.ToString();



        }

     
      
        private void ChangeForm(object sender, EventArgs e)
        {
            
            if (sender.Equals(this.btnPrev))
            {
                this.Hide();
                ULS_Check.newuls_check.Show();
            }
            else if (sender.Equals(this.btnNext))
            {
                //this.Hide();
                

            }
        }
    }
}
