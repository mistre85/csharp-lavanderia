

bool menu = true;

Lavanderia lav = new Lavanderia();

while (menu)
{
    Console.Clear();

    Console.WriteLine("Sistema di controllo lavanderia");
    Console.WriteLine();

    lav.StampaStatoGenerale();


    Console.WriteLine("Digita 'reset' per reinizializzare casualmente il sistema.");
    Console.WriteLine("Digita il numero della macchina per vedere i dettagli");
    Console.WriteLine("Digita 'esci' per chiudere il programma.");
    Console.Write(">");

    string sceltaUtente = Console.ReadLine();

    if (sceltaUtente == "reset") {

        //try
        //{
        lav.Simulazione();
        //}catch(Exception e)
        //{
        //    Console.WriteLine("error: {0}", e.Message);

        Console.WriteLine();
        Console.WriteLine("Premi invio per continuare...");
        Console.ReadLine();
        //}



    }
    else 
    {
        Console.Clear();

        try
        {

            int numero = Convert.ToInt32(sceltaUtente);
            lav.StampaDettaglioMacchina(numero);

        }
        catch (FormatException e)
        {
            //inserito una lettera invece che un numero
            Console.WriteLine("Codice macchina non corretto!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }


        Console.WriteLine();
        Console.WriteLine("Premi invio per continuare...");
        Console.ReadLine();

    }

   
}
