
// il sistema di controllo è il program.cs

using csharp_lavanderia;
using csharp_lavanderia.Exceptions;
using System.Data;
using System.Reflection.PortableExecutable;

public class Lavanderia
{
    Macchina[] macchine;

    List<Cliente> clienti;

    public Lavanderia()
    {
        macchine = new Macchina[10];
        clienti = new List<Cliente>();

        this.Reset();
    }

    public void StampaDettaglioMacchina(int numero)
    {
        int index = numero - 1;
        if (index < 0 || index >= macchine.Length)
        {
            throw new Exception("La macchina specificata non esiste!");
        }

        macchine[index].StampaDettaglio();

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
    public void Simulazione()
    {

        Cliente clienteCasuale = clienti[new Random().Next(0, clienti.Count())];
        Macchina macchinaCasuale = macchine[new Random().Next(0, macchine.Count())];

        clienteCasuale.Usa(macchinaCasuale);
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

        for(i=0; i< 20; i++)
        {
            clienti.Add(new Cliente());
        }
    }

    public static int GeneraGettoni()
    {
        return new Random().Next(2,10);
    }
}
