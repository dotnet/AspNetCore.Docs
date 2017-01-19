function doToggle() 
{
 var cpe = $find("cpe");
 //cpe._toggle();
 if (cpe.get_Collapsed()) {
 cpe._doOpen();
 } else {
 cpe._doClose();
 }
}