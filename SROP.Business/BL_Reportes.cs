using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using Utilitario.Funciones;
using SROP.Entities;
using SROP.DataAccess;
using System.Globalization;
using System.IO;
namespace SROP.Business
{

	public class BL_Reportes : BL_BASE
	{

		private DA_Reportes _DATA = new DA_Reportes();
		public void Reporte_AlianzaElectoral(BE_Reportes oBE)
		{
			var oRpt = new Reportes.CR_AlianzaElectoral();
			DataTable dt1 = null;
			DataTable dt2 = null;
			DataTable dt3 = null;
			BL_Alianza BL = new BL_Alianza();

			dt1 = BL.Crear_DT_AlianzaElectoral(oBE.Cod_OP);
			dt2 = BL.Crear_DT_AlianzasTipoElecc(oBE.Cod_OP);
			dt3 = BL.Crear_DT_AlianzasGrid(oBE.Cod_OP);

			oRpt.SetDataSource(dt1);
			oRpt.OpenSubreport("CR_procesos_electorales").SetDataSource(dt2);
			oRpt.OpenSubreport("CR_miembros_alianza").SetDataSource(dt3);

			To_PDF(oRpt, oBE);

			BL.DISPOSE();
			BL = null;

		}

		public void Reporte_Partidos(BE_Reportes oBE)
		{
			Reportes.CR_Lista_OP oRpt = new Reportes.CR_Lista_OP();
			DataTable dt = null;
			oBE.Cod_Tipo_OP = "01";
			dt = Crear_DT_Partidos(oBE);

			dt = Filtrar_Por_Ente(dt, oBE);

			oRpt.SetDataSource(dt);
			oRpt.SetParameterValue("param2", "Tipo:   " + "Partido Político");

			To_PDF(oRpt, oBE);
		}

		public void Reporte_Partidos_Libros(BE_Reportes oBE)
		{
			Reportes.CR_Lista_Libros oRpt = new Reportes.CR_Lista_Libros();
			DataTable dt = null;

			oBE.Cod_Tipo_Libro = "01";
			dt = Crear_DT_Libros(oBE);

			oRpt.SetDataSource(dt);
			oRpt.SetParameterValue("param2", "Tipo:   " + "Partido Político");

			To_PDF(oRpt, oBE);

		}

		public void Reporte_MovReg(BE_Reportes oBE)
		{
			Reportes.CR_OP_Dist_reg oRpt = new Reportes.CR_OP_Dist_reg();
			DataTable dt = null;
			oBE.Cod_Tipo_OP = "02";
			dt = Crear_DT_MovReg(oBE);

			dt = Filtrar_Por_Ente(dt, oBE);

			oRpt.SetDataSource(dt);
			oRpt.SetParameterValue("param2", "Tipo:   " + "Movimiento Regional");

			To_PDF(oRpt, oBE);
		}

		public void Reporte_MovReg_Libros(BE_Reportes oBE)
		{
			Reportes.CR_Lista_Libros oRpt = new Reportes.CR_Lista_Libros();
			DataTable dt = null;

			oBE.Cod_Tipo_Libro = "02";
			dt = Crear_DT_Libros(oBE);

			oRpt.SetDataSource(dt);
			oRpt.SetParameterValue("param2", "Tipo:   " + "Movimiento Regional");

			To_PDF(oRpt, oBE);

		}

		public void Reporte_OPLP(BE_Reportes oBE)
		{
			Reportes.CR_OP_Dist_pro oRpt = new Reportes.CR_OP_Dist_pro();
			DataTable dt = null;
			oBE.Cod_Tipo_OP = "03";
			dt = Crear_DT_OPLP(oBE);

			dt = Filtrar_Por_Ente(dt, oBE);

			oRpt.SetDataSource(dt);
			oRpt.SetParameterValue("param2", "Tipo:   " + "Organización Local (Provincial)");

			To_PDF(oRpt, oBE);
		}

		public void Reporte_OPLP_Libros(BE_Reportes oBE)
		{
			Reportes.CR_Lista_Libros oRpt = new Reportes.CR_Lista_Libros();
			DataTable dt = null;

			oBE.Cod_Tipo_Libro = "03";
			dt = Crear_DT_Libros(oBE);

			oRpt.SetDataSource(dt);
			oRpt.SetParameterValue("param2", "Tipo:   " + "Organización Local (Provincial)");

			To_PDF(oRpt, oBE);

		}

		public void Reporte_OPLD(BE_Reportes oBE)
		{
			Reportes.CR_OP_Dist_dis oRpt = new Reportes.CR_OP_Dist_dis();
			DataTable dt = null;
			oBE.Cod_Tipo_OP = "04";
			dt = Crear_DT_OPLD(oBE);

			dt = Filtrar_Por_Ente(dt, oBE);

			oRpt.SetDataSource(dt);
			oRpt.SetParameterValue("param2", "Tipo:   " + "Organización Local (Distrital)");

			To_PDF(oRpt, oBE);
		}

