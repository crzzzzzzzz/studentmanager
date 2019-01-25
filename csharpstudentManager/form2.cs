using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace csharpstudentManager
{
    public partial class Form2 : Form
    {
        MySqlConnection conn;
        //存储传进来的用户名
        string name;
        //构造函数初始化form2
        public Form2(string name, MySqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            this.name = name;
            label1.Text = "欢迎进入学生成绩管理系统，"+ this.name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Hide();
            //点击“添加用户名”跳出添加的form
            Form3 login = new Form3(conn);
            login.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Hide();
            //点击“修改密码”跳出修改的form
            Form4 changePassword = new Form4(conn,name);
            changePassword.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Hide();
            //点击“学生信息查询”跳出查询的form
            Form5 inquiry = new Form5(conn);
            inquiry.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Hide();
            //点击“专业课信息管理”跳出专业课信息的form
            Form6 manage = new Form6(conn);
            manage.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //点击“专业课成绩管理”跳出成绩信息的form
            Form13 score = new Form13(conn);
            score.Show();
        }

        private void form1_closed(object sender, FormClosedEventArgs e)
        {
            //点击右上角❌退出程序
            Application.Exit();
        }
       
    }
}
