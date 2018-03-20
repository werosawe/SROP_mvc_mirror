using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Oracle.DataAccess.Client;
using System.Web.Mvc;

//public enum UTILITARIO_MUESTRA_FECHA : int
//{
//    NINGUNO = 0,
//    CLIENTE_FECHA_24HORA = 1,
//    CLIENTE_FECHA_12HORA,
//    CLIENTE_FECHA,
//    CLIENTE_12HORA,
//    CLIENTE_24HORA,
//    CLIENTE_DIA_NUMERO,
//    CLIENTE_MES_NUMERO,
//    CLIENTE_ANNO_NUMERO,
//    CLIENTE_DIA_NOMBRE,
//    CLIENTE_MES_NOMBRE,
//    CLIENTE_HORA_NUMERO,
//    CLIENTE_MINUTO_NUMERO,
//    CLIENTE_SEGUNDO_NUMERO,
//    CLIENTE_FECHA_12HORA_DIA_MES
//}



public static partial class Glo
{
    public static Nullable<System.DateTime> Convert_dd_mm_yyyy(this object XobjValue)
    {
        if (object.ReferenceEquals(XobjValue, System.DBNull.Value))
        {
            return null;
        }
        else if (XobjValue == null)
        {
            return null;
        }
        else if (XobjValue.ToString().Trim().Equals(""))
        {
            return null;
        }
        else
        {

            try
            {
                string[] arrMonth = { "ENE", "FEB", "MAR", "ABR", "MAY", "JUN", "JUL", "AGO", "SEP", "OCT", "NOV", "DIC" };
                //int iMonth = arrMonth.ToList().IndexOf(XobjValue.Substring(3, 3).ToUpper) + 1;

                int iMonth = Array.IndexOf(arrMonth, XobjValue.ToString().Substring(3, 3).ToUpper()) + 1;

                string f = XobjValue.ToString().Substring(0, 2) + "/" + iMonth.ToString().PadLeft(2, Convert.ToChar("0")) + "/" + XobjValue.ToString().Substring(7, 4);
                return Convert.ToDateTime(f);
            }

            catch (Exception ex)
            {
                return Convert.ToDateTime(XobjValue);
            }

        }
    }




    //public static string Fecha(string XobjValue)
    //{
    //    return FechaCliente(XobjValue, UTILITARIO_MUESTRA_FECHA.NINGUNO, false);
    //}

    //public static string Fecha(this string XobjValue, UTILITARIO_MUESTRA_FECHA _Mostrar = UTILITARIO_MUESTRA_FECHA.CLIENTE_FECHA_12HORA, bool FL_SEGUNDO = false)
    //{
    //    return FechaCliente(XobjValue, _Mostrar, FL_SEGUNDO);
    //}

    //private static void ppf()
    //{
    //    fecha("", new FeParam { formatoEntrada = "" });

    //}

 

