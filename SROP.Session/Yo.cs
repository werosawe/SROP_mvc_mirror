using System.Web;
using System.Collections.Generic;
public static class Yoo
{
    public static string UserId { get { return Yo().UserId; } }
    public static string UserName { get { return Yo().UserName; } }
    public static string PasswordInDB { get { return Yo().PasswordInDB; } }
    public static string CodEnte { get { return Yo().CodEnte; } }
    public static string CodPerfil { get { return Yo().CodPerfil; } }
    public static bool VencioCta { get { return Yo().VencioCta; } }
    public static bool VencioPsw { get { return Yo().VencioPsw; } }
    public static string UBIREGION { get { return Yo().UBIREGION; } }
    public static object FLOFICIO { get { return Yo().FLOFICIO; } }
    public static object Cod_Rol { get { return Yo().Cod_Rol; } }
    public static List<BE_PAGINA> Paginas { get { return Yo().Paginas; } }
    

    //public static List<BE_PAGINA> Paginas { get { return null; } }

    public static BE_USUARIO Yo()
    {
        //fDesSerializar(Of BE_GLOBAL_SESSION)(CType(System.Web.HttpContext.Current.Session.Item(NO_GLOBAL_SESSION), String))
        //BE_USUARIO i = new BE_USUARIO();
        if (HttpContext.Current.Session[CO_Constante.VariableGlobalSession] != null)
        { return System.Web.HttpContext.Current.Session[CO_Constante.VariableGlobalSession].Text().DesSerializar<BE_USUARIO>(); }
        else
        { return null; }
    }
 
    public static void Yo(string TX_SESSION)
    {
        //HttpContext.Current.Session.Add(NO_GLOBAL, TX_SESSION);
        System.Web.HttpContext.Current.Session[CO_Constante.VariableGlobalSession] = TX_SESSION;
    }
}
