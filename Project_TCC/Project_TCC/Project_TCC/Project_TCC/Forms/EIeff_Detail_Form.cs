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
    public partial class EIeff_Detail_Form : Form
    {
        public EIeff_Detail_Form()
        {
            InitializeComponent();
            Init();
        
        }
        public void Init()
        {
                pictureBox1.Image = global::Project_TCC.Properties.Resources.EIeff_detail_pos;
                pictureBox2.Image = global::Project_TCC.Properties.Resources.EIeff_detail_neg;

            

                lbl1.Text = Math.Round(InputForm.EI_c/1000000000,2).ToString() + " kN⋅m²";
                lbl2.Text = Math.Round(InputForm.EI_t / 1000000000, 2).ToString() + " kN⋅m²";
                lbl3.Text = "1";
                lbl4.Text = Math.Round(InputForm.gamma_t, 2).ToString();
                lbl5.Text = Math.Round(InputForm.EA_c/1000, 2).ToString()+" kN";
                lbl6.Text = Math.Round(InputForm.EA_t/1000, 2).ToString() + " kN";
                lbl7.Text = Math.Round(InputForm.a_t, 2).ToString()+" mm";
                lbl8.Text = Math.Round(InputForm.a_c, 2).ToString() + " mm";

            
            
                

                lbl10.Text = Math.Round(InputForm.EI_t / 1000000000, 2).ToString() + " kN⋅m²";
                lbl11.Text = Math.Round(InputForm.gamma_s, 2).ToString();
                lbl12.Text = Math.Round(InputForm.gamma_t_neg, 2).ToString();
                lbl13.Text = Math.Round(InputForm.a_s, 2).ToString() + " mm";
                lbl14.Text = Math.Round(InputForm.EA_s/1000, 2).ToString() + " kN";
                lbl15.Text = Math.Round(InputForm.EA_t/1000, 2).ToString() + " kN";
                lbl16.Text = Math.Round(InputForm.a_t,2).ToString() + " mm";

        }
    }
}

