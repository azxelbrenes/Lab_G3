using Lab1_G3.Dominio;
using Lab1_G3.Dominio.InterfacesAD;
using Lab1_G3_.AccesoDatos.Model;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_G3_.AccesoDatos.Implementaciones
{
    public class UnidadTrabajoEF : IUnidadTrabajoEF
    {
        private readonly Lab1_G3Context _contexto;
        private IDbContextTransaction? _transaccion;

        public IRepositorioAD<Categorium> TCategorium { get; }
        public IRepositorioAD<Cliente> TCliente { get; }
        public IRepositorioAD<DetallesPedido> TDetallesPedido { get; }
        public IRepositorioAD<Pedido> TPedido { get; }
        public IRepositorioAD<Producto> TProducto { get; }
        public IRepositorioAD<SegPantalla> TSegPantalla { get; }
        public IRepositorioAD<SegPerfil> TSegPerfil { get; }
        public IRepositorioAD<SegPerfilXpantalla> TSegPerfilXPantalla { get; }
        public IRepositorioAD<SegUsuario> TSegUsuario { get; }
        public IRepositorioAD<TipoCedula> TTipoCedula { get; }

        public UnidadTrabajoEF(Lab1_G3Context contexto)
        {
            _contexto = contexto;

            TCategorium = new RepositorioAD<Categorium>(_contexto);
            TCliente = new RepositorioAD<Cliente>(_contexto);
            TDetallesPedido = new RepositorioAD<DetallesPedido>(_contexto);
            TPedido = new RepositorioAD<Pedido>(_contexto);
            TProducto = new RepositorioAD<Producto>(_contexto);
            TSegPantalla = new RepositorioAD<SegPantalla>(_contexto);
            TSegPerfil = new RepositorioAD<SegPerfil>(_contexto);
            TSegPerfilXPantalla = new RepositorioAD<SegPerfilXpantalla>(_contexto);
            TSegUsuario = new RepositorioAD<SegUsuario>(_contexto);
            TTipoCedula = new RepositorioAD<TipoCedula>(_contexto);
        }

        public void EmpezarTransaccion()
        {
            if (_transaccion == null)
            {
                _transaccion = _contexto.Database.BeginTransaction();
            }
        }

        public void Completar()
        {
            _contexto.SaveChanges();
        }

        public void CompletarTran()
        {
            try
            {
                _transaccion?.Commit();
            }
            finally
            {
                _transaccion?.Dispose();
                _transaccion = null;
            }
        }

        public void Rollback()
        {
            try
            {
                _transaccion?.Rollback();
            }
            finally
            {
                _transaccion?.Dispose();
                _transaccion = null;
            }
        }
    }
}
