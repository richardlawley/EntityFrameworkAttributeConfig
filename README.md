Entity Framework Attribute Config
=================================

Allows you to configure properties by placing attributes on the properties of the Entity, rather than using the fluent configuration method.  For example...

    public class MyEntity 
    {
        [DateTimePrecision(0)]    // Column will be created as datetime(0)
        public DateTime ShortDate { get; set; }
        
        [DecimalPrecision(18, 5)] // Column will be created as decimal(18,5)
        public decimal PreciseNumber { get; set; }
    }
    
Install from nuget:

    PM> Install-Package EFAttributeConfig


For each type of precision attribute you wish to use, add a line to your `OnModelCreating` method:

    public class TestContext : DbContext 
    {
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		    base.OnModelCreating(modelBuilder);
		    
            // Add conventions for Precision Attributes
		    modelBuilder.Conventions.Add(new DecimalPrecisionAttributeConvention());
            modelBuilder.Conventions.Add(new DateTimePrecisionAttributeConvention());
		}
    }

The following attributes have been implemented so far:

* `DecimalPrecisionAttribute` - change the precision of a decimal
* `DateTimePrecisionAttribute` - change the precision of a datetime2 or datetimeoffset type

Adding further attributes is simple - take a look at the implementation of the existing attributes for an example!

This project is an extension of [this StackOverflow answer](http://stackoverflow.com/a/15386883/163495).  Thanks to @richi2666 for the suggestion of using conventions instead of Reflection.
