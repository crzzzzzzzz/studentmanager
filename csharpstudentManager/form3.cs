using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace csharpstudentManager
{
    public partial class Form3 : Form
    {
        string Cmd; 
        MySqlCommand cmd;
        MySqlConnection conn; 

        //构造函数初始化form3
        public Form3(MySqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        //点击修改密码按钮修改信息
        private void button1_Click(object sender, EventArgs e)
        {
            //判断账户是否已存在，存在则不能添加，
            string tCmd = string.Format("select * from managers where 管理员账号 = '{0}' ",textBox1.Text);
            var tcmd = new MySqlCommand(tCmd, conn);
            //打开数据库连接
            conn.Open();
            MySqlDataReader reader = tcmd.ExecuteReader();
            if (!(reader.Read()))
            {
                reader.Close();
                reader.Dispose();

                //两次输入的密码一致则修改密码
                if (textBox2.Text == textBox3.Text)
                {
                    Cmd = "insert into managers(管理员账号,管理员密码) values('" + textBox1.Text + "','" + textBox2.Text + "')";
                    cmd = new MySqlCommand(Cmd, conn);
                    int count = cmd.ExecuteNonQuery();
                    if (count != 0)
                    {
                        MessageBox.Show("添加成功!");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("添加失败!");
                    }
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
                else
                {
                    MessageBox.Show("两次输入的密码不同，请重新输入");
                }
            }
            else
            {
                MessageBox.Show("此账号已存在！");
            }
            //关闭数据库连接
            conn.Close();
        }
    }
}