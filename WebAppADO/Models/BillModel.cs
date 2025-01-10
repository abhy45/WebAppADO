namespace WebAppADO.Models
{
    public class BillModel
    {
        public ProductModel AddProd { get; set; }
        public int id { get; set; } 
        public string BillCode { get; set; } 
        public DateTime BillDates { get; set; } 
    }
}

