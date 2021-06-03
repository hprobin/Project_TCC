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
    public partial class MfVf_detail : Form
    {
        public MfVf_detail()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {
            label19.Text = "Mf : " + Math.Round(ShearForce.pos_Mf_X_sin, 2) + " kN*m";
            label18.Text = "Vf : " + Math.Round(ShearForce.pos_Vf_X_sin, 2) + " kN";
            label22.Text = "Mf : " + Math.Round(ShearForce.neg_Mf_X_sin, 2) + " kN*m";
            label20.Text = "Vf : " + Math.Round(ShearForce.neg_Vf_X_sin, 2) + " kN";

            label26.Text = "Mf : " + Math.Round(ShearForce.pos_Mf_Y_sin, 2) + " kN*m";
            label25.Text = "Vf : " + Math.Round(ShearForce.pos_Vf_Y_sin, 2) + " kN";
            label24.Text = "Mf : " + Math.Round(ShearForce.neg_Mf_Y_sin, 2) + " kN*m";
            label23.Text = "Vf : " + Math.Round(ShearForce.neg_Vf_Y_sin, 2) + " kN";

            label14.Text = "Mf : " + Math.Round(ShearForce.pos_Mf_X_con, 2) + " kN*m";
            label13.Text = "Vf : " + Math.Round(ShearForce.pos_Vf_X_con, 2) + " kN";
            label12.Text = "Mf : " + Math.Round(ShearForce.neg_Mf_X_con, 2) + " kN*m";
            label11.Text = "Vf : " + Math.Round(ShearForce.neg_Vf_X_con, 2) + " kN";

            label10.Text = "Mf : " + Math.Round(ShearForce.pos_Mf_Y_con, 2) + " kN*m";
            label9.Text = "Vf : " + Math.Round(ShearForce.pos_Vf_Y_con, 2) + " kN";
            label7.Text = "Mf : " + Math.Round(ShearForce.neg_Mf_Y_con, 2) + " kN*m";
            label4.Text = "Vf : " + Math.Round(ShearForce.neg_Vf_Y_con, 2) + " kN";


           

    }
    }
}
