using System;
using System.Runtime.Serialization;
[Serializable()]
public class BE_OP : BE_BASE
{
    public BE_OP() { }

    public BE_OP(int Cod_OP_) { Cod_OP = Cod_OP_;  }

    

    [DataMember(EmitDefaultValue = false, Name = "FLTIENESIMBOLO")] public int FLTIENESIMBOLO { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "Des_Siglas")] public string Des_Siglas { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Img_Simbolo_Op")] public byte[] Img_Simbolo_Op { get; set; }
    
    [DataMember(EmitDefaultValue = false, Name = "Des_Tipo_Op")] public string Des_Tipo_Op { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Cod_Estado_Insc")] public string Cod_Estado_Insc { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Des_Estado_Inscrip")] public string Des_Estado_Inscrip { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Estado_Op")] public string Estado_Op { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Fec_Estado_Insc")] public DateTime? Fec_Estado_Insc { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Fec_inscripcion")] public DateTime? Fec_inscripcion { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "Des_Ambito")] public string Des_Ambito { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "COD_REQUISITO")] public string COD_REQUISITO { get; set; }
    


    [text(0, 0, "Ingrese tipo Libro")] [DataMember(EmitDefaultValue = false, Name = "Des_Tipo_Libro")] public string Des_Tipo_Libro { get; set; }

    [number(0, 0, "Ingrese Tomo")] [DataMember(EmitDefaultValue = false, Name = "Nro_Tomo")] public int Nro_Tomo { get; set; }

    [number(0, 0, "Ingrese Partida")] [DataMember(EmitDefaultValue = false, Name = "Nro_Partida")] public int Nro_Partida { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "Des_Domicilio_Legal")] public string Des_Domicilio_Legal { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Des_Domicilio_Procesal")] public string Des_Domicilio_Procesal { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Tip_Calle_Domleg")] public string Tip_Calle_Domleg { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Num_Num_Domleg")] public string Num_Num_Domleg { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Tip_Calle_Domproc")] public string Tip_Calle_Domproc { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Num_Num_Domproc")] public string Num_Num_Domproc { get; set; }
    //[DataMember(EmitDefaultValue = false, Name = "Ubidistrito")] public int Ubidistrito { get; set; }
    //[DataMember(EmitDefaultValue = false, Name = "Ubiprovincia")] public int Ubiprovincia { get; set; }
    //[DataMember(EmitDefaultValue = false, Name = "Ubiregion")] public int Ubiregion { get; set; }
   
    [DataMember(EmitDefaultValue = false, Name = "Des_Telef_Op_01")] public string Des_Telef_Op_01 { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Des_Telef_Op_02")] public string Des_Telef_Op_02 { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Des_Fax_Op")] public string Des_Fax_Op { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Des_Correo_Op")] public string Des_Correo_Op { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Fec_Adq_Kit")] public DateTime? Fec_Adq_Kit { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Fec_Ven_Kit")] public DateTime? Fec_Ven_Kit { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Observaciones")] public string Observaciones { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Pag_Web")] public string Pag_Web { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Region")] public string Region { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Provincia")] public string Provincia { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Distrito")] public string Distrito { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Reg_Domic_Legal")] public string Reg_Domic_Legal { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Prov_Domic_Legal")] public string Prov_Domic_Legal { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Dist_Domic_Legal")] public string Dist_Domic_Legal { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Reg_Domic_Procesal")] public string Reg_Domic_Procesal { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Prov_Domic_Procesal")] public string Prov_Domic_Procesal { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Dist_Domic_Procesal")] public string Dist_Domic_Procesal { get; set; }



    [DataMember(EmitDefaultValue = false, Name = "Cod_Arc")] public string Cod_Arc { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Num_Tom_Leg")] public string Num_Tom_Leg { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Num_Tom_Pla")] public string Num_Tom_Pla { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Tx_Ubic_Arc")] public string Tx_Ubic_Arc { get; set; }

    private string _Asistente;
    [DataMember(EmitDefaultValue = false, Name = "Asistente")] public string Asistente { get { if (_Asistente.NoNulo()) { return _Asistente; } else { return "(sin usuario)"; } } set { _Asistente = value; } }

    [DataMember(EmitDefaultValue = false, Name = "Des_Tarea_Estado")] public string Des_Tarea_Estado { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Trf_Estado_Inscrip")] public string Trf_Estado_Inscrip { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Trf_Tipo_Op")] public string Trf_Tipo_Op { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Ubigeou1")] public string Ubigeou1 { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Trf_Ambito")] public string Trf_Ambito { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Ubigeou2")] public string Ubigeou2 { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Ubigeou3")] public string Ubigeou3 { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Trf_Estado_Op")] public string Trf_Estado_Op { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Fec_Solic")] public DateTime? Fec_Solic { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Ubigeo_Concat")] public string Ubigeo_Concat { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "CargaFin_Comite")] public int CargaFin_Comite { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "CargaFin_Repres")] public int CargaFin_Repres { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "MensajeCargaCompletada")] public string MensajeCargaCompletada { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Tipo_Carga_Comite_Repres")] public string Tipo_Carga_Comite_Repres { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Vinculado")] public Boolean Vinculado { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Tipo_Estado_Insc")] public int Tipo_Estado_Insc { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "Num_DptoLeg")] public string Num_DptoLeg { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Num_DptoProc")] public string Num_DptoProc { get; set; }

    //[DataMember(EmitDefaultValue = false, Name = "EsMiembroDeAlianza")] public int EsMiembroDeAlianza { get; set; }

    private object _FLMIEMBRODEALIANZA;
    [DataMember(EmitDefaultValue = false, Name = "FLMIEMBRODEALIANZA")] public object FLMIEMBRODEALIANZA
    {
        get
        {
            if (_FLMIEMBRODEALIANZA == null) { return 0; }
            else
            {
                if (_FLMIEMBRODEALIANZA.NoNulo())
                {
                    if (_FLMIEMBRODEALIANZA.ToString() == "on") { return 1; }
                    else if (_FLMIEMBRODEALIANZA.ToString() == "1") { return 1; }
                    else { return 0; }
                }
                else { return 0; }
            }
        }
        set { _FLMIEMBRODEALIANZA = value; }
    }


    [DataMember(EmitDefaultValue = false, Name = "AlianzaPadre")] public string AlianzaPadre { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Anos_Vigencia_Cargo")] public int Anos_Vigencia_Cargo { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "Ubigeo_OP")] public string Ubigeo_OP { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Estado_Insc")] public string Estado_Insc { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Proc_Insc")] public string Proc_Insc { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Cod_Est_Insc")] public string Cod_Est_Insc { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Fec_Movim")] public string Fec_Movim { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Fec_Solic_Insc")] public string Fec_Solic_Insc { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "SiglaTipoOP")] public string SiglaTipoOP { get; set; }


