using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
/// Project	 : BE
/// Class	 : BE_PAGINA
///
/// -----------------------------------------------------------------------------
/// <summary>
/// 
/// </summary>
/// <remarks>
/// </remarks>
/// <history>
/// 	[Jonatan Abregu Chalco]	Created 07/06/2017
/// </history>
[Serializable()]
[DataContract()]
public partial class BE_PAGINA : BE_BASE
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    [DataMember(EmitDefaultValue = false, Name = "IDAREA")]
    public int IDAREA { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "QTPADRES")]
    public int QTPADRES { get; set; }
    

    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    [DataMember(EmitDefaultValue = false, Name = "NUORDEN")]
    public int NUORDEN { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    [DataMember(EmitDefaultValue = false, Name = "TXTITULOFLOTANTE")]
    public string TXTITULOFLOTANTE { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    [DataMember(EmitDefaultValue = false, Name = "IDPAGINAPADRE")]
    public int IDPAGINAPADRE { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    [DataMember(EmitDefaultValue = false, Name = "TXCONTROLADOR")]
    public string TXCONTROLADOR { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    [DataMember(EmitDefaultValue = false, Name = "TXACCION")]
    public string TXACCION { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>PRIMARY KEY</remarks>
    [DataMember(EmitDefaultValue = false, Name = "IDPAGINA")]
    public int IDPAGINA { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    [DataMember(EmitDefaultValue = false, Name = "TXROL")]
    public string TXROL { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    [DataMember(EmitDefaultValue = false, Name = "TXTITULO")]
    public string TXTITULO { get; set; }


    [DataMember(EmitDefaultValue = false, Name = "TXAREA")]
    public string TXAREA { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "TXAREADESCRIPCION")]
    public string TXAREADESCRIPCION { get; set; }


    [DataMember(EmitDefaultValue = false, Name = "isFirst")]
    public bool isFirst { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "isLast")]
    public bool isLast { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "isLastParent")]
    public bool isLastParent { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "children")]
    public List<BE_PAGINA> children { get; set; }

    bool disposed = false;
    protected override void Dispose(bool disposing)
    {
        if (disposed) return;
        if (disposing) { }
        disposed = true;
        base.Dispose(disposing);
    }
    ~BE_PAGINA() { Dispose(false); }
}





//public static class ClassTreeGrid
//{
//    private static List<BE_PAGINA> _origen;
//    private static List<BE_PAGINA> _destino;
//    public static List<BE_PAGINA> TreeGrid(this List<BE_PAGINA> origen)
//    {
//        _origen = origen;
//        Carguito(0);

//        return _destino;
//    }


//    private static void Carguito(int IDPAGINA, BE_PAGINA doc = null)
//    {

//        List<BE_PAGINA> r = _origen.FindAll(x => x.IDPAGINAPADRE == IDPAGINA);
//        r.Sort(new Sorter<BE_PAGINA>("NUORDEN"));

//        // Verficar el primer y el ultimo elemento de cada grupo
//        if (r.Count > 0)
//        {
//            //int NuDocFirst = r.Min(x => x.NUORDEN);
//            //int NuDocLast = r.Max(x => x.NUORDEN);
//            //BE_Documento docFirst = r.Find(x => x.NUORDEN == NuDocFirst);
//            //if (docFirst != null) { docFirst.isFirst = true; }
//            //BE_Documento docLast = r.Find(x => x.NUORDEN == NuDocLast);
//            //if (docLast != null) { docLast.isLast = true; }


//            BE_PAGINA docFirst = r.First();
//            if (docFirst != null) { docFirst.isFirst = true; }
//            BE_PAGINA docLast = r.Last();
//            if (docLast != null) { docLast.isLast = true; }



//        }
//        // Verficar el primer y el ultimo elemento de cada grupo

//        if (doc == null)
//        {
//            _destino = r;

//            foreach (BE_PAGINA i in _destino)
//            {
//                Carguito(i.IDPAGINA, i);
//            }
//        }
//        else
//        {
//            foreach (BE_PAGINA i in r)
//            {
//                if (doc.Children == null) { doc.Children = new List<BE_PAGINA>(); }

//                int IDPAGINAPADRE = i.IDPAGINAPADRE;
//                BE_PAGINA docParent = _origen.Find(x => x.IDPAGINA == IDPAGINAPADRE);
//                if (docParent != null)
//                {
//                    if (docParent.isLast == true) { i.isLastParent = true; }
//                }

//                doc.Children.Add(i);
//                Carguito(i.IDPAGINA, i);
//            }
//        }


//        //var roots = groups.FirstOrDefault().ToList();


//    }


//}