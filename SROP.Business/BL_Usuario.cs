using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Data;
using System.Security.Cryptography;
using System.IO;
using System.Text;



public class BL_USUARIO : BL_BASE
{
    private DA_Usuario data;

    public List<BE_USUARIO> Listar_Usuarios()
    {
        List<BE_USUARIO> r = new List<BE_USUARIO>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Listar_Usuarios(cn);
            while (dr.Read())
            {
                BE_USUARIO i = Llenar_BE_Usuario(dr);
                r.Add(i);
            }

            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }

    public List<BE_USUARIO> Listar_Usuarios_Search(string search, int filtro)
    {
        List<BE_USUARIO> r = new List<BE_USUARIO>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_Usuarios_Search(cn, search, filtro);
        while (dr.Read())
        {
            BE_USUARIO i = Llenar_BE_Usuario(dr);
            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;

    }


    private BE_USUARIO Llenar_BE_Usuario(OracleDataReader dr)
    {
        BE_USUARIO i = new BE_USUARIO();
        i.UserId = dr.Text("UserId");
        i.UserName = dr.Text("UserName");
        i.PasswordInDB = dr.Text("clave");
        i.Cod_Rol = dr.Text("Cod_Rol");
        i.Ambito = dr.Text("ambito");
        i.Des_Rol = dr.Text("des_rol");
        i.Cod_OP = dr.Num("cod_op");
        i.Des_OP = dr.Text("des_op");
        i.fg_estado = dr.Text("fg_activo");
        i.CodEnte = dr.Text("cod_ente");
        if (dr["Fec_Ven_Cta"] != null)
        {
            i.Fec_Ven_Cta = Convert.ToDateTime(dr["Fec_Ven_Cta"]);
        }

        if (dr["Fec_Ven_Psw"] != null)
        {
            i.Fec_Ven_Psw = Convert.ToDateTime(dr["Fec_Ven_Psw"]);
        }

        if (dr["x_fecha_crea"] != null)
        {
            i.Fec_Crea = Convert.ToDateTime(dr["x_fecha_crea"]);
        }


        i.Cod_Area = dr.Text("cod_area");

        i.DesEnte = dr.Text("des_ente");
        i.DesArea = dr.Text("des_area");
        return i;
    }

    public BE_USUARIO Autenticacion_DT(BE_USUARIO c)
    {
        BE_USUARIO i = null;
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            c.PasswordInTextBox = Encrypt(c.PasswordInTextBox.Text(), "&%#@?,:*");
            dr = data.Verifica_Usuario(cn, c);
            if (dr.Read())
            {
                i = new BE_USUARIO();
                i.UserId = dr.Text("userid");
                i.UserName = dr.Text("username");
                i.Cod_Rol = dr.Text("cod_rol");
                i.CodEnte = dr.Text("cod_ente");
                i.Cod_Area = dr.Text("cod_area");
            }
            return i;
        }
        finally { pCerrarDr(cn, dr); }
    }

    public bool Autenticacion(BE_USUARIO c)
    {
        c.PasswordInTextBox = Encrypt(c.PasswordInTextBox.Text(), "&%#@?,:*");

        data.Autenticacion(c);
        //el usuario y password coinciden existe                
        if (c.UserExiste == 1)
        {

            return true;
        }
        else
        {
            // Usuario y password no coinciden
            c.MensajeDeLogeo = "Datos no válidos";
            return false;
        }

    }

