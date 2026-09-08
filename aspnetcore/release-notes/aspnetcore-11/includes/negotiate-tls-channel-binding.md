### Negotiate authentication uses TLS channel binding

Negotiate authentication on Kestrel uses the TLS endpoint channel binding token for HTTPS connections. The authentication handler supplies the token to the underlying Kerberos or NTLM exchange and retains it across multi-round authentication.

No configuration changes are required. Non-HTTPS connections and HTTPS connections where a channel binding token isn't available continue to use the existing behavior.
