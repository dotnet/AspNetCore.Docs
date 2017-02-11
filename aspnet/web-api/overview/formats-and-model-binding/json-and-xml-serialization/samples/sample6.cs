var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
json.SerializerSettings.DateFormatHandling 
= Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;