    private static List<BE_FORMATOFECHA> getsFormatoCol(string formato)
    {
        MatchCollection ss= Regex.Matches(formato, @"(.)\1*");
        int iCaracter = -1, NUORDEN = 0;
        List<BE_FORMATOFECHA> r = new List<BE_FORMATOFECHA>();
        foreach (Match s in ss)
        {

            BE_FORMATOFECHA i = new BE_FORMATOFECHA();
            if (s.Value == "dd")
            {
                i.TXTIPOFORMATO = "Dia";
                i.IDTIPODATO = 1;
                i.NUCARACTERINICIAL = iCaracter + 1;
                i.NUCARACTERES = 2;
                i.TXSIGLA = s.Value;
                iCaracter = iCaracter + 2;
                NUORDEN = NUORDEN + 1;
                i.NUORDEN = NUORDEN;
                r.Add(i);
            }
            else if (s.Value == "MM")
            {
                i.TXTIPOFORMATO = "Mes";
                i.IDTIPODATO = 1;
                i.NUCARACTERINICIAL = iCaracter + 1;
                i.NUCARACTERES = 2;
                i.TXSIGLA = s.Value;
                iCaracter = iCaracter + 2;
                NUORDEN = NUORDEN + 1;
                i.NUORDEN = NUORDEN;
                r.Add(i);
            }
            else if (s.Value == "yyyy")
            {
                i.TXTIPOFORMATO = "Anno";
                i.IDTIPODATO = 1;
                i.NUCARACTERINICIAL = iCaracter + 1;
                i.NUCARACTERES = 4;
                i.TXSIGLA = s.Value;
                iCaracter = iCaracter + 4;
                NUORDEN = NUORDEN + 1;
                i.NUORDEN = NUORDEN;
                r.Add(i);
            }
            else if (s.Value == "hh" || s.Value == "HH")
            {
                i.TXTIPOFORMATO = "Hora";
                i.IDTIPODATO = 1;
                i.NUCARACTERINICIAL = iCaracter + 1;
                i.NUCARACTERES = 2;
                i.TXSIGLA = s.Value;
                iCaracter = iCaracter + 2;
                NUORDEN = NUORDEN + 1;
                i.NUORDEN = NUORDEN;
                r.Add(i);
            }
            else if (s.Value == "mm")
            {
                i.TXTIPOFORMATO = "Minuto";
                i.IDTIPODATO = 1;
                i.NUCARACTERINICIAL = iCaracter + 1;
                i.NUCARACTERES = 2;
                i.TXSIGLA = s.Value;
                iCaracter = iCaracter + 2;
                NUORDEN = NUORDEN + 1;
                i.NUORDEN = NUORDEN;
                r.Add(i);
            }
            else if (s.Value == "ss")
            {
                i.TXTIPOFORMATO = "Segundo";
                i.IDTIPODATO = 1;
                i.NUCARACTERINICIAL = iCaracter + 1;
                i.NUCARACTERES = 2;
                i.TXSIGLA = s.Value;
                iCaracter = iCaracter + 2;
                NUORDEN = NUORDEN + 1;
                i.NUORDEN = NUORDEN;
                r.Add(i);
            }
            else if (s.Value == "tt")
            {
                i.TXTIPOFORMATO = "Asignador";
                i.IDTIPODATO = 2;
                i.NUCARACTERINICIAL = iCaracter + 1;
                i.NUCARACTERES = 2;
                i.TXSIGLA = s.Value;
                iCaracter = iCaracter + 2;
                NUORDEN = NUORDEN + 1;
                i.NUORDEN = NUORDEN;
                r.Add(i);
            }
            else if (s.Value == "/" || s.Value == "-" || s.Value == ".")
            {
                i.TXTIPOFORMATO = "SeparadorFecha";
                i.IDTIPODATO = 2;
                i.NUCARACTERINICIAL = iCaracter + 1;
                i.NUCARACTERES = 1;
                i.TXSIGLA = s.Value;
                iCaracter = iCaracter + 1;
                NUORDEN = NUORDEN + 1;
                i.NUORDEN = NUORDEN;
                r.Add(i);
            }
            else if (s.Value == ":")
            {
                i.TXTIPOFORMATO = "SeparadorHora";
                i.IDTIPODATO = 2;
                i.NUCARACTERINICIAL = iCaracter + 1;
                i.NUCARACTERES = 1;
                i.TXSIGLA = s.Value;
                iCaracter = iCaracter + 1;
                NUORDEN = NUORDEN + 1;
                i.NUORDEN = NUORDEN;
                r.Add(i);
            }
            else if (s.Value == "T")
            {
                i.TXTIPOFORMATO = "IdentificadorTiempo";
                i.IDTIPODATO = 2;
                i.NUCARACTERINICIAL = iCaracter + 1;
                i.NUCARACTERES = 1;
                i.TXSIGLA = s.Value;
                iCaracter = iCaracter + 1;
                NUORDEN = NUORDEN + 1;
                i.NUORDEN = NUORDEN;
                r.Add(i);
            }
        }


        return r;
    }



