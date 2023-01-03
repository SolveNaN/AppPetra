namespace ControWell.Client.Services.AlarmaService
{
    public interface IAlarmaService
    {
        List<Alarma> Alarmas { get; set; }
        List<VariableProceso> VariableProcesos { get; set; }
        List<Pozo> Pozos { get; set; }

        Task<Alarma> GetSingleAlarma(int id);

        Task CreateAlarma(Alarma alarma);
        Task DeleteAlarma(int id);
        Task UpdateAlarma(Alarma alarma);
    }
}
