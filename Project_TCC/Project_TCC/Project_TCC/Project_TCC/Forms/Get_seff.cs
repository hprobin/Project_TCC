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
    public partial class Get_seff : Form
    {
   
        public static Form slabinputform;

        public static double s_eff;//계산된 Seff값

        public static double s_eff_m;

        public static int Seff = 1;//seff 디자인 컨셉 라디오 버튼
        
        //다음 dimension으로 넘겨줄 값들
        //원래 major 방향 으로 구하던 변수들
        public static double smax_value;
        public static string ScrewType;
        public static double K;

        public static double n1;
        public static double n2;
        public static double total_n;

        //minor 방향으로 구할 변수들
        public static double smax_value_m;
        public static double K_m;
        public static double m1;
        public static double m2;
        public static double total_m;

        
        //private string[] Screws(efij_) = { };
        public Get_seff()
        {
            InitializeComponent();            
            Init();
         
            rbt_Seff1.Checked = true;

            rbt_Seff1.CheckedChanged += Seff_concept;
            rbt_Seff2.CheckedChanged += Seff_concept;
            radioButton1.CheckedChanged+= Seff_concept;
            radioButton2.CheckedChanged += Seff_concept;


            btnPrev.Click += ChangeForm;
            btnNext.Click += ChangeForm;

        }
        private void Init()
        {
            if (SelectForm.slab == 1)
            {
               
                ScrewType = "CLT-Concrete composite slab \n" +
                    "with a single inclined screw";
              
            }
            else if (SelectForm.slab == 2)
            {
                
              
                ScrewType = "CLT-Glulam beam with\n" +
                    " vertical screw connectors";
              
            }
        }
   
        private void Seff_concept(object sender, EventArgs e)
        {
            if (rbt_Seff1.Checked)
                Seff = 1;
            else if (rbt_Seff2.Checked)
                Seff = 2;
        }
        private void ChangeForm(object sender, EventArgs e)
        {
            if (sender.Equals(this.btnPrev))
            {
                this.Hide();
                Get_LayerProperties.get_ks.Show();
               
            }
            else if (sender.Equals(this.btnNext))
            {
                this.Hide();
                total_n = n1 + n2;
                slabinputform = new InputForm();
                slabinputform.Show();
            }
        }
       
            //seff를 구하기 위한 함수
        private void tbo_n2_TextChanged(object sender, EventArgs e)
        {
            calculate_seff();
            n2 = Convert.ToDouble(tbo_n2.Text);
        }
        private void tbo_n1_TextChanged(object sender, EventArgs e)
        {
            calculate_seff();
            n1 = Convert.ToDouble(tbo_n1.Text);

        }
        private void rbt_Seff1_CheckedChanged(object sender, EventArgs e)
        {
            if (tbo_smax.Text != "" && tbo_smin.Text != "" && tbo_n1.Text != "" && tbo_n2.Text != "")
            {
                s_eff = 0.75 * Convert.ToDouble(tbo_smin.Text) / Convert.ToDouble(tbo_n1.Text) + 0.25 * Convert.ToDouble(tbo_smax.Text) / Convert.ToDouble(tbo_n2.Text);
                lblSeff.Text = Math.Round(s_eff, 2).ToString();
                lbl_k.Text = Math.Round(Get_ks.Ks*1000/s_eff, 2).ToString();
                K = Get_ks.Ks*1000 / s_eff;

            }
        }

        private void rbt_Seff2_CheckedChanged(object sender, EventArgs e)
        {
            if (tbo_smax.Text != "" && tbo_smin.Text != "" && tbo_n1.Text != "" && tbo_n2.Text != "")
            {
                s_eff = 0.67 * Convert.ToDouble(tbo_smin.Text) / Convert.ToDouble(tbo_n1.Text) + 0.33 * Convert.ToDouble(tbo_smax.Text) / Convert.ToDouble(tbo_n2.Text);
                lblSeff.Text = Math.Round(s_eff, 2).ToString();
                lbl_k.Text = Math.Round(Get_ks.Ks*1000 / s_eff, 2).ToString();
                 K = Get_ks.Ks*1000 / s_eff;

            }
        }


       
       
        //그림에 label값 바꾸기
        private void tbo_smin_TextChanged(object sender, EventArgs e)
        {
            if (tbo_smin.Text != "")
            {
                lbl_smin.Text = ":" + "  " + Convert.ToString(tbo_smin.Text);
                tbo_smax.Text = Convert.ToString(tbo_smin.Text);
                smax_value = Convert.ToDouble(tbo_smax.Text);
            }
            calculate_seff();
        }

        private void tbo_smax_TextChanged(object sender, EventArgs e)
        {
            if (tbo_smax.Text != "")
            {
                lbl_smax.Text = ":" + "  " + Convert.ToString(tbo_smax.Text);
            }
            calculate_seff();
        }



       public void calculate_seff()
        {
            if (tbo_smax.Text != "" && tbo_smin.Text != "" && tbo_n1.Text != "" && tbo_n2.Text != "")
            {
                if (tbo_smin.Text!=tbo_smax.Text) {
                    if (Seff == 1)
                        s_eff = 0.75 * Convert.ToDouble(tbo_smin.Text) / Convert.ToDouble(tbo_n1.Text) + 0.25 * Convert.ToDouble(tbo_smax.Text) / Convert.ToDouble(tbo_n2.Text);
                    else if (Seff == 2)
                        s_eff = 0.67 * Convert.ToDouble(tbo_smin.Text) / Convert.ToDouble(tbo_n1.Text) + 0.33 * Convert.ToDouble(tbo_smax.Text) / Convert.ToDouble(tbo_n2.Text);
                    lblSeff.Text = Math.Round(s_eff, 2).ToString();

                }
                else if(Convert.ToDouble(tbo_smin.Text) == smax_value)
                {
                    if (Seff == 1)
                        s_eff = 0.75 * Convert.ToDouble(tbo_smin.Text) + 0.25 * Convert.ToDouble(tbo_smax.Text);
                    else if (Seff == 2)
                        s_eff = 0.67 * Convert.ToDouble(tbo_smin.Text) + 0.33 * Convert.ToDouble(tbo_smax.Text);
                    lblSeff.Text = Math.Round(s_eff, 2).ToString();

                }
            }
        }




        //minor 방향

        public void calculate_seff_m()
        {
            if (textBox8.Text != "" && textBox7.Text != "" && textBox6.Text != "" && textBox5.Text != "")
            {
                if (textBox7.Text != textBox8.Text)
                {
                    if (Seff == 1)
                        s_eff_m = 0.75 * Convert.ToDouble(textBox7.Text) / Convert.ToDouble(textBox6.Text) + 0.25 * Convert.ToDouble(textBox8.Text) / Convert.ToDouble(textBox5.Text);
                    else if (Seff == 2)
                        s_eff_m = 0.67 * Convert.ToDouble(textBox7.Text) / Convert.ToDouble(textBox6.Text) + 0.33 * Convert.ToDouble(textBox8.Text) / Convert.ToDouble(textBox5.Text);
                    label23.Text = Math.Round(s_eff_m, 2).ToString();

                }
                else if (Convert.ToDouble(textBox7.Text) == smax_value_m)
                {
                    if (Seff == 1)
                        s_eff_m = 0.75 * Convert.ToDouble(textBox7.Text) + 0.25 * Convert.ToDouble(textBox8.Text);
                    else if (Seff == 2)
                        s_eff_m = 0.67 * Convert.ToDouble(textBox7.Text) + 0.33 * Convert.ToDouble(textBox8.Text);
                    label23.Text = Math.Round(s_eff_m, 2).ToString();

                }
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            calculate_seff_m();
            m1 = Convert.ToDouble(tbo_n1.Text);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            calculate_seff_m();
            m2 = Convert.ToDouble(textBox5.Text);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text != "")
            {
                //lbl_smin.Text = ":" + "  " + Convert.ToString(textBox7.Text);
                textBox8.Text = Convert.ToString(textBox7.Text);
                smax_value_m = Convert.ToDouble(textBox8.Text);
            }
            calculate_seff_m();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text != "")
            {
                //lbl_smax.Text = ":" + "  " + Convert.ToString(textBox8.Text);
            }
            calculate_seff_m();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (tbo_smax.Text != "" && tbo_smin.Text != "" && tbo_n1.Text != "" && tbo_n2.Text != "")
            {
                s_eff_m = 0.75 * Convert.ToDouble(textBox7.Text) / Convert.ToDouble(textBox6.Text) + 0.25 * Convert.ToDouble(textBox8.Text) / Convert.ToDouble(textBox5.Text);
                label23.Text = Math.Round(s_eff_m, 2).ToString();
                label25.Text = Math.Round(Get_ks.Ks * 1000 / s_eff_m, 2).ToString();
                K_m = Get_ks.Ks * 1000 / s_eff_m;

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox8.Text != "" && textBox7.Text != "" && textBox6.Text != "" && textBox5.Text != "")
            {
                s_eff_m = 0.67 * Convert.ToDouble(textBox7.Text) / Convert.ToDouble(textBox6.Text) + 0.33 * Convert.ToDouble(textBox8.Text) / Convert.ToDouble(textBox5.Text);
                label23.Text = Math.Round(s_eff_m, 2).ToString();
                label25.Text = Math.Round(Get_ks.Ks * 1000 / s_eff_m, 2).ToString();
                K_m = Get_ks.Ks * 1000 / s_eff_m;

            }
        }
    }
}
