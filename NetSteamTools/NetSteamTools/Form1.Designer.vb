<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStm))
        Me.btnMv = New System.Windows.Forms.Button()
        Me.btnSteamRes = New System.Windows.Forms.Button()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.prgBar = New System.Windows.Forms.ProgressBar()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblLabel = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.rtbLog = New System.Windows.Forms.RichTextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lstFiles = New System.Windows.Forms.ListBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.picGame = New System.Windows.Forms.PictureBox()
        Me.lblIdapp = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblSttus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnCopyID = New System.Windows.Forms.Button()
        Me.txtIDApp = New System.Windows.Forms.TextBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.lvGames = New System.Windows.Forms.ListView()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btnExtrct = New System.Windows.Forms.Button()
        Me.rtbDL = New System.Windows.Forms.RichTextBox()
        Me.txtAppid = New System.Windows.Forms.TextBox()
        Me.btnDownload = New System.Windows.Forms.Button()
        Me.btnChck = New System.Windows.Forms.Button()
        Me.lblAppid = New System.Windows.Forms.Label()
        Me.btnLink = New System.Windows.Forms.Button()
        Me.btnSSU = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picGame, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnMv
        '
        Me.btnMv.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMv.Location = New System.Drawing.Point(205, 315)
        Me.btnMv.Name = "btnMv"
        Me.btnMv.Size = New System.Drawing.Size(133, 34)
        Me.btnMv.TabIndex = 1
        Me.btnMv.Text = "Move lua files to target folder"
        Me.btnMv.UseVisualStyleBackColor = True
        '
        'btnSteamRes
        '
        Me.btnSteamRes.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSteamRes.Location = New System.Drawing.Point(417, 315)
        Me.btnSteamRes.Name = "btnSteamRes"
        Me.btnSteamRes.Size = New System.Drawing.Size(133, 34)
        Me.btnSteamRes.TabIndex = 2
        Me.btnSteamRes.Text = "Run NetSteamTools No Restart"
        Me.btnSteamRes.UseVisualStyleBackColor = True
        '
        'btnLoad
        '
        Me.btnLoad.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoad.Location = New System.Drawing.Point(344, 315)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(67, 34)
        Me.btnLoad.TabIndex = 0
        Me.btnLoad.Text = "Scan lua files"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'prgBar
        '
        Me.prgBar.BackColor = System.Drawing.Color.Black
        Me.prgBar.ForeColor = System.Drawing.Color.LimeGreen
        Me.prgBar.Location = New System.Drawing.Point(4, 352)
        Me.prgBar.Maximum = 5
        Me.prgBar.Name = "prgBar"
        Me.prgBar.Size = New System.Drawing.Size(543, 23)
        Me.prgBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.prgBar.TabIndex = 4
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(202, 384)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 13)
        Me.lblStatus.TabIndex = 12
        '
        'lblLabel
        '
        Me.lblLabel.AutoSize = True
        Me.lblLabel.Font = New System.Drawing.Font("Consolas", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel.ForeColor = System.Drawing.Color.Lime
        Me.lblLabel.Location = New System.Drawing.Point(173, -1)
        Me.lblLabel.Name = "lblLabel"
        Me.lblLabel.Size = New System.Drawing.Size(210, 32)
        Me.lblLabel.TabIndex = 6
        Me.lblLabel.Text = "NetSteamTools"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(4, 34)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(543, 275)
        Me.TabControl1.TabIndex = 7
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Black
        Me.TabPage1.Controls.Add(Me.rtbLog)
        Me.TabPage1.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.ForeColor = System.Drawing.Color.Lime
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(535, 249)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Activity Log"
        '
        'rtbLog
        '
        Me.rtbLog.BackColor = System.Drawing.Color.Black
        Me.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbLog.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbLog.ForeColor = System.Drawing.Color.Lime
        Me.rtbLog.Location = New System.Drawing.Point(3, 3)
        Me.rtbLog.Name = "rtbLog"
        Me.rtbLog.ReadOnly = True
        Me.rtbLog.Size = New System.Drawing.Size(529, 243)
        Me.rtbLog.TabIndex = 0
        Me.rtbLog.Text = ""
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Black
        Me.TabPage2.Controls.Add(Me.lstFiles)
        Me.TabPage2.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.ForeColor = System.Drawing.Color.Lime
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(535, 249)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "lua files"
        '
        'lstFiles
        '
        Me.lstFiles.BackColor = System.Drawing.Color.Black
        Me.lstFiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstFiles.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstFiles.ForeColor = System.Drawing.Color.Lime
        Me.lstFiles.FormattingEnabled = True
        Me.lstFiles.Location = New System.Drawing.Point(3, 3)
        Me.lstFiles.Name = "lstFiles"
        Me.lstFiles.Size = New System.Drawing.Size(529, 243)
        Me.lstFiles.TabIndex = 1
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.Black
        Me.TabPage4.Controls.Add(Me.GroupBox1)
        Me.TabPage4.Controls.Add(Me.lblIdapp)
        Me.TabPage4.Controls.Add(Me.StatusStrip1)
        Me.TabPage4.Controls.Add(Me.btnCopyID)
        Me.TabPage4.Controls.Add(Me.txtIDApp)
        Me.TabPage4.Controls.Add(Me.lblSearch)
        Me.TabPage4.Controls.Add(Me.lvGames)
        Me.TabPage4.Controls.Add(Me.btnSearch)
        Me.TabPage4.Controls.Add(Me.txtSearch)
        Me.TabPage4.ForeColor = System.Drawing.Color.Lime
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(535, 249)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Search Game"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.picGame)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Lime
        Me.GroupBox1.Location = New System.Drawing.Point(357, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(175, 192)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Game Image"
        '
        'picGame
        '
        Me.picGame.Location = New System.Drawing.Point(6, 19)
        Me.picGame.Name = "picGame"
        Me.picGame.Size = New System.Drawing.Size(163, 167)
        Me.picGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picGame.TabIndex = 3
        Me.picGame.TabStop = False
        '
        'lblIdapp
        '
        Me.lblIdapp.AutoSize = True
        Me.lblIdapp.Location = New System.Drawing.Point(238, 8)
        Me.lblIdapp.Name = "lblIdapp"
        Me.lblIdapp.Size = New System.Drawing.Size(43, 13)
        Me.lblIdapp.TabIndex = 8
        Me.lblIdapp.Text = "AppID:"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblSttus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 227)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(535, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblSttus
        '
        Me.lblSttus.BackColor = System.Drawing.Color.Black
        Me.lblSttus.ForeColor = System.Drawing.Color.Lime
        Me.lblSttus.Name = "lblSttus"
        Me.lblSttus.Size = New System.Drawing.Size(39, 17)
        Me.lblSttus.Text = "Ready"
        '
        'btnCopyID
        '
        Me.btnCopyID.Location = New System.Drawing.Point(455, 3)
        Me.btnCopyID.Name = "btnCopyID"
        Me.btnCopyID.Size = New System.Drawing.Size(77, 23)
        Me.btnCopyID.TabIndex = 2
        Me.btnCopyID.Text = "Copy AppID"
        Me.btnCopyID.UseVisualStyleBackColor = True
        '
        'txtIDApp
        '
        Me.txtIDApp.Location = New System.Drawing.Point(287, 5)
        Me.txtIDApp.Name = "txtIDApp"
        Me.txtIDApp.ReadOnly = True
        Me.txtIDApp.Size = New System.Drawing.Size(70, 20)
        Me.txtIDApp.TabIndex = 5
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(4, 8)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(67, 13)
        Me.lblSearch.TabIndex = 4
        Me.lblSearch.Text = "Game Name:"
        '
        'lvGames
        '
        Me.lvGames.BackColor = System.Drawing.Color.Black
        Me.lvGames.ForeColor = System.Drawing.Color.Lime
        Me.lvGames.FullRowSelect = True
        Me.lvGames.GridLines = True
        Me.lvGames.Location = New System.Drawing.Point(7, 31)
        Me.lvGames.MultiSelect = False
        Me.lvGames.Name = "lvGames"
        Me.lvGames.Size = New System.Drawing.Size(344, 193)
        Me.lvGames.TabIndex = 3
        Me.lvGames.UseCompatibleStateImageBehavior = False
        Me.lvGames.View = System.Windows.Forms.View.Details
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(363, 3)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(86, 23)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Search Game"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(71, 5)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(164, 20)
        Me.txtSearch.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Black
        Me.TabPage3.Controls.Add(Me.btnExtrct)
        Me.TabPage3.Controls.Add(Me.rtbDL)
        Me.TabPage3.Controls.Add(Me.txtAppid)
        Me.TabPage3.Controls.Add(Me.btnDownload)
        Me.TabPage3.Controls.Add(Me.btnChck)
        Me.TabPage3.Controls.Add(Me.lblAppid)
        Me.TabPage3.ForeColor = System.Drawing.Color.Lime
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(535, 249)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "lua/manifest Downloader"
        '
        'btnExtrct
        '
        Me.btnExtrct.Location = New System.Drawing.Point(4, 33)
        Me.btnExtrct.Name = "btnExtrct"
        Me.btnExtrct.Size = New System.Drawing.Size(95, 23)
        Me.btnExtrct.TabIndex = 3
        Me.btnExtrct.Text = "Extract Files"
        Me.btnExtrct.UseVisualStyleBackColor = True
        '
        'rtbDL
        '
        Me.rtbDL.BackColor = System.Drawing.Color.Black
        Me.rtbDL.ForeColor = System.Drawing.Color.Lime
        Me.rtbDL.Location = New System.Drawing.Point(4, 62)
        Me.rtbDL.Name = "rtbDL"
        Me.rtbDL.Size = New System.Drawing.Size(528, 184)
        Me.rtbDL.TabIndex = 4
        Me.rtbDL.Text = ""
        '
        'txtAppid
        '
        Me.txtAppid.BackColor = System.Drawing.Color.Black
        Me.txtAppid.ForeColor = System.Drawing.Color.Lime
        Me.txtAppid.Location = New System.Drawing.Point(86, 7)
        Me.txtAppid.Name = "txtAppid"
        Me.txtAppid.Size = New System.Drawing.Size(153, 20)
        Me.txtAppid.TabIndex = 0
        '
        'btnDownload
        '
        Me.btnDownload.AutoSize = True
        Me.btnDownload.Location = New System.Drawing.Point(252, 33)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(143, 23)
        Me.btnDownload.TabIndex = 2
        Me.btnDownload.Text = "Download lua/manifest"
        Me.btnDownload.UseVisualStyleBackColor = True
        '
        'btnChck
        '
        Me.btnChck.AutoSize = True
        Me.btnChck.Location = New System.Drawing.Point(252, 5)
        Me.btnChck.Name = "btnChck"
        Me.btnChck.Size = New System.Drawing.Size(125, 23)
        Me.btnChck.TabIndex = 1
        Me.btnChck.Text = "Check lua/Manifest"
        Me.btnChck.UseVisualStyleBackColor = True
        '
        'lblAppid
        '
        Me.lblAppid.AutoSize = True
        Me.lblAppid.Location = New System.Drawing.Point(1, 10)
        Me.lblAppid.Name = "lblAppid"
        Me.lblAppid.Size = New System.Drawing.Size(79, 13)
        Me.lblAppid.TabIndex = 0
        Me.lblAppid.Text = "Enter AppID:"
        '
        'btnLink
        '
        Me.btnLink.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLink.Location = New System.Drawing.Point(96, 315)
        Me.btnLink.Name = "btnLink"
        Me.btnLink.Size = New System.Drawing.Size(106, 34)
        Me.btnLink.TabIndex = 3
        Me.btnLink.Text = "Open lua/manifest links"
        Me.btnLink.UseVisualStyleBackColor = True
        '
        'btnSSU
        '
        Me.btnSSU.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSSU.Location = New System.Drawing.Point(4, 315)
        Me.btnSSU.Name = "btnSSU"
        Me.btnSSU.Size = New System.Drawing.Size(86, 34)
        Me.btnSSU.TabIndex = 13
        Me.btnSSU.Text = "Run SSU"
        Me.btnSSU.UseVisualStyleBackColor = True
        '
        'frmStm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(554, 403)
        Me.Controls.Add(Me.btnSSU)
        Me.Controls.Add(Me.btnLink)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lblLabel)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.prgBar)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnSteamRes)
        Me.Controls.Add(Me.btnMv)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmStm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NetSteamTool v7.1"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.picGame, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnMv As System.Windows.Forms.Button
    Friend WithEvents btnSteamRes As System.Windows.Forms.Button
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents prgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblLabel As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents rtbLog As System.Windows.Forms.RichTextBox
    Friend WithEvents lstFiles As System.Windows.Forms.ListBox
    Friend WithEvents btnLink As System.Windows.Forms.Button
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents txtAppid As System.Windows.Forms.TextBox
    Friend WithEvents btnDownload As System.Windows.Forms.Button
    Friend WithEvents btnChck As System.Windows.Forms.Button
    Friend WithEvents lblAppid As System.Windows.Forms.Label
    Friend WithEvents rtbDL As System.Windows.Forms.RichTextBox
    Friend WithEvents btnExtrct As System.Windows.Forms.Button
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents lblIdapp As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents btnCopyID As System.Windows.Forms.Button
    Friend WithEvents txtIDApp As System.Windows.Forms.TextBox
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents picGame As System.Windows.Forms.PictureBox
    Friend WithEvents lvGames As System.Windows.Forms.ListView
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblSttus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSSU As System.Windows.Forms.Button

End Class
