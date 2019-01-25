using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace csharpstudentManager
{
    public partial class Form8 : Form
    {
        MySqlConnection conn;
        string Cmd;
        MySqlCommand cmd;
        string num;
        Form5 parent;
        public Form8(MySqlConnection conn,string num,Form5 parent)
        {
            InitializeComponent();
            this.conn = conn;
            this.num = num;
            this.parent = parent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        //点击修改学生信息
        private void button1_Click(object sender, EventArgs e)
        {
            Cmd = string.Format("update students set {0} = '{1}' where 学号='{2}'", item.Text, newProp.Text, num);
            cmd = new MySqlCommand(Cmd, conn);
            conn.Open();
            int count = cmd.ExecuteNonQuery();
            if (count != 0)
            {
                MessageBox.Show("学生信息信息修改成功!");
            }
            else
            {
                MessageBox.Show("修改失败!");
            }
            conn.Close();
            parent.select();
            Close();
        }
    }
}
