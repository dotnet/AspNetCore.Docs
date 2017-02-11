Response.OutputCache(60);
Response.OutputCache(3600, true);
Response.OutputCache(10, varyByParams : new[] {"category","sortOrder"});