return from p in db.Products select new ProductDTO() 
    { Id = p.Id, Name = p.Name, Price = p.Price };