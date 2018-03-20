using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
//===============================================================================
// OraclecleHelper based on Microsoft Data Access Application Block (DAAB) for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/daab-rm.asp
//
// OraclecleHelper.cs
//
// This file contains the implementations of the OraclecleHelper and OraclecleHelperParameterCache
// classes.
//
// The DAAB for MS .NET Provider for Oraclecle has been tested in the context of this Nile implementation,
// but has not undergone the generic functional testing that the Oracle version has gone through.
// You can use it in other .NET applications using Oraclecle databases.  For complete docs explaining how to use
// and how it's built go to the originl appblock link. 
// For this sample, the code resides in the Nile namespaces not the Microsoft.ApplicationBlocks namespace
//==============================================================================
using System.Xml;
using Oracle.DataAccess.Client;
using static System.Exception;
namespace Utilitario
{

	// The OracleHelper class is intended to encapsulate high performance, scalable best practices for 
	// common uses of OracleClient.

	public sealed class Oracle_Helper
	{
		#region "private utility methods & constructors"

		private Oracle_Helper()
		{
		}
		private static void AttachParameters(OracleCommand command, OracleParameter[] commandParameters)
		{
			OracleParameter p = null;

			foreach (OracleParameter p_loopVariable in commandParameters) {
				p = p_loopVariable;
				if (p.Direction == ParameterDirection.InputOutput & p.Value == null) {
					p.Value = null;
				}
				command.Parameters.Add(p);
			}
		}

		private static void AssignParameterValues(OracleParameter[] commandParameters, object[] parameterValues)
		{
			short i = 0;
			short j = 0;
			if ((commandParameters == null) & (parameterValues == null)) {
				return;
			}

			if (commandParameters.Length != parameterValues.Length) {
				throw new ArgumentException("Parameter count does not match Parameter Value count.");
			}

			j = Convert.ToInt16(commandParameters.Length - 1);
			for (i = 0; i <= j; i++) {
				commandParameters[i].Value = parameterValues[i];
			}
		}

		private static void PrepareCommand(OracleCommand command, OracleConnection connection, OracleTransaction transaction, CommandType commandType, string commandText, OracleParameter[] commandParameters)
		{
			if (connection.State != ConnectionState.Open) {
				connection.Open();
			}

			command.Connection = connection;
			command.CommandText = commandText;

			if ((transaction != null)) {
				command.Transaction.Connection.BeginTransaction();
			}

			command.CommandType = commandType;

			if ((commandParameters != null)) {
				AttachParameters(command, commandParameters);
			}

			return;
		}
		//PrepareCommand

		#endregion

		#region "ExecuteNonQuery"

		public static int ExecuteNonQuery(OracleConnection connection, CommandType commandType, string commandText)
		{
			return ExecuteNonQuery(connection, commandType, commandText, (OracleParameter[])null);

		}
		public static int ExecuteNonQuery(OracleConnection connection, CommandType commandType, string commandText, params OracleParameter[] commandParameters)
		{
			OracleCommand cmd = new OracleCommand();
			int retval = 0;
			PrepareCommand(cmd, connection, (OracleTransaction)null, commandType, commandText, commandParameters);
			retval = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();
			return retval;
		}


		#endregion

		#region "ExecuteDataset, DataTable"
		//Public Overloads Shared Function ExecuteDataset(ByVal connectionString As String, _
		//                                                ByVal commandType As CommandType, _
		//                                                ByVal commandText As String) As DataSet
		//    Return ExecuteDataset(connectionString, commandType, commandText, CType(Nothing, OracleParameter()))
		//End Function
		//Public Overloads Shared Function ExecuteDataset(ByVal connectionString As String, _
		//                                                ByVal commandType As CommandType, _
		//                                                ByVal commandText As String, _
		//                                                ByVal ParamArray commandParameters() As OracleParameter) As DataSet
		//    Dim cn As New OracleConnection(connectionString)
		//    Try
		//        cn.Open()
		//        Return ExecuteDataset(cn, commandType, commandText, commandParameters)
		//    Finally
		//        cn.Close()
		//        cn.Dispose()
		//    End Try
		//End Function

