namespace ControWell.Client.Services.VariableProcesoService
{
    public interface IVariableProcesoService
    {
        List<VariableProceso> Variables { get; set; }
        Task<VariableProceso> GetSingleVariableProceso(int id);

        Task CreateVariableProceso(VariableProceso variable);
        Task DeleteVariableProceso(int id);
        Task UpdateVariableProceso(VariableProceso variable);

    }
}