		public void Reporte_OPLD_Libros(BE_Reportes oBE)
		{
			Reportes.CR_Lista_Libros oRpt = new Reportes.CR_Lista_Libros();
			DataTable dt = null;

			oBE.Cod_Tipo_Libro = "03";
			// ojo: Es 03 no es 04
			dt = Crear_DT_Libros(oBE);

			oRpt.SetDataSource(dt);
			oRpt.SetParameterValue("param2", "Tipo:   " + "Organización Local (Distrital)");

			To_PDF(oRpt, oBE);

		}

		public void Reporte_Alianzas(BE_Reportes oBE)
		{
			Reportes.CR_Alianzas oRpt = new Reportes.CR_Alianzas();
			DataTable dt = null;
			oBE.Cod_Tipo_OP = "05";
			dt = Crear_DT_Alianzas(oBE);

			dt = Filtrar_Por_Ente(dt, oBE);

			oRpt.SetDataSource(dt);
			oRpt.SetParameterValue("param2", "Tipo:   " + "Alianza Electoral");

			To_PDF(oRpt, oBE);
		}

		public void Reporte_Alianzas_Libros(BE_Reportes oBE)
		{
			Reportes.CR_Lista_Libros oRpt = new Reportes.CR_Lista_Libros();
			DataTable dt = null;

			oBE.Cod_Tipo_Libro = "04";
			dt = Crear_DT_Libros(oBE);

			oRpt.SetDataSource(dt);
			oRpt.SetParameterValue("param2", "Tipo:   " + "Alianza Electoral");

			To_PDF(oRpt, oBE);

		}


		public void Reporte_Resoluciones(BE_Reportes oBE)
		{
			ReportClass oRpt = new ReportClass();

			if (oBE.boResolAgrup == true) {
				oRpt = new Reportes.CR_listar_docums_02();
			} else {
				oRpt = new Reportes.CR_listar_docums_01();
			}

			DataTable dt = null;

			dt = Crear_DT_Resoluciones(oBE);

			dt = Filtrar_Por_Ente(dt, oBE);

			oRpt.SetDataSource(dt);
			oRpt.SetParameterValue("prmGroupxUser", oBE.boResolAgrup);

			To_PDF(oRpt, oBE);

		}

		//Public Sub Reporte_Personeros_Direcc(ByVal oBE As BE_Reportes)

		//    Dim oRpt As New Reportes.CR_Direcc_Personeros
		//    Dim dt As DataTable

		//    dt = Crear_DT_Personeros_Direcc(oBE)

		//    dt = Filtrar_Por_Ente(dt, oBE)

		//    oRpt.SetDataSource(dt)

		//    To_PDF(oRpt, oBE)

		//End Sub


		public void Reporte_OP_Directivos_prox_fin(BE_Reportes oBE)
		{
			Reportes.CR_Repres_vigencia oRpt = new Reportes.CR_Repres_vigencia();
			DataTable dt1 = null;
			DataTable dt2 = null;

			dt1 = Crear_DT_Directivos_Vencidos(oBE);

			dt2 = Crear_DT_Directivos_Por_Vencer(oBE);

			oRpt.OpenSubreport("CR_Repres_vigencia1.rpt").SetDataSource(dt1);
			oRpt.OpenSubreport("CR_Repres_vigencia2.rpt").SetDataSource(dt2);

			To_PDF(oRpt, oBE);

		}


		public void Reporte_OP_Registradas(BE_Reportes oBE)
		{
			Reportes.CR_Lista_OP_reg oRpt = new Reportes.CR_Lista_OP_reg();
			DataTable dt = null;

			dt = Crear_DT_OP_Registradas(oBE);

			dt = Filtrar_Por_Ente(dt, oBE);

			oRpt.SetDataSource(dt);

			To_PDF(oRpt, oBE);


		}


		public void Reporte_OP_x_insc_pend_final(BE_Reportes oBE, string[] arr)
		{
			DataTable dt1 = new DataTable();
			DataTable dt2 = new DataTable();

			dt1 = Crear_DT_OP_x_insc_pend_final(oBE);
			dt2 = Crear_DT_OP_Detalle_insc_pend_final(oBE);
			dt2 = Aplica_Filtro_BusqOP(arr, dt2);

			ReportClass oRpt = new ReportClass();
			if (Reporte_Completo(arr)) {
				oRpt = new Reportes.CR_op_x_insc_pend_final_1();
				oRpt.SetDataSource(dt1);
				oRpt.OpenSubreport("CR_op_det_insc_pen_fin.rpt").SetDataSource(dt2);

			} else {
				oRpt = new Reportes.CR_op_x_insc_pend_final_2();
				oRpt.SetDataSource(dt2);
				//'oRpt.OpenSubreport("CR_op_det_insc_pen_fin.rpt").SetDataSource(dt2)            
				oRpt.SetParameterValue("p_filtro", Show_Filtro(arr));

				//oRpt = New Reportes.CR_op_x_insc_pend_final_2
				//oRpt.SetDataSource(dt1)
				//oRpt.OpenSubreport("CR_op_det_insc_pen_fin.rpt").SetDataSource(dt2)
				//oRpt.OpenSubreport("CR_pp_det_insc_pen_fin.rpt").SetDataSource(dt2)
				//oRpt.OpenSubreport("CR_ae_det_insc_pen_fin").SetDataSource(dt2)
				//oRpt.SetParameterValue("p_filtro", Show_Filtro(arr))            

			}

			To_PDF(oRpt, oBE);

		}


