using System;
using System.Runtime.Serialization;
using System.Collections.Generic;



[Serializable()]
[DataContract()]
public class BE_MENSAJE
{
    public BE_MENSAJE(string _TXLLAVE, string _TXMENSAJE, enumTipoMensaje _IDTIPOMENSAJE = enumTipoMensaje.Advertencia )
    {
        TXLLAVE = _TXLLAVE;
        TXMENSAJE = _TXMENSAJE;
        IDTIPOMENSAJE = _IDTIPOMENSAJE;
    }

    [DataMember(EmitDefaultValue = false, Name = "TXLLAVE")] public string TXLLAVE { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "TXMENSAJE")] public string TXMENSAJE { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "IDTIPOMENSAJE")] public enumTipoMensaje IDTIPOMENSAJE { get; set; } //EXITO = 1 - INFORMACION = 2 - ADVERTENCIA = 3 - PELIGRO = 4
    
}