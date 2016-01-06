using System;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;

namespace RichardLawley.EF.AttributeConfig
{
	/// <summary>
	/// Configures the precision property of a DateTime within the store
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
	public sealed class DateTimePrecisionAttribute : Attribute
	{
		public DateTimePrecisionAttribute(byte value)
		{
			Value = value;
		}

		public byte Value { get; set; }
	}
}