		public void Reporte_Consol_PadronAfil(BE_Reportes oBE)
		{
			Reportes.CR_Consol_Padron_Afil oRpt = new Reportes.CR_Consol_Padron_Afil();
			DataTable dt = null;

			dt = Crear_DT_Consol_PadronAfil(oBE);

			oRpt.SetDataSource(dt);

			To_PDF(oRpt, oBE);

		}


		public void Reporte_Constancias(BE_Reportes oBE)
		{
			Reportes.CR_Listar_Constancias_OP oRpt = new Reportes.CR_Listar_Constancias_OP();
			DataTable dt = null;

			dt = Crear_DT_Constancias(oBE);

			dt = Filtrar_Por_Ente(dt, oBE);

			oRpt.SetDataSource(dt);
			oRpt.SetParameterValue("pTitulo", "Constancias Emitidas");

			To_PDF(oRpt, oBE);

		}


		public void Reporte_Exp_Asignados(BE_Reportes oBE)
		{
			Reportes.CR_Listar_Asistente_x_OP oRpt = new Reportes.CR_Listar_Asistente_x_OP();
			DataTable dt = null;

			dt = Crear_DT_Exp_Asignados(oBE);

			oRpt.SetDataSource(dt);

			To_PDF(oRpt, oBE);

		}


		public void Reporte_Tareas_Pend_x_OP(BE_Reportes oBE, string[] arr)
		{
			Reportes.CR_Tareas_x_OP oRpt = new Reportes.CR_Tareas_x_OP();

			DataTable dtSource = null;

			dtSource = Crear_DT_Tareas_Pend_x_OP(oBE);

			dtSource = Aplica_Filtro_BusqOP(arr, dtSource);

			oRpt.SetDataSource(dtSource);
			To_PDF(oRpt, oBE);

		}



		public void Reporte_Tareas_Pend_x_Tarea(BE_Reportes oBE, string[] arr)
		{
			Reportes.CR_TareasPend_x_Tarea oRpt = new Reportes.CR_TareasPend_x_Tarea();
			DataTable dtSource = null;

			dtSource = Crear_DT_Tareas_Pend_x_Tarea(oBE);

			dtSource = Aplica_Filtro_BusqOP(arr, dtSource);

			oRpt.SetDataSource(dtSource);
			To_PDF(oRpt, oBE);

		}


		private DataTable Aplica_Filtro_BusqOP(string[] arr, DataTable dtSource)
		{

			BE_BusquedaOP paramOP = new BE_BusquedaOP();
			paramOP.Des_OP = arr[0];
			string ID_Asistente = arr[1];
			paramOP.Cod_Tipo_OP = arr[2];
			paramOP.ID_EstadoOP = arr[3];
			paramOP.UserId = arr[4];
			paramOP.Ubigeo = arr[5];

			BE_BusquedaOP.FecEstado paramFec = default(BE_BusquedaOP.FecEstado);
			paramFec.FecIni = arr[6];
			if (!string.IsNullOrEmpty(paramFec.FecIni)) {
				paramFec.FecIni = Utilitario.Funciones.Convert_dd_mm_yyyy(arr[6]);
			}
			paramFec.FecFin = arr[7];
			if (!string.IsNullOrEmpty(paramFec.FecFin)) {
				paramFec.FecFin = Utilitario.Funciones.Convert_dd_mm_yyyy(arr[7]);
			}

			paramOP.SoloSedesReg = arr[9];

			BL_BusquedaOP BL_BusquedaOP = new BL_BusquedaOP();
			this.ListaOP = BL_BusquedaOP.BusquedaOP_x_Parametros(paramOP, paramFec, ListaOP);

			DataTable dt2 = new DataTable();

			dt2 = dtSource.Clone();

			List<BE_BusquedaOP> _LISTA = new List<BE_BusquedaOP>();


			if (Utilitario.Funciones.Dame_ListCount(this.ListaOP) > 0) {
				string _Cod_OP = "";

				foreach (DataRow dr in dtSource.Rows) {
					_Cod_OP = dr["Cod_OP"].ToString();

					_LISTA = ListaOP.FindAll((BE_BusquedaOP x) => x.Cod_OP == _Cod_OP);

					if (_LISTA.Count > 0) {
						if (string.IsNullOrEmpty(ID_Asistente)) {
							if (Es_Sede_Registral_2014(paramOP.SoloSedesReg, _Cod_OP)) {
								dt2.Rows.Add(dr.ItemArray);
							}

						} else {
							if (ID_Asistente == dr["userid"].ToString()) {
								dt2.Rows.Add(dr.ItemArray);
							}
						}

					}

				}
				return dt2;

			} else {
				if (!string.IsNullOrEmpty(ID_Asistente)) {
					foreach (DataRow dr in dtSource.Rows) {
						if (ID_Asistente == dr["userid"].ToString()) {
							dt2.Rows.Add(dr.ItemArray);
						}
					}
					return dt2;


				} else {
					if (Reporte_Completo(arr)) {
						return dtSource;
					} else {
						return dt2;
					}

				}

			}

		}

