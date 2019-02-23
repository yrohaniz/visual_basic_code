Public Class EXPLORATION

    Dim g1, g2 As Graphics 'Declaration of the global variables
    Dim sdBrush1 As SolidBrush = New SolidBrush(Color.Red)
    Dim sdBrush2 As SolidBrush = New SolidBrush(Color.Blue)
    Dim sdBrush3 As SolidBrush = New SolidBrush(Color.Black)
    Dim sdBrush4 As SolidBrush = New SolidBrush(Color.Green)
    Dim sdBrush5 As SolidBrush = New SolidBrush(Color.Orange)
    Dim sdBrush6 As SolidBrush = New SolidBrush(Color.Purple)
    Dim sdBrush7 As SolidBrush = New SolidBrush(Color.Chocolate)
    Dim sdBrush8 As SolidBrush = New SolidBrush(Color.Tan)
    Dim sdBrush9 As SolidBrush = New SolidBrush(Color.Cyan)
    Dim sdBrush10 As SolidBrush = New SolidBrush(Color.Yellow)
    Dim SB() As SolidBrush = {sdBrush1, sdBrush2, sdBrush3, sdBrush4, sdBrush5, sdBrush6, sdBrush7, sdBrush8, sdBrush9, sdBrush10}
    Dim PopNu, h, w, counter As Integer
    Dim Transition As Boolean = False

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then                       'Throw bunch of errors in case the values of population number or the transition matrix or the initial state vector are missing
            MsgBox("YOU MUST ENTER POPULATION NUMBER!")
        ElseIf inti_state Is Nothing Then
            MsgBox("THE INITIAL STATE VECTOR IS MISSING!")
        ElseIf inti_Trans Is Nothing Then
            MsgBox("THE TRANSITION MATRIX IS MISSING!")
        Else
            PopNu = TextBox1.Text 'Read the population number 
            h = PictureBox1.Height - 10 'Determine the height and the width of the picturebox1 considering a small margin
            w = PictureBox1.Width - 10
            Timer1.Enabled = True 'Enable Timer1
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Timer1.Enabled = False 'Disable Timer1
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Transition = False 'The Back button hides the current From and puts the enries of the initial state vector into the state array if the initial state exists
        Timer1.Enabled = False
        If Not inti_state Is Nothing Then
            Initialize(state, inti_state, inti_state.Length, 1)
        End If
        Me.Hide()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim i As Integer 'Declaration of the local variables

        g1 = PictureBox1.CreateGraphics 'Initialize the Graphics objects
        g2 = PictureBox2.CreateGraphics
        g1.Clear(Color.White)
        g2.Clear(Color.White)
        If Transition Then 'If the start transition button is clicked, Timer1 starts to multiply the transition matrix and the resultant state vecors sequentially
            Multiply(inti_Trans, state, state.Length, 1) 'Call the multiply procedure
            For i = 0 To inti_state.Length - 1
                Population(Math.Round(PopNu * state(i, 0)), i) 'Produce dots of a certain color according to the enteries of the state vectors and population number
            Next
            Histogram() 'Draw Historgram
            counter += 1 'Increment the counter variable
            TextBox2.Text = counter
        Else
            For i = 0 To inti_state.Length - 1 'If the start transition button is not still clicked, just draw the dots corresponding the initial state vector
                Population(Math.Round(PopNu * inti_state(i, 0)), i)
            Next
            Histogram()
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Timer1.Enabled Then 'Start the Transition if the animate button has already initiated Timer1
            Transition = True
            counter = 0
            TextBox2.Text = counter
        Else
            MsgBox("YOU MUST ANIMATE FIRST!")
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If Timer1.Enabled Then 'Stop the Transition if the animate button has already initiated Timer1
            Transition = False
            Initialize(state, inti_state, inti_state.Length, 1) 'Put the entries of the inti_state array into state array by calling the Initialize subroutine
        Else
            MsgBox("YOU MUST ANIMATE FIRST!")
        End If
    End Sub

    Sub Population(ByVal N As Integer, ByVal C As Integer) 'The Population subprocedure which draws the points in picturebox1
        Dim i As Integer 'Declaration of the local variables

        For i = 1 To N
            g1.FillRectangle(SB(C), Int(w * Rnd()), Int(h * Rnd()), 5, 5) 'Draw the dots
        Next
    End Sub

    Sub Histogram() 'The Histogram subprocedure which draws the histogram graph in the picturebox2 for each color entry
        Dim i As Integer

        For i = 1 To inti_state.Length
            g2.FillRectangle(SB(i - 1), 39 * i, Yc(state(i - 1, 0)), 20, 330 - Yc(state(i - 1, 0))) 'Draw th rectangular histograms
        Next
    End Sub

    Function Yc(ByVal y As Double) As Integer 'Yc function converts the y cartesian coordinate into appropriate VB.NET coordinate
        Return 330 - 330 * y
    End Function

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click 'The contents of the help button
        MsgBox("In this window the multiplication process of the transition matrix and" & vbCrLf &
               "the initial state vector is animated using a number of dots in different" & vbCrLf &
               "colors. The total number of dots is given by the population number." & vbCrLf &
               "The corresponding number of colors are given by the number of" & vbCrLf &
               "state vector entries. There are two graphical methods to show the evolution" & vbCrLf &
               "of colored dots. The graphics representation supports up to 10 different" & vbCrLf &
               "colors. In order to initiate the transition, the user should click the" & vbCrLf &
               "start transition button. The number of steps are shown in the 'Counter' textbox.")
    End Sub
End Class