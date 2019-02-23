Public Class TRANSITION

    Dim State_vec As New STATES() 'Declaration of the global variables
    Dim counter As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If TextBox1.Text = "" Then
            MsgBox("YOU MUST ENTER THE TRANSITION MATRIX IN PROPER FORMAT!") 'Throw an error message in the case of wrong formatted entry
        Else
            Read1(TextBox1.Lines, inti_Trans) 'Call the subroutine Read1 to read the transition matrix
            Out(inti_Trans, Int(Math.Sqrt(inti_Trans.Length)), Int(Math.Sqrt(inti_Trans.Length))) 'Call the subroutine Out to print the transtion matrix in Textbox2
            TextBox2.Text = output
            Initialize(Trans, inti_Trans, Int(Math.Sqrt(inti_Trans.Length)), Int(Math.Sqrt(inti_Trans.Length))) 'Call the subroutine Initialize to put the entries of the inti_Trans array into Trans array
            counter = 0 'Initialize the counter variable
            TextBox3.Text = counter
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("YOU MUST READ THE TRANSITION MATRIX FIRST!") 'Throw an error in case the transition matrix is not read
        Else
            Multiply(Trans, Trans, Int(Math.Sqrt(Trans.Length)), Int(Math.Sqrt(Trans.Length))) 'Call the subroutine Multiply to multiply transition matrix by itself
            Out(Trans, Int(Math.Sqrt(Trans.Length)), Int(Math.Sqrt(Trans.Length))) 'Call Out subprocedure to print the result of multiplication
            TextBox2.Text = output
            counter += 1 'Increment the count after each multiplication
            TextBox3.Text = counter
        End If
        

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click 'The Help button contents
        MsgBox("This window reads in the input transition matrix and provides a method to" & vbCrLf &
               "multiply the transition matrix by itself for an indefinite number of times as long" & vbCrLf &
               "as the user clicks the multiply button. In order to input data, the user must obey" & vbCrLf &
               "a preassigned format. There must be only one space betweent the entries and" & vbCrLf &
               "there shouldn't be any space in the begining and at the end of each line of" & vbCrLf &
               "entries. Keep in mind that the transition matrix is a square matrix." & vbCrLf &
               "To change between entry lines use Enter. To read the transition matrix click the" & vbCrLf &
               "'Read' button. The number of multiplications are shown in the 'Counter' textbox." & vbCrLf &
               "The 'State Calculation' button leads to the next form. ")
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        State_vec.Show() 'Call the STATES Form
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Hide() 'Hide the current Form
    End Sub
End Class
