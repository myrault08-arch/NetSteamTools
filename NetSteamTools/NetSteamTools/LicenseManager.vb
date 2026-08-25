Imports System.IO

Module LicenseManager

    Private ReadOnly DataFolder As String = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NetSteamTools")
    Private ReadOnly DataFile As String = IO.Path.Combine(DataFolder, "Usage.dat")

    Public Sub CreateDataFile()

        If Not Directory.Exists(DataFolder) Then
            Directory.CreateDirectory(DataFolder)
        End If

        If Not File.Exists(DataFile) Then

            File.WriteAllLines(DataFile, {
                "LicenseKey=",
                "UsageCount=0"
            })

        End If

    End Sub

    Public Function GetLicenseKey() As String

        CreateDataFile()

        For Each line As String In File.ReadAllLines(DataFile)

            If line.StartsWith("LicenseKey=") Then
                Return line.Substring("LicenseKey=".Length)
            End If

        Next

        Return ""

    End Function

    Public Function GetUsageCount() As Integer

        CreateDataFile()

        For Each line As String In File.ReadAllLines(DataFile)

            If line.StartsWith("UsageCount=") Then

                Dim count As Integer

                If Integer.TryParse(line.Substring("UsageCount=".Length), count) Then
                    Return count
                End If

            End If

        Next

        Return 0

    End Function

    Public Sub SaveLicense(key As String)

        CreateDataFile()

        File.WriteAllLines(DataFile, {
            "LicenseKey=" & key,
            "UsageCount=0"
        })

    End Sub

    Public Sub IncrementUsage()

        Dim key As String = GetLicenseKey()
        Dim count As Integer = GetUsageCount() + 1

        File.WriteAllLines(DataFile, {
            "LicenseKey=" & key,
            "UsageCount=" & count
        })

    End Sub

    Public Sub ResetLicense()

        CreateDataFile()

        File.WriteAllLines(DataFile, {
            "LicenseKey=",
            "UsageCount=0"
        })

    End Sub

End Module