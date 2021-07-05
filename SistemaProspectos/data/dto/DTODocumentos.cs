using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaProspectos.data.dto
{
    public class DTODocumentos
    {
        public long Id { get; set; }
        public string NombreDocumento { get; set; }
        public string Documento { get; set; }
        public HttpPostedFile File { get; set; }
    }
}