Public Class STATES

    Dim Explore As New EXPLORATION() 'Declaration of the global variables
    Dim counter As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If TextBox1.Text = "" Then
            MsgBox("YOU MUST ENTER THE INITIAL STATE VECTOR IN PROPER FORMAT!") 'Throw an error message in case the initial state vector format is wrong
        Else
            Read2(TextBox1.Lines, inti_state) 'Call the Read2 subroutine to read the initial state vector
            Out(inti_state, inti_state.Length, 1) 'Call Out subprocedure to print the contents of the initial state vector in Textbox2
            TextBox2.Text = output
            Initialize(state, inti_state, inti_state.Length, 1) 'Call the Initialize subroutine to put the entries of inti_state array into state array
            counter = 0 'Initialize the counter variable
            TextBox3.Text = counter
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If TextBox2.Text = "" Or TextBox1.Text = "" Then
            MsgBox("YOU MUST READ THE INITIAL STATE VECTOR FIRST!")
        ElseIf inti_Trans Is Nothing Then                                             'Throw errors if either initial state vector or the transition matrix are not read into the system
            MsgBox("YOU MUST ENTER AND READ THE TRANSITION MATRIX IN PREVIOUS PAGE!")
        Else
            Multiply(inti_Trans, state, state.Length, 1) 'Call the Multiply subroutine to multiply the transition matrix and the initial state vector
            Out(state, state.Length, 1) 'Call the Out subprocedure to print the resultant state vector in the output Textbox
            TextBox2.Text = output
            counter += 1 'Increment counter
            TextBox3.Text = counter
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Hide() 'Hide the current Form
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Not inti_state Is Nothing Then 'If the initial state vector is not empty its contents are put into the state array 
            Initialize(state, inti_state, inti_state.Length, 1)
        End If
        Explore.Show() 'Call the EXPLORATION Form
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click 'The contents of the Help button
        MsgBox("This window reads in the input initial state vector and provides a method to" & vbCrLf &
               "multiply the transition matrix by it for an indefinite number of times as long" & vbCrLf &
               "as the user clicks the multiply button. In order to input data, the user must" & vbCrLf &
               "obey a preassigned format. There must be only one entry in each line." & vbCrLf &
               "Keep in mind that the state vectors are column matrices. To change between" & vbCrLf &
               "entry lines use Enter. To read the initial state vector click the 'Read' button." & vbCrLf &
               "The number of multiplications are shown in the 'Counter' textbox." & vbCrLf &
               "The 'Explore' button leads to the next form.")
    End Sub
End Class