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
    public class SegPantallaLN : ISegPantallaLN
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;
        private readonly IMapper _mapper;


    public SegPantallaLN(
        IUnidadTrabajoEF unidadTrabajo,
        IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _mapper = mapper;
        }

        public Respuesta<TSegPantalla> Insertar(TSegPantalla pantalla)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(pantalla.NombrePantalla))
                {
                    return new Respuesta<TSegPantalla>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Debe ingresar el nombre de la pantalla."
                    };
                }

                var entidad = _mapper.Map<SegPantalla>(pantalla);

                var resultado = _unidadTrabajo.TSegPantalla.Insertar(entidad);

                if (resultado.blnIndicadorTransaccion)
                    _unidadTrabajo.Completar();

                return new Respuesta<TSegPantalla>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = pantalla
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TSegPantalla>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<TSegPantalla> Modificar(TSegPantalla pantalla)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(pantalla.NombrePantalla))
                {
                    return new Respuesta<TSegPantalla>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Debe ingresar el nombre de la pantalla."
                    };
                }

                var entidad = _mapper.Map<SegPantalla>(pantalla);

                var resultado = _unidadTrabajo.TSegPantalla.Modificar(entidad);

                if (resultado.blnIndicadorTransaccion)
                    _unidadTrabajo.Completar();

                return new Respuesta<TSegPantalla>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = pantalla
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TSegPantalla>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<bool> Eliminar(TSegPantalla pantalla)
        {
            try
            {
                var entidad = _unidadTrabajo.TSegPantalla.ObtenerEntidad(
                    x => x.CodigoPantalla == pantalla.CodigoPantalla);

                if (!entidad.blnIndicadorTransaccion)
                {
                    return new Respuesta<bool>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Pantalla no encontrada."
                    };
                }

                var resultado = _unidadTrabajo.TSegPantalla.Eliminar(
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

        public Respuesta<TSegPantalla> Buscar(TSegPantalla pantalla)
        {
            try
            {
                var resultado = _unidadTrabajo.TSegPantalla.ObtenerEntidad(
                    x => x.CodigoPantalla == pantalla.CodigoPantalla);

                if (!resultado.blnIndicadorTransaccion)
                {
                    return new Respuesta<TSegPantalla>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Pantalla no encontrada."
                    };
                }

                return new Respuesta<TSegPantalla>
                {
                    blnIndicadorTransaccion = true,
                    ValorRetorno = _mapper.Map<TSegPantalla>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TSegPantalla>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<IEnumerable<TSegPantalla>> Listar()
        {
            try
            {
                var resultado = _unidadTrabajo.TSegPantalla.Listar();

                return new Respuesta<IEnumerable<TSegPantalla>>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = _mapper.Map<IEnumerable<TSegPantalla>>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<IEnumerable<TSegPantalla>>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<IEnumerable<TSegPantalla>> Obtener(TSegPantalla pantalla)
        {
            try
            {
                var resultado = _unidadTrabajo.TSegPantalla.Buscar(
                    x => x.NombrePantalla.Contains(pantalla.NombrePantalla));

                return new Respuesta<IEnumerable<TSegPantalla>>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = _mapper.Map<IEnumerable<TSegPantalla>>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<IEnumerable<TSegPantalla>>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }
    }


}
