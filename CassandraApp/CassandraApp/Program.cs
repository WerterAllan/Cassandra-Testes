using Cassandra.Mapping;
using System;

namespace CassandraApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var cassandraDb = new CassandraDb();
            cassandraDb.RealizarTestes();
            cassandraDb.ExcluirTudo();
            


            Console.ReadKey();
        }
    }
}
