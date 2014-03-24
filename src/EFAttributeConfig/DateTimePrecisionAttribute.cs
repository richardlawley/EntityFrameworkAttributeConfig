using System;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;

namespace RichardLawley.EF.AttributeConfig
{
	/// <summary>
	/// Configures the precision property of a DateTime within the store
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
	public sealed class DateTimePrecisionAttribute : EFPropertyConfigurationAttribute
	{
		public DateTimePrecisionAttribute(byte value)
		{
			Value = value;
		}

		public byte Value { get; set; }

		public override void Configure(PrimitivePropertyConfiguration property)
		{
			DateTimePropertyConfiguration datetimeProperty = property as DateTimePropertyConfiguration;
			if (datetimeProperty == null) { throw new ArgumentException("Property should be DateTimePropertyConfiguration"); }

			datetimeProperty.HasPrecision(Value);
		}
	}
}