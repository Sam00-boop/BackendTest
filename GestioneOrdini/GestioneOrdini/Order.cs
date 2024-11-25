using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTest
{
    internal class Order
    {

        public long Id { get; set; }
        public string Article {  get; set; }
        public long Quantity { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public string Buyer { get; set; }

        public double DiscountPrice()
        {
            return Price-Price*Discount/100; 
        }

        public double TotalPrice()
        {
            return Quantity * DiscountPrice();
        }

        public double PriceDifference()
        {
            return Price - DiscountPrice();
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Article)}={Article}, {nameof(Quantity)}={Quantity.ToString()}, {nameof(Price)}={Price.ToString()}, {nameof(Discount)}={Discount.ToString()}, {nameof(Buyer)}={Buyer}}}";
        }
    }
}
