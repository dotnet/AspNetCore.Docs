// GET api/ApiPerson
/// <summary>
/// Documentation for 'GET' method
/// </summary>
/// <returns>Returns a list of people in the requested format</returns>
public IQueryable<Person> GetPeople()
{
    return db.People;
}