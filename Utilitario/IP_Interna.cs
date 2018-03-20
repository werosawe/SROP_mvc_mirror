using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using System.Configuration;
namespace Utilitario
{

	public class IP_Interna
	{

		//Evitar que cada vez que se cargue la page, el sistema entre en un loop de redireccion infinita
		//Public Property Segmentos_IP_int As String
		public string IP_USER { get; set; }


		public IP_Interna()
		{
		}

		public bool Tengo_IP_Interna()
		{

			// Debes crear una pagina Start.aspx
			// Esa pagina Start.aspx debe ser la default en el web.config Authentication mode="Forms" loginUrl
			// Revisar propiedad DefaultUrl
			///http://stackoverflow.com/questions/3106896/defaulturl-loginurl-in-asp-net-web-config?rq=1

			bool boo = false;
			// Se redirecciona a IP externa

			try {
				string Segmentos_IP_int = "";

				Segmentos_IP_int = ConfigurationManager.AppSettings["segmentos_ip_int"];

				string[] arrIP_int = null;
				arrIP_int = Segmentos_IP_int.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

				for (int i = 0; i <= arrIP_int.Count() - 1; i++) {
					if (IP_USER == arrIP_int[i]) {
						boo = true;
						// Se redirecciona a IP interna

					} else {
						boo = Compara_Segmentos_IP(IP_USER, arrIP_int[i]);

					}
					if (boo) {
						break; // TODO: might not be correct. Was : Exit For
					}
				}

			} catch  {
                throw;
				//Redirect webapp to URL_externa

			} finally {
			}
			return boo;

		}
		private bool Compara_Segmentos_IP(string IP_User, string Segmento_IP)
		{
			if (GetNthPos(IP_User, Convert.ToChar("."), 2) == -1) {
				return false;
			} else {
				if (IP_User.Substring(0, GetNthPos(IP_User, Convert.ToChar("."), 2) + 1) == Segmento_IP) {
					return true;
				} else {
					return false;
				}
			}

		}
		public static int GetNthPos(string s, char t, int n)
		{
			int count = 0;
			for (int i = 0; i <= s.Length - 1; i++) {
				if (s[i] == t) {
					count += 1;
					if (count == n) {
						return i;
					}
				}
			}
			return -1;
		}


		public void Dispose()
		{
			//base.Finalize();
			GC.SuppressFinalize(this);
		}


	}
}
