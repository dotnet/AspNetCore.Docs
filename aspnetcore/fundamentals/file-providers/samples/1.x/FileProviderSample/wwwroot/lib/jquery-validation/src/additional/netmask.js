$.validator.addMethod( "netmask", function( value, element ) {
    return this.optional( element ) || /^(254|252|248|240|224|192|128)\.0\.0\.0|255\.(254|252|248|240|224|192|128|0)\.0\.0|255\.255\.(254|252|248|240|224|192|128|0)\.0|255\.255\.255\.(254|252|248|240|224|192|128|0)/i.test( value );
}, "Please enter a valid netmask." );
