using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;
using System.Web;
using System.Runtime.Serialization.Json;
using System.Reflection;
public static partial class Glo
{


    

    public static string Serializar(this Object OBJ)
    {
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        DataContractJsonSerializer serializer = null;
        try
        {
            serializer = new DataContractJsonSerializer(OBJ.GetType());
            serializer.WriteObject(ms, OBJ);

            return System.Text.Encoding.UTF8.GetString(ms.ToArray());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            ms.Close();
            ms = null;
        }
    }

    public static string Serializar<T>(this T OBJ, bool FL_JSCRIPT = false)
    {
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        DataContractJsonSerializer serializer = null;
        try
        {
            serializer = new DataContractJsonSerializer(OBJ.GetType());
            serializer.WriteObject(ms, OBJ);

            if (FL_JSCRIPT == false)
            {
                return System.Text.Encoding.UTF8.GetString(ms.ToArray());
            }
            else
            {
                string TX = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                TX = TX.Replace("\"", "'");
                return TX;
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            ms.Close();
            ms = null;
        }
    }


    public static List<T> DesSerializarLista<T>(this string TX_DATA)
    {
        System.IO.MemoryStream ms = null;
        DataContractJsonSerializer serializer = null;
        try
        {
            List<T> ITEM = new List<T>();
            ms = new System.IO.MemoryStream(System.Text.Encoding.Unicode.GetBytes(TX_DATA));
            //DataContractJsonSerializerSettings s = new DataContractJsonSerializerSettings();

            serializer = new DataContractJsonSerializer(ITEM.GetType());
            //serializer.KnownTypes.Where<T>(;//== true;
            return (List<T>)serializer.ReadObject(ms);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            ms.Close();
            ms = null;
            serializer = null;
        }
    }


    public static T DesSerializar<T>(this string TX_DATA)
    {
        System.IO.MemoryStream ms = null;
        DataContractJsonSerializer serializer = null;
        try
        {
            ms = new System.IO.MemoryStream(System.Text.Encoding.Unicode.GetBytes(TX_DATA));
            serializer = new DataContractJsonSerializer(typeof(T));
            return (T)serializer.ReadObject(ms);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            ms.Close();
            ms = null;
            serializer = null;
        }
    }
    


    public static string GetFieldJson(this object Entidad, params string[] Propiedades)
    {
        // Coleccion donde se agregara los Campos con sus valores 
        List<PropiedadJSON> PROPIEDAD_COL = new List<PropiedadJSON>();
        System.Text.StringBuilder sbEntidad = new System.Text.StringBuilder("");
        try
        {
            BindingFlags flags = (BindingFlags.Instance
                        | (BindingFlags.Public
                        | (BindingFlags.DeclaredOnly
                        | (BindingFlags.Static
                        | (BindingFlags.GetProperty | BindingFlags.NonPublic)))));
            Type Objeto = Entidad.GetType();
            PropertyInfo Info = null;
            object Prop = null;
            foreach (string _item in Propiedades)
            {
                string NO_Propiedad = _item;
                // Buscamos si la propiedad es una Sub Clase
                int IndexPunto = _item.IndexOf(Convert.ToChar("."));
                if ((IndexPunto > -1))
                {
                    // En caso que la propiedad sea una Sub Clase
                    string NO_SubClase = NO_Propiedad.Substring(0, IndexPunto);
                    string NO_SubPropiedad = NO_Propiedad.Substring((IndexPunto + 1));
                    object SubClase = Objeto.InvokeMember(NO_SubClase, flags, null, Entidad, null);
                    if (SubClase != null)
                    {
                        Type SubObjeto = SubClase.GetType();
                        Info = SubObjeto.GetProperty(NO_SubPropiedad);
                        if (Info != null)
                        {
                            if (Info.CanRead)
                            {
                                Prop = Info.GetValue(SubClase, null);
                                PropiedadJSON _prop = fPropiedad(Info, Prop, NO_SubClase, NO_SubPropiedad);
                                PROPIEDAD_COL.Add(_prop);
                            }

                        }

                    }

                }
                else
                {
                    Info = Objeto.GetProperty(NO_Propiedad);
                    Prop = Info.GetValue(Entidad, null);
                    PropiedadJSON _prop = fPropiedad(Info, Prop, "", NO_Propiedad);
                    PROPIEDAD_COL.Add(_prop);
                }

            }

            //var tmp = from x in myCollection
              //        group x by x.Id;

            PROPIEDAD_COL.Sort(new Sorter<PropiedadJSON>("TXCLASE,TXPROPIEDAD"));

            IEnumerable<PropiedadJSON> filteredList = PROPIEDAD_COL .GroupBy(x => x.TXCLASE) .Select(group => group.First());
                     
            foreach (var CLASE in filteredList)
            {
                string TXCLASE = CLASE.TXCLASE;
                List<PropiedadJSON> _resultado = PROPIEDAD_COL.FindAll(x=> x.TXCLASE == TXCLASE);
                if (_resultado.Count > 0)
                {
                    if (TXCLASE.NoNulo())
                    {                        
                        sbEntidad.Append(string.Concat("\"", TXCLASE, "\":{"));
                        foreach (PropiedadJSON _item in _resultado)
                        {
                            sbEntidad.Append(_item.GetPropiedad);
                        }
                        sbEntidad.Remove((sbEntidad.ToString().Length - 1), 1);
                        sbEntidad.Append("},");
                    }
                    else
                    {
                        foreach (PropiedadJSON i in _resultado)
                        {
                            sbEntidad.Append(i.GetPropiedad);
                        }

                    }

                }

            }

            sbEntidad.Remove((sbEntidad.ToString().Length - 1), 1);
            return string.Concat("{", sbEntidad.ToString(), "}");

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            sbEntidad = null;
        }
    }

    public static PropiedadJSON fPropiedad(PropertyInfo Info, object Prop, string TXCLASE, string TXPROPIEDAD)
    {
        if (Info != null)
        {          
            if (Info.CanRead)
            {
                PropiedadJSON _prop = new PropiedadJSON();
                _prop.TXTIPODATO = Prop.GetType().ToString();
                _prop.TXVALOR = Prop.ToString();
                _prop.TXCLASE = TXCLASE;
                _prop.TXPROPIEDAD = TXPROPIEDAD;
                return _prop;
            }

        }

        return null;
    }

    

}


public class PropiedadJSON
{
    
    public string TXTIPODATO { get; set; }
    public string TXCLASE { get; set; } 
    public string TXPROPIEDAD { get; set; }
    public string TXVALOR { get; set; }
    

    public string GetPropiedad
    {
        get
        {
            if (TXTIPODATO.Equals("System.String"))
            {
                return string.Concat("\"", TXPROPIEDAD, "\":\"", TXVALOR, "\",");
            }
            else if (TXTIPODATO.Equals("System.Int32"))
            {
                return string.Concat("\"", TXPROPIEDAD, "\":", TXVALOR, ",");
            }
            else if (TXTIPODATO.Equals("System.Decimal"))
            {
                return string.Concat("\"", TXPROPIEDAD, "\":", TXVALOR, ",");
            }

            return "";
        }
    }
}