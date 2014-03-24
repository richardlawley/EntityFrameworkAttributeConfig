using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFAttributeConfig
{
	/// <summary>
	/// Extension methods to apply the configuration attributes
	/// </summary>
	public static class DbContextConfiguration
	{
		private readonly static Func<Type, bool> _defaultTypeFilter = t => true;

		/// <summary>
		/// Applies the configuration attributes for entities found in all of the specified assemblies
		/// </summary>
		/// <param name="modelBuilder">Model Builder</param>
		/// <param name="assemblies">Assemblies to search for entities</param>
		public static void ApplyConfigurationAttributes(this DbModelBuilder modelBuilder, params Assembly[] assemblies)
		{
			foreach (Assembly assembly in assemblies)
			{
				modelBuilder.ApplyConfigurationAttributes(assembly, _defaultTypeFilter);
			}
		}

		/// <summary>
		/// Applies the configuration attributes for entities found in the specified assembly matching the given type filter
		/// </summary>
		/// <param name="modelBuilder">Model Builder</param>
		/// <param name="assembly">Assembly to search for entities</param>
		/// <param name="typeFilter">Filter for types in the given assembly</param>
		public static void ApplyConfigurationAttributes(this DbModelBuilder modelBuilder, Assembly assembly, Func<Type, bool> typeFilter)
		{
			foreach (Type classType in assembly.GetTypes().Where(t => t.IsClass && typeFilter(t)))
			{
				var propertiesToConfigure = classType
					.GetProperties(BindingFlags.Public | BindingFlags.Instance)
					.Where(p => p.GetCustomAttribute<EFPropertyConfigurationAttribute>() != null)
					.Select(p => new { prop = p, attr = p.GetCustomAttribute<EFPropertyConfigurationAttribute>(true) });

				foreach (var propAttr in propertiesToConfigure)
				{
					var entityConfig = modelBuilder.GetType().GetMethod("Entity").MakeGenericMethod(classType).Invoke(modelBuilder, null);
					ParameterExpression param = ParameterExpression.Parameter(classType, "c");
					Expression property = Expression.Property(param, propAttr.prop.Name);
					LambdaExpression lambdaExpression = Expression.Lambda(property, true, new ParameterExpression[] { param });

					MethodInfo methodInfo = entityConfig.GetType().GetMethod("Property", new[] { lambdaExpression.GetType() });
					PrimitivePropertyConfiguration propertyConfig = methodInfo.Invoke(entityConfig, new[] { lambdaExpression }) 
						as PrimitivePropertyConfiguration;

					propAttr.attr.Configure(propertyConfig);
				}
			}
		}
	}
}
