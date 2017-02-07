makecert.exe -pe -ss My -sr CurrentUser -a sha1 -sky exchange -n "CN=name" 
     -eku 1.3.6.1.5.5.7.3.2 -sk SignedByCA -ic TempCA.cer -iv TempCA.pvk