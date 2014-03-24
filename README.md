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
    
This requires a single line to be added to your `OnModelCreating` method:

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Apply Configuration Attributes from Assembly including type "TestContext"
        modelBuilder.ApplyConfigurationAttributes(typeof(TestContext).Assembly);
    }