    //private static string FechaConfiguracion(string fechaTexto,  string formato, string formatoSalida, bool fHtml5= true)
    private static BE_PARAMETRO_FORMATOFECHA FechaConfiguracion(BE_PARAMETRO_FORMATOFECHA prm)
    {         
        prm.FORMATOFECHACOL = getsFormatoCol(prm.TXFORMATOENTRADA);
        prm.FORMATOFECHACOL.Sort(new Sorter<BE_FORMATOFECHA>("NUORDEN"));
        prm.TXFECHAENTRADA = prm.TXFECHAENTRADA.Replace(" ", "").Text();
        foreach (BE_FORMATOFECHA i in prm.FORMATOFECHACOL) {
            if (i.IDTIPODATO == 1) { i.TXVALOR = prm.TXFECHAENTRADA.Substring(i.NUCARACTERINICIAL, i.NUCARACTERES); }
            else if (i.IDTIPODATO == 2) { i.TXVALOR = prm.TXFECHAENTRADA.Substring(i.NUCARACTERINICIAL, i.NUCARACTERES); }
        }

        BE_FORMATOFECHA Hora = prm.FORMATOFECHACOL.Find(x => x.TXTIPOFORMATO == "Hora");
        BE_FORMATOFECHA Asignador = prm.FORMATOFECHACOL.Find(x => x.TXTIPOFORMATO == "Asignador");
        if (Hora != null && Asignador != null) {
            int valor = Hora.TXVALOR.Num();
            if (Hora.TXSIGLA == "hh" && Asignador.TXVALOR.Minuscula() == "pm") {
                valor = valor.Num() + 12; if (valor == 24) { valor = 0; }
            }
            Hora.TXVALOR = valor.Text();
        }
        int ano = 0, mes = 0, dia = 0, hora = 0, minuto = 0, segundo = 0;
        BE_FORMATOFECHA ItemAno = prm.FORMATOFECHACOL.Find(x => x.TXTIPOFORMATO == "Anno"); if (ItemAno != null) { ano = ItemAno.TXVALOR.Num(); }
        BE_FORMATOFECHA ItemMes = prm.FORMATOFECHACOL.Find(x => x.TXTIPOFORMATO == "Mes"); if (ItemMes != null) { mes = ItemMes.TXVALOR.Num(); }
        BE_FORMATOFECHA ItemDia = prm.FORMATOFECHACOL.Find(x => x.TXTIPOFORMATO == "Dia"); if (ItemDia != null) { dia = ItemDia.TXVALOR.Num(); }
        BE_FORMATOFECHA ItemHora = prm.FORMATOFECHACOL.Find(x => x.TXTIPOFORMATO == "Hora"); if (ItemHora != null) { hora = ItemHora.TXVALOR.Num(); }
        BE_FORMATOFECHA ItemMinuto = prm.FORMATOFECHACOL.Find(x => x.TXTIPOFORMATO == "Minuto"); if (ItemMinuto != null) { minuto = ItemMinuto.TXVALOR.Num(); }
        BE_FORMATOFECHA ItemSegundo = prm.FORMATOFECHACOL.Find(x => x.TXTIPOFORMATO == "Segundo"); if (ItemSegundo != null) { segundo = ItemSegundo.TXVALOR.Num(); }
        prm.FECALCULO = new DateTime(ano, mes, dia, hora, minuto, segundo, 0);

        if (prm.NUANNO > 0)
        {
            prm.FECALCULO = prm.FECALCULO.AddYears(prm.NUANNO);
        }
        if (prm.NUMES > 0)
        {
            prm.FECALCULO = prm.FECALCULO.AddMonths(prm.NUMES);            
        }
        if (prm.NUDIA > 0)
        {
            prm.FECALCULO = prm.FECALCULO.AddDays(prm.NUDIA);
        }
        if (prm.NUHORA > 0)
        {
            prm.FECALCULO = prm.FECALCULO.AddHours(prm.NUHORA);
        }
        if (prm.NUMINUTO > 0)
        {
            prm.FECALCULO = prm.FECALCULO.AddMinutes(prm.NUMINUTO);
        }
         if (prm.NUSEGUNDO > 0)
        {
            prm.FECALCULO = prm.FECALCULO.AddSeconds(prm.NUSEGUNDO);
        }

        return prm;
    }



    private static string FechaSalida(BE_PARAMETRO_FORMATOFECHA prm )
    {
        if (prm.TXFORMATOSALIDA == null) { prm.TXFORMATOSALIDA = prm.TXFORMATOENTRADA; }
        List<BE_FORMATOFECHA> formatoSalidaCol = getsFormatoCol(prm.TXFORMATOSALIDA);
        formatoSalidaCol.Sort(new Sorter<BE_FORMATOFECHA>("NUORDEN"));

        string strSalida = null;
        List<BE_FORMATOFECHA> formatoEntradaCol = prm.FORMATOFECHACOL;
        DateTime f = prm.FECALCULO;

        foreach (BE_FORMATOFECHA i in formatoSalidaCol)
        {
            if (i.TXTIPOFORMATO == "Dia") { strSalida = strSalida + f.ToString("dd"); }
            else if (i.TXTIPOFORMATO == "Mes") { strSalida = strSalida + f.ToString("MM"); }
            else if (i.TXTIPOFORMATO == "Anno") { strSalida = strSalida + f.ToString("yyyy"); }
            else if (i.TXTIPOFORMATO == "Hora") { strSalida = strSalida + f.ToString("HH"); }
            else if (i.TXTIPOFORMATO == "Minuto") { strSalida = strSalida + f.ToString("mm"); }
            else if (i.TXTIPOFORMATO == "Segundo") { strSalida = strSalida + f.ToString("ss"); }
            else if (i.TXTIPOFORMATO == "Asignador") { strSalida = strSalida + " " + i.TXVALOR; }
            else if (i.TXTIPOFORMATO == "SeparadorFecha") { strSalida = strSalida + i.TXSIGLA; }
            else if (i.TXTIPOFORMATO == "SeparadorHora") { strSalida = strSalida + i.TXSIGLA; }
            else if (i.TXTIPOFORMATO == "IdentificadorTiempo") { strSalida = strSalida + i.TXSIGLA; }
        }
        return strSalida;
    }
    
