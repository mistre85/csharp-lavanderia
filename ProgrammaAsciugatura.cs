
// il sistema di controllo è il program.cs
public class ProgrammaAsciugatura : Programma
{


       
    public ProgrammaAsciugatura(string nome, int durata, int numeroGettoni) : 
        base(nome, durata, numeroGettoni)
    {

    }


    public override string ToString()
    {
        return "Programma Asciugatura " + Nome;
    }
}
