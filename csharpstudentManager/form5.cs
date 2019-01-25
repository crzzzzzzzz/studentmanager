using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace csharpstudentManager
{
    public partial class Form5 : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;
        bool selectFlag = false;
        public Form5(MySqlConnection conn)
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

        private void Form5_Load(object sender, EventArgs e)
        {
            GetMessage();
        }

        //此方法用来刷新全部学生信息
        private void GetMessage()
        {
            cmd = new MySqlCommand("select * from students", conn);
            //这里用adapter作为桥梁连接数据库与此程序
            adapter = new MySqlDataAdapter(cmd);
            //DataTable用于从存储通过adapter连接后获取的数据
            dt = new DataTable();
            //打开数据库连接
            conn.Open();
            //数据存到dt表中
            adapter.Fill(dt);
            //设置数据源为dt表
            dataGridView1.DataSource = dt;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                //将每一列都调整为自动适应模式
                dataGridView1.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
            }
            conn.Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 add = new Form7(conn);
            add.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //先判断是否进行查询操作
            if (selectFlag == true)
            {
                //那么
                Form8 change = new Form8(conn, num.Text,this);
                change.Show();
            }
            else
            {
                MessageBox.Show("请先点击查询按钮查询要操作的学生信息！");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //先判断有没有查询
            if (selectFlag == true)
            {
                //删除操作
                string Cmd = string.Format("delete from students where 学号='{0}'", num.Text);
                cmd = new MySqlCommand(Cmd, conn);
                conn.Open();
                int count = cmd.ExecuteNonQuery();
                if (count != 0)
                {
                    MessageBox.Show("学生信息删除成功!");
                    //删除后置空学号查询文本框，置空数据源
                    dataGridView2.DataSource =  null;
                    num.Text = "";
                    selectFlag = false;
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
        private void button5_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        //此方法查询某个学生信息
        public void select()
        {
            string Cmd = string.Format("select * from students where 学号 = '{0}'", num.Text);
            cmd = new MySqlCommand(Cmd, conn);
            //这里用adapter作为桥梁连接数据库与此程序
            adapter = new MySqlDataAdapter(cmd);
            //DataTable用于从存储通过adapter连接后获取的数据
            dt = new DataTable();
            conn.Open();
            //获取（就是fill）
            adapter.Fill(dt);
            //如果信息非空（就是有这个学号）
            if(dt.Rows.Count != 0)
            {
                //就设置dataGridView2控件的数据源为dt
                dataGridView2.DataSource = dt;
                for (int i = 0; i < dataGridView2.Columns.Count; i++)
                {
                    //将每一列都调整为自动适应模式（看起来好看）
                    dataGridView2.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                }
                selectFlag = true;
            }
            else
            {
                MessageBox.Show("没有此位学生！");
            }
            conn.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            select();
        }
    }
}
