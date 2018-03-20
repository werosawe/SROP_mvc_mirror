using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


[Serializable()]
public class BE_USUARIO : BE_BASE
{
    public string DesEnteCorto { get; set; }
    public string DesEnteCorto2 { get; set; }

    [text(3, 30, "Ingrese usuario")]
    [DataMember(EmitDefaultValue = false, Name = "UserName")]
    public string UserName { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "Cod_Rol")] public string Cod_Rol { get; set; }

    public string Ambito { get; set; }
    public string Des_Rol { get; set; }

    private object _FLOFICIO;
    [DataMember(EmitDefaultValue = false, Name = "FLOFICIO")]
    public object FLOFICIO
    {
        get
        {
            if (_FLOFICIO == null) { return 0; }
            else
            {
                if (_FLOFICIO.NoNulo())
                {
                    if (_FLOFICIO.ToString() == "on") { return 1; }
                    else if (_FLOFICIO.ToString() == "1") { return 1; }
                    else { return 0; }
                }
                else { return 0; }
            }
        }
        set { _FLOFICIO = value; }
    }

    public string Aspx { get; set; }

  
    public string CodEnte { get; set; }
    public DateTime? Fec_Ven_Cta { get; set; }
    public DateTime? Fec_Ven_Psw { get; set; }
    public DateTime? Fec_Crea { get; set; }

    public string fg_estado { get; set; }
    public string storedProcedure { get; set; }
    public string UserID_modulo { get; set; }
    //public int UbiRegion { get; set; }
    public string UserHostName { get; set; }
    public string Cod_Area { get; set; }
    public string DesEnte { get; set; }
    public string DesArea { get; set; }


    [text(3, 30, "Ingrese clave")]
    [DataMember(EmitDefaultValue = false, Name = "PasswordInTextBox")]
    public string PasswordInTextBox { get; set; }


    [text(3, 30, "Ingrese código")]
    [DataMember(EmitDefaultValue = false, Name = "TXCAPCHA")] public string TXCAPCHA { get; set; }

    

    [text(3, 30, "Ingrese clave")]
    [DataMember(EmitDefaultValue = false, Name = "UserName")]
    public string PasswordInDB { get; set; }


    public string PasswordNuevo { get; set; }
    public int PasswordSize { get; set; }
    public int UserExiste { get; set; }
    public string MensajeDeLogeo { get; set; }
    public bool VencioCta { get; set; }
    public bool VencioPsw { get; set; }
    public string IP { get; set; }
    public string CodPerfil { get; set; }
    public string DesPerfil { get; set; }

    public string DesCargo { get; set; }

    public bool ForzarCambioPsw { get; set; }

    public int MaxErrorLogin { get; set; }

    [text(3, 30, "Ingrese usuario")]
    [DataMember(EmitDefaultValue = false, Name = "UserId")]
    public string UserId { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "Paginas")]
    public List<BE_PAGINA> Paginas { get; set; }


    bool disposed = false;
    protected override void Dispose(bool disposing)
    {
        if (disposed) return;
        if (disposing) { }
        disposed = true;
        base.Dispose(disposing);
    }
    ~BE_USUARIO() { Dispose(false); }
}

