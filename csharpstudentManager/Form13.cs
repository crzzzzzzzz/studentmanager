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
    public partial class Form13 : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;
        bool selectFlag = false;
        public Form13(MySqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetMessage();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            GetMessage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form14 add = new Form14(conn);
            add.Show();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectFlag == true)
            {   //如果查询操作已经执行，可进行修改操作
                Form15 change = new Form15(conn, cnum.Text,lnum.Text,this);
                change.Show();
            }
            else
            {
                MessageBox.Show("请先点击查询按钮查询要操作的成绩信息！");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (selectFlag == true)
            { //如果查询操作已经执行，可进行删除操作
                string Cmd = string.Format("delete from students where 学号='{0}' and 课程编号 = '{1}'", cnum.Text,lnum.Text);
                cmd = new MySqlCommand(Cmd, conn);
                conn.Open();
                int count = cmd.ExecuteNonQuery();
                if (count != 0)
                {
                    MessageBox.Show("成绩信息删除成功!");
                }
                else
                {
                    MessageBox.Show("删除失败!");
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("请先点击查询按钮查询要操作的学生信息！");
            }
        }

        //获取全部成绩信息
        private void GetMessage()
        {
            cmd = new MySqlCommand("select * from scores", conn);
            adapter = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            conn.Open();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                //将每一列都调整为自动适应模式
                dataGridView1.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
            }
            conn.Close();
        }
        //获取选中的成绩信息
        public void select()
        {
            string Cmd = string.Format("select * from scores where 学号 = '{0}' and 课程编号 = '{1}'", cnum.Text,lnum.Text);
            cmd = new MySqlCommand(Cmd, conn);
            adapter = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            conn.Open();
            adapter.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                dataGridView2.DataSource = dt;
                for (int i = 0; i < dataGridView2.Columns.Count; i++)
                {
                    //将每一列都调整为自动适应模式
                    dataGridView2.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                }
                selectFlag = true;
            }
            else
            {
                MessageBox.Show("没有这条成绩信息！");
            }
            conn.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            select();
        }
    }
}
