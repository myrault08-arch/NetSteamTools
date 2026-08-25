<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWelcome
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWelcome))
        Me.btnActivate = New System.Windows.Forms.Button()
        Me.lblEAK = New System.Windows.Forms.Label()
        Me.txtKey = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.prgActivation = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'btnActivate
        '
        Me.btnActivate.BackColor = System.Drawing.Color.White
        Me.btnActivate.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActivate.ForeColor = System.Drawing.Color.LimeGreen
        Me.btnActivate.Location = New System.Drawing.Point(101, 51)
        Me.btnActivate.Name = "btnActivate"
        Me.btnActivate.Size = New System.Drawing.Size(75, 23)
        Me.btnActivate.TabIndex = 0
        Me.btnActivate.Text = "Activate"
        Me.btnActivate.UseVisualStyleBackColor = False
        '
        'lblEAK
        '
        Me.lblEAK.AutoSize = True
        Me.lblEAK.BackColor = System.Drawing.Color.Transparent
        Me.lblEAK.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEAK.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblEAK.Location = New System.Drawing.Point(78, 9)
        Me.lblEAK.Name = "lblEAK"
        Me.lblEAK.Size = New System.Drawing.Size(127, 13)
        Me.lblEAK.TabIndex = 1
        Me.lblEAK.Text = "Enter Activation Key"
        '
        'txtKey
        '
        Me.txtKey.BackColor = System.Drawing.Color.White
        Me.txtKey.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKey.ForeColor = System.Drawing.Color.LimeGreen
        Me.txtKey.Location = New System.Drawing.Point(3, 25)
        Me.txtKey.Name = "txtKey"
        Me.txtKey.Size = New System.Drawing.Size(268, 20)
        Me.txtKey.TabIndex = 2
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(5, 93)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(37, 13)
        Me.lblStatus.TabIndex = 3
        Me.lblStatus.Text = "Ready"
        '
        'prgActivation
        '
        Me.prgActivation.Location = New System.Drawing.Point(3, 109)
        Me.prgActivation.Name = "prgActivation"
        Me.prgActivation.Size = New System.Drawing.Size(268, 10)
        Me.prgActivation.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.prgActivation.TabIndex = 4
        Me.prgActivation.Visible = False
        '
        'frmWelcome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.ClientSize = New System.Drawing.Size(275, 121)
        Me.Controls.Add(Me.prgActivation)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.txtKey)
        Me.Controls.Add(Me.lblEAK)
        Me.Controls.Add(Me.btnActivate)
        Me.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.LimeGreen
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmWelcome"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NetSteamTool v7.1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnActivate As System.Windows.Forms.Button
    Friend WithEvents lblEAK As System.Windows.Forms.Label
    Friend WithEvents txtKey As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents prgActivation As System.Windows.Forms.ProgressBar
End Class
