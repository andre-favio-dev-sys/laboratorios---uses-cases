namespace Lab01_Ancco_Andre;

public class Empresa
{
    private int id;
    private string razonSocial;
    private string ruc;

    public Empresa(int id, string razonSocial, string ruc)
    {
        this.id = id;
        this.razonSocial = razonSocial;
        this.ruc = ruc;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Id: {id}, Razón Social: {razonSocial}, RUC: {ruc}");
    }
}