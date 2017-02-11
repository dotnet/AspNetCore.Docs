public class DinnerRepository {
 
    private NerdDinnerDataContext db = new NerdDinnerDataContext();

    //
    // Query Methods

    public IQueryable<Dinner> FindAllDinners() {
        return db.Dinners;
    }

    public IQueryable<Dinner> FindUpcomingDinners() {
        return from dinner in db.Dinners
               where dinner.EventDate > DateTime.Now
               orderby dinner.EventDate
               select dinner;
    }

    public Dinner GetDinner(int id) {
        return db.Dinners.SingleOrDefault(d => d.DinnerID == id);
    }

    //
    // Insert/Delete Methods

    public void Add(Dinner dinner) {
        db.Dinners.InsertOnSubmit(dinner);
    }

    public void Delete(Dinner dinner) {
        db.RSVPs.DeleteAllOnSubmit(dinner.RSVPs);
        db.Dinners.DeleteOnSubmit(dinner);
    }

    //
    // Persistence 

    public void Save() {
        db.SubmitChanges();
    }
}