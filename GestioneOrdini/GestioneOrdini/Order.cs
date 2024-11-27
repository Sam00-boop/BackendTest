using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneOrdini
{
    internal class Order
    {

        public long Id { get; set; }
        public string Article {  get; set; }
        public long Quantity { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public string Buyer { get; set; }

        // Metodo che torna il prezzo dell'articolo con lo sconto applicato
        public double DiscountPrice()
        {
            return Price-Price*Discount/100; 
        }

        // Metodo che calcola il prezzo dell'intero ordine
        public double TotalPrice()
        {
            return Quantity * DiscountPrice();
        }

        // Metodo che calcola la differenza tra il prezzo originale e quello scontato
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
