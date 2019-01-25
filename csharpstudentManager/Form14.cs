using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharpstudentManager
{
    public partial class Form14 : Form
    {
        MySqlConnection conn;
        string Cmd;
        MySqlCommand cmd;
        public Form14(MySqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        //点击插入成绩信息
        private void button1_Click(object sender, EventArgs e)
        {
            Cmd = string.Format("insert into scores(学号,课程编号,成绩) values('{0}','{1}','{2}')", snum.Text, cnum.Text, score.Text);
            cmd = new MySqlCommand(Cmd, conn);
            conn.Open();
            int count = cmd.ExecuteNonQuery();
            if (count != 0)
            {
                MessageBox.Show("成绩添加成功!");
            }
            else
            {
                MessageBox.Show("添加失败!");
            }
            snum.Text = "";
            cnum.Text = "";
            score.Text = "";
            conn.Close();
            Close();
        }
    }
}
