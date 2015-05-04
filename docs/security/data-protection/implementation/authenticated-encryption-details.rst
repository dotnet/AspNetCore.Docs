.. _data-protection-implementation-authenticated-encryption-details:

Authenticated encryption details.
=================================

Calls to IDataProtector.Protect are authenticated encryption operations. The Protect method offers both confidentiality and authenticity, and it is tied to the purpose chain that was used to derive this particular IDataProtector instance from its root IDataProtectionProvider.

IDataProtector.Protect takes a byte[] plaintext parameter and produces a byte[] protected payload, whose format is described below. (There is also an extension method overload which takes a string plaintext parameter and returns a string protected payload. If this API is used the protected payload format will still have the below structure, but it will be `base64url-encoded <https://tools.ietf.org/html/rfc4648#section-5>`_.)

Protected payload format
------------------------

The protected payload format consists of three primary components:

* A 32-bit magic header that identifies the version of the data protection system.
* A 128-bit key id that identifies the key used to protect this particular payload.
* The remainder of the protected payload is :ref:`specific to the encryptor encapsulated by this key <data-protection-implementation-subkey-derivation>`. In the example below the key represents an AES-256-CBC + HMACSHA256 encryptor, and the payload is further subdivided as follows:
  * A 128-bit key modifier.
  * A 128-bit initialization vector.
  * 48 bytes of AES-256-CBC output.
  * An HMACSHA256 authentication tag.

A sample protected payload is illustrated below.

.. literalinclude:: authenticated-encryption-details/_static/protectedpayload.txt
        :linenos:

From the payload format above the first 32 bits, or 4 bytes are the magic header identifying the version (09 F0 C9 F0)

The next 128 bits, or 16 bytes is the key identifier (80 9C 81 0C 19 66 19 40 95 36 53 F8 AA FF EE 57)

The remainder contains the payload and is specific to the format used.

.. WARNING::
  All payloads protected to a given key will begin with the same 20-byte (magic value, key id) header. Administrators can use this fact for diagnostic purposes to approximate when a payload was generated. For example, the payload above corresponds to key {0c819c80-6619-4019-9536-53f8aaffee57}. If after checking the key repository you find that this specific key's activation date was 2015-01-01 and its expiration date was 2015-03-01, then it is reasonable to assume that the payload (if not tampered with) was generated within that window, give or take a small fudge factor on either side.
