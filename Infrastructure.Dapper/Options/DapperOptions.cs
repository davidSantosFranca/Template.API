namespace Infrastructure.Repository.Options
{
    public class DapperOptions
    {
        public Enumerators.SqlProviderEnum Provider { get; set; }
        public string ConnectionString { get; set; }
    }
}
