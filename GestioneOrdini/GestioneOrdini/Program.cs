using BackendTest;

namespace GestioneOrdini
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Percorso del file CSV
            Console.Write("Inserire il percorso del file csv da cui leggere:");
            string input = Console.ReadLine();
            //string path = @"..\..\..\files\file.csv";

            // Elenco di articoli
            List<Order> elenco = new List<Order>();


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

                // Record con importo totale più alto (per importo totale sto considerando prezzoScontato*quantita)
                var maxTotalArticle = elenco.OrderByDescending(a => a.TotalPrice()).First();
                Console.WriteLine($"Record con importo totale più alto: {maxTotalArticle}");

                // Record con quantità più alta
                maxTotalArticle = elenco.OrderByDescending(a => a.Quantity).First();
                Console.WriteLine($"Record con quantità più alta: {maxTotalArticle}");

                // Record con maggior differenza tra totale senza sconto e totale con sconto
                maxTotalArticle = elenco.OrderByDescending(a => a.PriceDifference()).First();
                Console.WriteLine($"Record con maggior differenza tra totale senza sconto e totale con sconto: {maxTotalArticle}");

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
        }
    }
}
