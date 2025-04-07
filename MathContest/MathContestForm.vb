'Brandon Barrera
'RCET 0226
'Spring 2025
'Math Contest
'https://github.com/BrandLeBar/MathContest.git

Option Explicit On
Option Strict On
Option Compare Text

Public Class MathContestForm

    ''' <summary>
    ''' Sets all of the initial values and resets everything to the way it was on start-up.
    ''' </summary>
    Sub SetDefaults()
        NameTextBox.Text = ""
        AgeTextBox.Text = ""
        GradeTextBox.Text = ""
        StudentAnswerTextBox.Text = ""
        StudentAnswerTextBox.Enabled = False
        MathTypeGroupBox.Enabled = False
        SubmitButton.Enabled = False
        SummaryButton.Enabled = False
        AddRadioButton.Checked = True
        FirstNumberTextBox.Text = CStr(RandomNumberGenerator(0, 100))
        SecondNumberTextBox.Text = CStr(RandomNumberGenerator(0, 100))
        ScoreCounter(True, True)
        AttemptCounter(True, True)
    End Sub


    ' Event Handlers //////////////////
    Private Sub MathContestForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SetDefaults()
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        SetDefaults()
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub NameTextBox_TextChanged(sender As Object, e As EventArgs) Handles NameTextBox.TextChanged
        SubmitButton.Enabled = True
    End Sub

    Private Sub SummaryButton_Click(sender As Object, e As EventArgs) Handles SummaryButton.Click
        Dim currentCorrect As Integer = ScoreCounter(, True)
        Dim currentAttempts As Integer = AttemptCounter(, True)

        MsgBox($"{NameTextBox.Text} has gotten {currentCorrect} out of {currentAttempts}")
    End Sub

    Private Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click
        If CheckValid() = True Then
            StudentAnswerTextBox.Enabled = True
            SubmitButton.Enabled = True
            MathTypeGroupBox.Enabled = True
            If StudentAnswerTextBox.Text = "" Then

            Else
                MathTime()
            End If
            FirstNumberTextBox.Text = CStr(RandomNumberGenerator(0, 100))
            SecondNumberTextBox.Text = CStr(RandomNumberGenerator(0, 100))
        End If
    End Sub


    ''' <summary>
    ''' Generates random numbers between a selected minimum and maximum value
    ''' </summary>
    ''' <param name="min"> minimum number generated </param>
    ''' <param name="max"> maximum number generated </param>
    ''' <returns> the selected random number </returns>
    Function RandomNumberGenerator(min As Integer, max As Integer) As Integer
        Randomize()
        Return CInt(Math.Ceiling(max - min) * Rnd() + min)
    End Function


    ''' <summary>
    ''' This function checks to see if the user is inputing data types that can be untilized by the program, and provides an explaintion
    ''' on what types they should be. Also is where the age and grade limit are set
    ''' </summary>
    ''' <returns> True or False </returns>
    Function CheckValid() As Boolean
        Dim valid As Boolean = True
        Dim message As String

        If NameTextBox.Text = "" Then
            valid = False
            NameTextBox.Focus()
            message &= "Please enter a name." & vbNewLine
        End If

        Try
            If CInt(AgeTextBox.Text) < 7 Then
                valid = False
                message &= "Student not eligible to compete" & vbNewLine
                AgeTextBox.Focus()
            ElseIf CInt(AgeTextBox.Text) > 11 Then
                valid = False
                message &= "Student not eligible to compete" & vbNewLine
                AgeTextBox.Focus()
            End If
        Catch ex As Exception
            valid = False
            message &= "Please enter a numeric age" & vbNewLine
            AgeTextBox.Focus()
        End Try

        Try
            If CInt(GradeTextBox.Text) < 1 Then
                valid = False
                message &= "Student not eligible to compete" & vbNewLine
                GradeTextBox.Focus()
            ElseIf CInt(GradeTextBox.Text) > 4 Then
                valid = False
                message &= "Student not eligible to compete" & vbNewLine
                GradeTextBox.Focus()
            End If
        Catch ex As Exception
            valid = False
            message &= "Please enter a numeric Grade" & vbNewLine
            GradeTextBox.Focus()
        End Try

        If Not valid Then
            MsgBox(message, MsgBoxStyle.Critical, "Please enter your name, age, and grade.")
        End If

        Return valid
    End Function


    'Math operators ////////////////////
    Function Add() As Integer
        Dim _add As Integer
        Dim firstNumber As Integer = CInt(FirstNumberTextBox.Text)
        Dim secondNumber As Integer = CInt(SecondNumberTextBox.Text)

        _add = firstNumber + secondNumber

        Return _add
    End Function
    Function Subtract() As Integer
        Dim _subtract As Integer
        Dim firstNumber As Integer = CInt(FirstNumberTextBox.Text)
        Dim secondNumber As Integer = CInt(SecondNumberTextBox.Text)

        _subtract = firstNumber - secondNumber

        Return _subtract
    End Function
    Function Multiply() As Integer
        Dim _multiply As Integer
        Dim firstNumber As Integer = CInt(FirstNumberTextBox.Text)
        Dim secondNumber As Integer = CInt(SecondNumberTextBox.Text)

        _multiply = firstNumber * secondNumber

        Return _multiply
    End Function
    Function Divide() As Integer
        Dim _divide As Integer
        Dim firstNumber As Integer = CInt(FirstNumberTextBox.Text)
        Dim secondNumber As Integer = CInt(SecondNumberTextBox.Text)

        _divide = firstNumber \ secondNumber

        Return _divide
    End Function


    ''' <summary>
    ''' This is where the magic happens, MathTime is where all of the students answers are compared to the correct values
    ''' and scores/attempts are counted. Feedback for answers is also here.
    ''' </summary>
    Sub MathTime()
        If AddRadioButton.Checked Then
            Try
                If CInt(StudentAnswerTextBox.Text) = Add() Then
                    MsgBox("Correct")
                    ScoreCounter()
                Else
                    MsgBox($"Incorrect, answer was {Add()}")
                End If
                AttemptCounter()
            Catch ex As Exception
                MsgBox("Please enter a numaric value")
                StudentAnswerTextBox.Focus()
            End Try
        ElseIf SubtractRadioButton.Checked Then
            Try
                If CInt(StudentAnswerTextBox.Text) = Subtract() Then
                    MsgBox("Correct")
                    ScoreCounter()
                Else
                    MsgBox($"Incorrect, answer was {Subtract()}")
                End If
                AttemptCounter()
            Catch ex As Exception
                MsgBox("Please enter a numaric value")
                StudentAnswerTextBox.Focus()
            End Try
        ElseIf MultiplyRadioButton.Checked Then
            Try
                If CInt(StudentAnswerTextBox.Text) = Multiply() Then
                    MsgBox("Correct")
                    ScoreCounter()
                Else
                    MsgBox($"Incorrect, answer was {Multiply()}")
                End If
                AttemptCounter()
            Catch ex As Exception
                MsgBox("Please enter a numaric value")
                StudentAnswerTextBox.Focus()
            End Try
        ElseIf DivideRadioButton.Checked Then
            Try
                If CInt(StudentAnswerTextBox.Text) = Divide() Then
                    MsgBox("Correct")
                    ScoreCounter()
                Else
                    MsgBox($"Incorrect, answer was {Divide()}")
                End If
                AttemptCounter()
            Catch ex As Exception
                MsgBox("Please enter a numaric value")
                StudentAnswerTextBox.Focus()
            End Try
        End If
    End Sub


    ' Radio button randomness
    Private Sub AddRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles AddRadioButton.CheckedChanged
        FirstNumberTextBox.Text = CStr(RandomNumberGenerator(0, 100))
        SecondNumberTextBox.Text = CStr(RandomNumberGenerator(0, 100))
    End Sub
    Private Sub SubtractRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles SubtractRadioButton.CheckedChanged
        FirstNumberTextBox.Text = CStr(RandomNumberGenerator(0, 100))
        SecondNumberTextBox.Text = CStr(RandomNumberGenerator(0, 100))
    End Sub
    Private Sub MultiplyRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles MultiplyRadioButton.CheckedChanged
        FirstNumberTextBox.Text = CStr(RandomNumberGenerator(0, 100))
        SecondNumberTextBox.Text = CStr(RandomNumberGenerator(0, 100))
    End Sub
    Private Sub DivideRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles DivideRadioButton.CheckedChanged
        FirstNumberTextBox.Text = CStr(RandomNumberGenerator(0, 100))
        SecondNumberTextBox.Text = CStr(RandomNumberGenerator(0, 100))
    End Sub


    ''' <summary>
    ''' Counts the number of correct answers from students
    ''' </summary>
    ''' <param name="clear"> An optional boolean that resets the current Score </param>
    ''' <param name="referance"> An optional boolean that lets this number be referenced without adding more </param>
    ''' <returns> The current score </returns>
    Function ScoreCounter(Optional clear As Boolean = False, Optional referance As Boolean = False) As Integer
        Static _scoreCounter As Integer

        If clear = False And referance = False Then
            _scoreCounter += 1
        ElseIf clear = True Then
            _scoreCounter = 0
        End If

        Return _scoreCounter
    End Function


    ''' <summary>
    ''' Counts the number of attempts made 
    ''' </summary>
    ''' <param name="clear"> Resets the current number of attempts (Optional) </param>
    ''' <param name="referance"> Lets this number be seen without adding additionally (Optional) </param>
    ''' <returns> The number of attempts </returns>
    Function AttemptCounter(Optional clear As Boolean = False, Optional referance As Boolean = False) As Integer
        Static _attemptCounter As Integer
        If _attemptCounter >= 1 Then
            SummaryButton.Enabled = True
        End If

        If clear = False And referance = False Then
            _attemptCounter += 1
        ElseIf clear = True Then
            _attemptCounter = 0
        End If

        Return _attemptCounter
    End Function

End Class
