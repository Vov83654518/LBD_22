﻿using System;
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
    public partial class Form2 : Form
    {
        public void Create_Table_f2(int x, int y,double[][] a)
        {
            DataGridViewTextBoxColumn[] Stolbech = new DataGridViewTextBoxColumn[x];
            DataGridViewRow[] Stroka = new DataGridViewRow[y];
            for (int i = 0; i < x; i++)
            {
                Stolbech[i] = new DataGridViewTextBoxColumn();
                Stolbech[i].Name = (i + 1).ToString();
            }
            dataGridView1.Columns.AddRange(Stolbech);
            for (int i = 0; i < y; i++)
            {
                Stroka[i] = new DataGridViewRow();
                DataGridViewCell[] Content_t = new DataGridViewTextBoxCell[x];
                for (int o = 0; o < x; o++)
                {
                    Content_t[o] = new DataGridViewTextBoxCell();
                    Content_t[o].Value = a[i][o].ToString();
                }
                Stroka[i].Cells.AddRange(Content_t);
            }
            dataGridView1.Rows.AddRange(Stroka);
        }
        public Form2(int n, double[][] a)
        {
            InitializeComponent();
            Create_Table_f2(n, n, a);
            label3.Text = Matematik.Opr(n, a).ToString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
