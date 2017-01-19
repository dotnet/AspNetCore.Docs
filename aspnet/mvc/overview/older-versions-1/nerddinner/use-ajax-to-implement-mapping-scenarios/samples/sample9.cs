public IQueryable<Dinner> FindByLocation(float latitude, float longitude) {

   var dinners = from dinner in FindUpcomingDinners()
                 join i in db.NearestDinners(latitude, longitude)
                 on dinner.DinnerID equals i.DinnerID
                 select dinner;

   return dinners;
}