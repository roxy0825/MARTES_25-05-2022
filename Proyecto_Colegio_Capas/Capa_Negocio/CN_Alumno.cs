using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using Capa_Datos;
using System.Data;

namespace Capa_Negocio
{
    public class CN_Alumno
    { 
        //Me permite 
        CD_Alumno odaalumno = new CD_Alumno();
        public bool Guardar_Alumno(CE_Alumno oencita)
        {
            return odaalumno.Guardar_Alumno(oencita);
        }
        public bool Anular_Alumno(CE_Alumno oencita)
        {
            return odaalumno.Anula_Alumno(oencita);
        }
        public DataSet Consultar_Alumno(CE_Alumno oencita)
        {
            return odaalumno.Consultar_Alumno(oencita);
        }


    }
}
