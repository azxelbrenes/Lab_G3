using Lab1_G3.Dominio.EntidadesTipadas;
using Lab1_G3.Utilitarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_G3_.Dominio.InterfacesLN
{
   public interface ITipoCedulaLN
    {
        Respuesta<TTipoCedula> Insertar(TTipoCedula tipoCedula);
        Respuesta<TTipoCedula> Modificar(TTipoCedula tipoCedula);
        Respuesta<bool> Eliminar(TTipoCedula tipoCedula);
        Respuesta<IEnumerable<TTipoCedula>> Obtener(TTipoCedula tipoCedula);
        Respuesta<TTipoCedula> Buscar(TTipoCedula tipoCedula);
        Respuesta<IEnumerable<TTipoCedula>> Listar();
    }
}
