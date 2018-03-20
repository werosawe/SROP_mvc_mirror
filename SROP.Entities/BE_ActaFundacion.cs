using System;
using System.Runtime.Serialization;

    [Serializable()]
    public class BE_ActaFundacion : BE_BASE
	{
        
    [DataMember(EmitDefaultValue = false, Name = "Cod_Req")] public string Cod_Req { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Cod_Item")] public string Cod_Item { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Des_Item")] public string Des_Item { get; set; }

    private object _FLTITULO;
    [DataMember(EmitDefaultValue = false, Name = "FLTITULO")]
    public object FLTITULO
    {
        get
        {
            if (_FLTITULO == null) { return 0; }
            else
            {
                if (_FLTITULO.NoNulo())
                {
                    if (_FLTITULO.ToString() == "on") { return 1; }
                    else if (_FLTITULO.ToString() == "1") { return 1; }
                    else { return 0; }
                }
                else { return 0; }
            }
        }
        set { _FLTITULO = value; }
    }
       
    [DataMember(EmitDefaultValue = false, Name = "Art_Doc")] public string Art_Doc { get; set; }
  
    [DataMember(EmitDefaultValue = false, Name = "Observ")] public string Observ { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Art_Ley")] public string Art_Ley { get; set; }
		


        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_ActaFundacion() { Dispose(false); }
    }
