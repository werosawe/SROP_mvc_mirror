using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;
using System.Web;
using System.Runtime.Serialization.Json;
using System.Reflection;
using System.IO;
using System.Web.Hosting;

public static partial class Glo
{

    public static string GetPath(this string path)
    {
        if (Path.IsPathRooted(path))
        {
            return path;
        }

        return HostingEnvironment.MapPath(path);
    }

    public static T FormatearNombreDeArchivo<T>(this T obj, string TXARCHIVORUTACOMPLETA)
    {
        Type t = obj.GetType();// typeof(T);

        string TXARCHIVONOMBRE = null;
        string TXARCHIVOEXTENSION = TXARCHIVORUTACOMPLETA.ToString().Substring(TXARCHIVORUTACOMPLETA.ToString().Length - 4, 4);
        int NUINICIO = TXARCHIVORUTACOMPLETA.ToString().LastIndexOf("\\") + 1;
        int NUFINAL = TXARCHIVORUTACOMPLETA.ToString().LastIndexOf(".");
        TXARCHIVONOMBRE = TXARCHIVORUTACOMPLETA.Substring(NUINICIO, NUFINAL - NUINICIO);
        TXARCHIVONOMBRE = TXARCHIVONOMBRE.RemoveDiacritics();
        TXARCHIVONOMBRE = TXARCHIVONOMBRE.RestringeASCII(40);
        TXARCHIVONOMBRE = TXARCHIVONOMBRE.Mayuscula();

        TXARCHIVOEXTENSION = TXARCHIVOEXTENSION.Replace(".", "").Mayuscula();
       
      

        PropertyInfo PpyTXARCHIVORUTACOMPLETA = t.GetProperty("TXARCHIVORUTACOMPLETA");
        PpyTXARCHIVORUTACOMPLETA.SetValue(obj, TXARCHIVORUTACOMPLETA, null);

        PropertyInfo PpyTXARCHIVOEXTENSION = t.GetProperty("TXARCHIVOEXTENSION");
        PpyTXARCHIVOEXTENSION.SetValue(obj, TXARCHIVOEXTENSION, null);

        PropertyInfo PpyTXARCHIVONOMBRE = t.GetProperty("TXARCHIVONOMBRE");
        PpyTXARCHIVONOMBRE.SetValue(obj, TXARCHIVONOMBRE, null);


        PropertyInfo PryENVIARA = t.GetProperty("ENVIARA");

        if (PryENVIARA.GetValue(obj, null).GetType().ToString() == "System.String")
        {

        }else if (PryENVIARA.GetValue(obj, null).GetType().ToString() == "System.Int32")
        {
            if (PryENVIARA.GetValue(obj, null).ToString().Num() == TIPOTABLA.ENVIARA.BaseDatos)
            {

                FileStream fs = new FileStream(TXARCHIVORUTACOMPLETA, FileMode.Open, FileAccess.Read);
                long filesize = fs.Length;
                byte[] BLARCHIVO = new byte[Convert.ToInt32(fs.Length - 1) + 1];
                fs.Read(BLARCHIVO, 0, Convert.ToInt32(filesize));
                fs.Close();
                fs.Close(); fs = null;

                PropertyInfo PpyBLARCHIVO = t.GetProperty("BLARCHIVO");
                PpyBLARCHIVO.SetValue(obj, BLARCHIVO, null);

                File.Delete(TXARCHIVORUTACOMPLETA.GetPath());
            }
        }

        //sb.Append(m.Name & "|" & m.GetValue(obj, Nothing).ToString & "|0~")

        //                    ElseIf m.GetValue(obj, Nothing).GetType.ToString = "System.Int32" Then
        //                        If CType(m.GetValue(obj, Nothing), Integer) > 0 Then
        //                            sb.Append(m.Name & "|" & m.GetValue(obj, Nothing).ToString & "|1~")
        //                        End If
        //                    End If

        //if (Archivo.ENVIARA != TIPOTABLA.ENVIARA.BaseDatos) { File.Delete(GetPath(TXARCHIVORUTACOMPLETA)); }; //Eliminar el archivo//

   

 

       

        return obj;

    }


}
