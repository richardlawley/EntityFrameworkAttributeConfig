using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace RichardLawley.EF.AttributeConfig
{
	/// <summary>
	/// Extension methods to apply the configuration attributes
	/// </summary>
	public static class DbContextConfiguration
	{
		/// <summary>
		/// Applies the configuration attributes for entities found in all of the specified assemblies
		/// </summary>
		/// <param name="modelBuilder">Model Builder</param>
		/// <param name="assemblies">Assemblies to search for entities</param>
		[Obsolete("Use AttributeConventions instead")]
		public static void ApplyConfigurationAttributes(this DbModelBuilder modelBuilder, params Assembly[] assemblies)
		{
			throw new InvalidOperationException("This method is no longer supported.  Instead, use modelBuilder.Conventions.Add(new DecimalPrecisionAttributeConvention()) and other equivalents");
		}

		/// <summary>
		/// Applies the configuration attributes for entities found in the specified assembly matching the given type filter
		/// </summary>
		/// <param name="modelBuilder">Model Builder</param>
		/// <param name="assembly">Assembly to search for entities</param>
		/// <param name="typeFilter">Filter for types in the given assembly</param>
		[Obsolete("Use AttributeConventions instead")]
		public static void ApplyConfigurationAttributes(this DbModelBuilder modelBuilder, Assembly assembly, Func<Type, bool> typeFilter)
		{
			throw new InvalidOperationException("This method is no longer supported.  Instead, use modelBuilder.Conventions.Add(new DecimalPrecisionAttributeConvention()) and other equivalents");
		}
	}
}