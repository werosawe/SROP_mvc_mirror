using System;
using System.Runtime.Serialization;
   
    [Serializable()]
    [DataContract()]
    public class BE_Abogado : BE_BASE
	{
        [DataMember(EmitDefaultValue = false, Name = "ID_CODIGO")] public string ID_CODIGO { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "TX_DESCRIPCION")]  public string TX_DESCRIPCION { get; set; }        
        [DataMember(EmitDefaultValue = false, Name = "UserIdaSis")] public string UserIdaSis { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "Abogado_ID")]  public string Abogado_ID { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "Id_Asig_Abogado")]  public string Id_Asig_Abogado { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "Fec_Ini")]   public DateTime? Fec_Ini { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "Fec_Fin")]  public DateTime? Fec_Fin { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "UserName")] public string UserName { get; set; }
      

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_Abogado() { Dispose(false); }
    }
