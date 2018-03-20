using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

//public enum eInput
//{
//    button = 1,
//    checkbox = 2,
//    color = 3,
//    date = 4,
//    datetime_local = 5,
//    email = 6,
//    file = 7,
//    hidden = 8,
//    image = 9,
//    month = 10,
//    number = 11,
//    password = 12,
//    radio = 13,
//    range = 14,
//    reset = 15,
//    search = 16,
//    submit = 17,
//    tel = 18,
//    text = 19,
//    time = 20,
//    url = 21,
//    week = 22,
//    textarea = 23
//}
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class texticulo : ValidationAttribute  
{
    private bool _flRequired;
    private int _minlength;
    private int _maxlength;

    public texticulo(bool flRequired = false, int minlength = 3, int maxlength = 30)
    {
        _flRequired = flRequired;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        //if (value.NoNulo()) // lets check if we have some value
        //{
        //    if ((value.Text().Length >= _minlength && value.Text().Length <= _maxlength) == false) // check if it is a valid integer
        //    {
        //        return new ValidationResult("Minimum value for this field should be ");
        //    }
        //}
        //else
        //{
        //    return new ValidationResult("Minimum value for this field should be ");
        //}

        //return ValidationResult.Success;

        return new ValidationResult("Minimum value for this field should be ");
    } 

    //public override string FormatErrorMessage(string name)
    //{
    //    return String.Format(CultureInfo.CurrentCulture,
    //      ErrorMessageString, name, this.text);
    //}

}