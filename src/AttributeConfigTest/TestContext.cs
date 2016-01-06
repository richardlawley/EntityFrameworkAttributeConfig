using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RichardLawley.EF.AttributeConfig;

namespace AttributeConfigTest
{
	public class TestContext : DbContext
	{
		public DbSet<TestEntity> TestEntities { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Conventions.Add(new DateTimePrecisionAttributeConvention());
			modelBuilder.Conventions.Add(new DecimalPrecisionAttributeConvention());
		}
	}
}
