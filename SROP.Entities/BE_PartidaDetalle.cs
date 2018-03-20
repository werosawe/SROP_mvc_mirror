using System;
using System.Runtime.Serialization;

	[Serializable()]
	public class BE_PartidaDetalle : BE_Partida
	{

		public int Id_Asig_Tarea { get; set; }
		//public string Cod_Tarea { get; set; }

		public string Tipo_Doc { get; set; }
		public string Des_Tipo_Doc { get; set; }
		public string Num_Doc { get; set; }
		public string Resultado { get; set; }
		public string Des_Resultado { get; set; }

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_PartidaDetalle() { Dispose(false); }
    
}
