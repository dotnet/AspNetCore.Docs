public override void Initialize(string name,
    System.Collections.Specialized.NameValueCollection config) {

    if (config["requiresQuestionAndAnswer"])
        _requiresQuestionAndAnswer = true;
    _connString = config["connectionString"];
    base.Initialize(name, config);
}