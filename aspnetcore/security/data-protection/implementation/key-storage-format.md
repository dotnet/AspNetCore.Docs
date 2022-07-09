---
title: Key storage format in ASP.NET Core
author: rick-anderson
description: Learn implementation details of the ASP.NET Core Data Protection key storage format.
ms.author: riande
ms.date: 04/08/2020
uid: security/data-protection/implementation/key-storage-format
---
# Key storage format in ASP.NET Core

<a name="data-protection-implementation-key-storage-format"></a>

Objects are stored at rest in XML representation. The default directory for key storage is:

* Windows: *%LOCALAPPDATA%\ASP.NET\DataProtection-Keys\*
* macOS / Linux: *$HOME/.aspnet/DataProtection-Keys*

## The \<key> element

Keys exist as top-level objects in the key repository. By convention keys have the filename *`key-{guid}.xml`*, where {guid} is the id of the key. Each such file contains a single key. The format of the file is as follows.

```xml
<?xml version="1.0" encoding="utf-8"?>
<key id="80732141-ec8f-4b80-af9c-c4d2d1ff8901" version="1">
  <creationDate>2015-03-19T23:32:02.3949887Z</creationDate>
  <activationDate>2015-03-19T23:32:02.3839429Z</activationDate>
  <expirationDate>2015-06-17T23:32:02.3839429Z</expirationDate>
  <descriptor deserializerType="{deserializerType}">
    <descriptor>
      <encryption algorithm="AES_256_CBC" />
      <validation algorithm="HMACSHA256" />
      <enc:encryptedSecret decryptorType="{decryptorType}" xmlns:enc="...">
        <encryptedKey>
          <!-- This key is encrypted with Windows DPAPI. -->
          <value>AQAAANCM...8/zeP8lcwAg==</value>
        </encryptedKey>
      </enc:encryptedSecret>
    </descriptor>
  </descriptor>
</key>
```

The \<key> element contains the following attributes and child elements:

* The key id. This value is treated as authoritative; the filename is simply a nicety for human readability.

* The version of the \<key> element, currently fixed at 1.

* The key's creation, activation, and expiration dates.

* A \<descriptor> element, which contains information on the authenticated encryption implementation contained within this key.

In the above example, the key's id is {80732141-ec8f-4b80-af9c-c4d2d1ff8901}, it was created and activated on March 19, 2015, and it has a lifetime of 90 days. (Occasionally the activation date might be slightly before the creation date as in this example. This is due to a nit in how the APIs work and is harmless in practice.)

## The \<descriptor> element

The outer \<descriptor> element contains an attribute deserializerType, which is the assembly-qualified name of a type which implements IAuthenticatedEncryptorDescriptorDeserializer. This type is responsible for reading the inner \<descriptor> element and for parsing the information contained within.

The particular format of the \<descriptor> element depends on the authenticated encryptor implementation encapsulated by the key, and each deserializer type expects a slightly different format for this. In general, though, this element will contain algorithmic information (names, types, OIDs, or similar) and secret key material. In the above example, the descriptor specifies that this key wraps AES-256-CBC encryption + HMACSHA256 validation.

## The \<encryptedSecret> element

An **&lt;encryptedSecret&gt;** element which contains the encrypted form of the secret key material may be present if [encryption of secrets at rest is enabled](xref:security/data-protection/implementation/key-encryption-at-rest). The attribute `decryptorType` is the assembly-qualified name of a type which implements <xref:Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlDecryptor>. This type is responsible for reading the inner **&lt;encryptedKey&gt;** element and decrypting it to recover the original plaintext.

As with `<descriptor>`, the particular format of the `<encryptedSecret>` element depends on the at-rest encryption mechanism in use. In the above example, the master key is encrypted using Windows DPAPI per the comment.

## The \<revocation> element

Revocations exist as top-level objects in the key repository. By convention revocations have the filename *`revocation-{timestamp}.xml`* (for revoking all keys before a specific date) or *`revocation-{guid}.xml`* (for revoking a specific key). Each file contains a single \<revocation> element.

For revocations of individual keys, the file contents will be as below.

```xml
<?xml version="1.0" encoding="utf-8"?>
<revocation version="1">
  <revocationDate>2015-03-20T22:45:30.2616742Z</revocationDate>
  <key id="eb4fc299-8808-409d-8a34-23fc83d026c9" />
  <reason>human-readable reason</reason>
</revocation>
```

In this case, only the specified key is revoked. If the key id is "*", however, as in the below example, all keys whose creation date is prior to the specified revocation date are revoked.

```xml
<?xml version="1.0" encoding="utf-8"?>
<revocation version="1">
  <revocationDate>2015-03-20T15:45:45.7366491-07:00</revocationDate>
  <!-- All keys created before the revocation date are revoked. -->
  <key id="*" />
  <reason>human-readable reason</reason>
</revocation>
```

The \<reason> element is never read by the system. It's simply a convenient place to store a human-readable reason for revocation.