    //public static string Mayuscula(this object XobjValue)
    public static string fecha(this string strFecha, BE_PARAMETRO_FORMATOFECHA prm = default(BE_PARAMETRO_FORMATOFECHA))
    {
        if (prm == null) { prm = new BE_PARAMETRO_FORMATOFECHA(); }
        if (strFecha.EsNulo()) { return null; } else { prm.TXFECHAENTRADA = strFecha; }
        if (prm.TXFORMATOENTRADA == null) { prm.TXFORMATOENTRADA = CO_Constante.formatoFechaHTML5; }//"yyyy-MM-ddTHH:mm:ss"
        //public string formatoEntrada { get { return _formatoEntrada == null ? "yyyy-MM-ddTHH:mm:ss" : _formatoEntrada; } set { _formatoEntrada = value; } }
        return FechaSalida(FechaConfiguracion(prm));
    }

    private static DateTime? Fec(this object XobjValue)
    {
        //DateTime nullDateTime = default(DateTime);
        //Nullable<DateTime> nullDateTime = null;
        if (object.ReferenceEquals(XobjValue, System.DBNull.Value)) { return null; }
        else if (XobjValue == null) { return null; }
        else if (XobjValue.ToString().Trim().Equals("")) { return null; }
        //return DateTime.ParseExact(Convert.ToString(XobjValue), CO_Constante.formatoFecha, null);
        return DateTime.Parse(Convert.ToString(XobjValue));
    }

    public static DateTime? Fec(this OracleDataReader dr, string TXCOLUMNA) { return Fec(dr[TXCOLUMNA]); }

    public static DateTime? Fec(this System.Data.DataRow dr, string TXCOLUMNA)
    {
        return Fec(dr[TXCOLUMNA]);
    }

    public static DateTime? Fec(this ModelMetadata m) {
        return  Fec(m.Model.Text());
    }




    //private static string FechaCliente2(string XobjValue)
    //    {
    //        if (XobjValue.EsNulo()) { return null; }

    //        if (XobjValue.ToString().Trim().Length == 14 | XobjValue.ToString().Trim().Length == 12)
    //        {
    //            string tx_dia = XobjValue.ToString().Substring(6, 2);
    //            string tx_mes = XobjValue.ToString().Substring(4, 2);
    //            string tx_anno = XobjValue.ToString().Substring(0, 4);

    //            string tx_fecha_hora = "";
    //            string tx_hora = XobjValue.ToString().Substring(8, 2);
    //            string tx_minuto = XobjValue.ToString().Substring(10, 2);
    //            string tx_segundo = "00";

    //            if (XobjValue.ToString().Trim().Length == 14)
    //            {
    //                tx_segundo = XobjValue.ToString().Substring(12, 2);
    //            }

    //            tx_fecha_hora = tx_hora + ":" + tx_minuto + ":" + tx_segundo;

    //            return tx_dia + "/" + tx_mes + "/" + tx_anno + " " + tx_fecha_hora;

    //        }
    //        else if (XobjValue.ToString().Trim().Length == 10)
    //        {
    //            string tx_dia = XobjValue.ToString().Substring(6, 2);
    //            string tx_mes = XobjValue.ToString().Substring(4, 2);
    //            string tx_anno = XobjValue.ToString().Substring(0, 4);
    //            return tx_dia + "/" + tx_mes + "/" + tx_anno;

    //        }
    //        else
    //        {
    //            return null;
    //        }

    //    }



}