		private bool Es_Sede_Registral_2014(int SoloSedesReg, int Cod_OP)
		{
			if (SoloSedesReg == 1) {
				if (Cod_OP > 2389) {
					return true;
				} else {
					return false;
				}
			}
			return true;
		}


		public void Reporte_Indicador_A11(BE_Reportes oBE)
		{

			Reportes.CR_IndicadorA11 oRpt = new Reportes.CR_IndicadorA11();
			DataTable dt1 = new DataTable();
			DataTable dt2 = new DataTable();

			dt1 = Crear_DT_Indicador_A11_sum(oBE);
			dt2 = Crear_DT_Indicador_A11_det(oBE);

			oRpt.SetDataSource(dt1);
			oRpt.OpenSubreport("CR_sub_indicadorA11_det.rpt").SetDataSource(dt2);

			To_PDF(oRpt, oBE);


		}


		public void Reporte_Indicador_A12(BE_Reportes oBE)
		{
			Reportes.CR_IndicadorA12 oRpt = new Reportes.CR_IndicadorA12();
			DataTable dt1 = new DataTable();
			DataTable dt2 = new DataTable();

			dt1 = Crear_DT_Indicador_A12_sum(oBE);
			dt2 = Crear_DT_Indicador_A12_det(oBE);

			oRpt.SetDataSource(dt1);
			oRpt.OpenSubreport("CR_sub_indicadorA12_det.rpt").SetDataSource(dt2);

			To_PDF(oRpt, oBE);


		}


		public void Reporte_Indicador_A13(BE_Reportes oBE)
		{
			Reportes.CR_IndicadorA13 oRpt = new Reportes.CR_IndicadorA13();
			DataTable dt1 = new DataTable();
			DataTable dt2 = new DataTable();

			dt1 = Crear_DT_Indicador_A13_sum(oBE);
			dt2 = Crear_DT_Indicador_A13_det(oBE);

			oRpt.SetDataSource(dt1);
			oRpt.OpenSubreport("CR_sub_indicadorA13_det.rpt").SetDataSource(dt2);

			To_PDF(oRpt, oBE);


		}


		public void Reporte_Indicador_A14(BE_Reportes oBE)
		{
			Reportes.CR_IndicadorA14 oRpt = new Reportes.CR_IndicadorA14();
			DataTable dt1 = new DataTable();
			DataTable dt2 = new DataTable();

			dt1 = Crear_DT_Indicador_A14_sum(oBE);
			dt2 = Crear_DT_Indicador_A14_det(oBE);

			oRpt.SetDataSource(dt1);
			oRpt.OpenSubreport("CR_sub_indicadorA14_det.rpt").SetDataSource(dt2);

			To_PDF(oRpt, oBE);


		}


		public void Reporte_Indicador_B1a(BE_Reportes oBE)
		{
			Reportes.CR_IndicadorB1a oRpt = new Reportes.CR_IndicadorB1a();
			DataTable dt = new DataTable();

			dt = Crear_DT_Indicador_B1a(oBE);

			oRpt.SetDataSource(dt);

			To_PDF(oRpt, oBE);

		}


		public void Reporte_Indicador_B1b(BE_Reportes oBE)
		{
			Reportes.CR_IndicadorB1b oRpt = new Reportes.CR_IndicadorB1b();
			DataTable dt = new DataTable();

			dt = Crear_DT_Indicador_B1b(oBE);

			oRpt.SetDataSource(dt);

			To_PDF(oRpt, oBE);

		}


		public void Reporte_Indicador_B2a(BE_Reportes oBE)
		{
			Reportes.CR_IndicadorB2a oRpt = new Reportes.CR_IndicadorB2a();
			DataTable dt = new DataTable();

			dt = Crear_DT_Indicador_B2a(oBE);

			oRpt.SetDataSource(dt);

			To_PDF(oRpt, oBE);

		}


		public void Reporte_Indicador_B2b(BE_Reportes oBE)
		{
			Reportes.CR_IndicadorB2b oRpt = new Reportes.CR_IndicadorB2b();
			DataTable dt = new DataTable();

			dt = Crear_DT_Indicador_B2b(oBE);

			oRpt.SetDataSource(dt);

			To_PDF(oRpt, oBE);

		}


		public void Reporte_Indicador_B3a(BE_Reportes oBE)
		{
			Reportes.CR_IndicadorB3a oRpt = new Reportes.CR_IndicadorB3a();
			DataTable dt = new DataTable();

			dt = Crear_DT_Indicador_B3a(oBE);

			oRpt.SetDataSource(dt);

			To_PDF(oRpt, oBE);

		}


