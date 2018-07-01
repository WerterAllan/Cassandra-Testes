using System;

namespace CassandraApp
{
    public class Cliente
    {
        public Cliente()
        {

        }

        public Cliente(string primeiroNome, string ultimoNome, string email)
        {
            this.Id = Guid.NewGuid();
            this.PrimeiroNome = primeiroNome;
            this.UltimoNome = ultimoNome;
            this.Email = email;
        }

        public Guid Id { get; private set; }
        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }
        public string Email { get; private set; }

        public override string ToString()
        {
            return $"Id: {Id.ToString()} Nome: { PrimeiroNome } SobreNome: {UltimoNome } Email: {Email}";
        }

    }
}
