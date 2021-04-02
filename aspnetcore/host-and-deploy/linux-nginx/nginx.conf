http {
    include        /etc/nginx/proxy.conf;
    limit_req_zone $binary_remote_addr zone=one:10m rate=5r/s;
    server_tokens  off;

    sendfile on;
    # Adjust keepalive_timeout to the lowest possible value that makes sense 
    # for your use case.
    keepalive_timeout   29;
    client_body_timeout 10; client_header_timeout 10; send_timeout 10;

    upstream helloapp{
        server 127.0.0.1:5000;
    }

    server {
        listen                    443 ssl http2;
        listen                    [::]:443 ssl http2;
        server_name               example.com *.example.com;
        ssl_certificate           /etc/ssl/certs/testCert.crt;
        ssl_certificate_key       /etc/ssl/certs/testCert.key;
        ssl_session_timeout       1d;
        ssl_protocols             TLSv1.2 TLSv1.3;
        ssl_prefer_server_ciphers off;
        ssl_ciphers               ECDHE-ECDSA-AES128-GCM-SHA256:ECDHE-RSA-AES128-GCM-SHA256:ECDHE-ECDSA-AES256-GCM-SHA384:ECDHE-RSA-AES256-GCM-SHA384:ECDHE-ECDSA-CHACHA20-POLY1305:ECDHE-RSA-CHACHA20-POLY1305:DHE-RSA-AES128-GCM-SHA256:DHE-RSA-AES256-GCM-SHA384;
        ssl_session_cache         shared:SSL:10m;
        ssl_session_tickets       off;
        ssl_stapling              off;

        add_header X-Frame-Options DENY;
        add_header X-Content-Type-Options nosniff;

        #Redirects all traffic
        location / {
            proxy_pass http://helloapp;
            limit_req  zone=one burst=10 nodelay;
        }
    }
}
