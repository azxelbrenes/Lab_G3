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

            // CLIENTE

            CreateMap<TCliente, Cliente>();
            CreateMap<Cliente, TCliente>();

           
            // PEDIDO
           
            CreateMap<TPedido, Pedido>();
            CreateMap<Pedido, TPedido>();

            
            // USUARIO
            
            CreateMap<TSegUsuario, SegUsuario>();
            CreateMap<SegUsuario, TSegUsuario>();
        }
    }
}
