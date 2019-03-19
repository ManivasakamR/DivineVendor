using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for SQLContext
/// </summary>
public class SQLContext
{
    public SqlConnection _SqlConnection;
   

    public SQLContext()
    {
        _SqlConnection = new SqlConnection();
        _SqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;
        _SqlConnection.Open();
    }
}