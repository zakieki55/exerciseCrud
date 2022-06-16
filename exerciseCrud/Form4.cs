using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exerciseCrud
{
    public partial class Form4 : Form
    {
        DataTable dt;
        DataRow dr;
        string code;
        public Form4()
        {
            InitializeComponent();
        }

        private void btnadd1_Click(object sender, EventArgs e)
        {
            btnsave1.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            int ctr, len;
            string codeval;
            dt = execrudDataSet.Tables["mhs"];
            len = dt.Rows.Count - 1;
            dr = dt.Rows[len];
            code = dr["nama_mhs"].ToString();
            codeval = code.Substring(1, 3);

            btnadd1.Enabled = false;
        }

        private void btnsave1_Click(object sender, EventArgs e)
        {
            dt = execrudDataSet.Tables["mhs"];
            dr = dt.NewRow();
            dr[0] = textBox1.Text;
            dr[1] = textBox2.Text;
            dr[2] = textBox3.Text;
            dt.Rows.Add(dr);
            mhsTableAdapter.Update(execrudDataSet);
            textBox1.Text = System.Convert.ToString(dr[0]);
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            this.mhsTableAdapter.Fill(this.execrudDataSet.mhs);
            btnadd1.Enabled = true;
            btnsave1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'execrudDataSet.mhs' table. You can move, or remove it, as needed.
            this.mhsTableAdapter.Fill(this.execrudDataSet.mhs);

        }
    }
}
