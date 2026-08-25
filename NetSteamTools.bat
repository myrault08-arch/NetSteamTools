@echo off
set "source_lua=C:\NetSteamTools\lua files"
set "destination_lua=C:\Program Files (x86)\Steam\config\lua"

echo Copying lua files from %source_lua% to %destination_lua%...
xcopy "%source_lua%\*.lua" "%destination_lua%\\" /s /i /y