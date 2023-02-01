namespace ControWell.Client.Services.BalanceService
{
    public interface IBalanceService
    {
        List<Balance> Balances { get; set; }
        List<Tanque> Tanques { get; set; }
        List<Pozo> Pozos { get; set; }
        List<TipoMovimiento> Movimientos { get; set; }

        Task<Balance> GetSingleBalance(int id);

        Task CreateBalance(Balance miBalance);
        Task DeleteBalance(int id);
        Task UpdateBalance(Balance miBalance);
    }
}
