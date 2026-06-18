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
    public class TipoCedulaLN : ITipoCedulaLN
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;
        private readonly IMapper _mapper;

        public TipoCedulaLN(
            IUnidadTrabajoEF unidadTrabajo,
            IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _mapper = mapper;
        }

        public Respuesta<TTipoCedula> Insertar(TTipoCedula tipoCedula)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tipoCedula.Descripcion))
                {
                    return new Respuesta<TTipoCedula>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Debe ingresar una descripción."
                    };
                }

                var entidad = _mapper.Map<TipoCedula>(tipoCedula);

                var resultado = _unidadTrabajo.TTipoCedula.Insertar(entidad);

                if (resultado.blnIndicadorTransaccion)
                    _unidadTrabajo.Completar();

                return new Respuesta<TTipoCedula>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = tipoCedula
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TTipoCedula>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<TTipoCedula> Modificar(TTipoCedula tipoCedula)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tipoCedula.Descripcion))
                {
                    return new Respuesta<TTipoCedula>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Debe ingresar una descripción."
                    };
                }

                var entidad = _mapper.Map<TipoCedula>(tipoCedula);

                var resultado = _unidadTrabajo.TTipoCedula.Modificar(entidad);

                if (resultado.blnIndicadorTransaccion)
                    _unidadTrabajo.Completar();

                return new Respuesta<TTipoCedula>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = tipoCedula
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TTipoCedula>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<bool> Eliminar(TTipoCedula tipoCedula)
        {
            try
            {
                var entidad = _unidadTrabajo.TTipoCedula.ObtenerEntidad(
                    x => x.TipoCedula1 == tipoCedula.TipoCedula1);

                if (!entidad.blnIndicadorTransaccion)
                {
                    return new Respuesta<bool>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Tipo de cédula no encontrado."
                    };
                }

                var resultado = _unidadTrabajo.TTipoCedula.Eliminar(
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

        public Respuesta<TTipoCedula> Buscar(TTipoCedula tipoCedula)
        {
            try
            {
                var resultado = _unidadTrabajo.TTipoCedula.ObtenerEntidad(
                    x => x.TipoCedula1 == tipoCedula.TipoCedula1);

                if (!resultado.blnIndicadorTransaccion)
                {
                    return new Respuesta<TTipoCedula>
                    {
                        blnIndicadorTransaccion = false,
                        strMensajeRespuesta = "Tipo de cédula no encontrado."
                    };
                }

                return new Respuesta<TTipoCedula>
                {
                    blnIndicadorTransaccion = true,
                    ValorRetorno = _mapper.Map<TTipoCedula>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<TTipoCedula>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<IEnumerable<TTipoCedula>> Listar()
        {
            try
            {
                var resultado = _unidadTrabajo.TTipoCedula.Listar();

                return new Respuesta<IEnumerable<TTipoCedula>>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = _mapper.Map<IEnumerable<TTipoCedula>>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<IEnumerable<TTipoCedula>>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }

        public Respuesta<IEnumerable<TTipoCedula>> Obtener(TTipoCedula tipoCedula)
        {
            try
            {
                var resultado = _unidadTrabajo.TTipoCedula.Buscar(
                    x => x.Descripcion.Contains(tipoCedula.Descripcion));

                return new Respuesta<IEnumerable<TTipoCedula>>
                {
                    blnIndicadorTransaccion = resultado.blnIndicadorTransaccion,
                    strMensajeRespuesta = resultado.strMensajeRespuesta,
                    ValorRetorno = _mapper.Map<IEnumerable<TTipoCedula>>(
                        resultado.ValorRetorno)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<IEnumerable<TTipoCedula>>
                {
                    blnIndicadorTransaccion = false,
                    strMensajeRespuesta = ex.Message
                };
            }
        }
    }
}