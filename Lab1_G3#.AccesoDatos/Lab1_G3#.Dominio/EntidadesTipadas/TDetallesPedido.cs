using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_G3.Dominio.EntidadesTipadas
{
    public class TDetallesPedido
    {
        public int DetalleId { get; set; }

        public int PedidoId { get; set; }

        public string ProductoId { get; set; } = null!;

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Descuento { get; set; }
    }
}
