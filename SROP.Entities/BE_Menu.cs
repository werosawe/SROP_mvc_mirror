using System;
using System.Collections;
using System.Runtime.Serialization;

	public class BE_Menu : BE_BASE
	{	
		public ArrayList ArrayMenuHijo { get; set; }
        public string ItemMenu { get; set; }
        public string URL { get; set; }
        public string Mensaje { get; set; }
        public string Padre { get; set; }
        public string Cod_Padre { get; set; }
        public string Codigo { get; set; }       

        //public ArrayList ArrayMenuHijo { get; set; }

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_Menu() { Dispose(false); }
    }
