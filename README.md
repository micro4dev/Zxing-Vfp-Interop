# Zxing-Vfp-Interop
Librería para ser usada desde Visual FoxPro para generar código qr para la representación impresa de los documentos según especificaciones SUNAT

# Registrar componente
Crear un archivo bat para registrar el emsamblado y ejecutar como administrador

# Contenido:

@echo off
cd %0\.. 
cd /d %0\..
C:\Windows\Microsoft.NET\Framework\v4.0.30319\RegAsm zxing.vfp.dll /unregister
C:\Windows\Microsoft.NET\Framework\v4.0.30319\RegAsm zxing.vfp.dll /register /codebase

pause


# Generar un codigo qr desde Visual FoxPro

SET STEP ON

LOCAL zxing
zxing = CREATEOBJECT("zxing.QrHelper")


LOCAL datosQr
datosQr = "20542754126|03|B001|00000016|1525.42|10000.00|2018-02-07|1|VISA SONCCO JESUS ANGEL|46795470|"

LOCAL imagenQr 
imagenQr  = zxing.GenerateQr(300,300,datosQr)

IF FILE(imagenQr)
	WAIT WINDOW FULLPATH(imagenQr)
ENDIF 

