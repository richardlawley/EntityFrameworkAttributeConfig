using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RichardLawley.EF.AttributeConfig;

namespace AttributeConfigTest
{
	public class TestEntity
	{
		public int Id { get; set; }

		[DecimalPrecision(18,5)]
		public decimal PreciseNumber { get; set; }
		public decimal DefaultNumber { get; set; }

		[DecimalPrecision(5, 0)]
		public decimal ImpreciseNumber { get; set; }

		[Column(TypeName="datetime2")]
		[DateTimePrecision(6)]		// 7 is the default
		public DateTime PreciseDate { get; set; }

		[Column(TypeName = "datetime2")]
		[DateTimePrecision(0)]
		public DateTime ImpreciseDate { get; set; }


		[DateTimePrecision(6)]
		public DateTimeOffset PreciseDateTimeOffset { get; set; }

		[DateTimePrecision(0)]
		public DateTimeOffset ImpreciseTimeOffset { get; set; }
	}
}
