@echo off
cd %0\.. 
cd /d %0\..
C:\Windows\Microsoft.NET\Framework\v4.0.30319\RegAsm zxing.vfp.dll /unregister
C:\Windows\Microsoft.NET\Framework\v4.0.30319\RegAsm zxing.vfp.dll /register /codebase


pause