		//Public Overloads Shared Function ExecuteDataset(ByVal connectionString As String, _
		//                                                ByVal spName As String, _
		//                                                ByVal ParamArray parameterValues() As Object) As DataSet

		//    Dim commandParameters As OracleParameter()
		//    If Not (parameterValues Is Nothing) And parameterValues.Length > 0 Then
		//        commandParameters = OracleHelperParameterCache.GetSpParameterSet(connectionString, spName)
		//        AssignParameterValues(commandParameters, parameterValues)
		//        Return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, commandParameters)
		//    Else
		//        Return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName)
		//    End If
		//End Function
		//Public Overloads Shared Function ExecuteDataset(ByVal connection As OracleConnection, _
		//                                                ByVal commandType As CommandType, _
		//                                                ByVal commandText As String) As DataSet
		//    Return ExecuteDataset(connection, commandType, commandText, CType(Nothing, OracleParameter()))
		//End Function 
		//Public Overloads Shared Function ExecuteDataset(ByVal connection As OracleConnection, _
		//                                                ByVal commandType As CommandType, _
		//                                                ByVal commandText As String, _
		//                                                ByVal ParamArray commandParameters() As OracleParameter) As DataSet

		//    'create a command and prepare it for execution
		//    Dim cmd As New OracleCommand
		//    Dim ds As New DataSet
		//    Dim da As OracleDataAdapter

		//    PrepareCommand(cmd, connection, CType(Nothing, OracleTransaction), commandType, commandText, commandParameters)

		//    'create the DataAdapter & DataSet
		//    da = New OracleDataAdapter(cmd)

		//    'fill the DataSet using default values for DataTable names, etc.
		//    da.Fill(ds)

		//    'detach the OracleParameters from the command object, so they can be used again
		//    cmd.Parameters.Clear()

		//    'return the dataset
		//    Return ds

		//End Function 'ExecuteDataset
		//Public Overloads Shared Function ExecuteDataTable(ByVal connectionString As String, _
		//                                                    ByVal commandType As CommandType, _
		//                                                    ByVal commandText As String, _
		//                                                    ByVal ParamArray commandParameters() As OracleParameter) As DataTable
		//    Dim cn As New OracleConnection(connectionString)
		//    Try
		//        cn.Open()
		//        Return ExecuteDataTable(cn, commandType, commandText, commandParameters)
		//    Finally
		//        cn.Close()
		//        cn.Dispose()
		//    End Try
		//End Function
		public static DataTable ExecuteDataTable(OracleConnection connection, CommandType commandType, string commandText, params OracleParameter[] commandParameters)
		{

			//create a command and prepare it for execution
			OracleCommand cmd = new OracleCommand();
			DataTable dt = new DataTable();
			OracleDataAdapter da = null;

			PrepareCommand(cmd, connection, (OracleTransaction)null, commandType, commandText, commandParameters);

			//create the DataAdapter & DataSet
			da = new OracleDataAdapter(cmd);

			//fill the DataSet using default values for DataTable names, etc.
			da.Fill(dt);

			//detach the OracleParameters from the command object, so they can be used again
			cmd.Parameters.Clear();

			//return the dataset
			return dt;

		}
		//ExecuteDataTable



		// Execute a stored procedure via a OracleCommand (that returns a resultset) against the specified OracleConnection 
		// using the provided parameter values.  This method will discover the parameters for the 
		// stored procedure, and assign the values based on parameter order.
		// This method provides no access to output parameters or the stored procedure's return value parameter.
		// e.g.:  
		// Dim ds As Dataset = ExecuteDataset(conn, "GetOrders", 24, 36)
		// Parameters:
		// -connection - a valid OracleConnection
		// -spName - the name of the stored procedure
		// -parameterValues - an array of objects to be assigned as the input values of the stored procedure
		// Returns: a dataset containing the resultset generated by the command
		//Public Overloads Shared Function ExecuteDataset(ByVal connection As OracleConnection, _
		//                                                ByVal spName As String, _
		//                                                ByVal ParamArray parameterValues() As Object) As DataSet
		//    'Return ExecuteDataset(connection, spName, parameterValues)
		//    Dim commandParameters As OracleParameter()

