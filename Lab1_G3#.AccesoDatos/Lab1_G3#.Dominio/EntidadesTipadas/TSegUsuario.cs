using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_G3.Dominio.EntidadesTipadas
{
    public class TSegUsuario
    {
        public string Usuario { get; set; } = null!;

        public string CedulaUsuario { get; set; } = null!;

        public int TipoCedulaId { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string? Direccion { get; set; }

        public int CodigoPerfil { get; set; }

        public string? Email { get; set; }

        public string? Telefono { get; set; }

        public byte[] ClaveHash { get; set; } = null!;

        public byte[] ClaveSalt { get; set; } = null!;

        public byte Estado { get; set; }

        public DateTime FechaActualizacion { get; set; }

        public byte[] RowVer { get; set; } = null!;
    }
}
