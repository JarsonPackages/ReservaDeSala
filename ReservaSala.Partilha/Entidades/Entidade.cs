using FluentValidator;
using System;


namespace ReservaSala.Infra.Entidades
{
    public abstract class Entidade:Notifiable
    {
        public Entidade()
        {
            ID = Guid.NewGuid();
            DataCadastro = DateTime.Now;
        }

        public Guid ID { get; private set; }
        public DateTime DataCadastro { get; private set; }
    }
}