//    DOMIDZONA INTEGER
//DOMTXZONA VARCHAR(100)

//DOMIDVIA INTEGER
//DOMTXVIA VARCHAR(100)

//DOMTXNUMERO VARCHAR(100)

//DOMTXKILOMETRO VARCHAR(100)
//DOMTXMANZANA VARCHAR(100)

//DOMTXLOTE VARCHAR(100)
//DOMTXDEPARTAMENTO VARCHAR(100)

//DOMTXINTERIOR VARCHAR(100)

//DOMTXREFERENCIA VARCHAR(200)


    [DataMember(EmitDefaultValue = false, Name = "DOMIDZONA")] public int DOMIDZONA { get; set; }
    [text(0, 100, "Ingrese zona")] [DataMember(EmitDefaultValue = false, Name = "DOMTXZONA")] public string DOMTXZONA { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "DOMIDVIA")] public int DOMIDVIA { get; set; }
    [text(0, 100, "Ingrese via")] [DataMember(EmitDefaultValue = false, Name = "DOMTXVIA")] public string DOMTXVIA { get; set; }

    [text(0, 100, "Ingrese número")] [DataMember(EmitDefaultValue = false, Name = "DOMTXNUMERO")] public string DOMTXNUMERO { get; set; }

    [text(0, 100, "Ingrese kilometro")] [DataMember(EmitDefaultValue = false, Name = "DOMTXKILOMETRO")] public string DOMTXKILOMETRO { get; set; }

    [text(0, 100, "Ingrese manzana")] [DataMember(EmitDefaultValue = false, Name = "DOMTXMANZANA")] public string DOMTXMANZANA { get; set; }

    [text(0, 100, "Ingrese lote")] [DataMember(EmitDefaultValue = false, Name = "DOMTXLOTE")] public string DOMTXLOTE { get; set; }
    [text(0, 100, "Ingrese departamento")] [DataMember(EmitDefaultValue = false, Name = "DOMTXDEPARTAMENTO")] public string DOMTXDEPARTAMENTO { get; set; }

    [text(0, 100, "Ingrese interior")] [DataMember(EmitDefaultValue = false, Name = "DOMTXINTERIOR")] public string DOMTXINTERIOR { get; set; }

    [text(0, 100, "Ingrese referencia")] [DataMember(EmitDefaultValue = false, Name = "DOMTXREFERENCIA")] public string DOMTXREFERENCIA { get; set; }

    bool disposed = false;
    protected override void Dispose(bool disposing)
    {
        if (disposed) return;
        if (disposing) { }
        disposed = true;
        base.Dispose(disposing);
    }
    ~BE_OP() { Dispose(false); }
}
