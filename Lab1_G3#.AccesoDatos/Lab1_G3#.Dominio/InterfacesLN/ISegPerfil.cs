using Lab1_G3.Dominio.EntidadesTipadas;
using Lab1_G3.Utilitarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_G3_.Dominio.InterfacesLN
{
    public interface ISegPerfil
    {
        Respuesta<TSegPerfil> Insertar(TSegPerfil segPerfil);
        Respuesta<TSegPerfil> Modificar(TSegPerfil segPerfil);
        Respuesta<bool> Eliminar(TSegPerfil segPerfil);
        Respuesta<IEnumerable<TSegPerfil>> Obtener(TSegPerfil segPerfil);
        Respuesta<TSegPerfil> Buscar(TSegPerfil segPerfil);
        Respuesta<IEnumerable<TSegPerfil>> Listar();
    }
}
