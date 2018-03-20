using System;
using System.IO;


	public class BL_ComiteVF : BL_BASE
	{
        private DA_ComiteVF data;

        
		public void Procesa_VF(BE_ComiteVF oBE_ComiteVF)
		{
			System.IO.FileInfo file = null;
			string FileBuscado = "";

			foreach (string InFile in Directory.GetFiles(oBE_ComiteVF.SubFolder, "*.txt")) {
				file = new FileInfo(InFile);

				FileBuscado = "Detallado_automatica";
				Selecc_Archivo(file, FileBuscado, oBE_ComiteVF);

				FileBuscado = "Detallado_semiautomatica";
				Selecc_Archivo(file, FileBuscado, oBE_ComiteVF);
			}

			Grabar_Fecha_VF(oBE_ComiteVF);

		}

		private void Selecc_Archivo(FileInfo File, string FileBuscado, BE_ComiteVF oBE_ComiteVF)
		{
			if (File.Name.Length >= FileBuscado.Length) {
				if (File.Name.Substring(0, FileBuscado.Length).ToUpper() == FileBuscado.ToUpper()) {
					if (FileBuscado.ToUpper() == "Detallado_automatica".ToUpper()) {
						LeerArchivo_Automatica(File, oBE_ComiteVF);
					}

					if (FileBuscado.ToUpper() == "Detallado_semiautomatica".ToUpper()) {
						LeerArchivo_SemiAutomatica(File, oBE_ComiteVF);
					}
				}
			}
		}

		private void LeerArchivo_Automatica(FileInfo file, BE_ComiteVF oBE_ComiteVF)
		{
			StreamReader sr = new StreamReader(file.DirectoryName + "\\" + file.Name, System.Text.Encoding.UTF8);
			string Ubigeo = file.Name.Substring(file.Name.Length - 10, 6);
			string Line = sr.ReadLine();

			BE_ComiteVF_Reniec oBE_Reniec = default(BE_ComiteVF_Reniec);

			while ((Line != null)) {
				if (Line.Trim().Length >= 6) {
                    int n;
                    bool isNumeric = int.TryParse(Line.Substring(1, 6), out n);
                    if (isNumeric) {
						oBE_Reniec = new BE_ComiteVF_Reniec();

						oBE_Reniec.Cod_OP = oBE_ComiteVF.Cod_OP;
						oBE_Reniec.Nro_Presen = oBE_ComiteVF.Nro_Presen;
						oBE_Reniec.Cod_Dni = Line.Substring(12, 8);
						oBE_Reniec.Codr_Vf = "N";

						oBE_Reniec.UbiReg = int.Parse(Ubigeo.Substring(0, 2));
						oBE_Reniec.UbiProv = int.Parse(Ubigeo.Substring(2, 2));
						oBE_Reniec.UbiDist = int.Parse(Ubigeo.Substring(4, 2));
						//oBE_Reniec.UserID = oBE_ComiteVF.UserID;

						oBE_Reniec.tx_Obs_RENIEC = Line.Substring(126, 19);

						Grabar_Registro(oBE_Reniec);
					}
				}

				Line = sr.ReadLine();
			}
			sr.Close();
		}

		//' Formato Nuevo
		private void LeerArchivo_SemiAutomatica(FileInfo file, BE_ComiteVF oBE_ComiteVF)
		{
			System.IO.StreamReader sr = new System.IO.StreamReader(file.DirectoryName + "\\" + file.Name, System.Text.Encoding.UTF8);
			string Ubigeo = file.Name.Substring(file.Name.Length - 10, 6);
			string Line = sr.ReadLine();

			BE_ComiteVF_Reniec oBE_Reniec = default(BE_ComiteVF_Reniec);

			while ((Line != null)) {

				if (Line.Trim().Length > 6) {
                    int n;
                    bool isNumeric = int.TryParse(Line.Substring(1, 6), out n);
                    if (isNumeric) {
						oBE_Reniec = new BE_ComiteVF_Reniec();

						oBE_Reniec.Cod_OP = oBE_ComiteVF.Cod_OP;
						oBE_Reniec.Nro_Presen = oBE_ComiteVF.Nro_Presen;

						oBE_Reniec.Cod_Dni = Line.Substring(32, 8);
						oBE_Reniec.Codr_Vf = Convertir_valores_VF(Line.Trim());
						oBE_Reniec.ApePat = Line.Substring(41, 20).Trim();
						oBE_Reniec.ApeMat = Line.Substring(62, 20).Trim();
						oBE_Reniec.Nombres = Line.Substring(83, 30).Trim();

						oBE_Reniec.UbiReg = int.Parse(Ubigeo.Substring(0, 2));
						oBE_Reniec.UbiProv = int.Parse(Ubigeo.Substring(2, 2));
						oBE_Reniec.UbiDist = int.Parse(Ubigeo.Substring(4, 2));
						//oBE_Reniec.UserID = oBE_ComiteVF.UserID;

						Grabar_Registro(oBE_Reniec);
					}
				}

				Line = sr.ReadLine();

			}
			sr.Close();
		}

		//Formato Antiguo
		//Private Sub LeerArchivo_SemiAutomatica(ByVal file As FileInfo, oBE_ComiteVF As BE_ComiteVF)
		//    Dim sr As New System.IO.StreamReader(file.DirectoryName & "\" & file.Name, System.Text.Encoding.UTF7)
		//    Dim Ubigeo As String = file.Name.Substring(file.Name.Length - 10, 6)
		//    Dim Line As String = sr.ReadLine()

		//    Dim oBE_Reniec As BE_ComiteVF_Reniec

		//    Do While Not Line Is Nothing
		//        oBE_Reniec = New BE_ComiteVF_Reniec

		//        oBE_Reniec.Cod_OP = oBE_ComiteVF.Cod_OP
		//        oBE_Reniec.Nro_Presen = oBE_ComiteVF.Nro_Presen

		//        oBE_Reniec.Cod_Dni = Line.Substring(19, 8)
		//        '''      oBE_Reniec.Codr_Vf = Convertir_valores_VF(Line.Substring(122, 1).Trim)
		//        oBE_Reniec.Codr_Vf = Convertir_valores_VF(Line.Trim)
		//        oBE_Reniec.ApePat = Line.Substring(28, 30).Trim
		//        oBE_Reniec.ApeMat = Line.Substring(58, 30).Trim
		//        oBE_Reniec.Nombres = Line.Substring(89, 30).Trim

		//        oBE_Reniec.UbiReg = CInt(Ubigeo.Substring(0, 2))
		//        oBE_Reniec.UbiProv = CInt(Ubigeo.Substring(2, 2))
		//        oBE_Reniec.UbiDist = CInt(Ubigeo.Substring(4, 2))
		//        oBE_Reniec.UserID = oBE_ComiteVF.UserID

		//        Grabar_Registro(oBE_Reniec)

		//        Line = sr.ReadLine()
		//    Loop
		//    sr.Close()
		//End Sub

		private string Convertir_valores_VF(string Line)
		{
			string functionReturnValue = null;
			string Resultado_VF = "";

			if (Line.IndexOf("NO VALIDO") > 0) {
				Resultado_VF = "N";
			} else if (Line.IndexOf("VALIDO") > 0) {
				Resultado_VF = "V";
			}

			switch (Resultado_VF) {
				case "V":
					// Valido
					functionReturnValue = "A";
					break;
				case "N":
					// No Valido
					functionReturnValue = "D";
					break;
				default:
					functionReturnValue = Resultado_VF;
					break;
			}
			return functionReturnValue;

		}

		private int Grabar_Registro(BE_ComiteVF_Reniec c)
		{
        return data.Modificar_Reniec(c);
    }

		private int Grabar_Fecha_VF(BE_ComiteVF c)
		{
        return data.Modificar(c);
    }

        public BL_ComiteVF() { data = new DA_ComiteVF(); }
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

