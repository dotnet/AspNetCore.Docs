Most configurations for apps and containers define only a port for listening, like port 80, without specifying other constraints like the host or path. HTTP_PORTS and HTTPS_PORTS are config keys that specify the listening ports for the Kestrel and HTTP.sys servers. You can specify the keys as environment variables defined with the `DOTNET_` or `ASPNETCORE_` prefixes, or set them directly through any other config input, such as the _appsettings.json_ file. Each configuration is a semicolon-delimited list of port values, as shown in the following example:

```json
ASPNETCORE_HTTP_PORTS=80;8080
ASPNETCORE_HTTPS_PORTS=443;8081
```

The configuration in the example is shorthand for the following specification, which defines the scheme (HTTP or HTTPS) and any host or IP:

```json
ASPNETCORE_URLS=http://*:80/;http://*:8080/;https://*:443/;https://*:8081/
```

The HTTP_PORTS and HTTPS_PORTS configuration keys are lower priority. If other URLs or values are set directly in code, they can override the configuration keys. You still need to configure certificates separately by using server-specific mechanics for HTTPS.
