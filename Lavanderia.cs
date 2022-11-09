
// il sistema di controllo è il program.cs

using System.Reflection.PortableExecutable;

public class Lavanderia
{
    Macchina[] macchine;

    public Lavanderia()
    {
        macchine = new Macchina[10];

        this.Reset();
    }

    public bool StampaDettaglioMacchina(int numero)
    {
        int index = numero - 1;
        if (index < 0 || index >= macchine.Length)
        {
            return false;
        }

        macchine[index].StampaDettaglio();

        return true;
    }
  


    public void StampaStatoGenerale()
    {
        Console.WriteLine("Stato Generale delle macchine:");
        Console.WriteLine();

        for (int i = 0; i < macchine.Length; i++)
        {
            Console.Write("{1} {0} - ", (i + 1), macchine[i].GetType().ToString());
            macchine[i].StampaStato();
        }
      
       
        Console.WriteLine();
    }

    /*
     Simula l'esecuzione di un utilizzo randomico delle macchine
     */
    public bool Next()
    {
        bool ok = true;
        //creazione randomica temporanea per test
        for (int i = 0; i < macchine.Length; i++)
        {
            //seleziono e avvio un programma casuale
            int programmaCasuale = new Random().Next(1, macchine[i].NumeroProgrammiDisponibili);
            macchine[i].Simulazione();

            if (macchine[i].SelezionaProgramma(programmaCasuale))
            {
                if (!macchine[i].AvviaProgramma())
                {
                    Console.WriteLine("Il detersivo non è sufficiente, cambia programma!");
                    ok = false;
                }
            }
            else
            {
                Console.WriteLine("La macchina è occupata {0}", i + 1);
                ok = false;
            }
        }

       

        return ok;
    }

    /*
        reinizializza tutti i macchinari della lavanderia
    */
    public void Reset()
    {
        int i = 0;
        //creazione randomica temporanea per test
        for (; i < 5; i++)
        {
            //creo una nuova lavatrice con impostazioni di base
            macchine[i] = new Lavatrice();
           
        }

        //creazione randomica temporanea per test
        for (; i < 10; i++)
        {
            macchine[i] = new Asciugatrice();
        }
    }
}
