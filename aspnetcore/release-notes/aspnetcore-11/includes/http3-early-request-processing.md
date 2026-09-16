### HTTP/3 starts processing requests earlier

Kestrel now starts processing HTTP/3 requests without waiting for the control stream and SETTINGS frame first, which reduces first-request latency on new connections.
