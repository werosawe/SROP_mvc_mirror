using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;


	public class BL_Cargos_AltasBajas : BL_BASE
	{


        private DA_Cargos_AltasBajas data;
       
	

		public BE_Cargos_AltasBajas Get_Directivo_Cargo(BE_Cargos_AltasBajas c)
		{
			BE_Cargos_AltasBajas i = new BE_Cargos_AltasBajas();
			OracleConnection cn = new OracleConnection(TX_ESQUEMA);
			OracleDataReader dr = data.Get_Directivo_Cargo(cn, c);      
				while (dr.Read()) {
					i.Cod_OP = dr.Num("Cod_OP");
					i.Cod_DNI = dr.Text("Cod_DNI");
					i.Cod_Cargo = dr.Text("Cod_Cargo");
					i.Cod_Correl_Repres = dr.Num("Cod_Correl");
				}
            pCerrarDr(cn, dr);
            return i;			
		}


		public List<BE_Cargos_AltasBajas> Listar_AltasBajas_Cargo(BE_Cargos_AltasBajas BE_List)
		{
			List<BE_Cargos_AltasBajas> r = new List<BE_Cargos_AltasBajas>();
			OracleConnection cn = new OracleConnection(TX_ESQUEMA);
			OracleDataReader dr = data.Listar_AltasBajas_Cargo(cn, BE_List);
        
				while (dr.Read()) {
					BE_Cargos_AltasBajas i = new BE_Cargos_AltasBajas();

					i.Cod_OP = dr.Num("Cod_OP");
					i.Cod_DNI = dr.Text("Cod_DNI");
					i.Id_Orden = dr.Num("Id_Orden");
					i.Cod_Cargo = dr.Text("Cod_Cargo");
					i.Des_Cargo = dr.Text("Des_Cargo");

					i.Fec_Carga = dr.Fec("Fec_Carga");
					i.Fec_Baja = dr.Fec("Fec_Baja"); 

					i.Cod_Motivo_Baja = dr.Text("Cod_Motivo_Baja");
					i.Des_Motivo_Baja = dr.Text("Des_Motivo_Baja");
					i.tx_Observacion = dr.Text("tx_Observacion");
					i.Des_Asiento_Carga = dr.Text("Des_Asiento_Carga");
					i.Des_Asiento_Baja = dr.Text("Des_Asiento_Baja");

					r.Add(i);
				}
            pCerrarDr(cn, dr);
            return r;
			
		}
    
	
		public string Agregar(BE_Cargos_AltasBajas c)
		{

        return data.Agregar(c);
    }

		public string Eliminar(BE_Cargos_AltasBajas c)
		{
        return data.Eliminar(c);
    }

		public string Actualizar(BE_Cargos_AltasBajas c)
		{
        return data.Actualizar(c);
    }

		public string Set_Fecha_Inicio_Cargo(BE_Cargos_AltasBajas c)
		{

        return data.Set_Fecha_Inicio_Cargo(c);
    }

		
     

        public BL_Cargos_AltasBajas() { data = new DA_Cargos_AltasBajas(); }
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

