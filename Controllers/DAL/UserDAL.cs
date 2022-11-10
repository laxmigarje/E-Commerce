using E_Commerce.Models;
using ecom.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ecom.DAL
{
    public class UserDAL
    {


        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public UserDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string constr = configuration["ConnectionStrings:defaultConnection"];
            
            con = new SqlConnection(constr);
        }
        public int UserRegister(User user)
            {
                string qry = "insert into UserInformation values(@name,@email,@contact,@pass,@roleid)";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@name", user.Name);
                cmd.Parameters.AddWithValue("@email", user.Email);
                 cmd.Parameters.AddWithValue("@contact", user.Contact);
                cmd.Parameters.AddWithValue("@pass", user.Password);
            cmd.Parameters.AddWithValue("@roleid", 2);
                con.Open();
                int res = cmd.ExecuteNonQuery();
                con.Close();
                return res;

            }
            public User UserLogin(User user)
            {
                User users = new User();
                string qry = "select * from UserInformation where Email=@email";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("email", user.Email);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        user.UserId = Convert.ToInt32(dr["UserId"]);
                        user.Name = dr["Name"].ToString();
                       user.Email = dr["Email"].ToString();
                    user.Contact = dr["Contact"].ToString();
                        user.Password = dr["Password"].ToString();
                    }
                    con.Close();
                    return user;

                }
                else
                {
                    return user;
                }
            }
        }
    }
        /*SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public UserDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string constr = configuration["ConnectionStrings:defaultConnection"];
            con = new SqlConnection(constr);
        }
        public List<User> GetAllUser()
        {
            List<User> userlist = new List<User>();
            String qry = "select * from Users";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    User user = new User();
                    user.Id = Convert.ToInt32(dr["id"]);//Id name same as per table in db
                    user.Name = dr["name"].ToString();
                    user.City = dr["city"].ToString();
                    user.Mob = Convert.ToInt32(dr["mob"]);
                    user.Email = dr["email"].ToString();
                    user.Password = dr["password"].ToString();
                    userlist.Add(user);

                }
            }
            con.Close();
            return userlist;
        }

        public User GetUserById(int id)
        {
            User user = new User();
            String qry = "select * from Users where Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    user.Id = Convert.ToInt32(dr["id"]);
                    user.Name = dr["name"].ToString();
                    user.City = dr["city"].ToString();
                    user.Mob = Convert.ToInt32(dr["mob"]);
                    user.Email = dr["email"].ToString();
                    user.Password = dr["password"].ToString();
                }
            }
            con.Close();
            return user;

        }

        public int AddUser(User user)
        {
            string qry = "insert into users values(@name,@city,@Mob,@Email,@password)";
            cmd = new SqlCommand(qry, con);
            //   cmd.Parameters.AddWithValue("@id", emp.Id);
            cmd.Parameters.AddWithValue("@name", user.Name);
            cmd.Parameters.AddWithValue("@city", user.City);
            cmd.Parameters.AddWithValue("@mob", user.Mob);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@password", user.Password);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
        public int UpdateEmployee(User user)
        {
            string qry = "update users set Name=@name,City=@city,Mob=@mob,Email=@email,Password=@password where Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", user.Id);
            cmd.Parameters.AddWithValue("@name", user.Name);
            cmd.Parameters.AddWithValue("@city", user.City);
            cmd.Parameters.AddWithValue("@mob", user.Mob);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@password", user.Password);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int DeleteUser(int id)
        {
            string qry = "delete from users where Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int res = cmd.ExecuteNonQuery();*/