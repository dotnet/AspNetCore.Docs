var xml = GlobalConfiguration.Configuration.Formatters.XmlFormatter;
var dcs = new DataContractSerializer(typeof(Department), null, int.MaxValue, 
    false, /* preserveObjectReferences: */ true, null);
xml.SetSerializer<Department>(dcs);