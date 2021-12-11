using System.Collections;
using System.Data.SqlClient;
using System.Data;
public class ChecadorDac
{

    public string GetPrecio(string pCodigo, int pSucursal)
    {
        Checador checador =  new Checador();
        ConexionDataAccess dac = new ConexionDataAccess();
        ArrayList parametros = new ArrayList();

        parametros.Add(new SqlParameter{ParameterName = "@pCodigo", SqlDbType = System.Data.SqlDbType.VarChar , Value = pCodigo});
        parametros.Add(new SqlParameter{ParameterName = "@pSucursal", SqlDbType = System.Data.SqlDbType.Int , Value = pSucursal});
        DataSet respuesta = dac.Fill("GetPrecio", parametros);

        if(respuesta.Tables.Count > 0)
        {
            foreach(DataRow item in respuesta.Tables[0].Rows)
            {
                checador.codigo = item["Codigo"].ToString();
                checador.descripcion = item[""].ToString();
                checador.precio = int.Parse(item[""].ToString());
                checador.precioOferta = int.Parse(item[""].ToString());
                checador.fechaFin = item[""].ToString();

            }
        }

        


        return "";
    }
    


}