		public void Reporte_Indicador_B3b(BE_Reportes oBE)
		{
			Reportes.CR_IndicadorB3b oRpt = new Reportes.CR_IndicadorB3b();
			DataTable dt = new DataTable();

			dt = Crear_DT_Indicador_B3b(oBE);

			oRpt.SetDataSource(dt);

			To_PDF(oRpt, oBE);

		}


		public void Reporte_Indicador_B3c(BE_Reportes oBE)
		{
			Reportes.CR_IndicadorB3c oRpt = new Reportes.CR_IndicadorB3c();
			DataTable dt = new DataTable();

			dt = Crear_DT_Indicador_B3c(oBE);

			oRpt.SetDataSource(dt);

			To_PDF(oRpt, oBE);

		}


		public void Reporte_Indicador_B4(BE_Reportes oBE)
		{
			Reportes.CR_IndicadorB4 oRpt = new Reportes.CR_IndicadorB4();
			DataTable dt = new DataTable();

			dt = Crear_DT_Indicador_B4(oBE);

			oRpt.SetDataSource(dt);

			To_PDF(oRpt, oBE);

		}


		public void Reporte_Indicador_B5a(BE_Reportes oBE)
		{
			Reportes.CR_IndicadorB5a oRpt = new Reportes.CR_IndicadorB5a();
			DataTable dt = new DataTable();

			dt = Crear_DT_Indicador_B5a(oBE);

			oRpt.SetDataSource(dt);

			To_PDF(oRpt, oBE);

		}


		public void Reporte_Indicador_B5b(BE_Reportes oBE)
		{
			Reportes.CR_IndicadorB5b oRpt = new Reportes.CR_IndicadorB5b();
			DataTable dt = new DataTable();

			dt = Crear_DT_Indicador_B5b(oBE);

			oRpt.SetDataSource(dt);

			To_PDF(oRpt, oBE);

		}


		public void Reporte_Indicador_B5c(BE_Reportes oBE)
		{
			Reportes.CR_IndicadorB5c oRpt = new Reportes.CR_IndicadorB5c();
			DataTable dt = new DataTable();

			dt = Crear_DT_Indicador_B5c(oBE);

			oRpt.SetDataSource(dt);

			To_PDF(oRpt, oBE);

		}


		public void Reporte_Indicador_Pedidos(BE_Reportes oBE)
		{
			Reportes.cr_tiempo_atencion oRpt = new Reportes.cr_tiempo_atencion();
			DataTable dt = new DataTable();

			dt = Crear_DT_Indicador_Pedidos(oBE);

			oRpt.SetDataSource(dt);

			To_PDF(oRpt, oBE);

		}

		/// Fin Menu Reportes


		public void Reporte_Comites_Afil(BE_Reportes oBE)
		{
			Reportes.CR_Comites_Afil_1 oRpt = new Reportes.CR_Comites_Afil_1();
			DataTable dt = null;

			dt = Crear_DT_Comites_Afil(oBE);

			oRpt.SetDataSource(dt);
			oRpt.SetParameterValue("p_fec_carga", oBE.Fec_carga_comite);
			To_PDF(oRpt, oBE);

		}


		public void Reporte_Comites(BE_Reportes oBE)
		{
			Reportes.CR_Comites_1 oRpt = new Reportes.CR_Comites_1();
			DataTable dt = null;

			dt = Crear_DT_Comites(oBE);

			oRpt.SetDataSource(dt);
			oRpt.SetParameterValue("p_all_comites", "False");
			oRpt.SetParameterValue("prmEntregas", oBE.Nro_Entrega);
			To_PDF(oRpt, oBE);

		}


		public void Reporte_Comites_Consolidado(BE_Reportes oBE)
		{
			Reportes.CR_Comites_1 oRpt = new Reportes.CR_Comites_1();
			DataTable dt = null;

			dt = Crear_DT_Comites_Consolidado(oBE);
			oRpt.SetDataSource(dt);

			if (string.IsNullOrEmpty(oBE.str_entregas)) {
				oBE.str_entregas = "Todas";
			}

			oRpt.SetParameterValue("p_all_comites", "True");
			oRpt.SetParameterValue("prmEntregas", oBE.str_entregas);

			To_PDF(oRpt, oBE);

		}


		public void Reporte_Comites_Uniq(BE_Reportes oBE)
		{
			//Dim oRpt As New Reportes.CR_Comites_Afil_2
			Reportes.CR_Comites_Afil_U oRpt = new Reportes.CR_Comites_Afil_U();
			DataTable dt = null;

			dt = Crear_DT_Comites_Uniq(oBE);

			oRpt.SetDataSource(dt);

			To_PDF(oRpt, oBE);

		}


