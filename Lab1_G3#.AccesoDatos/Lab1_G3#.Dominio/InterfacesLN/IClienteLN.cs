using Lab1_G3.Dominio.EntidadesTipadas;
using Lab1_G3.Utilitarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_G3.Dominio.InterfacesLN
{
   public interface IClienteLN
    {
        Respuesta<TCliente> Insertar(TCliente Cliente);
        Respuesta<TCliente> Modificar(TCliente Cliente);
        Respuesta<bool> Eliminar(TCliente Cliente);
        Respuesta<IEnumerable<TCliente>> Obtener(TCliente Cliente);
        Respuesta<TCliente> Buscar(TCliente Cliente);
        Respuesta<IEnumerable<TCliente>> Listar();
    }
}
