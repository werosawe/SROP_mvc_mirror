using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using Oracle.DataAccess.Client;

	public class DA_MotivoVin : DA_BASE
	{

		public OracleDataReader Listar_Motivos_Vincula(OracleConnection CN)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];
			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_Listar.sp_motivos_vin", ARRPARAM);
			
		}

		public OracleDataReader Listar_OP_Vin(OracleConnection CN, int Cod_OP)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];
			
				ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[0].Value = Cod_OP;

				ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "Pkg_Listar.sp_op_vincula", ARRPARAM);
			
		}

        public int Delete_OP_Vinculada(BE_MotivoVin c)
        {
            Int32 oRet = new Int16();
            OracleParameter[] arrParam = new OracleParameter[4];



            arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
            arrParam[0].Value = c.Cod_OP;

            arrParam[1] = new OracleParameter("i_cod_op_vin", OracleDbType.Int32, ParameterDirection.Input);
            arrParam[1].Value = c.cod_op_vin;

            arrParam[2] = new OracleParameter("i_user_del", OracleDbType.Varchar2, ParameterDirection.Input);
            arrParam[2].Value = Yoo.UserId;

            arrParam[3] = new OracleParameter("o_return", OracleDbType.Int16, ParameterDirection.Output);

            ORACLEHELPER.EjecutarQR("pkg_OP.SP_delete_op_vincula", arrParam);

            oRet = (int)arrParam[3].Value;

            return oRet;


        }

		public BE_MotivoVin.Check Check_Puede_Vin(BE_MotivoVin c)
		{
			BE_MotivoVin.Check oRet = default(BE_MotivoVin.Check);
			OracleParameter[] arrParam = new OracleParameter[4];


			
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value = c.Cod_OP;

				arrParam[1] = new OracleParameter("i_cod_op_vin", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[1].Value = c.cod_op_vin;

				arrParam[2] = new OracleParameter("o_mensaje", OracleDbType.Varchar2,ParameterDirection.Output);
				arrParam[2].Size = 200;
				
				arrParam[3] = new OracleParameter("o_return", OracleDbType.Int16,ParameterDirection.Output);
				
				ORACLEHELPER.EjecutarQR("pkg_op.SP_Check_Puede_Vin", arrParam);

				oRet.Mensaje =(string) arrParam[2].Value;
				oRet.retorno =(int) arrParam[3].Value;

				return oRet;

			
		}

		public int Insert_OP_Vincula(BE_MotivoVin c)
		{
						OracleParameter[] arrParam = new OracleParameter[6];


			
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value = c.Cod_OP;

				arrParam[1] = new OracleParameter("i_cod_op_vin", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[1].Value = c.cod_op_vin;

				arrParam[2] = new OracleParameter("i_fec_vin", OracleDbType.Date, ParameterDirection.Input);
				arrParam[2].Value = null;

				arrParam[3] = new OracleParameter("i_user", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[3].Value = Yoo.UserId;

            arrParam[4] = new OracleParameter("i_cod_motivo_vin", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[4].Value = c.Cod_Motivo_Vin;

				arrParam[5] = new OracleParameter("o_return", OracleDbType.Int16,ParameterDirection.Output);
				
				ORACLEHELPER.EjecutarQR("pkg_op.SP_Insert_OP_Vincula", arrParam);
            
				return (int)arrParam[5].Value;

        }
	}

