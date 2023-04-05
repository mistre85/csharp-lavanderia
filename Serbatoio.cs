
// il sistema di controllo è il program.cs


public class Serbatoio 
{

    //livelloDiPartenza disponibili
    public int Livello { get; private set; }

    //stabilisce quale quantità massima questo serbatoio può gestire
    public int LivelloMassimo;

    public Serbatoio(int livelloDiPartenza, int livelloMassimo)
    {

        if (livelloDiPartenza <= 0)
        {
            throw new QuantitaNegativaException("Non puoi specificare una quantità negativa.");
        }

        if (livelloDiPartenza <= 0)
        {
            throw new QuantitaNegativaException("Non puoi specificare un livello massimo negativo.");
        }

        if (livelloDiPartenza < 0)
            throw new LivelloNegativoSerbatoioExcpetion();

        Livello = livelloDiPartenza;
        LivelloMassimo = livelloMassimo;
    }

    public void Consuma(int quantità)
    {
        if (quantità <= 0)
        {
            throw new QuantitaNegativaException("Non puoi specificare una quantità negativa.");
        }

        if (Disponibile(quantità))
        {
            Livello -= quantità;
        }
    }

    public bool Disponibile(int quantità)
    {
        if (quantità <= 0)
        {
            throw new QuantitaNegativaException("Non puoi specificare una quantità negativa.");
        }

        return quantità <= Livello;
    }

    public override string ToString()
    {
        return Livello + "ml";
    }

    public void Ricarica(int quantità)
    {
        if(quantità <= 0)
        {
            throw new QuantitaNegativaException("Non puoi specificare una quantità negativa.");
        }

        if(Livello + quantità > LivelloMassimo)
        {
            throw new LivelloMassimoSerbatoioException("Livello del serbatoio superato, impossibile ricaricare.");
        }

        Livello += quantità;
    }
}
