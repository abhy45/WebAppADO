using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAppADO.BAL;
using WebAppADO.DAL;
using WebAppADO.Models;

namespace WebAppADO.Controllers
{
    public class BillController : Controller
    {
        DALAccess DALAccess = new DALAccess();
        BALAccess BALAccess = new BALAccess();
        public IActionResult create()
        {

            return View();
        }

        public IActionResult Save(BillModel model, string ProductData)
        {
            var products = JsonConvert.DeserializeObject<List<ProductModel>>(ProductData);

            int BillTablid = BALAccess.SaveBillAndProduct(model.BillCode,model.BillDates,model.id);

            foreach (ProductModel proditem in products)
            {
                int aa = BALAccess.SaveProduct(BillTablid,proditem.ProductName,proditem.Qty,proditem.Price);
            }
            return RedirectToAction("create");
        }
    }
}
