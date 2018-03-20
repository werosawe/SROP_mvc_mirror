using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;

	public class BL_Persona : BL_BASE
	{
        private DA_Persona data;
        public BE_Persona Obtener_Persona(string Cod_Dni)
		{
			List<BE_Persona> r = new List<BE_Persona>();
			OracleConnection cn = new OracleConnection(TX_ESQUEMA);
	
        BE_Persona i = null;
        OracleDataReader dr = data.Obtener_Persona(cn, Cod_Dni);

     
				if (dr.Read()) {
					i = new BE_Persona();
					i.Cod_Dni = dr.Text("Numdle");
					i.ApePat = dr.Text("ApePat");
					i.ApeMat = dr.Text("ApeMat");
					i.Nombre = dr.Text("Nombre");
					i.enPadronElec = 1;
				}

				if (i == null) {
					i = new BE_Persona();
					i.Cod_Dni = Cod_Dni;
					i.ApePat = "-";
					i.ApeMat = "-";
					i.Nombre = "-";
					i.enPadronElec = 0;
				}
        pCerrarDr(cn, dr);
        return i;
			
		}

		public List<BE_Persona> Obtener_Personas_x_Nombres(BE_Persona oBE)
		{
			List<BE_Persona> r = new List<BE_Persona>();
			OracleConnection cn = new OracleConnection(TX_ESQUEMA);
			OracleDataReader dr = null;			
			BE_Persona i = null;


			
				if (!string.IsNullOrEmpty(oBE.Nombre) & !string.IsNullOrEmpty(oBE.ApePat) & !string.IsNullOrEmpty(oBE.ApeMat)) {
					dr = data.Obtener_Personas_x_Nombres_Completo(cn, oBE);
				} else if (!string.IsNullOrEmpty(oBE.Nombre) & !string.IsNullOrEmpty(oBE.ApePat)) {
					dr = data.Obtener_Personas_x_ApPat_Nombres(cn, oBE);
				} else if (!string.IsNullOrEmpty(oBE.ApePat) & !string.IsNullOrEmpty(oBE.ApeMat)) {
					dr = data.Obtener_Personas_x_ApPat_ApMat(cn, oBE);
				} else if (!string.IsNullOrEmpty(oBE.Nombre) & !string.IsNullOrEmpty(oBE.ApeMat)) {
					dr = data.Obtener_Personas_x_ApMat_Nombres(cn, oBE);
				}

				while (dr.Read()) {
					i = new BE_Persona();
					i.Cod_Dni = dr.Text("Numdle");
					i.ApePat = dr.Text("ApePat");
					i.ApeMat = dr.Text("ApeMat");
					i.Nombre = dr.Text("Nombre");
					r.Add(i);
				}pCerrarDr(cn, dr);

				return r;			
		}



        public BL_Persona() { data = new DA_Persona(); }
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

