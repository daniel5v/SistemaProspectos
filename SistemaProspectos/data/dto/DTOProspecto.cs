using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaProspectos.data.dto
{
    public class DTOProspecto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string APaterno { get; set; }
        public string AMaterno { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Colonia { get; set; }
        public string CodigoPostal { get; set; }
        public string Telefono { get; set; }
        public string Rfc { get; set; }
        public string Status { get; set; }
        public string Observacion { get; set; }
    }
}