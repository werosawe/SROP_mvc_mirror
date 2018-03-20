using System;
using System.Runtime.Serialization;


	[Serializable()]
	public class BE_Reportes : BE_BASE
	{

		public string Ruta { get; set; }
		public string Oficial { get; set; }
		public string PDFName { get; set; }

		
		public string Cod_Tipo_Libro { get; set; }
		public string Cod_Tipo_Doc { get; set; }
		public bool boResolAgrup { get; set; }
    		
		public int Nro_Entrega { get; set; }
		public int ubireg { get; set; }
		public int ubiprov { get; set; }
		public int ubidist { get; set; }
		public string Orden_ComAfil { get; set; }
		public string Fec_carga_comite { get; set; }
		public int Activos_Bajas_Directivos { get; set; }

		public int Nro_ConstanciaOP { get; set; }
		public DateTime? Fecha_ConstOP { get; set; }
		public string DNI_Solic { get; set; }
		public string Nombres_Solic { get; set; }

		

		public string Responsable_Ente { get; set; }
		public string Cargo_Responsable { get; set; }

		public string Cod_Perfil { get; set; }
		public string Cod_Ente { get; set; }
		public string Des_Ente { get; set; }

		public string Logo1 { get; set; }
		public string Logo2 { get; set; }

		public int anos_vigencia_cargo { get; set; }

		public DateTime? FecIni { get; set; }
		public DateTime? FecFin { get; set; }

		public int filtro { get; set; }
		public string search { get; set; }


		public string str_entregas = "";
        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_Reportes() { Dispose(false); }

    }

