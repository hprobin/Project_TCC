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
    public partial class Get_LayerProperties : Form
    {
        public static Form get_ks;
        public static Form main_selectform;

        
        private static int dgvInput_Flag = 0; // For insert and remove of appropriate rows.
        public static int index = 0;//thickness 구하기 위해 dgvinput 행(row)개수
        private int previous_rbt; // value of 0 ~ 3 ( 0 : rbt_FlatSlab ~ 3 : rbt_RibSlab_both)

        //inputform 으로 넘겨줄 값
        public static double thickness;
        ///public static double SlabWidth;
        //public static double L;
        

        public static double T;
        public static double[] density = new double[10];
        public static double[] E0mean = new double[10];

        public static double timber_density;
        public static double concrete_density;
        
        public static double Bt;
        //public static double Bc;       
        public static double Ht;
        public static string concrete ;
        public static string timber;

        //일단 concrete 한겹만 한다고 생각했을때 값들
        public static double Hc;
        public static double Fc;
        public static double Et;
        public static double Ec;

        private string[] Woods_국산재 = { "육안등급(낙엽송) - 1등급", "육안등급(낙엽송) - 2등급", "육안등급(낙엽송) - 3등급",
                                          "육안등급(소나무) - 1등급", "육안등급(소나무) - 2등급", "육안등급(소나무) - 3등급",
                                          "육안등급(잣나무) - 1등급", "육안등급(잣나무) - 2등급", "육안등급(잣나무) - 3등급",
                                          "육안등급(삼나무) - 1등급", "육안등급(삼나무) - 2등급", "육안등급(삼나무) - 3등급",
                                          "기계등급 - E17", "기계등급 - E16", "기계등급 - E15", "기계등급 - E14",
                                          "기계등급 - E13", "기계등급 - E12", "기계등급 - E12 (실험)", "기계등급 - E11",
                                          "기계등급 - E10", "기계등급 - E10 (실험)", "기계등급 - E9" , "기계등급 - E8" ,
                                          "기계등급 - E8 (실험)", "기계등급 - E7" , "기계등급 - E6" , "기계등급 - E6 (실험)",
                                          "User Define" };
        private string[] Woods_외국산 = { "C14", "C16", "C18", "C20", "C22", "C24", "C27", "C30", "C35", "C40",
                                          "C45", "C50", "D18", "D24", "D30", "D35", "D40", "D50", "D60", "D70",
                                          "User Define" };
        private string[] Concretes = { "C12/15", "C16/20", "C20/25", "C25/30", "C30/37", "C35/45", "C40/50",
                                       "C45/55", "C50/60", "C55/67", "C60/75", "C70/85", "C80/95", "C90/105",
                                       "User Define" };
        private string[] Steels = { "User Define" };
        private string[] Gluelams = { "17S-54B (4매 이상)", "15S-46B (4매 이상)", "13S-40B (4매 이상)",
                                      "12S-37B (4매 이상)", "10S-34B (4매 이상)", "9S-31B (4매 이상)",
                                      "8S-30B (4매 이상)", "7S-27B (4매 이상)", "6S-25B (4매 이상)",
                                      "17S-49B (3매)", "15S-43B (3매)", "13S-37B (3매)", "12S-33B (3매)",
                                      "10S-30B (3매)", "9S-28B (3매)", "8S-27B (3매)", "7S-25B (3매)",
                                      "6S-24B (3매)", "17S-45B (2매)", "15S-39B (2매)", "13S-34B (2매)",
                                      "12S-30B (2매)", "10S-28B (2매)", "9S-27B (2매)", "8S-25B (2매)",
                                      "7S-24B (2매)", "6S-22B (2매)", "17S-49B (대칭)", "15S-43B (대칭)",
                                      "13S-37B (대칭)", "12S-33B (대칭)", "10S-30B (대칭)", "9S-27B (대칭)",
                                      "8S-25B (대칭)", "7S-24B (대칭)", "6S-22B (대칭)", "16S-48B (비대칭)",
                                      "14S-42B (비대칭)", "12S-36B (비대칭)", "11S-31B (비대칭)", "10S-28B (비대칭)",
                                      "9S-25B (비대칭)", "8S-24B (비대칭)", "7S-22B (비대칭)", "6S-21B (비대칭)",
                                      "User Define" };
        private string[] Etcs = { "User Define" };

        public Get_LayerProperties()
        {
            InitializeComponent();
            SetupDataGridView();
            Init();
            // dgv 수정
            dgvInput_Flag = 0;
            previous_rbt = 0;

            btn_AddLayer.Click += dgvInput_AddLayer;
            btn_RemoveLayer.Click += dgvInput_RemoveLayer;
            btn_Initialize.Click += dgvInput_Initialize;

            

            btnPrev.Click += ChangeForm;
            btnNext.Click += ChangeForm;

            dgvInput.CellEndEdit += dgvInput_CellEndEdit;

        }
        private void Init()
        {
            if (SelectForm.slab == 1)
            {
                pbo_rib_layer.Image = global::Project_TCC.Properties.Resources.flat_slab_layer;
                lblshow();
            }
            else if (SelectForm.slab == 2)
            {
                //Add_insulation();
                Add_RibSlab();
                
                dgvInput_Flag = 1;
                pbo_rib_layer.Image = global::Project_TCC.Properties.Resources.layerpropeties_pic;
                lblshow();
                lbl_width.Text = ":" + "  " + Convert.ToString(ShearForce.SlabWidth) + " mm";

            }

        }
        
        private void DrawLayer()
        {
            Graphics graphics = CreateGraphics();

            if (index == 0)
            {
                graphics.Dispose();
            }
            if (index == 1)
            {
                Pen pen = new Pen(Color.Black);
                //DrawLine(pen, 1000, 250, 1600, 250);
            }
            if (index == 2)
            {

            }
            if (index == 3)
            {

            }
            if (index == 4)
            {

            }
            if (index == 5)
            {

            }
        }
        private void lblshow()
        {
            if (SelectForm.slab == 1)
            {
                pbo_rib_layer.Visible = false;
               

                lbl_rib_thickness.Visible = false;
                lbl_rib_width.Visible = false;
                lbl_width.Visible = false;
                
                textBox3.Visible = false;

                
                label3.Visible = false;
               
                label19.Visible = false;
                label20.Visible = false;

                


            }
            else if (SelectForm.slab == 2)
            {
                pbo_rib_layer.Visible = true;
               
                lbl_rib_thickness.Visible = true;
                lbl_rib_width.Visible = true;
                lbl_width.Visible = true;
               
                textBox3.Visible = true;

                label3.Visible = true;
                label19.Visible = true;
                label20.Visible = true;


               
            }
        }
        private void SetupDataGridView()
        {
            this.Controls.Add(dgvInput);

            dgvInput.ColumnCount = 11;

            dgvInput.Columns[0].Name = "Material";
            dgvInput.Columns[1].Name = "Classification";
            dgvInput.Columns[2].Name = "Thickness";
            dgvInput.Columns[3].Name = "E";
            dgvInput.Columns[4].Name = "fb";
            dgvInput.Columns[5].Name = "ft";
            dgvInput.Columns[6].Name = "fc";
            dgvInput.Columns[7].Name = "fcp";
            dgvInput.Columns[8].Name = "fv";
            dgvInput.Columns[9].Name = "fs";
            dgvInput.Columns[10].Name = "Density";

            dgvInput.Columns[0].Width = 120;
            dgvInput.Columns[1].Width = 180;
            for (int i = 2; i < dgvInput.ColumnCount; i++)
            {
                dgvInput.Columns[i].Width = 70;
            }
        }
        private void ChangeForm(object sender, EventArgs e)
        {
            if (sender.Equals(this.btnPrev))
            {
                index = 0;
                this.Hide();
                SelectForm.shear_force.Show();
            }
            else if (sender.Equals(this.btnNext))
            {
                GetThickness();
                for (int i = 0; i < index; i++)
                {
                    density[i] = Convert.ToDouble(dgvInput.Rows[i].Cells[10].Value);
                    timber_density = Convert.ToDouble(dgvInput.Rows[1].Cells[10].Value);
                    concrete_density = Convert.ToDouble(dgvInput.Rows[0].Cells[10].Value);
                }
                for (int i = 0; i < index; i++)
                {
                    E0mean[i] = Convert.ToDouble(dgvInput.Rows[i].Cells[3].Value);
                }
                //layer를 rib= 나무 slab= concrete 한층 씩으로 한다고 가정하에 잡아논 변수 
                Et = Convert.ToDouble(dgvInput.Rows[1].Cells[3].Value);
                Ec = Convert.ToDouble(dgvInput.Rows[0].Cells[3].Value);
                Hc = Convert.ToDouble(dgvInput.Rows[0].Cells[2].Value);
                Fc = Convert.ToDouble(dgvInput.Rows[1].Cells[6].Value);
                concrete =  Convert.ToString(dgvInput.Rows[0].Cells[1].Value);
                timber = Convert.ToString(dgvInput.Rows[1].Cells[1].Value);
                //T = Convert.ToDouble(dgvInput.Rows[0].Cells[2].Value);
                Ht = Convert.ToDouble(dgvInput.Rows[1].Cells[2].Value);

                this.Hide();
                get_ks = new Get_ks();
                get_ks.Show();
            }
        }
        private void GetThickness()
        {
            if (SelectForm.slab == 1)
            {
                double default_thickness = 0;
                int i;
                for (i = 0; i < index; i++)
                {
                    default_thickness = default_thickness + Convert.ToDouble(dgvInput.Rows[i].Cells[2].Value);
                }
                thickness = default_thickness;
            }
            else if (SelectForm.slab == 2)
            {
                double default_thickness = 0;
                int j;
                for (j = 0; j < index; j++)
                {
                    default_thickness = default_thickness + Convert.ToDouble(dgvInput.Rows[j].Cells[2].Value);
                }
                thickness = default_thickness;
            }
        }

        /*
        private void Savedensity()
        {
            if (SelectForm.slab == 1)
            {
                int i = 0;
                for (i = 0; i < 3; i++)
                {
                    density[i] = Convert.ToDouble(dgvInput.Rows[i].Cells[10].Value);
                }
            }
            if (SelectForm.slab == 2)
            {
                int i = 0;
                for (i = 0; i < 3; i++)
                {
                    density[i] = Convert.ToDouble(dgvInput.Rows[i].Cells[10].Value);
                }
            }
        }
        */

        private void dgvInput_AddLayer(object sender, EventArgs e)
        {
            if (sender.Equals(this.btn_AddLayer))
            {
                dgvInput.Rows.Insert(dgvInput.Rows.Count - dgvInput_Flag-1);
                dgvInput.Rows[dgvInput.Rows.Count - 2 - dgvInput_Flag].HeaderCell.Value = "Layer " + (index+1);

                DataGridViewComboBoxCell cboCell_Material = new DataGridViewComboBoxCell();
                cboCell_Material.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;

                cboCell_Material.Items.Add("Woods(국산재)");
                cboCell_Material.Items.Add("Woods(외국산)");
                cboCell_Material.Items.Add("Concretes");
                cboCell_Material.Items.Add("Steel");
                cboCell_Material.Items.Add("Gluelam");
                cboCell_Material.Items.Add("Etc.");

                dgvInput.Rows[dgvInput.Rows.Count - 2 - dgvInput_Flag].Cells[0] = cboCell_Material;
                DataGridViewComboBoxCell cboCell_Classification = new DataGridViewComboBoxCell();
                cboCell_Classification.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;

                dgvInput.Rows[dgvInput.Rows.Count - 2 - dgvInput_Flag].Cells[1] = cboCell_Classification;

                index++;
                //Savedensity();
                DrawLayer();
            }
        }

        private void dgvInput_RemoveLayer(object sender, EventArgs e)
        {
            if (sender.Equals(this.btn_RemoveLayer) && dgvInput.Rows.Count != 0)
            {
                dgvInput.Rows.RemoveAt(dgvInput.Rows.Count - 2 - dgvInput_Flag);

                if (index != 0)
                {
                    index--;
                    //Savedensity();
                    DrawLayer();
                }
                else if (index == 0)
                {
                    index = 0;
                    //Savedensity();
                    DrawLayer();
                }
            }
        }

        private void dgvInput_Initialize(object sender, EventArgs e)
        {
            if (sender.Equals(this.btn_Initialize))
            {
                dgvInput.Rows.Clear();
                index = 0;
                //Savedensity();
                DrawLayer();
            }
        }
        //Rib Slab dgv init
        private void Add_RibSlab()
        {
            dgvInput.Rows.Add();
            dgvInput.Rows[dgvInput.Rows.Count - 1].HeaderCell.Value = "Rib";

            DataGridViewComboBoxCell cboCell_Material = new DataGridViewComboBoxCell();
            cboCell_Material.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;

            cboCell_Material.Items.Add("Woods(국산재)");
            cboCell_Material.Items.Add("Woods(외국산)");
            cboCell_Material.Items.Add("Concretes");
            cboCell_Material.Items.Add("Steel");
            cboCell_Material.Items.Add("Gluelam");
            cboCell_Material.Items.Add("Etc.");

            dgvInput.Rows[dgvInput.Rows.Count - 1].Cells[0] = cboCell_Material;

            DataGridViewComboBoxCell cboCell_Classification = new DataGridViewComboBoxCell();
            cboCell_Classification.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;

            dgvInput.Rows[dgvInput.Rows.Count - 1].Cells[1] = cboCell_Classification;
        }
        /*
        private void Add_insulation()
        {
            dgvInput.Rows.Add();
            dgvInput.Rows[dgvInput.Rows.Count - 1].HeaderCell.Value = "insulation(t)";

            DataGridViewComboBoxCell cboCell_Material = new DataGridViewComboBoxCell();
            cboCell_Material.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;

            cboCell_Material.Items.Add("Woods(국산재)");
            cboCell_Material.Items.Add("Woods(외국산)");
            cboCell_Material.Items.Add("Concretes");
            cboCell_Material.Items.Add("Steel");
            cboCell_Material.Items.Add("Gluelam");
            cboCell_Material.Items.Add("Etc.");

            dgvInput.Rows[dgvInput.Rows.Count - 1].Cells[0] = cboCell_Material;

            DataGridViewComboBoxCell cboCell_Classification = new DataGridViewComboBoxCell();
            cboCell_Classification.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;

            dgvInput.Rows[dgvInput.Rows.Count - 1].Cells[1] = cboCell_Classification;
        }

        */

        //다음 페이지에서 정보로 보여줄 SlabWidth,SlabLength,L값 변수에 저장(Slab dimension)          
       /*
        private void tbo_Slab_Width_TextChanged_1(object sender, EventArgs e)
        {
            if (tbo_Slab_Width.Text != "")
            {
                SlabWidth = Convert.ToDouble(tbo_Slab_Width.Text);
                lbl_width.Text = ":" + "  " + Convert.ToString(SlabWidth)+" mm";
                Bc= Convert.ToDouble(tbo_Slab_Width.Text);
            }


        }

        private void tbo_L_TextChanged_1(object sender, EventArgs e)
        {
            if (tbo_L.Text != "")
            {
                L = Convert.ToDouble(tbo_L.Text);
                //lbl_length.Text = ":" + "  " + Convert.ToString(L);
                //label13.Text = ":" + "  " + Convert.ToString(L);

            }
        }
       */
        private void tbo_T_TextChanged(object sender, EventArgs e)
        {
            if (tbo_T.Text != "")
            {
                T = Convert.ToDouble(tbo_T.Text);
                label3.Text = "t : " + "  " + Convert.ToString(T) + " mm";

            }
        }
        /*
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                T = Convert.ToDouble(tbo_T.Text);
                label3.Text = "t : " + "  " + Convert.ToString(T);

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Ht = Convert.ToDouble(dgvInput.Rows[1].Cells[2].Value);
            label16.Text = "h(t): " + " " + Convert.ToString(Ht);
        }
        */
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            Bt = Convert.ToDouble(textBox3.Text);
            label9.Text = "b(t): " + " " + Convert.ToString(Bt) + " mm";
        }

        private void dgvInput_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewComboBoxCell cboCell_Material;
            DataGridViewComboBoxCell cboCell_Classification;

            if (e.ColumnIndex == 0)
            {
                cboCell_Material = (DataGridViewComboBoxCell)dgvInput[e.ColumnIndex, e.RowIndex];
                cboCell_Classification = (DataGridViewComboBoxCell)dgvInput[e.ColumnIndex + 1, e.RowIndex];

                if (cboCell_Material.Value != null && cboCell_Material.Items.IndexOf(cboCell_Material.Value) == 0)
                {
                    cboCell_Classification.Value = null;

                    cboCell_Classification.Items.Clear();
                    for (int i = 0; i < Woods_국산재.Length; i++)
                    {
                        cboCell_Classification.Items.Add(Woods_국산재[i]);
                    }
                }
                else if (cboCell_Material.Value != null && cboCell_Material.Items.IndexOf(cboCell_Material.Value) == 1)
                {
                    cboCell_Classification.Value = null;

                    cboCell_Classification.Items.Clear();
                    for (int i = 0; i < Woods_외국산.Length; i++)
                    {
                        cboCell_Classification.Items.Add(Woods_외국산[i]);
                    }
                }
                else if (cboCell_Material.Value != null && cboCell_Material.Items.IndexOf(cboCell_Material.Value) == 2)
                {
                    cboCell_Classification.Value = null;

                    cboCell_Classification.Items.Clear();
                    for (int i = 0; i < Concretes.Length; i++)
                    {
                        cboCell_Classification.Items.Add(Concretes[i]);
                    }
                }
                else if (cboCell_Material.Value != null && cboCell_Material.Items.IndexOf(cboCell_Material.Value) == 3)
                {
                    cboCell_Classification.Value = null;

                    cboCell_Classification.Items.Clear();
                    for (int i = 0; i < Steels.Length; i++)
                    {
                        cboCell_Classification.Items.Add(Steels[i]);
                    }
                }
                else if (cboCell_Material.Value != null && cboCell_Material.Items.IndexOf(cboCell_Material.Value) == 4)
                {
                    cboCell_Classification.Value = null;

                    cboCell_Classification.Items.Clear();
                    for (int i = 0; i < Gluelams.Length; i++)
                    {
                        cboCell_Classification.Items.Add(Gluelams[i]);
                    }
                }
                else if (cboCell_Material.Value != null && cboCell_Material.Items.IndexOf(cboCell_Material.Value) == 5)
                {
                    cboCell_Classification.Value = null;

                    cboCell_Classification.Items.Clear();
                    for (int i = 0; i < Etcs.Length; i++)
                    {
                        cboCell_Classification.Items.Add(Etcs[i]);
                    }
                }
            }
            else if (e.ColumnIndex == 1)
            {
                cboCell_Classification = (DataGridViewComboBoxCell)dgvInput[e.ColumnIndex, e.RowIndex];

                if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "육안등급(낙엽송) - 1등급")
                {
                    double[] property;


                    property = Property_ASD.낙엽송1;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "육안등급(낙엽송) - 2등급")
                {
                    double[] property;

                    property = Property_ASD.낙엽송2;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "육안등급(낙엽송) - 3등급")
                {
                    double[] property;

                    property = Property_ASD.낙엽송3;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "육안등급(소나무) - 1등급")
                {
                    double[] property;

                    property = Property_ASD.소나무1;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "육안등급(소나무) - 2등급")
                {
                    double[] property;

                    property = Property_ASD.소나무2;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "육안등급(소나무) - 3등급")
                {
                    double[] property;

                    property = Property_ASD.소나무3;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }


                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "육안등급(잣나무) - 1등급")
                {
                    double[] property;

                    property = Property_ASD.잣나무1;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "육안등급(잣나무) - 2등급")
                {
                    double[] property;

                    property = Property_ASD.잣나무2;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "육안등급(잣나무) - 3등급")
                {
                    double[] property;

                    property = Property_ASD.잣나무3;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "육안등급(삼나무) - 1등급")
                {
                    double[] property;

                    property = Property_ASD.삼나무1;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];

                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "육안등급(삼나무) - 2등급")
                {
                    double[] property;

                    property = Property_ASD.삼나무2;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "육안등급(삼나무) - 3등급")
                {
                    double[] property;

                    property = Property_ASD.삼나무3;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "기계등급 - E17")
                {
                    double[] property;

                    property = Property_ASD.E17;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }


                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "기계등급 - E16")
                {
                    double[] property;

                    property = Property_ASD.E16;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "기계등급 - E15")
                {
                    double[] property;

                    property = Property_ASD.E15;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "기계등급 - E14")
                {
                    double[] property;

                    property = Property_ASD.E14;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "기계등급 - E13")
                {
                    double[] property;

                    property = Property_ASD.E13;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "기계등급 - E12")
                {
                    double[] property;

                    property = Property_ASD.E12;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "기계등급 - E12 (실험)")
                {
                    double[] property;

                    property = Property_ASD.E12_실험;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "기계등급 - E11")
                {
                    double[] property;

                    property = Property_ASD.E11;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "기계등급 - E10")
                {
                    double[] property;

                    property = Property_ASD.E10;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "기계등급 - E10 (실험)")
                {
                    double[] property;

                    property = Property_ASD.E10_실험;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "기계등급 - E9")
                {

                    double[] property;

                    property = Property_ASD.E9;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "기계등급 - E8")
                {

                    double[] property;

                    property = Property_ASD.E8;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "기계등급 - E8 (실험)")
                {

                    double[] property;

                    property = Property_ASD.E8_실험;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "기계등급 - E7")
                {

                    double[] property;

                    property = Property_ASD.E7;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "기계등급 - E6")
                {

                    double[] property;

                    property = Property_ASD.E6;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "기계등급 - E6 (실험)")
                {

                    double[] property;

                    property = Property_ASD.E6_실험;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "C14")
                {

                    double[] property;

                    property = Property_ASD.C14;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "C16")
                {
                    double[] property;

                    property = Property_ASD.C16;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "C18")
                {
                    double[] property;

                    property = Property_ASD.C18;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "C20")
                {
                    double[] property;

                    property = Property_ASD.C20;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "C22")
                {
                    double[] property;

                    property = Property_ASD.C22;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "C24")
                {
                    double[] property;

                    property = Property_ASD.C24;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "C27")
                {
                    double[] property;

                    property = Property_ASD.C27;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "C30")
                {
                    double[] property;

                    property = Property_ASD.C30;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "C35")
                {
                    double[] property;

                    property = Property_ASD.C35;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "C40")
                {
                    double[] property;

                    property = Property_ASD.C40;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "C45")
                {
                    double[] property;

                    property = Property_ASD.C45;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "C50")
                {
                    double[] property;

                    property = Property_ASD.C50;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "D18")
                {
                    double[] property;

                    property = Property_ASD.D18;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "D24")
                {
                    double[] property;

                    property = Property_ASD.D24;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "D30")
                {
                    double[] property;

                    property = Property_ASD.D30;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "D35")
                {
                    double[] property;

                    property = Property_ASD.D35;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "D40")
                {
                    double[] property;

                    property = Property_ASD.D40;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "D50")
                {
                    double[] property;

                    property = Property_ASD.D50;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "D60")
                {
                    double[] property;

                    property = Property_ASD.D60;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "D70")
                {
                    double[] property;

                    property = Property_ASD.D70;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "C12/15")
                {
                    double[] property;

                    property = Property_ASD.C_12_15;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "C16/20")
                {

                    double[] property;

                    property = Property_ASD.C_12_15;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "C20/25")
                {
                    double[] property;

                    property = Property_ASD.C_20_25;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "C25/30")
                {
                    double[] property;

                    property = Property_ASD.C_25_30;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "C30/37")
                {
                    double[] property;

                    property = Property_ASD.C_30_37;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "C35/45")
                {
                    double[] property;

                    property = Property_ASD.C_35_45;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "C40/50")
                {
                    double[] property;

                    property = Property_ASD.C_40_50;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "C45/55")
                {
                    double[] property;

                    property = Property_ASD.C_45_55;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "C50/60")
                {
                    double[] property;

                    property = Property_ASD.C_50_60;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "C55/67")
                {
                    double[] property;

                    property = Property_ASD.C_55_67;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "C60/75")
                {
                    double[] property;

                    property = Property_ASD.C_60_75;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "C70/85")
                {
                    double[] property;

                    property = Property_ASD.C_70_85;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "C80/95")
                {
                    double[] property;

                    property = Property_ASD.C_80_95;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "C90/105")
                {
                    double[] property;

                    property = Property_ASD.C_90_105;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }
                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "17S-54B (4매 이상)")
                {
                    double[] property;

                    property = Property_ASD.G_17S54B_4매이상;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "15S-46B (4매 이상)")
                {
                    double[] property;

                    property = Property_ASD.G_15S46B_4매이상;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "13S-40B (4매 이상)")
                {
                    double[] property;

                    property = Property_ASD.G_13S40B_4매이상;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "12S-37B (4매 이상)")
                {
                    double[] property;
                    property = Property_ASD.G_12S37B_4매이상;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "10S-34B (4매 이상)")
                {
                    double[] property;

                    property = Property_ASD.G_10S34B_4매이상;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "9S-31B (4매 이상)")
                {
                    double[] property;

                    property = Property_ASD.G_9S31B_4매이상;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "8S-30B (4매 이상)")
                {
                    double[] property;

                    property = Property_ASD.G_8S30B_4매이상;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "7S-27B (4매 이상)")
                {
                    double[] property;

                    property = Property_ASD.G_7S27B_4매이상;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "6S-25B (4매 이상)")
                {
                    double[] property;

                    property = Property_ASD.G_6S25B_4매이상;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "17S-49B (3매)")
                {
                    double[] property;

                    property = Property_ASD.G_17S49B_3매;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "15S-43B (3매)")
                {
                    double[] property;

                    property = Property_ASD.G_15S43B_3매;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "13S-37B (3매)")
                {
                    double[] property;
                    property = Property_ASD.G_13S37B_3매;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "12S-33B (3매)")
                {
                    double[] property;

                    property = Property_ASD.G_12S33B_3매;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "10S-30B (3매)")
                {
                    double[] property;

                    property = Property_ASD.G_10S30B_3매;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "9S-28B (3매)")
                {
                    double[] property;

                    property = Property_ASD.G_9S28B_3매;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "8S-27B (3매)")
                {
                    double[] property;

                    property = Property_ASD.G_8S27B_3매;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "7S-25B (3매)")
                {
                    double[] property;

                    property = Property_ASD.G_7S25B_3매;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "6S-24B (3매)")
                {
                    double[] property;

                    property = Property_ASD.G_6S24B_3매;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "17S-45B (2매)")
                {
                    double[] property;

                    property = Property_ASD.G_17S45B_2매;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "15S-39B (2매)")
                {
                    double[] property;

                    property = Property_ASD.G_15S39B_2매;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "13S-34B (2매)")
                {
                    double[] property;

                    property = Property_ASD.G_13S34B_2매;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "12S-30B (2매)")
                {
                    double[] property;

                    property = Property_ASD.G_12S30B_2매;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "10S-28B (2매)")
                {
                    double[] property;

                    property = Property_ASD.G_10S28B_2매;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "9S-27B (2매)")
                {
                    double[] property;

                    property = Property_ASD.G_9S27B_2매;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "8S-25B (2매)")
                {
                    double[] property;

                    property = Property_ASD.G_8S25B_2매;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "7S-24B (2매)")
                {
                    double[] property;

                    property = Property_ASD.G_7S24B_2매;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "6S-22B (2매)")
                {
                    double[] property;

                    property = Property_ASD.G_6S22B_2매;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "17S-49B (대칭)")
                {
                    double[] property;

                    property = Property_ASD.G_17S49B_대칭;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "15S-43B (대칭)")
                {
                    double[] property;

                    property = Property_ASD.G_15S43B_대칭;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "13S-37B (대칭)")
                {
                    double[] property;

                    property = Property_ASD.G_13S37B_대칭;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "12S-33B (대칭)")
                {
                    double[] property;

                    property = Property_ASD.G_12S33B_대칭;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "10S-30B (대칭)")
                {
                    double[] property;

                    property = Property_ASD.G_10S30B_대칭;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "9S-27B (대칭)")
                {
                    double[] property;

                    property = Property_ASD.G_9S27B_대칭;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "8S-25B (대칭)")
                {
                    double[] property;

                    property = Property_ASD.G_8S25B_대칭;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "7S-24B (대칭)")
                {
                    double[] property;

                    property = Property_ASD.G_7S24B_대칭;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "6S-22B (대칭)")
                {
                    double[] property;

                    property = Property_ASD.G_6S22B_대칭;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "16S-48B (비대칭)")
                {
                    double[] property;

                    property = Property_ASD.G_16S48B_비대칭;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "14S-42B (비대칭)")
                {
                    double[] property;

                    property = Property_ASD.G_14S42B_비대칭;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "12S-36B (비대칭)")
                {
                    double[] property;

                    property = Property_ASD.G_12S36B_비대칭;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "11S-31B (비대칭)")
                {
                    double[] property;

                    property = Property_ASD.G_11S31B_비대칭;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "10S-28B (비대칭)")
                {
                    double[] property;

                    property = Property_ASD.G_10S28B_비대칭;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "9S-25B (비대칭)")
                {
                    double[] property;

                    property = Property_ASD.G_9S25B_비대칭;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "8S-24B (비대칭)")
                {
                    double[] property;

                    property = Property_ASD.G_8S24B_비대칭;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "7S-22B (비대칭)")
                {
                    double[] property;
                    property = Property_ASD.G_7S22B_비대칭;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "6S-21B (비대칭)")
                {
                    double[] property;

                    property = Property_ASD.G_6S21B_비대칭;
                    for (int i = 0; i < property.Length; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = property[i];
                    }

                }
                else if (cboCell_Classification.Value != null && cboCell_Classification.Value.ToString() == "User Define")
                {
                    for (int i = 0; i < 7; i++)
                    {
                        dgvInput[i + 3, e.RowIndex].Value = "";
                    }
                }
            }
        }

       
    }

}
