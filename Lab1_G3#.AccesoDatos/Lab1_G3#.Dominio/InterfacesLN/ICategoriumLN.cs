using Lab1_G3.Dominio.EntidadesTipadas;
using Lab1_G3.Utilitarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_G3_.Dominio.InterfacesLN
{
    public interface ICategoriumLN
    {
        Respuesta<TCategorium> Insertar(TCategorium Categorium);
        Respuesta<TCategorium> Modificar(TCategorium Categorium);
        Respuesta<bool> Eliminar(TCategorium Categorium);
        Respuesta<IEnumerable<TCategorium>> Obtener(TCategorium Categorium);
        Respuesta<TCategorium> Buscar(TCategorium Categorium);
        Respuesta<IEnumerable<TCategorium>> Listar();
    }
}
