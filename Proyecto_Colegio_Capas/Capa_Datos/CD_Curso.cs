using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Se adicionan las siguientes librerias
using System.Data.SqlClient;
using Capa_Entidad;
using System.Data;

namespace Capa_Datos
{
    public class CD_Curso
    {
        //Se crea objeto de conexion
        Conexion oconexion = new Conexion();
        //Se crea objeto para conexion con SQL
        SqlCommand ocmd = new SqlCommand();
        //Se crea procedimiento para acceder a la BD
        public bool Guardar_Curso(CE_Curso oacurso)
        {
            try
            {
                //Trae los procedimientos almacenados
                ocmd.CommandType = CommandType.StoredProcedure;
                //Se conecta con el servidor, el nombre es el que aparece en la web.config
                ocmd.Connection = oconexion.conectar("BD_Colegio");
                //Copiamos el nombre del procedimiento almacenado
                ocmd.CommandText = "Insertar_Curso";
                //Se pone el nombre de cada campo de la tabla de SQL poniendose cómo variable
                ocmd.Parameters.AddWithValue("@Id_Curso", oacurso.Id_Curso1);
                ocmd.Parameters.AddWithValue("@Nom_Curso", oacurso.Nom_Curso1);
                //Se cierra el query
                ocmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }
        //Pte realizar el procedimiento para anular curso
        public bool Anula_Curso(CE_Alumno oalumno)
        {
            try
            {
                ocmd.CommandType = CommandType.StoredProcedure;
                ocmd.Connection = oconexion.conectar("BD_Colegio");
                ocmd.CommandText = "Borrar_Alumno";
                ocmd.Parameters.AddWithValue("@Id_Alumno", oalumno.Id_Alumno1);
                ocmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
