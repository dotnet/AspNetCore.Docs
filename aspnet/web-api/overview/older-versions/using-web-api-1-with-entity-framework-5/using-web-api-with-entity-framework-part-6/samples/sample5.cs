var product = (from p in MapProducts() 
    where p.Id == 1
    select p).FirstOrDefault();