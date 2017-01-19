// Disable any() and all() functions.
[Queryable(AllowedFunctions= AllowedFunctions.AllFunctions & 
    ~AllowedFunctions.All & ~AllowedFunctions.Any)]