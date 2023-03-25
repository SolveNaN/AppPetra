namespace ControWell.Client.Services.CarroTanqueService
{
    public interface ICarroTanqueService
    {
        List<CarroTanque> CarroTanques { get; set; }
        Task<CarroTanque> GetSingleCarroTanque(int id);

        Task CreateCarroTanque(CarroTanque carroanque);
        Task DeleteCarroTanque(int id);
        Task UpdateCarroTanque(CarroTanque carroTanque);

    }
}
