var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
json.SerializerSettings.PreserveReferencesHandling = 
    Newtonsoft.Json.PreserveReferencesHandling.All;