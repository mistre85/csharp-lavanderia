


using ConsoleTables;
using csharp_lavanderia.Exceptions;
using System.Linq.Expressions;


bool run = true; //cicol di vita del programma. se vero il programma continua altrimenti si ferma

string ultimoMessaggioSistema = "Seleziona un comando per procedere"; //ultimo messaggio del sistema, contiene informazioni o errori sull'ultima operazione effettuata dall'utente

string comandoUtente = ""; //contiene il comando scelto dall'utente. 

string[] comando; //contiene il comando codificato per uso interno del programma


//oggetto generale di simulazione della lavanderia
Lavanderia lavanderia = new Lavanderia();

//ciclo del programma
while (run)
{
    Console.Clear();

    Console.WriteLine(" Terminale controllo lavanderia v1.0");
    Console.WriteLine();


    //blocco di controllo semplice per gestire gli errori e avvisare l'utente
    try
    {
        lavanderia.StampStato();

        Console.WriteLine();
        Console.WriteLine(" " + ultimoMessaggioSistema);
        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine(" apri <numero_macchina> | Apre lo sportello della macchina");
        Console.WriteLine(" chiudi <numero_macchina> | Chiude lo sportello della macchina");
        Console.WriteLine(" gettoni <numero_macchina> <numero_gettoni> | inserisce i gettoni spcificati nella macchina specificata");
        Console.WriteLine(" lista <numero_macchina> | visualizza l'elenco dei programmi della macchina specificata");
        Console.WriteLine(" programma <numero_macchina> <numero_programma> | imposta il programma indicato nella macchina indicata");
        Console.WriteLine(" avvia <numero_macchina> | avvia la macchina indicata");
        Console.WriteLine(" ferma <numero_macchina> | ferma la macchina indicata");
        Console.WriteLine(" detersivo <numero_macchina> <quantità> | avvia la macchina indicata");
        Console.WriteLine(" ammorbidente <numero_macchina> <quantità> | avvia la macchina indicata");
        Console.WriteLine(" esci | termina il programma");
        Console.WriteLine();
        Console.Write(" >");

        //stringa originale dell'utente
        comandoUtente = Console.ReadLine();

      
        //parso il comando per identificare i parametri
        comando = comandoUtente.Split(" ");


        string cmd = "";
        int numero_macchina = -1; //numero della macchina specificato nel comando
        int parametro_aggiuntivo = -1; //numero del programma o numero dei gettoni in base ai comandi

        //per semplicità gestiamo questo errore
        //con il try catch su indexout of range
        cmd = comando[0];


        //controllo che l'utente abbia specificato il primo parametro
        if (comando.Length >= 2)
            numero_macchina = Convert.ToInt32(comando[1]);

        //controllo che l'utente abbia specificato il secondo parametro
        if (comando.Length >= 3)
            parametro_aggiuntivo = Convert.ToInt32(comando[2]);

        switch (cmd)
        {

            case "apri":

                lavanderia.GetMacchina(numero_macchina).Apri();
                ultimoMessaggioSistema = "Macchina aperta correttamente.";

                break;

            case "chiudi":

                lavanderia.GetMacchina(numero_macchina).Chiudi();
                ultimoMessaggioSistema = "Macchina chiusa correttamente.";

                break;

            case "gettoni":

                lavanderia.GetMacchina(numero_macchina).InserisciGettoni(parametro_aggiuntivo);
                ultimoMessaggioSistema = "Gettorni inseriti correttamente.";

                break;

            case "lista":

                ultimoMessaggioSistema = "Lista programmi macchina" + numero_macchina + Environment.NewLine;
                ultimoMessaggioSistema += lavanderia.GetMacchina(numero_macchina).TabellaProgrammiToString();

                break;

            case "programma":

                lavanderia.GetMacchina(numero_macchina).SelezionaProgramma(parametro_aggiuntivo);
                ultimoMessaggioSistema = "Programma selezionato correttamente";

                break;
            case "avvia":

                lavanderia.GetMacchina(numero_macchina).Avvia();
                ultimoMessaggioSistema = "Macchina " + numero_macchina + " avviata!";

                break;
            case "ferma":

                lavanderia.GetMacchina(numero_macchina).Ferma();
                ultimoMessaggioSistema = "Macchina " + numero_macchina + " fermata!";

                break;

            case "detersivo":

                //qui potrei avere errore di conversione, per semplicità gestiamo con eccezione nativa InvalidCastException
                Lavatrice lavatrice = (Lavatrice)lavanderia.GetMacchina(numero_macchina);


                lavatrice.Detersivo.Ricarica(parametro_aggiuntivo);
                ultimoMessaggioSistema = "Detersivo ricaricato correttametne.";


                break;

            case "ammorbidente":

                //qui potrei avere errore di conversione, per semplicità gestiamo con eccezione nativa InvalidCastException
                lavatrice = (Lavatrice)lavanderia.GetMacchina(numero_macchina);

                lavatrice.Ammorbidente.Ricarica(parametro_aggiuntivo);
                ultimoMessaggioSistema = "Ammorbidente ricaricato correttametne.";


                break;

            case "esci":

                run = false;

                break;

            default:

                ultimoMessaggioSistema = "Il comando [" + cmd + "] non esiste.";

                break;
        }

    }
    catch (InvalidCastException)
    {
        ultimoMessaggioSistema = " Le asciugatrici non hanno i serbatoi, seleziona una lavatrice.";
    }
    catch(FormatException e)
    {
        ultimoMessaggioSistema = " Parametri non validi!";
    }
    catch(IndexOutOfRangeException e)
    {
        ultimoMessaggioSistema = " Sintassi comando errata.";
    }
    catch (Exception e)
    {
        //l'ultimo messaggio viene salvato e ripresentato prima del menu utente.
        ultimoMessaggioSistema = e.Message;
    }
   


}
