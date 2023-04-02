namespace ControWell.Client.Services.BalanceService
{
    public interface IBalanceService
    {


        Task<Balance> GetSingleBalance(int id);

        Task CreateBalance(Balance miBalance);
        Task DeleteBalance(int id);
        Task UpdateBalance(Balance miBalance);
    }
}
