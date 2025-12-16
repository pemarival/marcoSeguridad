using marcoSeguridad.Models;

namespace marcoSeguridad.Services;

public static class PoliticaService
{
    static List<Politica> Politicas { get; }
    static int nextId = 2;

    static PoliticaService()
    {
        Politicas = new List<Politica>
        {
            new Politica
            {
                PoliticaID = 1,
                MinLongitud = 8,
                MaxLongitud = 16,
                RequiereMayusculas = true,
                RequiereNumeros = true,
                RequiereSimbolos = false,
                CaducidadDias = 90
            }
        };
    }

    // GET ALL
    public static List<Politica> GetAll() => Politicas;

    // GET BY ID
    public static Politica? Get(int id) =>
        Politicas.FirstOrDefault(p => p.PoliticaID == id);

    // ADD
    public static void Add(Politica politica)
    {
        politica.PoliticaID = nextId++;
        Politicas.Add(politica);
    }

    // DELETE
    public static void Delete(int id)
    {
        var politica = Get(id);
        if (politica is null)
            return;

        Politicas.Remove(politica);
    }

    // UPDATE
    public static void Update(Politica politica)
    {
        var index = Politicas.FindIndex(
            p => p.PoliticaID == politica.PoliticaID
        );

        if (index == -1)
            return;

        Politicas[index] = politica;
    }
}
