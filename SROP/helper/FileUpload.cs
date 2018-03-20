using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;
using System.Web.Hosting;

[Serializable()]
[DataContract()]
public class FileUpLoad: BE_BASE
{
    //public MvcHtmlString inputFile()
    //{

    //    return new MvcHtmlString(string.Concat("<input type='file' required='required'  id='filesToUploadCtrl' ", fTipoArchivo(accept), " name='filesToUploadInput[]' ", ((multiple == 1) ? "multiple=''" : ""), ">"));
    //}
    //style='display:none'
    public HtmlString GetTipoArchivo()
    {
        StringBuilder sb = new StringBuilder("");
        if (accept.NoNulo())
        {
            string[] ss = accept.Split(char.Parse("|"));
            foreach (string s in ss)
            {
                sb.Append(string.Concat(".", s.Minuscula(), ","));
            }
            //return string.Concat();
            return new HtmlString(string.Concat("accept='", sb.ToString(), "'"));
        }
        return new HtmlString("");
    }

    public HtmlString GetMultiple()
    {       
        if (multiple.Equals(1))
        {
            return new HtmlString("multiple");
            //return "multiple";
        }
        return new HtmlString("");
    }
    public HtmlString GetRequired()
    {       
        if (required.Equals(true))
        {
            return new HtmlString("required='required'");
            //return "required='required'";
        }
        return new HtmlString("");
    }

    [DataMember(EmitDefaultValue = false, Name = "required")] public bool required { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "multiple")] public int multiple { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "accept")] public string accept { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "TerminateFunction")] public string TerminateFunction { get; set; }   
    [DataMember(EmitDefaultValue = false, Name = "FileName")] public string FileName { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "TempFolder")] public string TempFolder { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "MaxFileSizeMB")] public int MaxFileSizeMB { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "FileParts")] public List<String> FileParts { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "baseFileName")] public string baseFileName { get; set; }

    //multiple: 0,  required='required'
    //        TipoArchivo: @TipoTabla.TipoArchivo_.Simbolo,
    //        ESTADOPAGINA: '@enumEstadoPagina.Edicion',
    //        Cod_OP: @Model.Cod_OP,
    //        ProcesoTerminado : 'CargarSimbolo'

    public FileUpLoad()
    {
        FileParts = new List<string>();
        ENVIARA = TIPOTABLA.ENVIARA.CarpetaTemporal;
        required = false;
    }

    /// <summary>
    /// original name + ".part_N.X" (N = file part number, X = total files)
    /// Objective = enumerate files in folder, look for all matching parts of split file. If found, merge and return true.
    /// </summary>
    /// <param name="FileName"></param>
    /// <returns></returns>
    public bool MergeFile(string FileName)
    {
        bool rslt = false;
        // parse out the different tokens from the filename according to the convention
        string partToken = ".part_";
        baseFileName = FileName.Substring(0, FileName.IndexOf(partToken));
        string trailingTokens = FileName.Substring(FileName.IndexOf(partToken) + partToken.Length);
        int FileIndex = 0;
        int FileCount = 0;
        int.TryParse(trailingTokens.Substring(0, trailingTokens.IndexOf(".")), out FileIndex);
        int.TryParse(trailingTokens.Substring(trailingTokens.IndexOf(".") + 1), out FileCount);
        // get a list of all file parts in the temp folder
        string Searchpattern = Path.GetFileName(baseFileName) + partToken + "*";
        string[] FilesList = Directory.GetFiles(Path.GetDirectoryName(FileName), Searchpattern);
        string[] FilesListToDelete = FilesList;
        //  merge .. improvement would be to confirm individual parts are there / correctly in sequence, a security check would also be important
        // only proceed if we have received all the file chunks
        if (FilesList.Count() == FileCount)
        {
            // use a singleton to stop overlapping processes
            if (!MergeFileManager.Instance.InUse(baseFileName))
            {
                MergeFileManager.Instance.AddFile(baseFileName);
                if (System.IO.File.Exists(baseFileName))
                    System.IO.File.Delete(baseFileName);
                // add each file located to a list so we can get them into 
                // the correct order for rebuilding the file
                List<SortedFile> MergeList = new List<SortedFile>();
                foreach (string File in FilesList)
                {
                    SortedFile sFile = new SortedFile();
                    sFile.FileName = File;
                    baseFileName = File.Substring(0, File.IndexOf(partToken));
                    trailingTokens = File.Substring(File.IndexOf(partToken) + partToken.Length);
                    int.TryParse(trailingTokens.Substring(0, trailingTokens.IndexOf(".")), out FileIndex);
                    sFile.FileOrder = FileIndex;
                    MergeList.Add(sFile);
                }
                // sort by the file-part number to ensure we merge back in the correct order
                var MergeOrder = MergeList.OrderBy(s => s.FileOrder).ToList();
                using (FileStream FS = new FileStream(baseFileName, FileMode.Create))
                {
                    // merge each file chunk back into one contiguous file stream
                    foreach (var chunk in MergeOrder)
                    {
                        try
                        {
                            using (FileStream fileChunk = new FileStream(chunk.FileName, FileMode.Open))
                            {
                                fileChunk.CopyTo(FS);
                                fileChunk.Dispose();
                            }
                            // Delete chunks or parts of transfered file
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                            System.IO.File.SetAttributes(chunk.FileName, FileAttributes.Normal);
                            System.IO.File.Delete(chunk.FileName);
                        }
                        catch (IOException ex)
                        {
                            throw ex;
                            //File.AppendAllText(
                            //    Path.GetDirectoryName(baseFileName) + @"\Errorlog.txt", ex.Message + Environment.NewLine);
                        }
                    }
                }
                rslt = true;

                //// unlock the file from singleton
                MergeFileManager.Instance.RemoveFile(baseFileName);
            }

        }
        return rslt;
    }

}

public struct SortedFile
{
    public int FileOrder { get; set; }
    public String FileName { get; set; }
}

public class MergeFileManager
{
    private static MergeFileManager instance;
    private List<string> MergeFileList;

    private MergeFileManager()
    {
        try
        {
            MergeFileList = new List<string>();
        }
        catch { }
    }

    public static MergeFileManager Instance
    {
        get
        {
            if (instance == null)
                instance = new MergeFileManager();
            return instance;
        }
    }

    public void AddFile(string BaseFileName)
    {
        MergeFileList.Add(BaseFileName);
    }

    public bool InUse(string BaseFileName)
    {
        return MergeFileList.Contains(BaseFileName);
    }

    public bool RemoveFile(string BaseFileName)
    {
        return MergeFileList.Remove(BaseFileName);
    }

}
