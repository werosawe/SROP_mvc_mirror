using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;

	public class BL_MotivoVin : BL_BASE
	{
        private DA_MotivoVin data;
        public List<BE_MotivoVin> Listar_Motivos_Vincula()
		{
			List<BE_MotivoVin> r = new List<BE_MotivoVin>();
			OracleConnection cn = new OracleConnection(TX_ESQUEMA);
			OracleDataReader dr = data.Listar_Motivos_Vincula(cn);
       

				while (dr.Read()) {
					BE_MotivoVin i = new BE_MotivoVin();					
					i.Cod_Motivo = dr.Text("Cod_Motivo");
					i.Des_Motivo = dr.Text("des_motivo");
					r.Add(i);
				}
            pCerrarDr(cn, dr);
            return r;
			
		}

		public List<BE_MotivoVin> Listar_OP_Vin(int Cod_OP)
		{
			List<BE_MotivoVin> r = new List<BE_MotivoVin>();
			OracleConnection cn = new OracleConnection(TX_ESQUEMA);
			OracleDataReader dr = data.Listar_OP_Vin(cn, Cod_OP);
     				while (dr.Read()) {
					BE_MotivoVin i = new BE_MotivoVin();
					i.cod_op_vin = dr.Num("cod_op_vin");
					i.Des_OP = dr.Text("des_op");
					i.des_tipo_op = dr.Text("des_tipo_op");
					i.fec_vin = dr.Fec("fec_vin");  
					i.Des_Estado_Inscrip = dr.Text("Des_Estado_Inscrip");
					i.Des_Motivo = dr.Text("Des_motivo");
					i.region = dr.Text("region");
					i.provincia = dr.Text("provincia");
					i.distrito = dr.Text("distrito");
					r.Add(i);
				}
            pCerrarDr(cn, dr);
            return r;
			
		}

		public int Delete_OP_Vinculada(BE_MotivoVin c)
		{

        return data.Delete_OP_Vinculada(c);
    }

		private BE_MotivoVin.Check Check_Puede_Vin(BE_MotivoVin c)
		{
        return data.Check_Puede_Vin(c);
    }

		private int Insert_OP_Vincula(BE_MotivoVin c)
		{
        return data.Insert_OP_Vincula(c);
    }


		public BE_MotivoVin.Check VincularOP(BE_MotivoVin oBE)
		{
			//Dim FunctionsOP As New FunctionsOP
			BE_MotivoVin.Check oRet = default(BE_MotivoVin.Check);
			//Dim boPuedeVincula As Boolean = False
			//Dim Motivo_Error As String = ""
			int n = 0;
			//Inicio de Reglas para vincular
			//Dim conOP As OracleConnection = Nothing
			//FunctionsOP.AbrirConexion(conOP)
			//Dim ospEntry(1) As spEntry
			//ospEntry(0) = New spEntry("i_cod_op", Me.Cod_OP, OracleDbType.int, 4)
			//ospEntry(1) = New spEntry("i_cod_op_vin", Me.Cod_OP_Vin, OracleDbType.int, 4)
			//Dim ospOutPut(0) As spEntry
			//ospOutPut(0) = New spEntry("o_mensaje", 0, OracleDbType.Varchar2, 200)
			//FunctionsOP.CallSP("pkg_op.SP_Check_Puede_Vin", conOP, ospEntry, ospOutPut, , , 0)
			//conOP.Close()

			oRet = Check_Puede_Vin(oBE);

			//If oRet.retorno = 1 Then
			//    boPuedeVincula = True
			//Else
			//    boPuedeVincula = False
			//    'Motivo_Error = oRet.Mensaje
			//    Return False
			//End If
			//Fin de Reglas para vincular

			if (oRet.retorno == 1) {
				// Se procede a vincular
				//FunctionsOP.AbrirConexion(conOP)
				//ReDim ospEntry(4)
				//ospEntry(0) = New spEntry("i_cod_op", Me.Cod_OP, OracleDbType.int, 4)
				//ospEntry(1) = New spEntry("i_cod_op_vin", Me.Cod_OP_Vin, OracleDbType.int, 4)
				//ospEntry(2) = New spEntry("i_fec_vin", "01/01/2008", OracleDbType.Date, 8)
				//ospEntry(3) = New spEntry("i_user", Me.UserId, OracleDbType.Varchar2, 50)
				//ospEntry(4) = New spEntry("i_cod_motivo_vin", Me.Cod_Motivo_Vin, OracleDbType.Char, 2)

				//FunctionsOP.CallSP("pkg_op.SP_Insert_OP_Vincula", conOP, ospEntry, , , , 0)
				//conOP.Close()
				//conOP.Dispose()

				n = Insert_OP_Vincula(oBE);

				switch (n) {
					case 0:
						// Error
						oRet.Mensaje = "Problemas al grabar";
						oRet.retorno = 0;
						break;
					case 1:
						// Todo bien
						oRet.retorno = 1;
						break;
				}

			} else {
			}

			return oRet;
		}
        public BL_MotivoVin() { data = new DA_MotivoVin(); }
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

