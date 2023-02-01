namespace ControWell.Client.Services.TipoMovimientoService
{
    public interface ITipoMovimientoService
    {
        List<TipoMovimiento> TipoMovimientos { get; set; }
        Task<TipoMovimiento> GetSingleTipoMovimiento(int id);

        Task CreateTipoMovimiento(TipoMovimiento movimiento);
        Task DeleteTipoMovimiento(int id);
        Task UpdateTipoMovimiento(TipoMovimiento movimiento);
    }
}
