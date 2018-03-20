using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Collections;


	[Serializable()]
	public class BE_Afiliados : BE_BASE
	{
        [DataMember(EmitDefaultValue = false, Name = "Cod_DNI")] public string Cod_DNI { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "ApePat")] public string ApePat { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "ApeMat")] public string ApeMat { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Nombres")] public string Nombres { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "NombreCompleto")] public string NombreCompleto { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "En_Padron_Afil")] public string En_Padron_Afil { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "En_Comites")] public string En_Comites { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "En_Directivos")] public string En_Directivos { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "SeqPadronAfil")] public int SeqPadronAfil { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "SeqMin")] public int SeqMin { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "SeqMax")] public int SeqMax { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "Cod_Proc")] public string Cod_Proc { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Nombre_OP")] public string Nombre_OP { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Tipo_OP")] public string Tipo_OP { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "Ubigeo_OP")] public string Ubigeo_OP { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Estado_Insc")] public string Estado_Insc { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Cod_Estado_Insc")] public string Cod_Estado_Insc { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Fec_Estado_Insc")] public string Fec_Estado_Insc { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Fec_Solic_Insc")] public string Fec_Solic_Insc { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "IsAfiliado")] public bool IsAfiliado { get; set; }
   
    [DataMember(EmitDefaultValue = false, Name = "IsRenunciado")] public bool IsRenunciado { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "MensajeAmostrar")] public string MensajeAmostrar { get; set; }
    


    private object _FLESTADOAFILIACION;
    [DataMember(EmitDefaultValue = false, Name = "FLESTADOAFILIACION")]
    public object FLESTADOAFILIACION
    {
        get
        {
            if (_FLESTADOAFILIACION == null) { return 0; }
            else
            {
                if (_FLESTADOAFILIACION.NoNulo())
                {
                    if (_FLESTADOAFILIACION.ToString() == "on") { return 1; }
                    else if (_FLESTADOAFILIACION.ToString() == "1") { return 1; }
                    else { return 0; }
                }
                else { return 0; }
            }
        }
        set { _FLESTADOAFILIACION = value; }
    }
   
    [DataMember(EmitDefaultValue = false, Name = "Estado_Afil")] public string Estado_Afil { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Estado_Afil_Nombre_Largo")] public string Estado_Afil_Nombre_Largo { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Fec_Renuncia")] public string Fec_Renuncia { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Fec_Renun_OP")] public string Fec_Renun_OP { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Fec_Padron_Afil")] public string Fec_Padron_Afil { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Nro_Entrega_Padron")] public string Nro_Entrega_Padron { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Fec_Comite")] public string Fec_Comite { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Fec_Repres")] public string Fec_Repres { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "Comite_name")] public string Comite_name { get; set; }
    //[DataMember(EmitDefaultValue = false, Name = "UbiRegion")] public int UbiRegion { get; set; }
    //[DataMember(EmitDefaultValue = false, Name = "UbiProv")] public int UbiProv { get; set; }
    //[DataMember(EmitDefaultValue = false, Name = "UbiDist")] public int UbiDist { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Region")] public string Region { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Provincia")] public string Provincia { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Distrito")] public string Distrito { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Cod_Ente_Renuncia")] public string Cod_Ente_Renuncia { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Des_Ente_Renuncia")] public string Des_Ente_Renuncia { get; set; }

 
      
    [DataMember(EmitDefaultValue = false, Name = "Observ")] public string Observ { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "FecIni_Afil")] public string FecIni_Afil { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "FecFin_Afil")] public string FecFin_Afil { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "CodExpMTD")] public string CodExpMTD { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "CodDocMTD")] public string CodDocMTD { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "Prefijo_PeriodoAfil")] public string Prefijo_PeriodoAfil { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "IsCandidato_Elecc")] public bool IsCandidato_Elecc { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "Representante")] public BE_Personero Representante { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "arrCandidato")] public ArrayList arrCandidato;
    [DataMember(EmitDefaultValue = false, Name = "liPeriodosAfilAnt")] public List<BE_PeriodosAfilAnt> liPeriodosAfilAnt { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Periodos_Afil_Anteriores")] public string Periodos_Afil_Anteriores { get; set; }

		public string Aspx { get; set; }

		

		public string Fue_Afiliado_OtraOP { get; set; }

		public struct Valores
		{
			public bool EsAfiliado;

			public ArrayList arrAfiliados;
		}

		public struct Mostrar
		{
			public bool MostrarRegistro;

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
        ~BE_Afiliados() { Dispose(false); }
    }
