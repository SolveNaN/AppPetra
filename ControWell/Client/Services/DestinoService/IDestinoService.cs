namespace ControWell.Client.Services.DestinoService
{
    public interface IDestinoService
    {
        List<Destino> Destinos { get; set; }
        Task<Destino> GetSingleDestino(int id);

        Task CreateDestino(Destino Destino);
        Task DeleteDestino(int id);
        Task UpdateDestino(Destino Destino);

    }
}
