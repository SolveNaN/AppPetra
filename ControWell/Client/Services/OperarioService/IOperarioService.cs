namespace ControWell.Client.Services.OperarioService
{
    public interface IOperarioService
    {
        List<Operario> Operarios { get; set; }
        Task<Operario> GetSingleOperario(int id);
        Task CreateOperario(Operario Operario);
        Task DeleteOperario(int id);
        Task UpdateOperario(Operario Operario);

    }
}
