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
    public partial class Form15 : Form
    {
        MySqlConnection conn;
        string Cmd;
        MySqlCommand cmd;
        string cnum, lnum;
        Form13 parent;
        public Form15(MySqlConnection conn,string cnum,string lnum, Form13 parent)
        {
            InitializeComponent();
            this.conn = conn;
            this.cnum = cnum;
            this.lnum = lnum;
            this.parent = parent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        //点击修改成绩信息
        private void button1_Click(object sender, EventArgs e)
        {
            Cmd = string.Format("update scores set {0} = '{1}' where 学号= '{2}' and 课程编号= '{3}'", item.Text, newProp.Text, cnum, lnum);
            cmd = new MySqlCommand(Cmd, conn);
            conn.Open();
            int count = cmd.ExecuteNonQuery();
            if (count != 0)
            {
                MessageBox.Show("成绩信息修改成功!");
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
