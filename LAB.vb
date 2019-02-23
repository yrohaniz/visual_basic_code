Public Class LAB

    Dim Transition As New TRANSITION() 'Declaration of the global variables

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Transition.Show() 'Call the TRANSITION Form
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End 'Exit button
    End Sub
End Class