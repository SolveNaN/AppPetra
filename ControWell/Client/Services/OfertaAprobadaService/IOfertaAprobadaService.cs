namespace ControWell.Client.Services.OfertaDiariaService
{
    public interface IOfertaDiariaService
    {
        List<OfertaDiaria> OfertaDiariaProgramacionCarrotanques { get; set; }
        Task<OfertaDiaria> GetSingleOfertaDiaria(int id);
        Task<OfertaDiaria> GetByPlacaOfertaDiaria(string placa);
        Task CreateOfertaDiaria(OfertaDiaria ofertaDiaria);
        Task DeleteOfertaDiaria(int id);
        Task UpdateOfertaDiaria(OfertaDiaria ofertaDiaria);

    }
}
