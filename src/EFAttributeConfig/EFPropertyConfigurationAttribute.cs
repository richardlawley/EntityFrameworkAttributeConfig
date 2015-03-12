using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;

namespace RichardLawley.EF.AttributeConfig
{
	/// <summary>
	/// Base class for Property Configuration Attributes
	/// </summary>
	public abstract class EFPropertyConfigurationAttribute : ValidationAttribute
	{
		/// <summary>
		/// Overridden in implementation classes to apply the actual configuration to a property
		/// </summary>
		/// <param name="property">Property to configure</param>
		public abstract void Configure(PrimitivePropertyConfiguration property);
	}
}