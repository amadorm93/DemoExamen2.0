using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDepartamentos.Modelos
{
    [Table("Empleados")]
    public class Empleado
    {
        [Key]
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Appat { get; set; }
        public string Apmat { get; set; }
        public int Numempleado { get; set; }
        public string Puesto { get; set; }
    }
}
