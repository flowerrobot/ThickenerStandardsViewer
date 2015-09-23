<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EdrawingsViewerControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EdrawingsViewerControl))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EDrawingControl1 = New eDrawingHostControl.eDrawingControl()
        Me.AxEModelViewControl1 = New AxEModelView.AxEModelViewControl()
        CType(Me.AxEModelViewControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(81, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Where is viewer"
        '
        'EDrawingControl1
        '
        Me.EDrawingControl1.BackColor = System.Drawing.Color.White
        Me.EDrawingControl1.EnableFeatures = 2080
        Me.EDrawingControl1.Location = New System.Drawing.Point(0, 3)
        Me.EDrawingControl1.Name = "EDrawingControl1"
        Me.EDrawingControl1.Size = New System.Drawing.Size(257, 298)
        Me.EDrawingControl1.TabIndex = 1
        '
        'AxEModelViewControl1
        '
        Me.AxEModelViewControl1.Enabled = True
        Me.AxEModelViewControl1.Location = New System.Drawing.Point(263, 3)
        Me.AxEModelViewControl1.Name = "AxEModelViewControl1"
        Me.AxEModelViewControl1.OcxState = CType(resources.GetObject("AxEModelViewControl1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxEModelViewControl1.Size = New System.Drawing.Size(217, 298)
        Me.AxEModelViewControl1.TabIndex = 2
        '
        'EdrawingsViewerControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.AxEModelViewControl1)
        Me.Controls.Add(Me.EDrawingControl1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "EdrawingsViewerControl"
        Me.Size = New System.Drawing.Size(480, 304)
        CType(Me.AxEModelViewControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Forms.Label
    Friend WithEvents EDrawingControl1 As eDrawingHostControl.eDrawingControl
    Friend WithEvents AxEModelViewControl1 As AxEModelView.AxEModelViewControl
End Class
