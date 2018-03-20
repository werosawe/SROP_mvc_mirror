using System;
using System.Runtime.Serialization;

[Serializable()]
public class BE_Etapa : BE_BASE
{
    [DataMember(EmitDefaultValue = false, Name = "MTDEXPTXPREFIJO")] public string MTDEXPTXPREFIJO { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "MTDEXPNUANNO")] public int MTDEXPNUANNO { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "MTDEXPNUEXPEDIENTE")] public int MTDEXPNUEXPEDIENTE { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "MTDCODDOCUMENTO")] public string MTDCODDOCUMENTO { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "MTDDESASUNTO")] public string MTDDESASUNTO { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "MTDCODEXPEDIENTE")] public string MTDCODEXPEDIENTE { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "QTEtapa")] public int QTEtapa { get; set; }
    

    [DataMember(EmitDefaultValue = false, Name = "Cod_Correlativo")] public int Cod_Correlativo { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Cod_Tipo_Etapa")] public string Cod_Tipo_Etapa { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Fec_Estado_Insc")] public DateTime? Fec_Estado_Insc { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Cod_Est_Insc")] public string Cod_Est_Insc { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Cod_Tipo_Cancel")] public string Cod_Tipo_Cancel { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Cod_Ente")] public string Cod_Ente { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Des_Num_Resol")] public string Des_Num_Resol { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Des_Observ")] public string Des_Observ { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Des_Observ_Corta")] public string Des_Observ_Corta { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Hora_AM")] public string Hora_AM { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Hor")] public string Hor { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Min")] public string Min { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Seg")] public string Seg { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "AmPm")] public string AmPm { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Des_Estado_Inscrip")] public string Des_Estado_Inscrip { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Des_Ente")] public string Des_Ente { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Flg_Consulta")] public string Flg_Consulta { get; set; }


    public void pDividirCodigoExpediente()
    {
        if (MTDCODEXPEDIENTE.NoNulo())
        {
            string[] ar = MTDCODEXPEDIENTE.Split(char.Parse("-"));
            if (ar.Length == 3)
            {
                MTDEXPTXPREFIJO = ar[0];
                MTDEXPNUANNO = int.Parse(ar[1]);
                MTDEXPNUEXPEDIENTE = int.Parse(ar[2]);
            }
        }

    }


    public BE_Etapa(int _Cod_OP)
    {
        Cod_OP = _Cod_OP;
    }
    public BE_Etapa() { }

    ////variable para ocultar el primer y ultimo elemento de etapas para evitar la funcionalidad de insertar.
    //public string Flg_Visible { get; set; }


    bool disposed = false;
    protected override void Dispose(bool disposing)
    {
        if (disposed) return;
        if (disposing) { }
        disposed = true;
        base.Dispose(disposing);
    }
    ~BE_Etapa() { Dispose(false); }

}
