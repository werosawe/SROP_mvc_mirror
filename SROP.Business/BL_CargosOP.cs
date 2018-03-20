using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;


	public class BL_CargosOP : BL_BASE
	{


        private DA_CargosOP data;
   
	

		public BE_Cargos_AltasBajas Get_Directivo_Cargo(BE_Cargos_AltasBajas c)
		{
			BE_Cargos_AltasBajas i = new BE_Cargos_AltasBajas();
			OracleConnection cn = new OracleConnection(TX_ESQUEMA);
			OracleDataReader dr = null;
			DA_Cargos_AltasBajas dataCargo = new DA_Cargos_AltasBajas();
			try {
				dr = dataCargo.Get_Directivo_Cargo(cn, c);
				if (dr.Read()) {
					i.Cod_OP = dr.Num("Cod_OP");
					i.Cod_DNI = dr.Text("Cod_DNI");
					i.Cod_Cargo = dr.Text("Cod_Cargo");
					i.Cod_Correl_Repres = dr.Num("Cod_Correl");
				}
				return i;
			} catch (Exception ex) {
				throw ex;
			} finally {
				pCerrarDr(cn, dr);
			}
		}


		public List<BE_CargosOP> Listar_CargosOP(BE_CargosOP c)
		{
			List<BE_CargosOP> r = new List<BE_CargosOP>();
			OracleConnection cn = new OracleConnection(TX_ESQUEMA);
			OracleDataReader dr = data.Listar_CargosOP(cn, c);
        
				while (dr.Read()) {
					BE_CargosOP i = new BE_CargosOP();
					i.ordShow = dr.Num("ordShow");
					i.Cod_OP = dr.Num("Cod_OP");
					i.Cod_Cargo = dr.Text("Cod_Cargo");
					i.Des_Cargo = dr.Text("Des_Cargo");
					i.fec_estatuto = (dr["fec_estatuto"] == null ? null : dr.Text("fec_estatuto"));
					i.anos_vigencia = dr.Num("anos_vigencia");
					i.cod_tipo_doc = dr.Text("cod_tipo_doc");
					i.orden = dr.Num("orden");

					r.Add(i);
				}
            pCerrarDr(cn, dr);
            return r;
			
		}




	

		
		public int Agregar(BE_CargosOP c)
		{
        return data.Agregar(c);
    }

		//public int Eliminar(BE_Cargos_AltasBajas oBE)
		//{
		//	OracleConnection cn = new OracleConnection(TX_ESQUEMA);

		//	try {
  //              //System.Web.HttpContext.Current.Cache.Remove("cacheCliente")

  //              //

  //              return data.Eliminar(cn, oBE)
		//	} catch (Exception ex) {
		//		throw ex;
		//	} finally {
		//		cn.Close();
		//		cn.Dispose();
		//		cn = null;
		//	}
		//}

		public string Actualizar(BE_CargosOP c)
		{
        return data.Actualizar(c);
    }

	
     

        public BL_CargosOP() { data = new DA_CargosOP(); }
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

