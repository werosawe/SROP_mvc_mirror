using System;
using System.Runtime.Serialization;
using System.Collections.Generic;


	[Serializable()]
	public class BE_RenunciaEval : BE_BASE
	{
		public string Cod_DNI { get; set; }
		public string CodExpMTD { get; set; }
		public string CodDocMTD { get; set; }
		public string ID_TipoRenuncia { get; set; }
		public string TX_TipoRenuncia { get; set; }

		public string UserName { get; set; }
		

		public List<BE_RenunciaEval_Det> lista_RenunciaEval { get; set; }

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_RenunciaEval() { Dispose(false); }
    }



	[Serializable()]
	public class BE_RenunciaEval_Det : BE_BASE
	{

		public int ID_Estado { get; set; }
		public string TX_Estado { get; set; }
		public int ID_ResultadoEval { get; set; }
		public string TX_ResultadoEval { get; set; }
		public int ID_Motivo { get; set; }
		public string TX_Motivo { get; set; }
		public DateTime? Fec_Eval { get; set; }

		public string UserName { get; set; }
		

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_RenunciaEval_Det() { Dispose(false); }
    }

