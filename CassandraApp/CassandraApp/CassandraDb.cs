using Cassandra;
using Cassandra.Mapping;
using System;
using System.Collections.Generic;

namespace CassandraApp
{
    public class CassandraDb
    {

        private ISession _session;

        public CassandraDb()
        {
            CriarTable();            
        }

        internal void RealizarTestes()
        {
            // Selecionar todos
            var mapper = new Mapper(_session);
            foreach (var cliente in mapper.Fetch<Cliente>("SELECT * FROM cliente"))
            {
                Console.WriteLine(cliente);
            }

            var redis = mapper.FirstOrDefault<Cliente>("SELECT * FROM cliente WHERE PrimeiroNome = ? ALLOW FILTERING", "redis");
            Console.WriteLine(redis);
        }

        internal void ExcluirTudo()
        {
            _session.Execute("DROP table cliente");
            _session.Execute("DROP KEYSPACE essentials");
        }

        internal void CriarTable()
        {

            object resultado = null;

            var cluster = Cluster.Builder()
                .AddContactPoints("127.0.0.1")
                .WithDefaultKeyspace("essentials")
                .Build();

            var replication = new Dictionary<string, string>
            {
                { "class", "SimpleStrategy" },
                { "replication_factor", "1" },
            };
            _session = cluster.ConnectAndCreateDefaultKeyspaceIfNotExists(replication);

            resultado = _session.Execute(Queries.CriaTabela);
            

            var mapper = new Mapper(_session);


            mapper.Insert<Cliente>(new Cliente("cassandra", "fulano", "cassandra@hotmail.com.br"));
            mapper.Insert<Cliente>(new Cliente("revenDb", "beltrano", "reven@email.com.br"));
            mapper.Insert<Cliente>(new Cliente("redis", "cilano", "redis@email.com.br"));

            Console.WriteLine("Cliente inseridos com sucesso");


        }

        
    }
}
