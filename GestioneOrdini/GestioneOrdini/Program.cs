using GestioneOrdini;

namespace GestioneOrdini
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<Order> elenco = new List<Order>(); // Elenco di ordini
            bool fileLetto = false;
            OrdersController ctrl = new OrdersController();
            string input;

            while (!fileLetto) // Ciclo per chiedere all'utente il percorso finchè non ne da uno valido
            {
                Console.Write("Inserire il percorso del file csv da cui leggere:");
                input = Console.ReadLine(); // Percorso del file CSV
                elenco = ctrl.GetOrders(input);
                if (elenco.Count > 0)
                    fileLetto = true;
                foreach (Order o in elenco) 
                    Console.WriteLine(o);
            }

           

            /*
                try
                {
                    // Lettura del file CSV
                    using (StreamReader sr = new StreamReader(input))
                    {
                        string riga = sr.ReadLine(); // Legge l'intestazione (prima riga)

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

                            // Aggiunta dell'oggetto all'elenco
                            elenco.Add(ordine);

                            Console.WriteLine(ordine);

                        }
                    }

                    OrdersController ctrl = new OrdersController();

                    // Record con importo totale più alto (per importo totale sto considerando prezzoScontato*quantita)
                    Console.WriteLine($"\nRecord con importo totale più alto: {ctrl.MaxPrice(elenco)}");

                    // Record con quantità più alta
                    Console.WriteLine($"\nRecord con quantità più alta: {ctrl.MaxQuantity(elenco)}");

                    // Record con maggior differenza tra totale senza sconto e totale con sconto
                    Console.WriteLine($"\nRecord con maggior differenza tra totale senza sconto e totale con sconto: {ctrl.MaxPriceDiff(elenco)}");

                    fileLetto = true;

                    foreach (var article in elenco)
                    {
                        //Console.WriteLine(article.Price);
                        //Console.WriteLine(article.DiscountPrice());
                        //Console.WriteLine(article.TotalPrice());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore durante la lettura del file: {ex.Message}");
                }
            */
        }
    }
}
