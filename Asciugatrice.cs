
// il sistema di controllo è il program.cs


public class Asciugatrice : Macchina
{
    
    public Asciugatrice() : base(2)
    {
       

        Programmi[0] = new ProgrammaAsciugatura("Rapido", 20,2);
        Programmi[1] = new ProgrammaAsciugatura("Intenso", 40,4);
   
    }


    public bool SelezionaProgramma(int numeroProgramma)
    {

        //controllo se posso avviare il programma
        //e se il programma esiste
        if (
            numeroProgramma >= programmi.Length ||
            InFunzione ||
            numeroProgramma < 1
            )
        {
            return false;
        }

        //recupero il programma
        ProgrammaInEsecuzione = programmi[numeroProgramma - 1];


        GettoniInseriti += ProgrammaInEsecuzione.NumeroGettoni;
      

        //per il momento casuale
        //lo metto alla fine perchè c'è un comportamento su SET che rende null il programma
        TempoRimanente = new Random().Next(0, ProgrammaInEsecuzione.Durata + 1);

        return true;

    }

    public void StampaStato()
    {
        Console.WriteLine("Stato: {0}", InFunzione ? "Occupata" : "Libera");
    }

    public void StampaDettaglio()
    {
        StampaStato();

        if (InFunzione)
        {
            Console.WriteLine("Programma in esecuzione: {0}", ProgrammaInEsecuzione.Nome);
            Console.WriteLine("Tempo rimanente: {0}", TempoRimanente);
        }

        Console.WriteLine("Numero Gettoni: {0}", GettoniInseriti);

    }

    public void SimulaAvanzamento()
    {
        TempoRimanente = new Random().Next(0, TempoRimanente);
    }


}
