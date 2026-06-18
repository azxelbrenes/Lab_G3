using AutoMapper;
using Lab1_G3.Dominio;
using Lab1_G3.Dominio.EntidadesTipadas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_G3_.Dominio.DTO
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            // Cliente
            CreateMap<Cliente, TCliente>()
            .ReverseMap();

            // Producto
            CreateMap<Producto, TProducto>()
                .ReverseMap();

            // Categoría
            CreateMap<Categorium, TCategorium>()
                .ReverseMap();

            // Pedido
            CreateMap<Pedido, TPedido>()
                .ReverseMap();

            // Detalle Pedido
            CreateMap<DetallesPedido, TDetallesPedido>()
                .ReverseMap();

            // Tipo Cédula
            CreateMap<TipoCedula, TTipoCedula>()
                .ReverseMap();

            // Seguridad Usuario
            CreateMap<SegUsuario, TSegUsuario>()
                .ReverseMap();

            // Seguridad Perfil
            CreateMap<SegPerfil, TSegPerfil>()
                .ReverseMap();

            // Seguridad Pantalla
            CreateMap<SegPantalla, TSegPantalla>()
                .ReverseMap();

            // Seguridad Perfil x Pantalla
            CreateMap<SegPerfilXpantalla, TSegPerfilXpantalla>()
                .ReverseMap();
        }
    }
}

