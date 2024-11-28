using System.Data;
using WebAppADO.Models;
using WebAppADO.DAL;

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
    }
}
