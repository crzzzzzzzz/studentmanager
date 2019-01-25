using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace csharpstudentManager
{
    public partial class Form4 : Form
    {
        MySqlConnection conn;
        string Cmd;
        MySqlCommand cmd;
        //保存传进来的账号
        string account;

        public Form4(MySqlConnection conn,string account)
        {
            InitializeComponent();
            this.conn = conn;
            this.account = account;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        //点击修改按钮修改密码
        private void button1_Click(object sender, EventArgs e)
        {
            if (newpw.Text == confirm.Text)
            {
                Cmd = string.Format("update managers set 管理员密码 = '{0}' where 管理员账号='{1}'", newpw.Text,account);
                cmd = new MySqlCommand(Cmd, conn);
                conn.Open();
                //ExecuteNonQuery命令可返回此cmd语句影响的行数，可判断是否修改成功
                int count = cmd.ExecuteNonQuery();
                if (count != 0)
                {
                    MessageBox.Show("密码修改成功!");
                }
                else
                {
                    MessageBox.Show("修改失败!");
                }
                conn.Close();
                newpw.Text = "";
                confirm.Text = "";
            }
            else
            {
                MessageBox.Show("两次输入的密码不一致");
            }
           
        }
    }
}
