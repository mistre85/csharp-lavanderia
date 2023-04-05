
// il sistema di controllo è il program.cs


using ConsoleTables;
using System.Reflection.PortableExecutable;

public class Asciugatrice : Macchina
{

    public override ProgrammaAsciugatura ProgrammaSelezionato
    {
        get
        {
            return (ProgrammaAsciugatura)base.ProgrammaSelezionato;
        }
    }

    public Asciugatrice(int numero) : base(numero,2)
    {
       ListaProgrammi[0] = new ProgrammaAsciugatura(1,"Rapido", 20,2);
       ListaProgrammi[1] = new ProgrammaAsciugatura(2,"Intenso", 60,4);
   
    }

    public void StampaStato()
    {
        Console.WriteLine("Stato: {0}", InFunzione ? "Occupata" : "Libera");
    }


    public override string TabellaProgrammiToString()
    {
        var table = new ConsoleTable("Numero programma", "Nome programma", "Durata", "Gettoni");

        foreach (ProgrammaAsciugatura programma in ListaProgrammi)
        {
            table.AddRow(
                programma.Numero,
                programma.Nome,
                programma.Durata,
                programma.NumeroGettoni);
        }

        return table.ToString();
    }

    protected override void _avvia()
    {
        //non è necessario fare nulla
    }
}
