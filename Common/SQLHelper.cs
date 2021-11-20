using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.NetworkInformation;

namespace PolicyBazar
{
    public class SQLHelper
    {
        #region Declaration
        public string errorMessage;
        public string errorDescription;
        public string connectionString ;
        private SqlConnection objSqlConnection;
        private SqlCommand objSqlCommand;
        private SqlParameter objSqlParameter;
        private SqlDataAdapter objSqlDataAdapter;
        #endregion

        public SQLHelper()
        {
            connectionString =  ConfigurationManager.ConnectionStrings["master"].ConnectionString;
        }

        #region Functions
        public int SP_ExecuteNonQuery(object[] parameterObjects, string storedProcedureName)
        {
            try
            {
                using (objSqlConnection = new SqlConnection(connectionString))
                {
                    //if (objSqlConnection.State == ConnectionState.Closed) OpenConnection(objSqlConnection);
                    objSqlConnection.Open();

                    int parameterObjectsLength = parameterObjects.Length;

                    object[] storedProcedureparameterObjects = new object[parameterObjectsLength];
                    using (objSqlCommand = new SqlCommand())
                    {
                        objSqlCommand.CommandText = storedProcedureName;
                        objSqlCommand.CommandType = CommandType.StoredProcedure;
                        objSqlCommand.Connection = objSqlConnection;

                        SqlCommandBuilder.DeriveParameters(objSqlCommand);

                        for (int i = 0; i < objSqlCommand.Parameters.Count - 1; i++)
                        {
                            storedProcedureparameterObjects[i] = objSqlCommand.Parameters[i + 1].ParameterName;
                        }

                        objSqlCommand = new SqlCommand(storedProcedureName, objSqlConnection);
                        for (int i = 0; i < parameterObjects.Length; i++)
                        {
                            objSqlParameter = new SqlParameter();
                            if (storedProcedureparameterObjects[i] != null)
                            {
                                objSqlParameter.ParameterName = storedProcedureparameterObjects[i].ToString();
                            }
                            else
                            {
                                objSqlParameter.ParameterName = null;
                            }
                            objSqlParameter.Value = parameterObjects[i];
                            objSqlCommand.Parameters.Add(objSqlParameter);

                        }
                        objSqlCommand.CommandType = CommandType.StoredProcedure;
                        return objSqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long SP_ExecuteScalar(object[] parameterObjects, string storedProcedureName)
        {
            try
            {
                using (objSqlConnection = new SqlConnection(connectionString))
                {
                    objSqlConnection.Open();
                    int parameterObjectsLength = parameterObjects.Length;

                    object[] storedProcedureparameterObjects = new object[parameterObjectsLength];
                    using (objSqlCommand = new SqlCommand())
                    {
                        objSqlCommand.CommandText = storedProcedureName;
                        objSqlCommand.CommandType = CommandType.StoredProcedure;
                        objSqlCommand.Connection = objSqlConnection;

                        SqlCommandBuilder.DeriveParameters(objSqlCommand);

                        for (int i = 0; i < objSqlCommand.Parameters.Count - 1; i++)
                        {
                            storedProcedureparameterObjects[i] = objSqlCommand.Parameters[i + 1].ParameterName;
                        }

                        objSqlCommand = new SqlCommand(storedProcedureName, objSqlConnection);
                        for (int i = 0; i < parameterObjects.Length; i++)
                        {
                            objSqlParameter = new SqlParameter();
                            objSqlParameter.ParameterName = storedProcedureparameterObjects[i].ToString();
                            objSqlParameter.Value = parameterObjects[i].ToString();
                            objSqlCommand.Parameters.Add(objSqlParameter);

                        }
                        objSqlCommand.CommandType = CommandType.StoredProcedure;
                        return Convert.ToInt64(objSqlCommand.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SP_GetDataSet(object[] parameterObjects, string storedProcedureName)
        {
            try
            {
                DataSet objDataSet = new DataSet();
                using (objSqlConnection = new SqlConnection(connectionString))
                {
                    objSqlConnection.Open();

                    int parameterObjectsLength = parameterObjects.Length;

                    object[] storedProcedureparameterObjects = new object[parameterObjectsLength];
                    using (objSqlCommand = new SqlCommand())
                    {
                        objSqlCommand.CommandText = storedProcedureName;
                        objSqlCommand.CommandType = CommandType.StoredProcedure;
                        objSqlCommand.Connection = objSqlConnection;

                        SqlCommandBuilder.DeriveParameters(objSqlCommand);

                        for (int i = 0; i < objSqlCommand.Parameters.Count - 1; i++)
                        {
                            storedProcedureparameterObjects[i] = objSqlCommand.Parameters[i + 1].ParameterName;
                        }

                        objSqlCommand = new SqlCommand(storedProcedureName, objSqlConnection);
                        for (int i = 0; i < parameterObjects.Length; i++)
                        {
                            objSqlParameter = new SqlParameter();
                            objSqlParameter.ParameterName = storedProcedureparameterObjects[i].ToString();
                            objSqlParameter.Value = parameterObjects[i];
                            objSqlCommand.Parameters.Add(objSqlParameter);

                        }
                        objSqlCommand.CommandType = CommandType.StoredProcedure;

                        using (objSqlDataAdapter = new SqlDataAdapter(objSqlCommand))
                        {
                            objSqlDataAdapter.Fill(objDataSet);
                        }

                        return objDataSet;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }      
        #endregion

    }
}