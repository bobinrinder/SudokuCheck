﻿Module Module1

    Sub Main()
        If CheckSudoko(ReadData) Then
            System.Console.WriteLine("Sudoku correct!")
        Else
            System.Console.WriteLine("Sudoku incorrect!")
        End If
    End Sub

    Public Function ReadData() As List(Of Integer)
        Dim mySudokoData As New List(Of Integer)(New Integer() {9, 1, 2, 8, 4, 6, 5, 7, 3, 6, 8, 3, 5, 7, 1, 2, 9, 4, 4, 5, 7, 3, 2, 9, 1, 6, 8, 8, 2, 9, 6, 1, 3, 4, 5, 7, 1, 6, 4, 9, 5, 7, 8, 3, 2, 3, 7, 5, 2, 8, 4, 6, 1, 9, 7, 4, 6, 1, 9, 2, 3, 8, 5, 5, 9, 1, 4, 3, 8, 7, 2, 6, 2, 3, 8, 7, 6, 5, 9, 4, 1})
        Return mySudokoData
    End Function

    Public Function CheckSudoko(mySudokoData As List(Of Integer)) As Boolean

        'Define temporary list to check
        Dim myNineTempNumbers As New List(Of Integer)

        'Check Rows
        For i As Integer = 0 To 80
            myNineTempNumbers.Add(mySudokoData(i))
            If myNineTempNumbers.Count = 9 AndAlso Not CheckNineNumbers(myNineTempNumbers) Then
                Return False
            Else
                myNineTempNumbers.Clear()
            End If
        Next

        'Check Columns
        Dim j As Integer = 0
        For i As Integer = 0 To 8
            While myNineTempNumbers.Count <> 9
                myNineTempNumbers.Add(mySudokoData(i + j))
                j += 9
            End While
            If CheckNineNumbers(myNineTempNumbers) Then
                myNineTempNumbers.Clear()
                j = 0
            Else
                Return False
            End If
        Next

        'Check Quarters
        For i As Integer = 0 To 54 Step 27
            For k As Integer = 0 To 2
                myNineTempNumbers.Add(mySudokoData(i + k))
                myNineTempNumbers.Add(mySudokoData(i + k + 9))
                myNineTempNumbers.Add(mySudokoData(i + k + 18))
            Next
            If myNineTempNumbers.Count = 9 AndAlso Not CheckNineNumbers(myNineTempNumbers) Then
                Return False
            Else
                myNineTempNumbers.Clear()
            End If
        Next
        For i As Integer = 3 To 57 Step 27
            For k As Integer = 0 To 2
                myNineTempNumbers.Add(mySudokoData(i + k))
                myNineTempNumbers.Add(mySudokoData(i + k + 9))
                myNineTempNumbers.Add(mySudokoData(i + k + 18))
            Next
            If myNineTempNumbers.Count = 9 AndAlso Not CheckNineNumbers(myNineTempNumbers) Then
                Return False
            Else
                myNineTempNumbers.Clear()
            End If
        Next
        For i As Integer = 6 To 60 Step 27
            For k As Integer = 0 To 2
                myNineTempNumbers.Add(mySudokoData(i + k))
                myNineTempNumbers.Add(mySudokoData(i + k + 9))
                myNineTempNumbers.Add(mySudokoData(i + k + 18))
            Next
            If myNineTempNumbers.Count = 9 AndAlso Not CheckNineNumbers(myNineTempNumbers) Then
                Return False
            Else
                myNineTempNumbers.Clear()
            End If
        Next

        'Yay, it's correct :)
        Return True

    End Function

    Public Function CheckNineNumbers(myNineNumbers As List(Of Integer)) As Boolean
        'Check if exactly 9 Numbers
        If Not myNineNumbers.Count = 9 Then
            Return False
        End If
        'Create Bool-Array for fast check
        Dim myStandardNumbers As Boolean() = {False, False, False, False, False, False, False, False, False}
        'Check each number
        For i As Integer = 0 To 8
            If 0 < myNineNumbers(i) < 10 AndAlso myStandardNumbers(myNineNumbers(i) - 1) = False Then
                myStandardNumbers(myNineNumbers(i) - 1) = True
            Else
                Return False
            End If
        Next
        Return True
    End Function

End Module
