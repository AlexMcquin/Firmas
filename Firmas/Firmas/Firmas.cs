using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Firmas
{

    [Table("Firmas")]
    public class Firmas
    {

        [AutoIncrement, PrimaryKey]
        public int id { get; set; }


        public string nombreFirma { get; set; }

        public string descripcionFirma { get; set; }

        public byte[] FirmaContent { get; set; }
    }
}
