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

        public Guid ID { get;  set; }
        public DateTime DataCadastro { get;  set; }
    }
}
