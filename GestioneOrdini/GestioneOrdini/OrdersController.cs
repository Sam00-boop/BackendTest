using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestioneOrdini
{
    internal class OrdersController
    {
        public List<Order> GetOrders(string path) 
        {
            List<Order> orders = new List<Order>();

            try
            {
                // Controlla se il file esiste
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException("Il file specificato non è stato trovato.");
                }

                // Legge il file riga per riga
                using (StreamReader sr = new StreamReader(path))
                {
                    string riga = sr.ReadLine();
                    while ((riga = sr.ReadLine()) != null)
                    {
                        // Separa la riga corrente in un array
                        string[] dati = riga.Split(",");

                        // Creazione e inizializzazione dell'oggetto order 
                        var ordine = new Order
                        {
                            Id = long.Parse(dati[0]),
                            Article = dati[1],
                            Quantity = long.Parse(dati[2]),
                            Price = double.Parse(dati[3]),
                            Discount = double.Parse(dati[4]),
                            Buyer = dati[5]
                        };

                        orders.Add(ordine);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Errore: Accesso al file negato. {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }

            return orders;
        }


        public Order MaxPrice(List<Order> orders)
        {
            return orders.OrderByDescending(a => a.TotalPrice()).First();
        }

        public Order MaxQuantity(List<Order> orders)
        {
            return orders.OrderByDescending(a => a.Quantity).First();
        }

        public Order MaxPriceDiff(List<Order> orders)
        {
            return orders.OrderByDescending(a => a.PriceDifference()).First();
        }
    }
}
