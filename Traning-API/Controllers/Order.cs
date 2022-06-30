using System;

namespace Traning_API.Controllers
{
    public class Order
    {
        public string Name_Product{ get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public User User { get; set; }
    }
}
