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
    public partial class ShearForce : Form
    {
        Graphics g;
        Pen wood_pen;
        SolidBrush steel_brush;
        public static Form get_layerproperties;
        public static Form main_selectform;

        public static string wall_height_string;
        public static string wall_width_string;
        public static string wall_split_w_string;
        public static string wall_split_h_string;
        public static string v1_w, v2_w, v3_w, v4_w, v5_w, v6_w, v7_w, v8_w, v9_w, v10_w, v1_h, v2_h, v3_h, v4_h, v5_h, v6_h, v7_h, v8_h, v9_h, v10_h;

        private void wall_split_w_TextChanged(object sender, EventArgs e)
        {
            x_split = Convert.ToDouble(wall_split_w.Text);
        }

        private void wall_split_h_TextChanged(object sender, EventArgs e)
        {
            y_split = Convert.ToDouble(wall_split_h.Text);
        }

        public static string maxV_w;
        public static string maxV_h;
        public static string maxM_w;
        public static string maxM_h;

        //yeunsung coding
        public static double Bc;
        public static double SlabWidth;
        public static double L;


        public static double sin_pos_L;
        public static double sin_neg_L;
        public static double con_pos_L;
        public static double con_neg_L;

        public static double x_split;
        public static double y_split;

        public static double span_split;

        //load
        public static double dead_load;
        // dead_load = 2+(Get_LayerProperties.timber_density *Get_LayerProperties.Ht + Get_LayerProperties.concrete_density*Get_LayerProperties.thickness)/100000;           

        public static double Wf;

        public static double pos_Mf_Y_sin;
        public static double pos_Vf_Y_sin;
        public static double neg_Mf_Y_sin;
        public static double neg_Vf_Y_sin;

        public static double pos_Mf_X_sin;
        public static double pos_Vf_X_sin;
        public static double neg_Mf_X_sin;
        public static double neg_Vf_X_sin;

        public static double pos_Mf_Y_con;
        public static double pos_Vf_Y_con;
        public static double neg_Mf_Y_con;
        public static double neg_Vf_Y_con;

        public static double pos_Mf_X_con;
        public static double pos_Vf_X_con;
        public static double neg_Mf_X_con;
        public static double neg_Vf_X_con;

        public ShearForce()
        {
            InitializeComponent();
            show_height.Text = "";
            show_width.Text = "";
            draw_panel.Size = new Size(487, 411);
            draw_panel.BackColor = Color.Peru;
            g = draw_panel.CreateGraphics();
            this.Show();
            wood_pen = new Pen(Color.SaddleBrown, 2);
            steel_brush = new SolidBrush(Color.Silver);

            rbt_single.CheckedChanged += rbt_beam_option;
            rbt_con.CheckedChanged += rbt_beam_option;

            btnMfVf.Click += ChangeForm;
            btnPrev.Click += ChangeForm;
            btnNext.Click += ChangeForm;

        }
      
         
      
        //yeunsung coding
        private void rbt_beam_option(object sender, EventArgs e)
        {
            if (rbt_single.Checked == true)
            {
                span_split = 1;
                sin_pos_L = L / 2;
                sin_neg_L = L / 4;
            }
            if (rbt_con.Checked == true)
            {
                span_split = 2;
                con_pos_L = 0.75 * L;
                con_neg_L = 0.5 * L;

            }
        }
        private void get_MfVf_Y()
        {
            if (ShearForce.span_split == 1)
            {
                if (1.4 * dead_load > (1.25 * dead_load + 1.5 * Select_LiveLoad.liveload))
                    Wf = 1.4 * dead_load;
                else if (1.4 * dead_load < (1.25 * dead_load + 1.5 * Select_LiveLoad.liveload))
                    Wf = (1.25 * dead_load) + (1.5 * Select_LiveLoad.liveload);

                pos_Mf_Y_sin = Wf * Math.Pow(ShearForce.L / 1000, 2) / 8;
                pos_Vf_Y_sin = Wf * ShearForce.L / 2000;
                neg_Mf_Y_sin = Wf * Math.Pow(ShearForce.L / 1000, 2) / 12;
                neg_Vf_Y_sin = Wf * ShearForce.L / 2000;

                label26.Text = "Mf : " + Math.Round(pos_Mf_Y_sin, 2) + " kN*m";
                label25.Text = "Vf : " + Math.Round(pos_Vf_Y_sin, 2) + " kN";
                label24.Text = "Mf : " + Math.Round(neg_Mf_Y_sin, 2) + " kN*m";
                label23.Text = "Vf : " + Math.Round(neg_Vf_Y_sin, 2) + " kN";
            }
            else if (ShearForce.span_split == 2)
            {
                if (1.4 * dead_load > (1.25 * dead_load + 1.5 * Select_LiveLoad.liveload))
                    Wf = 1.4 * dead_load;
                else if (1.4 * dead_load < (1.25 * dead_load + 1.5 * Select_LiveLoad.liveload))
                    Wf = (1.25 * dead_load) + (1.5 * Select_LiveLoad.liveload);

                neg_Mf_Y_con = Wf * Math.Pow(ShearForce.L / 1000, 2) / 8;
                neg_Vf_Y_con = 5 * Wf * ShearForce.L / 8000;
                pos_Mf_Y_con = 9 * Wf * Math.Pow(ShearForce.L / 1000, 2) / 128;
                pos_Vf_Y_con = 5 * Wf * ShearForce.L / 8000;

                label26.Text = "Mf : " + Math.Round(pos_Mf_Y_con, 2) + " kN*m";
                label25.Text = "Vf : " + Math.Round(pos_Vf_Y_con, 2) + " kN";
                label24.Text = "Mf : " + Math.Round(neg_Mf_Y_con, 2) + " kN*m";
                label23.Text = "Vf : " + Math.Round(neg_Vf_Y_con, 2) + " kN";

            }

            
        }
        private void get_MfVf_X()
        {
            if (span_split == 1)
            {
                if (1.4 * dead_load > (1.25 * dead_load + 1.5 * Select_LiveLoad.liveload))
                    Wf = 1.4 * dead_load;
                else if (1.4 * dead_load < (1.25 * dead_load + 1.5 * Select_LiveLoad.liveload))
                    Wf = (1.25 * dead_load) + (1.5 * Select_LiveLoad.liveload);

                pos_Mf_X_sin = Wf * Math.Pow(Bc / 1000, 2) / 8;
                pos_Vf_X_sin = Wf * Bc / 2000;
                neg_Mf_X_sin = Wf * Math.Pow(Bc / 1000, 2) / 12;
                neg_Vf_X_sin = Wf * Bc / 2000;

                label19.Text = "Mf : " + Math.Round(pos_Mf_X_sin, 2) + " kN*m";
                label18.Text = "Vf : " + Math.Round(pos_Vf_X_sin, 2) + " kN";
                label22.Text = "Mf : " + Math.Round(neg_Mf_X_sin, 2) + " kN*m";
                label20.Text = "Vf : " + Math.Round(neg_Vf_X_sin, 2) + " kN";

            }
            else if (span_split == 2)
            {
                if (1.4 * dead_load > (1.25 * dead_load + 1.5 * Select_LiveLoad.liveload))
                    Wf = 1.4 * dead_load;
                else if (1.4 * dead_load < (1.25 * dead_load + 1.5 * Select_LiveLoad.liveload))
                    Wf = (1.25 * dead_load) + (1.5 * Select_LiveLoad.liveload);

                neg_Mf_X_con = Wf * Math.Pow(Bc / 1000, 2) / 8;
                neg_Vf_X_con = 5 * Wf * Bc / 8000;
                pos_Mf_X_con = 9 * Wf * Math.Pow(Bc / 1000, 2) / 128;
                pos_Vf_X_con = 5 * Wf * Bc / 8000;
                label19.Text = "Mf : " + Math.Round(pos_Mf_X_con, 2) + " kN*m";
                label18.Text = "Vf : " + Math.Round(pos_Vf_X_con, 2) + " kN";
                label22.Text = "Mf : " + Math.Round(neg_Mf_X_con, 2) + " kN*m";
                label20.Text = "Vf : " + Math.Round(neg_Vf_X_con, 2) + " kN";

            }

           
        }

        private void ChangeForm(object sender, EventArgs e)
        {
            if (sender.Equals(this.btnMfVf))
            {
                Form form = new MfVf_detail();
                form.Show();
            }

            if (sender.Equals(this.btnPrev))
            {
                this.Hide();

                main_selectform = new SelectForm();
                main_selectform.Show();

            }
            else if (sender.Equals(this.btnNext))
            {
                this.Hide();
                get_layerproperties = new Get_LayerProperties();
                get_layerproperties.Show();
            }
        }

        private void wall_width_TextChanged_1(object sender, EventArgs e)
        {
            g.Clear(Color.Peru);

            show_width.Text = wall_width.Text + "[mm]";
            if (wall_width.Text != "")
            {
                SlabWidth = Convert.ToDouble(wall_width.Text);
                Bc = Convert.ToDouble(wall_width.Text);
            }

        }

        private void wall_height_TextChanged_1(object sender, EventArgs e)
        {
            g.Clear(Color.Peru);
            show_height.Text = wall_height.Text + "[mm]";
            L = Convert.ToDouble(wall_height.Text);
        }
        private void ShearForce_Load_1(object sender, EventArgs e)
        {
            v1_w = "0";
            v2_w = "0";
            v3_w = "0";
            v4_w = "0";
            v5_w = "0";
            v6_w = "0";
            v7_w = "0";
            v8_w = "0";
            v9_w = "0";
            v10_w = "0";
            v1_h = "0";
            v2_h = "0";
            v3_h = "0";
            v4_h = "0";
            v5_h = "0";
            v6_h = "0";
            v7_h = "0";
            v8_h = "0";
            v9_h = "0";
            v10_h = "0";
            for (int i = 1; i < 10; i++)
            {
                dataGridView1.Rows.Add("v" + i, 0, "m" + i, 0, "v" + i, 0, "m" + i, 0);

            }
            dataGridView1.Rows.Add("v" + 10, 0, "", "", "v" + 10, 0, "", "");

            //dataGridView1.Rows.Add(0, 0);

            for (int i = 1; i <= 10; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = " ";

            }
        }
       

        private void btn_RemoveLayer_Click_1(object sender, EventArgs e)
        {
            get_MfVf_Y();
            get_MfVf_X();

            for (int i = 1; i < 9; i += 4)
                for (int j = 0; j < 10; j++)
                    dataGridView1.Rows[j].Cells[i].Value = 0;

            for (int i = 3; i < 9; i += 4)
                for (int j = 0; j < 9; j++)
                    dataGridView1.Rows[j].Cells[i].Value = 0;



            for (int i = 0; i < 5; i++) //나무panel초기화
            {
                g.Clear(Color.Peru); //direction
            }

            v1_1.Visible = v2_1.Visible = m1_1.Visible = false;         //아래, 옆그림 라벨 초기화
            m1_2.Visible = m2_2.Visible = m3_2.Visible = false;
            v1_2.Visible = v2_2.Visible = v3_2.Visible = v4_2.Visible = false;
            v1_3.Visible = v2_3.Visible = v3_3.Visible = v4_3.Visible = v5_3.Visible = v6_3.Visible = false;
            m1_3.Visible = m2_3.Visible = m3_3.Visible = m4_3.Visible = m5_3.Visible = false;
            v1_4.Visible = v2_4.Visible = v3_4.Visible = v4_4.Visible = v5_4.Visible = v6_4.Visible = v7_4.Visible = v8_4.Visible = false;
            m1_4.Visible = m2_4.Visible = m3_4.Visible = m4_4.Visible = m5_4.Visible = m6_4.Visible = m7_4.Visible = false;
            m1_10.Visible = m2_10.Visible = m3_10.Visible = m4_10.Visible = m5_10.Visible = m6_10.Visible = m7_10.Visible = m8_10.Visible = m9_10.Visible = false;
            v1_10.Visible = v2_10.Visible = v3_10.Visible = v4_10.Visible = v5_10.Visible = v6_10.Visible = v7_10.Visible = v8_10.Visible = v9_10.Visible = v10_10.Visible = false;

            v1_11.Visible = v2_11.Visible = m1_11.Visible = false;
            v1_22.Visible = v2_22.Visible = v3_22.Visible = v4_22.Visible = false;
            m1_22.Visible = m2_22.Visible = m3_22.Visible = false;
            v1_33.Visible = v2_33.Visible = v3_33.Visible = v4_33.Visible = v5_33.Visible = v6_33.Visible = false;
            m1_33.Visible = m2_33.Visible = m3_33.Visible = m4_33.Visible = m5_33.Visible = false;
            v1_44.Visible = v2_44.Visible = v3_44.Visible = v4_44.Visible = v5_44.Visible = v6_44.Visible = v7_44.Visible = v8_44.Visible = false;
            m1_44.Visible = m2_44.Visible = m3_44.Visible = m4_44.Visible = m5_44.Visible = m6_44.Visible = m7_44.Visible = false;
            v1_55.Visible = v2_55.Visible = v3_55.Visible = v4_55.Visible = v5_55.Visible = v6_55.Visible = v7_55.Visible = v8_55.Visible = v9_55.Visible = v10_55.Visible = false;
            m1_55.Visible = m2_55.Visible = m3_55.Visible = m4_55.Visible = m5_55.Visible = m6_55.Visible = m7_55.Visible = m8_55.Visible = m9_55.Visible = false;

            r1_1.Visible = r2_1.Visible = false;
            r1_2.Visible = r2_2.Visible = r3_2.Visible = false;
            r1_3.Visible = r2_3.Visible = r3_3.Visible = r4_3.Visible = false;
            r1_4.Visible = r2_4.Visible = r3_4.Visible = r4_4.Visible = r5_4.Visible = false;
            r1_5.Visible = r2_5.Visible = r3_5.Visible = r4_5.Visible = r5_5.Visible = r6_5.Visible = false;

            r1_11.Visible = r2_11.Visible = false;
            r1_22.Visible = r2_22.Visible = r3_22.Visible = false;
            r1_33.Visible = r2_33.Visible = r3_33.Visible = r4_33.Visible = false;
            r1_44.Visible = r2_44.Visible = r3_44.Visible = r4_44.Visible = r5_44.Visible = false;
            r1_55.Visible = r2_55.Visible = r3_55.Visible = r4_55.Visible = r5_55.Visible = r6_55.Visible = false;


            //Console.Clear();
            if (wall_split_h.Text == "1")
            {

                dataGridView1.Rows[0].Cells[5].Value = string.Format("{0:0.#}", ((int.Parse(wall_height.Text) * int.Parse(wall_seismic_h.Text)) / 2)).ToString();

                dataGridView1.Rows[1].Cells[5].Value = string.Format("{0:0.#}", ((int.Parse(wall_height.Text) * int.Parse(wall_seismic_h.Text)) / 2)).ToString();

                dataGridView1.Rows[0].Cells[7].Value = string.Format("{0:0.#}", ((int.Parse(wall_height.Text) * int.Parse(wall_height.Text) * int.Parse(wall_seismic_h.Text)) / 8)).ToString();

                split_picture1.Image = null;
                split_picture1.Image = Properties.Resources.split_11;       // 오른쪽 그림


                v1_11.Text = v1_h = (dataGridView1.Rows[0].Cells[5].Value).ToString();
                v2_11.Text = v2_h = (dataGridView1.Rows[1].Cells[5].Value).ToString();
                m1_11.Text = (dataGridView1.Rows[0].Cells[7].Value).ToString();
                v1_11.Visible = v2_11.Visible = m1_11.Visible = true;

                r1_11.Text = r2_11.Text = string.Format("{0:0.#}", ((int.Parse(wall_height.Text) * int.Parse(wall_seismic_h.Text)) / 2)).ToString();
                r1_11.Visible = r2_11.Visible = true;


                maxV_h = string.Format("{0:0.#}", ((int.Parse(wall_height.Text) * int.Parse(wall_seismic_h.Text)) / 2)).ToString(); ;
                maxM_h = string.Format("{0:0.#}", ((int.Parse(wall_height.Text) * int.Parse(wall_height.Text) * int.Parse(wall_seismic_h.Text)) / 8)).ToString();


            }

            else if (wall_split_h.Text == "2")
            {


                dataGridView1.Rows[0].Cells[5].Value = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 2) * (int.Parse(wall_seismic_h.Text))) * 3 / 8)).ToString();
                dataGridView1.Rows[1].Cells[5].Value = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 2) * (int.Parse(wall_seismic_h.Text))) - (((int.Parse(wall_height.Text) / 2) * (int.Parse(wall_seismic_h.Text))) * 3 / 8))).ToString();
                dataGridView1.Rows[2].Cells[5].Value = dataGridView1.Rows[1].Cells[5].Value;
                dataGridView1.Rows[3].Cells[5].Value = dataGridView1.Rows[0].Cells[5].Value;

                maxV_h = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 2) * (int.Parse(wall_seismic_h.Text))) * 3 / 8)).ToString();
                //  maxM_h = 

                v1_22.Text = v4_22.Text = v1_h = v4_h = (dataGridView1.Rows[0].Cells[5].Value).ToString();
                v3_22.Text = v2_22.Text = v3_h = v2_h = (dataGridView1.Rows[1].Cells[5].Value).ToString();
                v1_22.Visible = v2_22.Visible = v3_22.Visible = v4_22.Visible = true;

                dataGridView1.Rows[0].Cells[7].Value = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 2) * (int.Parse(wall_seismic_h.Text))) * (0.14 * ((int.Parse(wall_height.Text) / 2) + 0.5)))).ToString();
                dataGridView1.Rows[1].Cells[7].Value = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 2) * (int.Parse(wall_height.Text) / 2) * (int.Parse(wall_seismic_h.Text))) / -8)).ToString();
                dataGridView1.Rows[2].Cells[7].Value = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 2) * (int.Parse(wall_seismic_h.Text))) * (0.14 * ((int.Parse(wall_height.Text) / 2) + 0.5)))).ToString();

                r1_22.Text = r3_22.Text = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 2) * (int.Parse(wall_seismic_h.Text))) * 3 / 8)).ToString();
                r2_22.Text = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 2) * (int.Parse(wall_seismic_h.Text))) * 5 / 4)).ToString();
                r1_22.Visible = r2_22.Visible = r3_22.Visible = true;

                m1_22.Text = (dataGridView1.Rows[0].Cells[7].Value).ToString();
                m2_22.Text = (dataGridView1.Rows[1].Cells[7].Value).ToString();
                m3_22.Text = (dataGridView1.Rows[2].Cells[7].Value).ToString();
                m1_22.Visible = m2_22.Visible = m3_22.Visible = true;

                split_picture1.Image = null;
                split_picture1.Image = Properties.Resources.split_22;       // 오른쪽 그림


                for (int i = 0; i < 1; i++)
                {
                    g.DrawLine(wood_pen, 0, 215, 550, 215); //direction
                }
            }
            else if (wall_split_h.Text == "3")
            {


                dataGridView1.Rows[0].Cells[5].Value = dataGridView1.Rows[5].Cells[5].Value = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 3) * int.Parse(wall_seismic_h.Text)) * 0.4)).ToString();
                dataGridView1.Rows[1].Cells[5].Value = dataGridView1.Rows[4].Cells[5].Value = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 3) * int.Parse(wall_seismic_h.Text)) * 0.6)).ToString();
                dataGridView1.Rows[2].Cells[5].Value = dataGridView1.Rows[3].Cells[5].Value = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 3) * int.Parse(wall_seismic_h.Text)) * 0.5)).ToString();

                maxV_h = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 3) * int.Parse(wall_seismic_h.Text)) * 0.6)).ToString();
                maxM_h = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 3) * (int.Parse(wall_height.Text) / 3) * int.Parse(wall_seismic_h.Text)) * 0.08)).ToString();

                v1_33.Text = v6_33.Text = v1_h = v6_h = (dataGridView1.Rows[0].Cells[5].Value).ToString();
                v2_33.Text = v5_33.Text = v2_h = v5_h = (dataGridView1.Rows[1].Cells[5].Value).ToString();
                v3_33.Text = v4_33.Text = v3_h = v4_h = (dataGridView1.Rows[2].Cells[5].Value).ToString();

                v1_33.Visible = v2_33.Visible = v3_33.Visible = v4_33.Visible = v5_33.Visible = v6_33.Visible = true;

                r1_33.Text = r4_33.Text = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 3) * int.Parse(wall_seismic_h.Text)) * 0.4)).ToString();
                r2_33.Text = r3_33.Text = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 3) * int.Parse(wall_seismic_h.Text)) * 1.1)).ToString();
                r1_33.Visible = r2_33.Visible = r3_33.Visible = r4_33.Visible = true;


                dataGridView1.Rows[0].Cells[7].Value = dataGridView1.Rows[4].Cells[7].Value = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 3) * (int.Parse(wall_height.Text) / 3) * int.Parse(wall_seismic_h.Text)) * 0.08)).ToString();
                dataGridView1.Rows[1].Cells[7].Value = dataGridView1.Rows[3].Cells[7].Value = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 3) * (int.Parse(wall_height.Text) / 3) * int.Parse(wall_seismic_h.Text)) * -0.1)).ToString();
                dataGridView1.Rows[2].Cells[7].Value = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 3) * (int.Parse(wall_height.Text) / 3) * int.Parse(wall_seismic_h.Text)) * 0.025)).ToString();

                m1_33.Text = m5_33.Text = (dataGridView1.Rows[0].Cells[7].Value).ToString();
                m2_33.Text = m4_33.Text = (dataGridView1.Rows[1].Cells[7].Value).ToString();
                m3_33.Text = (dataGridView1.Rows[2].Cells[7].Value).ToString();

                m1_33.Visible = m2_33.Visible = m3_33.Visible = m4_33.Visible = m5_33.Visible = true;

                split_picture1.Image = null;
                split_picture1.Image = Properties.Resources.split_33;       // 오른쪽 그림

                for (int i = 0; i < 2; i++)
                {
                    g.DrawLine(wood_pen, 0, (float)135 * (i + 1), 550, 135 * (i + 1)); //direction

                }


            }
            else if (wall_split_h.Text == "4")
            {

                dataGridView1.Rows[0].Cells[5].Value = dataGridView1.Rows[7].Cells[5].Value = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 4) * int.Parse(wall_seismic_h.Text)) * 0.393)).ToString();
                dataGridView1.Rows[1].Cells[5].Value = dataGridView1.Rows[6].Cells[5].Value = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 4) * int.Parse(wall_seismic_h.Text)) * 0.536)).ToString();
                dataGridView1.Rows[2].Cells[5].Value = dataGridView1.Rows[5].Cells[5].Value = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 4) * int.Parse(wall_seismic_h.Text)) * 0.607)).ToString();
                dataGridView1.Rows[3].Cells[5].Value = dataGridView1.Rows[4].Cells[5].Value = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 4) * int.Parse(wall_seismic_h.Text)) * 0.464)).ToString();

                maxV_h = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 4) * int.Parse(wall_seismic_h.Text)) * 0.607)).ToString();
                maxM_h = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 4) * (int.Parse(wall_height.Text) / 4) * int.Parse(wall_seismic_h.Text)) * 0.0772)).ToString();

                v1_44.Text = v8_44.Text = v1_h = v8_h = (dataGridView1.Rows[0].Cells[5].Value).ToString();
                v2_44.Text = v7_44.Text = v2_h = v7_h = (dataGridView1.Rows[1].Cells[5].Value).ToString();
                v3_44.Text = v6_44.Text = v3_h = v6_h = (dataGridView1.Rows[2].Cells[5].Value).ToString();
                v4_44.Text = v5_44.Text = v4_h = v5_h = (dataGridView1.Rows[3].Cells[5].Value).ToString();

                v1_44.Visible = v2_44.Visible = v3_44.Visible = v4_44.Visible = v5_44.Visible = v6_44.Visible = v7_44.Visible = v8_44.Visible = true;

                r1_44.Text = r5_44.Text = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 4) * int.Parse(wall_seismic_h.Text)) * 0.393)).ToString();
                r2_44.Text = r4_44.Text = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 4) * int.Parse(wall_seismic_h.Text)) * 1.143)).ToString();
                r3_44.Text = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 4) * int.Parse(wall_seismic_h.Text)) * 0.928)).ToString();

                r1_44.Visible = r2_44.Visible = r3_44.Visible = r4_44.Visible = r5_44.Visible = true;

                dataGridView1.Rows[0].Cells[7].Value = dataGridView1.Rows[6].Cells[7].Value = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 4) * (int.Parse(wall_height.Text) / 4) * int.Parse(wall_seismic_h.Text)) * 0.0772)).ToString();
                dataGridView1.Rows[1].Cells[7].Value = dataGridView1.Rows[5].Cells[7].Value = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 4) * (int.Parse(wall_height.Text) / 4) * int.Parse(wall_seismic_h.Text)) * -0.1071)).ToString();
                dataGridView1.Rows[2].Cells[7].Value = dataGridView1.Rows[4].Cells[7].Value = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 4) * (int.Parse(wall_height.Text) / 4) * int.Parse(wall_seismic_h.Text)) * 0.0364)).ToString();
                dataGridView1.Rows[3].Cells[7].Value = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 4) * (int.Parse(wall_height.Text) / 4) * int.Parse(wall_seismic_h.Text)) * -0.0714)).ToString();

                m1_44.Text = m7_44.Text = (dataGridView1.Rows[0].Cells[7].Value).ToString();
                m2_44.Text = m6_44.Text = (dataGridView1.Rows[1].Cells[7].Value).ToString();
                m3_44.Text = m5_44.Text = (dataGridView1.Rows[2].Cells[7].Value).ToString();
                m4_44.Text = (dataGridView1.Rows[3].Cells[7].Value).ToString();

                m1_44.Visible = m2_44.Visible = m3_44.Visible = m4_44.Visible = m5_44.Visible = m6_44.Visible = m7_44.Visible = true;

                split_picture1.Image = null;
                split_picture1.Image = Properties.Resources.split_44;       // 오른쪽 그림

                for (int i = 0; i < 3; i++)
                {
                    g.DrawLine(wood_pen, 0, 102 * (i + 1), 550, 102 * (i + 1)); //direction

                }

            }
            else if (wall_split_h.Text == "5")
            {

                dataGridView1.Rows[0].Cells[5].Value = dataGridView1.Rows[9].Cells[5].Value = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 5) * int.Parse(wall_seismic_h.Text)) * 0.4)).ToString();
                dataGridView1.Rows[1].Cells[5].Value = dataGridView1.Rows[8].Cells[5].Value = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 5) * int.Parse(wall_seismic_h.Text)) * 0.6)).ToString();
                dataGridView1.Rows[2].Cells[5].Value = dataGridView1.Rows[7].Cells[5].Value = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 5) * int.Parse(wall_seismic_h.Text)) * 31 / 60)).ToString();
                dataGridView1.Rows[3].Cells[5].Value = dataGridView1.Rows[6].Cells[5].Value = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 5) * int.Parse(wall_seismic_h.Text)) * 29 / 60)).ToString();
                dataGridView1.Rows[4].Cells[5].Value = dataGridView1.Rows[5].Cells[5].Value = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 5) * int.Parse(wall_seismic_h.Text)) * 0.5)).ToString();

                maxV_h = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 5) * int.Parse(wall_seismic_h.Text)) * 0.6)).ToString();
                maxM_h = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 5) * (int.Parse(wall_height.Text) / 5) * int.Parse(wall_seismic_h.Text)) / 12.5)).ToString();

                v1_55.Text = v10_55.Text = v1_h = v10_h = (dataGridView1.Rows[0].Cells[5].Value).ToString();
                v2_55.Text = v9_55.Text = v2_h = v9_h = (dataGridView1.Rows[1].Cells[5].Value).ToString();
                v3_55.Text = v8_55.Text = v3_h = v8_h = (dataGridView1.Rows[2].Cells[5].Value).ToString();
                v4_55.Text = v7_55.Text = v4_h = v7_h = (dataGridView1.Rows[3].Cells[5].Value).ToString();
                v5_55.Text = v6_55.Text = v5_h = v6_h = (dataGridView1.Rows[4].Cells[5].Value).ToString();

                v1_55.Visible = v2_55.Visible = v3_55.Visible = v4_55.Visible = v5_55.Visible = v6_55.Visible = v7_55.Visible = v8_55.Visible = v9_55.Visible = v10_55.Visible = true;

                r1_55.Text = r6_55.Text = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 5) * int.Parse(wall_seismic_h.Text)) * 0.4)).ToString();
                r2_55.Text = r5_55.Text = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 5) * int.Parse(wall_seismic_h.Text)) * 67 / 60)).ToString();
                r3_55.Text = r4_55.Text = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 5) * int.Parse(wall_seismic_h.Text)) * 50 / 60)).ToString();
                r1_55.Visible = r2_55.Visible = r3_55.Visible = r4_55.Visible = r5_55.Visible = r6_55.Visible = true;

                dataGridView1.Rows[0].Cells[7].Value = dataGridView1.Rows[8].Cells[7].Value = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 5) * (int.Parse(wall_height.Text) / 5) * int.Parse(wall_seismic_h.Text)) / 12.5)).ToString();
                dataGridView1.Rows[1].Cells[7].Value = dataGridView1.Rows[7].Cells[7].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 5) * (int.Parse(wall_width.Text) / 5) * int.Parse(wall_seismic_h.Text)) / -10)).ToString();
                dataGridView1.Rows[2].Cells[7].Value = dataGridView1.Rows[6].Cells[7].Value = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 5) * (int.Parse(wall_height.Text) / 5) * int.Parse(wall_seismic_h.Text)) / 30)).ToString();
                dataGridView1.Rows[3].Cells[7].Value = dataGridView1.Rows[5].Cells[7].Value = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 5) * (int.Parse(wall_height.Text) / 5) * int.Parse(wall_seismic_h.Text)) / -12)).ToString();
                dataGridView1.Rows[4].Cells[7].Value = string.Format("{0:0.#}", (((int.Parse(wall_height.Text) / 5) * (int.Parse(wall_height.Text) / 5) * int.Parse(wall_seismic_h.Text)) / 24)).ToString();

                m1_55.Text = m9_55.Text = (dataGridView1.Rows[0].Cells[7].Value).ToString();
                m2_55.Text = m8_55.Text = (dataGridView1.Rows[1].Cells[7].Value).ToString();
                m3_55.Text = m7_55.Text = (dataGridView1.Rows[2].Cells[7].Value).ToString();
                m4_55.Text = m6_55.Text = (dataGridView1.Rows[3].Cells[7].Value).ToString();
                m5_55.Text = (dataGridView1.Rows[4].Cells[7].Value).ToString();

                m1_55.Visible = m2_55.Visible = m3_55.Visible = m4_55.Visible = m5_55.Visible = m6_55.Visible = m7_55.Visible = m8_55.Visible = m9_55.Visible = true;

                split_picture1.Image = null;
                split_picture1.Image = Properties.Resources.split_55;       // 오른쪽 그림

                for (int i = 0; i < 4; i++)
                {
                    g.DrawLine(wood_pen, 0, 80 * (i + 1), 550, 80 * (i + 1)); //direction

                }

            }
            else
            {
                MessageBox.Show("1~5사이의 숫자를 입력하시오");
            }

            if (wall_split_w.Text == "1")
            {
                dataGridView1.Rows[0].Cells[1].Value = string.Format("{0:0.#}", ((int.Parse(wall_width.Text) * int.Parse(wall_seismic_w.Text)) / 2)).ToString();
                dataGridView1.Rows[1].Cells[1].Value = string.Format("{0:0.#}", ((int.Parse(wall_width.Text) * int.Parse(wall_seismic_w.Text)) / 2)).ToString();

                dataGridView1.Rows[0].Cells[3].Value = string.Format("{0:0.#}", ((int.Parse(wall_width.Text) * int.Parse(wall_width.Text) * int.Parse(wall_seismic_w.Text)) / 8)).ToString();

                maxV_w = string.Format("{0:0.#}", ((int.Parse(wall_width.Text) * int.Parse(wall_seismic_w.Text)) / 2)).ToString();
                maxM_w = string.Format("{0:0.#}", ((int.Parse(wall_width.Text) * int.Parse(wall_width.Text) * int.Parse(wall_seismic_w.Text)) / 8)).ToString();

                split_picture.Image = null;
                split_picture.Image = Properties.Resources.split_1; //아래 그림


                v1_1.Text = v1_w = (dataGridView1.Rows[0].Cells[1].Value).ToString();
                v2_1.Text = v2_w = (dataGridView1.Rows[1].Cells[1].Value).ToString();
                m1_1.Text = (dataGridView1.Rows[0].Cells[3].Value).ToString();
                v1_1.Visible = true;
                v2_1.Visible = true;
                m1_1.Visible = true;

                r1_1.Text = r2_1.Text = string.Format("{0:0.#}", ((int.Parse(wall_width.Text) * int.Parse(wall_seismic_w.Text)) / 2)).ToString();
                r1_1.Visible = r2_1.Visible = true;
            }

            else if (wall_split_w.Text == "2")
            {


                dataGridView1.Rows[0].Cells[1].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 2) * (int.Parse(wall_seismic_w.Text))) * 3 / 8)).ToString();
                dataGridView1.Rows[1].Cells[1].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 2) * (int.Parse(wall_seismic_w.Text))) * 5 / 8)).ToString();
                dataGridView1.Rows[2].Cells[1].Value = dataGridView1.Rows[1].Cells[1].Value;
                dataGridView1.Rows[3].Cells[1].Value = dataGridView1.Rows[0].Cells[1].Value;

                maxV_w = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 2) * (int.Parse(wall_seismic_w.Text))) * 5 / 8)).ToString();
                // maxM_w = 

                v1_2.Text = v4_2.Text = v1_w = v4_w = (dataGridView1.Rows[0].Cells[1].Value).ToString();
                v3_2.Text = v2_2.Text = v3_w = v2_w = (dataGridView1.Rows[1].Cells[1].Value).ToString();
                v1_2.Visible = v2_2.Visible = v3_2.Visible = v4_2.Visible = true;


                dataGridView1.Rows[0].Cells[3].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 2) * (int.Parse(wall_seismic_w.Text))) * (0.14 * ((int.Parse(wall_width.Text) / 2) + 0.5)))).ToString();
                dataGridView1.Rows[1].Cells[3].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 2) * (int.Parse(wall_width.Text) / 2) * (int.Parse(wall_seismic_w.Text))) / -8)).ToString();
                dataGridView1.Rows[2].Cells[3].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 2) * (int.Parse(wall_seismic_w.Text))) * (0.14 * ((int.Parse(wall_width.Text) / 2) + 0.5)))).ToString();

                m1_2.Text = (dataGridView1.Rows[0].Cells[3].Value).ToString();
                m2_2.Text = (dataGridView1.Rows[1].Cells[3].Value).ToString();
                m3_2.Text = (dataGridView1.Rows[2].Cells[3].Value).ToString();
                m1_2.Visible = m2_2.Visible = m3_2.Visible = true;

                split_picture.Image = null;
                split_picture.Image = Properties.Resources.split_2;

                for (int i = 0; i < 1; i++)
                {
                    g.DrawLine(wood_pen, 245, 0, 245, 550); //direction
                }

                r1_2.Text = r3_2.Text = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 2) * (int.Parse(wall_seismic_w.Text))) * 3 / 8)).ToString();
                r2_2.Text = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 2) * (int.Parse(wall_seismic_w.Text))) * 5 / 4)).ToString();
                r1_2.Visible = r2_2.Visible = r3_2.Visible = true;

            }
            else if (wall_split_w.Text == "3")
            {


                dataGridView1.Rows[0].Cells[1].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 3) * int.Parse(wall_seismic_w.Text)) * 0.4)).ToString();
                dataGridView1.Rows[1].Cells[1].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 3) * int.Parse(wall_seismic_w.Text)) * 0.6)).ToString();
                dataGridView1.Rows[2].Cells[1].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 3) * int.Parse(wall_seismic_w.Text)) * 0.5)).ToString();
                dataGridView1.Rows[3].Cells[1].Value = dataGridView1.Rows[2].Cells[1].Value;
                dataGridView1.Rows[4].Cells[1].Value = dataGridView1.Rows[1].Cells[1].Value;
                dataGridView1.Rows[5].Cells[1].Value = dataGridView1.Rows[0].Cells[1].Value;

                maxV_w = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 3) * int.Parse(wall_seismic_w.Text)) * 0.6)).ToString();
                maxM_w = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 3) * (int.Parse(wall_width.Text) / 3) * int.Parse(wall_seismic_w.Text)) * 0.08)).ToString();

                v1_3.Text = v6_3.Text = v1_w = v6_w = (dataGridView1.Rows[0].Cells[1].Value).ToString();
                v2_3.Text = v5_3.Text = v2_w = v5_w = (dataGridView1.Rows[1].Cells[1].Value).ToString();
                v3_3.Text = v4_3.Text = v3_w = v4_w = (dataGridView1.Rows[2].Cells[1].Value).ToString();

                v1_3.Visible = v2_3.Visible = v3_3.Visible = v4_3.Visible = v5_3.Visible = v6_3.Visible = true;

                r1_3.Text = r4_3.Text = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 3) * int.Parse(wall_seismic_w.Text)) * 0.4)).ToString();
                r2_3.Text = r3_3.Text = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 3) * int.Parse(wall_seismic_w.Text)) * 1.1)).ToString();
                r1_3.Visible = r2_3.Visible = r3_3.Visible = r4_3.Visible = true;


                dataGridView1.Rows[0].Cells[3].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 3) * (int.Parse(wall_width.Text) / 3) * int.Parse(wall_seismic_w.Text)) * 0.08)).ToString();
                dataGridView1.Rows[1].Cells[3].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 3) * (int.Parse(wall_width.Text) / 3) * int.Parse(wall_seismic_w.Text)) * -0.1)).ToString();
                dataGridView1.Rows[2].Cells[3].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 3) * (int.Parse(wall_width.Text) / 3) * int.Parse(wall_seismic_w.Text)) * 0.025)).ToString();
                dataGridView1.Rows[3].Cells[3].Value = dataGridView1.Rows[1].Cells[3].Value;
                dataGridView1.Rows[4].Cells[3].Value = dataGridView1.Rows[0].Cells[3].Value;

                m1_3.Text = m5_3.Text = (dataGridView1.Rows[0].Cells[3].Value).ToString();
                m2_3.Text = m4_3.Text = (dataGridView1.Rows[1].Cells[3].Value).ToString();
                m3_3.Text = (dataGridView1.Rows[2].Cells[3].Value).ToString();

                m1_3.Visible = m2_3.Visible = m3_3.Visible = m4_3.Visible = m5_3.Visible = true;

                split_picture.Image = null;
                split_picture.Image = Properties.Resources.split_3;

                for (int i = 0; i < 2; i++)
                {
                    g.DrawLine(wood_pen, (float)160 * (i + 1), 0, 160 * (i + 1), 550); //direction

                }


            }
            else if (wall_split_w.Text == "4")
            {

                dataGridView1.Rows[0].Cells[1].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 4) * int.Parse(wall_seismic_w.Text)) * 0.393)).ToString();
                dataGridView1.Rows[1].Cells[1].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 4) * int.Parse(wall_seismic_w.Text)) * 0.536)).ToString();
                dataGridView1.Rows[2].Cells[1].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 4) * int.Parse(wall_seismic_w.Text)) * 0.607)).ToString();
                dataGridView1.Rows[3].Cells[1].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 4) * int.Parse(wall_seismic_w.Text)) * 0.464)).ToString();
                dataGridView1.Rows[4].Cells[1].Value = dataGridView1.Rows[3].Cells[1].Value;
                dataGridView1.Rows[5].Cells[1].Value = dataGridView1.Rows[2].Cells[1].Value;
                dataGridView1.Rows[6].Cells[1].Value = dataGridView1.Rows[1].Cells[1].Value;
                dataGridView1.Rows[7].Cells[1].Value = dataGridView1.Rows[0].Cells[1].Value;

                maxV_w = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 4) * int.Parse(wall_seismic_w.Text)) * 0.607)).ToString();
                maxM_w = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 4) * (int.Parse(wall_width.Text) / 4) * int.Parse(wall_seismic_w.Text)) * 0.0772)).ToString();

                v1_4.Text = v8_4.Text = v1_w = v8_w = (dataGridView1.Rows[0].Cells[1].Value).ToString();
                v2_4.Text = v7_4.Text = v2_w = v7_w = (dataGridView1.Rows[1].Cells[1].Value).ToString();
                v3_4.Text = v6_4.Text = v3_w = v6_w = (dataGridView1.Rows[2].Cells[1].Value).ToString();
                v4_4.Text = v5_4.Text = v4_w = v5_w = (dataGridView1.Rows[3].Cells[1].Value).ToString();

                v1_4.Visible = v2_4.Visible = v3_4.Visible = v4_4.Visible = v5_4.Visible = v6_4.Visible = v7_4.Visible = v8_4.Visible = true;

                r1_4.Text = r5_4.Text = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 4) * int.Parse(wall_seismic_w.Text)) * 0.393)).ToString();
                r2_4.Text = r4_4.Text = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 4) * int.Parse(wall_seismic_w.Text)) * 1.143)).ToString();
                r3_4.Text = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 4) * int.Parse(wall_seismic_w.Text)) * 0.928)).ToString();

                r1_4.Visible = r2_4.Visible = r3_4.Visible = r4_4.Visible = r5_4.Visible = true;

                dataGridView1.Rows[0].Cells[3].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 4) * (int.Parse(wall_width.Text) / 4) * int.Parse(wall_seismic_w.Text)) * 0.0772)).ToString();
                dataGridView1.Rows[1].Cells[3].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 4) * (int.Parse(wall_width.Text) / 4) * int.Parse(wall_seismic_w.Text)) * -0.1071)).ToString();
                dataGridView1.Rows[2].Cells[3].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 4) * (int.Parse(wall_width.Text) / 4) * int.Parse(wall_seismic_w.Text)) * 0.0364)).ToString();
                dataGridView1.Rows[3].Cells[3].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 4) * (int.Parse(wall_width.Text) / 4) * int.Parse(wall_seismic_w.Text)) * -0.0714)).ToString();
                dataGridView1.Rows[4].Cells[3].Value = dataGridView1.Rows[2].Cells[3].Value;
                dataGridView1.Rows[5].Cells[3].Value = dataGridView1.Rows[1].Cells[3].Value;
                dataGridView1.Rows[6].Cells[3].Value = dataGridView1.Rows[0].Cells[3].Value;

                m1_4.Text = m7_4.Text = (dataGridView1.Rows[0].Cells[3].Value).ToString();
                m2_4.Text = m6_4.Text = (dataGridView1.Rows[1].Cells[3].Value).ToString();
                m3_4.Text = m5_4.Text = (dataGridView1.Rows[2].Cells[3].Value).ToString();
                m4_4.Text = (dataGridView1.Rows[3].Cells[3].Value).ToString();

                m1_4.Visible = m2_4.Visible = m3_4.Visible = m4_4.Visible = m5_4.Visible = m6_4.Visible = m7_4.Visible = true;

                split_picture.Image = null;
                split_picture.Image = Properties.Resources.split_4;

                for (int i = 0; i < 3; i++)
                {
                    g.DrawLine(wood_pen, 120 * (i + 1), 0, 120 * (i + 1), 550); //direction

                }

            }
            else if (wall_split_w.Text == "5")
            {

                dataGridView1.Rows[9].Cells[1].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 5) * int.Parse(wall_seismic_w.Text)) * 0.4)).ToString();
                dataGridView1.Rows[8].Cells[1].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 5) * int.Parse(wall_seismic_w.Text)) * 0.6)).ToString();
                dataGridView1.Rows[7].Cells[1].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 5) * int.Parse(wall_seismic_w.Text)) * 31 / 60)).ToString();
                dataGridView1.Rows[6].Cells[1].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 5) * int.Parse(wall_seismic_w.Text)) * 29 / 60)).ToString();
                dataGridView1.Rows[5].Cells[1].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 5) * int.Parse(wall_seismic_w.Text)) * 0.5)).ToString();

                maxV_w = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 5) * int.Parse(wall_seismic_w.Text)) * 0.6)).ToString();
                maxM_w = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 5) * (int.Parse(wall_width.Text) / 5) * int.Parse(wall_seismic_w.Text)) / 12.5)).ToString();

                dataGridView1.Rows[0].Cells[1].Value = dataGridView1.Rows[9].Cells[1].Value;
                dataGridView1.Rows[1].Cells[1].Value = dataGridView1.Rows[8].Cells[1].Value;
                dataGridView1.Rows[2].Cells[1].Value = dataGridView1.Rows[7].Cells[1].Value;
                dataGridView1.Rows[3].Cells[1].Value = dataGridView1.Rows[6].Cells[1].Value;
                dataGridView1.Rows[4].Cells[1].Value = dataGridView1.Rows[5].Cells[1].Value;

                v1_10.Text = v10_10.Text = v1_w = v10_w = (dataGridView1.Rows[0].Cells[1].Value).ToString();
                v2_10.Text = v9_10.Text = v2_w = v9_w = (dataGridView1.Rows[1].Cells[1].Value).ToString();
                v3_10.Text = v8_10.Text = v3_w = v8_w = (dataGridView1.Rows[2].Cells[1].Value).ToString();
                v4_10.Text = v7_10.Text = v4_w = v7_w = (dataGridView1.Rows[3].Cells[1].Value).ToString();
                v5_10.Text = v6_10.Text = v5_w = v6_w = (dataGridView1.Rows[4].Cells[1].Value).ToString();    //v1_5 에서 5대신 v1_10

                v1_10.Visible = v2_10.Visible = v3_10.Visible = v4_10.Visible = v5_10.Visible = v6_10.Visible = v7_10.Visible = v8_10.Visible = v9_10.Visible = v10_10.Visible = true;

                r1_5.Text = r6_5.Text = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 5) * int.Parse(wall_seismic_w.Text)) * 0.4)).ToString();
                r2_5.Text = r5_5.Text = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 5) * int.Parse(wall_seismic_w.Text)) * 67 / 60)).ToString();
                r3_5.Text = r4_5.Text = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 5) * int.Parse(wall_seismic_w.Text)) * 50 / 60)).ToString();
                r1_5.Visible = r2_5.Visible = r3_5.Visible = r4_5.Visible = r5_5.Visible = r6_5.Visible = true;

                dataGridView1.Rows[0].Cells[3].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 5) * (int.Parse(wall_width.Text) / 5) * int.Parse(wall_seismic_w.Text)) / 12.5)).ToString();
                dataGridView1.Rows[1].Cells[3].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 5) * (int.Parse(wall_width.Text) / 5) * int.Parse(wall_seismic_w.Text)) / -10)).ToString();
                dataGridView1.Rows[2].Cells[3].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 5) * (int.Parse(wall_width.Text) / 5) * int.Parse(wall_seismic_w.Text)) / 30)).ToString();
                dataGridView1.Rows[3].Cells[3].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 5) * (int.Parse(wall_width.Text) / 5) * int.Parse(wall_seismic_w.Text)) / -12)).ToString();
                dataGridView1.Rows[4].Cells[3].Value = string.Format("{0:0.#}", (((int.Parse(wall_width.Text) / 5) * (int.Parse(wall_width.Text) / 5) * int.Parse(wall_seismic_w.Text)) / 24)).ToString();
                dataGridView1.Rows[5].Cells[3].Value = dataGridView1.Rows[3].Cells[3].Value;
                dataGridView1.Rows[6].Cells[3].Value = dataGridView1.Rows[2].Cells[3].Value;
                dataGridView1.Rows[7].Cells[3].Value = dataGridView1.Rows[1].Cells[3].Value;
                dataGridView1.Rows[8].Cells[3].Value = dataGridView1.Rows[0].Cells[3].Value;

                m1_10.Text = m9_10.Text = (dataGridView1.Rows[0].Cells[3].Value).ToString();
                m2_10.Text = m8_10.Text = (dataGridView1.Rows[1].Cells[3].Value).ToString();
                m3_10.Text = m7_10.Text = (dataGridView1.Rows[2].Cells[3].Value).ToString();
                m4_10.Text = m6_10.Text = (dataGridView1.Rows[3].Cells[3].Value).ToString();
                m5_10.Text = (dataGridView1.Rows[4].Cells[3].Value).ToString();

                m1_10.Visible = m2_10.Visible = m3_10.Visible = m4_10.Visible = m5_10.Visible = m6_10.Visible = m7_10.Visible = m8_10.Visible = m9_10.Visible = true;

                split_picture.Image = null;
                split_picture.Image = Properties.Resources.split_5;

                for (int i = 0; i < 4; i++)
                {
                    g.DrawLine(wood_pen, 97 * (i + 1), 0, 97 * (i + 1), 550); //direction

                }

            }
            else
            {
                MessageBox.Show("1~5사이의 숫자를 입력하시오");
            }

            label_seismic_h.Text = string.Format("{0:0.#}", ((float.Parse(wall_seismic_h.Text) / float.Parse(wall_height.Text)))).ToString() + "KN/m";        //m당 걸리는 w힘
            label_seismic_w.Text = string.Format("{0:0.#}", ((float.Parse(wall_seismic_w.Text) / float.Parse(wall_width.Text)))).ToString() + "KN/m";


        }



    }
}
