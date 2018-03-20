using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;


	public class BL_BusquedaOP : BL_BASE
	{
        private DA_BusquedaOP data;
        //private string formatoFechaInterfaz = "dd-MMM-yyyy";
	
		private int NoList;
		private bool Hay_ParametrosOP(BE_BusquedaOP paramOP)
		{
			if (!string.IsNullOrEmpty(paramOP.Des_OP))
				return true;
			if (!string.IsNullOrEmpty(paramOP.ID_Asistente))
				return true;
			if (!(paramOP.Cod_Tipo_OP == "00"))
				return true;
			if (!(paramOP.ID_EstadoOP == "0"))
				return true;
			//If Not paramFec.FecIni = "" Then Return False
			//If Not paramFec.FecFin = "" Then Return False
			return false;
		}

		public List<BE_BusquedaOP> BusquedaOP_x_Parametros(BE_BusquedaOP paramOP, BE_BusquedaOP.FecEstado paramFec, List<BE_BusquedaOP> ListaOP)
		{
			NoList = 0;
			ListaOP = Obtener_Lista_Por_Denominacion(ref NoList, paramOP, paramFec, ListaOP);
			ListaOP = Obtener_Lista_Por_Ubigeo(ref NoList, paramOP, paramFec, ListaOP);
			ListaOP = Obtener_Lista_Por_Asistente(ref NoList, paramOP, paramFec, ListaOP);
			ListaOP = Obtener_Lista_Por_Tipo_OP(ref NoList, paramOP, paramFec, ListaOP);
			ListaOP = Obtener_Lista_Por_Estado_OP(ref NoList, paramOP, paramFec, ListaOP);
			ListaOP = Obtener_Lista_Por_Legajo(ref NoList, paramOP, paramFec, ListaOP);
			ListaOP = Obtener_Lista_Por_Fechas(ref NoList, paramOP, paramFec, ListaOP);
			return ListaOP;
		}

		private List<BE_BusquedaOP> Obtener_Lista_Por_Denominacion(ref int NoList, BE_BusquedaOP paramOP, BE_BusquedaOP.FecEstado paramFec, List<BE_BusquedaOP> ListaOP)
		{
		    List<BE_BusquedaOP> ReturnLista = null;
			if (!(string.IsNullOrEmpty(paramOP.Des_OP))) {
				ListaOP = Retorna_ListaOP_Filtrada1(paramOP, ListaOP);
				if (Funciones.Dame_ListCount(ListaOP) == 0)
					NoList = 1;
			}
			ReturnLista = ListaOP;
			return ReturnLista;
		}

		private List<BE_BusquedaOP> Obtener_Lista_Por_Ubigeo(ref int NoList, BE_BusquedaOP paramOP, BE_BusquedaOP.FecEstado paramFec, List<BE_BusquedaOP> ListaOP)
		{
			List<BE_BusquedaOP> ReturnLista = null;
			if (!(string.IsNullOrEmpty(paramOP.UBIGEO) | paramOP.UBIGEO == "000000")) {
				if (NoList == 1) {
					ListaOP = null;
				} else {
					ListaOP = Retorna_ListaOP_Filtrada7(paramOP, ListaOP);
					if (Funciones.Dame_ListCount(ListaOP) == 0)
						NoList = 1;
				}
			}
			ReturnLista = ListaOP;
			return ReturnLista;
		}

		private List<BE_BusquedaOP> Obtener_Lista_Por_Asistente(ref int NoList, BE_BusquedaOP paramOP, BE_BusquedaOP.FecEstado paramFec, List<BE_BusquedaOP> ListaOP)
		{
			List<BE_BusquedaOP> ReturnLista = null;
			if (!(string.IsNullOrEmpty(paramOP.ID_Asistente) | paramOP.ID_Asistente == "00")) {
				if (NoList == 1) {
					ListaOP = null;
				} else {
					ListaOP = Retorna_ListaOP_Filtrada2(paramOP, ListaOP);
					if (Funciones.Dame_ListCount(ListaOP) == 0)
						NoList = 1;
				}
			}
			ReturnLista = ListaOP;
			return ReturnLista;
		}

		private List<BE_BusquedaOP> Obtener_Lista_Por_Tipo_OP(ref int NoList, BE_BusquedaOP paramOP, BE_BusquedaOP.FecEstado paramFec, List<BE_BusquedaOP> ListaOP)
		{
			List<BE_BusquedaOP> ReturnLista = null;
			if (!(string.IsNullOrEmpty(paramOP.Cod_Tipo_OP) | paramOP.Cod_Tipo_OP == "00")) {
				if (NoList == 1) {
					ListaOP = null;
				} else {
					ListaOP = Retorna_ListaOP_Filtrada3(paramOP, ListaOP);
					if (Funciones.Dame_ListCount(ListaOP) == 0)
						NoList = 1;
				}
			}
			ReturnLista = ListaOP;
			return ReturnLista;
		}

		private List<BE_BusquedaOP> Obtener_Lista_Por_Estado_OP(ref int NoList, BE_BusquedaOP paramOP, BE_BusquedaOP.FecEstado paramFec, List<BE_BusquedaOP> ListaOP)
		{
			List<BE_BusquedaOP> ReturnLista = null;
			if (!(string.IsNullOrEmpty(paramOP.ID_EstadoOP) | paramOP.ID_EstadoOP == "0")) {
				if (NoList == 1) {
					ListaOP = null;
				} else {
					if (paramFec.FecIni != null) {
						ListaOP = Retorna_ListaOP_Filtrada5(paramFec, ListaOP, paramOP);
					} else {
						ListaOP = Retorna_ListaOP_Filtrada4(paramOP, ListaOP);

					}
					if (Funciones.Dame_ListCount(ListaOP) == 0)
						NoList = 1;

				}
			}
			ReturnLista = ListaOP;
			return ReturnLista;
		}

		private List<BE_BusquedaOP> Obtener_Lista_Por_Legajo(ref int NoList, BE_BusquedaOP paramOP, BE_BusquedaOP.FecEstado paramFec, List<BE_BusquedaOP> ListaOP)
		{
			List<BE_BusquedaOP> ReturnLista = null;
			if (!(string.IsNullOrEmpty(paramOP.Ubic_Legajo) | paramOP.Ubic_Legajo == "0")) {
				if (NoList == 1) {
					ListaOP = null;
				} else {
					ListaOP = Retorna_ListaOP_Filtrada6(paramOP, ListaOP);
					if (Funciones.Dame_ListCount(ListaOP) == 0)
						NoList = 1;
				}
			}
			ReturnLista = ListaOP;
			return ReturnLista;
		}

		private List<BE_BusquedaOP> Obtener_Lista_Por_Fechas(ref int NoList, BE_BusquedaOP paramOP, BE_BusquedaOP.FecEstado paramFec, List<BE_BusquedaOP> ListaOP)
		{

			List<BE_BusquedaOP> LISTA = new List<BE_BusquedaOP>();

			if (!(string.IsNullOrEmpty(paramOP.ID_EstadoOP) | paramOP.ID_EstadoOP == "0")) {
				return ListaOP;
			}


			if (paramFec.FecIni != null) {
				if (NoList == 1) {
					ListaOP = null;


				} else {

					if (ListaOP.Count == 0) {
						OracleConnection cn = new OracleConnection(TX_ESQUEMA);
						OracleDataReader dr = null;
						dr = data.ListarOPxFechasEtapas(cn, paramFec);
						LISTA = GetListaOPFiltrada(dr);

					} else {
						//Dim dt1 As Date = DateTime.ParseExact(paramFec.FecIni, formatoFechaInterfaz, Nothing)
						//Dim dt2 As Date = DateTime.ParseExact(paramFec.FecFin, formatoFechaInterfaz, Nothing)

						DateTime? dt1 = paramFec.FecIni;
						DateTime? dt2 = paramFec.FecFin;

                        DateTime? dateEstadoInsc = default(DateTime);

						foreach (BE_BusquedaOP x in ListaOP) {
							if (x.Fec_Estado_Insc !=null) {
							} else {
								dateEstadoInsc = x.Fec_Estado_Insc;
								if ((dateEstadoInsc.Value.Date >= dt1.Value.Date) & (dateEstadoInsc.Value.Date <= dt2.Value.Date)) {
									LISTA.Add(x);
								}
							}
						}
					}
					if (Funciones.Dame_ListCount(ListaOP) == 0)
						NoList = 1;
				}
			} else {
				LISTA = ListaOP;
			}



			return (LISTA);
		}

		public List<BE_BusquedaOP> Retorna_ListaOP_Filtrada1(BE_BusquedaOP paramOP, List<BE_BusquedaOP> ListaOP)
		{
			List<BE_BusquedaOP> LISTA = new List<BE_BusquedaOP>();
			OracleConnection cn = new OracleConnection(TX_ESQUEMA);
			OracleDataReader dr = data.ListarOPxDenominacion(cn, paramOP);       
				LISTA = GetListaOPFiltrada(dr);			
        pCerrarDr(cn, dr);
        return LISTA;


        }

    public List<BE_BusquedaOP> Retorna_ListaOP_Filtrada2(BE_BusquedaOP paramOP, List<BE_BusquedaOP> ListaOP)
    {
        List<BE_BusquedaOP> LISTA = new List<BE_BusquedaOP>();
        if (ListaOP.Count == 0)
        {
            OracleConnection cn = new OracleConnection(TX_ESQUEMA);
            OracleDataReader dr = data.ListarOPxAbogado(cn, paramOP);
            LISTA = GetListaOPFiltrada(dr);
            pCerrarDr(cn, dr);
        }
        else
        {
            LISTA = ListaOP.FindAll((BE_BusquedaOP x) => x.ID_Asistente == paramOP.ID_Asistente);

        }
        return (LISTA);
    }

		public List<BE_BusquedaOP> Retorna_ListaOP_Filtrada3(BE_BusquedaOP paramOP, List<BE_BusquedaOP> ListaOP)
		{

			List<BE_BusquedaOP> LISTA = new List<BE_BusquedaOP>();
			if (ListaOP.Count == 0) {
				OracleConnection cn = new OracleConnection(TX_ESQUEMA);
				OracleDataReader dr = data.ListarOPxTipoOP(cn, paramOP);
					LISTA = GetListaOPFiltrada(dr);
                pCerrarDr(cn, dr);
           
			} else {
				//newList = List.FindAll(Function(s As String) s = "match")
				LISTA = ListaOP.FindAll((BE_BusquedaOP x) => x.Cod_Tipo_OP == paramOP.Cod_Tipo_OP);

			}
			return (LISTA);

		}

		public List<BE_BusquedaOP> Retorna_ListaOP_Filtrada4(BE_BusquedaOP paramOP, List<BE_BusquedaOP> ListaOP)
		{
			List<BE_BusquedaOP> LISTA = new List<BE_BusquedaOP>();
			if (ListaOP.Count == 0) {
				OracleConnection cn = new OracleConnection(TX_ESQUEMA);
				OracleDataReader dr = data.ListarOPxEstadoOP(cn, paramOP);           
					LISTA = GetListaOPFiltrada(dr);
                pCerrarDr(cn, dr); 
			} else {
				//newList = List.FindAll(Function(s As String) s = "match")
				LISTA = ListaOP.FindAll((BE_BusquedaOP x) => x.ID_EstadoOP == paramOP.ID_EstadoOP);

			}
			return (LISTA);
		}

		public List<BE_BusquedaOP> Retorna_ListaOP_Filtrada5(BE_BusquedaOP.FecEstado paramFec, List<BE_BusquedaOP> ListaOP, BE_BusquedaOP paramOP)
		{
			string Today = DateTime.Now.Date.ToString("dd-MMM-yyyy");
			if (paramFec.FecFin == null)
				paramFec.FecFin = DateTime.Today;
			List<BE_BusquedaOP> LISTA = new List<BE_BusquedaOP>();
			// genera lista filtrada por Fechas y por Estado OP
			if (Hay_ParametrosOP(paramOP) == true) {
				OracleConnection cn = new OracleConnection(TX_ESQUEMA);
				OracleDataReader dr = null;
				if (paramFec.FecIni == null | paramFec.FecFin == null) {
				} else {
					dr = data.ListarOPxEstado_EnRango_Fechas(cn, paramFec, paramOP);
					LISTA = GetListaOPFiltrada(dr);
				}
			}
			if (ListaOP.Count == 0) {


			} else {
				int cod_op = 0;
				List<BE_BusquedaOP> L = new List<BE_BusquedaOP>();
				foreach (BE_BusquedaOP B in ListaOP) {
					//elementos de LISTA que coinciden con elementos de ListaOP
					cod_op = B.Cod_OP;
					L.AddRange(LISTA.FindAll((BE_BusquedaOP x) => x.Cod_OP == cod_op));

				}
				LISTA = L;
			}
			return (LISTA);
		}

		public List<BE_BusquedaOP> Retorna_ListaOP_Filtrada6(BE_BusquedaOP paramOP, List<BE_BusquedaOP> ListaOP)
		{

			List<BE_BusquedaOP> LISTA = new List<BE_BusquedaOP>();

			if (ListaOP.Count == 0) {
				OracleConnection cn = new OracleConnection(TX_ESQUEMA);
				OracleDataReader dr = data.ListarOPxUbicDeLegajo(cn, paramOP);
					LISTA = GetListaOPFiltrada(dr);
                pCerrarDr(cn, dr);          

			} else {
				LISTA = ListaOP.FindAll((BE_BusquedaOP x) => x.Ubic_Legajo == paramOP.Ubic_Legajo);

			}

			return (LISTA);

		}

		public List<BE_BusquedaOP> Retorna_ListaOP_Filtrada7(BE_BusquedaOP paramOP, List<BE_BusquedaOP> ListaOP)
		{

			List<BE_BusquedaOP> LISTA = new List<BE_BusquedaOP>();

			if (ListaOP.Count == 0) {
				OracleConnection cn = new OracleConnection(TX_ESQUEMA);
				OracleDataReader dr = null;
				
                    if (paramOP.UBIGEO.Substring(2, 4) == "0000") {
                        //busqueda regional
                        dr = data.ListarOPxRegion(cn, paramOP); }
                    else if (paramOP.UBIGEO.Substring(4, 2) == "00")
                    {

                        dr = data.ListarOPxProvincia(cn, paramOP);
                    }
                    else 
                    {
                      
							dr = data.ListarOPxDistrito(cn, paramOP);
                                          }

					LISTA = GetListaOPFiltrada(dr);
                pCerrarDr(cn, dr);
            


			} else {
                if (paramOP.UBIGEO.Substring(2, 4) == "0000")
                {
                    LISTA = ListaOP.FindAll((BE_BusquedaOP x) => x.UBIGEO.Substring(0, 2) == paramOP.UBIGEO.Substring(0, 2));
                }
                else if (paramOP.UBIGEO.Substring(4, 2) == "00")
                {

                    LISTA = ListaOP.FindAll((BE_BusquedaOP x) => x.UBIGEO.Substring(0, 4) == paramOP.UBIGEO.Substring(0, 4));
                }
                else
                {
                    LISTA = ListaOP.FindAll((BE_BusquedaOP x) => x.UBIGEO == paramOP.UBIGEO);
                }


			}

			return (LISTA);

		}

		private List<BE_BusquedaOP> GetListaOPFiltrada(OracleDataReader dr)
		{
			List<BE_BusquedaOP> LISTA = new List<BE_BusquedaOP>();
			while (dr.Read()) {
				BE_BusquedaOP i = new BE_BusquedaOP();
				i.Cod_OP = dr.Num("codigo");
				i.Des_OP = dr.Text("descripcion");
				i.ID_Asistente = dr.Text("id_asistente");
				i.Cod_Tipo_OP = dr.Text("cod_tipo_op");
				i.Des_Tipo_OP = dr.Text("des_tipo");
				i.ID_EstadoOP = dr.Text("flg_estado_op");
				i.Fec_Estado_Insc = dr.Fec("fec_estado_insc");
				i.Des_Estado_Inscrip = dr.Text("des_est_insc");
				i.Estado_OP = dr.Text("estado_op");

				i.UBIREGION = dr.Text("UbiRegion");
				i.UBIPROVINCIA = dr.Text("UbiProv");
				i.UBIDISTRITO = dr.Text("UbiDist");
				i.UBIGEO = i.UBIREGION.CerosIzquierda(2) + i.UBIPROVINCIA.CerosIzquierda(2) + i.UBIDISTRITO.CerosIzquierda(2);

				i.Region = dr.Text("Region");
				i.Provincia = dr.Text("Provincia");
				i.Distrito = dr.Text("Distrito");

				i.FLCANDADO = dr.Num("flg_candado");
				i.Cod_Arc = dr.Text("Cod_Arc");
				i.Num_Tomo_Legajo = dr.Text("Num_Tom_Leg");
				i.Num_Tomo_Planillon = dr.Text("Num_Tom_Pla");
				i.Ubic_Legajo = dr.Text("Tx_Ubic_Arc");

				i.DomicilioLegal_OP = dr.Text("DomLegal_OP");
				i.Telefono01_OP = dr.Text("des_telef_op_01");
				i.Telefono02_OP = dr.Text("des_telef_op_02");

				string Ubigeo_Concat = "";

				if (!string.IsNullOrEmpty(dr.Text("Region"))) {
					Ubigeo_Concat = dr.Text("Region");
				}

				if (!string.IsNullOrEmpty(dr.Text("Provincia"))) {
					Ubigeo_Concat += "-" + dr.Text("Provincia");
				}

				if (!string.IsNullOrEmpty(dr.Text("Distrito"))) {
					Ubigeo_Concat += "-" + dr.Text("Distrito");
				}

				if (i.Cod_Tipo_OP == "01") {
					i.Ubigeo_Concat = "Nacional";
				} else {
					i.Ubigeo_Concat = Ubigeo_Concat;
				}

				i.Cod_Ente = dr.Text("Cod_Ente");

				LISTA.Add(i);
			}
			return LISTA;
		}

		private int countCharacters(string Cadena, string phrase)
		{

			double Occurrences = (Cadena.Length - Cadena.Replace(phrase, string.Empty).Length) / phrase.Length;

			return (int) Occurrences;
		}

        public BL_BusquedaOP() { data = new DA_BusquedaOP(); }
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

