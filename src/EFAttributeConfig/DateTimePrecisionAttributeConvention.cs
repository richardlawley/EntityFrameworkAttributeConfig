using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichardLawley.EF.AttributeConfig
{
	public class DateTimePrecisionAttributeConvention : PrimitivePropertyAttributeConfigurationConvention<DateTimePrecisionAttribute>
	{
		public override void Apply(ConventionPrimitivePropertyConfiguration configuration, DateTimePrecisionAttribute attribute)
		{
			configuration.HasPrecision(attribute.Value);
		}
	}
}