		//    'if we receive parameter values, we need to figure out where they go
		//    If Not (parameterValues Is Nothing) And parameterValues.Length > 0 Then
		//        'pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
		//        commandParameters = OracleHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName)

		//        'assign the provided values to these parameters based on parameter order
		//        AssignParameterValues(commandParameters, parameterValues)

		//        'call the overload that takes an array of OracleParameters
		//        Return ExecuteDataset(connection, CommandType.StoredProcedure, spName, commandParameters)
		//        'otherwise we can just call the SP without params
		//    Else
		//        Return ExecuteDataset(connection, CommandType.StoredProcedure, spName)
		//    End If

		//End Function 'ExecuteDataset


		// Execute a OracleCommand (that returns a resultset and takes no parameters) against the provided OracleTransaction. 
		// e.g.:  
		// Dim ds As Dataset = ExecuteDataset(trans, CommandType.StoredProcedure, "GetOrders")
		// Parameters
		// -transaction - a valid OracleTransaction
		// -commandType - the CommandType (stored procedure, text, etc.)
		// -commandText - the stored procedure name or T-Oracle command
		// Returns: a dataset containing the resultset generated by the command
		//Public Overloads Shared Function ExecuteDataset(ByVal transaction As OracleTransaction, _
		//                                                ByVal commandType As CommandType, _
		//                                                ByVal commandText As String) As DataSet
		//    'pass through the call providing null for the set of OracleParameters
		//    Return ExecuteDataset(transaction, commandType, commandText, CType(Nothing, OracleParameter()))
		//End Function 'ExecuteDataset

		// Execute a OracleCommand (that returns a resultset) against the specified OracleTransaction
		// using the provided parameters.
		// e.g.:  
		// Dim ds As Dataset = ExecuteDataset(trans, CommandType.StoredProcedure, "GetOrders", new OracleParameter("@prodid", 24))
		// Parameters
		// -transaction - a valid OracleTransaction 
		// -commandType - the CommandType (stored procedure, text, etc.)
		// -commandText - the stored procedure name or T-Oracle command
		// -commandParameters - an array of OracleParamters used to execute the command
		// Returns: a dataset containing the resultset generated by the command
		//Public Overloads Shared Function ExecuteDataset(ByVal transaction As OracleTransaction, _
		//                                                ByVal commandType As CommandType, _
		//                                                ByVal commandText As String, _
		//                                                ByVal ParamArray commandParameters() As OracleParameter) As DataSet
		//    'create a command and prepare it for execution
		//    Dim cmd As New OracleCommand
		//    Dim ds As New DataSet
		//    Dim da As OracleDataAdapter

		//    PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters)

		//    'create the DataAdapter & DataSet
		//    da = New OracleDataAdapter(cmd)

		//    'fill the DataSet using default values for DataTable names, etc.
		//    da.Fill(ds)

		//    'detach the OracleParameters from the command object, so they can be used again
		//    cmd.Parameters.Clear()

		//    'return the dataset
		//    Return ds
		//End Function 'ExecuteDataset

		// Execute a stored procedure via a OracleCommand (that returns a resultset) against the specified
		// OracleTransaction using the provided parameter values.  This method will discover the parameters for the 
		// stored procedure, and assign the values based on parameter order.
		// This method provides no access to output parameters or the stored procedure's return value parameter.
		// e.g.:  
		// Dim ds As Dataset = ExecuteDataset(trans, "GetOrders", 24, 36)
		// Parameters:
		// -transaction - a valid OracleTransaction 
		// -spName - the name of the stored procedure
		// -parameterValues - an array of objects to be assigned as the input values of the stored procedure
		// Returns: a dataset containing the resultset generated by the command
		//Public Overloads Shared Function ExecuteDataset(ByVal transaction As OracleTransaction, _
		//                                                ByVal spName As String, _
		//                                                ByVal ParamArray parameterValues() As Object) As DataSet
		//    Dim commandParameters As OracleParameter()

