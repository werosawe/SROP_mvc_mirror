using System;
using System.Runtime.Serialization;

	[Serializable()]
	public class BE_Resolucion : BE_BASE
	{

	
		public string Orden { get; set; }
		public string Orden_Show { get; set; }
		public string Cod_Tipo_Doc { get; set; }
		public string Des_Doc { get; set; }
		public string Des_Doc_Show { get; set; }
		public string File_Name { get; set; }
		public DateTime? Fec_Doc { get; set; }
		public string Des_Tipo_Doc { get; set; }
		public string Observ { get; set; }
		public string Url_Resol_Rop { get; set; }
		
		public DateTime? Fec_Eleva { get; set; }

		public string Nro_Resol_Pleno { get; set; }
		public string File_Resol_Pleno { get; set; }
		public string Url_Resol_Pleno { get; set; }
		public DateTime? Fec_Resol_Pleno { get; set; }
		public string Des_Resul_Pleno { get; set; }
		public string Des_Resul_Pleno_Ext { get; set; }

		public string Cod_Resul_Pleno { get; set; }
		public string Nro_Resol_Pleno_Ext { get; set; }
		public string File_Resol_Pleno_Ext { get; set; }
		public string Url_Resol_Pleno_Ext { get; set; }
		public DateTime? Fec_Resol_Pleno_Ext { get; set; }
		public string Cod_Resul_Pleno_Ext { get; set; }
		
		


    private object _FLTIENEDETALLE;
    [DataMember(EmitDefaultValue = false, Name = "FLTIENEDETALLE")]
    public object FLTIENEDETALLE
    {
        get
        {
            if (_FLTIENEDETALLE == null) { return 0; }
            else
            {
                if (_FLTIENEDETALLE.NoNulo())
                {
                    if (_FLTIENEDETALLE.ToString() == "on") { return 1; }
                    else if (_FLTIENEDETALLE.ToString() == "1") { return 1; }
                    else { return 0; }
                }
                else { return 0; }
            }
        }
        set { _FLTIENEDETALLE = value; }
    }

    private object _FLTIENEAUTO;
    [DataMember(EmitDefaultValue = false, Name = "FLTIENEAUTO")]
    public object FLTIENEAUTO
    {
        get
        {
            if (_FLTIENEAUTO == null) { return 0; }
            else
            {
                if (_FLTIENEAUTO.NoNulo())
                {
                    if (_FLTIENEAUTO.ToString() == "on") { return 1; }
                    else if (_FLTIENEAUTO.ToString() == "1") { return 1; }
                    else { return 0; }
                }
                else { return 0; }
            }
        }
        set { _FLTIENEAUTO = value; }
    }



    public BE_ResolucionDetalle ResolucionesPleno { get; set; }

		public DateTime? Fec_Notif_Pleno { get; set; }
		public DateTime? Fec_Notif_Ext { get; set; }

		public string Sumilla { get; set; }

		public string Cod_Tipo_Resol { get; set; }
		public string Des_Tipo_Resol { get; set; }

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_Resolucion() { Dispose(false); }
    }

