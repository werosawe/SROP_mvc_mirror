using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;
using System.Web;
using System.Runtime.Serialization.Json;
using System.Reflection;
public static partial class Glo
{
    
    public static List<T> Ordenar<T>(this List<T> obj, List<BE_ORDEN> _ORDEN_COL, string TXORDENPORDEFECTO)
    {
        //ORDEN_COL = _ORDEN_COL;
        if (_ORDEN_COL.Count > 0)
        {
            _ORDEN_COL.Sort(new Sorter<BE_ORDEN>("priority"));
            System.Text.StringBuilder s = new System.Text.StringBuilder("");
            foreach (BE_ORDEN o in _ORDEN_COL)
            {
                s.Append(string.Concat(o.property, " ", o.direction, ","));

            }
            if (s.ToString().Length > 0)
            {
                s.Remove(s.ToString().Length - 1, 1);
            }
            obj.Sort(new Sorter<T>(s.ToString()));
        }
        else
        {
            obj.Sort(new Sorter<T>(TXORDENPORDEFECTO));
        }
        return obj;
    }





    public static T Criterio<T>(this T obj, List<BE_FILTRO> FILTRO_COL)
    {
        //BindingFlags flags =  BindingFlags.GetProperty ;
        //BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.NonPublic;
        //FLSABANA = false;
        foreach (BE_FILTRO f in FILTRO_COL)
        {
            string NO_CAMPO = f.property;
            object VALOR = f.value;
            string NO_VALOR = "";
            PropertyInfo p = obj.GetType().GetProperty(NO_CAMPO);
            if (p != null)
            {
                if (VALOR != null)
                {
                    //if (NO_CAMPO.Equals("CO_EST_REG")) { if (VALOR.Equals("true") || VALOR.Equals(true)) { VALOR = "1"; } else if (VALOR.Equals("false") || VALOR.Equals(false)) { VALOR = "0"; } 

                    if (VALOR.GetType().ToString() == "System.String" || VALOR.GetType().ToString() == "System.Int32")
                    {
                        NO_VALOR = Convert.ToString(VALOR);

                        bool flag;
                        bool.TryParse(NO_VALOR, out flag);
                        if (flag)
                        {
                            if (NO_VALOR == "true") { NO_VALOR = "1"; } else { NO_VALOR = "0"; }
                        }

                    }
                    else if (VALOR.GetType().IsArray == true)
                    {
                        IEnumerable enumerable = VALOR as IEnumerable;
                        string[] arrVALOR = Array.ConvertAll<object, string>((object[])VALOR, Convert.ToString);
                        NO_VALOR = string.Join(",", arrVALOR);
                    }
                    else if (VALOR.GetType().ToString() == "System.Boolean")
                    {
                        if ((bool)VALOR == true) { NO_VALOR = "1"; } else { NO_VALOR = "0"; }
                        //IEnumerable enumerable = VALOR as IEnumerable;
                        //string[] arrVALOR = Array.ConvertAll<object, string>((object[])VALOR, Convert.ToString);
                        //NO_VALOR = string.Join(",", arrVALOR);
                    }


                    if (p.PropertyType.Name == "String")
                    {
                        p.SetValue(obj, (string)NO_VALOR, null);
                    }
                    else if (p.PropertyType.Name == "Int32")
                    {
                        p.SetValue(obj, int.Parse(NO_VALOR), null);
                    }
                }
            }
        }
        return obj;
    }

}

