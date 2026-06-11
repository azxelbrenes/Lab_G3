using Lab1_G3.Dominio.EntidadesTipadas;
using Lab1_G3.Utilitarios;
using Lab1_G3_.Dominio.InterfacesLN;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_G3_.LogicaNegocios.Implementaciones
{
    public class SegUsuarioLN : IUsuarioLN
    {
        public Respuesta<TSegUsuario> Buscar(TSegUsuario segUsuario)
        {
            throw new NotImplementedException();
        }

        public Respuesta<bool> Eliminar(TSegUsuario segUsuario)
        {
            throw new NotImplementedException();
        }

        public Respuesta<TSegUsuario> Insertar(TSegUsuario segUsuario)
        {
            throw new NotImplementedException();
        }

        public Respuesta<IEnumerable<TSegUsuario>> Listar()
        {
            throw new NotImplementedException();
        }

        public Respuesta<TSegUsuario> Modificar(TSegUsuario segUsuario)
        {
            throw new NotImplementedException();
        }

        public Respuesta<IEnumerable<TSegUsuario>> Obtener(TSegUsuario segUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
