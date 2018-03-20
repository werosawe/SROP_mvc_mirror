using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;


	public class BL_PadronAfil : BL_BASE
	{
        private DA_PadronAfil data;
		public List<BE_PadronAfil> Listar_Padrones(BE_PadronAfil c)
		{
           
            string _URL = Funciones.Dame_Valor_WebConfig("URL_SROP");
			List<BE_PadronAfil> r = new List<BE_PadronAfil>();
			OracleConnection cn = new OracleConnection(TX_ESQUEMA);
			OracleDataReader dr = data.Listar_Padrones(cn, c);
				while (dr.Read()) {
					BE_PadronAfil i = new BE_PadronAfil();

					i.Cod_OP = dr.Num("Cod_OP");
					i.Des_OP = dr.Text("Des_OP");
					i.Des_Tipo_OP = dr.Text("des_tipo_op");
					i.Partido = dr.Text("partido");

					if (i.Partido == "1") {
						i.URL_Padron = "~" + dr.Text("url_padron");
					} else {
						i.URL_Padron = _URL + dr.Text("url_padron");
					}
                  
                    i.Region = dr.Text("region");
					i.Des_Estado_Inscrip = dr.Text("des_estado_inscrip");
					i.Fec_Present = dr.Fec("fec_present");  

                    r.Add(i);
				}
            pCerrarDr(cn, dr);
            return r;
			
		}


    public BE_PadronAfil Get_Datos_Ultimo_Padron(int Cod_OP)
    {
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        BE_PadronAfil i = null;
        OracleDataReader dr = data.Get_Datos_Ultimo_Padron(cn, Cod_OP);
        if (dr.Read())
        {
            i = new BE_PadronAfil();
            i.Des_OP = dr.Text("Des_Op");
            i.Des_Tipo_OP = dr.Text("Des_Tipo_Op");
            i.Nro_Entrega = dr.Num("nro_entrega");
            i.Ult_Fec_Entrega = dr.Fec("ult_fec_entrega"); 
            i.Cancelatorio = dr.Text("cancelatorio");
        }
        pCerrarDr(cn, dr);
        return i;
    }


		public List<BE_PadronAfil> Listar_Padrones_Partes(int Cod_OP)
		{
			string _URL = Funciones.Dame_Valor_WebConfig("URL_SROP");
			List<BE_PadronAfil> r = new List<BE_PadronAfil>();
			OracleConnection cn = new OracleConnection(TX_ESQUEMA);
			OracleDataReader dr = data.Listar_Padrones_Partes(cn, Cod_OP);
				while (dr.Read()) {
					BE_PadronAfil i = new BE_PadronAfil();

					i.Cod_OP = dr.Num("Cod_OP");
					i.Nro_Orden = dr.Text("Nro_Orden");
					i.URL_Padron = _URL + dr.Text("url_padron");
					i.NomArch = dr.Text("nomarch");
					i.Descripcion = dr.Text("descripcion");
					r.Add(i);
				}
            pCerrarDr(cn, dr);
            return r;
			
		}
        public BL_PadronAfil() { data = new DA_PadronAfil(); }
        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                data.Dispose(); data = null;
            }
            disposed = true;
            base.Dispose(disposing);
        }
    }

