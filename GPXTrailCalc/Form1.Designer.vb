<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    ' The form overrides the Dispose method to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    ' Required by the Windows Form Designer
    ' It can be modified using the Windows Form Designer.
    ' Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.txtDirectory = New System.Windows.Forms.TextBox()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.btnReadGpxFiles = New System.Windows.Forms.Button()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.lblDirectory = New System.Windows.Forms.Label()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.txtWarnings = New System.Windows.Forms.TextBox()
        Me.chbDateToName = New System.Windows.Forms.CheckBox()
        Me.btnOpenDataFile = New System.Windows.Forms.Button()
        Me.btnChartDistances = New System.Windows.Forms.Button()
        Me.rbTotDistance = New System.Windows.Forms.RadioButton()
        Me.rbDistances = New System.Windows.Forms.RadioButton()
        Me.rbAge = New System.Windows.Forms.RadioButton()
        Me.rbSpeed = New System.Windows.Forms.RadioButton()
        Me.btnEng = New System.Windows.Forms.Button()
        Me.btnCS = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnDe = New System.Windows.Forms.Button()
        Me.btnRu = New System.Windows.Forms.Button()
        Me.btnPl = New System.Windows.Forms.Button()
        Me.btnUK = New System.Windows.Forms.Button()
        Me.lblBackupDirectory = New System.Windows.Forms.Label()
        Me.txtBackupDirectory = New System.Windows.Forms.TextBox()
        Me.btnBrowseBackup = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnBrowse
        '
        Me.btnBrowse.BackColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(158, Byte), Integer))
        resources.ApplyResources(Me.btnBrowse, "btnBrowse")
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.UseVisualStyleBackColor = False
        '
        'txtDirectory
        '
        Me.txtDirectory.BackColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.txtDirectory.BorderStyle = System.Windows.Forms.BorderStyle.None
        resources.ApplyResources(Me.txtDirectory, "txtDirectory")
        Me.txtDirectory.Name = "txtDirectory"
        Me.ToolTip1.SetToolTip(Me.txtDirectory, resources.GetString("txtDirectory.ToolTip"))
        '
        'dtpStartDate
        '
        resources.ApplyResources(Me.dtpStartDate, "dtpStartDate")
        Me.dtpStartDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartDate.Name = "dtpStartDate"
        '
        'dtpEndDate
        '
        resources.ApplyResources(Me.dtpEndDate, "dtpEndDate")
        Me.dtpEndDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Name = "dtpEndDate"
        '
        'btnReadGpxFiles
        '
        Me.btnReadGpxFiles.BackColor = System.Drawing.Color.LightCoral
        resources.ApplyResources(Me.btnReadGpxFiles, "btnReadGpxFiles")
        Me.btnReadGpxFiles.Name = "btnReadGpxFiles"
        Me.btnReadGpxFiles.UseVisualStyleBackColor = False
        '
        'lblStartDate
        '
        Me.lblStartDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(158, Byte), Integer))
        resources.ApplyResources(Me.lblStartDate, "lblStartDate")
        Me.lblStartDate.Name = "lblStartDate"
        '
        'lblEndDate
        '
        Me.lblEndDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(158, Byte), Integer))
        resources.ApplyResources(Me.lblEndDate, "lblEndDate")
        Me.lblEndDate.Name = "lblEndDate"
        '
        'lblDirectory
        '
        Me.lblDirectory.BackColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(158, Byte), Integer))
        resources.ApplyResources(Me.lblDirectory, "lblDirectory")
        Me.lblDirectory.Name = "lblDirectory"
        '
        'txtOutput
        '
        Me.txtOutput.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(213, Byte), Integer))
        resources.ApplyResources(Me.txtOutput, "txtOutput")
        Me.txtOutput.Name = "txtOutput"
        '
        'txtWarnings
        '
        Me.txtWarnings.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(213, Byte), Integer))
        resources.ApplyResources(Me.txtWarnings, "txtWarnings")
        Me.txtWarnings.Name = "txtWarnings"
        '
        'chbDateToName
        '
        resources.ApplyResources(Me.chbDateToName, "chbDateToName")
        Me.chbDateToName.Name = "chbDateToName"
        Me.chbDateToName.UseVisualStyleBackColor = True
        '
        'btnOpenDataFile
        '
        Me.btnOpenDataFile.BackColor = System.Drawing.Color.LightGreen
        resources.ApplyResources(Me.btnOpenDataFile, "btnOpenDataFile")
        Me.btnOpenDataFile.Name = "btnOpenDataFile"
        Me.btnOpenDataFile.UseVisualStyleBackColor = False
        '
        'btnChartDistances
        '
        Me.btnChartDistances.BackColor = System.Drawing.Color.Yellow
        resources.ApplyResources(Me.btnChartDistances, "btnChartDistances")
        Me.btnChartDistances.Name = "btnChartDistances"
        Me.btnChartDistances.UseVisualStyleBackColor = False
        '
        'rbTotDistance
        '
        resources.ApplyResources(Me.rbTotDistance, "rbTotDistance")
        Me.rbTotDistance.BackColor = System.Drawing.Color.Yellow
        Me.rbTotDistance.Checked = True
        Me.rbTotDistance.Name = "rbTotDistance"
        Me.rbTotDistance.TabStop = True
        Me.rbTotDistance.UseVisualStyleBackColor = False
        '
        'rbDistances
        '
        resources.ApplyResources(Me.rbDistances, "rbDistances")
        Me.rbDistances.BackColor = System.Drawing.Color.Yellow
        Me.rbDistances.Name = "rbDistances"
        Me.rbDistances.UseVisualStyleBackColor = False
        '
        'rbAge
        '
        resources.ApplyResources(Me.rbAge, "rbAge")
        Me.rbAge.BackColor = System.Drawing.Color.Yellow
        Me.rbAge.Name = "rbAge"
        Me.rbAge.UseVisualStyleBackColor = False
        '
        'rbSpeed
        '
        resources.ApplyResources(Me.rbSpeed, "rbSpeed")
        Me.rbSpeed.BackColor = System.Drawing.Color.Yellow
        Me.rbSpeed.Name = "rbSpeed"
        Me.rbSpeed.UseVisualStyleBackColor = False
        '
        'btnEng
        '
        resources.ApplyResources(Me.btnEng, "btnEng")
        Me.btnEng.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnEng.FlatAppearance.BorderSize = 0
        Me.btnEng.Name = "btnEng"
        Me.btnEng.UseVisualStyleBackColor = True
        '
        'btnCS
        '
        resources.ApplyResources(Me.btnCS, "btnCS")
        Me.btnCS.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCS.FlatAppearance.BorderSize = 0
        Me.btnCS.Name = "btnCS"
        Me.btnCS.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'btnDe
        '
        resources.ApplyResources(Me.btnDe, "btnDe")
        Me.btnDe.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnDe.FlatAppearance.BorderSize = 0
        Me.btnDe.Name = "btnDe"
        Me.btnDe.UseVisualStyleBackColor = True
        '
        'btnRu
        '
        resources.ApplyResources(Me.btnRu, "btnRu")
        Me.btnRu.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnRu.FlatAppearance.BorderSize = 0
        Me.btnRu.Name = "btnRu"
        Me.btnRu.UseVisualStyleBackColor = True
        '
        'btnPl
        '
        resources.ApplyResources(Me.btnPl, "btnPl")
        Me.btnPl.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnPl.FlatAppearance.BorderSize = 0
        Me.btnPl.Name = "btnPl"
        Me.btnPl.UseVisualStyleBackColor = True
        '
        'btnUK
        '
        resources.ApplyResources(Me.btnUK, "btnUK")
        Me.btnUK.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnUK.FlatAppearance.BorderSize = 0
        Me.btnUK.Name = "btnUK"
        Me.btnUK.UseVisualStyleBackColor = True
        '
        'lblBackupDirectory
        '
        Me.lblBackupDirectory.BackColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(158, Byte), Integer))
        resources.ApplyResources(Me.lblBackupDirectory, "lblBackupDirectory")
        Me.lblBackupDirectory.Name = "lblBackupDirectory"
        '
        'txtBackupDirectory
        '
        Me.txtBackupDirectory.BackColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.txtBackupDirectory.BorderStyle = System.Windows.Forms.BorderStyle.None
        resources.ApplyResources(Me.txtBackupDirectory, "txtBackupDirectory")
        Me.txtBackupDirectory.Name = "txtBackupDirectory"
        Me.ToolTip1.SetToolTip(Me.txtBackupDirectory, resources.GetString("txtBackupDirectory.ToolTip"))
        '
        'btnBrowseBackup
        '
        Me.btnBrowseBackup.BackColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(158, Byte), Integer))
        resources.ApplyResources(Me.btnBrowseBackup, "btnBrowseBackup")
        Me.btnBrowseBackup.Name = "btnBrowseBackup"
        Me.btnBrowseBackup.UseVisualStyleBackColor = False
        '
        'Form1
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnBrowseBackup)
        Me.Controls.Add(Me.txtBackupDirectory)
        Me.Controls.Add(Me.lblBackupDirectory)
        Me.Controls.Add(Me.btnUK)
        Me.Controls.Add(Me.btnEng)
        Me.Controls.Add(Me.btnPl)
        Me.Controls.Add(Me.btnRu)
        Me.Controls.Add(Me.btnDe)
        Me.Controls.Add(Me.btnCS)
        Me.Controls.Add(Me.rbSpeed)
        Me.Controls.Add(Me.rbAge)
        Me.Controls.Add(Me.rbDistances)
        Me.Controls.Add(Me.rbTotDistance)
        Me.Controls.Add(Me.btnChartDistances)
        Me.Controls.Add(Me.btnOpenDataFile)
        Me.Controls.Add(Me.chbDateToName)
        Me.Controls.Add(Me.txtWarnings)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.lblDirectory)
        Me.Controls.Add(Me.lblEndDate)
        Me.Controls.Add(Me.lblStartDate)
        Me.Controls.Add(Me.btnReadGpxFiles)
        Me.Controls.Add(Me.dtpEndDate)
        Me.Controls.Add(Me.dtpStartDate)
        Me.Controls.Add(Me.txtDirectory)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBrowse As Button
    Friend WithEvents txtDirectory As TextBox
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents btnReadGpxFiles As Button
    Friend WithEvents lblStartDate As Label
    Friend WithEvents lblEndDate As Label
    Friend WithEvents lblDirectory As Label
    Friend WithEvents txtOutput As TextBox
    Friend WithEvents txtWarnings As TextBox
    Friend WithEvents chbDateToName As CheckBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnOpenDataFile As Button

    Public Sub New()

        ' Toto volání je vyžadované návrhářem.
        InitializeComponent()

        ' Přidejte libovolnou inicializaci po volání InitializeComponent().

        Me.txtOutput.Text &= vbCrLf
        Me.txtWarnings.Text &= vbCrLf
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        chbDateToName.Checked = My.Settings.PrependDateToName

        If My.Settings.Directory = "" Then
            txtDirectory.Text = Application.StartupPath
        Else
            Me.txtDirectory.Text = My.Settings.Directory '
        End If

        If My.Settings.BackupDirectory = "" Then
            txtBackupDirectory.Text = System.IO.Path.Combine(Application.StartupPath, "gpxFilesBackup")
        Else
            Me.txtBackupDirectory.Text = My.Settings.BackupDirectory '
        End If
        gpxCalculator = New GPXDistanceCalculator()
        Me.dtpEndDate.Value = Now
        Me.dtpStartDate.Value = Me.dtpEndDate.Value.AddYears(-1)

        SetTooltips()

    End Sub



    Friend WithEvents btnChartDistances As Button
    Friend WithEvents rbTotDistance As RadioButton
    Friend WithEvents rbDistances As RadioButton
    Friend WithEvents rbAge As RadioButton
    Friend WithEvents rbSpeed As RadioButton
    Friend WithEvents btnCS As Button
    Friend WithEvents btnEng As Button
    Friend WithEvents btnDe As Button
    Friend WithEvents btnRu As Button
    Friend WithEvents btnPl As Button
    Friend WithEvents btnUK As Button
    Friend WithEvents lblBackupDirectory As Label
    Friend WithEvents txtBackupDirectory As TextBox
    Friend WithEvents btnBrowseBackup As Button
    Friend WithEvents ToolTip1 As ToolTip
End Class

