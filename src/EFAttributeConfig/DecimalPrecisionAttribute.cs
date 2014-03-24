using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAttributeConfig
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
	}
}
