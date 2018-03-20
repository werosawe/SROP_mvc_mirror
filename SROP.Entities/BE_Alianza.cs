using System;
using System.Runtime.Serialization;

	[Serializable()]
	public class BE_Alianza : BE_BASE
	{

    [DataMember(EmitDefaultValue = false, Name = "proceso_elecc")] public string proceso_elecc { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "ubireg")] public int ubireg { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "ubiprov")] public int ubiprov { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "ubidist")] public int ubidist { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "cod_op_asoc")] public int cod_op_asoc { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "des_op_asoc")] public string des_op_asoc { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Num_Resol_Alianza")] public string Num_Resol_Alianza { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Observ")] public string Observ { get; set; }

    private object _FLASOCIADO;
    [DataMember(EmitDefaultValue = false, Name = "FLASOCIADO")]
    public object FLASOCIADO
    {
        get
        {
            if (_FLASOCIADO == null) { return 0; }
            else
            {
                if (_FLASOCIADO.NoNulo())
                {
                    if (_FLASOCIADO.ToString() == "on") { return 1; }
                    else if (_FLASOCIADO.ToString() == "1") { return 1; }
                    else { return 0; }
                }
                else { return 0; }
            }
        }
        set { _FLASOCIADO = value; }
    }
    

    [DataMember(EmitDefaultValue = false, Name = "IDProcesoElec")] public string IDProcesoElec { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "TXProcesoElec")] public string TXProcesoElec { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "Cod_Tipo_Elecc")] public string Cod_Tipo_Elecc { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Des_Tipo_Elecc")] public string Des_Tipo_Elecc { get; set; }
    
    [DataMember(EmitDefaultValue = false, Name = "EnableDdlReg")] public bool EnableDdlReg { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "EnableDdlProv")] public bool EnableDdlProv { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "EnableDdlDist")] public bool EnableDdlDist { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Cod_Ente")] public string Cod_Ente { get; set; }

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_Alianza() { Dispose(false); }
    }

