using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;   //引用MySql

namespace ConnectMysql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string constructorString = "server=localhost;User Id=root;password=;Database=company";
            string constructorString = "Database=CSU;Data Source= 45.77.135.81;User Id=CSU;Password=SzzCMeXBEB;charset='utf8';pooling=true";
            MySqlConnection myConnnect = new MySqlConnection(constructorString);
             myConnnect.Open();
             MySqlCommand myCmd = new MySqlCommand("INSERT INTO `CSU`.`test` (`姓名`, `学号`, `数学`) VALUES ('李四', '02', '85');", myConnnect);
            
             //Console.WriteLine(myCmd.CommandText);
             if (myCmd.ExecuteNonQuery() > 0)
             {
                MessageBox.Show("数据插入成功！");
                //Console.WriteLine("数据插入成功！");
             }
          ///下面是读取数据库中单独的数值与数据表
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter("SELECT 姓名,学号 FROM `test` ", myConnnect);
            adp.Fill(ds);
            myConnnect.Close();
            dataGridView1.DataSource = ds.Tables[0];
            textBox1.Text = ds.Tables[0].Rows[0][0].ToString();
            ds.Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
