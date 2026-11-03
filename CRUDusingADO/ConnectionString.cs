namespace CRUDusingADO
{
    public static class ConnectionString
    {
        private static readonly string _connectionString = "Server=localhost;Database=CRUDAdoDB;Trusted_Connection=True;";
        public static string GetConnectionString()
        {
            return _connectionString;
        }
    }
}
