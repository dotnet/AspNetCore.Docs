const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORTS ? `https://localhost:${env.ASPNETCORE_HTTPS_PORTS}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:26572';

const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
      "/_configuration",
      "/.well-known",
      "/Identity",
      "/connect",
      "/ApplyDatabaseMigrations",
      "/_framework"
   ],
    target: target,
    secure: false
  }
]

module.exports = PROXY_CONFIG;
