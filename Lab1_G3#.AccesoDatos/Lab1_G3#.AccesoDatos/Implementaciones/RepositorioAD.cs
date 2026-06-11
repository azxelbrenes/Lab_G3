using Lab1_G3.Dominio.InterfacesAD;
using Lab1_G3.Utilitarios;
using Lab1_G3_.AccesoDatos.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Lab1_G3_.AccesoDatos.Implementaciones
{
    public class RepositorioAD<T> : IRepositorioAD<T> where T : class
    {
        private readonly Lab1_G3Context _contexto;
        private readonly DbSet<T> _dbSet;

        public RepositorioAD(Lab1_G3Context contexto)
        {
            _contexto = contexto;
            _dbSet = _contexto.Set<T>();
        }

        public Respuesta<IEnumerable<T>> Listar(List<string>? includes = null)
        {
            Respuesta<IEnumerable<T>> respuesta = new Respuesta<IEnumerable<T>>();

            try
            {
                IQueryable<T> query = _dbSet.AsQueryable();

                if (includes != null && includes.Any())
                {
                    foreach (var include in includes)
                    {
                        query = query.Include(include);
                    }
                }

                var resultado = query.ToList();

                respuesta.blnIndicadorTransaccion = true;
                respuesta.strTituloRespuesta = "Transacción Exitosa";
                respuesta.strMensajeRespuesta = "Listado obtenido correctamente.";
                respuesta.enuTipoMensaje = 1;
                respuesta.ValorRetorno = resultado;
                respuesta.xCantidadItems = resultado.Count.ToString();
            }
            catch (Exception ex)
            {
                respuesta.blnIndicadorTransaccion = false;
                respuesta.strTituloRespuesta = "Error";
                respuesta.strMensajeRespuesta = "Error al listar registros. " + ex.Message;
                respuesta.enuTipoMensaje = 4;
                respuesta.ValorRetorno = null;
            }

            return respuesta;
        }

        public Respuesta<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicado, List<string>? includes = null)
        {
            Respuesta<IEnumerable<T>> respuesta = new Respuesta<IEnumerable<T>>();

            try
            {
                IQueryable<T> query = _dbSet.Where(predicado);

                if (includes != null && includes.Any())
                {
                    foreach (var include in includes)
                    {
                        query = query.Include(include);
                    }
                }

                var resultado = query.ToList();

                respuesta.blnIndicadorTransaccion = true;
                respuesta.strTituloRespuesta = "Transacción Exitosa";
                respuesta.strMensajeRespuesta = "Consulta realizada correctamente.";
                respuesta.enuTipoMensaje = 1;
                respuesta.ValorRetorno = resultado;
                respuesta.xCantidadItems = resultado.Count.ToString();
            }
            catch (Exception ex)
            {
                respuesta.blnIndicadorTransaccion = false;
                respuesta.strTituloRespuesta = "Error";
                respuesta.strMensajeRespuesta = "Error al buscar registros. " + ex.Message;
                respuesta.enuTipoMensaje = 4;
                respuesta.ValorRetorno = null;
            }

            return respuesta;
        }

        public Respuesta<T> ObtenerEntidad(Expression<Func<T, bool>> predicado, List<string>? includes = null)
        {
            Respuesta<T> respuesta = new Respuesta<T>();

            try
            {
                IQueryable<T> query = _dbSet.Where(predicado);

                if (includes != null && includes.Any())
                {
                    foreach (var include in includes)
                    {
                        query = query.Include(include);
                    }
                }

                var resultado = query.FirstOrDefault();

                if (resultado == null)
                {
                    respuesta.blnIndicadorTransaccion = false;
                    respuesta.strTituloRespuesta = "Validación";
                    respuesta.strMensajeRespuesta = "No se encontró el registro solicitado.";
                    respuesta.enuTipoMensaje = 3;
                    respuesta.ValorRetorno = null;
                    return respuesta;
                }

                respuesta.blnIndicadorTransaccion = true;
                respuesta.strTituloRespuesta = "Transacción Exitosa";
                respuesta.strMensajeRespuesta = "Registro obtenido correctamente.";
                respuesta.enuTipoMensaje = 1;
                respuesta.ValorRetorno = resultado;
            }
            catch (Exception ex)
            {
                respuesta.blnIndicadorTransaccion = false;
                respuesta.strTituloRespuesta = "Error";
                respuesta.strMensajeRespuesta = "Error al obtener el registro. " + ex.Message;
                respuesta.enuTipoMensaje = 4;
                respuesta.ValorRetorno = null;
            }

            return respuesta;
        }

        public Respuesta<T> Insertar(T entidad)
        {
            Respuesta<T> respuesta = new Respuesta<T>();

            try
            {
                _dbSet.Add(entidad);

                respuesta.blnIndicadorTransaccion = true;
                respuesta.strTituloRespuesta = "Transacción Exitosa";
                respuesta.strMensajeRespuesta = "Registro insertado correctamente.";
                respuesta.enuTipoMensaje = 1;
                respuesta.ValorRetorno = entidad;
            }
            catch (Exception ex)
            {
                respuesta.blnIndicadorTransaccion = false;
                respuesta.strTituloRespuesta = "Error";
                respuesta.strMensajeRespuesta = "Error al insertar el registro. " + ex.Message;
                respuesta.enuTipoMensaje = 4;
                respuesta.ValorRetorno = null;
            }

            return respuesta;
        }

        public Respuesta<T> Modificar(T entidad)
        {
            Respuesta<T> respuesta = new Respuesta<T>();

            try
            {
                _dbSet.Update(entidad);

                respuesta.blnIndicadorTransaccion = true;
                respuesta.strTituloRespuesta = "Transacción Exitosa";
                respuesta.strMensajeRespuesta = "Registro modificado correctamente.";
                respuesta.enuTipoMensaje = 1;
                respuesta.ValorRetorno = entidad;
            }
            catch (Exception ex)
            {
                respuesta.blnIndicadorTransaccion = false;
                respuesta.strTituloRespuesta = "Error";
                respuesta.strMensajeRespuesta = "Error al modificar el registro. " + ex.Message;
                respuesta.enuTipoMensaje = 4;
                respuesta.ValorRetorno = null;
            }

            return respuesta;
        }

        public Respuesta<bool> Eliminar(T entidad)
        {
            Respuesta<bool> respuesta = new Respuesta<bool>();

            try
            {
                _dbSet.Remove(entidad);

                respuesta.blnIndicadorTransaccion = true;
                respuesta.strTituloRespuesta = "Transacción Exitosa";
                respuesta.strMensajeRespuesta = "Registro eliminado correctamente.";
                respuesta.enuTipoMensaje = 1;
                respuesta.ValorRetorno = true;
            }
            catch (Exception ex)
            {
                respuesta.blnIndicadorTransaccion = false;
                respuesta.strTituloRespuesta = "Error";
                respuesta.strMensajeRespuesta = "Error al eliminar el registro. " + ex.Message;
                respuesta.enuTipoMensaje = 4;
                respuesta.ValorRetorno = false;
            }

            return respuesta;
        }

        public Respuesta<int> Contar(Expression<Func<T, bool>> predicado)
        {
            Respuesta<int> respuesta = new Respuesta<int>();

            try
            {
                var cantidad = _dbSet.Count(predicado);

                respuesta.blnIndicadorTransaccion = true;
                respuesta.strTituloRespuesta = "Transacción Exitosa";
                respuesta.strMensajeRespuesta = "Conteo realizado correctamente.";
                respuesta.enuTipoMensaje = 1;
                respuesta.ValorRetorno = cantidad;
                respuesta.xCantidadItems = cantidad.ToString();
            }
            catch (Exception ex)
            {
                respuesta.blnIndicadorTransaccion = false;
                respuesta.strTituloRespuesta = "Error";
                respuesta.strMensajeRespuesta = "Error al contar registros. " + ex.Message;
                respuesta.enuTipoMensaje = 4;
                respuesta.ValorRetorno = 0;
            }

            return respuesta;
        }
    }

}
