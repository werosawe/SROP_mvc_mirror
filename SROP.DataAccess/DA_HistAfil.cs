using System;
using System.Data;
using Oracle.DataAccess.Client;

	public class DA_HistAfil : DA_BASE
	{

		public string UpdateFlagsComites_Personeros(BE_HistAfil c)
		{
			OracleParameter[] arrParam = new OracleParameter[6];

			
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value = c.Cod_OP;

				arrParam[1] = new OracleParameter("i_cod_DNI", OracleDbType.Char, ParameterDirection.Input);
				arrParam[1].Value = c.Cod_DNI;

				arrParam[2] = new OracleParameter("i_flg_estado_afil", OracleDbType.Int16, ParameterDirection.Input);
				arrParam[2].Value = c.flg_Estado_Afil_new;

				arrParam[3] = new OracleParameter("i_fec_renuncia", OracleDbType.Date, ParameterDirection.Input);
				if (string.IsNullOrEmpty(c.Fec_renun_OP)) {
					arrParam[3].Value = DBNull.Value;
				} else {
					arrParam[3].Value = c.Fec_renun_OP;
				}

				arrParam[4] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[4].Value = Yoo.UserId;

            arrParam[5] = new OracleParameter("o_return", OracleDbType.Int32);
				arrParam[5].Direction = ParameterDirection.Output;


				ORACLEHELPER.EjecutarQR("PKG_AFILIADOS.sp_update_comites_personeros", arrParam);

				return Convert.ToString(arrParam[5].Value.ToString());
            
		}

	}

