public class UsersController {
    public bool UserNameAvailable(string username) {
        if(MyRepository.UserNameExists(username)) {
            return "false";
        }
        return "true";
    }
}