		public void Reporte_Comites_Revisar_VF(BE_Reportes oBE)
		{
			Reportes.CR_Comites_VF oRpt = new Reportes.CR_Comites_VF();
			DataTable dt = null;

			dt = Crear_DT_Comites_Revisar_VF(oBE);

			oRpt.SetDataSource(dt);

			if (string.IsNullOrEmpty(oBE.str_entregas)) {
				oBE.str_entregas = "Todas";
			}

			oRpt.SetParameterValue("prmEntregas", oBE.str_entregas);
			To_PDF(oRpt, oBE);

		}


		public void Reporte_Directivos(BE_Reportes oBE)
		{
			ReportClass oRpt = new ReportClass();
			string prmFiltro = "";
			string prmSinRegistros = "";

			if (oBE.Activos_Bajas_Directivos == 0) {
				//Solo Directivos actuales
				oRpt = new Reportes.CR_Personeros_Rep();

			} else if (oBE.Activos_Bajas_Directivos == 1) {
				//Actuales + Dados baja
				oRpt = new Reportes.CR_Personeros_Rep();

			} else if (oBE.Activos_Bajas_Directivos == 2) {
				// Directivos con Vigencia Mayor a 4 anos
				prmFiltro = "Sin vigencia en el cargo";
				oRpt = new Reportes.CR_Personeros_Cargos();

			} else if (oBE.Activos_Bajas_Directivos == 3) {
				// Directivos con Vigencia Menor a 4 anos
				prmFiltro = "Con vigencia en el cargo";
				oRpt = new Reportes.CR_Personeros_Cargos();

			} else if (oBE.Activos_Bajas_Directivos == 4) {
				// Directivos con Vigencia Cerca a 4 anos (a 1 mes de cumplir 4 anos)
				prmFiltro = "A quedar sin vigencia en el cargo dentro de 6 meses";
				oRpt = new Reportes.CR_Personeros_Cargos();

			}

			DataTable dt = null;

			dt = Crear_DT_Directivos(oBE);

			oRpt.SetDataSource(dt);

			if (dt.Rows.Count > 0) {
				prmSinRegistros = "";
			} else {
				prmSinRegistros = Retorna_prmSinRegistros(oBE.Cod_OP);

			}

			oRpt.SetParameterValue("prmFiltro", prmFiltro);
			oRpt.SetParameterValue("prmSinRegistros", prmSinRegistros);
			To_PDF(oRpt, oBE);

		}

		private string Retorna_prmSinRegistros(int Cod_OP)
		{
			string Ret = "";
			BL_OP oBL_OP = new BL_OP();
			BE_OP oBE_OP = new BE_OP();

			oBE_OP = oBL_OP.Obtener_OP_Completa(Cod_OP);
			Ret = "La organizacón política " + oBE_OP.Des_Op + ", con código " + Cod_OP + " y de Tipo " + oBE_OP.Des_Tipo_Op + ", no cuenta con directivos bajo el presente criterio de filtro.";
			oBE_OP.Dispose();
			oBE_OP = null;
			oBL_OP.DISPOSE();
			oBL_OP = null;
			return Ret;
		}


		public void Reporte_Ult4anos(BE_Reportes oBE)
		{
			Reportes.CR_Ult4anos oRpt = new Reportes.CR_Ult4anos();
			DataTable dt = null;

			dt = Crear_DT_Ult4anos(oBE);

			oRpt.SetDataSource(dt);

			To_PDF(oRpt, oBE);

		}


		public void Reporte_TodosUsers(BE_Reportes oBE)
		{
			Reportes.CR_Users oRpt = new Reportes.CR_Users();
			DataTable dt = null;

			dt = Crear_DT_TodosUsers(oBE);

			oRpt.SetDataSource(dt);

			To_PDF(oRpt, oBE);

		}


		public void Reporte_LoginsDetalle(BE_Reportes oBE)
		{
			Reportes.CR_Logins_01 oRpt = new Reportes.CR_Logins_01();
			DataTable dt = null;

			dt = Crear_DT_LoginsDetalle(oBE);

			oRpt.SetDataSource(dt);

			To_PDF(oRpt, oBE);

		}


		public void Reporte_LoginsAgrupados(BE_Reportes oBE)
		{
			Reportes.CR_Logins_02 oRpt = new Reportes.CR_Logins_02();
			DataTable dt = null;

			dt = Crear_DT_LoginsAgrupados(oBE);

			oRpt.SetDataSource(dt);

			oRpt.SetParameterValue("param2", "Rango de Fechas: " + Utilitario.Funciones.Dame_Texto(oBE.FecIni).Substring(0, 10) + " al " + Utilitario.Funciones.Dame_Texto(oBE.FecFin).Substring(0, 10));

			To_PDF(oRpt, oBE);

		}