		//    'if we receive parameter values, we need to figure out where they go
		//    If Not (parameterValues Is Nothing) And parameterValues.Length > 0 Then
		//        'pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
		//        commandParameters = OracleHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName)

		//        'assign the provided values to these parameters based on parameter order
		//        AssignParameterValues(commandParameters, parameterValues)

		//        'call the overload that takes an array of OracleParameters
		//        Return ExecuteDataset(transaction, CommandType.StoredProcedure, spName, commandParameters)
		//        'otherwise we can just call the SP without params
		//    Else
		//        Return ExecuteDataset(transaction, CommandType.StoredProcedure, spName)
		//    End If
		//End Function 'ExecuteDataset

		#endregion

		#region "ExecuteReader"
		// this enum is used to indicate whether the connection was provided by the caller, or created by OracleHelper, so that
		// we can set the appropriate CommandBehavior when calling ExecuteReader()
		private enum OracleConnectionOwnership
		{
			//Connection is owned and managed by OracleHelper
			Internal,
			//Connection is owned and managed by the caller
			External
		}
		//OracleConnectionOwnership

		private static OracleDataReader ExecuteReader(OracleConnection connection, OracleTransaction transaction, CommandType commandType, string commandText, OracleParameter[] commandParameters, OracleConnectionOwnership connectionOwnership)
		{
			//create a command and prepare it for execution
			OracleCommand cmd = new OracleCommand();
			//create a reader
			OracleDataReader dr = null;

			PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters);

			// call ExecuteReader with the appropriate CommandBehavior
			if (connectionOwnership == OracleConnectionOwnership.External) {
				dr = cmd.ExecuteReader();
			} else {
				dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			}

			//detach the OracleParameters from the command object, so they can be used again
			cmd.Parameters.Clear();

			return dr;
		}
		//ExecuteReader

		public static OracleDataReader ExecuteReader(OracleConnection connection, CommandType commandType, string commandText)
		{

			return ExecuteReader(connection, commandType, commandText, (OracleParameter[])null);

		}
		//ExecuteReader

		public static OracleDataReader ExecuteReader(OracleConnection connection, CommandType commandType, string commandText, params OracleParameter[] commandParameters)
		{
			//pass through the call to private overload using a null transaction value
			return ExecuteReader(connection, (OracleTransaction)null, commandType, commandText, commandParameters, OracleConnectionOwnership.External);

		}
		//ExecuteReader

		public static OracleDataReader ExecuteReader(OracleConnection connection, string spName, params object[] parameterValues)
		{
			OracleParameter[] commandParameters = null;
			if ((parameterValues != null) & parameterValues.Length > 0) {
				commandParameters = OracleHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);
				AssignParameterValues(commandParameters, parameterValues);
				return ExecuteReader(connection, CommandType.StoredProcedure, spName, commandParameters);
			} else {
				return ExecuteReader(connection, CommandType.StoredProcedure, spName);
			}
		}

		public static OracleDataReader ExecuteReader(OracleTransaction transaction, CommandType commandType, string commandText)
		{
			return ExecuteReader(transaction, commandType, commandText, (OracleParameter[])null);
		}
		public static OracleDataReader ExecuteReader(OracleTransaction transaction, CommandType commandType, string commandText, params OracleParameter[] commandParameters)
		{
			return ExecuteReader(transaction.Connection, transaction, commandType, commandText, commandParameters, OracleConnectionOwnership.External);
		}
		public static OracleDataReader ExecuteReader(OracleTransaction transaction, string spName, params object[] parameterValues)
		{
			OracleParameter[] commandParameters = null;
			if ((parameterValues != null) & parameterValues.Length > 0) {
				commandParameters = OracleHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);
				AssignParameterValues(commandParameters, parameterValues);
				return ExecuteReader(transaction, CommandType.StoredProcedure, spName, commandParameters);
			} else {
				return ExecuteReader(transaction, CommandType.StoredProcedure, spName);
			}
		}
		//ExecuteReader

		#endregion


	}
}
namespace Utilitario
{

