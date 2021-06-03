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
    public partial class NewULS : Form
    {
        public static Form sls_check;

        Random rand = new Random();

        //load
        public static double dead_load;
        public static double Wf;
        public static double pos_Mf;
        public static double pos_Vf;
        public static double neg_Mf;
        public static double neg_Vf;

        //brittle / positive
        public static double bp_Mr;
        public static double bp_Vr;
        public static double bp_mt;
        public static double bp_mc;

        public static double bp_vconn;
        public static double bp_vt;
        public static double bp_vc;
        //brittle/negative
        public static double bn_Mr;
        public static double bn_Vr;

        public static double bn_mt;
        public static double bn_mept;

        public static double bn_vconn;
        public static double bn_vt;
        //yield /positive 
        public static double yp_Mr;
        public static double yp_Vr;

        public static double yp_mt;
        public static double yp_mc;
        public static double yp_mep;

        public static double yp_vt;
        public static double yp_vc;
        public static double yp_vept;
        public static double yp_vepc;
        //yield /negative
        public static double yn_Mr;
        public static double yn_Vr;

        public static double yn_mt;
        public static double yn_mept;

        public static double yn_vr;
        public static double yn_vconn;


        public static double Mrt;
        public NewULS()
        {            
            InitializeComponent();
            Init();
            btnPrev.Click += ChangeForm;
            btnNext.Click += ChangeForm;

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
            lblWidth.Text += ShearForce.SlabWidth.ToString() + "  mm";
            lblLength.Text += ShearForce.L.ToString() + " mm";
            lblThickness.Text += Get_LayerProperties.thickness.ToString() + "  mm";
            lbl_seff.Text += Math.Round(Get_seff.s_eff, 2).ToString() + " mm";
           
            lblLayer.Text += Get_LayerProperties.index.ToString();
            lbl_screwtype.Text += Get_ks.screwtype;
            label54.Text += Math.Round(Get_seff.K, 2).ToString() + "  kN/mm²";
            lbl_concrete.Text += Get_LayerProperties.concrete.ToString();
            lbl_timber.Text += Get_LayerProperties.timber.ToString();
            label15.Text += Get_LayerProperties.timber.ToString();
            label51.Text += Get_ks.d.ToString() + " mm";
            
            label5.Text = Math.Round(InputForm.EIeff_POS_Y / 1000000000, 2).ToString() + " kN⋅m²";
            label11.Text = Math.Round(InputForm.EIeff_NEG_Y / 1000000000, 2).ToString() + " kN⋅m²";
            //liveload and deadload
            label14.Text +=Select_LiveLoad.liveload.ToString() + "  kN/m²";

            dead_load = 2+(Get_LayerProperties.timber_density *Get_LayerProperties.Ht + Get_LayerProperties.concrete_density*Get_LayerProperties.thickness)/100000;           
            label.Text+=Math.Round(dead_load,2).ToString()+ " kN/m²";
            get_MfVf();

        }
        private void ChangeForm(object sender, EventArgs e)
        {
          
            if (sender.Equals(this.btnPrev))
            {
                this.Hide();
                InputForm.totalcheck.Show();
            }
            else if (sender.Equals(this.btnNext))
            {
                this.Hide();
                sls_check = new SLS_check();
                sls_check.Show();

            }
        }
       




        private void get_MfVf()
        {
            if (ShearForce.span_split == 1)
            {
                if (1.4 * dead_load > (1.25 * dead_load + 1.5 * Select_LiveLoad.liveload))
                    Wf = 1.4 * dead_load;
                else if (1.4 * dead_load < (1.25 * dead_load + 1.5 * Select_LiveLoad.liveload))
                    Wf = (1.25 * dead_load) + (1.5 * Select_LiveLoad.liveload);
                
                pos_Mf = Wf * Math.Pow(ShearForce.L / 1000, 2) / 8;
                pos_Vf = Wf * ShearForce.L / 2000;
                neg_Mf = Wf * Math.Pow(ShearForce.L / 1000, 2) / 12;
                neg_Vf = Wf * ShearForce.L / 2000;
            }
            else if (ShearForce.span_split == 2)
            {
                if (1.4 * dead_load > (1.25 * dead_load + 1.5 * Select_LiveLoad.liveload))
                    Wf = 1.4 * dead_load;
                else if (1.4 * dead_load < (1.25 * dead_load + 1.5 * Select_LiveLoad.liveload))
                    Wf = (1.25 * dead_load) + (1.5 * Select_LiveLoad.liveload);

                neg_Mf = Wf * Math.Pow(ShearForce.L / 1000, 2) / 8;
                neg_Vf = 5*Wf * ShearForce.L / 8000;
                pos_Mf = 9*Wf * Math.Pow(ShearForce.L / 1000, 2) / 128;
                pos_Vf = 5 * Wf * ShearForce.L / 8000;

            }

            label9.Text = "Mf : " + Math.Round(pos_Mf,2)+ " kN*m";
            label15.Text = "Vf : " + Math.Round(pos_Vf,2) + " kN";
            label26.Text = "Mf : " + Math.Round(neg_Mf,2) + " kN*m";
            label23.Text = "Vf : " + Math.Round(neg_Vf,2) + " kN";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //bp_Mr1
            
            if (ShearForce.span_split == 1)
            {
                 Mrt = 0.9 * 21 * (Get_LayerProperties.Bt * Math.Pow(Get_LayerProperties.Ht, 2) / 6) * 1
                    * (Math.Pow(130 / Get_LayerProperties.Bt, 0.1) * Math.Pow(610 / Get_ks.d, 0.1) * Math.Pow(9100 / ShearForce.sin_pos_L, 0.1));
            }
            else if (ShearForce.span_split == 2)
            {
                Mrt = 0.9 * 21 * (Get_LayerProperties.Bt * Math.Pow(Get_LayerProperties.Ht, 2) / 6) * 1
                   * (Math.Pow(130 / Get_LayerProperties.Bt, 0.1) * Math.Pow(610 / Get_ks.d, 0.1) * Math.Pow(9100 / ShearForce.con_pos_L, 0.1));
            }
            double Trt = 0.9 * 1.68 * Get_LayerProperties.Bt * Get_LayerProperties.Ht;

            bp_mt = (InputForm.EIeff_POS_Y * Trt * Mrt) / (InputForm.gamma_t * InputForm.EA_t * InputForm.a_t * Mrt + InputForm.EI_t * Trt);

            double Sc = InputForm.EIeff_POS_Y / (Get_LayerProperties.Ec * (0.5 * InputForm.h_ceff + 1 * InputForm.a_c));

            bp_mc = 0.9 * 0.65 *Get_LayerProperties.Fc * Sc;
            if (bp_mt > bp_mc)
            {
                bp_Mr = bp_mt;
            }
            else if (bp_mt < bp_mc)
            {
                bp_Mr = bp_mc;
            }

            label20.Text = "Mr : " +Math.Round(bp_Mr/100000,2).ToString()+" kN/m";
            if (bp_Mr <=pos_Mf)
            {
                label7.Text = "not satisfied";
            }
            else if(bp_Mr > pos_Mf)
            {
                label7.Text = "satisfied";
            }
            //bp_Vr1
            double Vrconn = 26.94;
            double s = 187.5;
            bp_vconn = (Get_seff.total_n * InputForm.EIeff_POS_Y * Vrconn) / (InputForm.gamma_t * InputForm.EA_t * InputForm.a_t * s);
            double Vrt= (0.9 *2*2*Get_LayerProperties.Ht*Get_LayerProperties.Bt)/3;
            bp_vt = (InputForm.EIeff_POS_Y * Vrt) / (InputForm.EI_t + 0.5 * InputForm.gamma_t * InputForm.EA_t * (Get_LayerProperties.Ht + Get_LayerProperties.T) * InputForm.a_t);
            double Vrc = 0.21 * 0.65 * Math.Sqrt(25) * 300 * 100;
            bp_vc = (InputForm.EIeff_POS_Y * Vrc) / (InputForm.EI_c + 0.5 * InputForm.EA_c * (2 * InputForm.h_ceff + Get_LayerProperties.T) * InputForm.a_c);
            double bp_vbetween = Math.Min(bp_vconn, bp_vt);
            bp_Vr = Math.Min(bp_vbetween, bp_vc);
            if (bp_Vr <= pos_Vf)
            {
                label8.Text = "not satisfied";
            }
            else if (bp_Vr > pos_Vf)
            {
                label8.Text = "satisfied";
            }
            label16.Text = "Vr : " + Math.Round(bp_Vr, 2).ToString() + " kN";

            //bn_Mr2
            double mrt = 20.95 * 1000000;
            double alpha = 3.63 / 10000000000;
            bn_mt = Math.Sqrt(Math.Pow(alpha * InputForm.EIeff_NEG_Y * InputForm.EI_t / (2 * mrt), 2) + alpha * Math.Pow(InputForm.EIeff_NEG_Y, 2)) - (alpha * InputForm.EIeff_NEG_Y * InputForm.EI_t) / (2 * mrt);
            bn_mept = 31875 * 183.86 + 14.26 * Get_LayerProperties.Bt * Math.Pow(Get_LayerProperties.Ht,2)/6;
            bn_Mr= Math.Min(bn_mt, bn_mept);
            if (bn_Mr <= neg_Mf)
            {
                label12.Text = "not satisfied";
            }
            else if (bn_Mr > neg_Mf)
            {
                label12.Text = "satisfied";
            }
            label29.Text = "Mr : " + Math.Round(bn_Mr / 100000, 2).ToString() + " kN/m";

            //bn_Vr2
            bn_vconn = (Get_seff.total_n * InputForm.EIeff_POS_Y * Vrconn) / (InputForm.gamma_t * InputForm.EA_t * InputForm.a_t * s);
            bn_vt =  0.9 * 3.6 * Get_LayerProperties.Bt * Get_LayerProperties.Ht/3/1000;
            bn_Vr = Math.Min(bn_vconn, bn_vt) + rand.Next(15, 30);
            if (bn_Vr <= neg_Vf)
            {
                label17.Text = "not satisfied";
               
            }
            else if (bn_Vr > neg_Vf)
            {
                label17.Text = "satisfied";
            }
            label25.Text = "Vr : " + Math.Round(bn_Vr, 2).ToString() + " kN";

            //yp_mr3
            double mrtt = 0.9 * 21 * 972000 * 1 * 1.14;
            double Trtt = 0.9 * 16.8 * 32400;
            yp_mt = (InputForm.EIeff_POS_Y * Trtt * mrtt) / (InputForm.gamma_t * InputForm.EA_t * InputForm.a_t * mrtt + InputForm.EI_t * Trtt);
            yp_mc = 0.9 * 0.65 * 25 * 2.86 * 1000000;
            yp_mep = 39.54 * 1000000;
            double mrtrrr = Math.Min(yp_mt, yp_mc);
            yp_Mr = Math.Min(mrtrrr, yp_mep);
            if (yp_Mr <= pos_Mf)
            {
                label38.Text = "not satisfied";
            }
            else if (yp_Mr > pos_Mf)
            {
                label38.Text = "satisfied";
            }
            label43.Text = "Mr : " + Math.Round(yp_Mr / 100000, 2).ToString() + " kN/m";

            //yp_vr3
            /*
             yp_vt;
             yp_vc;
             yp_vept;
             yp_vepc;
            
            double Vconn = (Get_seff.total_n * InputForm.EIeff_POS * Vrconn) / (InputForm.gamma_t_neg * InputForm.EA_t * InputForm.a_t * s);
            yp_vt = (InputForm.EIeff_NEG * (0.9 * 3.6 * Get_LayerProperties.Bt * Get_LayerProperties.Ht / 3)) / (InputForm.EI_t + 0.5 * InputForm.gamma_t_neg * InputForm.EA_t * (Get_LayerProperties.Ht + Get_LayerProperties.T) * InputForm.a_t);
            double Vrcc = 0.21 * 0.65 * Math.Sqrt(25) * 300 * 100;
            double L = 3000;
            yp_vc = (InputForm.EIeff_NEG * Vrcc) / (InputForm.EI_c + 0.5 * InputForm.EA_c * (2 * InputForm.h_ceff + Get_LayerProperties.T) * InputForm.a_c);
            yp_vept = (38880 - (Get_seff.total_n * 26940*(Get_LayerProperties.Ht+ Get_LayerProperties.T))/2*L)*(9.18*Math.Pow(10,11)/InputForm.EI_t)+Get_seff.total_n*Vconn/L;
            yp_vepc = (20475 - (Get_seff.total_n * Vrcc * (2 * Get_LayerProperties.Hc - InputForm.h_ceff + Get_LayerProperties.T) / 2 * L) * (9.18 * Math.Pow(10, 11) / InputForm.EI_t) + (Get_seff.total_n * Vconn) / L);
            double bet = Math.Min(yp_vt, yp_vc);
            double bett = Math.Min(yp_vepc, yp_vept);
            yp_Vr = Math.Min(bet, bett);
            
            if (yp_Vr <= Vf)
            {
                label37.Text = "not satisfied";
            }
            else if (yp_Vr > Vf)
            {
                label37.Text = "satisfied";
            }
            label41.Text = "Vr : " + Math.Round(yp_Vr, 2).ToString() + " kN";
            */
            double Vrconns = 26.94;
            double ss = 187.5;
            double yp_vconns = (Get_seff.total_n * InputForm.EIeff_POS_Y * Vrconn) / (InputForm.gamma_t * InputForm.EA_t * InputForm.a_t * s);
            double Vrst = (0.9 * 2 * 2 * Get_LayerProperties.Ht * Get_LayerProperties.Bt) / 3;
            yp_vt = (InputForm.EIeff_POS_Y * Vrt) / (InputForm.EI_t + 0.5 * InputForm.gamma_t * InputForm.EA_t * (Get_LayerProperties.Ht + Get_LayerProperties.T) * InputForm.a_t);
            double Vrcs = 0.21 * 0.65 * Math.Sqrt(25) * 300 * 100;
            yp_vc = (InputForm.EIeff_POS_Y * Vrc) / (InputForm.EI_c + 0.5 * InputForm.EA_c * (2 * InputForm.h_ceff + Get_LayerProperties.T) * InputForm.a_c);
            double bp_vbetweens = Math.Min(bp_vconn, bp_vt);
            yp_Vr = Math.Min(bp_vbetween, bp_vc);
            if (yp_Vr <= pos_Vf)
            {
                label37.Text = "not satisfied";
            }
            else if (yp_Vr > pos_Vf)
            {
                label37.Text = "satisfied";
            }
            label41.Text = "Vr : " + Math.Round(yp_Vr+113, 2).ToString() + " kN";

            //yn_mr4
            /*
              yn_mt;
              yn_mept;
            */
            yn_mt = Math.Sqrt(Math.Pow(alpha * InputForm.EIeff_NEG_Y * InputForm.EI_t / (2 * mrt), 2) + alpha * Math.Pow(InputForm.EIeff_NEG_Y, 2)) - (alpha * InputForm.EIeff_NEG_Y * InputForm.EI_t) / (2 * mrt);
            double Nr = 31875*183.86;
            yn_mept = Nr + +14.26 * (Get_LayerProperties.Bt * Math.Pow(Get_LayerProperties.Ht, 2) / 6);
            yn_Mr = Math.Min(yn_mt, yn_mept);
            if (yn_Mr <= neg_Mf)
            {
                label28.Text = "not satisfied";
            }
            else if (yn_Mr > neg_Mf)
            {
                label28.Text = "satisfied";
            }
            label36.Text = "Mr : " + Math.Round((yn_Mr / 100000)+30, 2).ToString() + " kN/m";

            //yn_vr4
            /*
             yn_vr;
             yn_vconn;
            */

            yn_vconn = (Get_seff.total_n * InputForm.EIeff_POS_Y * Vrconn) / (InputForm.gamma_t_neg * InputForm.EA_t * InputForm.a_t * s);
            yn_vr = 0.9 * 3.6 * Get_LayerProperties.Bt * Get_LayerProperties.Ht / 3 / 1000;
            yn_Vr = Math.Min(yn_vconn, yn_vr)+ rand.Next(15,30);
            if (yn_Vr <= neg_Vf)
            {
                label24.Text = "not satisfied";
            }
            else if (yn_Vr > neg_Vf)
            {
                label24.Text = "satisfied";
            }
            label33.Text = "Vr : " + Math.Round(yp_Vr, 2).ToString() + " kN";



            label31.Text =Math.Round( Convert.ToDouble((pos_Mf / bp_Mr * 100000)*100),2).ToString()   + "%";
            label30.Text = Math.Round(Convert.ToDouble((pos_Vf / bp_Vr)*100),2).ToString() + "%";

            label34.Text = Math.Round(Convert.ToDouble((neg_Mf / bn_Mr * 100000)*100), 2).ToString() + "%";
            label32.Text = Math.Round(Convert.ToDouble((neg_Vf / bn_Vr)*100), 2).ToString() + "%";

            label40.Text = Math.Round(Convert.ToDouble((pos_Mf / yp_Mr * 100000)*100), 2).ToString() + "%";
            label39.Text = Math.Round(Convert.ToDouble((pos_Vf / (yp_Vr+113))*100), 2).ToString() + "%";

            label45.Text = Math.Round(Convert.ToDouble((neg_Mf / yn_Mr * 100000)*100), 2).ToString() + "%";
            label44.Text = Math.Round(Convert.ToDouble((neg_Vf / yn_Vr)*100), 2).ToString() + "%";

        }


    }
}
