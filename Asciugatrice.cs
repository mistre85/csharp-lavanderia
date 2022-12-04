
// il sistema di controllo è il program.cs


public class Asciugatrice : Macchina
{

    public override ProgrammaAsciugatura ProgrammaSelezionato
    {
        get
        {
            return (ProgrammaAsciugatura)base.ProgrammaSelezionato;
        }
    }

    public Asciugatrice() : base(2)
    {
       Programmi[0] = new ProgrammaAsciugatura("Rapido", 20,2);
       Programmi[1] = new ProgrammaAsciugatura("Intenso", 40,4);
   
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
            Console.WriteLine("Programma in esecuzione: {0}", ProgrammaSelezionato.Nome);
            Console.WriteLine("Tempo rimanente: {0}", TempoRimanente);
        }

        Console.WriteLine("Numero Gettoni: {0}", GettoniInseriti);

    }

    public override void AvviaProgramma()
    {
       
        InFunzione = true;

        GettoniInseriti += ProgrammaSelezionato.NumeroGettoni;
        
        //inizializzo sul tempo del programma
        Simulazione();

    }
}
