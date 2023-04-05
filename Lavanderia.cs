
// il sistema di controllo è il program.cs

using ConsoleTables;
using csharp_lavanderia;
using csharp_lavanderia.Exceptions;
using System.Data;
using System.Reflection.PortableExecutable;

public class Lavanderia
{
    Macchina[] macchine;

    public Lavanderia()
    {
        macchine = new Macchina[10];

        this.Reset();
    }

    public void StampStato()
    {

        Console.WriteLine(" Stato lavanderia:");
        var table = new ConsoleTable("Numero","Tipo","Gettoni", "Aperta", "In Funzione", "Programma", "Tempo rimanente","Detersivo", "Ammorbidente");

        foreach(Macchina macchina in macchine)
        {
            string detersivo = "N.N";
            string ammorbidente = "N.N";

            if(macchina is Lavatrice)
            {
                detersivo = ((Lavatrice)macchina).Detersivo.Livello.ToString();
                ammorbidente = ((Lavatrice)macchina).Ammorbidente.Livello.ToString();
            }

            table.AddRow(
                macchina.Numero,
                macchina.GetType().ToString(),
                macchina.GettoniInseriti,
                macchina.Aperta,
                macchina.InFunzione,
                macchina.ProgrammaSelezionato?.
                Nome,
                macchina.TempoRimanente,
                detersivo,
                ammorbidente
                );
        }

        table.Write();


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
            macchine[i] = new Lavatrice(i+1);
           
        }

        //creazione randomica temporanea per test
        for (; i < 10; i++)
        {
            macchine[i] = new Asciugatrice(i+1);
        }

    }

    public Macchina GetMacchina(int numeroMacchina)
    {
        numeroMacchina--;

        if (numeroMacchina >= macchine.Length || numeroMacchina<0)
            throw new MacchinaSelezionataInesistenteException();

        return macchine[numeroMacchina];
    }
}
