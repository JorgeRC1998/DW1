using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Parcial_No1.Models
{
    public class Logica_de_negocio
    {
       public int resultadoCuestionario(int valor1, int valor2, int valor3, int valor4, int valor5)
        {
            int resultado = 0;

            if (valor1 == 4)
            {
                resultado = resultado + 1;
            }

            if(valor2 == 4)
            {
                resultado = resultado + 1; 
            }

            if (valor3 == 1)
            {
                resultado = resultado + 1;
            }

            if (valor4 == 0)
            {
                resultado = resultado + 1;
            }

            if (valor5 == 8)
            {
                resultado = resultado + 1;
            }
            return resultado;
        }

       


        public void insertaDatos(Int64 cedula, int valor1, int valor2, int valor3, int valor4, int valor5, int resultado)
        {
            try
            {
                SqlConnection cn = new SqlConnection(@"Database=DB_DWPARCIAL 1;Server=LAPTOP-VK5MQEUU\SQLEXPRESS;Integrated Security=SSPI");
                SqlDataAdapter da = new SqlDataAdapter();
                da.InsertCommand = new SqlCommand();
                da.InsertCommand.Connection = cn;
                da.InsertCommand.CommandType = CommandType.StoredProcedure;
                da.InsertCommand.CommandText = "insertarRegistro";
                da.InsertCommand.Parameters.Add("@cedula", SqlDbType.Int).Value = cedula;
                da.InsertCommand.Parameters.Add("@respuestaNo1", SqlDbType.Int).Value = valor1;
                da.InsertCommand.Parameters.Add("@respuestaNo2", SqlDbType.Int).Value = valor2;
                da.InsertCommand.Parameters.Add("@respuestaNo3", SqlDbType.Int).Value = valor3;
                da.InsertCommand.Parameters.Add("@respuestaNo4", SqlDbType.Int).Value = valor4;
                da.InsertCommand.Parameters.Add("@respuestaNo5", SqlDbType.Int).Value = valor5;
                da.InsertCommand.Parameters.Add("@resultado", SqlDbType.Int).Value = resultado;
                cn.Open();
               
                da.InsertCommand.ExecuteNonQuery();
                cn.Close();

            }
            catch (Exception err)
            {

                throw new Exception(err.Message);
            }
        }
        
        public DataSet consultaSQL()
        {
            Database dato = DatabaseFactory.CreateDatabase();
            DataSet datos = dato.ExecuteDataSet(ClaseProcedimientos.consultarMejorPuntaje);
            return datos;
        }

        public string cadenaCedula (int cedula)
        {
            try
            {
                int cadena;
                DataTable Cedula = new DataTable();
                SqlConnection cn = new SqlConnection(@"Database=DB_DWPARCIAL 1;Server=LAPTOP-VK5MQEUU\SQLEXPRESS;Integrated Security=SSPI");
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = cn;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = "cedulaDuplicada";
                da.SelectCommand.Parameters.Add("@cedula", SqlDbType.Int).Value = cedula;
                cadena = da.Fill(Cedula);
                
                if (cadena == 1)
                {
                    return ("Esta cedula ya está matriculada " + cedula);
                }else
                {
                    return "Se registrará esta cedula por primera vez " + cedula;
                }

            }
            catch (Exception err)
            {

                throw new Exception(err.Message);
            }
        }

    }
}

