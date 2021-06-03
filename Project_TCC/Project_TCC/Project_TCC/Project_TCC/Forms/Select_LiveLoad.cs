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
    public partial class Select_LiveLoad : Form
    {
        
        public static double liveload;
        public static Form selectform;
        public Select_LiveLoad()
        {
            InitializeComponent();
        }


        private void btnNext_Click_1(object sender, EventArgs e)
        {
            liveload = 0;

            for (int i = 0; i < dgv.RowCount; i++)
            {
                liveload += Convert.ToDouble(dgv.Rows[i].Cells[2].Value);
                //liveload += Double.Parse(dgv[2, i].Value.ToString());
            }

            this.Hide();
            selectform = new SelectForm();
            selectform.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int dgv_index = dgv.SelectedCells[0].RowIndex;
            dgv.Rows.Remove(dgv.Rows[dgv_index]);
        }

        private void treeView1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            string[] row = { treeView1.SelectedNode.Parent.Text, treeView1.SelectedNode.Text, treeView1.SelectedNode.Name };
            dgv.Rows.Add(row);
        }
    }
}
