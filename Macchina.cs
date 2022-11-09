
// il sistema di controllo è il program.cs


public abstract class Macchina
{
    protected Programma[] Programmi { get; set; }

    protected virtual Programma ProgrammaSelezionato { get; set; }

    private int tempoRimanente;

    public Macchina(int numeroProgrammi)
    {
        Programmi = new Programma[numeroProgrammi];
    }

    public bool InFunzione { get; protected set; }

    public int GettoniInseriti { get; protected set; }

    public int NumeroProgrammiDisponibili
    {
        get
        {
            return Programmi.Length;
        }
    }

    public int TempoRimanente
    {
        get
        {
            return tempoRimanente;
        }

        private set
        {
            if (value == 0)
            {
                tempoRimanente = 0;
                InFunzione = false;
                //ProgrammaSelezionato = null;
            }
            else
            {
                tempoRimanente = value;
            }
        }

    }


    public abstract bool AvviaProgramma();

    //selezione e avvio
    public bool SelezionaProgramma(int numeroProgramma)
    {

        //controllo se posso avviare il programma
        //e se il programma esiste
        if(
            numeroProgramma >= Programmi.Length || numeroProgramma < 1 ||
            InFunzione
            
            )
        {
            return false;
        }

        //recupero il programma
        //programma dell'utente - 1 
        ProgrammaSelezionato = Programmi[numeroProgramma - 1];

        return true;
    }

    public bool Simulazione(bool init = false)
    {
        if(ProgrammaSelezionato == null)
        {
            return false;
        }

        //per il momento casuale
        //lo metto alla fine perchè c'è un comportamento su SET che rende null il programma
        if (init)//la situazioe iniziale
            TempoRimanente = new Random().Next(1, ProgrammaSelezionato.Durata + 1);
        else//situazione intermedia... il tempo scorre durante il lavaggio
            TempoRimanente = new Random().Next(0,TempoRimanente);

        return true;
    }


    public virtual void StampaDettaglio()
    {
        StampaStato();

        if (InFunzione)
        {
            Console.WriteLine(ProgrammaSelezionato.ToString());
            Console.WriteLine("Tempo rimanente: {0}", TempoRimanente);
        }

        
    }

    public void StampaStato()
    {
        Console.WriteLine("Stato: {0}", InFunzione ? "Occupata" : "Libera");
    }

}
