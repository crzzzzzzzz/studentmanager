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
    public partial class Form7 : Form
    {
        MySqlConnection conn;
        string Cmd;
        MySqlCommand cmd;
        public Form7(MySqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        //点击添加按钮添加学生系统
        private void button1_Click(object sender, EventArgs e)
        {
            Cmd = string.Format("insert into students(学号,姓名,年龄,性别,籍贯,政治面貌,入学时间,联系电话) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", num.Text, name.Text, sex.Text, age.Text, place.Text, face.Text, admission.Text, tel.Text);
            cmd = new MySqlCommand(Cmd, conn);
            conn.Open();
            int count = cmd.ExecuteNonQuery();
            if (count != 0)
            {
                MessageBox.Show("学生信息添加成功!");
                Close();
            }
            else
            {
                MessageBox.Show("添加失败!");
            }
            num.Text = "";
            name.Text = "";
            sex.Text = "";
            age.Text = "";
            place.Text = "";
            face.Text = "";
            admission.Text = "";
            tel.Text = "";
            conn.Close();
            Close();
        }


    }
}
