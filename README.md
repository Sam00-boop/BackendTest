# GestioneOrdini
L'applicazione permette la lettura di un elenco di ordini salvato su un file csv. Il programma richiede il percorso del file da leggere e ritorna all'utente tre record:
- l'ordine con importo più alto, considerando come importo il prezzo dell'articolo con lo sconto applicato moltiplicato per la quantità;
- l'ordine con quantità maggiore;
- l'ordine con maggiore differenza tra prezzo originale e scontato.

Per il testing è presente un file di prova nella cartella files, per usarlo basta incollare questo percorso: ` ..\..\..\files\file.csv `.  
L'applicazione è stata sviluppata con un paradigma a oggetti, con suddivisione del codice tra le classi Program, Order e OrderController.

## Order
Il modello per l'ordine, contiene le proprietà corrispondenti alle colonne del csv e quattro metodi:
- **DiscountPrice**: calcola il prezzo scontato del singolo articolo
- **TotalPrice**: calcola il prezzo totale dell'ordine
- **PriceDifference**: calcola la differenza tra importo iniziale e prezzo scontato
- **ToString**: ritorna una stringa con le proprietà dell'oggetto
## OrderController
Contiene i metodi che costituiscono la logica del programma:
- **GetOrders**: prende come argomento il path del file come stringa e restituisce una lista di oggetti di classe *Orders*. Il codice è inserito in una struttura di controllo (try catch) per gestire eccezioni come un path non valido o l'assenza di autorizzazioni per la lettura. Il file viene letto una riga alla volta usando un'istanza di *StreamReader* e la riga corrente viene suddivisa nei singoli campi dentro un array. Per ogni riga viene controllato che il numero di campi sia quello atteso e che i campi numerici contengano effettivamente dei numeri (le righe non valide vengono ignorate). I dati della riga vengono quindi usati per istanziare un nuovo ordine che viene aggiunto alla lista di ordini.
- **MaxPrice**: riceve una lista di ordini e ritorna quello con il prezzo totale più alto. Usa LINQ per ritornare il primo elemento della lista ordinata per il metodo TotalPrice.
- **MaxQuantity**: riceve una lista di ordini e ritorna quello con la quantità maggiore. Usa LINQ come prima ma ordinando per la proprietà Quantity.
- **MaxPriceDiff**: riceve una lista di ordini e ritorna quello con la maggiore differenza tra prezzo originale e scontato. Usa LINQ come prima ma ordinando per il metodo PriceDifference.

## Program
Costituisce il main dell'applicazione, fornisce le funzioni all'utente richiamando i metodi del controller.  
Inizia dichiarando una lista vuota di Orders e un controller.
Chiede il path all'utente all'interno di un ciclo, così da continuare a chiederlo finchè non ne viene inserito uno valido. 
Stampa i tre record richiesti richiamando i rispettivi metodi.
