Imports System.Diagnostics
Imports System.IO
Imports System.Threading.Tasks
Imports System.Net
Imports System.IO.Compression
Imports Newtonsoft.Json.Linq

Public Class frmStm
    Private Sub SetStep(stepNumber As Integer, message As String)

        prgBar.Value = stepNumber
        lblStatus.Text = "Step " & stepNumber & "/4 - " & message

        lblStatus.ForeColor = Color.LimeGreen

        prgBar.Refresh()
        lblStatus.Refresh()

    End Sub
    Private Async Sub btnSteamRes_Click(sender As Object, e As EventArgs) Handles btnSteamRes.Click

        btnSteamRes.Enabled = False
        TabControl1.SelectedTab = TabPage1

        Try

            AddLog("NetSteamTools launch started.")

            ' =========================
            ' SETUP UI
            ' =========================
            prgBar.Minimum = 0
            prgBar.Maximum = 4
            prgBar.Value = 0

            lblStatus.Visible = True
            lblStatus.ForeColor = Color.White

            ' =========================
            ' STEP 1
            ' =========================
            SetStep(1, "Preparing...")
            AddLog("Step 1: Preparing launch.")

            Await Task.Delay(1000)

            ' =========================
            ' STEP 2
            ' =========================
            SetStep(2, "Installing Steam files...")
            AddLog("Step 2: Running InstallSteamFiles.bat.")

            Await Task.Run(Sub()

                               Dim psi As New ProcessStartInfo()
                               psi.FileName = "C:\NetSteamTools\InstallSteamFiles.bat"
                               psi.UseShellExecute = False
                               psi.RedirectStandardOutput = True
                               psi.RedirectStandardError = True
                               psi.CreateNoWindow = True

                               Using proc = Process.Start(psi)

                                   Dim output = proc.StandardOutput.ReadToEnd()
                                   Dim errors = proc.StandardError.ReadToEnd()

                                   proc.WaitForExit()

                                   Me.Invoke(Sub()

                                                 AddLog("InstallSteamFiles exited with code: " & proc.ExitCode)

                                                 If Not String.IsNullOrWhiteSpace(output) Then
                                                     AddLog("OUTPUT: " & output.Trim())
                                                 End If

                                                 If Not String.IsNullOrWhiteSpace(errors) Then
                                                     AddLog("ERROR: " & errors.Trim())
                                                 End If

                                             End Sub)

                               End Using

                           End Sub)

            prgBar.Value = 2

            ' =========================
            ' STEP 3
            ' =========================
            SetStep(3, "Starting NetSteamTools...")
            AddLog("Step 3: Running NetSteamTools.bat.")

            Await Task.Run(Sub()

                               Dim psi As New ProcessStartInfo()
                               psi.FileName = "C:\NetSteamTools\NetSteamTools.bat"
                               psi.UseShellExecute = False
                               psi.RedirectStandardOutput = True
                               psi.RedirectStandardError = True
                               psi.CreateNoWindow = True

                               Using proc = Process.Start(psi)

                                   Dim output = proc.StandardOutput.ReadToEnd()
                                   Dim errors = proc.StandardError.ReadToEnd()

                                   proc.WaitForExit()

                                   Me.Invoke(Sub()

                                                 AddLog("NetSteamTools exited with code: " & proc.ExitCode)

                                                 If Not String.IsNullOrWhiteSpace(output) Then
                                                     AddLog("OUTPUT: " & output.Trim())
                                                 End If

                                                 If Not String.IsNullOrWhiteSpace(errors) Then
                                                     AddLog("ERROR: " & errors.Trim())
                                                 Else
                                                     AddLog("No errors from NetSteamTools.")
                                                 End If

                                             End Sub)

                               End Using

                           End Sub)

            prgBar.Value = 3

            ' =========================
            ' STEP 4
            ' =========================
            SetStep(4, "Complete!")
            AddLog("Process completed successfully.")

            prgBar.Value = 4

            Await Task.Delay(1000)

        Catch ex As Exception

            AddLog("EXCEPTION: " & ex.Message)

        Finally

            btnSteamRes.Enabled = True
            AddLog("Launch button re-enabled.")

        End Try

    End Sub


    Private Sub btnRun_Click(sender As Object, e As EventArgs)
        Dim NetSteamToolPath As String = "C:\NetSteamTools\NetSteamTools.bat" ' Update this path

        Dim psi As New ProcessStartInfo()
        psi.FileName = NetSteamToolPath
        psi.UseShellExecute = False
        psi.RedirectStandardOutput = True
        psi.RedirectStandardError = True
        psi.CreateNoWindow = True

        Try
            Dim process As Process = process.Start(psi)

            Dim output As String = process.StandardOutput.ReadToEnd()
            Dim errors As String = process.StandardError.ReadToEnd()

            process.WaitForExit()

            MessageBox.Show("Output:" & vbCrLf & output)

            If Not String.IsNullOrEmpty(errors) Then
                MessageBox.Show("Errors:" & vbCrLf & errors)
            End If

        Catch ex As Exception
            MessageBox.Show("Error running batch file:" & vbCrLf & ex.Message)
        End Try
    End Sub


    Private Sub btnMv_Click(sender As Object, e As EventArgs) Handles btnMv.Click
        TabControl1.SelectedTab = TabPage1
        Dim OrganizeFilePath As String = "C:\NetSteamTools\OrganizeFile.bat"

        AddLog("Launching batch file: " & OrganizeFilePath)

        Dim psi As New ProcessStartInfo()
        psi.FileName = OrganizeFilePath
        psi.UseShellExecute = False
        psi.RedirectStandardOutput = True
        psi.RedirectStandardError = True
        psi.CreateNoWindow = True

        Try
            Dim process As Process = Process.Start(psi)

            AddLog("Process started successfully.")

            Dim output As String = process.StandardOutput.ReadToEnd()
            Dim errors As String = process.StandardError.ReadToEnd()

            process.WaitForExit()

            AddLog("Process finished with exit code: " & process.ExitCode)

            ' Log output (optional, but useful)
            If Not String.IsNullOrWhiteSpace(output) Then
                AddLog("OUTPUT: " & output.Trim())
            End If

            ' Log errors
            If Not String.IsNullOrWhiteSpace(errors) Then
                AddLog("ERROR: " & errors.Trim())
                'MessageBox.Show("Errors occurred. Check log.")
            Else
                AddLog("No errors reported.")
            End If
            AddLog("Batch file executed successfully.")
            'MessageBox.Show("Batch file executed successfully.")

        Catch ex As Exception
            AddLog("EXCEPTION: " & ex.Message)
            MessageBox.Show("Error running batch file:" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        LoadluaFiles()
        TabControl1.SelectedTab = TabPage1

    End Sub

    Private Sub frmStm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim version As String = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()
        AddLog("NetSteamTools Version: " & version)
        AddLog("NetSteamTools is Activated")
        CreateBatchFiles()
        AddLog("Batch files have been created in C:\NetSteamTools\")

        ' ===== FORM STYLE =====
        Me.BackColor = Color.FromArgb(30, 30, 30)
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.StartPosition = FormStartPosition.CenterScreen

        ' ===== PROGRESS BAR STYLE =====
        prgBar.Style = ProgressBarStyle.Continuous

        ' ===== BUTTON STYLE =====
        StyleButton(btnSteamRes)
        StyleButton(btnLoad)
        StyleButton(btnMv)
        StyleButton(btnLink)
        StyleButton(btnChck)
        StyleButton(btnDownload)
        StyleButton(btnExtrct)
        StyleButton(btnCopyID)
        StyleButton(btnSearch)
        StyleButton(btnSSU)

        lvGames.Columns.Add("Game Name", 250)
        lvGames.Columns.Add("AppID", 100)
        Me.AcceptButton = btnSearch


    End Sub
    Private Sub StyleButton(btn As Button)

        btn.BackColor = Color.FromArgb(45, 45, 48)
        btn.ForeColor = Color.White
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 70, 70)

    End Sub

    Private Sub frmStm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()

    End Sub

    Private Sub LoadluaFiles()

        lstFiles.Items.Clear()

        ' =========================
        ' 1. LUA FILES
        ' =========================
        Dim luaPath As String = "C:\Program Files (x86)\Steam\config\lua"

        If IO.Directory.Exists(luaPath) Then

            AddLog("Scanning stplug-in for .lua files...")

            Dim luaFiles As String() = IO.Directory.GetFiles(luaPath, "*.lua")

            For Each file As String In luaFiles

                Dim item As New ListViewItem(IO.Path.GetFileName(file))
                item.ImageKey = "file"

                lstFiles.Items.Add(item)

            Next

            AddLog(luaFiles.Length.ToString() & " lua file(s) found.")

        Else
            AddLog("Lua folder not found: " & luaPath)
        End If

    End Sub
    Private Sub AddLog(message As String)

        If rtbLog.InvokeRequired Then
            rtbLog.Invoke(New Action(Of String)(AddressOf AddLog), message)
            Return
        End If

        Dim logLine As String =
            "[" & DateTime.Now.ToString("HH:mm:ss") & "] " & message

        rtbLog.AppendText(logLine & vbCrLf)
        rtbLog.SelectionStart = rtbLog.TextLength
        rtbLog.ScrollToCaret()

    End Sub

    Private Sub btnLink_Click(sender As Object, e As EventArgs) Handles btnLink.Click
        AddLog("Opening links using default browser... ")
        Process.Start("https://steamdb.info/")
        AddLog("Opening: https://steamdb.info/ ")

        Process.Start("https://ahd-manifest.lovable.app/")
        AddLog("Opening: https://ahd-manifest.lovable.app/")

        Process.Start("https://ssmg4.github.io/ManifestHubDownloader/")
        AddLog("Opening: https://ssmg4.github.io/ManifestHubDownloader/")

        Task.Delay(1500).ContinueWith(Sub()
                                          Me.Invoke(Sub()
                                                        Me.WindowState = FormWindowState.Normal
                                                        Me.Activate()
                                                    End Sub)
                                      End Sub)
    End Sub

    Private Sub btnChck_Click(sender As Object, e As EventArgs) Handles btnChck.Click

        Dim appId As String = txtAppid.Text.Trim()

        If String.IsNullOrEmpty(appId) Then
            MessageBox.Show("Please enter an App ID.", "App ID Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAppid.Focus()
            Exit Sub
        End If

        ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)

        Try
            Dim url As String =
                "https://api.github.com/repos/SSMGAlt/ManifestHub2/branches/" & appId

            Dim req = CType(WebRequest.Create(url), HttpWebRequest)
            req.UserAgent = "ManifestDownloader"

            AddLogDL("Checking: " & url)
            AddLog("Checking: " & url)

            Using resp = req.GetResponse()
                AddLogDL("manifest/lua Found!")
                AddLog("manifest/lua Found!")
            End Using

        Catch ex As WebException
            AddLogDL("manifest/lua not Found")
            AddLog("manifest/lua not Found")
        End Try

    End Sub

    Private Sub AddLogDL(message As String)

        If rtbDL.InvokeRequired Then
            rtbDL.Invoke(New Action(Of String)(AddressOf AddLogDL), message)
            Return
        End If

        Dim logLine As String =
            "[" & DateTime.Now.ToString("HH:mm:ss") & "] " & message

        rtbDL.AppendText(logLine & vbCrLf)
        rtbDL.SelectionStart = rtbDL.TextLength
        rtbDL.ScrollToCaret()

    End Sub

    Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click

        Dim appId As String = txtAppid.Text.Trim()

        If String.IsNullOrEmpty(appId) Then
            MessageBox.Show("Please enter an App ID.", "App ID Required",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAppid.Focus()
            Exit Sub
        End If

        ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)

        Dim url As String =
            "https://codeload.github.com/SSMGAlt/ManifestHub2/zip/refs/heads/" & appId

        Dim savePath As String =
            "C:\NetSteamTools\" & appId & ".zip"

        Try
            AddLogDL("Starting download: " & url)

            Using wc As New WebClient()
                wc.Headers.Add("User-Agent", "Mozilla/5.0")
                wc.DownloadFile(url, savePath)
            End Using

            AddLogDL("Download successful: " & savePath)
            AddLog("Download successful: " & savePath)

            MessageBox.Show("Download Complete!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As WebException

            Dim response As HttpWebResponse = TryCast(ex.Response, HttpWebResponse)

            If response IsNot Nothing AndAlso response.StatusCode = HttpStatusCode.NotFound Then

                AddLogDL("404 Error - File not found: " & url)
                AddLog("404 Error - File not found")

                MessageBox.Show("File not found (404)." & vbCrLf &
                                "Invalid AppID or branch name.",
                                "Download Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)

            Else

                AddLogDL("Download error: " & ex.Message)
                AddLog("Download error: " & ex.Message)

                MessageBox.Show("Download failed: " & ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)

            End If

        Catch ex As Exception

            AddLogDL("Unexpected error: " & ex.Message)
            AddLog("Unexpected error: " & ex.Message)

            MessageBox.Show("Unexpected error: " & ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnExtrct_Click(sender As Object, e As EventArgs) Handles btnExtrct.Click

        Dim appId As String = txtAppid.Text.Trim()

        If String.IsNullOrEmpty(appId) Then
            MessageBox.Show("Please enter an App ID.", "App ID Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim zipPath As String = "C:\NetSteamTools\" & appId & ".zip"
        Dim extractPath As String = "C:\NetSteamTools\Temp\" & appId

        ' Check if ZIP exists
        If Not File.Exists(zipPath) Then
            MessageBox.Show("No downloaded ZIP file found.")
            AddLogDL("ZIP file not found: " & zipPath)
            Exit Sub
        End If

        ' Delete old extraction folder
        If Directory.Exists(extractPath) Then
            Directory.Delete(extractPath, True)
        End If

        Try

            ' Check if ZIP contains files
            Using archive As ZipArchive = ZipFile.OpenRead(zipPath)

                If archive.Entries.Count = 0 Then
                    MessageBox.Show("ZIP file is empty.")
                    AddLogDL("ZIP file contains no files.")
                    Exit Sub
                End If

            End Using

            ZipFile.ExtractToDirectory(zipPath, extractPath)
            AddLog("Extracting...")
            AddLogDL("Extracting...")
            AddLog("Files Extracted in:" & extractPath)
            AddLogDL("Files Extracted in:" & extractPath)

            AddLog("Extraction Complete")
            AddLogDL("Extraction Complete")

            Dim files() As String = Directory.GetFiles(extractPath, "*.*", SearchOption.AllDirectories)

            If files.Length = 0 Then
                AddLogDL("No files were extracted.")
                AddLog("No files were extracted.")
                Exit Sub
            End If

            For Each file As String In files
                AddLogDL("Extracted: " & Path.GetFileName(file))
                AddLog("Extracted: " & Path.GetFileName(file))
            Next

        Catch ex As Exception
            MessageBox.Show("Extraction failed: " & ex.Message)
            AddLogDL("Extraction failed: " & ex.Message)
        End Try

    End Sub

    Private Sub CreateBatchFiles()

        Dim baseFolder As String = "C:\NetSteamTools"

        prgBar.Minimum = 0
        prgBar.Maximum = 100
        prgBar.Value = 0

        AddLog("Checking batch files...")

        If Not Directory.Exists(baseFolder) Then
            Directory.CreateDirectory(baseFolder)
            AddLog("Created folder: " & baseFolder)
        End If

        prgBar.Value = 10
        Application.DoEvents()

        ' ==========================
        ' 1. OrganizeFile.bat
        ' ==========================
        Dim importBat As String =
            "@echo off" & vbCrLf &
            "setlocal" & vbCrLf &
            vbCrLf &
            "set ""source=%USERPROFILE%\Downloads""" & vbCrLf &
            "set ""source_temp=C:\NetSteamTools\Temp""" & vbCrLf &
            vbCrLf &
            "set ""target_lua=C:\NetSteamTools\lua files""" & vbCrLf &
            vbCrLf &
            "if not exist ""%target_lua%"" mkdir ""%target_lua%""" & vbCrLf &
            vbCrLf &
            "echo Searching for .lua files in Downloads..." & vbCrLf &
            "for /R ""%source%"" %%F in (*.lua) do (" & vbCrLf &
            "    echo Moving: %%F" & vbCrLf &
            "    move /Y ""%%F"" ""%target_lua%\\"" " & vbCrLf &
            ")" & vbCrLf &
            vbCrLf &
            "echo." & vbCrLf &
            "echo Searching for .lua files in Temp..." & vbCrLf &
            "for /R ""%source_temp%"" %%F in (*.lua) do (" & vbCrLf &
            "    echo Moving: %%F" & vbCrLf &
            "    move /Y ""%%F"" ""%target_lua%\\"" " & vbCrLf &
            ")" & vbCrLf &
            vbCrLf &
            "echo." & vbCrLf &
            "echo Done moving files."

        Dim organizePath As String = Path.Combine(baseFolder, "OrganizeFile.bat")

        If Not File.Exists(organizePath) Then
            File.WriteAllText(organizePath, importBat)
            AddLog("Created OrganizeFile.bat")
        Else
            AddLog("OrganizeFile.bat already exists. Skipped.")
        End If

        prgBar.Value = 40
        Application.DoEvents()

        ' ==========================
        ' 2. NetSteamTools.bat
        ' ==========================
        Dim copyBat As String =
        "@echo off" & vbCrLf &
        "set ""source_lua=C:\NetSteamTools\lua files""" & vbCrLf &
        "set ""destination_lua=C:\Program Files (x86)\Steam\config\lua""" & vbCrLf &
        vbCrLf &
        "echo Copying lua files from %source_lua% to %destination_lua%..." & vbCrLf &
        "xcopy ""%source_lua%\*.lua"" ""%destination_lua%\\"" /s /i /y"

        Dim copyPath As String = Path.Combine(baseFolder, "NetSteamTools.bat")

        If Not File.Exists(copyPath) Then
            File.WriteAllText(copyPath, copyBat)
            AddLog("Created NetSteamTools.bat")
        Else
            AddLog("NetSteamTools.bat already exists. Skipped.")
        End If

        prgBar.Value = 70
        Application.DoEvents()
        ' ==========================
        ' 3. InstallSteamFiles.bat
        ' ==========================
        Dim installBat As String =
            "@echo off" & vbCrLf &
            "setlocal" & vbCrLf &
            vbCrLf &
            "set ""STEAMDIR=C:\Program Files (x86)\Steam""" & vbCrLf &
            "set ""BACKUPDIR=C:\NetSteamTools\Backup""" & vbCrLf &
            "set ""SOURCEDIR=C:\NetSteamTools\Installer""" & vbCrLf &
            vbCrLf &
            "echo ==========================================" & vbCrLf &
            "echo NetSteamTools File Installer" & vbCrLf &
            "echo ==========================================" & vbCrLf &
            "echo." & vbCrLf &
            vbCrLf &
            "if not exist ""%BACKUPDIR%"" mkdir ""%BACKUPDIR%""" & vbCrLf &
            vbCrLf &
            "for %%F in (dwmapi.dll OpenSteamTool.dll xinput1_4.dll) do (" & vbCrLf &
            "    if exist ""%STEAMDIR%\%%F"" (" & vbCrLf &
            "        echo Backing up %%F..." & vbCrLf &
            "        copy /Y ""%STEAMDIR%\%%F"" ""%BACKUPDIR%\%%F"" >nul" & vbCrLf &
            "    ) else (" & vbCrLf &
            "        echo %%F not found in Steam folder. Skipping backup." & vbCrLf &
            "    )" & vbCrLf &
            ")" & vbCrLf &
            vbCrLf &
            "echo." & vbCrLf &
            "echo Backup complete." & vbCrLf &
            "echo." & vbCrLf &
            vbCrLf &
            "for %%F in (dwmapi.dll OpenSteamTool.dll xinput1_4.dll) do (" & vbCrLf &
            "    if exist ""%SOURCEDIR%\%%F"" (" & vbCrLf &
            "        echo Installing %%F..." & vbCrLf &
            "        copy /Y ""%SOURCEDIR%\%%F"" ""%STEAMDIR%\%%F"" >nul" & vbCrLf &
            "    ) else (" & vbCrLf &
            "        echo WARNING: %%F not found in current directory." & vbCrLf &
            "    )" & vbCrLf &
            ")" & vbCrLf &
            vbCrLf &
            "echo." & vbCrLf &
            "echo Installation complete."

        Dim installPath As String = Path.Combine(baseFolder, "InstallSteamFiles.bat")

        If Not File.Exists(installPath) Then
            File.WriteAllText(installPath, installBat)
            AddLog("Created InstallSteamFiles.bat")
        Else
            AddLog("InstallSteamFiles.bat already exists. Skipped.")
        End If
        prgBar.Value = 90
        Application.DoEvents()
        ' ==========================
        ' 4. SSU.bat
        ' ==========================
        Dim InstallSSU As String =
            "@echo off" & vbCrLf &
        "setlocal" & vbCrLf &
        vbCrLf &
        ":: ---- CONFIGURE THESE ----" & vbCrLf &
        "set ""USERNAME=myrault08""" & vbCrLf &
        "set ""STEAMPATH=C:\Program Files (x86)\Steam\steam.exe""" & vbCrLf &
        ":: --------------------------" & vbCrLf &
        vbCrLf &
        "echo Closing Steam..." & vbCrLf &
        vbCrLf &
        ":: Ask Steam to shut down gracefully" & vbCrLf &
        "start """" ""%STEAMPATH%"" -shutdown" & vbCrLf &
        vbCrLf &
        ":: Wait up to 15 seconds for Steam to close" & vbCrLf &
        "set /a waited=0" & vbCrLf &
        vbCrLf &
        ":waitloop" & vbCrLf &
        "tasklist /FI ""IMAGENAME eq steam.exe"" | find /I ""steam.exe"" >nul" & vbCrLf &
        "if errorlevel 1 goto closed" & vbCrLf &
        vbCrLf &
        "if %waited% GEQ 15 goto forcekill" & vbCrLf &
        vbCrLf &
        "timeout /t 1 /nobreak >nul" & vbCrLf &
        "set /a waited+=1" & vbCrLf &
        "goto waitloop" & vbCrLf &
        vbCrLf &
        ":forcekill" & vbCrLf &
        "echo Steam did not close in time. Forcing shutdown..." & vbCrLf &
        "taskkill /F /IM steam.exe >nul 2>&1" & vbCrLf &
        vbCrLf &
        ":closed" & vbCrLf &
        "timeout /t 2 /nobreak >nul" & vbCrLf &
        vbCrLf &
        "echo Launching Steam as %USERNAME%..." & vbCrLf &
        "start """" ""%STEAMPATH%"" -login %USERNAME%" & vbCrLf &
        vbCrLf &
        "endlocal" & vbCrLf &
        "exit"

        Dim SSUInstall As String = Path.Combine(baseFolder, "SSU.bat")

        If Not File.Exists(SSUInstall) Then
            File.WriteAllText(SSUInstall, InstallSSU)
            AddLog("Created SSU.bat")
        Else
            AddLog("SSU.bat already exists. Skipped.")
        End If

        prgBar.Value = 100
        AddLog("Batch file check completed.")
        Application.DoEvents()

    End Sub


    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        Try
            lblSttus.Text = "Searching Steam..."
            AddLog("Searching Steam...")

            lvGames.Items.Clear()

            Dim searchTerm As String = txtSearch.Text.Trim()

            If searchTerm = "" Then
                MessageBox.Show("Enter a game name.", "Search for Game",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblSttus.Text = "Ready"
                Exit Sub
            End If

            AddLog("Searching for game: " & searchTerm)

            Dim url As String =
                "https://store.steampowered.com/api/storesearch/?term=" &
                Uri.EscapeDataString(searchTerm) &
                "&l=english&cc=US"

            ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)

            Using wc As New WebClient()

                wc.Headers.Add("User-Agent", "Mozilla/5.0")

                Dim json As String = wc.DownloadString(url)

                ' ----- validate response -----
                If String.IsNullOrWhiteSpace(json) Then
                    lblSttus.Text = "Empty response from Steam."
                    AddLog("Empty response from Steam.")
                    Exit Sub
                End If

                Dim root As JObject = Nothing

                Try
                    root = JObject.Parse(json)
                Catch ex As Exception
                    lblSttus.Text = "Invalid Steam response."
                    AddLog("JSON parse error: " & ex.Message)
                    Exit Sub
                End Try

                ' ----- check items -----
                If root("items") Is Nothing OrElse root("items").Count = 0 Then
                    lblSttus.Text = "No results found."
                    AddLog("No results found for: " & searchTerm)
                    Exit Sub
                End If

                ' ----- populate list -----
                For Each item As JObject In root("items")

                    Dim gameName As String = item("name").ToString()
                    Dim appid1 As String = item("id").ToString()

                    Dim lvItem As New ListViewItem(gameName)
                    lvItem.SubItems.Add(appid1)

                    lvGames.Items.Add(lvItem)

                Next

            End Using

            lblSttus.Text = "Found " & lvGames.Items.Count & " games."
            AddLog("Found " & lvGames.Items.Count & " games.")

        Catch ex As WebException

            lblSttus.Text = "Network error."
            AddLog("WebException: " & ex.Message)

            MessageBox.Show("Network error while searching Steam." & vbCrLf &
                            ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)

        Catch ex As Exception

            lblSttus.Text = "Search failed."
            AddLog("Search failed: " & ex.Message)

            MessageBox.Show("Search failed: " & ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub lvGames_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvGames.SelectedIndexChanged

        If lvGames.SelectedItems.Count = 0 Then Exit Sub

        Dim appid As String = lvGames.SelectedItems(0).SubItems(1).Text

        txtIDApp.Text = appid
        AddLog(appid & " is selected!")

        Try
            picGame.Load(
                "https://cdn.cloudflare.steamstatic.com/steam/apps/" &
                appid &
                "/header.jpg")
        Catch ex As Exception
            picGame.Image = Nothing
        End Try
    End Sub

    Private Sub btnCopyID_Click(sender As Object, e As EventArgs) Handles btnCopyID.Click
        If txtIDApp.Text <> "" Then

            Clipboard.SetText(txtIDApp.Text)
            txtAppid.Text = txtIDApp.Text

            MessageBox.Show("AppID copied.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information
                            )
            AddLog("AppID copied:" & txtIDApp.Text)
        Else
            txtIDApp.Text = ""
            MessageBox.Show("No selected AppID.", "No AppID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation
                            )
            AddLog("No selected AppID")
        End If

    End Sub

    Private Sub txtAppid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAppid.KeyPress

        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub
    Private Sub btnSSU_Click(sender As Object, e As EventArgs) Handles btnSSU.Click
        Dim SSU As String = "C:\NetSteamTools\SSU.bat"

        If Not IO.File.Exists(SSU) Then
            MessageBox.Show("Batch file not found.")
            Exit Sub
        End If

        Dim psi As New ProcessStartInfo()
        psi.FileName = SSU
        psi.UseShellExecute = False
        psi.CreateNoWindow = True
        psi.WindowStyle = ProcessWindowStyle.Hidden
        psi.RedirectStandardOutput = True
        psi.RedirectStandardError = True

        Dim proc As New Process()
        proc.StartInfo = psi

        AddHandler proc.OutputDataReceived,
            Sub(s, ev)
            If Not String.IsNullOrWhiteSpace(ev.Data) Then
                Me.Invoke(Sub()
                              AddLog(ev.Data)
                          End Sub)
            End If
        End Sub

        AddHandler proc.ErrorDataReceived,
            Sub(s, ev)
            If Not String.IsNullOrWhiteSpace(ev.Data) Then
                Me.Invoke(Sub()
                              AddLog("ERROR: " & ev.Data)
                          End Sub)
            End If
        End Sub

        AddHandler proc.Exited,
            Sub(s, ev)
                Me.Invoke(Sub()
                              AddLog("Switch steam user executed successfully.")
                          End Sub)
            End Sub

        proc.EnableRaisingEvents = True

        proc.Start()
        proc.BeginOutputReadLine()
        proc.BeginErrorReadLine()
    End Sub
End Class
