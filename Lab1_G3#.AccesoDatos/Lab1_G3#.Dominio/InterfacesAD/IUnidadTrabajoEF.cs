
using Lab1_G3.Dominio.Entidades;
using Lab1_G3.Dominio.EntidadesTipadas;

namespace Lab1_G3.Dominio.InterfacesAD
{
    public interface IUnidadTrabajoEF
    {
        IRepositorioAD<Categorium> TCategorium { get; }
        IRepositorioAD<Cliente> TCliente { get; }
        IRepositorioAD<DetallesPedido> TDetallesPedido { get; }
        IRepositorioAD<Pedido> TPedido { get; }
        IRepositorioAD<Producto> TProducto { get; }
        IRepositorioAD<SegPantalla> TSegPantalla { get; }
        IRepositorioAD<SegPerfil> TSegPerfil { get; }
        IRepositorioAD<SegPerfilXpantalla> TSegPerfilXPantalla { get; }
        IRepositorioAD<SegUsuario> TSegUsuario { get; }
        IRepositorioAD<TipoCedula> TTipoCedula { get; }

        void EmpezarTransaccion();
        void Completar();
        void CompletarTran();
        void Rollback();
    }
}
