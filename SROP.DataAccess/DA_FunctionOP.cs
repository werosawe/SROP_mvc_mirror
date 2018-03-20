using System;
using System.Data;
using Oracle.DataAccess.Client;


public class DA_FunctionOP
{
    public void Save_BLOB(OracleConnection cn, Int32 Cod_OP, byte[] Foto)
    {

        if ((Foto != null))
        {
            OracleCommand cmd = new OracleCommand();
            cn.Open();

            cmd = cn.CreateCommand();
            cmd.CommandText = "Pkg_OP.sp_save_simbolo_blob";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new OracleParameter("i_cod_op", OracleDbType.Int32)).Value = Cod_OP;
            cmd.Parameters.Add(new OracleParameter("i_img_simbolo_op", OracleDbType.Blob)).Value = Foto;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cn.Close();
            cn.Dispose();
        }
    }
}

