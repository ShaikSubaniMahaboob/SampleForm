using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using SampleForm.Models;
using System.Runtime.CompilerServices;
using SampleForm.DBContext;
using System.Reflection;

namespace SampleForm
{
    public class Repository
    {
        private readonly DBConnection dBContext;
        public Repository(DBConnection dBConnection)
        {
            this.dBContext = dBConnection;
        }

        public int AddCrfeateForm(CreateForm createform)

        {
            try
            {
                SqlConnection con = new SqlConnection();
                con = dBContext.getSqlConnection();

                SqlCommand cmd = new SqlCommand("spAddStudent", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", createform.ID);
                cmd.Parameters.AddWithValue("@Name", createform.Name);
                cmd.Parameters.AddWithValue("@Gender", createform.Gender);
                cmd.Parameters.AddWithValue("@Skills", createform.Skills);
                cmd.Parameters.AddWithValue("@Description", createform.Description);
                cmd.Parameters.AddWithValue("@isverify", createform.Isverify);

                int i = cmd.ExecuteNonQuery();
                con.Close();
                return i;
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }

        public CreateForm GetDataById(int id)
        {
            try
            {
                CreateForm objcreateForm = new CreateForm();



                SqlConnection con1 = new SqlConnection();
                con1 = dBContext.getSqlConnection();
                //string sqlQuery = "SELECT * FROM GetDataById";

                SqlCommand cmd = new SqlCommand("GetDataById", con1);
                con1.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {


                    objcreateForm.ID = Convert.ToInt32(rdr["ID"]);
                    objcreateForm.Name = Convert.ToString(rdr["Name"]);
                    objcreateForm.Gender = Convert.ToString(rdr["Gender"]);
                    objcreateForm.Skills = Convert.ToInt32(rdr["Skills"]);
                    objcreateForm.Description = Convert.ToString(rdr["Description"]);
                    objcreateForm.Isverify = Convert.ToString(rdr["isverify"]);
                   

                }
                return objcreateForm;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<CreateForm> GetCreateForm()
        {


            try
            {
                List<CreateForm> objcreateForm = new List<CreateForm>();



                SqlConnection con1 = new SqlConnection();
                con1 = dBContext.getSqlConnection();
                string sqlQuery = "SELECT * FROM CreateForm";
                SqlCommand cmd = new SqlCommand(sqlQuery, con1);
                con1.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    objcreateForm.Add(new CreateForm
                    {
                        ID = Convert.ToInt32(rdr["ID"]),
                        Name = Convert.ToString(rdr["Name"]),
                        Gender = Convert.ToString(rdr["Gender"]),
                        Skills = Convert.ToInt32(rdr["Skills"]),
                        Description = Convert.ToString(rdr["Description"]),
                        Isverify = Convert.ToString(rdr["isverify"])
                    });

                }
                return objcreateForm;
            }
            catch (Exception ex)
            {

                throw ex;
            }


         
        }



        public void spUpdateCreateForm(CreateForm createform)

        {

            try
            {
                SqlConnection con2 = new SqlConnection();
                con2 = dBContext.getSqlConnection();

                SqlCommand cmd = new SqlCommand("spUpdateCreateForm", con2);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", createform.Name);
                cmd.Parameters.AddWithValue("@Gender", createform.Gender);
                cmd.Parameters.AddWithValue("@Skills", createform.Skills);
                cmd.Parameters.AddWithValue("@Description", createform.Description);
                cmd.Parameters.AddWithValue("@isverify", createform.Isverify);
                con2.Open();
                cmd.ExecuteNonQuery();
                con2.Close();
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void spDeleteCreateForm(int? id)
        {
            SqlConnection con3 = new SqlConnection();
            con3 = dBContext.getSqlConnection();
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spDeleteCreateForm", con3);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    con3.Open();
                    cmd.ExecuteNonQuery();
                    con3.Close();
                }
                
             catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
}


