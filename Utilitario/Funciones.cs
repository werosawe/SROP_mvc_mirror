using Oracle.DataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Drawing;

public class Funciones
{

    public static bool Valid_DNI(string strDNI)
    {
        bool functionReturnValue = false;
        functionReturnValue = true;
        int i = 0;
        if (strDNI.Length == 8)
        {
            i = 0;
            while ((i <= strDNI.Length - 1))
            {
                if ("1234567890".IndexOf(strDNI.Substring(i, 1)) < 0)
                {
                    //DNI Error
                    functionReturnValue = false;
                }
                i = i + 1;
            }
        }
        else
        {
            //DNI Error
            functionReturnValue = false;
        }
        return functionReturnValue;
    }

    public static int Dame_ListCount(object XobjValue)
    {

        if (object.ReferenceEquals(XobjValue, System.DBNull.Value))
        {
            return 0;
        }
        else if (XobjValue == null)
        {
            return 0;
        }
        else if (XobjValue.ToString().Trim().Equals(""))
        {
            return 0;
        }
        return ((IList)XobjValue).Count;
    }
    public static string Dame_Valor_WebConfig(string param)
    {

        return System.Configuration.ConfigurationManager.AppSettings[param];
    }

    public static string GET_SENTENCIA_SQL(string TX_STORE, OracleParameter[] prm)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder("");
        int i;
        for (i = 0; i <= prm.Length - 1; i++)
        {
            string coma = ",";
            if (i == prm.Length - 1)
            {
                coma = "";
            }
            if (prm[i] != null)
            {
                if (prm[i].Direction == ParameterDirection.Input | prm[i].Direction == ParameterDirection.InputOutput)
                {
                    sb.Append("'");
                    sb.Append(prm[i].Value.Text());
                    sb.Append("'" + coma);
                }
                else
                {
                    sb.Append("'_OUTPUT_'" + coma);
                }
            }
            else
            {
                sb.Append("'_NOTHING_'" + coma);
            }
        }
        return TX_STORE + ": " + sb.ToString();
    }
    public static bool Es_Registrador_Provincia(string Cod_Perfil)
    {
        if (Cod_Perfil == "08" | Cod_Perfil == "19")
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public static System.Drawing.Image DibujaTexto(String text, Font font, Color textColor, Color backColor)
    {
        //first, create a dummy bitmap just to get a graphics object
        System.Drawing.Image img = new Bitmap(1, 1);
        Graphics drawing = Graphics.FromImage(img);

        //measure the string to see how big the image needs to be
        SizeF textSize = drawing.MeasureString(text, font);

        //free up the dummy image and old graphics object
        img.Dispose();
        drawing.Dispose();

        //create a new image of the right size
        img = new Bitmap((int)textSize.Width, (int)textSize.Height);

        drawing = Graphics.FromImage(img);

        //paint the background
        drawing.Clear(backColor);

        //create a brush for the text
        Brush textBrush = new SolidBrush(textColor);

        drawing.DrawString(text, font, textBrush, 0, 0);

        drawing.Save();

        textBrush.Dispose();
        drawing.Dispose();

        return img;

    }

    public static string fTipoArchivo( string TXFORMATO)
    {
        if (TXFORMATO.NoNulo())
        {
            int NUINICIO = TXFORMATO.ToString().LastIndexOf(".");
            if (NUINICIO > -1)
            {
                TXFORMATO = TXFORMATO.ToString().Substring(NUINICIO);
                TXFORMATO = TXFORMATO.Text().Mayuscula().Replace(".", "");
            }
        }
        switch (TXFORMATO)
        {
            case "JPG":
                return "image/jpg";
            case "JPEG":
                return "image/jpeg";
            case "TIF":
                return "image/tiff";
            case "BMP":
                return "image/bmp";
            case "PNG":
                return "image/png";
            case "GIF":
                return "image/gif";
            case "CSS":
                return "text/css";
            case "PDF":
                return "application/pdf";
            case "TXT":
                return "text/plain";
            case "HTML":
                return "text/html";
            case "RTF":
                return "application/rtf";
            case "XLS":
                return "application/vnd.ms-excel";
            case "DBF":
                return "application/vnd.ms-excel";
            case "XLSX":
                return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            case "DOC":
                return "application/msword";
            case "DOCX":
                return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            case "PPT":
                return "application/vnd.ms-powerpoint";
            case "PPS":
                return "application/vnd.ms-powerpoint";
            case "PPTX":
                return "application/vnd.openxmlformats-officedocument.presentationml.presentation";
            case "PPSX":
                return "application/vnd.openxmlformats-officedocument.presentationml.presentation";
            //case "PPSX":
            //    return "application/vnd.openxmlformats-officedocument.presentationml.slideshow";
            case "MDB":
                return "application/vnd.ms-access";
            case "MDBX":
                return "application/vnd.ms-access";
            case "ZIP":
                return "application/zip";
            default:
                return "application/octet-stream";
        }
    }


    //public static T DesSerializar<T>(this string TX_DATA)
    //{
    //    System.IO.MemoryStream ms = null;
    //    DataContractJsonSerializer serializer = null;
    //    try
    //    {
    //        ms = new System.IO.MemoryStream(System.Text.Encoding.Unicode.GetBytes(TX_DATA));
    //        serializer = new DataContractJsonSerializer(typeof(T));
    //        return (T)serializer.ReadObject(ms);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        ms.Close();
    //        ms = null;
    //        serializer = null;
    //    }
    //}






    }
