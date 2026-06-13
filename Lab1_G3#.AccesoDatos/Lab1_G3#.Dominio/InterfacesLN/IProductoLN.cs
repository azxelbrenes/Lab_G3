using Lab1_G3.Dominio.EntidadesTipadas;
using Lab1_G3.Utilitarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_G3_.Dominio.InterfacesLN
{
    public interface IProductoLN
    {
        Respuesta<TProducto> Insertar(TProducto producto);
        Respuesta<TProducto> Modificar(TProducto producto);
        Respuesta<bool> Eliminar(TProducto producto);
        Respuesta<IEnumerable<TProducto>> Obtener(TProducto producto);
        Respuesta<TProducto> Buscar(TProducto producto);
        Respuesta<IEnumerable<TProducto>> Listar();
    }
}
