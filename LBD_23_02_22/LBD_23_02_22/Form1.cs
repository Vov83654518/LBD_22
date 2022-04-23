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
    public partial class Form1 : Form
    {
        public void Create_Table(int x, int y)
        {
            DataGridViewTextBoxColumn[] Stolbech = new DataGridViewTextBoxColumn[x+1];
            DataGridViewRow[] Stroka = new DataGridViewRow[y];
            for (int i = 0; i < x; i++) 
            {
                Stolbech[i] = new DataGridViewTextBoxColumn();
                Stolbech[i].Name = (i+1).ToString();
            }
            Stolbech[x] = new DataGridViewTextBoxColumn();
            Stolbech[x].Name = "b";
            dataGridView1.Columns.AddRange(Stolbech);
            for (int i = 0; i < y; i++)
            {
                Stroka[i] = new DataGridViewRow();
                DataGridViewCell []Content_t = new DataGridViewTextBoxCell[x+1];
                for (int o = 0; o < x+1; o++)
                {
                    Content_t[o] = new DataGridViewTextBoxCell();
                    Content_t[o].Value = "";
                }
                Stroka[i].Cells.AddRange(Content_t);
            }
            dataGridView1.Rows.AddRange(Stroka);
        } 
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                Create_Table(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox1.Text));
            }
            catch (Exception)
            {
                textBox3.Text = "Error";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (IsOllEst())
            {
                try
                {
                    int y = dataGridView1.Rows.Count, x = dataGridView1.Columns.Count;
                    double[] opr_mas = new double[x];
                    for (int i = 0; i < x; ++i)
                    {
                        double[][] a = new double[y][];
                        for (int o = 0; o < y; o++)
                        {
                            a[o] = new double[y];
                            for (int p = 0; p < y; p++)
                                if (i - 1 == p) a[o][p] = Convert.ToDouble(dataGridView1.Rows[o].Cells[y].Value.ToString());
                                else a[o][p] = Convert.ToDouble(dataGridView1.Rows[o].Cells[p].Value.ToString());
                        }
                        double[][] ad = new double[y][];
                        for (int o = 0; o < y; o++)
                        {
                            ad[o] = new double[y];
                            for (int p = 0; p < y; p++) ad[o][p] = a[o][p];
                        }
                        Form2 form2 = new Form2(y, ad);
                        form2.ShowDialog();
                        opr_mas[i] = Matematik.Opr(y, a);
                    }
                    if (opr_mas[0] != 0)
                    {
                        Form3 form3 = new Form3(opr_mas);
                        form3.Show();
                        double[] rez = new double[y];
                        for (int i = 0; i < y; i++)
                            rez[i] = (opr_mas[i + 1] / opr_mas[0]);
                        textBox3.Text = "";
                        foreach (var r in rez) textBox3.Text += r.ToString() + " ";
                    }
                    else
                    {
                        textBox3.Text = "null";
                    }
                }
                catch (Exception)
                {
                    textBox3.Text = "Error";
                }
            }
            else textBox3.Text = "null";
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public bool IsOllEst()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    for (int o = 0; o < dataGridView1.Rows.Count; o++)
                        if (Convert.ToDouble(dataGridView1.Rows[o].Cells[i].Value.ToString()) == null) return false;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public double[] Rehenie()
        {
            if (IsOllEst())
            {
                try
                {
                    int y = dataGridView1.Rows.Count, x = dataGridView1.Columns.Count;
                    double[] opr_mas = new double[x];
                    for (int i = 0; i < x; ++i)
                    {
                        double[][] a = new double[y][];
                        for (int o = 0; o < y; o++)
                        {
                            a[o] = new double[y];
                            for (int p = 0; p < y; p++)
                                if (i - 1 == p) a[o][p] = Convert.ToDouble(dataGridView1.Rows[o].Cells[y].Value.ToString());
                                else a[o][p] = Convert.ToDouble(dataGridView1.Rows[o].Cells[p].Value.ToString());
                        }
                        opr_mas[i] = Matematik.Opr(y, a);
                    }
                    if (opr_mas[0] != 0)
                    {
                        double[] rez = new double[y];
                        for (int i = 0; i < y; i++)
                            rez[i] = (opr_mas[i + 1] / opr_mas[0]);
                        return rez;
                    }
                    else return null;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else return null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var rez = Rehenie();
            if (rez != null) 
            {
                textBox3.Text = "";
                for (int i = 0; i < dataGridView1.Rows.Count; i++) textBox3.Text += rez[i].ToString() + " ";
            }
            else textBox3.Text = "Error";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var s = textBox3.Text.Split(' ');
            var rez = Rehenie();
            if (rez == null && s[0] == "null") textBox3.Text = "Yes";
            else if (s.Length-1 == dataGridView1.Rows.Count && rez != null)
            {
                int otv = 0;
                foreach (var r in rez)
                    foreach (var st in s)
                        if (r.ToString() == st) otv++;
                if (otv>= s.Length-1) textBox3.Text = "Yes";
                else textBox3.Text = "No";
            }
            else textBox3.Text = "No";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int y = dataGridView1.Rows.Count, x = dataGridView1.Columns.Count;
            Random random = new Random();
            for (int i = 0; i < x; ++i)
            {
                for (int o = 0; o < y; o++)
                {
                    dataGridView1.Rows[o].Cells[i].Value = random.Next(-100,100).ToString();
                }
            }
        }
    }
}