    public string Encrypt(string strText, string strEncrKey)
    {
        byte[] byKey = { };
        byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
        try
        {
            byKey = System.Text.Encoding.UTF8.GetBytes(strEncrKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(strText);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string Decrypt(string strText, string sDecrKey)
    {
        byte[] byKey = { };
        byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
        byte[] inputByteArray = new byte[strText.Length];
        try
        {
            byKey = System.Text.Encoding.UTF8.GetBytes(sDecrKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(strText);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public BE_USUARIO GetDatos_User(BE_USUARIO c)
    {
        BE_USUARIO i = null;
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.GetDatos_User(cn, c);
            while (dr.Read())
            {
                i = new BE_USUARIO();
                i.UserId = dr.Text("UserId").Minuscula();
                i.UserName = dr.Text("UserName");
                i.VencioCta = dr.Text("VencioCta").Text() == "1" ? true : false;
                i.VencioPsw = dr.Text("VencioPsw").Text() == "1" ? true : false;
                i.CodEnte = dr.Text("Cod_Ente");
                i.DesEnteCorto = dr.Text("Des_Ente_corto");
                i.DesEnteCorto2 = dr.Text("Des_Ente_corto2");
                i.CodPerfil = dr.Text("Cod_Rol");
                i.DesPerfil = dr.Text("Des_Rol");
                i.DesEnte = dr.Text("Des_Ente");
                i.UBIREGION = dr.Text("UbiRegion");
                i.FLOFICIO = dr.Num("flg_doc_ofic");
            }
            return i;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }

    public bool Puede_Mirar_Boton_BuevoExp(BE_USUARIO c)
    {
        return data.Puede_Mirar_Boton_NuevoExp(null, c);
    }

    public bool Puede_Mirar_Boton_Bloq(BE_USUARIO c)
    {
        return data.Puede_Mirar_Boton_Bloq(null, c);
    }

    public bool ValidacionesDeUsuario(BE_USUARIO c)
    {
        if (c.VencioCta)
        {
            c.MensajeDeLogeo = "No está autorizado a ingresar...Su cuenta en ROP ha expirado";
            return false;
        }
        if (c.VencioPsw)
        {
            c.MensajeDeLogeo = "No está autorizado a ingresar...Su clave en ROP ha expirado";
            return false;
        }
        //If oUser.NumLogins < 1 Then
        //    BE_User.Forzar_Cambio_Password=True
        //    Return False
        //End If
        return true;
    }
    public bool CambiarPassword(BE_USUARIO BE_User)
    {
        if (BE_User.PasswordNuevo.Length < BE_User.PasswordSize)
        {
            BE_User.MensajeDeLogeo = "Clave debe tener al menos 10 caracteres...";
            return false;
        }


        BE_User.PasswordNuevo = Encrypt(BE_User.PasswordNuevo, "&%#@?,:*");

        int ret = data.Update_Password(BE_User);

        switch (ret)
        {
            case 0:
                BE_User.MensajeDeLogeo = "Clave incorrecta, corriga los datos...";
                return false;
            case 1:
                BE_User.MensajeDeLogeo = "Se ha registrado cambio de Clave ...";
                return true;
            default:
                throw new Exception();
        }
    }
    public void Insert_Logins(BE_USUARIO BE_User)
    {
        data.Insert_Login_Out(null, BE_User, 1);

    }

    public void Insert_Logout(BE_USUARIO BE_User)
    {
        data.Insert_Login_Out(null, BE_User, 0);

    }
    public string TipoAcceso(BE_USUARIO BE)
    {

        int ret = data.TipoAcceso(BE);

        switch (ret)
        {
            case -1:
                //No tiene acceso
                return "*";
            case 0:
                //acceso de consulta
                return "C";
            case 1:
                //acceso para modif
                return "A";
        }
        return null;

    }

    public int UpdateUser(BE_USUARIO BE_User)
    {

        DA_Usuario data = new DA_Usuario();
        return data.UpdateUser(BE_User);

    }

    public List<BE_BusquedaOP> Filtra_OP_Por_Departamento(List<BE_BusquedaOP> ListaOP, BE_USUARIO BE_User)
    {
        List<BE_BusquedaOP> LISTA = new List<BE_BusquedaOP>();
        bool Adiciona = false;


        if (Funciones.Es_Registrador_Provincia(BE_User.CodPerfil) == true)
        {

            foreach (BE_BusquedaOP x in ListaOP)
            {
                // La Region del Registador Departamental
                if (x.UBIREGION == BE_User.UBIREGION)
                {
                    Adiciona = true;
                }

                // Partidos Politicos
                if (x.Cod_Tipo_OP == "01")
                {
                    Adiciona = true;
                }

                // Alianza Electoral de Alcance Nacional
                if (x.Cod_Tipo_OP == "05")
                {
                    if (x.UBIREGION.Num() == 0)
                    {
                        Adiciona = true;
                    }
                }

                if (Adiciona == true)
                {
                    LISTA.Add(x);
                    Adiciona = false;
                }

            }

        }
        return (LISTA);
    }


    public int Puede_Modif_User(string UserId, string Cod_Rol)
    {
        return data.Puede_Modif_User(UserId, Cod_Rol);

    }


    public BL_USUARIO() { data = new DA_Usuario(); }
    bool disposed = false;
    protected override void Dispose(bool disposing)
    {
        if (disposed) return;
        if (disposing)
        {
            data.Dispose(); data = null;
        }
        disposed = true;
        base.Dispose(disposing);
    }

    //Public Function GetPermisos_User_Pag(ByVal UserId As String, ByVal Pagina As String) As List(Of BE_USUARIO)
    //    Dim r As New List(Of BE_USUARIO)
    //    Dim cn As New OracleConnection(TX_ESQUEMA)
    //    Dim dr As OracleDataReader = Nothing
    //    Dim data As New DA_Usuario
    //    Try
    //        dr = data.GetPermisos_User_Pag(cn, UserId, Pagina)
    //        While dr.Read
    //            Dim i As New BE_USUARIO


    //            i.ID_REGION = Dame_Texto(dr("UBIREGION"))
    //            i.TX_REGION = Dame_Texto(dr("REGION"))

    //            r.Add(i)
    //        End While

    //        Return r
    //    Catch ex As Exception
    //        Throw ex
    //    Finally
    //        pCerrarDr(cn, dr)
    //    End Try
    //End Function

    //Public Function PuedeAcceder_Pag(ByVal UserId As String, ByVal Pagina As String) As Boolean

    //    Dim cn As New OracleConnection(TX_ESQUEMA)

    //    Dim data As New DA_Usuario
    //    Try
    //        If data.Count_Pagina_UserId(cn, UserId, Pagina) = 0 Then
    //            PuedeAcceder_Pag = False
    //        Else
    //            PuedeAcceder_Pag = True
    //        End If

    //    Catch ex As Exception
    //        Throw ex

    //    End Try
    //End Function

    //Public Function KeepSame_IP(ByVal UserId As String, ByVal IP As String) As Boolean

    //    Dim cn As New OracleConnection(TX_ESQUEMA)

    //    Dim data As New DA_Usuario
    //    Try
    //        If data.Count_IP_UserId(cn, UserId, IP) = 0 Then
    //            KeepSame_IP = False
    //        Else
    //            KeepSame_IP = True
    //        End If

    //    Catch ex As Exception
    //        Throw ex
    //    End Try
    //End Function
}

