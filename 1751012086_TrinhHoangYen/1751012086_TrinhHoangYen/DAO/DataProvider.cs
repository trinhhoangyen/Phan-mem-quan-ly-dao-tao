using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1751012086_TrinhHoangYen
{
    public class DataProvider
    {
        private static DataProvider instance; //Ctrl + R + E

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }
        
        private DataProvider() { }

        //chuỗi xác định database sẽ kết nối
        private string connectionSTR = @"Data Source=.;Initial Catalog = QuanLyMonHoc1; Integrated Security = True"; 

        //trả về những dòng kết quả
        public DataTable ExcuteQuery(string query, object[] parameter = null)
        {
            //tạo bảng để đổ dữ liệu lấy từ sql lên
            DataTable data = new DataTable();

            // tạo 1 kết nối, kết nối với connectionSTR
            using ( SqlConnection connetion = new SqlConnection(connectionSTR)) 
            {
                connetion.Open();   //mở kết nối

                //tạo câu truy vấn để thực thi chuỗi truy vấn được truyền vào, thông qua kết nối connection đã tạo 
                SqlCommand command = new SqlCommand(query, connetion);

                if( parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach( string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                //trung gian để thực hiện câu truy vấn lấy dữ liệu ra
                SqlDataAdapter adapter = new SqlDataAdapter(command);   // SqlDataAdapter là bộ chuyển đổi ///DataSet -- SqlDataAdapter -- SQL

                adapter.Fill(data); //đổ dữ liệu đã lấy ra vào DataTable đã tạo

                connetion.Close();  //đóng kết nối
            }
            return data;
        }

        //trả về số dòng được thực thi INSERT, DELETE, UPDATE
        public int ExcuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connetion = new SqlConnection(connectionSTR)) // tạo kết nối với connectionSTR
            {
                connetion.Open();   //mở kết nối

                SqlCommand command = new SqlCommand(query, connetion);  //câu truy vấn sẽ thực thi

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();

                connetion.Close();  //đóng kết nối
            }
            return data;
        }

        //trả về kết quả như SELECT COUNT (số cột)
        public object ExcuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connetion = new SqlConnection(connectionSTR)) // tạo kết nối với connectionSTR
            {
                connetion.Open();   //mở kết nối

                SqlCommand command = new SqlCommand(query, connetion);  //câu truy vấn sẽ thực thi

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar();

                connetion.Close();  //đóng kết nối
            }
            return data;
        }


    }
}
