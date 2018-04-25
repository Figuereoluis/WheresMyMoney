namespace WhereIsMyMoney.Backend.Models
{
    using WhereIsMyMoney.Domain;

    public class DataContextLocal : DataContext
    {
        public System.Data.Entity.DbSet<WhereIsMyMoney.Domain.Budget> Budgets { get; set; }

        public System.Data.Entity.DbSet<WhereIsMyMoney.Domain.Status> Status { get; set; }

        public System.Data.Entity.DbSet<WhereIsMyMoney.Domain.User> Users { get; set; }
    }
}