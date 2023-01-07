namespace ControWell.Client.Services.AforoService
{
    public interface IAforoService
    {
        List<AforoTK> Aforos { get; set; }
        List<Tanque> Tanques { get; set; }


        Task<AforoTK> GetSingleAforo(int id);

        Task CreateAforo(AforoTK aforo);
        Task DeleteAforo(int id);
        Task UpdateAforo(AforoTK aforo);
        Task ConsultaNivel(float nivel);
    }
}
