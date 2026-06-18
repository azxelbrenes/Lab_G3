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
    public class DetallesPedidoLN : IDetallePedidoLN
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;
        private readonly IMapper _mapper;


    public DetallesPedidoLN(
        IUnidadTrabajoEF unidadTrabajo,
        IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _mapper = mapper;
        }

        public Respuesta<TDetallesPedido> Insertar(TDetallesPedido detalle)
        {
            try
            {
                if (detalle.Cantidad <= 0)
                {
                    return new Respuesta<TDetallesPedido>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "La cantidad debe ser mayor a cero."
                    };
                }

                var entidad = _mapper.Map<DetallesPedido>(detalle);

                var resultado = _unidadTrabajo.TDetallesPedido.Insertar(entidad);

                if (resultado.blnIndicadorTransaccion)
                    _unidadTrabajo.Completar();

                return new Respuesta<TDetallesPedido>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = detalle
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TDetallesPedido>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<TDetallesPedido> Modificar(TDetallesPedido detalle)
        {
            try
            {
                if (detalle.Cantidad <= 0)
                {
                    return new Respuesta<TDetallesPedido>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "La cantidad debe ser mayor a cero."
                    };
                }

                var entidad = _mapper.Map<DetallesPedido>(detalle);

                var resultado = _unidadTrabajo.TDetallesPedido.Modificar(entidad);

                if (resultado.blnIndicadorTransaccion)
                    _unidadTrabajo.Completar();

                return new Respuesta<TDetallesPedido>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = detalle
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TDetallesPedido>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<bool> Eliminar(TDetallesPedido detalle)
        {
            try
            {
                var entidad = _unidadTrabajo.TDetallesPedido.ObtenerEntidad(
                    x => x.DetalleId == detalle.DetalleId);

                if (!entidad.blnIndicadorTransaccion)
                {
                    return new Respuesta<bool>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Detalle no encontrado."
                    };
                }

                var resultado = _unidadTrabajo.TDetallesPedido.Eliminar(
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

        public Respuesta<TDetallesPedido> Buscar(TDetallesPedido detalle)
        {
            try
            {
                var resultado = _unidadTrabajo.TDetallesPedido.ObtenerEntidad(
                    x => x.DetalleId == detalle.DetalleId);

                if (!resultado.blnIndicadorTransaccion)
                {
                    return new Respuesta<TDetallesPedido>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Detalle no encontrado."
                    };
                }

                return new Respuesta<TDetallesPedido>
                {
                    blnIndicadorTransaccion = true,
                    ValorRetorno = _mapper.Map<TDetallesPedido>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TDetallesPedido>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<IEnumerable<TDetallesPedido>> Listar()
        {
            try
            {
                var resultado = _unidadTrabajo.TDetallesPedido.Listar();

                return new Respuesta<IEnumerable<TDetallesPedido>>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = _mapper.Map<IEnumerable<TDetallesPedido>>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<IEnumerable<TDetallesPedido>>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<IEnumerable<TDetallesPedido>> Obtener(TDetallesPedido detalle)
        {
            try
            {
                var resultado = _unidadTrabajo.TDetallesPedido.Buscar(
                    x => x.PedidoId == detalle.PedidoId);

                return new Respuesta<IEnumerable<TDetallesPedido>>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = _mapper.Map<IEnumerable<TDetallesPedido>>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<IEnumerable<TDetallesPedido>>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }
    }


}
