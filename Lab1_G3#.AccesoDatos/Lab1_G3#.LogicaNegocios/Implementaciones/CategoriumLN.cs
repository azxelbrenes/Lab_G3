using AutoMapper;
using Lab1_G3.Dominio;

using Lab1_G3.Dominio.EntidadesTipadas;
using Lab1_G3.Dominio.InterfacesAD;
using Lab1_G3.Dominio.InterfacesLN;
using Lab1_G3.Utilitarios;
using Lab1_G3_.Dominio.InterfacesLN;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1_G3.LogicaNegocios.Implementaciones
{
    public class CategoriumLN : ICategoriumLN
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;
        private readonly IMapper _mapper;


    public CategoriumLN(
        IUnidadTrabajoEF unidadTrabajo,
        IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _mapper = mapper;
        }

        public Respuesta<TCategorium> Insertar(TCategorium categoria)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(categoria.NombreCategoria))
                {
                    return new Respuesta<TCategorium>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Debe ingresar el nombre de la categoría."
                    };
                }

                var entidad = _mapper.Map<Categorium>(categoria);

                var resultado = _unidadTrabajo.TCategorium.Insertar(entidad);

                if (resultado.blnIndicadorTransaccion)
                    _unidadTrabajo.Completar();

                return new Respuesta<TCategorium>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = categoria
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TCategorium>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<TCategorium> Modificar(TCategorium categoria)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(categoria.NombreCategoria))
                {
                    return new Respuesta<TCategorium>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Debe ingresar el nombre de la categoría."
                    };
                }

                var entidad = _mapper.Map<Categorium>(categoria);

                var resultado = _unidadTrabajo.TCategorium.Modificar(entidad);

                if (resultado.blnIndicadorTransaccion)
                    _unidadTrabajo.Completar();

                return new Respuesta<TCategorium>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = categoria
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TCategorium>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<bool> Eliminar(TCategorium categoria)
        {
            try
            {
                var entidad = _unidadTrabajo.TCategorium.ObtenerEntidad(
                    x => x.CategoriaId == categoria.CategoriaId);

                if (!entidad.blnIndicadorTransaccion)
                {
                    return new Respuesta<bool>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Categoría no encontrada."
                    };
                }

                var resultado = _unidadTrabajo.TCategorium.Eliminar(
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

        public Respuesta<TCategorium> Buscar(TCategorium categoria)
        {
            try
            {
                var resultado = _unidadTrabajo.TCategorium.ObtenerEntidad(
                    x => x.CategoriaId == categoria.CategoriaId);

                if (!resultado.blnIndicadorTransaccion)
                {
                    return new Respuesta<TCategorium>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Categoría no encontrada."
                    };
                }

                return new Respuesta<TCategorium>
                {
                    blnIndicadorTransaccion = true,
                    ValorRetorno = _mapper.Map<TCategorium>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TCategorium>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<IEnumerable<TCategorium>> Listar()
        {
            try
            {
                var resultado = _unidadTrabajo.TCategorium.Listar();

                return new Respuesta<IEnumerable<TCategorium>>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = _mapper.Map<IEnumerable<TCategorium>>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<IEnumerable<TCategorium>>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<IEnumerable<TCategorium>> Obtener(TCategorium categoria)
        {
            try
            {
                var resultado = _unidadTrabajo.TCategorium.Buscar(
                    x => x.NombreCategoria.Contains(categoria.NombreCategoria));

                return new Respuesta<IEnumerable<TCategorium>>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = _mapper.Map<IEnumerable<TCategorium>>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<IEnumerable<TCategorium>>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }
    }

}
