function UpdatePerson(person)
{
 //Check if address is null
 Sys.Debug.assert(person.get_address() == null,"Address is null!",true);

 alert("Person updated! " + person.get_firstName() + " " + person.get_lastName());
}