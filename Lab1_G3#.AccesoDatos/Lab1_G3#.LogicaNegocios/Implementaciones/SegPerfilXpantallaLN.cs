using AutoMapper;
using Lab1_G3.Dominio;
using Lab1_G3.Dominio.EntidadesTipadas;
using Lab1_G3.Dominio.InterfacesAD;
using Lab1_G3_.Dominio.InterfacesLN;
using Lab1_G3.Utilitarios;
using System;
using System.Collections.Generic;

namespace Lab1_G3.LogicaNegocios.Implementaciones
{
    public class SegPerfilXPantallaLN : ISegPerfilXPantallaLN
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;
        private readonly IMapper _mapper;


    public SegPerfilXPantallaLN(
        IUnidadTrabajoEF unidadTrabajo,
        IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _mapper = mapper;
        }

        public Respuesta<TSegPerfilXpantalla> Insertar(TSegPerfilXpantalla segPerfilXPantalla)
        {
            try
            {
                if (segPerfilXPantalla.CodigoPerfil <= 0)
                {
                    return new Respuesta<TSegPerfilXpantalla>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Debe seleccionar un perfil."
                    };
                }

                if (segPerfilXPantalla.CodigoPantalla <= 0)
                {
                    return new Respuesta<TSegPerfilXpantalla>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Debe seleccionar una pantalla."
                    };
                }

                var entidad = _mapper.Map<SegPerfilXpantalla>(segPerfilXPantalla);

                var resultado = _unidadTrabajo.TSegPerfilXPantalla.Insertar(entidad);

                if (resultado.blnIndicadorTransaccion)
                    _unidadTrabajo.Completar();

                return new Respuesta<TSegPerfilXpantalla>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = segPerfilXPantalla
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TSegPerfilXpantalla>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<TSegPerfilXpantalla> Modificar(TSegPerfilXpantalla segPerfilXPantalla)
        {
            try
            {
                if (segPerfilXPantalla.CodigoPerfil <= 0)
                {
                    return new Respuesta<TSegPerfilXpantalla>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Debe seleccionar un perfil."
                    };
                }

                if (segPerfilXPantalla.CodigoPantalla <= 0)
                {
                    return new Respuesta<TSegPerfilXpantalla>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Debe seleccionar una pantalla."
                    };
                }

                var entidad = _mapper.Map<SegPerfilXpantalla>(segPerfilXPantalla);

                var resultado = _unidadTrabajo.TSegPerfilXPantalla.Modificar(entidad);

                if (resultado.blnIndicadorTransaccion)
                    _unidadTrabajo.Completar();

                return new Respuesta<TSegPerfilXpantalla>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = segPerfilXPantalla
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TSegPerfilXpantalla>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<bool> Eliminar(TSegPerfilXpantalla segPerfilXPantalla)
        {
            try
            {
                var entidad = _unidadTrabajo.TSegPerfilXPantalla.ObtenerEntidad(
                    x => x.PerfilXpantallaId == segPerfilXPantalla.PerfilXpantallaId);

                if (!entidad.blnIndicadorTransaccion)
                {
                    return new Respuesta<bool>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Registro no encontrado."
                    };
                }

                var resultado = _unidadTrabajo.TSegPerfilXPantalla.Eliminar(
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

        public Respuesta<TSegPerfilXpantalla> Buscar(TSegPerfilXpantalla segPerfilXPantalla)
        {
            try
            {
                var resultado = _unidadTrabajo.TSegPerfilXPantalla.ObtenerEntidad(
                    x => x.PerfilXpantallaId == segPerfilXPantalla.PerfilXpantallaId);

                if (!resultado.blnIndicadorTransaccion)
                {
                    return new Respuesta<TSegPerfilXpantalla>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Registro no encontrado."
                    };
                }

                return new Respuesta<TSegPerfilXpantalla>
                {
                    blnIndicadorTransaccion = true,
                    ValorRetorno = _mapper.Map<TSegPerfilXpantalla>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TSegPerfilXpantalla>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<IEnumerable<TSegPerfilXpantalla>> Listar()
        {
            try
            {
                var resultado = _unidadTrabajo.TSegPerfilXPantalla.Listar();

                return new Respuesta<IEnumerable<TSegPerfilXpantalla>>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = _mapper.Map<IEnumerable<TSegPerfilXpantalla>>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<IEnumerable<TSegPerfilXpantalla>>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<IEnumerable<TSegPerfilXpantalla>> Obtener(TSegPerfilXpantalla segPerfilXPantalla)
        {
            try
            {
                var resultado = _unidadTrabajo.TSegPerfilXPantalla.Buscar(
                    x => x.CodigoPerfil == segPerfilXPantalla.CodigoPerfil);

                return new Respuesta<IEnumerable<TSegPerfilXpantalla>>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = _mapper.Map<IEnumerable<TSegPerfilXpantalla>>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<IEnumerable<TSegPerfilXpantalla>>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }
    }


}
