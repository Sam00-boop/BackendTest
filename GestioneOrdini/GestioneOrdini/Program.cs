using GestioneOrdini;

namespace GestioneOrdini
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<Order> orders = new List<Order>(); // Elenco di ordini
            OrdersController ctrl = new OrdersController();
            string input; // Percorso del file CSV: ..\..\..\files\file.csv

            while (orders.Count == 0) // Ciclo per chiedere all'utente il percorso finchè non ne da uno valido
            {
                Console.Write("Inserire il percorso del file csv da cui leggere:"); 
                input = Console.ReadLine(); 
                orders = ctrl.GetOrders(input);
                foreach (Order o in orders) 
                    Console.WriteLine(o);
            }

            // Record con importo totale più alto (per importo totale sto considerando prezzoScontato*quantita)
            Console.WriteLine($"\nRecord con importo totale più alto: \n{ctrl.MaxPrice(orders)}\n");

            // Record con quantità più alta
            Console.WriteLine($"\nRecord con quantità più alta: \n{ctrl.MaxQuantity(orders)}\n");

            // Record con maggior differenza tra totale senza sconto e totale con sconto
            Console.WriteLine($"\nRecord con maggior differenza tra totale senza sconto e totale con sconto: \n{ctrl.MaxPriceDiff(orders)}\n");

        }
    }
}
