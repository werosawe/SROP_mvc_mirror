using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Web;
using System.Configuration;
namespace Utilitario
{

    public class Encriptar_Desencriptar
	{

        public static string Desencriptar_CN(string TX_ESQUEMA, string KEY)
        {
            if (HttpRuntime.Cache[TX_ESQUEMA] == null)
            {
                string TXCONEXION = DecryptTripleDES(ConfigurationManager.ConnectionStrings[TX_ESQUEMA].ToString(), KEY);
                HttpRuntime.Cache.Insert(TX_ESQUEMA, TXCONEXION, null, DateTime.Now.AddHours(12), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
                return TXCONEXION;
            }
            else
            {
                return HttpRuntime.Cache[TX_ESQUEMA].ToString();
            }
        }

        public static string EncryptTripleDES(string sIn, string key)
		{
			TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
			MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
			// Compute the MD5 hash.
			DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(key));
			// Set the cipher mode.
			DES.Mode = CipherMode.ECB;
			// Create the encryptor.
			ICryptoTransform DESEncrypt = DES.CreateEncryptor();
			// Get a byte array of the string.
			byte[] Buffer = System.Text.ASCIIEncoding.ASCII.GetBytes(sIn);
			// Transform and return the string.
			return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
		}

		public static string DecryptTripleDES(string sOut, string key)
		{
			TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
			MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
			// Compute the MD5 hash.
			DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(key));
			// Set the cipher mode.
			DES.Mode = CipherMode.ECB;
			// Create the decryptor.
			ICryptoTransform DESDecrypt = DES.CreateDecryptor();
			byte[] Buffer = Convert.FromBase64String(sOut);
			// Transform and return the string.
			return System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
		}

	}
}
