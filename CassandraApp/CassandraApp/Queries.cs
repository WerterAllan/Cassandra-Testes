namespace CassandraApp
{
    public static class Queries
    {
        public static string CriaTabela = @" CREATE TABLE IF NOT EXISTS cliente (
                                Id UUID,
                                PrimeiroNome TEXT,
                                UltimoNome TEXT,
                                Email TEXT,
                                PRIMARY KEY ( (Id), PrimeiroNome )
                            );";       

        

    }
}
