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
    public class SegPerfilLN : ISegPerfil
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;
        private readonly IMapper _mapper;


    public SegPerfilLN(
        IUnidadTrabajoEF unidadTrabajo,
        IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _mapper = mapper;
        }

        public Respuesta<TSegPerfil> Insertar(TSegPerfil perfil)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(perfil.Descripcion))
                {
                    return new Respuesta<TSegPerfil>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Debe ingresar la descripción del perfil."
                    };
                }

                var entidad = _mapper.Map<SegPerfil>(perfil);

                var resultado = _unidadTrabajo.TSegPerfil.Insertar(entidad);

                if (resultado.blnIndicadorTransaccion)
                    _unidadTrabajo.Completar();

                return new Respuesta<TSegPerfil>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = perfil
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TSegPerfil>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<TSegPerfil> Modificar(TSegPerfil perfil)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(perfil.Descripcion))
                {
                    return new Respuesta<TSegPerfil>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Debe ingresar la descripción del perfil."
                    };
                }

                var entidad = _mapper.Map<SegPerfil>(perfil);

                var resultado = _unidadTrabajo.TSegPerfil.Modificar(entidad);

                if (resultado.blnIndicadorTransaccion)
                    _unidadTrabajo.Completar();

                return new Respuesta<TSegPerfil>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = perfil
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TSegPerfil>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<bool> Eliminar(TSegPerfil perfil)
        {
            try
            {
                var entidad = _unidadTrabajo.TSegPerfil.ObtenerEntidad(
                    x => x.CodigoPerfil == perfil.CodigoPerfil);

                if (!entidad.blnIndicadorTransaccion)
                {
                    return new Respuesta<bool>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Perfil no encontrado."
                    };
                }

                var resultado = _unidadTrabajo.TSegPerfil.Eliminar(
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

        public Respuesta<TSegPerfil> Buscar(TSegPerfil perfil)
        {
            try
            {
                var resultado = _unidadTrabajo.TSegPerfil.ObtenerEntidad(
                    x => x.CodigoPerfil == perfil.CodigoPerfil);

                if (!resultado.blnIndicadorTransaccion)
                {
                    return new Respuesta<TSegPerfil>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Perfil no encontrado."
                    };
                }

                return new Respuesta<TSegPerfil>
                {
                    blnIndicadorTransaccion = true,
                    ValorRetorno = _mapper.Map<TSegPerfil>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TSegPerfil>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<IEnumerable<TSegPerfil>> Listar()
        {
            try
            {
                var resultado = _unidadTrabajo.TSegPerfil.Listar();

                return new Respuesta<IEnumerable<TSegPerfil>>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = _mapper.Map<IEnumerable<TSegPerfil>>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<IEnumerable<TSegPerfil>>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<IEnumerable<TSegPerfil>> Obtener(TSegPerfil perfil)
        {
            try
            {
                var resultado = _unidadTrabajo.TSegPerfil.Buscar(
                    x => x.Descripcion.Contains(perfil.Descripcion));

                return new Respuesta<IEnumerable<TSegPerfil>>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = _mapper.Map<IEnumerable<TSegPerfil>>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<IEnumerable<TSegPerfil>>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }
    }


}

