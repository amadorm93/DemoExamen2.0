using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDepartamentos.Modelos
{
    [Table("Gerentes")]
    public class Gerentes
    {
        [Key]
        public int Id { get; set; }
        public int Idempleado { get; set; }
        public int IdDepartamento { get; set; }
    }
}
