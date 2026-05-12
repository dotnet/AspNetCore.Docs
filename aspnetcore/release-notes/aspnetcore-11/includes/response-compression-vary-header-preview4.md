### Response compression always emits `Vary: Accept-Encoding`

The response-compression middleware now adds `Vary: Accept-Encoding` to every response when compression is enabled, even when the response itself isn't compressed. This prevents shared caches and CDNs from serving a compressed payload to a client that didn't ask for one (or vice versa).

Thank you [@pedrobsaila](https://github.com/pedrobsaila) for this contribution!
