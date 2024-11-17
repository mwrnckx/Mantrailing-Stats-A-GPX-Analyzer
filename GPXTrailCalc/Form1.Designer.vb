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
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnBrowse
        '
        Me.btnBrowse.BackColor = System.Drawing.Color.LightGreen
        resources.ApplyResources(Me.btnBrowse, "btnBrowse")
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.UseVisualStyleBackColor = False
        '
        'txtDirectory
        '
        resources.ApplyResources(Me.txtDirectory, "txtDirectory")
        Me.txtDirectory.Name = "txtDirectory"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        resources.ApplyResources(Me.dtpStartDate, "dtpStartDate")
        Me.dtpStartDate.Name = "dtpStartDate"

        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        resources.ApplyResources(Me.dtpEndDate, "dtpEndDate")
        Me.dtpEndDate.Name = "dtpEndDate"
        '
        'btnCalculate
        '
        Me.btnCalculate.BackColor = System.Drawing.Color.LightCoral
        resources.ApplyResources(Me.btnCalculate, "btnCalculate")
        Me.btnCalculate.Name = "btnCalculate"
        Me.btnCalculate.UseVisualStyleBackColor = False
        '
        'lblStartDate
        '
        resources.ApplyResources(Me.lblStartDate, "lblStartDate")
        Me.lblStartDate.Name = "lblStartDate"
        '
        'lblEndDate
        '
        resources.ApplyResources(Me.lblEndDate, "lblEndDate")
        Me.lblEndDate.Name = "lblEndDate"
        '
        'lblDirectory
        '
        resources.ApplyResources(Me.lblDirectory, "lblDirectory")
        Me.lblDirectory.Name = "lblDirectory"
        '
        'txtOutput
        '
        resources.ApplyResources(Me.txtOutput, "txtOutput")
        Me.txtOutput.Name = "txtOutput"
        '
        'txtWarnings
        '
        resources.ApplyResources(Me.txtWarnings, "txtWarnings")
        Me.txtWarnings.Name = "txtWarnings"
        '
        'chbDateToName
        '
        Me.chbDateToName.Checked = True
        Me.chbDateToName.CheckState = System.Windows.Forms.CheckState.Checked
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
        Me.btnEng.Name = "btnEng"
        Me.btnEng.UseVisualStyleBackColor = True
        '
        'btnCS
        '
        resources.ApplyResources(Me.btnCS, "btnCS")
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
        Me.btnDe.Cursor = System.Windows.Forms.Cursors.IBeam
        resources.ApplyResources(Me.btnDe, "btnDe")
        Me.btnDe.Name = "btnDe"
        Me.btnDe.UseVisualStyleBackColor = True
        '
        'Form1
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnEng)
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
        Me.Controls.Add(Me.btnCalculate)
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
    Friend WithEvents btnCalculate As Button
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
        Me.txtDirectory.Text = Application.StartupPath
        gpxCalculator = New GPXDistanceCalculator()
        Me.dtpEndDate.Value = Now
        Me.dtpStartDate.Value = Me.dtpEndDate.Value.AddYears(-1)
    End Sub

    Friend WithEvents btnChartDistances As Button
    Friend WithEvents rbTotDistance As RadioButton
    Friend WithEvents rbDistances As RadioButton
    Friend WithEvents rbAge As RadioButton
    Friend WithEvents rbSpeed As RadioButton
    Friend WithEvents btnCS As Button
    Friend WithEvents btnEng As Button
    Friend WithEvents btnDe As Button
End Class

