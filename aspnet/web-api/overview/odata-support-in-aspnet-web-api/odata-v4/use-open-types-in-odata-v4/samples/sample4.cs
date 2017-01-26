ODataModelBuilder builder = new ODataModelBuilder();

ComplexTypeConfiguration<Press> pressType = builder.ComplexType<Press>();
pressType.Property(c => c.Name);
// ...
pressType.HasDynamicProperties(c => c.DynamicProperties);

EntityTypeConfiguration<Book> bookType = builder.EntityType<Book>();
bookType.HasKey(c => c.ISBN);
bookType.Property(c => c.Title);
// ...
bookType.ComplexProperty(c => c.Press);
bookType.HasDynamicProperties(c => c.Properties);

// ...
builder.EntitySet<Book>("Books");
IEdmModel model = builder.GetEdmModel();