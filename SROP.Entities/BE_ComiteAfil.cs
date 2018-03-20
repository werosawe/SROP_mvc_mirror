using System;
using System.Runtime.Serialization;

[Serializable()]
public class BE_ComiteAfil : BE_BASE
{

   
    public int Num_Pag { get; set; }
    public int Num_Ite { get; set; }
    public string Des_Estado_Inscrip { get; set; }
    public string Cod_Dni { get; set; }
    public string Nombres { get; set; }
    public string ApPat { get; set; }
    public string ApMat { get; set; }
    public string CodDep { get; set; }
    public string CodPro { get; set; }
    public string CodDis { get; set; }
    public string Fecha { get; set; }
    public int Nro_Entrega { get; set; }




    private object _FLRENUNCIA;
    [DataMember(EmitDefaultValue = false, Name = "FLRENUNCIA")]
    public object FLRENUNCIA
    {
        get
        {
            if (_FLRENUNCIA == null) { return 0; }
            else
            {
                if (_FLRENUNCIA.NoNulo())
                {
                    if (_FLRENUNCIA.ToString() == "on") { return 1; }
                    else if (_FLRENUNCIA.ToString() == "1") { return 1; }
                    else { return 0; }
                }
                else { return 0; }
            }
        }
        set { _FLRENUNCIA = value; }
    }

    //public int UbiRegion { get; set; }
    //public int UbiProv { get; set; }
    //public int UbiDist { get; set; }
    public string Region { get; set; }
    public string Provincia { get; set; }
    public string Distrito { get; set; }
    public string Des_Motivo_Inval { get; set; }
    public string Des_Motivo_Baja { get; set; }
    public string Cod_Resultado_VF { get; set; }
    public int Cod_Motivo_Baja { get; set; }
    public string Codr_VF { get; set; }


    private object _FLDJ;
    [DataMember(EmitDefaultValue = false, Name = "FLDJ")]
    public object FLDJ
    {
        get
        {
            if (_FLDJ == null) { return 0; }
            else
            {
                if (_FLDJ.NoNulo())
                {
                    if (_FLDJ.ToString() == "on") { return 1; }
                    else if (_FLDJ.ToString() == "1") { return 1; }
                    else { return 0; }
                }
                else { return 0; }
            }
        }
        set { _FLDJ = value; }
    }



    public string Tipo_Insercion { get; set; }

    public string Cond_Busqueda { get; set; }
    //usado para enviar parametro de busqueda por nombre o dni

    bool disposed = false;
    protected override void Dispose(bool disposing)
    {
        if (disposed) return;
        if (disposing) { }
        disposed = true;
        base.Dispose(disposing);
    }
    ~BE_ComiteAfil() { Dispose(false); }
}