	public sealed class OracleHelperParameterCache
	{

		#region "private methods, variables, and constructors"


		//Since this class provides only static methods, make the default constructor private to prevent 
		//instances from being created with "new OracleHelperParameterCache()".
		private OracleHelperParameterCache()
		{
		}
		//New 


		private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());

		private static OracleParameter[] DiscoverSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter, params object[] parameterValues)
		{

			OracleConnection cn = new OracleConnection(connectionString);
			OracleCommand cmd = new OracleCommand(spName, cn);
			OracleParameter[] discoveredParameters = null;

			try {
				cn.Open();
				cmd.CommandType = CommandType.StoredProcedure;
				if (!includeReturnValueParameter) {
					cmd.Parameters.RemoveAt(0);
				}
				discoveredParameters = new OracleParameter[cmd.Parameters.Count];
				cmd.Parameters.CopyTo(discoveredParameters, 0);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}

			return discoveredParameters;

		}

		private static OracleParameter[] CloneParameters(OracleParameter[] originalParameters)
		{
			short i = 0;
			short j = Convert.ToInt16(originalParameters.Length - 1);
			OracleParameter[] clonedParameters = new OracleParameter[j + 1];

			for (i = 0; i <= j; i++) {
				clonedParameters[i] = (OracleParameter)((ICloneable)originalParameters[i]).Clone();
			}

			return clonedParameters;
		}
		//CloneParameters



		#endregion

		#region "caching functions"


		public static void CacheParameterSet(string connectionString, string commandText, params OracleParameter[] commandParameters)
		{
			string hashKey = connectionString + ":" + commandText;

			paramCache[hashKey] = commandParameters;
		}
		//CacheParameterSet


		public static OracleParameter[] GetCachedParameterSet(string connectionString, string commandText)
		{
			string hashKey = connectionString + ":" + commandText;
			OracleParameter[] cachedParameters = (OracleParameter[])paramCache[hashKey];

			if (cachedParameters == null) {
				return null;
			} else {
				return CloneParameters(cachedParameters);
			}
		}
		//GetCachedParameterSet

		#endregion

		#region "Parameter Discovery Functions"
		// Retrieves the set of OracleParameters appropriate for the stored procedure
		// 
		// This method will query the database for this information, and then store it in a cache for future requests.
		// Parameters:
		// -connectionString - a valid connection string for a OracleConnection 
		// -spName - the name of the stored procedure 
		// Returns: an array of OracleParameters
		public static OracleParameter[] GetSpParameterSet(string connectionString, string spName)
		{
			return GetSpParameterSet(connectionString, spName, false);
		}
		//GetSpParameterSet 

		// Retrieves the set of OracleParameters appropriate for the stored procedure
		// 
		// This method will query the database for this information, and then store it in a cache for future requests.
		// Parameters:
		// -connectionString - a valid connection string for a OracleConnection
		// -spName - the name of the stored procedure 
		// -includeReturnValueParameter - a bool value indicating whether the return value parameter should be included in the results 
		// Returns: an array of OracleParameters 
		public static OracleParameter[] GetSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
		{

			OracleParameter[] cachedParameters = null;
			string hashKey = null;

			string str = null;
			//IIf(includeReturnValueParameter = True, ":include ReturnValue Parameter", ""
			if (includeReturnValueParameter == true) {
				str = ":include ReturnValue Parameter";
			} else {
				str = "";
			}

			hashKey = connectionString + ":" + spName + str;

			cachedParameters = (OracleParameter[])paramCache[hashKey];

			if ((cachedParameters == null)) {
				paramCache[hashKey] = DiscoverSpParameterSet(connectionString, spName, includeReturnValueParameter);
				cachedParameters = (OracleParameter[])paramCache[hashKey];

			}

			return CloneParameters(cachedParameters);

		}
		//GetSpParameterSet
		#endregion

	}
}
//OracleHelperParameterCache 

