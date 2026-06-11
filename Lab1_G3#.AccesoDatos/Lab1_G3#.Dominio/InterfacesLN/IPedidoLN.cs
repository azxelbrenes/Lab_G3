using Lab1_G3.Dominio.EntidadesTipadas;
using Lab1_G3.Utilitarios;
using System;
using System.Collections.Generic;
using System.Text;


namespace Lab1_G3.Dominio.InterfacesLN
{
    public interface IPedidoLN
    {
        Respuesta<TPedido> Insertar(TPedido pedido);
        Respuesta<TPedido> Modificar(TPedido pedido);
        Respuesta<bool> Eliminar(TPedido pedido);
        Respuesta<IEnumerable<TPedido>> Obtener(TPedido pedido);
        Respuesta<TPedido> Buscar(TPedido pedido);
        Respuesta<IEnumerable<TPedido>> Listar();
    }
}
