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
    public partial class Form3 : Form
    {
        DataTable dt;
        DataRow dr;
        string code;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'execrudDataSet.matkul' table. You can move, or remove it, as needed.
            this.matkulTableAdapter.Fill(this.execrudDataSet.matkul);

        }

        private void btnadd2_Click(object sender, EventArgs e)
        {
            btnsave2.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            int ctr, len;
            string codeval;
            dt = execrudDataSet.Tables["matkul"];
            len = dt.Rows.Count - 1;
            dr = dt.Rows[len];
            code = dr["nama_matkul"].ToString();
            codeval = code.Substring(1, 3);

            btnadd2.Enabled = false;
        }

        private void btnsave2_Click(object sender, EventArgs e)
        {
            dt = execrudDataSet.Tables["matkul"];
            dr = dt.NewRow();
            dr[0] = textBox1.Text;
            dr[1] = textBox2.Text;
            dr[2] = textBox3.Text;
            dt.Rows.Add(dr);
            matkulTableAdapter.Update(execrudDataSet);
            textBox1.Text = System.Convert.ToString(dr[0]);
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            this.matkulTableAdapter.Fill(this.execrudDataSet.matkul);
            btnadd2.Enabled = true;
            btnsave2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
