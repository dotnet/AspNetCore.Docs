Person GetPerson(int id) {
	var p = new Person
	{
		ID = 1,
		FirstName = "Joe",
		LastName = "Smith",
		Phone = "123-456",
		HomeAddress = new Address
		{
			City = "Great Falls",
			StreetAddress = "1234 N 57th St",
			PostalCode = "95045"
		}
	};
	return p;
}