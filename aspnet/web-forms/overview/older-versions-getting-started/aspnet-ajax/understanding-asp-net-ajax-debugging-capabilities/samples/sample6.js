function BuildPerson()
{
 var address = new XmlForAsp.Address($get("txtStreet").value, $get("txtCity").value, $get("txtState").value, $get("txtZip").value);
 var person = new XmlForAsp.Person(null, $get("txtFirstName").value, $get("txtLastName").value, address);
 Sys.Debug.trace("Person's name: " + person.get_firstName() + " " + person.get_lastName());
 UpdatePerson(person);
}