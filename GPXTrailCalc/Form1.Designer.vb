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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.txtDirectory = New System.Windows.Forms.TextBox()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.btnCalculate = New System.Windows.Forms.Button()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.lblDirectory = New System.Windows.Forms.Label()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.txtWarnings = New System.Windows.Forms.TextBox()
        Me.chbDateOfCreation = New System.Windows.Forms.CheckBox()
        Me.chbDateToName = New System.Windows.Forms.CheckBox()
        Me.chbCSVFile = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnOpenDataFile = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnBrowse
        '
        Me.btnBrowse.BackColor = System.Drawing.Color.LightGreen
        Me.btnBrowse.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBrowse.Location = New System.Drawing.Point(621, 15)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(143, 33)
        Me.btnBrowse.TabIndex = 3
        Me.btnBrowse.Text = "Browse..."
        Me.btnBrowse.UseVisualStyleBackColor = False
        '
        'txtDirectory
        '
        Me.txtDirectory.Location = New System.Drawing.Point(120, 20)
        Me.txtDirectory.Name = "txtDirectory"
        Me.txtDirectory.Size = New System.Drawing.Size(466, 26)
        Me.txtDirectory.TabIndex = 2
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartDate.Location = New System.Drawing.Point(149, 67)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(144, 26)
        Me.dtpStartDate.TabIndex = 5
        Me.dtpStartDate.Value = New Date(2023, 11, 2, 16, 45, 15, 170)
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(149, 105)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(144, 26)
        Me.dtpEndDate.TabIndex = 7
        '
        'btnCalculate
        '
        Me.btnCalculate.BackColor = System.Drawing.Color.LightCoral
        Me.btnCalculate.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnCalculate.Location = New System.Drawing.Point(21, 245)
        Me.btnCalculate.Name = "btnCalculate"
        Me.btnCalculate.Size = New System.Drawing.Size(232, 60)
        Me.btnCalculate.TabIndex = 1
        Me.btnCalculate.Text = "Start Calculation"
        Me.btnCalculate.UseVisualStyleBackColor = False
        '
        'lblStartDate
        '
        Me.lblStartDate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.lblStartDate.Location = New System.Drawing.Point(21, 67)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(108, 26)
        Me.lblStartDate.TabIndex = 4
        Me.lblStartDate.Text = "Start Date:"
        '
        'lblEndDate
        '
        Me.lblEndDate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.lblEndDate.Location = New System.Drawing.Point(21, 105)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(108, 26)
        Me.lblEndDate.TabIndex = 6
        Me.lblEndDate.Text = "End Date:"
        '
        'lblDirectory
        '
        Me.lblDirectory.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.lblDirectory.Location = New System.Drawing.Point(21, 20)
        Me.lblDirectory.Name = "lblDirectory"
        Me.lblDirectory.Size = New System.Drawing.Size(93, 28)
        Me.lblDirectory.TabIndex = 10
        Me.lblDirectory.Text = "Directory:"
        '
        'txtOutput
        '
        Me.txtOutput.Location = New System.Drawing.Point(354, 67)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.Size = New System.Drawing.Size(576, 577)
        Me.txtOutput.TabIndex = 9
        Me.txtOutput.Text = "GPX Routes:"
        '
        'txtWarnings
        '
        Me.txtWarnings.Location = New System.Drawing.Point(954, 67)
        Me.txtWarnings.Multiline = True
        Me.txtWarnings.Name = "txtWarnings"
        Me.txtWarnings.Size = New System.Drawing.Size(313, 577)
        Me.txtWarnings.TabIndex = 9
        Me.txtWarnings.Text = "Errors and Logs:"
        '
        'chbDateOfCreation
        '
        Me.chbDateOfCreation.Checked = True
        Me.chbDateOfCreation.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbDateOfCreation.Location = New System.Drawing.Point(21, 143)
        Me.chbDateOfCreation.Name = "chbDateOfCreation"
        Me.chbDateOfCreation.Size = New System.Drawing.Size(232, 24)
        Me.chbDateOfCreation.TabIndex = 12
        Me.chbDateOfCreation.Text = "Change Date File Attributes"
        Me.chbDateOfCreation.UseVisualStyleBackColor = True
        '
        'chbDateToName
        '
        Me.chbDateToName.Location = New System.Drawing.Point(21, 173)
        Me.chbDateToName.Name = "chbDateToName"
        Me.chbDateToName.Size = New System.Drawing.Size(232, 24)
        Me.chbDateToName.TabIndex = 13
        Me.chbDateToName.Text = "Prepend Date to File Name"
        Me.chbDateToName.UseVisualStyleBackColor = True
        '
        'chbCSVFile
        '
        Me.chbCSVFile.Checked = True
        Me.chbCSVFile.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbCSVFile.Location = New System.Drawing.Point(21, 203)
        Me.chbCSVFile.Name = "chbCSVFile"
        Me.chbCSVFile.Size = New System.Drawing.Size(232, 24)
        Me.chbCSVFile.TabIndex = 15
        Me.chbCSVFile.Text = "Create CSV Data  File"
        Me.chbCSVFile.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Image = Global.GPXTrailCalc.My.Resources.Resources.trail1
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1300, 844)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'btnOpenDataFile
        '
        Me.btnOpenDataFile.BackColor = System.Drawing.Color.LightGreen
        Me.btnOpenDataFile.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOpenDataFile.Location = New System.Drawing.Point(26, 332)
        Me.btnOpenDataFile.Name = "btnOpenDataFile"
        Me.btnOpenDataFile.Size = New System.Drawing.Size(232, 60)
        Me.btnOpenDataFile.TabIndex = 16
        Me.btnOpenDataFile.Text = "Open Data File"
        Me.btnOpenDataFile.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1778, 844)
        Me.Controls.Add(Me.btnOpenDataFile)
        Me.Controls.Add(Me.chbCSVFile)
        Me.Controls.Add(Me.chbDateToName)
        Me.Controls.Add(Me.chbDateOfCreation)
        Me.Controls.Add(Me.txtWarnings)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.lblDirectory)
        Me.Controls.Add(Me.lblEndDate)
        Me.Controls.Add(Me.lblStartDate)
        Me.Controls.Add(Me.btnCalculate)
        Me.Controls.Add(Me.dtpEndDate)
        Me.Controls.Add(Me.dtpStartDate)
        Me.Controls.Add(Me.txtDirectory)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "GPX Route Distance Calculator"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBrowse As Button
    Friend WithEvents txtDirectory As TextBox
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents btnCalculate As Button
    Friend WithEvents lblStartDate As Label
    Friend WithEvents lblEndDate As Label
    Friend WithEvents lblDirectory As Label
    Friend WithEvents txtOutput As TextBox
    Friend WithEvents txtWarnings As TextBox
    Friend WithEvents chbDateOfCreation As CheckBox
    Friend WithEvents chbDateToName As CheckBox
    Friend WithEvents PictureBox1 As PictureBox

    Public Sub New()

        ' Toto volání je vyžadované návrhářem.
        InitializeComponent()

        ' Přidejte libovolnou inicializaci po volání InitializeComponent().

        Me.txtOutput.Text &= vbCrLf
        Me.txtWarnings.Text &= vbCrLf
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.txtDirectory.Text = Application.StartupPath
        gpxCalculator = New GPXDistanceCalculator()
    End Sub

    Friend WithEvents chbCSVFile As CheckBox
    Friend WithEvents btnOpenDataFile As Button
End Class

