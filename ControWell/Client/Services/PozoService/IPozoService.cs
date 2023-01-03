namespace ControWell.Client.Services.PozoService
{
    public interface IPozoService
    {
        List<Pozo> Pozos { get; set; }
        Task<Pozo> GetSinglePozo(int id);

        Task CreatePozo(Pozo pozo);
        Task DeletePozo(int id);
        Task UpdatePozo(Pozo pozo);

    }
}
