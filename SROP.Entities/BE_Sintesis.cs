using System;
using System.Runtime.Serialization; using System.Collections.Generic;

[Serializable()]
public class BE_Sintesis : BE_BASE
{
    [DataMember(EmitDefaultValue = false, Name = "File_Path")] public string File_Path { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "File_Name")] public string File_Name { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Fec_Doc")] public string Fec_Doc { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Tx_SintesInsc")] public string Tx_SintesInsc { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Tx_Simbolo")] public string Tx_Simbolo { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Tx_Des_OP")] public string Tx_Des_OP { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Tx_Des_Tipo_OP")] public string Tx_Des_Tipo_OP { get; set; }


    //[DataMember(EmitDefaultValue = false, Name = "BLSimbolo")] public byte[] BLSimbolo { get; set; }

    //Public Property Img_Simbolo As String
    [DataMember(EmitDefaultValue = false, Name = "Tx_Fundadores")] public string Tx_Fundadores { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Tx_Dirigentes")] public string Tx_Dirigentes { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Tx_Apoderados")] public string Tx_Apoderados { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Tx_PersoLegal")] public string Tx_PersoLegal { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Tx_PersoTecni")] public string Tx_PersoTecni { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Tx_RepreLegal")] public string Tx_RepreLegal { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Tx_Tesorero")] public string Tx_Tesorero { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Tx_Domiclegal")] public string Tx_Domiclegal { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Tx_ResumenEstatuto")] public string Tx_ResumenEstatuto { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Directivos")] public List<BE_Representantes> Directivos { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "FirmadoPor")] public string FirmadoPor { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "CargoSede")] public string CargoSede { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Ciudad")] public string Ciudad { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "Visible")] public int Visible { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Existe")] public bool Existe { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "tx_OrgPol_Alianza")] public string tx_OrgPol_Alianza { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "tx_ProcElec_Alianza")] public string tx_ProcElec_Alianza { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "tx_Siglas")] public string tx_Siglas { get; set; }
      
    [DataMember(EmitDefaultValue = false, Name = "URL_Sintesis_OP")] public string URL_Sintesis_OP { get; set; }
   

    bool disposed = false;
    protected override void Dispose(bool disposing)
    {
        if (disposed) return;
        if (disposing) { }
        disposed = true;
        
        base.Dispose(disposing);
    }
    ~BE_Sintesis() { Dispose(false); }
}
