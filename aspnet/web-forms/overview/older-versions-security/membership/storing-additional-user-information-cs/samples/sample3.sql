UPDATE UserProfiles SET
     HomeTown = @HomeTown,
     HomepageUrl = @HomepageUrl,
     Signature = @Signature
WHERE UserId = @UserId