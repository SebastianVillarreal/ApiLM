using System.Collections;
using System.Data.SqlClient;
using System.Data;
using ApiLM.DataContext;
using ApiLM.Models;
using System;

namespace ApiLM.DataContext
{
    public class ChecadorDac
    {

        public Checador GetPrecio(string pCodigo, int pSucursal)
        {
            Checador checador =  new Checador();
            ConexionDataAccess dac = new ConexionDataAccess();
            ArrayList parametros = new ArrayList();

            parametros.Add(new SqlParameter{ParameterName = "@pCodigo", SqlDbType = System.Data.SqlDbType.VarChar , Value = pCodigo});
            parametros.Add(new SqlParameter{ParameterName = "@pSucursal", SqlDbType = System.Data.SqlDbType.Int , Value = pSucursal});
            DataSet respuesta = dac.Fill("GetPrecio", parametros);

            Console.Write(respuesta);
            if(respuesta.Tables.Count > 0)
            {
                
                foreach(DataRow item in respuesta.Tables[0].Rows)
                {
                    Console.Write(item["Codigo"]);
                    checador.codigo = item["Codigo"].ToString();
                    checador.descripcion = item["Descripcion"].ToString();
                    checador.precio = float.Parse(item["Precio"].ToString());
                    checador.precioOferta = float.Parse(item["PrecioOferta"].ToString());
                    checador.fechaFin = item["FechaFin"].ToString();

                }
            }

            


            return checador;
        }
        


    }
}

