@echo off
set baseDirectory=%1
echo %baseDirectory%
REM "C:\Users\StupidBoy\source\repos\TF-Auto-Deploy\TF-Auto-Deploy\TF-Auto-Deploy\bin\Debug"
cd /d %baseDirectory%
powershell -noexit -executionpolicy bypass -File auto_build.ps1
