public static class BirthdayCalculator
{
   public static int GetDaysBeforeBirthday(DateTime birthDate)
   {
      var today = DateTime.Now;
      var nextBirthday = new DateTime(today.Year, birthDate.Month, birthDate.Day);
      TimeSpan difference = nextBirthday - DateTime.Now;
      if (difference.Days < 0)
      {
         nextBirthday = new DateTime(today.Year + 1, birthDate.Month, birthDate.Day);
         difference = nextBirthday - DateTime.Now;
      }
      return difference.Days;
   }
}