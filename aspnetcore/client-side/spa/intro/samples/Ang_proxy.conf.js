const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORTS ? `https://localhost:${env.ASPNETCORE_HTTPS_PORTS}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:51951';

const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
   ],
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  }
]

module.exports = PROXY_CONFIG;
