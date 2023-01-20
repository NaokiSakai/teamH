
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TeamHApp.Models



{
    public class DBconnect
    {
        public static void Test()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                // DBサーバー名
                builder.DataSource = "schoolnetdb.database.windows.net";
                // ユーザー名
                builder.UserID = "schoolnetadmin";
                // パスワード
                builder.Password = "schoolnetpass000!";
                // DB名
                builder.InitialCatalog = "SchoolNETDataBase";


                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");


                    // SQL文の発行
                    String sql_select = "SELECT * FROM dbo.items";
                    String[] column = { "items_Id", "classify", "type", "image_path", "found_place", "information", "is_sended_notice" };




                    using (SqlCommand command = new SqlCommand(sql_select, connection))
                    {
                        string s = "";

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        // SELECT文の場合は結果を表示する
                        
                        if (sql_select.StartsWith("SELECT"))
                            while (reader.Read())
                            {

                              


                            }
                        reader.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {

                Console.WriteLine("");
                Console.WriteLine("---------------End---------------");
            }
            
        }


        public static List<itemsModel> GetItems()
        {
            List<itemsModel> result = new List<itemsModel>();
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                // DBサーバー名
                builder.DataSource = "schoolnetdb.database.windows.net";
                // ユーザー名
                builder.UserID = "schoolnetadmin";
                // パスワード
                builder.Password = "schoolnetpass000!";
                // DB名
                builder.InitialCatalog = "SchoolNETDataBase";


                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");


                    // SQL文の発行
                    String sql_select = "SELECT * FROM dbo.items";
                    String[] column = { "items_Id", "classify", "type", "image_path", "found_place", "information", "is_sended_notice" };




                    using (SqlCommand command = new SqlCommand(sql_select, connection))
                    {
                        string s = "";

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        // SELECT文の場合は結果を表示する

                        if (sql_select.StartsWith("SELECT"))
                            while (reader.Read())
                            {
                                itemsModel m = new itemsModel();

                                m.items_id = (int)reader["items_Id"];
                                m.classify = (string)reader["classify"];
                                m.image_path = (string)reader["image_path"];
                                m.information = (string)reader["information"];
                                string str_nortice = (string)reader["is_sended_notice"];

                                m.is_sended_notice = str_nortice; 
                               
                                

                                result.Add(m);

                            }
                        reader.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {

                Console.WriteLine("");
                Console.WriteLine("---------------End---------------");
            }
         
            

            return result;
        }

        public static void InsertItem(string classify,  string image_path, string found_place,string information, string is_sended_notice )
        {
            List<itemsModel> result = new List<itemsModel>();
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                // DBサーバー名
                builder.DataSource = "schoolnetdb.database.windows.net";
                // ユーザー名
                builder.UserID = "schoolnetadmin";
                // パスワード
                builder.Password = "schoolnetpass000!";
                // DB名
                builder.InitialCatalog = "SchoolNETDataBase";


                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");


                    // SQL文の発行
                    String sql_select = "INSERT INTO dbo.items(";
                    String[] column = {"classify",  "image_path", "found_place", "information", "is_sended_notice" };
                    for( int i = 0; i<column.Length ; i++){
                        sql_select += column[i];
                        if(i == column.Length - 1)
                        {
                            break;
                        }
                        sql_select += ",";

                    }
                    sql_select += ")VALUES(";
                    sql_select += "N'" + classify + "',N'" + image_path + "',N'" + found_place + "',N'" + information + "',N'" + is_sended_notice + "');";

                    Debug.WriteLine(sql_select);

                    using (SqlCommand command = new SqlCommand(sql_select, connection))
                    {
                        

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        // SELECT文の場合は結果を表示する

                        reader.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {

                Console.WriteLine("");
                Console.WriteLine("---------------End---------------");
            }
        }

        public static List<LostReservationModel> GetReserve(int item_id)
        {
            List<LostReservationModel> result = new List<LostReservationModel>();
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                // DBサーバー名
                builder.DataSource = "schoolnetdb.database.windows.net";
                // ユーザー名
                builder.UserID = "schoolnetadmin";
                // パスワード
                builder.Password = "schoolnetpass000!";
                // DB名
                builder.InitialCatalog = "SchoolNETDataBase";


                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");


                    // SQL文の発行
                    string sql_select_reserve = "SELECT * FROM dbo.reserv WHERE items_Id = " + item_id + ";";
                    string sql_select_user = "SELECT * FROM dbo.UserTable";

                    SqlDataReader user_reader;
                    List<UserModel> userlist = new List<UserModel>();
                   
                    using (SqlCommand command = new SqlCommand(sql_select_user, connection))
                    {
                        connection.Open();
                        user_reader = command.ExecuteReader();
                        while (user_reader.Read())
                        {
                            UserModel m = new UserModel();
                            m.userId =(int)user_reader["user_Id"];
                            m.name = (string)user_reader["name"];
                            userlist.Add(m);
                        }
                    }
                    user_reader.Close();


                    using (SqlCommand command = new SqlCommand(sql_select_reserve, connection))
                    {
                        string s = "";

                        
                        SqlDataReader reader = command.ExecuteReader();

                        // SELECT文の場合は結果を表示する

                        
                        while (reader.Read())
                        {
                            
                            LostReservationModel m = new LostReservationModel();
                            m.LostId = (int)reader["items_Id"];
                            int userid = (int)reader["user_number"];
                            m.name = userlist[userid - 1].name;
                           




                            result.Add(m);

                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {

                Console.WriteLine("");
                Console.WriteLine("---------------End---------------");
            }



            return result;
        }

    }



}
