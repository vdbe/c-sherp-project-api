# Steps to create tunnnel.json

1. Create the Tunnel named 'c-sherp-api' in the UI  
 1.1 Add a public hostname with Type `HTTP` and URL `api:5000`
2. Run `cloudflared tunnel token --cred-file tunnel.json c-sherp-api`


https://github.com/cloudflare/cloudflared/issues/645#issuecomment-1136486550
