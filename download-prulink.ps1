$source = "http://www.prudential.co.id/pru_CMS/unitlink?lang=in"
$destination = "D:\app\bot\result\prulink.txt"

Invoke-WebRequest $source -OutFile $destination