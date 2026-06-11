using Lab1_G3.Dominio.EntidadesTipadas;
using Lab1_G3.Dominio.InterfacesLN;
using Lab1_G3.Utilitarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_G3_.LogicaNegocios.Implementaciones
{
    public class Cliente : IClienteLN
    {
        public Respuesta<TCliente> Buscar(TCliente Cliente)
        {
            throw new NotImplementedException();
        }

        public Respuesta<bool> Eliminar(TCliente Cliente)
        {
            throw new NotImplementedException();
        }

        public Respuesta<TCliente> Insertar(TCliente Cliente)
        {
            throw new NotImplementedException();
        }

        public Respuesta<IEnumerable<TCliente>> Listar()
        {
            throw new NotImplementedException();
        }

        public Respuesta<TCliente> Modificar(TCliente Cliente)
        {
            throw new NotImplementedException();
        }

        public Respuesta<IEnumerable<TCliente>> Obtener(TCliente Cliente)
        {
            throw new NotImplementedException();
        }
    }
}
