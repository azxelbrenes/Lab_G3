using AutoMapper;
using Lab1_G3.Dominio;
using Lab1_G3.Dominio.EntidadesTipadas;
using Lab1_G3.Dominio.InterfacesAD;
using Lab1_G3.Dominio.InterfacesLN;
using Lab1_G3.Utilitarios;
using Lab1_G3_.Dominio.InterfacesLN;
using System;
using System.Collections.Generic;

namespace Lab1_G3.LogicaNegocios.Implementaciones
{
    public class SegUsuarioLN : IUsuarioLN
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;
        private readonly IMapper _mapper;

        public SegUsuarioLN(
            IUnidadTrabajoEF unidadTrabajo,
            IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _mapper = mapper;
        }

        public Respuesta<TSegUsuario> Insertar(TSegUsuario usuario)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(usuario.Usuario))
                    return new Respuesta<TSegUsuario>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Debe ingresar el usuario."
                    };

                if (string.IsNullOrWhiteSpace(usuario.CedulaUsuario))
                    return new Respuesta<TSegUsuario>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Debe ingresar la cédula."
                    };

                if (string.IsNullOrWhiteSpace(usuario.Nombre))
                    return new Respuesta<TSegUsuario>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Debe ingresar el nombre."
                    };

                if (string.IsNullOrWhiteSpace(usuario.Apellidos))
                    return new Respuesta<TSegUsuario>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Debe ingresar los apellidos."
                    };

                if (usuario.CodigoPerfil <= 0)
                    return new Respuesta<TSegUsuario>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Debe seleccionar un perfil."
                    };

                if (usuario.TipoCedulaId <= 0)
                    return new Respuesta<TSegUsuario>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Debe seleccionar un tipo de cédula."
                    };

                var entidad = _mapper.Map<SegUsuario>(usuario);

                var resultado = _unidadTrabajo.TSegUsuario.Insertar(entidad);

                if (resultado.blnIndicadorTransaccion)
                    _unidadTrabajo.Completar();

                return new Respuesta<TSegUsuario>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = usuario
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TSegUsuario>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<TSegUsuario> Modificar(TSegUsuario usuario)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(usuario.Usuario))
                    return new Respuesta<TSegUsuario>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Debe indicar el usuario."
                    };

                var entidad = _mapper.Map<SegUsuario>(usuario);

                var resultado = _unidadTrabajo.TSegUsuario.Modificar(entidad);

                if (resultado.blnIndicadorTransaccion)
                    _unidadTrabajo.Completar();

                return new Respuesta<TSegUsuario>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = usuario
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TSegUsuario>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<bool> Eliminar(TSegUsuario usuario)
        {
            try
            {
                var entidad = _unidadTrabajo.TSegUsuario.ObtenerEntidad(
                    x => x.Usuario == usuario.Usuario);

                if (!entidad.blnIndicadorTransaccion)
                {
                    return new Respuesta<bool>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Usuario no encontrado."
                    };
                }

                var resultado = _unidadTrabajo.TSegUsuario.Eliminar(
                    entidad.ValorRetorno);

                if (resultado.blnIndicadorTransaccion)
                    _unidadTrabajo.Completar();

                return resultado;
            }
            catch (Exception ex)
            {
                return new Respuesta<bool>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<TSegUsuario> Buscar(TSegUsuario usuario)
        {
            try
            {
                var resultado = _unidadTrabajo.TSegUsuario.ObtenerEntidad(
                    x => x.Usuario == usuario.Usuario);

                if (!resultado.blnIndicadorTransaccion)
                {
                    return new Respuesta<TSegUsuario>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Usuario no encontrado."
                    };
                }

                return new Respuesta<TSegUsuario>
                {
                    blnIndicadorTransaccion = true,
                    ValorRetorno = _mapper.Map<TSegUsuario>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TSegUsuario>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<IEnumerable<TSegUsuario>> Listar()
        {
            try
            {
                var resultado = _unidadTrabajo.TSegUsuario.Listar();

                return new Respuesta<IEnumerable<TSegUsuario>>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = _mapper.Map<IEnumerable<TSegUsuario>>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<IEnumerable<TSegUsuario>>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<IEnumerable<TSegUsuario>> Obtener(TSegUsuario usuario)
        {
            try
            {
                var resultado = _unidadTrabajo.TSegUsuario.Buscar(
                    x => x.Nombre.Contains(usuario.Nombre));

                return new Respuesta<IEnumerable<TSegUsuario>>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = _mapper.Map<IEnumerable<TSegUsuario>>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<IEnumerable<TSegUsuario>>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }
    }
}