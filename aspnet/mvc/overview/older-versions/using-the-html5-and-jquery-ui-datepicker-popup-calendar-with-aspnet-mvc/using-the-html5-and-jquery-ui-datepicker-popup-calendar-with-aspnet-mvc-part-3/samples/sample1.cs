public class Address {
	public string StreetAddress { get; set; }
	public string City { get; set; }
	public string PostalCode { get; set; }
}

public class Person {
	public int ID { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Phone { get; set; }
	public Address HomeAddress;
}