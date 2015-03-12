using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.SqlTypes;
using System.Linq;

namespace RichardLawley.EF.AttributeConfig
{
	/// <summary>
	/// Configures the precision of a decimal type within the datastore
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
	public sealed class DecimalPrecisionAttribute : EFPropertyConfigurationAttribute
	{
		public DecimalPrecisionAttribute(byte precision, byte scale)
		{
			Precision = precision;
			Scale = scale;
		}

		public byte Precision { get; set; }

		public byte Scale { get; set; }

		public override void Configure(PrimitivePropertyConfiguration property)
		{
			DecimalPropertyConfiguration decimalProperty = property as DecimalPropertyConfiguration;
			if (decimalProperty == null) { throw new ArgumentException("property should be DecimalPropertyConfiguration"); }
			decimalProperty.HasPrecision(Precision, Scale);
		}

    protected override ValidationResult IsValid(object value, ValidationContext context)
    {
      var dec = value as decimal?;
      if (!dec.HasValue)
        return new ValidationResult("The PrecisionAttribute can only be used on string");
      try
      {
        SqlDecimal.ConvertToPrecScale(new SqlDecimal(dec.Value), Precision, Scale);
      }
      catch (Exception)
      {
        return new ValidationResult(String.Format("The field '{0}' with the value '{1}'does not have the specified Precision: {2} and/or scale: {3}", context.DisplayName, dec.Value, Precision, Scale));
      }
      return ValidationResult.Success;
    }
	}
}