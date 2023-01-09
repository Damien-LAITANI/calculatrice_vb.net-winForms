Public Class Form1

    ' Action au click sur un des boutons de 1 à 9 et des signes de calcules
    Private Sub MultiButton_Click(sender As Object, e As EventArgs) Handles Button5.Click, virgule.Click, Button09.Click, Button08.Click, Button07.Click, Button06.Click, Button05.Click, Button04.Click, Button03.Click, Button02.Click, Button01.Click, Button0.Click

        ' On caste le sender dans le type voulu
        Dim btn As Button = CType(sender, Button)

        ' On affiche le chiffre ou nombre sélectionné par l'utilisateur
        If showRes.Text = 0 Then
            showRes.Text = btn.Text
        Else
            showRes.Text += btn.Text
        End If
    End Sub

    Private Sub Assign_sign_Click(sender As Object, e As EventArgs) Handles SubButton.Click, PlusButton.Click, MultiButton.Click, DivButton.Click

        ' On caste le sender dans le type voulu
        Dim btn As Button = CType(sender, Button)

        ' Si leftNum n'est pas encore assigné
        If leftNum.Text = "" Then
            ' On ajoute le signe au premier nombre
            sign.Text = btn.Text

            ' On place le nombre à calculé dans le label
            leftNum.Text = showRes.Text
            showRes.Text = 0
        End If

    End Sub

    Private Sub Result_Click(sender As Object, e As EventArgs) Handles Result.Click

        rightNum.Text = showRes.Text

        Dim result As Integer
        Select Case sign.Text
            Case "-"
                result = Integer.Parse(leftNum.Text) - Integer.Parse(rightNum.Text)
            Case "+"
                result = Integer.Parse(leftNum.Text) + Integer.Parse(rightNum.Text)
            Case "x"
                result = Integer.Parse(leftNum.Text) * Integer.Parse(rightNum.Text)
            Case "÷"
                result = Integer.Parse(leftNum.Text) / Integer.Parse(rightNum.Text)
        End Select
        showRes.Text = result
    End Sub

    Private Sub Reset_Click(sender As Object, e As EventArgs) Handles Reset.Click
        leftNum.Text = ""
        rightNum.Text = ""
        sign.Text = ""
        showRes.Text = 0
    End Sub

    Private Sub RemoveOne_Click(sender As Object, e As EventArgs) Handles RemoveOne.Click

        ' On supprime le dernier élément entré si le showRes n'est pas égal à 0
        If showRes.Text <> "0" Then

            ' Si il n'y a qu'un chiffre alors on affiche 0, sinon on le supprime
            If showRes.Text.Length = 1 Then
                showRes.Text = 0
            Else
                showRes.Text = showRes.Text.Substring(0, showRes.Text.Length - 1)
            End If
        End If
    End Sub
End Class
