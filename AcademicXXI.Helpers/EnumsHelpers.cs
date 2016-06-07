using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Helpers
{
    public enum Status
    {
        /// <summary>
        /// Estado Inactivo
        /// </summary>
        Inactive = 0,

        /// <summary>
        /// Estado Eliminado
        /// </summary>
        Delete = -1,
        
        /// <summary>
        /// Estado Activo
        /// </summary>
        Active = 1,
        
        /// <summary>
        /// Estado Nuevo
        /// </summary>
        New = 2,
        
        /// <summary>
        /// Estado Actualizado
        /// </summary>
        Update = 3,
        
        /// <summary>
        /// Estado Pendiente
        /// </summary>
        Pedding = 4,
    }
}
