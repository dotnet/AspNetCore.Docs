.. _data-protection-extensibility-mics-apis:

Miscellaneous APIs
==================

.. include:: extensibility-thread-safety-included.rst

ISecret
-------

The ISecret interface represents a secret value, such as cryptographic key material. It contains the following API surface.

* Length : int
* Dispose() : void
* WriteSecretIntoBuffer(ArraySegment<byte> buffer) : void

The WriteSecretIntoBuffer method populates the supplied buffer with the raw secret value. The reason this API takes the buffer as a parameter rather than returning a byte[] directly is that this gives the caller the opportunity to pin the buffer object, limiting secret exposure to the managed garbage collector.

The Secret type is a concrete implementation of ISecret where the secret value is stored in in-process memory. On Windows platforms, the secret value is encrypted via `CryptProtectMemory <https://msdn.microsoft.com/en-us/library/windows/desktop/aa380262(v=vs.85).aspx>`_.
