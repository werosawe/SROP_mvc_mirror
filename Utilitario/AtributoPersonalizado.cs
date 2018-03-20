using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

//
// Resumen:
//     Atributo para input text 
//     el cuial sirve
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
public class text : ValidationAttribute, IClientValidatable

{
    private int _MinLength;
    private int _MaxLength;
    private string _placeholder;

    public text(int minLength, int maxLength, string placeholder = null)
    {
        _MinLength = minLength;
        _MaxLength = maxLength;
        _placeholder = placeholder;
    }

    public override bool IsValid(object value)
    {
        //if (value == null || (DateTime)value < DateTime.Now)
        //    return false;

        return true;
    }

    public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
    {

        var rgl = new ModelClientValidationRule
        {
            ErrorMessage = "Ingrese texto",
            ValidationType = "length",
        };

        metadata.Watermark = _placeholder;


        if (_MinLength > 0)
        {
            rgl.ValidationParameters.Add("minlength", _MinLength);
        }

        if (_MaxLength > 0)
        {
            rgl.ValidationParameters.Add("maxlength", _MaxLength);
        }

        yield return rgl;

        //yield return new ModelClientValidationRule
        //{
        //    ErrorMessage = this.ErrorMessage,
        //    ValidationType = "futuredate",          
        //}.ValidationParameters.Add("","");




        //yield return new ModelClientValidationRule
        //{
        //    ErrorMessage = "pepe el vivo",
        //    ValidationType = "futuredate2"
        //};
    }
}

//
// Resumen:
//     Atributo para input numeric 
//     el cuial sirve
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
public class number : ValidationAttribute, IClientValidatable

{
    private int _min;
    private int _max;
    //private bool _flRequerido;
    private string _placeholder;

    public number(int min, int max, string placeholder = null)
    {
        _min = min;
        _max = max;
        //_flRequerido = flRequerido;
        _placeholder = placeholder;
    }

    public override bool IsValid(object value)
    {
        //if (value == null || (DateTime)value < DateTime.Now)
        //    return false;

        return true;
    }

    public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
    {

        var rgl = new ModelClientValidationRule
        {
            ErrorMessage = "Ingrese texto",
            ValidationType = "range",
        };
               
        metadata.Watermark = _placeholder;
       

        if (_min > 0)
        {
            rgl.ValidationParameters.Add("min", _min);
        }

        if (_max > 0)
        {
            rgl.ValidationParameters.Add("max", _max);
        }

        yield return rgl;

        //yield return new ModelClientValidationRule
        //{
        //    ErrorMessage = this.ErrorMessage,
        //    ValidationType = "futuredate",          
        //}.ValidationParameters.Add("","");




        //yield return new ModelClientValidationRule
        //{
        //    ErrorMessage = "pepe el vivo",
        //    ValidationType = "futuredate2"
        //};
    }
}