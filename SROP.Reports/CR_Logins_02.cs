using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------


 // ERROR: Not supported in C#: OptionDeclaration
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.ComponentModel;
namespace Reportes
{


	public class CR_Logins_02 : ReportClass
	{

		public CR_Logins_02() : base()
		{
		}

		public override string ResourceName {
			get { return "CR_Logins_02.rpt"; }
				//Do nothing
			set { }
		}

		public override bool NewGenerator {
			get { return true; }
				//Do nothing
			set { }
		}

		public override string FullResourceName {
			get { return "Reportes.CR_Logins_02.rpt"; }
				//Do nothing
			set { }
		}

		[Browsable(false), DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public CrystalDecisions.CrystalReports.Engine.Section Section1 {
			get { return this.ReportDefinition.Sections[0]; }
		}

		[Browsable(false), DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public CrystalDecisions.CrystalReports.Engine.Section Section2 {
			get { return this.ReportDefinition.Sections[1]; }
		}

		[Browsable(false), DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public CrystalDecisions.CrystalReports.Engine.Section GroupHeaderSection1 {
			get { return this.ReportDefinition.Sections[2]; }
		}

		[Browsable(false), DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public CrystalDecisions.CrystalReports.Engine.Section GroupHeaderSection2 {
			get { return this.ReportDefinition.Sections[3]; }
		}

		[Browsable(false), DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public CrystalDecisions.CrystalReports.Engine.Section Section3 {
			get { return this.ReportDefinition.Sections[4]; }
		}

		[Browsable(false), DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public CrystalDecisions.CrystalReports.Engine.Section GroupFooterSection2 {
			get { return this.ReportDefinition.Sections[5]; }
		}

		[Browsable(false), DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public CrystalDecisions.CrystalReports.Engine.Section GroupFooterSection1 {
			get { return this.ReportDefinition.Sections[6]; }
		}

		[Browsable(false), DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public CrystalDecisions.CrystalReports.Engine.Section Section4 {
			get { return this.ReportDefinition.Sections[7]; }
		}

		[Browsable(false), DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public CrystalDecisions.CrystalReports.Engine.Section Section5 {
			get { return this.ReportDefinition.Sections[8]; }
		}

		[Browsable(false), DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public CrystalDecisions.Shared.IParameterField Parameter_param1 {
			get { return this.DataDefinition.ParameterFields[0]; }
		}

		[Browsable(false), DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public CrystalDecisions.Shared.IParameterField Parameter_param2 {
			get { return this.DataDefinition.ParameterFields[1]; }
		}
	}
}
namespace Reportes
{

	[System.Drawing.ToolboxBitmapAttribute(typeof(CrystalDecisions.Shared.ExportOptions), "report.bmp")]
	public class CachedCR_Logins_02 : Component, ICachedReport
	{

		public CachedCR_Logins_02() : base()
		{
		}

		[Browsable(false), DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public virtual bool IsCacheable {
			get { return true; }
				//
			set { }
		}

		[Browsable(false), DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public virtual bool ShareDBLogonInfo {
			get { return false; }
				//
			set { }
		}

		[Browsable(false), DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public virtual System.TimeSpan CacheTimeOut {
			get { return CachedReportConstants.DEFAULT_TIMEOUT; }
				//
			set { }
		}

		public virtual CrystalDecisions.CrystalReports.Engine.ReportDocument CreateReport()
		{
			CR_Logins_02 rpt = new CR_Logins_02();
			rpt.Site = this.Site;
			return rpt;
		}

		public virtual string GetCustomizedCacheKey(RequestContext request)
		{
			String key = null;
			//// The following is the code used to generate the default
			//// cache key for caching report jobs in the ASP.NET Cache.
			//// Feel free to modify this code to suit your needs.
			//// Returning key == null causes the default cache key to
			//// be generated.
			//
			//key = RequestContext.BuildCompleteCacheKey(
			//    request,
			//    null,       // sReportFilename
			//    this.GetType(),
			//    this.ShareDBLogonInfo );
			return key;
		}
	}
}
