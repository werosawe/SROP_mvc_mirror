using System;
using System.Runtime.Serialization;

	[Serializable()]
public class BE_MotivoVin : BE_BASE
{
    public string Cod_Motivo { get; set; }
    public string Des_Motivo { get; set; }

  
    public int cod_op_vin { get; set; }
  
    public string des_tipo_op { get; set; }
    public DateTime? fec_vin { get; set; }
    public string Des_Estado_Inscrip { get; set; }
    public string region { get; set; }
    public string provincia { get; set; }
    public string distrito { get; set; }

    public string Cod_Motivo_Vin { get; set; }


    public struct Check
    {
        public int retorno;
        public string Mensaje;

    }


    bool disposed = false;
    protected override void Dispose(bool disposing)
    {
        if (disposed) return;
        if (disposing) { }
        disposed = true;
        base.Dispose(disposing);
    }
    ~BE_MotivoVin() { Dispose(false); }

}