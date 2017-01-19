public int Insert(TUser user)
{
    string commandText = @"Insert into Users (UserName, Id, PasswordHash, SecurityStamp,Email,EmailConfirmed,PhoneNumber,PhoneNumberConfirmed, AccessFailedCount,LockoutEnabled,LockoutEndDateUtc,TwoFactorEnabled)
        values (@name, @id, @pwdHash, @SecStamp,@email,@emailconfirmed,@phonenumber,@phonenumberconfirmed,@accesscount,@lockoutenabled,@lockoutenddate,@twofactorenabled)";
    Dictionary<string, object> parameters = new Dictionary<string, object>();
    parameters.Add("@name", user.UserName);
    parameters.Add("@id", user.Id);
    parameters.Add("@pwdHash", user.PasswordHash);
    parameters.Add("@SecStamp", user.SecurityStamp);
    parameters.Add("@email", user.Email);
    parameters.Add("@emailconfirmed", user.EmailConfirmed);
    parameters.Add("@phonenumber", user.PhoneNumber);
    parameters.Add("@phonenumberconfirmed", user.PhoneNumberConfirmed);
    parameters.Add("@accesscount", user.AccessFailedCount);
    parameters.Add("@lockoutenabled", user.LockoutEnabled);
    parameters.Add("@lockoutenddate", user.LockoutEndDateUtc);
    parameters.Add("@twofactorenabled", user.TwoFactorEnabled);

    return _database.Execute(commandText, parameters);
}