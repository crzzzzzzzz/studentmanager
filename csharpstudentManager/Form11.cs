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
    public partial class Form11 : Form
    {
        MySqlConnection conn;
        string Cmd;
        MySqlCommand cmd;
        string num;
        Form6 parent;
        public Form11(MySqlConnection conn,string num, Form6 parent)
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
            Cmd = string.Format("update lessons set {0} = '{1}' where 课程编号 = '{2}'", item.Text, newProp.Text, num);
            cmd = new MySqlCommand(Cmd, conn);
            conn.Open();
            int count = cmd.ExecuteNonQuery();
            if (count != 0)
            {
                MessageBox.Show("专业课信息修改成功!");
            }
            else
            {
                MessageBox.Show("修改失败!");
            }
            item.Text = "";
            newProp.Text = "";
            conn.Close();
            parent.select();
            Close();
        }
    }
}
