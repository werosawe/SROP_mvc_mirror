using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;


	public class BL_RenunciaEval : BL_BASE
	{

        //Comentario prueba

        private DA_RenunciaEval data;
      
		public BE_RenunciaEval Get_Cab_RenunEval(BE_RenunciaEval BE_List)
		{

			BE_RenunciaEval i = new BE_RenunciaEval();

			i.Cod_OP = 4;
			i.Cod_DNI = "32984512";
			i.CodExpMTD = "ADX-2017-000301";
			i.CodDocMTD = "ADM-2017-000111";
			i.ID_TipoRenuncia = "1";
			i.TX_TipoRenuncia = "Renuncia Simple";

			i.lista_RenunciaEval = Listar_Det_RenunEval(i);

			return i;



			//Dim r As New List(Of BE_RenunciaEval)
			//Dim cn As New OracleConnection(TX_ESQUEMA)
			//Dim dr As OracleDataReader = Nothing
			//Dim data As New DA_RenunciaEval
			//Try
			//    dr = data.Listar_Cab_RenunEval(cn, BE_List)
			//    While dr.Read
			//        Dim i As New BE_RenunciaEval

			//        i.Cod_OP = Dame_Entero(dr("COD_OP"))
			//        i.Cod_DNI = Dame_Texto(dr("COD_DNI"))
			//        i.CodExpMTD = Dame_Texto(dr("COD_EXP_MTD"))
			//        i.CodDocMTD = Dame_Texto(dr("COD_DOC_MTD"))
			//        i.ID_TipoRenuncia = Dame_Texto(dr("ID_TIPORENUN"))
			//        i.TX_TipoRenuncia = Dame_Texto(dr("TX_TIPORENUN"))

			//        i.lista_RenunciaEval = Listar_Det_RenunEval(i)

			//        r.Add(i)
			//    End While

			//    Return r
			//Catch ex As Exception
			//    Throw ex
			//Finally
			//    pCerrarDr(cn, dr)
			//End Try
		}

		public List<BE_RenunciaEval_Det> Listar_Det_RenunEval(BE_RenunciaEval BE_List)
		{

			List<BE_RenunciaEval_Det> r = new List<BE_RenunciaEval_Det>();

			BE_RenunciaEval_Det i = new BE_RenunciaEval_Det();

			i.ID_Estado = 1;
			i.TX_Estado = "Observado";

			i.ID_ResultadoEval = 1;
			i.TX_ResultadoEval = "No Procede";

			i.ID_Motivo = 2;
			i.TX_Motivo = "No pagó TUPA";
			i.Fec_Eval = DateTime.Parse( "31/03/2017");

			r.Add(i);

			i = new BE_RenunciaEval_Det();

			i.ID_Estado = 2;
			i.TX_Estado = "Atendido";
			i.ID_ResultadoEval = 2;
			i.TX_ResultadoEval = "Procede";
			i.TX_Motivo = "";
			i.Fec_Eval = DateTime.Parse("01/04/2017");

			r.Add(i);

			return r;

			//Dim r As New List(Of BE_RenunciaEval_Det)
			//Dim cn As New OracleConnection(TX_ESQUEMA)
			//Dim dr As OracleDataReader = Nothing
			//Dim data As New DA_RenunciaEval
			//Try
			//    dr = data.Listar_Det_RenunEval(cn, BE_List)
			//    While dr.Read
			//        Dim i As New BE_RenunciaEval_Det

			//        i.ID_Estado = Dame_Entero(dr("ID_ESTADO"))
			//        i.TX_Estado = Dame_Texto(dr("TX_ESTADO"))
			//        i.ID_Motivo = Dame_Entero(dr("ID_MOTIVO"))
			//        i.TX_Motivo = Dame_Texto(dr("TX_MOTIVO"))
			//        i.Fec_Eval = Dame_Texto(dr("FEC_EVAL"))

			//        r.Add(i)
			//    End While

			//    Return r
			//Catch ex As Exception
			//    Throw ex
			//Finally
			//    pCerrarDr(cn, dr)
			//End Try
		}


	
		public string Agregar(BE_Abogado c)
		{
        return data.Agregar(c);
    }

		public string Eliminar(BE_Abogado c)
		{
        return data.Eliminar(c);
    }
	
     

        public BL_RenunciaEval() { data = new DA_RenunciaEval(); }
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

