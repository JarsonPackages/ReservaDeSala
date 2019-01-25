

namespace ReservaSala.Partilha
{ 
    public interface IComandoManipulador<T> where T:IComando
    {
        IComandoResultado Manipular(T comando);
    }
}
