using Lab1_G3.Dominio.EntidadesTipadas;
using Lab1_G3.Utilitarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_G3_.Dominio.InterfacesLN
{
    public interface IDetallePedidoLN
    {
        Respuesta<TDetallesPedido> Insertar(TDetallesPedido DetallesPedido);
        Respuesta<TDetallesPedido> Modificar(TDetallesPedido DetallesPedido);
        Respuesta<bool> Eliminar(TDetallesPedido DetallesPedido);
        Respuesta<IEnumerable<TDetallesPedido>> Obtener(TDetallesPedido DetallesPedido);
        Respuesta<TDetallesPedido> Buscar(TDetallesPedido DetallesPedido);
        Respuesta<IEnumerable<TDetallesPedido>> Listar();


    }
}
