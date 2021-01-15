using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using XamarinWebApi.Models;


namespace XamarinWebApi.Controllers
{
    public class MastersController : ApiController
    {
        SqlConnection conn;
        private void connection()
        {
            string conString = ConfigurationManager.ConnectionStrings["getConnection"].ToString();
            conn = new SqlConnection(conString);
        }

       /* [Route("api/Masters/selectClass")]
        [HttpGet]
        public IHttpActionResult LayClass(string ID_Class)
        {
            Dictionary<string, Object> param = new Dictionary<string, object>();
            param.Add("ID_Class ", ID_Class);
            DataTable tb = Database.dbStudentClass(" ID_Class", param);

        }*/
        public IEnumerable<Student> GetStudent(string ID_Class)
        {

            List<Student> studentData = new List<Student>();

            string conString = ConfigurationManager.ConnectionStrings["getConnection"].ToString();
            conn = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand("dbStudentClass", conn);
            //SqlCommand cmd = new SqlCommand("spStudent1", conn);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.AddWithValue("@ID_Class", ID_Class);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Student student = new Student();
                student.Id = Convert.ToInt32(reader["Id"]);
                student.Name = reader["Name"].ToString();
                student.Address = reader["Address"].ToString();
                student.PhoneNumber = reader["PhoneNumber"].ToString();
                student.Gender = reader["Gender"].ToString();
                student.ID_Class = reader["ID_Class"].ToString();
                student.RegisterDay = reader["RegisterDay"].ToString();
                student.Birthday = reader["Birthday"].ToString();


                studentData.Add(student);
            }
            conn.Close();
            return studentData;
        }
        public Response SaveStudent(Student student)
        {
            Response response = new Response();
            try
            {
                if (string.IsNullOrEmpty(student.Name))
                {
                    response.Message = "Sudent name is mandatory";
                    response.Status = 0;
                }
                else if (string.IsNullOrEmpty(student.Address))
                {
                    response.Message = "Student address is mandatory";
                    response.Status = 0;
                }
                else if (string.IsNullOrEmpty(student.PhoneNumber))
                {
                    response.Message = "Student phone number is mandatory";
                    response.Status = 0;
                }
                else
                {
                    connection();
                    SqlCommand com = new SqlCommand("dbAddStudent", conn);
                    com.CommandType = CommandType.StoredProcedure;

                    com.Parameters.AddWithValue("@Id", student.Id);
                    com.Parameters.AddWithValue("@Name", student.Name);
                    com.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);
                    com.Parameters.AddWithValue("@Address", student.Address);
                    com.Parameters.AddWithValue("@ID_class", student.ID_Class);
                    com.Parameters.AddWithValue("@Birthday", student.Birthday);
                    com.Parameters.AddWithValue("@RegisterDay", student.RegisterDay);
                    com.Parameters.AddWithValue("@Gender", student.Gender);

                    conn.Open();
                    int i = com.ExecuteNonQuery();
                    conn.Close();
                    if (i >= 1)
                    {
                        response.Message = "Employee Saved Successfully";
                        response.Status = 1;
                    }
                    else
                    {
                        response.Message = "Employee faild To Save";
                        response.Status = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = 0;
            }
            return response;
        }
        public Response DeleteStudent(int StudentId)
        {
            Response response = new Response();
            try
            {
                connection();
                SqlCommand com = new SqlCommand("dbDeleteStudent", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@StudentId", StudentId);
                conn.Open();
                int i = com.ExecuteNonQuery();
                conn.Close();
                if (i >= 1)
                {
                    response.Message = "Employee Deleted Successfully";
                    response.Status = 1;
                }
                else
                {
                    response.Message = "Employee faild To Delete";
                    response.Status = 0;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = 0;
            }
            return response;
        }
       
        public IEnumerable<ClassStudent> GetClass()
        {

            List<ClassStudent> LoginData = new List<ClassStudent>();

            string conString = ConfigurationManager.ConnectionStrings["getConnection"].ToString();
            conn = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand("spCLASS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ClassStudent classStudent = new ClassStudent();


                classStudent.ID_CLass = reader["ID_CLass"].ToString();
                classStudent.NameClass = reader["NameClass"].ToString();
                classStudent.StartDay = reader["StartDay"].ToString();
                classStudent.LeavingDay = reader["LeavingDay"].ToString();
                classStudent.Image = reader["IMAGE"].ToString();
                LoginData.Add(classStudent);
            }
            conn.Close();
            return LoginData;
        }
        


        public IEnumerable<Thongbao> GetThongbao()
        {

            List<Thongbao> ThongbaoData = new List<Thongbao>();

            string conString = ConfigurationManager.ConnectionStrings["getConnection"].ToString();
            conn = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand("spThongbao", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Thongbao thongbao = new Thongbao();
                thongbao.Id_thongbao = Convert.ToInt32(reader["ID_Thongbao"]);
                thongbao.Tieude = reader["Tieude"].ToString();
                thongbao.Noidung = reader["Noidung"].ToString();
                thongbao.Time = reader.GetFieldValue<DateTime>(reader.GetOrdinal("getDate"));
                ThongbaoData.Add(thongbao);
            }
            conn.Close();
            return ThongbaoData;
        }

        public Response SaveThongbao(Thongbao thongbao)
        {
            Response response = new Response();
            try
            {
                if (string.IsNullOrEmpty(thongbao.Tieude))
                {

                    response.Status = 0;
                }
                else if (string.IsNullOrEmpty(thongbao.Noidung))
                {

                    response.Status = 0;
                }
                else
                {
                    connection();
                    SqlCommand com = new SqlCommand("dbAddDateTime", conn);
                    com.CommandType = CommandType.StoredProcedure;

                    com.Parameters.AddWithValue("@Id", thongbao.Id_thongbao);
                    com.Parameters.AddWithValue("@Tieude", thongbao.Tieude);
                    com.Parameters.AddWithValue("@Noidung", thongbao.Noidung);
                 
                    conn.Open();
                    int i = com.ExecuteNonQuery();
                    conn.Close();
                    if (i >= 1)
                    {
                        
                        response.Status = 1;
                    }
                    else
                    {
                       
                        response.Status = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = 0;
            }
            return response;
        }
        

    }
}
