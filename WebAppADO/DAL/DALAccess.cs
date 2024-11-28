using System.Data;
using WebAppADO.Models;
using System.Data.SqlClient;

namespace WebAppADO.DAL
{
    public class DALAccess
    {
        public List<ToDoModel> GetAllStudent()
        {
            List<ToDoModel> lstStudent = new List<ToDoModel>();
            using (SqlConnection con = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_GetToDiList", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ToDoModel student = new ToDoModel();
                    student.Id = Convert.ToInt32(rdr["Id"]);
                    student.Tasks = rdr["Task"].ToString();
                    student.CreatedDate = Convert.ToDateTime( rdr["CreatedDate"]); 
                    lstStudent.Add(student);
                }
                con.Close();
            }
            return lstStudent;
        }

        public DataSet GetToDoList()
        {
            try
            {
                return SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, System.Data.CommandType.StoredProcedure, "[dbo].[usp_GetToDiList]");
            }
            catch (Exception err)
            {
                throw err;
            }
        }



    }
}
