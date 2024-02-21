using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [Keyless]
    public class sp_GetAllEmpleados_Result
    {
        public int EmpleadoId { get; set; }

        public string Nombre { get; set; } = null!;

        public double Salario { get; set; }
    }
}