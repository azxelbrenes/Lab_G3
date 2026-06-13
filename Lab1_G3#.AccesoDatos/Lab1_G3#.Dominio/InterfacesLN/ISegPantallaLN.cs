using Lab1_G3.Dominio.EntidadesTipadas;
using Lab1_G3.Utilitarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_G3_.Dominio.InterfacesLN
{
    public interface ISegPantallaLN
    {
        Respuesta<TSegPantalla> Insertar(TSegPantalla segPantalla);
        Respuesta<TSegPantalla> Modificar(TSegPantalla segPantalla);
        Respuesta<bool> Eliminar(TSegPantalla segPantalla);
        Respuesta<IEnumerable<TSegPantalla>> Obtener(TSegPantalla segPantalla);
        Respuesta<TSegPantalla> Buscar(TSegPantalla segPantalla);
        Respuesta<IEnumerable<TSegPantalla>> Listar();
    }
}
