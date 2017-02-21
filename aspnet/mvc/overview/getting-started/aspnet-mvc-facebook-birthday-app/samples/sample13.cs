public class MyAppUser
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    [JsonProperty("picture")] // This renames the property to picture.
    public FacebookConnection<FacebookPicture> ProfilePicture { get; set; }

    // This sets the size of the friend list to 8, remove it to get all friends.
    [FacebookFieldModifier("limit(8)")] 
    public FacebookGroupConnection<MyAppUserFriend> Friends { get; set; }

    // This sets the size of the photo list to 16, remove it to get all photos.
    [FacebookFieldModifier("limit(16)")] 
    public FacebookGroupConnection<FacebookPhoto> Photos { get; set; }
}