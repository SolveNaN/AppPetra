namespace ControWell.Client.Services.GuiaService
{
    public interface IGuiaService
    {
        List<Guia> Guias { get; set; }
        Task<Guia> GetSingleGuia(string id);
        Task CreateGuia(Guia guia);
        Task DeleteGuia(int id);
        Task UpdateGuia(Guia guia);

    }
}
