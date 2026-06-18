using AutoMapper;
using Lab1_G3.Dominio;

using Lab1_G3.Dominio.EntidadesTipadas;
using Lab1_G3.Dominio.InterfacesAD;
using Lab1_G3.Dominio.InterfacesLN;
using Lab1_G3.Utilitarios;
using System;
using System.Collections.Generic;

namespace Lab1_G3.LogicaNegocios.Implementaciones
{
    public class PedidoLN : IPedidoLN
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;
        private readonly IMapper _mapper;


    public PedidoLN(
        IUnidadTrabajoEF unidadTrabajo,
        IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _mapper = mapper;
        }

        public Respuesta<TPedido> Insertar(TPedido pedido)
        {
            try
            {
                if (pedido.ClienteId <= 0)
                {
                    return new Respuesta<TPedido>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Debe seleccionar un cliente."
                    };
                }

                var entidad = _mapper.Map<Pedido>(pedido);

                var resultado = _unidadTrabajo.TPedido.Insertar(entidad);

                if (resultado.blnIndicadorTransaccion)
                    _unidadTrabajo.Completar();

                return new Respuesta<TPedido>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = pedido
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TPedido>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<TPedido> Modificar(TPedido pedido)
        {
            try
            {
                if (pedido.ClienteId <= 0)
                {
                    return new Respuesta<TPedido>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Debe seleccionar un cliente."
                    };
                }

                var entidad = _mapper.Map<Pedido>(pedido);

                var resultado = _unidadTrabajo.TPedido.Modificar(entidad);

                if (resultado.blnIndicadorTransaccion)
                    _unidadTrabajo.Completar();

                return new Respuesta<TPedido>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = pedido
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TPedido>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<bool> Eliminar(TPedido pedido)
        {
            try
            {
                var entidad = _unidadTrabajo.TPedido.ObtenerEntidad(
                    x => x.PedidoId == pedido.PedidoId);

                if (!entidad.blnIndicadorTransaccion)
                {
                    return new Respuesta<bool>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Pedido no encontrado."
                    };
                }

                var resultado = _unidadTrabajo.TPedido.Eliminar(
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

        public Respuesta<TPedido> Buscar(TPedido pedido)
        {
            try
            {
                var resultado = _unidadTrabajo.TPedido.ObtenerEntidad(
                    x => x.PedidoId == pedido.PedidoId);

                if (!resultado.blnIndicadorTransaccion)
                {
                    return new Respuesta<TPedido>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Pedido no encontrado."
                    };
                }

                return new Respuesta<TPedido>
                {
                    blnIndicadorTransaccion = true,
                    ValorRetorno = _mapper.Map<TPedido>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TPedido>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<IEnumerable<TPedido>> Listar()
        {
            try
            {
                var resultado = _unidadTrabajo.TPedido.Listar();

                return new Respuesta<IEnumerable<TPedido>>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = _mapper.Map<IEnumerable<TPedido>>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<IEnumerable<TPedido>>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<IEnumerable<TPedido>> Obtener(TPedido pedido)
        {
            try
            {
                var resultado = _unidadTrabajo.TPedido.Buscar(
                    x => x.ClienteId == pedido.ClienteId);

                return new Respuesta<IEnumerable<TPedido>>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = _mapper.Map<IEnumerable<TPedido>>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<IEnumerable<TPedido>>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }
    }


}
