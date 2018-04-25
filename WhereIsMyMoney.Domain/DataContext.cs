namespace WhereIsMyMoney.Domain
{
    using System.Data.Entity;

    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }
    }
}
