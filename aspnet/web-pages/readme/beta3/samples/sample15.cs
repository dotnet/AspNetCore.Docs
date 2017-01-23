SqlCeEngine engine = new SqlCeEngine("Data Source=Northwind.sdf");
engine.Compact("Data Source=Northwind.sdf;encryption mode=platform default;Password=<enterStrongPasswordHere>;");