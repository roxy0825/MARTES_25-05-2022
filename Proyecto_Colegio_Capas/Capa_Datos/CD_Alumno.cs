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
    public class CD_Alumno
    {
        //Se crea objeto de conexion
        Conexion oconexion = new Conexion();
        //Se crea objeto para conexion con SQL
        SqlCommand ocmd = new SqlCommand();
        //Se crea procedimiento para acceder a la BD
        public bool Guardar_Alumno(CE_Alumno oalumno)
        {
            try
            {
                //Trae los procedimientos almacenados
                ocmd.CommandType = CommandType.StoredProcedure;
                //Se conecta con el servidor, el nombre es el que aparece en la web.config
                ocmd.Connection = oconexion.conectar("BD_Colegio");
                //Copiamos el nombre del procedimiento almacenado
                ocmd.CommandText = "Matricula";
                //Se pone el nombre de cada campo de la tabla de SQL poniendose cómo variable
                ocmd.Parameters.AddWithValue("@Id_Alumno", oalumno.Id_Alumno1);
                ocmd.Parameters.AddWithValue("@Nom_Alumno", oalumno.Nom_Alumno1);
                ocmd.Parameters.AddWithValue("@Dir_Alumno", oalumno.Dir_Alumno1);
                ocmd.Parameters.AddWithValue("@Tel_Alumno", oalumno.Tel_Alumno1);
                ocmd.Parameters.AddWithValue("@Grp_Alumno", oalumno.Grp_Alumno1);
                //Se cierra el query
                ocmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool Anula_Alumno (CE_Alumno oalumno)
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
        //Cómo es sólo para consultar se utiliza DataSet
        public DataSet Consultar_Alumno(CE_Alumno oalumno)
        {
            try
            {
                ocmd.CommandType = CommandType.StoredProcedure;
                ocmd.Connection = oconexion.conectar("BD_Colegio");
                ocmd.CommandText = "Consul_Alumno";
                ocmd.Parameters.AddWithValue("@Id_Alumno", oalumno.Id_Alumno1);
                //Se utiliza adaptador para conectarnos con el SQL
                SqlDataAdapter da = new SqlDataAdapter(ocmd);
                //Determina si existe o no en la tabla
                DataSet ds = new DataSet();
                //
                da.Fill(ds);
                return ds;
                
            }
            catch (Exception)
            {

                throw;
            }
        }

    }


}
