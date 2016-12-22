private IEdmModel GetExplicitEdmModel()
{
  ODataModelBuilder builder = new ODataModelBuilder();

  EnumTypeConfiguration<Color> color = builder.EnumType<Color>();
  color.Member(Color.Red);
  color.Member(Color.Blue);
  color.Member(Color.Green);
  color.Member(Color.Yellow);

  ComplexTypeConfiguration<Point> point = builder.ComplexType<Point>();
  point.Property(c => c.X);
  point.Property(c => c.Y);

  ComplexTypeConfiguration<Shape> shape = builder.ComplexType<Shape>();
  shape.EnumProperty(c => c.Color);
  shape.Property(c => c.HasBorder);
  shape.Abstract();

  ComplexTypeConfiguration<Triangle> triangle = builder.ComplexType<Triangle>();
    triangle.ComplexProperty(c => c.P1);
    triangle.ComplexProperty(c => c.P2);
    triangle.ComplexProperty(c => c.P2);
    triangle.DerivesFrom<Shape>();

    ComplexTypeConfiguration<Rectangle> rectangle = builder.ComplexType<Rectangle>();
    rectangle.ComplexProperty(c => c.LeftTop);
    rectangle.Property(c => c.Height);
    rectangle.Property(c => c.Weight);
    rectangle.DerivesFrom<Shape>();

  ComplexTypeConfiguration<RoundRectangle> roundRectangle = builder.ComplexType<RoundRectangle>();
    roundRectangle.Property(c => c.Round);
    roundRectangle.DerivesFrom<Rectangle>();

    ComplexTypeConfiguration<Circle> circle = builder.ComplexType<Circle>();
    circle.ComplexProperty(c => c.Center);
    circle.Property(c => c.Radius);
    circle.DerivesFrom<Shape>();

    EntityTypeConfiguration<Window> window = builder.EntityType<Window>();
    window.HasKey(c => c.Id);
    window.Property(c => c.Title);
    window.ComplexProperty(c => c.Shape);

    builder.EntitySet<Window>("Windows");
    return builder.GetEdmModel();
}