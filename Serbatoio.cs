
// il sistema di controllo è il program.cs


public class Serbatoio 
{
    //milliletri disponibili
    public int Livello { get; private set; }

    public Serbatoio(int milliletri)
    {
        if (milliletri < 0)
            throw new LivelloNegativoSerbatoioExcpetion();

        Livello = milliletri;
    }

    public void Consuma(int quantità)
    {
        if(Disponibile(quantità))
        {
            Livello -= quantità;
        }
    }

    public bool Disponibile(int quantità)
    {
        return quantità <= Livello;
    }


}
