using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;

using System.IO;
using System.Linq;


	public class BL_opPDF : BL_BASE
	{
        private DA_opPDF data;
      
		public byte[] Obtener_PDF_Page(BE_opPDF c)
		{
			OracleConnection cn = new OracleConnection(TX_ESQUEMA);
			OracleDataReader dr = data.Obtener_PDF_Page(cn, c);
        byte[] pdfByte = null;			
				while (dr.Read()) {
					pdfByte = (byte[]) dr["PDF_Page"];
				}
            pCerrarDr(cn, dr);
            return pdfByte;
			
		}

		public BE_opPDF Datos_PDF(int Cod_OP)
		{
			BE_opPDF i = null;
			OracleConnection cn = new OracleConnection(TX_ESQUEMA);
			OracleDataReader dr = data.Datos_PDF(cn, Cod_OP);
				if (dr.Read()) {
                    i = new BE_opPDF();
                    //.Cod_OP = Dame_Entero(dr("Cod_OP"))
                    i.N_Page_Tot = dr.Num("total_pages");
					i.Des_OP = dr.Text("Des_OP");
					i.Id_Estado_OP = dr.Text("Id_Estado_OP");
					i.Tipo_OP = dr.Text("Tipo_OP");
					i.Siglas_Estado_Insc = dr.Text("estado_insc");
				}
            pCerrarDr(cn, dr);
            return i;
			

		}

		public bool Acceder_ExpPDF(int Cod_OP)
		{
			bool functionReturnValue = false;
			BE_opPDF oBE = new BE_opPDF();

			oBE = Datos_PDF(Cod_OP);

			//If oBE.N_Page_Tot = 0 Or _
			//   oBE.Id_Estado_OP = "1" Then

			//    Acceder_ExpPDF = False
			//Else
			//    Acceder_ExpPDF = True
			//End If


			if (oBE.N_Page_Tot == 0) {
				functionReturnValue = false;
			} else {
				functionReturnValue = true;
			}
			return functionReturnValue;

		}

		public byte[] PDFEnBytes(string ImgFilePath)
		{
			byte[] functionReturnValue = null;

			functionReturnValue = null;
			DirectoryInfo dirInfo = new DirectoryInfo(ImgFilePath);

			if (dirInfo.Exists) {
				foreach (FileInfo xFileInfo in dirInfo.GetFiles("*.pdf").OrderBy(p => p.CreationTime).ToArray()) {
					functionReturnValue = PutImage(ImgFilePath + xFileInfo.Name);
				}
			}
			return functionReturnValue;

		}

		public byte[] Page_PDF_EnBytes(string FilePath)
		{
			byte[] functionReturnValue = null;

			functionReturnValue = null;

			functionReturnValue = PutImage(FilePath);
			return functionReturnValue;

		}


		public void Save_BLOB(BE_opPDF oBE)
		{	
			if ((oBE.PDF_Page != null)) {
				OracleConnection cn = new OracleConnection(TX_ESQUEMA);
				data.Save_BLOB(cn, oBE);
			}
		}

        public void Borrar_PagePDF(BE_opPDF c)
        {
        data.Borrar_PagePDF(c);
    }

        public void Borrar_TodoPDF(BE_opPDF c)
        {
        data.Borrar_TodoPDF(c);
    }

		public byte[] PutImage(string sImageNamePath)
		{
			FileStream oImg = null;
			BinaryReader oBinaryReader = null;
			byte[] oImgByteArray = null;

			oImg = new System.IO.FileStream(sImageNamePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);

			oBinaryReader = new System.IO.BinaryReader(oImg);
			oImgByteArray = oBinaryReader.ReadBytes((int)oImg.Length);

			oImg.Read(oImgByteArray, 0, (int)oImg.Length);

            oBinaryReader.Close();
			oImg.Close();

			return oImgByteArray;
		}


		public List<BE_opPDF> Listar_Indice(int Cod_OP)
		{
			List<BE_opPDF> r = new List<BE_opPDF>();
			OracleConnection cn = new OracleConnection(TX_ESQUEMA);
			OracleDataReader dr = data.Listar_Indice(cn, Cod_OP);
				while (dr.Read()) {
					BE_opPDF i = new BE_opPDF();
					i.Cod_OP = dr.Num("Cod_OP");
					i.Id_Indice = dr.Num("Id_Indice");
					i.Id_Indice_Show = dr.Num("Id_Indice_Show");
					i.Tema_Indice = dr.Text("tx_Tema");
					i.Pagina_Indice = dr.Num("n_Pagina");
					r.Add(i);
				}
            pCerrarDr(cn, dr);
            return r;
		
		}

        public void Add_Pagina_Indice(BE_opPDF c)
        {
        data.Add_Pagina_Indice(c);
    }

        public void Ins_Pagina_Indice(BE_opPDF c)
        {
        data.Ins_Pagina_Indice(c);
    }

        public void Update_Pagina_Indice(BE_opPDF c)
        {
        data.Update_Pagina_Indice(c);
    }

		public void Delete_Pagina_Indice(BE_opPDF c)
		{
        data.Delete_Pagina_Indice(c);
    }

        public void Crear_Indice_Basico(BE_opPDF c)
        {
        data.Crear_Indice_Basico(c);
    }

        public BL_opPDF() { data = new DA_opPDF(); }
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

