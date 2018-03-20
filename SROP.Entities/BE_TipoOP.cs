using System;
using System.Runtime.Serialization;

[Serializable()]
public class BE_TipoOP : BE_BASE
{
    public struct EstadoDeCombos_ExpOP
    {
        public int ComboAmbito_SelectedIndex;
        public bool ComboAmbitoIsEnabled;
        public int ComboLibro_SelectedIndex;
        public bool ComboRegionIsEnabled;
        public bool ComboProvinciaIsEnabled;
        public bool ComboDistritoIsEnabled;
    }

    [DataMember(EmitDefaultValue = false, Name = "DES_TIPO_OP")] public string DES_TIPO_OP;
    [DataMember(EmitDefaultValue = false, Name = "COD_AMBITO")] public string COD_AMBITO;
    [DataMember(EmitDefaultValue = false, Name = "COD_TIPO_LIBRO")] public string COD_TIPO_LIBRO;
    [DataMember(EmitDefaultValue = false, Name = "ENABLE_DDL_AMB")] public string ENABLE_DDL_AMB;
    [DataMember(EmitDefaultValue = false, Name = "ENABLE_DDL_PROV")] public string ENABLE_DDL_PROV;
    [DataMember(EmitDefaultValue = false, Name = "ENABLE_DDL_REG")] public string ENABLE_DDL_REG;
    [DataMember(EmitDefaultValue = false, Name = "ENABLE_DDL_DIST")] public string ENABLE_DDL_DIST;

    private object _FLSIMBOLO;
    [DataMember(EmitDefaultValue = false, Name = "FLSIMBOLO")]
    public object FLSIMBOLO
    {
        get
        {
            if (_FLSIMBOLO == null) { return 0; }
            else
            {
                if (_FLSIMBOLO.NoNulo())
                {
                    if (_FLSIMBOLO.ToString() == "on") { return 1; }
                    else if (_FLSIMBOLO.ToString() == "1") { return 1; }
                    else { return 0; }
                }
                else { return 0; }
            }
        }
        set { _FLSIMBOLO = value; }
    }
       

    bool disposed = false;
    protected override void Dispose(bool disposing)
    {
        if (disposed) return;
        if (disposing) { }
        disposed = true;
        base.Dispose(disposing);
    }
    ~BE_TipoOP() { Dispose(false); }

}
