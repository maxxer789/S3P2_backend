#!/bin/bash
if [ -z "$VPN_SERVER_CERT" ]
then
    echo $VPN_PASSWORD |openconnect -u $VPN_LOGIN $VPN_SERVER --passwd-on-stdin -b
else
    echo $VPN_PASSWORD |openconnect -u $VPN_LOGIN $VPN_SERVER --servercert $VPN_SERVER_CERT --passwd-on-stdin -b
fi

# Wait a little
sleep 5

# Print IP
curl http://api.ipify.org

# Run your regular commands
# ...