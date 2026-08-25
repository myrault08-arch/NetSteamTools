@echo off
setlocal

set "source=%USERPROFILE%\Downloads"
set "source_temp=C:\NetSteamTools\Temp"

set "target_lua=C:\NetSteamTools\lua files"

if not exist "%target_lua%" mkdir "%target_lua%"

echo Searching for .lua files in Downloads...
for /R "%source%" %%F in (*.lua) do (
    echo Moving: %%F
    move /Y "%%F" "%target_lua%\\" 
)

echo.
echo Searching for .lua files in Temp...
for /R "%source_temp%" %%F in (*.lua) do (
    echo Moving: %%F
    move /Y "%%F" "%target_lua%\\" 
)

echo.
echo Done moving files.