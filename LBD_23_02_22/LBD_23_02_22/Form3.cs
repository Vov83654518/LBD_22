using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LBD_23_02_22
{
    public partial class Form3 : Form
    {
        public Form3(double[] opr_mas)
        {
            InitializeComponent();
            Create_Table_f3(opr_mas.Length, opr_mas.Length, opr_mas);
        }
        public void Create_Table_f3(int x, int y, double[] opr_mas)
        {
            DataGridViewTextBoxColumn[] Stolbech = new DataGridViewTextBoxColumn[x];
            DataGridViewRow Stroka = new DataGridViewRow();
            for (int i = 0; i < x; i++)
            {
                Stolbech[i] = new DataGridViewTextBoxColumn();
                Stolbech[i].Name = (i + 1).ToString();
            }
            dataGridView1.Columns.AddRange(Stolbech);
            DataGridViewCell[] Content_t = new DataGridViewTextBoxCell[x];
            for (int o = 0; o < x; o++)
            {
                Content_t[o] = new DataGridViewTextBoxCell();
                Content_t[o].Value = opr_mas[o].ToString();
            }
            Stroka.Cells.AddRange(Content_t);
            dataGridView1.Rows.AddRange(Stroka);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
