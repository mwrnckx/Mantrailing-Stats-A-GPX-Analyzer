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
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.btnReadGpxFiles = New System.Windows.Forms.Button()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.txtWarnings = New System.Windows.Forms.TextBox()
        Me.btnChartDistances = New System.Windows.Forms.Button()
        Me.rbTotDistance = New System.Windows.Forms.RadioButton()
        Me.rbDistances = New System.Windows.Forms.RadioButton()
        Me.rbAge = New System.Windows.Forms.RadioButton()
        Me.rbSpeed = New System.Windows.Forms.RadioButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSelect_directory_gpx_files = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSelectBackupDirectory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSaveAsCsvFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrependDateToFileName = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLanguage = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEnglish = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuGerman = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCzech = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUkrainian = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPolish = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRussian = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabel1})
        resources.ApplyResources(Me.StatusStrip1, "StatusStrip1")
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.ToolTip1.SetToolTip(Me.StatusStrip1, resources.GetString("StatusStrip1.ToolTip"))
        '
        'StatusLabel1
        '
        Me.StatusLabel1.Name = "StatusLabel1"
        resources.ApplyResources(Me.StatusLabel1, "StatusLabel1")
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.MenuStrip1.GripMargin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.SettingsToolStripMenuItem, Me.mnuLanguage})
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.Name = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSelect_directory_gpx_files, Me.mnuSelectBackupDirectory, Me.mnuSaveAsCsvFile})
        resources.ApplyResources(Me.mnuFile, "mnuFile")
        Me.mnuFile.Name = "mnuFile"
        '
        'mnuSelect_directory_gpx_files
        '
        Me.mnuSelect_directory_gpx_files.Name = "mnuSelect_directory_gpx_files"
        resources.ApplyResources(Me.mnuSelect_directory_gpx_files, "mnuSelect_directory_gpx_files")
        '
        'mnuSelectBackupDirectory
        '
        Me.mnuSelectBackupDirectory.Name = "mnuSelectBackupDirectory"
        resources.ApplyResources(Me.mnuSelectBackupDirectory, "mnuSelectBackupDirectory")
        '
        'mnuSaveAsCsvFile
        '
        Me.mnuSaveAsCsvFile.Name = "mnuSaveAsCsvFile"
        resources.ApplyResources(Me.mnuSaveAsCsvFile, "mnuSaveAsCsvFile")
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPrependDateToFileName})
        resources.ApplyResources(Me.SettingsToolStripMenuItem, "SettingsToolStripMenuItem")
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        '
        'mnuPrependDateToFileName
        '
        Me.mnuPrependDateToFileName.CheckOnClick = True
        Me.mnuPrependDateToFileName.Name = "mnuPrependDateToFileName"
        resources.ApplyResources(Me.mnuPrependDateToFileName, "mnuPrependDateToFileName")
        '
        'mnuLanguage
        '
        Me.mnuLanguage.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEnglish, Me.mnuGerman, Me.mnuCzech, Me.mnuUkrainian, Me.mnuPolish, Me.mnuRussian})
        resources.ApplyResources(Me.mnuLanguage, "mnuLanguage")
        Me.mnuLanguage.Name = "mnuLanguage"
        '
        'mnuEnglish
        '
        Me.mnuEnglish.Image = Global.GPXTrailAnalyzer.My.Resources.Resources.en_flag
        Me.mnuEnglish.Name = "mnuEnglish"
        resources.ApplyResources(Me.mnuEnglish, "mnuEnglish")
        Me.mnuEnglish.Tag = "en"
        '
        'mnuGerman
        '
        Me.mnuGerman.Image = Global.GPXTrailAnalyzer.My.Resources.Resources.De_Flag
        Me.mnuGerman.Name = "mnuGerman"
        resources.ApplyResources(Me.mnuGerman, "mnuGerman")
        Me.mnuGerman.Tag = "de"
        '
        'mnuCzech
        '
        Me.mnuCzech.CheckOnClick = True
        Me.mnuCzech.Image = Global.GPXTrailAnalyzer.My.Resources.Resources.czech_flag
        Me.mnuCzech.Name = "mnuCzech"
        resources.ApplyResources(Me.mnuCzech, "mnuCzech")
        Me.mnuCzech.Tag = "cs"
        '
        'mnuUkrainian
        '
        Me.mnuUkrainian.Image = Global.GPXTrailAnalyzer.My.Resources.Resources.uk_flag
        Me.mnuUkrainian.Name = "mnuUkrainian"
        resources.ApplyResources(Me.mnuUkrainian, "mnuUkrainian")
        Me.mnuUkrainian.Tag = "uk"
        '
        'mnuPolish
        '
        Me.mnuPolish.Image = Global.GPXTrailAnalyzer.My.Resources.Resources.pl_flag
        Me.mnuPolish.Name = "mnuPolish"
        resources.ApplyResources(Me.mnuPolish, "mnuPolish")
        Me.mnuPolish.Tag = "pl"
        '
        'mnuRussian
        '
        Me.mnuRussian.Image = Global.GPXTrailAnalyzer.My.Resources.Resources.ru_flag
        Me.mnuRussian.Name = "mnuRussian"
        resources.ApplyResources(Me.mnuRussian, "mnuRussian")
        Me.mnuRussian.Tag = "ru"
        '
        'PictureBox1
        '
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'Form1
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.rbSpeed)
        Me.Controls.Add(Me.rbAge)
        Me.Controls.Add(Me.rbDistances)
        Me.Controls.Add(Me.rbTotDistance)
        Me.Controls.Add(Me.btnChartDistances)
        Me.Controls.Add(Me.txtWarnings)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.lblEndDate)
        Me.Controls.Add(Me.lblStartDate)
        Me.Controls.Add(Me.btnReadGpxFiles)
        Me.Controls.Add(Me.dtpEndDate)
        Me.Controls.Add(Me.dtpStartDate)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.PictureBox1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents btnReadGpxFiles As Button
    Friend WithEvents lblStartDate As Label
    Friend WithEvents lblEndDate As Label
    Friend WithEvents txtOutput As TextBox
    Friend WithEvents txtWarnings As TextBox

    Public Sub New()

        ' Toto volání je vyžadované návrhářem.
        InitializeComponent()

        ' Přidejte libovolnou inicializaci po volání InitializeComponent().

        Me.txtOutput.Text &= vbCrLf
        Me.txtWarnings.Text &= vbCrLf
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        mnuPrependDateToFileName.Checked = My.Settings.PrependDateToName

        If My.Settings.Directory = "" Then
            My.Settings.Directory = Application.StartupPath
        End If

        If My.Settings.BackupDirectory = "" Then
            My.Settings.BackupDirectory = System.IO.Path.Combine(My.Settings.Directory, "gpxFilesBackup")
        End If
        gpxCalculator = New GPXDistanceCalculator()
        Me.dtpEndDate.Value = Now
        Me.dtpStartDate.Value = Me.dtpEndDate.Value.AddYears(-1)

        Me.StatusLabel1.Text = $"Directory: {ZkratCestu(My.Settings.Directory, 130)}" & vbCrLf & $"Backup Directory: {ZkratCestu(My.Settings.BackupDirectory, 130)}"


        SetTooltips()

    End Sub



    Friend WithEvents btnChartDistances As Button
    Friend WithEvents rbTotDistance As RadioButton
    Friend WithEvents rbDistances As RadioButton
    Friend WithEvents rbAge As RadioButton
    Friend WithEvents rbSpeed As RadioButton
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents mnuFile As ToolStripMenuItem
    Friend WithEvents mnuSelect_directory_gpx_files As ToolStripMenuItem
    Friend WithEvents mnuSelectBackupDirectory As ToolStripMenuItem
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents StatusLabel1 As ToolStripStatusLabel
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuPrependDateToFileName As ToolStripMenuItem
    Friend WithEvents mnuLanguage As ToolStripMenuItem
    Friend WithEvents mnuCzech As ToolStripMenuItem
    Friend WithEvents mnuUkrainian As ToolStripMenuItem
    Friend WithEvents mnuEnglish As ToolStripMenuItem
    Friend WithEvents mnuGerman As ToolStripMenuItem
    Friend WithEvents mnuRussian As ToolStripMenuItem
    Friend WithEvents mnuPolish As ToolStripMenuItem
    Friend WithEvents mnuSaveAsCsvFile As ToolStripMenuItem
End Class

