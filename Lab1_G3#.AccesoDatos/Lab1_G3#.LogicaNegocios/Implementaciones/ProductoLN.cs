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
    public class ProductoLN : IProductoLN
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;
        private readonly IMapper _mapper;


    public ProductoLN(
        IUnidadTrabajoEF unidadTrabajo,
        IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _mapper = mapper;
        }

        public Respuesta<TProducto> Insertar(TProducto producto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(producto.Nombre))
                {
                    return new Respuesta<TProducto>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Debe ingresar el nombre del producto."
                    };
                }

                if (producto.Precio <= 0)
                {
                    return new Respuesta<TProducto>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "El precio debe ser mayor a cero."
                    };
                }

                var entidad = _mapper.Map<Producto>(producto);

                var resultado = _unidadTrabajo.TProducto.Insertar(entidad);

                if (resultado.blnIndicadorTransaccion)
                    _unidadTrabajo.Completar();

                return new Respuesta<TProducto>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = producto
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TProducto>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<TProducto> Modificar(TProducto producto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(producto.Nombre))
                {
                    return new Respuesta<TProducto>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Debe ingresar el nombre del producto."
                    };
                }

                if (producto.Precio <= 0)
                {
                    return new Respuesta<TProducto>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "El precio debe ser mayor a cero."
                    };
                }

                var entidad = _mapper.Map<Producto>(producto);

                var resultado = _unidadTrabajo.TProducto.Modificar(entidad);

                if (resultado.blnIndicadorTransaccion)
                    _unidadTrabajo.Completar();

                return new Respuesta<TProducto>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = producto
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TProducto>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<bool> Eliminar(TProducto producto)
        {
            try
            {
                var entidad = _unidadTrabajo.TProducto.ObtenerEntidad(
                    x => x.ProductoId == producto.ProductoId);

                if (!entidad.blnIndicadorTransaccion)
                {
                    return new Respuesta<bool>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Producto no encontrado."
                    };
                }

                var resultado = _unidadTrabajo.TProducto.Eliminar(
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

        public Respuesta<TProducto> Buscar(TProducto producto)
        {
            try
            {
                var resultado = _unidadTrabajo.TProducto.ObtenerEntidad(
                    x => x.ProductoId == producto.ProductoId);

                if (!resultado.blnIndicadorTransaccion)
                {
                    return new Respuesta<TProducto>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Producto no encontrado."
                    };
                }

                return new Respuesta<TProducto>
                {
                    blnIndicadorTransaccion = true,
                    ValorRetorno = _mapper.Map<TProducto>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TProducto>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<IEnumerable<TProducto>> Listar()
        {
            try
            {
                var resultado = _unidadTrabajo.TProducto.Listar();

                return new Respuesta<IEnumerable<TProducto>>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = _mapper.Map<IEnumerable<TProducto>>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<IEnumerable<TProducto>>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<IEnumerable<TProducto>> Obtener(TProducto producto)
        {
            try
            {
                var resultado = _unidadTrabajo.TProducto.Buscar(
                    x => x.Nombre.Contains(producto.Nombre));

                return new Respuesta<IEnumerable<TProducto>>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = _mapper.Map<IEnumerable<TProducto>>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<IEnumerable<TProducto>>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }
    }


}
