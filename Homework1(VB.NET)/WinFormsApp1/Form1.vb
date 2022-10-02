Namespace Homework1
    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.groupBox1.Text = "Russian forces retreat from strategic city. Pressure appears to be growing on Putin to use nuclear weapons"
        End Sub

        Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.groupBox1.Text = "Bolsonaro or Lula? As Brazil prepares to vote, here's what to know"
        End Sub

        Private Sub button3_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.groupBox1.Text = "Hurricane Orlene strengthens into Category 4 storm as it heads toward western Mexico"
        End Sub

        Private Sub checkBox1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            Me.groupBox1.Text = "Now you can close the application form"
        End Sub
    End Class
End Namespace
