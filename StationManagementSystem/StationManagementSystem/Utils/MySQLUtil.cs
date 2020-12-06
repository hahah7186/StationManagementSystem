using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace StationManagementSystem.Utils
{

    /// <summary>
    /// 通用数据库类MySQL 
    /// </summary>
    public class MySQLUtil
    {
        protected String ConnectionString;

        public MySQLUtil()
        {
            //构造函数
            ConnectionString = "127.0.0.1";
        }

        //public static string ConnStr = @"server=数据库;uid=帐号;pwd=密码;database=数据库;charset=utf8";
        //public static string ConnStr = MyData.Properties.Settings.Default.my_soft_mysqlConn + "pwd=密码;charset=utf8;";

        //打开数据库链接
        public MySqlConnection Open_Conn()
        {
            MySqlConnection Conn = new MySqlConnection(ConnectionString);
            Conn.Open();
            return Conn;
        }
        //关闭数据库链接
        public void Close_Conn(MySqlConnection Conn)
        {
            if (Conn != null)
            {
                Conn.Close();
                Conn.Dispose();
            }
            GC.Collect();
        }
        //运行MySql语句
        public int Run_SQL(string SQL)
        {
            MySqlConnection Conn = Open_Conn();
            MySqlCommand Cmd = Create_Cmd(SQL, Conn);
            try
            {
                int result_count = Cmd.ExecuteNonQuery();
                Close_Conn(Conn);
                return result_count;
            }
            catch
            {
                Close_Conn(Conn);
                return 0;
            }
        }
        // 生成Command对象 
        public MySqlCommand Create_Cmd(string SQL, MySqlConnection Conn)
        {
            MySqlCommand Cmd = new MySqlCommand(SQL, Conn);
            return Cmd;
        }
        // 运行MySql语句返回 DataTable
        public DataTable Get_DataTable(string SQL, string ConnStr, string Table_name)
        {
            MySqlDataAdapter Da = Get_Adapter(SQL);
            DataTable dt = new DataTable(Table_name);
            Da.Fill(dt);
            return dt;
        }
        // 运行MySql语句返回 MySqlDataReader对象
        public MySqlDataReader Get_Reader(string SQL, string ConnStr)
        {
            MySqlConnection Conn = Open_Conn();
            MySqlCommand Cmd = Create_Cmd(SQL, Conn);
            MySqlDataReader Dr;
            try
            {
                Dr = Cmd.ExecuteReader(CommandBehavior.Default);
            }
            catch
            {
                throw new Exception(SQL);
            }
            Close_Conn(Conn);
            return Dr;
        }
        // 运行MySql语句返回 MySqlDataAdapter对象 
        public MySqlDataAdapter Get_Adapter(string SQL)
        {
            MySqlConnection Conn = Open_Conn();
            MySqlDataAdapter Da = new MySqlDataAdapter(SQL, Conn);
            return Da;
        }
        // 运行MySql语句,返回DataSet对象
        public DataSet Get_DataSet(string SQL, string ConnStr, DataSet Ds)
        {
            MySqlDataAdapter Da = Get_Adapter(SQL);
            try
            {
                Da.Fill(Ds);
            }
            catch (Exception Err)
            {
                throw Err;
            }
            return Ds;
        }
        // 运行MySql语句,返回DataSet对象
        public DataSet Get_DataSet(string SQL, string ConnStr, DataSet Ds, string tablename)
        {
            MySqlDataAdapter Da = Get_Adapter(SQL);
            try
            {
                Da.Fill(Ds, tablename);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return Ds;
        }
        // 运行MySql语句,返回DataSet对象，将数据进行了分页
        public DataSet Get_DataSet(string SQL, DataSet Ds, int StartIndex, int PageSize, string tablename)
        {
            MySqlConnection Conn = Open_Conn();
            MySqlDataAdapter Da = Get_Adapter(SQL);
            try
            {
                Da.Fill(Ds, StartIndex, PageSize, tablename);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            Close_Conn(Conn);
            return Ds;
        }
        // 返回MySql语句执行结果的第一行第一列
        public string Get_Row1_Col1_Value(string SQL, string ConnStr)
        {
            MySqlConnection Conn = Open_Conn();
            string result;
            MySqlDataReader Dr;
            try
            {
                Dr = Create_Cmd(SQL, Conn).ExecuteReader();
                if (Dr.Read())
                {
                    result = Dr[0].ToString();
                    Dr.Close();
                }
                else
                {
                    result = "";
                    Dr.Close();
                }
            }
            catch
            {
                throw new Exception(SQL);
            }
            Close_Conn(Conn);
            return result;
        }
    }
}
