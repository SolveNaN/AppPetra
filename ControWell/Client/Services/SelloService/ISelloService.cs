namespace ControWell.Client.Services.SelloService
{
    public interface ISelloService
    {
        List<Sello> Sellos { get; set; }
        Task<Sello> GetSingleSello(string id);
        Task CreateSello(Sello sello);
        Task DeleteSello(int id);
        Task UpdateSello(Sello sello);

    }
}
