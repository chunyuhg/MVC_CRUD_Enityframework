using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace test2.Controllers
{
    
    public class HomeController : Controller
    {
        string strConnString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        List<Result_Lsit> A_list = new List<Result_Lsit>();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Demo()
        {
            //make_table("member");
            // AddDate();
            //SelectData();
            InsertData();
            //DeleteData();
            //UpdateData();
            return View();
        }
        public void make_table(string table_name)
        {
            using (SqlConnection conn = new SqlConnection(strConnString))
            {
                conn.Open();
                SqlCommand scom = conn.CreateCommand();
                scom.CommandType = CommandType.Text;
                string msg = "CREATE TABLE [dbo].[member]" +
                    "( [member_id] INT  NOT NULL PRIMARY KEY, " +
                    "[name] NCHAR(10) NULL,"+  
                    "[gender] NCHAR(1) NULL,"+
                    "[phone] NCHAR(10) NULL, "+
                   " [address] NCHAR(50) NULL)";

                scom.CommandText = @msg;
                int n = scom.ExecuteNonQuery();



                scom.Cancel();
                conn.Close();
                conn.Dispose();

            }
        }
       
        public void InsertData()
        {
            using (SqlConnection conn = new SqlConnection(strConnString))
            {
                conn.Open();
                SqlCommand scom = conn.CreateCommand();
                scom.CommandType = CommandType.Text;
                //string msg = "Insert into [dbo].[member] values(1,'AA','F','123789','gghkghkr')";
                string msg = "Select * From [dbo].[member]";
                scom.CommandText = @msg;
                scom.ExecuteNonQuery();
                SqlDataReader read = scom.ExecuteReader();
                
                scom.Cancel();//關閉DataReader之前，一定要先「取消」SqlCommand
                conn.Close();
                conn.Dispose();
            }
        }
        public void SelectData()
        {
            using (SqlConnection conn = new SqlConnection(strConnString))
            {
                conn.Open();
                SqlCommand scom = conn.CreateCommand();
                scom.CommandType = CommandType.Text;
                string msg = "Select * From [dbo].[member]";
                scom.CommandText = @msg;
                scom.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(scom);
                da.Fill(dt);
                
                scom.Cancel();//關閉DataReader之前，一定要先「取消」SqlCommand
                conn.Close();
                conn.Dispose();
            }
        }
        public void DeleteData()
        {
            using (SqlConnection conn = new SqlConnection(strConnString))
            {
                conn.Open();
                SqlCommand scom = conn.CreateCommand();
                scom.CommandType = CommandType.Text;
                string msg = "Delete From [dbo].[member] where member_id=1";
                scom.CommandText = @msg;
                scom.ExecuteNonQuery();
                scom.Cancel();//關閉DataReader之前，一定要先「取消」SqlCommand
                conn.Close();
                conn.Dispose();
            }
        }
        public void UpdateData() {
            using (SqlConnection conn = new SqlConnection(strConnString))
            {
                conn.Open();
                SqlCommand scom = conn.CreateCommand();
                scom.CommandType = CommandType.Text;
                string msg = "Update [dbo].[member] set member_id=2"+
                    "where member_id=1";
                scom.CommandText = @msg;
                scom.ExecuteNonQuery();
                scom.Cancel();//關閉DataReader之前，一定要先「取消」SqlCommand
                conn.Close();
                conn.Dispose();
            }
        }
        public void ReadData()
        {
            string[] arr = { "", "", "","","" };
            using (SqlConnection conn = new SqlConnection(strConnString))
            {
                conn.Open();
                SqlCommand scom =  conn.CreateCommand();
                scom.CommandType = CommandType.Text;
                string msg = "select *from [Result] where [id]='1'";
                scom.CommandText = @msg;
                scom.ExecuteNonQuery();
                //SqlDataReader sread = scom.ExecuteReader();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(scom);
                da.Fill(dt);
                
               
                scom.Cancel();//關閉DataReader之前，一定要先「取消」SqlCommand
                conn.Close();
                conn.Dispose();
            }
            
           
        }
       
        public void WriteData()
        {
            using (SqlConnection conn = new SqlConnection(strConnString))
            {


                conn.Open();
                SqlCommand scom = conn.CreateCommand();
                //scom.CommandText = @"from[dbo].[Result]";
                scom.CommandType = CommandType.Text;
                string math_message = "update [Result]  set [A_80-100]='"+A_list[0].A_80_100.ToString() +"'" +
                    ",[A_avg_80-100]= '" + A_list[0].A_avg_80_100.ToString() +"'" +
                    ",[B_60-79]= '" + A_list[0].B_60_79.ToString() + "'" +
                    ",[B_avg_60-79]= '" + A_list[0].B_avg_60_79.ToString() + "'" +
                    ",[C_0-59]= '" + A_list[0].C_0_59.ToString() + "'" +
                    ",[C_avg_0-59]= '" + A_list[0].C_avg_0_59.ToString() + "'" +
                    " where [id]='2'";
                string en_message= "update [Result]  set [A_80-100]='" + A_list[1].A_80_100.ToString() + "'" +
                    ",[A_avg_80-100]= '" + A_list[1].A_avg_80_100.ToString() + "'" +
                    ",[B_60-79]= '" + A_list[1].B_60_79.ToString() + "'" +
                    ",[B_avg_60-79]= '" + A_list[1].B_avg_60_79.ToString() + "'" +
                    ",[C_0-59]= '" + A_list[1].C_0_59.ToString() + "'" +
                    ",[C_avg_0-59]= '" + A_list[1].C_avg_0_59.ToString() + "'" +
                    " where [id]='3'";
                string ch_message = "update [Result]  set [A_80-100]='" + A_list[2].A_80_100.ToString() + "'" +
                    ",[A_avg_80-100]= '" + A_list[2].A_avg_80_100.ToString() + "'" +
                    ",[B_60-79]= '" + A_list[2].B_60_79.ToString() + "'" +
                    ",[B_avg_60-79]= '" + A_list[2].B_avg_60_79.ToString() + "'" +
                    ",[C_0-59]= '" + A_list[2].C_0_59.ToString() + "'" +
                    ",[C_avg_0-59]= '" + A_list[2].C_avg_0_59.ToString() + "'" +
                    " where [id]='1'";
                string message = ch_message + en_message + math_message;
                
                scom.CommandText = @message;
              
                int n =scom.ExecuteNonQuery();
              
               
                conn.Close();


            }
        }
        private class Result_Lsit
        {
            public string category { get; set; }
            public int A_80_100 { get; set; }
            public int B_60_79 { get; set; }
            public int C_0_59 { get; set; }
            public int A_avg_80_100 { get; set; }
            public int B_avg_60_79 { get; set; }
            public int C_avg_0_59 { get; set; }
            
            
        }
    }
   
}