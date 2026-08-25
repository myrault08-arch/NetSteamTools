@echo off
setlocal

set "STEAMDIR=C:\Program Files (x86)\Steam"
set "BACKUPDIR=C:\NetSteamTools\Backup"
set "SOURCEDIR=C:\NetSteamTools\Installer"

echo ==========================================
echo NetSteamTools File Installer
echo ==========================================
echo.

if not exist "%BACKUPDIR%" mkdir "%BACKUPDIR%"

for %%F in (dwmapi.dll OpenSteamTool.dll xinput1_4.dll) do (
    if exist "%STEAMDIR%\%%F" (
        echo Backing up %%F...
        copy /Y "%STEAMDIR%\%%F" "%BACKUPDIR%\%%F" >nul
    ) else (
        echo %%F not found in Steam folder. Skipping backup.
    )
)

echo.
echo Backup complete.
echo.

for %%F in (dwmapi.dll OpenSteamTool.dll xinput1_4.dll) do (
    if exist "%SOURCEDIR%\%%F" (
        echo Installing %%F...
        copy /Y "%SOURCEDIR%\%%F" "%STEAMDIR%\%%F" >nul
    ) else (
        echo WARNING: %%F not found in current directory.
    )
)

echo.
echo Installation complete.