using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace csharpstudentManager
{
    public partial class Form1 : Form
    {   
        //创建数据库连接对象
        MySqlConnection conn;
        public Form1()
        {
            InitializeComponent();
            string connString = "server=localhost;database=StudentsManager;uid=root;pwd=1234";
            conn = new MySqlConnection(connString);
        }
        
        //按登录按钮登陆
        private void button1_Click(object sender, EventArgs e)
        {   
            //这个变量用于判断是否输入了正确的管理员账号
            bool isManager = false;

            //从managers表中查找管理员账号，遍历一遍，如果有与账号输入框内一致的信息就说明输入正确
            MySqlCommand cmd = new MySqlCommand("select * from managers",conn);
            //reader对象存储查询到的表的信息
            MySqlDataReader reader = null;
            //开启数据库的连接
            conn.Open();
            //把数据给reader对象
            reader = cmd.ExecuteReader();
            //遍历reader对象
            while (reader.Read())
            {
                //如果输入正确则跳出遍历
                if (textBox1.Text == reader[0].ToString())
                {
                    isManager = true;
                    break;
                }
            }

            //只用正则表达式，判断账号中是否有非法字符
            Regex regExp = new Regex("[ \\[ \\] \\^ \\-_*×――(^)$%~!@#$…&%￥—+=<>《》!！??？:：•`·、。，；,.;\"‘’“”-]");
            if (!regExp.IsMatch(textBox1.Text)) {
                //没有非法字符再判断是否输入了正确的管理员账号
                if (isManager)
                {//输入了正确的管理员账号再判断是否输入了正确的管理员密码
                    if (textBox2.Text == reader[1].ToString())
                    {
                        Hide();
                        Form2 myPage = new Form2(reader[0].ToString(),conn);
                        //都对了就登陆
                        myPage.Show();
                    }
                    else
                        MessageBox.Show("密码错误");
                }
                else
                    MessageBox.Show("数据库中没有这个用户");
            }
            else
                MessageBox.Show("含有非法字符");
            reader.Close();
            reader.Dispose();
            conn.Close();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            //注册按钮跳转到添加管理用户界面
            Form3 register = new Form3(conn);
            register.Show();
        }

        private void Form1_load(object sender, EventArgs e)
        {
            //设置页面布局（form不方便的地方）
            label2.Parent = pictureBox4;
            label3.Parent = pictureBox4;
            pictureBox2.Parent = pictureBox4;
            pictureBox3.Parent = pictureBox4;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //点击取消退出程序
            Application.Exit();
        }
    }
}
