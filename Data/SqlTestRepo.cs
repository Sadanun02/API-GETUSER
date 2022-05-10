
using System.Data;
using Microsoft.Data.SqlClient;
using TodoApi.Models;



namespace TodoApi.Data
{
    public class SqlTestRepo : ITestRepo
    {
        private readonly ConnectionString _context;

        public SqlTestRepo(ConnectionString context)
        {
            _context = context;
        }

        public IEnumerable<UserItem> GetUsers()
        {
            List<UserItem> UsersModel = new List<UserItem>();

            var conn = new SqlConnection(_context.Value);
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "select top(10)  id,full_name,name,emp_num from man.users ";

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UserItem _usersID = new UserItem();
                        if (!(reader["id"] is DBNull)) _usersID.Id = Convert.ToInt32(reader["id"].ToString());
                        if (!(reader["full_Name"] is DBNull)) _usersID.Full_name = reader["full_Name"].ToString();
                        if (!(reader["name"] is DBNull)) _usersID.Name = reader["name"].ToString();
                        if (!(reader["emp_num"] is DBNull)) _usersID.Emp_Num = reader["emp_num"].ToString();

                        UsersModel.Add(_usersID);
                    }

                    conn.Close();
                }

                return UsersModel;
            }
        }

        public IEnumerable<UserItem> GetUsers(string id)
        {
            List<UserItem> UsersModel = new List<UserItem>();

            var conn = new SqlConnection(_context.Value);
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "select top(10)  id,full_name,name,emp_num from man.users (NOLOCK) WHERE id = " + id;

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UserItem _usersID = new UserItem();
                        if (!(reader["id"] is DBNull)) _usersID.Id = Convert.ToInt32(reader["id"].ToString());
                        if (!(reader["full_Name"] is DBNull)) _usersID.Full_name = reader["full_Name"].ToString();
                        if (!(reader["name"] is DBNull)) _usersID.Name = reader["name"].ToString();
                        if (!(reader["emp_num"] is DBNull)) _usersID.Emp_Num = reader["emp_num"].ToString();

                        UsersModel.Add(_usersID);
                    }

                    conn.Close();
                }

                return UsersModel;
            }
        }

        // public bool AddUsersDetails(int id, string full_name, string name, string englist_name, string emp_num, string default_language, string mail_address, string emp_code1, string password)
        public bool AddUsersDetails(AddUser _object)
        {
            var conn = new SqlConnection(_context.Value);
            conn.Open();

            using (var cmd = conn.CreateCommand())
            {

                int id = 0;

                cmd.CommandText = @"SELECT ISNULL(MAX(id),0)+ 1 AS id  FROM man.users (NOLOCK)";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader["id"].ToString());
                    }
                }

                using (var cmd2 = conn.CreateCommand())
                {

                   string sql = @"INSERT INTO man.users
                            (
                              id
                            , full_name
                            , name
                            , english_name
                            , emp_num
                            , default_language
                            , mail_address
                            , emp_code1
                            , password
                            , created_at
                            , created_by
                            , updated_at
                            , updated_by
                             )
                            VALUES 
                            (
                              @id
                            , @full_name
                            , @name
                            , @english_name
                            , @emp_num
                            , @default_language
                            , @mail_address
                            , @emp_code1
                            , @password
                            , @created_at
                            , @created_by
                            , @updated_at
                            , @updated_by
                            )";
                        SqlCommand AddUser = new SqlCommand(sql, conn);
                        AddUser.CommandType = CommandType.Text;
                        AddUser.Parameters.AddWithValue("@id", id);
                        AddUser.Parameters.AddWithValue("@full_name", _object.full_name);
                        AddUser.Parameters.AddWithValue("@name", _object.name);
                        AddUser.Parameters.AddWithValue("@english_name", _object.english_name);
                        AddUser.Parameters.AddWithValue("@emp_num", _object.emp_num);
                        AddUser.Parameters.AddWithValue("@default_language", _object.Default_Language);
                        AddUser.Parameters.AddWithValue("@mail_address", _object.mail_address);
                        AddUser.Parameters.AddWithValue("@emp_code1", _object.emp_code1);
                        AddUser.Parameters.AddWithValue("@password", _object.password);
                        AddUser.Parameters.AddWithValue("@created_at", DateTime.Now);
                        AddUser.Parameters.AddWithValue("@created_by", 1);
                        AddUser.Parameters.AddWithValue("@updated_at", DateTime.Now);
                        AddUser.Parameters.AddWithValue("@updated_by", 1);

                        int i = AddUser.ExecuteNonQuery();

                        if (i >= 1)
                            return true;
                        else
                            return false;
                     
                }
            }
        }



        public IEnumerable<UserItem> GetUserDetails()
        {
            List<UserItem> UsersModel = new List<UserItem>();

            var conn = new SqlConnection(_context.Value);
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "select top(10)  id,full_name,name,emp_num from man.users ";
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UserItem _usersID = new UserItem();
                        if (!(reader["id"] is DBNull)) _usersID.Id = Convert.ToInt32(reader["id"].ToString());
                        if (!(reader["full_Name"] is DBNull)) _usersID.Full_name = reader["full_Name"].ToString();
                        if (!(reader["name"] is DBNull)) _usersID.Name = reader["name"].ToString();
                        if (!(reader["emp_num"] is DBNull)) _usersID.Emp_Num = reader["emp_num"].ToString();

                        UsersModel.Add(_usersID);
                    }

                    conn.Close();
                }

                return UsersModel;
            }
        }

        public IEnumerable<UserItem> GetUserDetails(string id)
        {
            List<UserItem> lstusers = new List<UserItem>();

            var conn = new SqlConnection(_context.Value);
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "select top(10)  id,full_name,name,emp_num from man.users WHERE id = " + id;

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UserItem Users = new UserItem();

                        if (!(reader["id"] is DBNull)) Users.Id = Convert.ToInt32(reader["id"].ToString());
                        if (!(reader["full_Name"] is DBNull)) Users.Full_name = reader["full_Name"].ToString();
                        if (!(reader["name"] is DBNull)) Users.Name = reader["name"].ToString();
                        if (!(reader["emp_num"] is DBNull)) Users.Emp_Num = reader["emp_num"].ToString();

                        lstusers.Add(Users);
                    }
                    conn.Close();
                }
                return lstusers;
            }
        }
    }
}