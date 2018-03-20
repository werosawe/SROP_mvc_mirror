using System;
using System.Runtime.Serialization;
[Serializable()]
public class BE_UBIGEO : BE_BASE
{
  
    bool disposed = false;
    protected override void Dispose(bool disposing)
    {
        if (disposed) return;
        if (disposing) { }
        disposed = true;
        base.Dispose(disposing);
    }
    ~BE_UBIGEO() { Dispose(false); }
}

