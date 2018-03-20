using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
[Serializable()]
[DataContract()]
public class BE_ORDEN
{
    [DataMember(EmitDefaultValue = false, Name = "property")]
    public string property { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "direction")]
    public string direction { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "priority")]
    public int priority { get; set; }

    public string directionImage
    {
        get
        {
            if (direction == "ASC") { return "<span style='float:right;' class='glyphicon glyphicon-sort-by-attributes'></span>"; }
            else
            {
                return "<span style='float:right;' class='glyphicon glyphicon-sort-by-attributes-alt'></span>";
            }

        }
    }

    ~BE_ORDEN() { }
}