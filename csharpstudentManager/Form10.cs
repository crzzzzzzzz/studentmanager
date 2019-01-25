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
    public partial class Form10 : Form
    {
        MySqlConnection conn;
        string Cmd;
        MySqlCommand cmd;
        public Form10(MySqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        //点击添加课程信息
        private void button1_Click(object sender, EventArgs e)
        {
            Cmd = string.Format("insert into lessons(课程编号,授课教师,课程名称,课程学分) values('{0}','{1}','{2}','{3}')", num.Text, teacher.Text, name.Text, point.Text);
            cmd = new MySqlCommand(Cmd, conn);
            conn.Open();
            int count = cmd.ExecuteNonQuery();
            if (count != 0)
            {
                MessageBox.Show("专业课信息添加成功!");
            }
            else
            {
                MessageBox.Show("添加失败!");
            }
            num.Text = "";
            teacher.Text = "";
            name.Text = "";
            point.Text = "";
            conn.Close();
            Close();
        }
    }
    
}
