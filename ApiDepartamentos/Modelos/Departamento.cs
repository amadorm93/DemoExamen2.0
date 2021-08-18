using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace ApiDepartamentos.Modelos
{
    [Table("Departamentos")]
    public class Departamento
    {
        [Key]
        public int IdDepartamento { get; set; }
        public string Nombre { get; set; }
        public string NoEmpleados { get; set; }
        public int IdGerente { get; set; }

    }
}
