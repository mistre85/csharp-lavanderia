
// il sistema di controllo è il program.cs

using csharp_lavanderia;

public class Lavanderia
{
    Lavatrice[] lavatrici;

    Asciugatrice[] asciugatrici;

    public Lavanderia()
    {
        lavatrici = new Lavatrice[5];
        asciugatrici = new Asciugatrice[5];

        this.Reset();
    }

    public bool StampaDettaglioLavatrice(int numero)
    {
        int index = numero - 1;
        if(index < 0 || index >= lavatrici.Length)
        {
            return false;
        }

        lavatrici[index].StampaDettaglio();

        return true;
    }

    public bool StampaDettaglioAsciugatrici(int numero)
    {
        int index = numero - 1;
        if (index < 0 || index >= asciugatrici.Length)
        {
            return false;
        }

        asciugatrici[index].StampaDettaglio();

        return true;
 
    }

    public void StampaStatoGenerale()
    {
        Console.WriteLine("Stato Generale delle macchine:");
        Console.WriteLine();
        
        for(int i = 0; i < lavatrici.Length; i++)
        {
            Console.Write("Lavatrice {0} - ", (i + 1));
            lavatrici[i].StampaStato();
        }
        
        Console.WriteLine();
        
        for (int i = 0; i < asciugatrici.Length; i++)
        {
            Console.Write("Asciugatrice {0} - ", (i + 1));
            asciugatrici[i].StampaStato();
        }

        Console.WriteLine();
        Console.WriteLine();
    }


    public void Simulazione()
    {
        //il cliente deve poter usare i servizi della lavanderia

    }


    /*
        reinizializza tutti i macchinari della lavanderia
    */
    public void Reset()
    {
        //creazione randomica temporanea per test
        for (int i = 0; i < lavatrici.Length; i++)
        {
            //creo una nuova lavatrice con impostazioni di base
            lavatrici[i] = new Lavatrice();
           
        }

        //creazione randomica temporanea per test
        for (int i = 0; i < asciugatrici.Length; i++)
        {
            asciugatrici[i] = new Asciugatrice();
        }
    }
}
