Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Management
Imports Newtonsoft.Json.Linq
Public Class frmWelcome

Private Sub btnActivate_Click(sender As Object, e As EventArgs) Handles btnActivate.Click

        If String.IsNullOrWhiteSpace(txtKey.Text) Then
            MessageBox.Show("Please enter a license key.", "License Key", MessageBoxButtons.OK,MessageBoxIcon.Exclamation
                            )
            Exit Sub
        End If
        btnActivate.Enabled = False

        prgActivation.Visible = True

        Try

            SetStatus("Contacting activation server...")

            Dim key As String = txtKey.Text.Trim()

            Dim hwid As String = GetHWID()

            Dim success As Boolean = ValidateAndActivate(key, hwid)

            If success Then
                frmStm.Show()
                SaveLicense(txtKey.Text.Trim())

                Me.DialogResult = DialogResult.OK
                Me.Hide()
            End If
        Catch ex As Exception

            MessageBox.Show(ex.Message)

        Finally

            btnActivate.Enabled = True

            prgActivation.Visible = False

        End Try
    End Sub

    Private Sub StyleButton(btn As Button)

        btn.BackColor = Color.FromArgb(45, 45, 48)
        btn.ForeColor = Color.White
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 70, 70)

    End Sub


    Private Function GetHWID() As String

        Try

            Dim mc As New ManagementClass("Win32_Processor")

            For Each mo As ManagementObject In mc.GetInstances()
                Return mo("ProcessorId").ToString()
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return ""

    End Function
    Private Sub UpdateHWID(key As String, currentHWID As String)

        Dim existingHWID As String = GetStoredHWID(key)

        If Not String.IsNullOrWhiteSpace(existingHWID) Then

            MessageBox.Show("License already activated.", "Activated", MessageBoxButtons.OK, MessageBoxIcon.Information
                            )
            Exit Sub

        End If

        Dim pcName As String = Environment.MachineName
        Dim activationDate As String =
            DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")

        Dim url As String =
            "https://firestore.googleapis.com/v1/projects/netsteamtools/databases/(default)/documents/licenses/" & key

        Dim json As String =
            "{""fields"":{" &
            """hwid"":{""stringValue"":""" & currentHWID & """}," &
            """pcname"":{""stringValue"":""" & pcName & """}," &
            """activated"":{""stringValue"":""" & activationDate & """}," &
            """status"":{""stringValue"":""active""}" &
            "}}"

        Dim request As HttpWebRequest =
            CType(WebRequest.Create(url), HttpWebRequest)

        request.Method = "PATCH"
        request.ContentType = "application/json"

        Dim bytes() As Byte = Encoding.UTF8.GetBytes(json)

        Using stream = request.GetRequestStream()
            stream.Write(bytes, 0, bytes.Length)
        End Using

        Using response As HttpWebResponse =
            CType(request.GetResponse(), HttpWebResponse)
        End Using

    End Sub
    Private Function IsActivated() As Boolean

        Dim filePath As String =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "NetSteamTools",
                "license.dat")

        Return File.Exists(filePath)

    End Function
    Private Function LicenseExists(key As String) As Boolean

        Try

            ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)

            Dim url As String =
                "https://firestore.googleapis.com/v1/projects/netsteamtools/databases/(default)/documents/licenses/" & key

            Dim request As HttpWebRequest =
                CType(WebRequest.Create(url), HttpWebRequest)

            request.Method = "GET"

            Using response As HttpWebResponse =
                CType(request.GetResponse(), HttpWebResponse)

                Return True

            End Using

        Catch ex As WebException

            Return False

        End Try

    End Function
 Private Function GetStoredHWID(key As String) As String

        Try

            ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)

            Dim url As String =
                "https://firestore.googleapis.com/v1/projects/netsteamtools/databases/(default)/documents/licenses/" & key

            Dim request As HttpWebRequest =
                CType(WebRequest.Create(url), HttpWebRequest)

            request.Method = "GET"

            Using response As HttpWebResponse =
                CType(request.GetResponse(), HttpWebResponse)

                Using reader As New StreamReader(response.GetResponseStream())

                    Dim json As String = reader.ReadToEnd()

                    Dim obj As JObject = JObject.Parse(json)

                    If obj("fields") Is Nothing Then Return ""

                    If obj("fields")("hwid") Is Nothing Then Return ""

                    Return obj("fields")("hwid")("stringValue").ToString()

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show("GetStoredHWID Error: " & ex.Message)
            Return ""

        End Try

    End Function
    Private Function ValidateAndActivate(key As String, currentHWID As String) As Boolean

        SetStatus("Checking license key...")

        If Not LicenseExists(key) Then

            SetStatus("Invalid license key.")

            MessageBox.Show("Invalid license key.", "Invalid",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return False
        End If

        SetStatus("Checking device registration...")

        Dim storedHWID As String = GetStoredHWID(key)

        ' =========================
        ' FIRST TIME ACTIVATION
        ' =========================
        If String.IsNullOrWhiteSpace(storedHWID) Then

            SetStatus("Registering device...")

            UpdateHWID(key, currentHWID)

            SaveActivation()
            SaveLicenseKey(key, GetHWID())

            SetStatus("Activation successful.")

            MessageBox.Show("Activation successful.", "Successful",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return True
        End If

        ' =========================
        ' SAME DEVICE
        ' =========================
        If storedHWID = currentHWID Then

            SaveActivation()
            SaveLicenseKey(key, GetHWID())

            SetStatus("License verified.")

            MessageBox.Show("License verified.", "Verified",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return True
        End If

        ' =========================
        ' DIFFERENT DEVICE
        ' =========================
        SetStatus("License blocked.")

        MessageBox.Show(
            "This license is already activated on another device.",
            "Access Denied",
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation)

        Return False

    End Function
    Private Function GetPCName() As String
        Return Environment.MachineName
    End Function
    Private Sub SetStatus(message As String)

        lblStatus.Text = message
        lblStatus.Refresh()

        Application.DoEvents()

    End Sub
    Private Sub SaveActivation()

        Dim folder As String =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "NetSteamTools")

        If Not Directory.Exists(folder) Then
            Directory.CreateDirectory(folder)
        End If

        Dim content As String =
            "HWID=" & GetHWID() & vbCrLf &
            "Date=" & DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")

        File.WriteAllText(
            Path.Combine(folder, "license.dat"),
            content)

    End Sub
    Private Sub SaveLicenseKey(key As String, hwid As String)

        Dim folder As String =
            IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                            "NetSteamTools")

        If Not IO.Directory.Exists(folder) Then
            IO.Directory.CreateDirectory(folder)
        End If

        Dim content As String =
            "KEY=" & key & vbCrLf &
            "HWID=" & hwid

        IO.File.WriteAllText(IO.Path.Combine(folder, "key.dat"), content)

    End Sub
    Private Function IsLicenseValidForThisPC(key As String) As Boolean

        Dim localFile As String =
            IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                            "NetSteamTools", "key.dat")

        If Not IO.File.Exists(localFile) Then Return False

        Dim lines() As String = IO.File.ReadAllLines(localFile)

        Dim fileKey As String = ""
        Dim fileHWID As String = ""

        For Each line In lines

            If line.StartsWith("KEY=") Then
                fileKey = line.Replace("KEY=", "").Trim()
            End If

            If line.StartsWith("HWID=") Then
                fileHWID = line.Replace("HWID=", "").Trim()
            End If

        Next

        Dim currentHWID As String = GetHWID()

        ' Must match BOTH local + Firebase
        If fileKey <> key Then Return False
        If fileHWID <> currentHWID Then Return False

        Return True

    End Function
    Private Function GetSavedKey() As String

        Dim file As String =
            IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                            "NetSteamTools", "key.dat")

        If Not IO.File.Exists(file) Then Return ""

        Dim lines() As String = IO.File.ReadAllLines(file)

        For Each line In lines
            If line.StartsWith("KEY=") Then
                Return line.Replace("KEY=", "").Trim()
            End If
        Next

        Return ""

    End Function

    Private Sub frmWelcome_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.AcceptButton = btnActivate
        Me.BackColor = Color.FromArgb(30, 30, 30)
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.StartPosition = FormStartPosition.CenterScreen

        StyleButton(btnActivate)

        lblStatus.Text = "Ready"
        prgActivation.Visible = False
        prgActivation.Style = ProgressBarStyle.Marquee

        Try
            CreateDataFile()

            Dim savedLicense As String = GetLicenseKey()

            ' =========================
            ' USAGE COUNTER CHECK
            ' =========================
            If Not String.IsNullOrWhiteSpace(savedLicense) Then

                IncrementUsage()

                Dim count As Integer = GetUsageCount()

                If count >= 10 Then

                    ResetLicense()

                    MessageBox.Show(
                        "This license must be revalidated.",
                        "NetSteamTools",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)

                    SetStatus("License validation required.")
                    btnActivate.Enabled = True
                    txtKey.Enabled = True

                    Exit Sub

                End If

            End If

            SetStatus("Checking license...")

            Dim hwid As String = GetHWID()
            Dim licenseKey As String = GetSavedKey()

            ' =========================
            ' STEP 1: NO KEY FOUND
            ' =========================
            If String.IsNullOrWhiteSpace(licenseKey) Then
                SetStatus("No license found.")
                btnActivate.Enabled = True
                txtKey.Enabled = True
                Exit Sub
            End If

            ' =========================
            ' STEP 2: GET FIREBASE DATA
            ' =========================
            Dim storedHWID As String = GetStoredHWID(licenseKey)

            ' =========================
            ' STEP 3: INVALID KEY (NOT REGISTERED)
            ' =========================
            If storedHWID Is Nothing Then
                SetStatus("Invalid license key.")
                btnActivate.Enabled = True
                txtKey.Enabled = True
                Exit Sub
            End If

            ' =========================
            ' STEP 4: FIRST TIME (FIREBASE EMPTY)
            ' =========================
            If String.IsNullOrWhiteSpace(storedHWID) Then
                SetStatus("License not activated.")
                btnActivate.Enabled = True
                txtKey.Enabled = True
                Exit Sub
            End If

            ' =========================
            ' STEP 5: HWID MATCH (VALID DEVICE)
            ' =========================
            If storedHWID = hwid Then

                SetStatus("License valid. Opening app...")

                ' 🔐 EXTRA SAFETY: verify local file matches HWID too
                If Not IsLicenseValidForThisPC(licenseKey) Then
                    SetStatus("Local license mismatch.")
                    btnActivate.Enabled = True
                    txtKey.Enabled = True
                    Exit Sub
                End If

                frmStm.Show()
                Me.Hide()


                Exit Sub

            End If

            ' =========================
            ' STEP 6: WRONG DEVICE
            ' =========================
            SetStatus("License blocked (used on another device).")

            MessageBox.Show("This license is not valid for this device.",
                            "Access Denied",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
            btnActivate.Enabled = True
            txtKey.Enabled = True

        Catch ex As Exception

            SetStatus("License check failed.")
            btnActivate.Enabled = True
            txtKey.Enabled = True

        End Try

    End Sub

    Private Sub frmWelcome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnActivate.Enabled = False
        txtKey.Enabled = False
    End Sub
End Class