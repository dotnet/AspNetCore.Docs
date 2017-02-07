public class DinnerFormViewModel {

    // Properties
    public Dinner     Dinner    { get; private set; }
    public SelectList Countries { get; private set; }

    // Constructor
    public DinnerFormViewModel(Dinner dinner) {
        Dinner = dinner;
        Countries = new SelectList(PhoneValidator.AllCountries, dinner.Country);
    }
}