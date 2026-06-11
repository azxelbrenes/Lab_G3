using Lab1_G3.Dominio.EntidadesTipadas;
using Lab1_G3.Utilitarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_G3_.Dominio.InterfacesLN
{
    public interface IUsuarioLN
    {
        Respuesta<TSegUsuario> Insertar(TSegUsuario segUsuario);
        Respuesta<TSegUsuario> Modificar(TSegUsuario segUsuario);
        Respuesta<bool> Eliminar(TSegUsuario segUsuario);
        Respuesta<IEnumerable<TSegUsuario>> Obtener(TSegUsuario segUsuario);
        Respuesta<TSegUsuario> Buscar(TSegUsuario segUsuario);
        Respuesta<IEnumerable<TSegUsuario>> Listar();
    }
}
