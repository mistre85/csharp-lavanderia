
// il sistema di controllo è il program.cs

Lavanderia lav = new Lavanderia();

bool menu = true;

while (menu)
{
    Console.Clear();

    Console.WriteLine("Sistema di controllo lavanderia");
    Console.WriteLine();

    lav.StampaStatoGenerale();


    Console.WriteLine("Digita 'reset' per reinizializzare casualmente il sistema.");
    Console.WriteLine("Per vedere i dettagli delle macchine digita 'm1' per vedere i dettagli della macchina 1");
    Console.WriteLine("Digita 'esci' per chiudere il programma.");
    Console.Write(">");

    string sceltaUtente = Console.ReadLine();

    if (sceltaUtente == "reset") {
        //lav.Reset();
        if (!lav.Next())
        {
            Console.WriteLine();
            Console.WriteLine("Premi invio per continuare...");
            Console.ReadLine();
        }
    }
    else 
    {
        if (sceltaUtente.Length == 2)
        {
            char macchina = sceltaUtente[0];
            int numero = Convert.ToInt32(sceltaUtente[1].ToString());

            bool numeroMacchinaEsistente = true;

            Console.Clear();

            switch (macchina)
            {
                case 'm':
                    numeroMacchinaEsistente = lav.StampaDettaglioMacchina(numero);
                    break;
                default:
                    numeroMacchinaEsistente = false;
                    break;

            }

            if (!numeroMacchinaEsistente)
            {
                Console.WriteLine("errore: La macchina indicata non esiste, specificare il nome corretto.");

            }


        }
        else
        {
            Console.WriteLine("errore: comando sconosciuto");
        }

        Console.WriteLine();
        Console.WriteLine("Premi invio per continuare...");
        Console.ReadLine();

    }




   
}
