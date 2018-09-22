using System;
using System.Collections;
using System.Configuration;
using System.Diagnostics;
using System.Xml;

namespace MyConfigBuilders
{

    public class EnvironmentConfigBuilder : ConfigurationBuilder
    {
        private readonly IDictionary _EnvVars;

        public EnvironmentConfigBuilder()
        {
            _EnvVars = 
                Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process);
            if (_EnvVars.Count == 0) _EnvVars = Environment.GetEnvironmentVariables();

            Debug.WriteLine(_EnvVars.Count);
        }

        public override XmlNode ProcessRawXml(XmlNode rawXml)
        {
            foreach (DictionaryEntry envVar in _EnvVars)
            {
                var pair = (Key: envVar.Key.ToString(), Value: envVar.Value.ToString());

                if (rawXml.HasChildNodes
                    && rawXml.SelectSingleNode($"add[@key='{pair.Key}']") != null)
                {
                    rawXml.SelectSingleNode($"add[@key='{pair.Key}']")
                        .Attributes["value"].Value = pair.Value;
                }
            }
            return rawXml;
        }

        public override ConfigurationSection ProcessConfigurationSection(
            ConfigurationSection configSection)
        {
            return base.ProcessConfigurationSection(configSection);
        }
    }
}