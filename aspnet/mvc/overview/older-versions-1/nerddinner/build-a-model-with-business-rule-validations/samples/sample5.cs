DinnerRepository dinnerRepository = new DinnerRepository();

// Retrieve all upcoming Dinners
var upcomingDinners = dinnerRepository.FindUpcomingDinners();

// Loop over each upcoming Dinner and print out its Title
foreach (Dinner dinner in upcomingDinners) {
   Response.Write("Title" + dinner.Title);
}