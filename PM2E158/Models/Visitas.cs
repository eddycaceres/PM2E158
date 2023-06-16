using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM2E158.Models
{
    public class Visitas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Longitud { get; set; }
        [MaxLength(100)]
        public string Latitud { get; set; }
        [MaxLength(200)]
        public string Descripcion { get; set; }
        public byte[] foto { get; set; }

    }
}
