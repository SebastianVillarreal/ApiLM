using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Data;

public class ConexionDataAccess
{

    SqlConnection SqlCon;
        
    public ConexionDataAccess()
    {
        SqlCon = new SqlConnection();
    }
    public SqlConnection GetConnection()
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        builder.DataSource = "localhost, 1433"; 
        builder.UserID = "sa";            
        builder.Password = "ABC1238f47";     
        builder.InitialCatalog = "LaMisionApp";

        SqlConnection connection = new SqlConnection(builder.ConnectionString);

        return connection;
    }

    public void ExecuteNonQuery(string procedimiento, ArrayList parametros)
    {
        try
        {
            this.SqlCon = this.GetConnection();
            this.SqlCon.Open();

            SqlCommand mComando = new SqlCommand(procedimiento, SqlCon);
            mComando.CommandType =  System.Data.CommandType.StoredProcedure;

            foreach (SqlParameter param in parametros)
            {
                mComando.Parameters.Add(param);
            }
            mComando.CommandTimeout = 10000;
            mComando.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            SqlCon.Close();

        }
        finally
        {
            SqlCon.Close();
        }
    }


    public DataSet Fill(string procedimiento, ArrayList parametros)
    {
        DataSet mDataSet = new DataSet();

        try
        {
            this.SqlCon = this.GetConnection();
            this.SqlCon.Open();


            SqlCommand mComando = new SqlCommand(procedimiento, SqlCon);
            SqlDataAdapter mDataAdapter = new SqlDataAdapter(mComando);

            mComando.CommandType = CommandType.StoredProcedure;
            mComando.CommandTimeout = 600;

            foreach (SqlParameter param in parametros)
            {
                mComando.Parameters.Add(param);
            }

            mDataAdapter.Fill(mDataSet);
            return mDataSet;
        }
        catch (Exception e)
        {
            this.SqlCon.Close();
            throw e;
        }
        finally
        {
           this.SqlCon.Close();
        }
    }
}
