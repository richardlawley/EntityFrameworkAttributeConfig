using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAttributeConfig
{
	/// <summary>
	/// Base class for Property Configuration Attributes
	/// </summary>
	public abstract class EFPropertyConfigurationAttribute : Attribute
	{
		/// <summary>
		/// Overridden in implementation classes to apply the actual configuration to a property
		/// </summary>
		/// <param name="property">Property to configure</param>
		public abstract void Configure(PrimitivePropertyConfiguration property);
	}
}
