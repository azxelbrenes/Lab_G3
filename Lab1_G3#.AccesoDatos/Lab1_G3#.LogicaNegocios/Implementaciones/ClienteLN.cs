using AutoMapper;
using Lab1_G3.Dominio;
using Lab1_G3.Dominio.EntidadesTipadas;
using Lab1_G3.Dominio.InterfacesAD;
using Lab1_G3.Dominio.InterfacesLN;
using Lab1_G3.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1_G3.LogicaNegocios.Implementaciones
{
    public class ClienteLN : IClienteLN
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;
        private readonly IMapper _mapper;


    public ClienteLN(
        IUnidadTrabajoEF unidadTrabajo,
        IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _mapper = mapper;
        }

        public Respuesta<TCliente> Insertar(TCliente cliente)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cliente.Nombre))
                {
                    return new Respuesta<TCliente>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Debe ingresar el nombre del cliente."
                    };
                }

                var entidad = _mapper.Map<Cliente>(cliente);

                var resultado = _unidadTrabajo.TCliente.Insertar(entidad);

                if (resultado.blnIndicadorTransaccion)
                    _unidadTrabajo.Completar();

                return new Respuesta<TCliente>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = cliente
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TCliente>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<TCliente> Modificar(TCliente cliente)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cliente.Nombre))
                {
                    return new Respuesta<TCliente>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Debe ingresar el nombre del cliente."
                    };
                }

                var entidad = _mapper.Map<Cliente>(cliente);

                var resultado = _unidadTrabajo.TCliente.Modificar(entidad);

                if (resultado.blnIndicadorTransaccion)
                    _unidadTrabajo.Completar();

                return new Respuesta<TCliente>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = cliente
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TCliente>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<bool> Eliminar(TCliente cliente)
        {
            try
            {
                var entidad = _unidadTrabajo.TCliente.ObtenerEntidad(
                    x => x.ClienteId == cliente.ClienteId);

                if (!entidad.blnIndicadorTransaccion)
                {
                    return new Respuesta<bool>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Cliente no encontrado."
                    };
                }

                var resultado = _unidadTrabajo.TCliente.Eliminar(
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

        public Respuesta<TCliente> Buscar(TCliente cliente)
        {
            try
            {
                var resultado = _unidadTrabajo.TCliente.ObtenerEntidad(
                    x => x.ClienteId == cliente.ClienteId);

                if (!resultado.blnIndicadorTransaccion)
                {
                    return new Respuesta<TCliente>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Cliente no encontrado."
                    };
                }

                return new Respuesta<TCliente>
                {
                    blnIndicadorTransaccion = true,
                    ValorRetorno = _mapper.Map<TCliente>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TCliente>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<IEnumerable<TCliente>> Listar()
        {
            try
            {
                var resultado = _unidadTrabajo.TCliente.Listar();

                return new Respuesta<IEnumerable<TCliente>>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = _mapper.Map<IEnumerable<TCliente>>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<IEnumerable<TCliente>>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<IEnumerable<TCliente>> Obtener(TCliente cliente)
        {
            try
            {
                var resultado = _unidadTrabajo.TCliente.Buscar(
                    x => x.Nombre.Contains(cliente.Nombre));

                return new Respuesta<IEnumerable<TCliente>>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = _mapper.Map<IEnumerable<TCliente>>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<IEnumerable<TCliente>>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }
    }

}
