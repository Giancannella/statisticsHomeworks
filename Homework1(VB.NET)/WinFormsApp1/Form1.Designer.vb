Namespace Homework1
    Partial Class Form1
        Private components As System.ComponentModel.IContainer = Nothing

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

        Private Sub InitializeComponent()
            Me.button1 = New System.Windows.Forms.Button()
            Me.button2 = New System.Windows.Forms.Button()
            Me.checkBox1 = New System.Windows.Forms.CheckBox()
            Me.button3 = New System.Windows.Forms.Button()
            Me.groupBox1 = New System.Windows.Forms.GroupBox()
            Me.label1 = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            Me.button1.Location = New System.Drawing.Point(36, 54)
            Me.button1.Name = "button1"
            Me.button1.Size = New System.Drawing.Size(75, 23)
            Me.button1.TabIndex = 0
            Me.button1.Text = "news1"
            Me.button1.UseVisualStyleBackColor = True
            AddHandler Me.button1.Click, New System.EventHandler(Me.button1_Click)
            Me.button2.Location = New System.Drawing.Point(36, 83)
            Me.button2.Name = "button2"
            Me.button2.Size = New System.Drawing.Size(75, 23)
            Me.button2.TabIndex = 3
            Me.button2.Text = "news2"
            Me.button2.UseVisualStyleBackColor = True
            AddHandler Me.button2.Click, New System.EventHandler(Me.button2_Click)
            Me.checkBox1.AutoSize = True
            Me.checkBox1.Location = New System.Drawing.Point(272, 374)
            Me.checkBox1.Name = "checkBox1"
            Me.checkBox1.Size = New System.Drawing.Size(195, 19)
            Me.checkBox1.TabIndex = 7
            Me.checkBox1.Text = "The application works correctly?"
            Me.checkBox1.UseVisualStyleBackColor = True
            AddHandler Me.checkBox1.CheckedChanged, New System.EventHandler(Me.checkBox1_CheckedChanged)
            Me.button3.Location = New System.Drawing.Point(36, 122)
            Me.button3.Name = "button3"
            Me.button3.Size = New System.Drawing.Size(75, 23)
            Me.button3.TabIndex = 8
            Me.button3.Text = "news3"
            Me.button3.UseVisualStyleBackColor = True
            AddHandler Me.button3.Click, New System.EventHandler(Me.button3_Click)
            Me.groupBox1.BackColor = System.Drawing.SystemColors.HighlightText
            Me.groupBox1.Location = New System.Drawing.Point(233, 54)
            Me.groupBox1.Name = "groupBox1"
            Me.groupBox1.Size = New System.Drawing.Size(301, 200)
            Me.groupBox1.TabIndex = 9
            Me.groupBox1.TabStop = False
            Me.groupBox1.Text = "NEWS"
            Me.label1.AutoSize = True
            Me.label1.Location = New System.Drawing.Point(233, 15)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(38, 15)
            Me.label1.TabIndex = 10
            Me.label1.Text = "TGCOM"
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7F, 15F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(800, 450)
            Me.Controls.Add(Me.label1)
            Me.Controls.Add(Me.groupBox1)
            Me.Controls.Add(Me.button3)
            Me.Controls.Add(Me.checkBox1)
            Me.Controls.Add(Me.button2)
            Me.Controls.Add(Me.button1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            AddHandler Me.Load, New System.EventHandler(Me.Form1_Load)
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Private button1 As Button
        Private button2 As Button
        Private checkBox1 As CheckBox
        Private button3 As Button
        Private groupBox1 As GroupBox
        Private label1 As Label
    End Class
End Namespace
