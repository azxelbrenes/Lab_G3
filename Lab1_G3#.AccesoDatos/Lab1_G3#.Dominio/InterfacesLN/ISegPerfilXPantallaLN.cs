using Lab1_G3.Dominio;
using Lab1_G3.Dominio.EntidadesTipadas;
using Lab1_G3.Utilitarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_G3_.Dominio.InterfacesLN
{
    public interface ISegPerfilXPantallaLN
    {
        Respuesta<TSegPerfilXpantalla> Insertar(TSegPerfilXpantalla segPerfilXPantalla);
        Respuesta<TSegPerfilXpantalla> Modificar(TSegPerfilXpantalla segPerfilXPantalla);
        Respuesta<bool> Eliminar(TSegPerfilXpantalla segPerfilXPantalla);
        Respuesta<IEnumerable<TSegPerfilXpantalla>> Obtener(TSegPerfilXpantalla segPerfilXPantalla);
        Respuesta<TSegPerfilXpantalla> Buscar(TSegPerfilXpantalla segPerfilXPantalla);
        Respuesta<IEnumerable<TSegPerfilXpantalla>> Listar();
    }
}
