using Lab1_G3.Dominio.EntidadesTipadas;
using Lab1_G3.Utilitarios;
using Lab1_G3_.Dominio.InterfacesLN;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_G3_.LogicaNegocios.Implementaciones
{
    public class DetallePedido : IDetallePedidoLN
    {
        public Respuesta<TDetallesPedido> Buscar(TDetallesPedido DetallesPedido)
        {
            throw new NotImplementedException();
        }

        public Respuesta<bool> Eliminar(TDetallesPedido DetallesPedido)
        {
            throw new NotImplementedException();
        }

        public Respuesta<TDetallesPedido> Insertar(TDetallesPedido DetallesPedido)
        {
            throw new NotImplementedException();
        }

        public Respuesta<IEnumerable<TDetallesPedido>> Listar()
        {
            throw new NotImplementedException();
        }

        public Respuesta<TDetallesPedido> Modificar(TDetallesPedido DetallesPedido)
        {
            throw new NotImplementedException();
        }

        public Respuesta<IEnumerable<TDetallesPedido>> Obtener(TDetallesPedido DetallesPedido)
        {
            throw new NotImplementedException();
        }
    }
}
