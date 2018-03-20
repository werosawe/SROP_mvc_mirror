using System;
using System.Data;
using Oracle.DataAccess.Client;


	public class BL_ConstanciaAfil : BL_BASE
	{

        private DA_Constancia data;
  //      public void Generar_PDF(BE_ConstanciaAfil BE_ConstAfil, string strFilePath, string PDFName)
		//{
		//	//Dim strFilePath As String = Server.MapPath(RutaDestino)

		//	if (System.IO.Directory.Exists(strFilePath) == false) {
		//		System.IO.Directory.CreateDirectory(strFilePath);
		//	}


		//	Reportes.CR_Const_Afil2 oRpt = new Reportes.CR_Const_Afil2();
		//	oRpt.SetDataSource(BE_ConstAfil.dtAfiliado);
		//	oRpt.OpenSubreport("cr_sub_percargos.rpt").SetDataSource(BE_ConstAfil.dtRep);
		//	oRpt.OpenSubreport("cr_sub_cand").SetDataSource(BE_ConstAfil.dtCand);

		//	oRpt.SetParameterValue("param1", "");
		//	//Dim FechaConst As String = "Lima, " + String.Format("{0:dd MMMM yyyy}", CType(BE_ConstAfil.Fecha_Constancia, Date))
		//	string FechaConst = "Lima, " + string.Format("{0:dd MMMM yyyy}", Utilitario.Funciones.Convert_dd_mm_yyyy(BE_ConstAfil.Fecha_Constancia));
		//	oRpt.SetParameterValue("FechaConst", FechaConst);
		//	oRpt.SetParameterValue("Solicitante", BE_ConstAfil.Solicitante);
		//	oRpt.SetParameterValue("num_const", BE_ConstAfil.Num_Const);
		//	oRpt.SetParameterValue("Responsable_Constancia", BE_ConstAfil.Responsable_Constancia);
		//	oRpt.SetParameterValue("Cargo_Responsable_A", BE_ConstAfil.Cargo_Responsable_A);
		//	oRpt.SetParameterValue("Cargo_Responsable", BE_ConstAfil.Cargo_Responsable);
		//	oRpt.SetParameterValue("logo1", BE_ConstAfil.logo1);
		//	oRpt.SetParameterValue("logo2", BE_ConstAfil.logo2);
		//	oRpt.SetParameterValue("EsAfiliado", (BE_ConstAfil.EsAfiliado == false ? 0 : 1));
		//	oRpt.SetParameterValue("EsCandidato", (BE_ConstAfil.EsCandidato == false ? 0 : 1));

		//	ExportOptions exportOpts = oRpt.ExportOptions;
		//	oRpt.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
		//	oRpt.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
		//	oRpt.ExportOptions.DestinationOptions = new DiskFileDestinationOptions();
		//	((DiskFileDestinationOptions)oRpt.ExportOptions.DestinationOptions).DiskFileName = strFilePath + PDFName;
		//	oRpt.Export();
		//	oRpt.Close();
		//	oRpt.Dispose();

		//}

		//public void Reporte_Listar_Constancias(DataTable dt, string sEnte, string strFilePath, string PDFName)
		//{
		//	Reportes.CR_Listar_Constancias_DNI oRpt = new Reportes.CR_Listar_Constancias_DNI();
		//	oRpt.SetDataSource(dt);
		//	oRpt.SetParameterValue("param1", "");
		//	string sTitulo = "Constancias Emitidas por " + Strings.Chr(10) + Strings.Chr(13) + sEnte;
		//	oRpt.SetParameterValue("pTitulo", sTitulo);

		//	To_PDF(oRpt, strFilePath, PDFName);
		//}


		//public void To_PDF(ReportClass oRpt, string strFilePath, string PDFName, string Oficial = "")
		//{
		//	try {
		//		if (!string.IsNullOrEmpty(Oficial)) {
		//			string strMensajeRep = "DOCUMENTO EMITIDO POR EL REGISTRO DE ORGANIZACIONES POLÍTICAS";
		//			oRpt.SetParameterValue("param1", strMensajeRep);
		//		}

		//		ExportOptions exportOpts = oRpt.ExportOptions;
		//		oRpt.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
		//		oRpt.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
		//		oRpt.ExportOptions.DestinationOptions = new DiskFileDestinationOptions();
		//		((DiskFileDestinationOptions)oRpt.ExportOptions.DestinationOptions).DiskFileName = strFilePath + PDFName;

		//		oRpt.Export();


		//	} catch (Exception ex) {
		//	} finally {
		//		oRpt.Close();
		//		oRpt.Dispose();
		//	}


		//}

		public DataTable Listar_Constancias_Afil_x_Ente(string sCod_Ente)
		{		
			OracleConnection cn = new OracleConnection(TX_ESQUEMA);
			DataTable dt = new DataTable();
			OracleDataReader dr = data.Listar_Constancias_Afil_x_Ente(cn, sCod_Ente);
				dt.Load(dr);
			
        pCerrarDr(cn, dr);
        return dt;

		}
        public BL_ConstanciaAfil() { data = new DA_Constancia(); }
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

