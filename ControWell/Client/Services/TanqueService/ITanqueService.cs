namespace ControWell.Client.Services.TanqueService
{
    public interface ITanqueService
    {
        List<Tanque> Tanques { get; set; }
        Task<Tanque> GetSingleTanque(int id);

        Task CreateTanque(Tanque tanque);
        Task DeleteTanque(int id);
        Task UpdateTanque(Tanque tanque);
    }
}
