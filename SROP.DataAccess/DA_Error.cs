using System.Data;
using Oracle.DataAccess.Client;
public class DA_Error : DA_BASE
{
    public void ADD(BE_Error c)
    {
        OracleParameter[] arrParam = new OracleParameter[4];
        arrParam[0] = new OracleParameter("TXERROR", OracleDbType.Varchar2,800, ParameterDirection.Input);
        arrParam[0].Value = c.TXERROR;
        arrParam[1] = new OracleParameter("TXORIGEN", OracleDbType.Varchar2, 350, ParameterDirection.Input);
        arrParam[1].Value = c.TXORIGEN;
        arrParam[2] = new OracleParameter("NUSTATUSCODE", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[2].Value = c.NUSTATUSCODE;
        arrParam[3] = new OracleParameter("TXUSUARIO", OracleDbType.Varchar2, 30, ParameterDirection.Input);
        arrParam[3].Value = Yoo.UserName;
        ORACLEHELPER.EjecutarQR("ORGPOL_ERROR_ADD", arrParam);
    }
}
