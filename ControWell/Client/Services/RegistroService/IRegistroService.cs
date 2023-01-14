namespace ControWell.Client.Services.RegistroService
{
    public interface IRegistroService
    {
        List<Registro> Registros { get; set; }
        List<VariableProceso> VariableProcesos { get; set; }
        List<Pozo> Pozos { get; set; }

        Task<Registro> GetSingleRegistro(int id);

        Task CreateRegistro(Registro registro);
        Task DeleteRegistro(int id);
        Task UpdateRegistro(Registro registro);
        Task CreateOrUpdateRegistro(Registro registro);
        
    }
}
