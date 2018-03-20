using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
[Serializable()]
[DataContract()]
public class BE_FILTRO
{
    [DataMember(EmitDefaultValue = false, Name = "value")]
    public object value { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "property")]
    public string property { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "operator")] public string Operator { get; set; }
    ~BE_FILTRO() { }

 }