
// il sistema di controllo è il program.cs

public class Lavatrice : Macchina
{   
    public Serbatoio Detersivo { get; private set; }
    public Serbatoio Ammorbidente { get; private set; }

    public Lavatrice() : base(3)
    {
        Detersivo = new Serbatoio(1000);
        Ammorbidente = new Serbatoio(500);

        Programmi[0] = new ProgrammaLavaggio("Rifrescante",20,5,20,2);
        Programmi[1] = new ProgrammaLavaggio("Rinnovante",40,10,40,3);
        Programmi[2] = new ProgrammaLavaggio("Sgrassante",60,15,60,4);

    }

    public void StampaDettaglio()
    {
        StampaStato();

        if (InFunzione)
        {
            Console.WriteLine("Programma in esecuzione: {0}", ProgrammaInEsecuzione.Nome);
            Console.WriteLine("Tempo rimanente: {0}", TempoRimanente);
        }
       
        Console.WriteLine("Ammorbidente disponibile: {0}", Ammorbidente.Livello);
        Console.WriteLine("Detersivo disponibile: {0}", Detersivo.Livello);
        Console.WriteLine("Numero Gettoni: {0}", GettoniInseriti);

    }
}
