using Lab1_G3.Dominio.EntidadesTipadas;
using Lab1_G3.Utilitarios;
using Lab1_G3_.Dominio.InterfacesLN;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_G3_.LogicaNegocios.Implementaciones
{
    public class Producto : IProductoLN
    {
        public Respuesta<TProducto> Buscar(TProducto producto)
        {
            throw new NotImplementedException();
        }

        public Respuesta<bool> Eliminar(TProducto producto)
        {
            throw new NotImplementedException();
        }

        public Respuesta<TProducto> Insertar(TProducto producto)
        {
            throw new NotImplementedException();
        }

        public Respuesta<IEnumerable<TProducto>> Listar()
        {
            throw new NotImplementedException();
        }

        public Respuesta<TProducto> Modificar(TProducto producto)
        {
            throw new NotImplementedException();
        }

        public Respuesta<IEnumerable<TProducto>> Obtener(TProducto producto)
        {
            throw new NotImplementedException();
        }
    }
}
