using System;
using System.Data;
using Oracle.DataAccess.Client;
public class DA_Usuario : DA_BASE
{


    public OracleDataReader Listar_Usuarios(OracleConnection CN)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[1];


        ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_Users.SP_Listar_Users", ARRPARAM);

    }

    public OracleDataReader Listar_Usuarios_Search(OracleConnection CN, string search, int filtro)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];
        ARRPARAM[0] = new OracleParameter("i_param", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[0].Value = search;
        ARRPARAM[1] = new OracleParameter("i_filtro", OracleDbType.Int16, ParameterDirection.Input);
        ARRPARAM[1].Value = filtro;
        ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_Users.SP_Listar_Users_Search", ARRPARAM);
    }

    public OracleDataReader Verifica_Usuario(OracleConnection cn, BE_USUARIO c)
    {
        OracleParameter[] pr = new OracleParameter[3];
        pr[0] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        pr[0].Value = c.UserId;
        pr[1] = new OracleParameter("i_clave", OracleDbType.Varchar2, ParameterDirection.Input);
        pr[1].Value = c.PasswordInTextBox;
        pr[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_Users.SP_VerificaUsuario", pr);
    }

    public OracleDataReader Verifica_UsuarioX(OracleConnection cn)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[1];
        ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_Users.SP_VerificaUsuario", ARRPARAM);
    }


    public void Autenticacion(BE_USUARIO c)
    {
        OracleParameter[] pr = new OracleParameter[3];
        pr[0] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        pr[0].Value = c.UserId;
        pr[1] = new OracleParameter("i_clave", OracleDbType.Varchar2, ParameterDirection.Input);
        pr[1].Value = c.PasswordInTextBox;
        pr[2] = new OracleParameter("o_return", OracleDbType.Int16, 4);
        pr[2].Direction = ParameterDirection.Output;
        ORACLEHELPER.EjecutarQR("pkg_Users.SP_Login", pr);
        c.UserExiste = (int)pr[2].Value;
    }

    public OracleDataReader GetDatos_User(OracleConnection cn, BE_USUARIO c)
    {
        OracleParameter[] pr = new OracleParameter[2];
        pr[0] = new OracleParameter("i_UserID", OracleDbType.Varchar2, ParameterDirection.Input);
        pr[0].Value = c.UserId;
        pr[1] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "PKG_Users.SP_GetDatos_USER", pr);
    }

    public bool Puede_Mirar_Boton_NuevoExp(OracleConnection CN, BE_USUARIO c)
    {
        bool functionReturnValue = false;

        OracleParameter[] ARRPARAM = new OracleParameter[2];

        ARRPARAM[0] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[0].Value = c.UserId;

        ARRPARAM[1] = new OracleParameter("o_return", OracleDbType.Int16, 4);
        ARRPARAM[1].Direction = ParameterDirection.Output;

        ORACLEHELPER.EjecutarQR("pkg_Users.SP_Puede_Mirar_Boton_NuevoExp", ARRPARAM);

        if ((int)ARRPARAM[1].Value == 1)
        {
            functionReturnValue = true;
        }
        else
        {
            functionReturnValue = false;
        }
        return functionReturnValue;

    }

    public bool Puede_Mirar_Boton_Bloq(OracleConnection CN, BE_USUARIO c)
    {
        bool functionReturnValue = false;

        OracleParameter[] ARRPARAM = new OracleParameter[2];

        ARRPARAM[0] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[0].Value = c.UserId;

        ARRPARAM[1] = new OracleParameter("o_return", OracleDbType.Int16, 4);
        ARRPARAM[1].Direction = ParameterDirection.Output;

        ORACLEHELPER.EjecutarQR("pkg_Users.SP_Puede_Mirar_Boton_Bloq", ARRPARAM);

        if ((int)ARRPARAM[1].Value == 1)
        {
            functionReturnValue = true;
        }
        else
        {
            functionReturnValue = false;
        }
        return functionReturnValue;

    }

    public void Insert_Login_Out(OracleConnection CN, BE_USUARIO c, int InOut)
    {

        if (string.IsNullOrEmpty(c.UserId))
        {
        }
        else
        {
            string HoraLogin = "";
            HoraLogin = Convert.ToString(DateTime.Now.TimeOfDay.Hours).PadLeft(2, char.Parse("0")) + ":" + Convert.ToString(DateTime.Now.TimeOfDay.Minutes).PadLeft(2, char.Parse("0")) + ":" + Convert.ToString(DateTime.Now.TimeOfDay.Seconds).PadLeft(2, char.Parse("0"));

            OracleParameter[] ARRPARAM = new OracleParameter[7];

            ARRPARAM[0] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
            ARRPARAM[0].Value = c.UserId;
            ARRPARAM[1] = new OracleParameter("i_IP_int", OracleDbType.Varchar2, ParameterDirection.Input);
            ARRPARAM[1].Value = c.IP;
            ARRPARAM[2] = new OracleParameter("i_in_out", OracleDbType.Int16, ParameterDirection.Input);
            ARRPARAM[2].Value = InOut;
            ARRPARAM[3] = new OracleParameter("i_Fecha", OracleDbType.Date, ParameterDirection.Input);
            ARRPARAM[3].Value = DateTime.Today.Date;
            ARRPARAM[4] = new OracleParameter("i_Hora", OracleDbType.Char, ParameterDirection.Input);
            ARRPARAM[4].Value = HoraLogin;
            ARRPARAM[5] = new OracleParameter("i_Hora_Login", OracleDbType.Char, ParameterDirection.Input);
            ARRPARAM[5].Value = "";
            ARRPARAM[6] = new OracleParameter("o_return", OracleDbType.Int16, 4);
            ARRPARAM[6].Direction = ParameterDirection.Output;

            ORACLEHELPER.EjecutarQR("pkg_Users.SP_Insert_Login_Out", ARRPARAM);

        }

    }

    public int Update_Password(BE_USUARIO c)
    {
        int functionReturnValue = 0;
        OracleParameter[] arrParam = new OracleParameter[3];

        arrParam[0] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[0].Value = c.UserId;
        arrParam[1] = new OracleParameter("i_clave", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[1].Value = c.PasswordNuevo;
        arrParam[2] = new OracleParameter("o_return", OracleDbType.Int16, 4);
        arrParam[2].Direction = ParameterDirection.Output;
        ORACLEHELPER.EjecutarQR("pkg_Users.SP_Update_Password", arrParam);
        functionReturnValue = (int)arrParam[2].Value;


        return functionReturnValue;
    }

    public int TipoAcceso(BE_USUARIO paramUser)
    {
        int functionReturnValue = 0;
        OracleParameter[] arrParam = new OracleParameter[6];

        arrParam[0] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[0].Value = paramUser.UserId;
        arrParam[1] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = paramUser.Cod_OP;
        arrParam[2] = new OracleParameter("i_cod_est_insc", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[2].Value = "00";
        arrParam[3] = new OracleParameter("i_aspx", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[3].Value = paramUser.Aspx;
        arrParam[4] = new OracleParameter("o_cod_rol", OracleDbType.Varchar2, 2);
        arrParam[4].Direction = ParameterDirection.Output;
        arrParam[5] = new OracleParameter("o_return", OracleDbType.Int16, 4);
        arrParam[5].Direction = ParameterDirection.Output;

        ORACLEHELPER.EjecutarQR("pkg_Users.SP_Tipo_Acceso", arrParam);

        paramUser.CodPerfil = (string)arrParam[4].Value;

        functionReturnValue = (int)arrParam[5].Value;


        return functionReturnValue;
    }

    public int UpdateUser(BE_USUARIO c)
    {

        OracleParameter[] ARRPARAM = new OracleParameter[14];

        ARRPARAM[0] = new OracleParameter("i_username", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[0].Value = c.UserName;
        ARRPARAM[1] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[1].Value = c.UserID_modulo;
        ARRPARAM[2] = new OracleParameter("i_clave", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[2].Value = c.PasswordInTextBox;
        ARRPARAM[3] = new OracleParameter("i_Fec_ven_cta", OracleDbType.Date, ParameterDirection.Input);
        ARRPARAM[3].Value = c.Fec_Ven_Cta;
        ARRPARAM[4] = new OracleParameter("i_Fec_ven_psw", OracleDbType.Date, ParameterDirection.Input);
        ARRPARAM[4].Value = c.Fec_Ven_Psw;
        ARRPARAM[5] = new OracleParameter("i_cod_rol", OracleDbType.Char, ParameterDirection.Input);
        ARRPARAM[5].Value = c.CodPerfil;
        ARRPARAM[6] = new OracleParameter("i_Fecha", OracleDbType.Date, ParameterDirection.Input);
        ARRPARAM[6].Value = DateTime.Today.Date;
        ARRPARAM[7] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[7].Value = c.Cod_OP;
        ARRPARAM[8] = new OracleParameter("i_cod_ubigeo", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[8].Value = c.UBIGEO;
        ARRPARAM[9] = new OracleParameter("i_cod_ente", OracleDbType.Char, ParameterDirection.Input);
        ARRPARAM[9].Value = c.CodEnte;
        ARRPARAM[10] = new OracleParameter("i_cod_area", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[10].Value = c.Cod_Area;
        ARRPARAM[11] = new OracleParameter("i_fg_estado", OracleDbType.Char, ParameterDirection.Input);
        ARRPARAM[11].Value = c.fg_estado;
        ARRPARAM[12] = new OracleParameter("x_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[12].Value = c.UserId;
        ARRPARAM[13] = new OracleParameter("o_return", OracleDbType.Int16, 4);
        ARRPARAM[13].Direction = ParameterDirection.Output;

        ORACLEHELPER.EjecutarQR(c.storedProcedure, ARRPARAM);

        return (int)ARRPARAM[13].Value;

    }

    public int Puede_Modif_User(string UserId, string Cod_Rol)
    {

        OracleParameter[] arrParam = new OracleParameter[3];


        arrParam[0] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[0].Value = UserId;

        arrParam[1] = new OracleParameter("i_cod_rol", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[1].Value = Cod_Rol;

        arrParam[2] = new OracleParameter("o_return", OracleDbType.Int16);
        arrParam[2].Direction = ParameterDirection.Output;

        ORACLEHELPER.EjecutarQR("pkg_Users.SP_ROLES_MODIF", arrParam);

        return (int)arrParam[2].Value;



    }


}

