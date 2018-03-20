using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Collections;

	public class BL_Menu : BL_BASE
	{


        private DA_Menu data;


        public List<BE_Menu> ListarMenu(BE_Menu c)
		{

			BE_Menu oPadre = new BE_Menu();
			List<BE_Menu> r = new List<BE_Menu>();
			ArrayList _Amenu = new ArrayList();
			_Amenu = RetornarArrayList(c);

			int i = 0;

			while (i <= _Amenu.Count - 1) {
				BE_Menu curr = new BE_Menu();
				curr = (BE_Menu)_Amenu[i];

				if (curr.Padre == "SI") {
					oPadre = new BE_Menu();
					oPadre = curr;
					i = i + 1;

				}

				if (curr.Padre == "NO") {
					BE_Menu oMENU = new BE_Menu();
					oMENU = oPadre;

					ArrayList oArray = new ArrayList();
					BE_Menu oBE_MenuHijo = new BE_Menu();

					while (curr.Padre == "NO" & i <= _Amenu.Count - 1) {
						oBE_MenuHijo = new BE_Menu();
						oBE_MenuHijo = curr;
						oBE_MenuHijo.Cod_Padre = oPadre.Codigo;
						oArray.Add(oBE_MenuHijo);
						i = i + 1;
						if (i <= _Amenu.Count - 1) {
							curr = (BE_Menu)_Amenu[i];
						}

					}

					oMENU.ArrayMenuHijo = oArray;

					r.Add(oMENU);
				}

			}

			return r;

		}

		private ArrayList RetornarArrayList(BE_Menu c)
		{			
			ArrayList r = new ArrayList();
			OracleConnection cn = new OracleConnection(TX_ESQUEMA);
			OracleDataReader dr = data.ListarMenu(cn, c);
				while (dr.Read()) {
					BE_Menu i = new BE_Menu();
					i.Codigo = dr.Text("codigo");
					i.ItemMenu = dr.Text("itemmenu");
					i.URL = dr.Text("url");
					i.Padre = dr.Text("padre");
					i.Mensaje = dr.Text("mensaje");
					r.Add(i);
				}
			
        pCerrarDr(cn, dr);
        return r;
		}

		public ArrayList GenerarArrayMenuHijo(OracleDataReader dr)
		{

			ArrayList oArray = new ArrayList();
			BE_Menu oBE_MenuHijo = default(BE_Menu);

			oBE_MenuHijo = new BE_Menu();
			oBE_MenuHijo.ItemMenu = dr.Text("descripcion");
			oBE_MenuHijo.Cod_Padre = dr.Text("Codigo_padre");
			oArray.Add(oBE_MenuHijo);

			oBE_MenuHijo = new BE_Menu();
			oBE_MenuHijo.ItemMenu = "Mantenimiento y Custodia";
			oArray.Add(oBE_MenuHijo);


			oBE_MenuHijo = new BE_Menu();
			oBE_MenuHijo.ItemMenu = "Consulta Detallada de Afiliación";
			oArray.Add(oBE_MenuHijo);
			return oArray;
		}

        public BL_Menu() { data = new DA_Menu(); }
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

