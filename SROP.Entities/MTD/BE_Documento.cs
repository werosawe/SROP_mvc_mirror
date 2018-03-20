using System;
using System.Runtime.Serialization;

namespace MTD.BE
{
    [Serializable()]
    public class BE_Documento : BE_BASE, MTDComun
    {
        
        [DataMember(EmitDefaultValue = false, Name = "CODDOCUMENTO")] public string CODDOCUMENTO { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "CODEXPEDIENTE")] public string CODEXPEDIENTE { get; set; }


        [DataMember(EmitDefaultValue = false, Name = "FERECEPCION")] public string FERECEPCION { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "DESASUNTO")] public string DESASUNTO { get; set; }


        [DataMember(EmitDefaultValue = false, Name = "TXPREFIJO")] public string TXPREFIJO { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "NUANNO")] public int NUANNO { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "NUEXPEDIENTE")] public int NUEXPEDIENTE { get; set; }


        public void pCODEXPEDIENTE() { CODEXPEDIENTE = string.Concat(TXPREFIJO, "-", NUANNO, "-", NUEXPEDIENTE.CerosIzquierda(6)); }

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_Documento() { Dispose(false); }
    }
}
