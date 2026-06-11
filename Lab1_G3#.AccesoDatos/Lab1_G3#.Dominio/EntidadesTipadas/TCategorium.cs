using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_G3.Dominio.EntidadesTipadas
{
    public class TCategorium
    {
        public int CategoriaId { get; set; }

        public string NombreCategoria { get; set; } = null!;

        public bool Activo { get; set; }

        public DateTime CreadoEn { get; set; }

        public string? CreadoPor { get; set; }

        public DateTime? ActualizadoEn { get; set; }

        public string? ActualizadoPor { get; set; }

        public byte[] RowVer { get; set; } = null!;
    }
}
