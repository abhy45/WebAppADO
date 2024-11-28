using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppADO.BAL;
using WebAppADO.DAL;
using WebAppADO.Models;

namespace WebAppADO.Controllers
{
    public class ToDoController : Controller
    {
        DALAccess DALAccess = new DALAccess();
        BALAccess BALAccess = new BALAccess();
        public ActionResult Index()
        {
            List<ToDoModel> Todolist = new List<ToDoModel>();
           // Todolist = BALAccess.GetToDoDetails();
            Todolist = DALAccess.GetAllStudent();
            return View(Todolist);
        }
      



    }
}
