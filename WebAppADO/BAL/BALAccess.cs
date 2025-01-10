using System.Data;
using WebAppADO.Models;
using WebAppADO.DAL;
using System.Data.SqlClient;


namespace WebAppADO.BAL
{
    public class BALAccess
    {
        DALAccess dalobj = new DALAccess();

        public List<ToDoModel> GetToDoDetails()
        {
            DataSet ds = dalobj.GetToDoList();
            List<ToDoModel> lstData = new List<ToDoModel>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                ToDoModel objmodel = new ToDoModel();
                objmodel.Id = Convert.ToInt32(item["Id"]);
                objmodel.Tasks = Convert.ToString(item["Task"]);
                objmodel.CreatedDate = Convert.ToDateTime(item["CreatedDate"]);
               

                lstData.Add(objmodel);
            }

            return lstData;
        }

        public int  SaveBillAndProduct(string billCode, DateTime billDates, int id)
        {
            int idaa = 0;
            string querry = "insert into tbl_bill (Billcode,BillDate,id)values('"+ billCode + "','"+ billDates + "',"+id+");SELECT SCOPE_IDENTITY();";

            using (SqlConnection cnn = new SqlConnection(SqlHelper.ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(querry,cnn))
                {
                    //int NoOfRowAffect = cmd.ExecuteNonQuery();

                    var result = cmd.ExecuteScalar();

                    // Return the inserted id, converting it to an integer

                    idaa =  Convert.ToInt32(result);
                }
            }
            return idaa;

        }

        public int SaveProduct(int Billid ,string producname , int Qty ,double price)
        {
           int  NowRowEffect = 0;
            using (SqlConnection con = new SqlConnection(SqlHelper.ConnectionString))
            {
                con.Open();
                string querry = "insert into tbl_product (Ref_BillId,Product,Quantity,price) values(@Billid,@productname,@Qty,@Price)";
                using (SqlCommand cmd = new SqlCommand(querry,con))
                {
                    cmd.Parameters.AddWithValue("@Billid",Billid);
                    cmd.Parameters.AddWithValue("@productname", producname);
                    cmd.Parameters.AddWithValue("@Qty",Qty);
                    cmd.Parameters.AddWithValue("@Price",price);
                    NowRowEffect = cmd.ExecuteNonQuery();
                   
                }
            }
            return NowRowEffect;
        }





    }
}
