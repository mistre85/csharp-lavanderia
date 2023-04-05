
// il sistema di controllo è il program.cs
public class ProgrammaAsciugatura : Programma
{


       
    public ProgrammaAsciugatura(int numero, string nome, int durata, int numeroGettoni) : 
        base(numero,nome, durata, numeroGettoni)
    {

    }


    public override string ToString()
    {
        return "Programma Asciugatura " + Nome;
    }
}

