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
    public partial class Get_ks : Form
    {
        public static Form get_seff;
        public static double d = 0;
        public static double Ks;
        public static double E0mean = 0;
        public static double screw_option=1;
        public static string screwtype="screw connector";
        public static double Sina ;
        public static double Cosa ;
        public static double Lef ;
        public static double Pm;
        public Get_ks()
        {
            InitializeComponent();
            Init();

            rbt_screw.Checked = true;
            rbt_ks_equation.Checked = true;

            //screw select
            rbt_screw.CheckedChanged += rbt_connector_option;
            rbt_metal.CheckedChanged += rbt_connector_option;
            rbt_notch.CheckedChanged += rbt_connector_option;
            rbt_dowel.CheckedChanged += rbt_connector_option;
            //study select
            rbt_scr_eur.CheckedChanged += rbt_connector_option;
            rbt_scr_zahn.CheckedChanged += rbt_connector_option;
            rbt_scr_cecco.CheckedChanged += rbt_connector_option;
            rbt_scr_gelfi.CheckedChanged += rbt_connector_option;
            rbt_scr_tomasi.CheckedChanged += rbt_connector_option;
            rbt_scr_marchi.CheckedChanged += rbt_connector_option;

            radioButton7.CheckedChanged += rbt_connector_option;
            radioButton8.CheckedChanged += rbt_connector_option;

            radioButton23.CheckedChanged += rbt_connector_option;
            radioButton22.CheckedChanged += rbt_connector_option;

            radioButton17.CheckedChanged += rbt_connector_option;
            radioButton16.CheckedChanged += rbt_connector_option;

            //metal plate 추가 옵션
            radioButton6.CheckedChanged += rbt_connector_option;
            radioButton9.CheckedChanged += rbt_connector_option;
            //dowel 추가 옵션
            radioButton10.CheckedChanged += rbt_connector_option;
            radioButton11.CheckedChanged += rbt_connector_option;
            radioButton12.CheckedChanged += rbt_connector_option;
            radioButton13.CheckedChanged += rbt_connector_option;

            rbt_ks_database.CheckedChanged += rbt_connector_option;
            rbt_ks_equation.CheckedChanged += rbt_connector_option;


            btnPrev.Click += ChangeForm;
            btnNext.Click += ChangeForm;
        }
        private void Init()
        {
            Gbo_equations_screw.Visible = true;
            Gbo_equations_notch.Visible = false;
            Gbo_equations_metal.Visible = false;
            Gbo_equations_dowel.Visible = false;

            label9.Text = Get_LayerProperties.Bt.ToString()+" mm";
            label10.Text = ShearForce.SlabWidth.ToString() + " mm";
            label11.Text = Get_LayerProperties.thickness.ToString() + " mm";
            label12.Text = Get_LayerProperties.T.ToString() + " mm";
            label13.Text = Get_LayerProperties.Ht.ToString() + " mm";
            label14.Text += (Get_LayerProperties.thickness + Get_LayerProperties.Ht + Get_LayerProperties.T).ToString() + "mm";
        }
        private void rbt_connector_option(object sender, EventArgs e)
        {
            calculate_Ks();
            if (rbt_screw.Checked == true)
            {
                screw_option = 1;
                screwtype = "screw connector";
            }
            if (rbt_notch.Checked == true)
            {
                screw_option = 2;
                screwtype = "notch connector";
            }
            if (rbt_metal.Checked == true)
            {
                screwtype = "metal connector";
                screw_option = 3;
            }
            if (rbt_dowel.Checked == true)
            {
                screwtype = "dowel connector";
                screw_option = 4;
            }
        }
        private void calculate_Ks()
        {
            double total_density = 0;
            //받아야되는값 일단 선언
            Pm = 0; //density 값 받아 오기                 
            for (int i = 0; i < Get_LayerProperties.index; i++)
            {
                total_density = total_density + Get_LayerProperties.density[i];
                Pm = total_density / Get_LayerProperties.index;
            }
            double total_E = 0;

            for (int i = 0; i < Get_LayerProperties.index; i++)
            {
                total_E = total_E + Get_LayerProperties.E0mean[i];
                E0mean = total_E / Get_LayerProperties.index;
            }
            
            if (SelectForm.slab == 1)
            {
                //천천히 코딩 할게요 
            }
            else if (SelectForm.slab == 2)
            {
                //pbo_rib_screw.Visible = true;

                if (rbt_ks_database.Checked == true)
                {
                    Gbo_equations_screw.Visible = false;
                    Gbo_equations_notch.Visible = false;
                    Gbo_equations_metal.Visible = false;
                    Gbo_equations_dowel.Visible = false;
                    groupBox1.Visible = false;
                    dataGridView1.Visible = true;
                    //데이터 베이스
                }

                else if (rbt_ks_equation.Checked == true)
                {
                    groupBox4.Visible = false;
                    groupBox5.Visible = false;
                    groupBox1.Visible = true;
                    dataGridView1.Visible = false;
                    if (rbt_screw.Checked == true)
                    {
                        lbl_diameter.Visible = true;
                        tbo_diameter.Visible = true;
                        label8.Visible = true;
                        pbo_TCC1.Image = global::Project_TCC.Properties.Resources.screw2;
                        Gbo_equations_screw.Visible = true;
                        Gbo_equations_notch.Visible = false;
                        Gbo_equations_metal.Visible = false;
                        Gbo_equations_dowel.Visible = false;
                        //rbt_scr_eur.Checked = true;
                        groupBox8.Visible = false;
                        if (rbt_scr_eur.Checked == true)
                        {
                            groupBox6.Visible = false;
                            lblKs.Text = Math.Round((2 * (Math.Pow(Pm, 1.5) * d) / 23 / 1000), 2).ToString();
                            Ks = (2 * (Math.Pow(Pm, 1.5) * d) / 23 / 1000);
                        }
                        else if (rbt_scr_zahn.Checked == true)
                        {
                            groupBox6.Visible = false;
                            lblKs.Text = Math.Round((2 * 246 * (Math.Pow(d, 1.5)) / 1000)-d*0.4, 2).ToString();
                            Ks = (2 * 246 * (Math.Pow(d, 1.5)) / 1000 - d * 0.4);
                        }
                        else if (rbt_scr_cecco.Checked == true)
                        {
                            groupBox6.Visible = false;
                            lblKs.Text = Math.Round(((0.125 * E0mean * d / 1000))-d*2, 2).ToString();
                            Ks = ((0.125 * E0mean * d / 1000)-d*2 );
                        }
                        else if (rbt_scr_gelfi.Checked == true)
                        {
                            groupBox6.Visible = false;
                            lblKs.Text = Math.Round(((124000 * d / (Math.Pow(4.34 + Get_LayerProperties.T / d, 3)) / 1000)) + d * 1.1, 2).ToString();
                            Ks = (((124000 * d) / (Math.Pow(4.34 + (Get_LayerProperties.T / d), 3)) / 1000)) + d * 1.1;
                        }
                        if (rbt_scr_tomasi.Checked == true)
                        {
                            groupBox6.Visible = true;
                            

                            lblKs.Text = Math.Round(((2 * 2 * (Math.Pow(Pm, 1.5) * d) / 23 * Math.Pow(Sina, 2) / 1000 +
                            234 * (Math.Pow(d * Pm, 0.2) * Math.Pow(Lef, 0.4) * Math.Pow(Cosa, 2)) / 1000)-3), 2).ToString();

                            Ks = ((2 * 2 * (Math.Pow(Pm, 1.5) * d) / 23 * Math.Pow(Sina, 2) / 1000 +
                            234 * (Math.Pow(d * Pm, 0.2) * Math.Pow(Lef, 0.4) * Math.Pow(Cosa, 2)) / 1000)-3);
                        }
                        if (rbt_scr_marchi.Checked == true)
                        {
                            groupBox6.Visible = true;
                            lblKs.Text = Math.Round(((780*Math.Pow(d,0.2)*Math.Pow(Lef,0.4)*Sina*(Sina+Cosa)/1000+
                                         (2*Math.Pow(Pm,1.5)*d/23*(Cosa-Sina))/1000))+7 + d * 0.07,2).ToString();
                            Ks = ((780 * Math.Pow(d, 0.2) * Math.Pow(Lef, 0.4) * Sina * (Sina + Cosa))/1000 +
                                         (2 * Math.Pow(Pm, 1.5) * d / 23 * (Cosa - Sina))/1000)+7+d*0.07;
                        }

                    }
                    else if (rbt_notch.Checked == true)
                    {
                        lbl_diameter.Visible = false;
                        tbo_diameter.Visible = false;
                        label8.Visible = false;
                        pbo_TCC1.Image = global::Project_TCC.Properties.Resources.notch;
                        groupBox6.Visible = false;
                        groupBox4.Visible = false;
                        groupBox5.Visible = false;
                        Gbo_equations_screw.Visible = false;
                        Gbo_equations_notch.Visible = true;
                        Gbo_equations_metal.Visible = false;
                        Gbo_equations_dowel.Visible = false;
                        groupBox1.Visible = false;
                        groupBox8.Visible = true;
                        if (radioButton8.Checked == true)
                        {
                            label16.Text = "1000";
                            Ks = 1000;
                        }
                        if (radioButton7.Checked == true)
                        {
                            label16.Text = "1500";
                            Ks = 1500;
                        }
                    }
                    else if (rbt_metal.Checked == true)
                    {
                        lbl_diameter.Visible = true;
                        tbo_diameter.Visible = true;
                        label8.Visible = true;
                        pbo_TCC1.Image = global::Project_TCC.Properties.Resources.metal;
                        groupBox6.Visible = false;
                        groupBox5.Visible = false;
                        Gbo_equations_metal.Visible = true;
                        Gbo_equations_screw.Visible = false;
                        Gbo_equations_notch.Visible = false;
                        Gbo_equations_dowel.Visible = false;
                        groupBox8.Visible = false;
                        pictureBox3.Visible = true;
                        if (radioButton22.Checked == true)
                        {
                            //metal national

                            groupBox4.Visible = true;
                            if (radioButton6.Checked == true)
                            {
                                lblKs.Text = "87.56";
                                Ks = 87.5634175;
                            }
                            else if (radioButton9.Checked == true)
                            {
                                lblKs.Text = "70.05";
                                Ks = 70.050734;
                            }
                        }
                        if (radioButton23.Checked == true)
                        {
                            lblKs.Text = Math.Round(((2 * Pm * d / 2) / 1000)+5, 2).ToString();
                            Ks = (2 * Pm * d / 2 / 1000)+5;
                        }
                    }


                    else if (rbt_dowel.Checked == true)
                    {
                        lbl_diameter.Visible = true;
                        tbo_diameter.Visible = true;
                        label8.Visible = true;
                        pbo_TCC1.Image = global::Project_TCC.Properties.Resources.dowel;
                        groupBox6.Visible = false;
                        groupBox4.Visible = false;
                        groupBox5.Visible = true;
                        Gbo_equations_dowel.Visible = true;
                        Gbo_equations_metal.Visible = false;
                        Gbo_equations_screw.Visible = false;
                        Gbo_equations_notch.Visible = false;
                        groupBox8.Visible = false;
                        if (radioButton16.Checked == true)
                        {
                            radioButton10.Visible = true;
                            radioButton11.Visible = true;
                            radioButton12.Visible = false;
                            radioButton13.Visible = false;
                            if (radioButton10.Checked == true)
                            {
                                lblKs.Text = Math.Round((2 * Math.Pow(Pm, 1.5) * d / 23 / 1000), 2).ToString();
                                Ks = (2 * Math.Pow(Pm, 1.5) * d / 23 / 1000);
                            }
                            else if (radioButton11.Checked == true)
                            {
                                lblKs.Text = Math.Round((2 * Math.Pow(Pm, 1.5) * Math.Pow(d, 0.8) / 23 / 1000)+3, 2).ToString();
                                Ks = (2 * Math.Pow(Pm, 1.5) * Math.Pow(d, 0.8) / 23 / 1000) + 3;
                            }

                        }
                        if (radioButton17.Checked == true)
                        {
                            radioButton10.Visible = false;
                            radioButton11.Visible = false;
                            radioButton12.Visible = true;
                            radioButton13.Visible = true;
                            if (radioButton12.Checked == true)
                            {
                                lblKs.Text = Math.Round((31.52 * Math.Pow(d, 1.5) / 1000)+10, 2).ToString();
                                Ks = (31.52 * Math.Pow(d, 1.5) / 1000) + 10;
                            }
                            else if (radioButton13.Checked == true)
                            {
                                lblKs.Text = Math.Round((47.28 * Math.Pow(d, 1.5) / 1000)+10, 2).ToString();
                                Ks = (47.28 * Math.Pow(d, 1.5) / 1000)+10;
                            }
                        }
                    }
                }
            }
        }
        private void ChangeForm(object sender, EventArgs e)
        {
            if (sender.Equals(this.btnPrev))
            {
                this.Hide();
                ShearForce.get_layerproperties.Show();

            }
            else if (sender.Equals(this.btnNext))
            {
                this.Hide();
                get_seff = new Get_seff();
                get_seff.Show();
            }
        }

        private void tbo_diameter_TextChanged(object sender, EventArgs e)
        {
            if (tbo_diameter.Text != "")
            {
                d = Convert.ToDouble(tbo_diameter.Text);
                calculate_Ks();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (textBox1.Text == "30")
                {
                    Sina = 0.5;
                    Cosa = Math.Sqrt(3) / 2;
                }
                if (textBox1.Text == "45")
                {
                    Sina = Math.Sqrt(2) / 2;
                    Cosa = Math.Sqrt(2) / 2;
                }
                if (textBox1.Text == "60")
                {
                    Cosa = 0.5;
                    Sina = Math.Sqrt(3) / 2;
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                Lef = Convert.ToDouble(textBox2.Text);
                calculate_Ks();

            }
        }
    }
}
