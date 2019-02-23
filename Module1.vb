Module Module1

    Public Trans(,) As Decimal      'Declaration of the public variables that are used in the entire project
    Public inti_Trans(,) As Decimal
    Public state(,) As Decimal
    Public inti_state(,) As Decimal
    Public output As String

    Sub Read1(ByVal inArray1() As String, ByRef inArray2(,) As Decimal) 'Read1 subprocedure which reads the contents of an string array (textbox.Lines) into a 2-D Decimal array (Specifically the Transition matrix)
        Dim tempArray1(), tempArray2() As String  'Declaration of the local variables
        Dim i, j As Integer
        Dim done As Boolean = False

        tempArray1 = inArray1 'Read the contents of the Textbox.Lines into a 1-D temporary array
        ReDim inArray2(tempArray1.Length - 1, tempArray1.Length - 1) 'Redimension inArray2 accordingly (Since we are dealing with square matrices)
        For i = 0 To tempArray1.Length - 1
            tempArray2 = tempArray1(i).Split(" ") 'Find the individaul entries of each line
            For j = 0 To tempArray2.Length - 1
                If tempArray1.Length <> tempArray2.Length Then
                    done = True
                    MsgBox("THE TRANSITION MATRIX HAS BEEN ENTERED IN A WRONG FORMAT! PLEASE TRY AGAIN.") 'If the entries are formatted wrong throw an error
                    Exit For
                Else
                    inArray2(i, j) = tempArray2(j) 'Initialize the contents of the second temporary array into the Decimal 2-D array (Tansition matrix)
                End If
            Next
            If done Then Exit For
        Next
    End Sub

    Sub Read2(ByVal inArray1() As String, ByRef inArray2(,) As Decimal) 'Read2 subprocedure reads the contents of the textbox.Lines string array and puts them in the state vetors
        Dim tempArray1() As String 'Declaration of local variables
        Dim i As Integer

        tempArray1 = inArray1 'Read the contents of the Textbox.Lines into a 1-D temporary array
        ReDim inArray2(tempArray1.Length - 1, 0) 'Redimension inArray2 accordingly (Since we are dealing with column matrices)
        For i = 0 To tempArray1.Length - 1
            Try                               'In case the format of the input initial state vector is wrong, throw an exception
                Decimal.Round(tempArray1(i))
            Catch ex As Exception
                MsgBox("THE INITIAL STATE FORMAT IS WRONG! PLEASE TRY AGAIN." & vbTab & ex.ToString)
                Exit For
            End Try
            inArray2(i, 0) = tempArray1(i) 'Initialize the contents of the temporary array into the Decimal 2-D array (State vectors)
        Next
    End Sub

    Sub Out(ByVal inArray(,) As Decimal, ByVal R As Integer, ByVal C As Integer) 'Out subprocedure which prints the contents of an array with the specified format
        Dim i, j As Integer 'Declaration of the local variables

        output = ""
        For i = 0 To R - 1
            For j = 0 To C - 1
                output = output & inArray(i, j).ToString("0.0000") & vbTab & vbTab
            Next
            output = output & vbCrLf & vbCrLf & vbCrLf
        Next

    End Sub

    Sub Initialize(ByRef inArray1(,) As Decimal, ByVal inArray2(,) As Decimal, ByVal R As Integer, ByVal C As Integer) 'Initialize subprocedure which puts the entries of a given array into another one
        Dim i, j As Integer 'Declaration of the local variables

        ReDim inArray1(R - 1, C - 1)
        For i = 0 To R - 1
            For j = 0 To C - 1
                inArray1(i, j) = inArray2(i, j)
            Next
        Next
    End Sub

    Sub Multiply(ByVal inArray1(,) As Decimal, ByVal inArray2(,) As Decimal, ByVal R As Integer, ByVal C As Integer) 'Multiply subprocedure which multiplies a given array with anohter one
        Dim tempMp(R - 1, C - 1) As Decimal 'Declaration of the local variables
        Dim i, j, k As Integer

        For i = 0 To R - 1  'Each row entry of a 2-D array on the right is multiplied by the corresponding entries of another 2-D array on the left
            For j = 0 To C - 1
                For k = 0 To R - 1
                    tempMp(i, j) = tempMp(i, j) + inArray1(i, k) * inArray2(k, j)
                Next
            Next
        Next
        For i = 0 To R - 1
            For j = 0 To C - 1
                inArray2(i, j) = tempMp(i, j) 'The entries of the temporary array used for multiplication are fed into the corresponding resultant array after the multiplication
                tempMp(i, j) = 0D 'Entries of the temporary array are set to zero
            Next
        Next
    End Sub
End Module
