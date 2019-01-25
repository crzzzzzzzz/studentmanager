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
    public partial class Form6 : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;
        bool selectFlag = false;
        public Form6(MySqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GetMessage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form10 add = new Form10(conn);
            add.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectFlag == true)
            { //如果已经查询，才能执行修改
                Form11 change = new Form11(conn, num.Text,this);
                change.Show();
            }
            else
            {
                MessageBox.Show("请先点击查询按钮查询要操作的专业课信息！");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (selectFlag == true)
            {//如果已经查询，那么才能执行查询
                string Cmd = string.Format("delete from lessons where 课程编号='{0}'", num.Text);
                cmd = new MySqlCommand(Cmd, conn);
                conn.Open();
                //返回影响的行数，可用作判断是否修改成功
                int count = cmd.ExecuteNonQuery();
                if (count != 0)
                {
                    MessageBox.Show("专业课信息删除成功!");
                }
                else
                {
                    MessageBox.Show("删除失败!");
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("请先点击查询按钮查询要操作的专业课信息！");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        //用来获取全部专业课的信息
        private void GetMessage()
        {
            cmd = new MySqlCommand("select * from lessons", conn);
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

        //用来查询选中的专业课的信息
        public void select()
        {
            string Cmd = string.Format("select * from lessons where 课程编号 = '{0}'", num.Text);
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
                MessageBox.Show("没有这门专业课！");
            }
            conn.Close();
        }

        //加载form的时候执行的方法，先刷新一遍所有的信息
        private void Form6_Load(object sender, EventArgs e)
        {
            GetMessage();
        }

        //点击查询按钮进行查询
        private void button6_Click(object sender, EventArgs e)
        {
            select();
        }
    }
}
