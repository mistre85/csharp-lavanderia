
// il sistema di controllo è il program.cs

public abstract class Macchina
{
    public Programma[] Programmi { get; protected set; }

    public Programma ProgrammaInEsecuzione { get; protected set; }

    public int tempoRimanente;

    public Macchina(int numeroProgrammi)
    {
        Programmi = new Programma[numeroProgrammi];
    }

    public bool InFunzione
    {
        get
        {
            return ProgrammaInEsecuzione != null;
        }
    }

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
                ProgrammaInEsecuzione = null;
            }
            else
            {
                tempoRimanente = value;
            }
        }

    }

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
        Programma programmaSelezionato = Programmi[numeroProgramma - 1];

        return true;
    
    }

    public abstract bool AvviaProgramma();

    public void StampaStato()
    {
        Console.WriteLine("Stato: {0}", InFunzione ? "Occupata" : "Libera");
    }

}
