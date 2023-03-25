namespace ControWell.Client.Services.FormatoCargaService
{
    public interface IFormatoCargaService
    {
        List<FormatoCarga> FormatoCarroTanquesCargados { get; set; }
        Task<FormatoCarga> GetSingleFormatoCarga(int id);

        Task CreateFormatoCarga(FormatoCarga formatoCarga);
        Task DeleteFormatoCarga(int id);
        Task UpdateFormatoCarga(FormatoCarga formatoCarga);

    }
}