		public void Reporte_ConstanciaOP(BE_Reportes oBE)
		{
			Reportes.CR_Const_OP oRpt = new Reportes.CR_Const_OP();
			DataTable dt = null;

			dt = Crear_DT_ConstanciaOP(oBE);

			oRpt.SetDataSource(dt);

			oRpt.SetParameterValue("param1", "");
			string FechaConst = "Lima, " + string.Format("{0:dd MMMM yyyy}", oBE.Fecha_ConstOP);
			oRpt.SetParameterValue("FechaConst", FechaConst);
			oRpt.SetParameterValue("dni_solic", oBE.DNI_Solic);
			oRpt.SetParameterValue("solicitante", oBE.Nombres_Solic);
			oRpt.SetParameterValue("num_const", oBE.Nro_ConstanciaOP);
			oRpt.SetParameterValue("p_responsable", oBE.Responsable_Ente);
			oRpt.SetParameterValue("p_cargo", oBE.Cargo_Responsable);
			oRpt.SetParameterValue("logo1", oBE.Logo1);
			oRpt.SetParameterValue("logo2", oBE.Logo2);
			To_PDF(oRpt, oBE);

		}

		public DataTable Crear_DT_Partidos(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Partidos(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_MovReg(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_MovReg(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_OPLP(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_OPLP(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_OPLD(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_OPLD(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Alianzas(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Alianzas(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Resoluciones(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Resoluciones(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}


		public DataTable Crear_DT_Personeros_Direcc(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Personeros_Direcc(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Directivos_Vencidos(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;

			try {
				dr = _DATA.Lst_Directivos_Vencidos(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Directivos_Por_Vencer(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;

			try {
				dr = _DATA.Lst_Directivos_Por_Vencer(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_OP_Registradas(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_OP_Registradas(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_OP_x_insc_pend_final(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_OP_x_insc_pend_final(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_OP_Detalle_insc_pend_final(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_OP_Detalle_insc_pend_final(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Consol_PadronAfil(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Consol_PadronAfil(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Constancias(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Constancias(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Exp_Asignados(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Exp_Asignados(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}


		public DataTable Crear_DT_Tareas_Pend_x_OP(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Tareas_Pend_x_OP(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Tareas_Pend_x_Tarea(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Tareas_Pend_x_Tarea(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Comites_Afil(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Comites_Afil(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Comites(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Comites(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Comites_Consolidado(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Comites_Consolidado(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Comites_Uniq(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Comites_Uniq(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Comites_Revisar_VF(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Comites_Revisar_VF(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}


		public DataTable Crear_DT_Directivos(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Directivos(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Ult4anos(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Ult4anos(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		private DataTable Crear_DT_TodosUsers(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_TodosUsers(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		private DataTable Crear_DT_LoginsDetalle(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_LoginsDetalle(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		private DataTable Crear_DT_LoginsAgrupados(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_LoginsAgrupados(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_ConstanciaOP(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_ConstanciaOP(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Libros(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Libros(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Indicador_A11_sum(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Indicador_A11_sum(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Indicador_A11_det(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Indicador_A11_det(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Indicador_A12_sum(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Indicador_A12_sum(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Indicador_A12_det(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Indicador_A12_det(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Indicador_A13_sum(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Indicador_A13_sum(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Indicador_A13_det(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Indicador_A13_det(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Indicador_A14_sum(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Indicador_A14_sum(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Indicador_A14_det(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Indicador_A14_det(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Indicador_B1a(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Indicador_B1a(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Indicador_B1b(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Indicador_B1b(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Indicador_B2a(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Indicador_B2a(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Indicador_B2b(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Indicador_B2b(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Indicador_B3a(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Indicador_B3a(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Indicador_B3b(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Indicador_B3b(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Indicador_B3c(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Indicador_B3c(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Indicador_B4(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Indicador_B4(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Indicador_B5a(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Indicador_B5a(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Indicador_B5b(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Indicador_B5b(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Indicador_B5c(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Indicador_B5c(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public DataTable Crear_DT_Indicador_Pedidos(BE_Reportes oBE)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			DataTable dt = new DataTable();
			OracleDataReader dr = null;


			try {
				dr = _DATA.Lst_Indicador_Pedidos(cn, oBE);

				dt.Load(dr);
			} catch (Exception ex) {
				throw ex;
			} finally {
				PCERRARDR(cn, dr);
			}
			return dt;
		}

		public void To_PDF(ReportClass oRpt, BE_Reportes oBE_Rep)
		{
			string strMensajeRep = "";

			try {
				if (System.IO.Directory.Exists(oBE_Rep.Ruta) == false) {
					System.IO.Directory.CreateDirectory(oBE_Rep.Ruta);
				}

				if (oBE_Rep.Oficial == "Si") {
					strMensajeRep = "DOCUMENTO EMITIDO POR LA DIRECCION NACIONAL DE REGISTRO DE ORGANIZACIONES POLÍTICAS";
					strMensajeRep = strMensajeRep + (oBE_Rep.Cod_Ente == "01" ? "" : " - " + oBE_Rep.Des_Ente);
				} else {
					strMensajeRep = "DOCUMENTO NO OFICIAL";
				}
				oRpt.SetParameterValue("param1", strMensajeRep);

				ExportOptions exportOpts = oRpt.ExportOptions;
				oRpt.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
				oRpt.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
				oRpt.ExportOptions.DestinationOptions = new DiskFileDestinationOptions();
				((DiskFileDestinationOptions)oRpt.ExportOptions.DestinationOptions).DiskFileName = oBE_Rep.Ruta + oBE_Rep.PDFName;

				oRpt.Export();


			} catch (Exception ex) {
				using (StreamWriter sw = new StreamWriter(oBE_Rep.Ruta + Strings.Replace(oBE_Rep.PDFName, ".pdf", ".html"))) {
					using (System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(sw)) {

						writer.WriteValue(ex.ToString());

					}
				}

			} finally {
				oRpt.Close();
				oRpt.Dispose();
			}


		}

		private bool Reporte_Completo(string[] arr)
		{
			bool Completo = true;
			if (!string.IsNullOrEmpty(arr[0]))
				Completo = false;
			if (!string.IsNullOrEmpty(arr[1]))
				Completo = false;
			if (!(string.IsNullOrEmpty(arr[2]) | arr[2] == "00"))
				Completo = false;
			if (!(string.IsNullOrEmpty(arr[3]) | arr[3] == "0"))
				Completo = false;
			//If arr(4) <> "" Then Completo = False
			if (!(string.IsNullOrEmpty(arr[5]) | arr[5] == "000000"))
				Completo = false;
			if (!string.IsNullOrEmpty(arr[6]))
				Completo = false;
			if (!string.IsNullOrEmpty(arr[7]))
				Completo = false;
			return Completo;

		}

		private string Show_Filtro(string[] arr)
		{
			string ShowFiltro = "";
			//If arr(0) <> "" Then ShowFiltro = ShowFiltro & "Organización Política: " & arr(0)
			if (!string.IsNullOrEmpty(arr[1]))
				ShowFiltro = ShowFiltro + "Abogado: " + arr[1];
			if (!(string.IsNullOrEmpty(arr[2]) | arr[2] == "00"))
				ShowFiltro = ShowFiltro + (ShowFiltro.Length > 0 ? ", " : "") + "Tipo: " + Tipo_OP(arr[2]);
			if (!(string.IsNullOrEmpty(arr[3]) | arr[3] == "0"))
				ShowFiltro = ShowFiltro + (ShowFiltro.Length > 0 ? ", " : "") + "Estado: " + Estado_OP(arr[3]);
			//If arr(4) <> "" Then Completo = False
			if (!(string.IsNullOrEmpty(arr[5]) | arr[5] == "000000"))
				ShowFiltro = ShowFiltro + (ShowFiltro.Length > 0 ? ", " : "") + "Ubigeo: " + Desc_Ubigeo(arr[5]);
			if (!string.IsNullOrEmpty(arr[6]))
				ShowFiltro = ShowFiltro + (ShowFiltro.Length > 0 ? ", " : "") + "Fecha Inicial: " + arr[6];
			if (!string.IsNullOrEmpty(arr[7]))
				ShowFiltro = ShowFiltro + (ShowFiltro.Length > 0 ? ", " : "") + "Fecha Final: " + arr[7];

			if (arr[9] == "1")
				ShowFiltro = ShowFiltro + (ShowFiltro.Length > 0 ? ", " : "") + "Sólo en Sedes Regitrales";

			return ShowFiltro;

		}

		private string Tipo_OP(string CodTipoOP)
		{
			BL_TipoOP BL = new BL_TipoOP();
			foreach (BE_TipoOP x in BL.Listar_TipoOP()) {
				if (x.COD_TIPO_OP == CodTipoOP) {
					return x.DES_TIPO_OP;
				}
			}
			return "";
		}

		private string Estado_OP(string IdEstadoOP)
		{
			BL_EstadoOP BL = new BL_EstadoOP();
			BE_EstadoOP BE = new BE_EstadoOP();
			foreach (BE_EstadoOP x in BL.Listar_EstadoOP(BE)) {
				if (x.ID_CODIGO == IdEstadoOP) {
					return x.TX_DESCRIPCION;
				}
			}
			return "";
		}

		private string Desc_Ubigeo(string idUbigeo)
		{
			BL_Ubigeo BL = new BL_Ubigeo();
			BE_UBIGEO BE = new BE_UBIGEO();
			BE = BL.Desc_Ubigeo(idUbigeo);
			return BE.TX_REGION + (BE.TX_PROVINCIA.Length > 0 ? " - " : "") + BE.TX_PROVINCIA + (BE.TX_DISTRITO.Length > 0 ? " - " : "") + BE.TX_DISTRITO;
		}

		private DataTable Filtrar_Por_Ente(DataTable dt, BE_Reportes BE)
		{
			if (Utilitario.Funciones.Es_Registrador_Provincia(BE.Cod_Perfil) == true) {
				//Dim x As DataView = dt.DefaultView
				//x.RowFilter = "Cod_Ente = " & BE.Cod_Ente
				//Return x.ToTable


				DataView dv = new DataView(dt);
				dv.RowFilter = "Cod_Ente = " + BE.Cod_Ente;
				return dv.ToTable();
			} else {
				return dt;
			}

		}

		public List<BE_BusquedaOP> ListaOP { get; set; }

	}
}
