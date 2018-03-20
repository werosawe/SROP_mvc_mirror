using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;
using System.Web;
using System.Reflection;
using System.IO;
using System.Web.ModelBinding;
//<HideModuleName()> <AttributeUsage(AttributeTargets.All)> _

public static class ControllerFunction
{
    //EXITO = 1 - INFORMACION = 2 - ADVERTENCIA = 3 - PELIGRO = 4
    public static IEnumerable<BE_MENSAJE> AllErrors(this System.Web.Mvc.ModelStateDictionary modelState)
    {
        var result = new List<BE_MENSAJE>();
        var erroneousFields = modelState.Where(ms => ms.Value.Errors.Any()) .Select(x => new { x.Key, x.Value.Errors });
        foreach (var erroneousField in erroneousFields)
        {
            var fieldKey = erroneousField.Key;
            var fieldErrors = erroneousField.Errors.Select(error => error.ErrorMessage.DesSerializar<BE_MENSAJE>());
            result.AddRange(fieldErrors);
        }
        return result;
    }
}

public static  class ControllerApiFunction
{
    public static IEnumerable<BE_MENSAJE> AllErrors(this System.Web.Http.ModelBinding.ModelStateDictionary modelState)
    {
        var result = new List<BE_MENSAJE>();
        var erroneousFields = modelState.Where(ms => ms.Value.Errors.Any())
                                        .Select(x => new { x.Key, x.Value.Errors });

        foreach (var erroneousField in erroneousFields)
        {
            var fieldKey = erroneousField.Key;

            var fieldErrors = erroneousField.Errors.Select(error => error.ErrorMessage.DesSerializar<BE_MENSAJE>());


            result.AddRange(fieldErrors);
        }  
        return result;
    }
}