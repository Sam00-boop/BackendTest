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
                    string line = sr.ReadLine();// Salta la prima riga (intestazione)

                    while ((line = sr.ReadLine()) != null)
                    {
                        // Separa la riga corrente in un array
                        string[] dati = line.Split(",");

                        // Controlla che la riga abbia il numero corretto di colonne
                        if (dati.Length != 6)
                        {
                            Console.WriteLine($"Riga ignorata: formato non valido ({line}).");
                            continue;
                        }

                        // Prova a convertire i dati e controlla la validità dei dati numerici
                        if (!long.TryParse(dati[0], out var id) ||
                            !long.TryParse(dati[2], out var quantity) ||
                            !double.TryParse(dati[3], out var price) ||
                            !double.TryParse(dati[4], out var discount))
                        {
                            Console.WriteLine($"Riga ignorata: dati non validi ({line}).");
                            continue;
                        }

                        // Creazione e aggiunta dell'ordine
                        var ordine = new Order
                        {
                            Id = id,
                            Article = dati[1],
                            Quantity = quantity,
                            Price = price,
                            Discount = discount,
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
