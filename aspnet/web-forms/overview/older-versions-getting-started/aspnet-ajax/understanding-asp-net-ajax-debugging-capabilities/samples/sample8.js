function UpdatePerson(person)
{
 //Dump contents of the person object to the trace output
 Sys.Debug.traceDump(person,"Person Data");

 alert("Person updated! " + person.get_firstName() + " " + person.get_lastName());
}