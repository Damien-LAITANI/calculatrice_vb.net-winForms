Public Class Form1

    ' On utilise cette variable pour vérifier que le 0 affiché a été saisi par l'utilisateur
    Dim isZeroSelected As Boolean = False

    ' On utilise cette variable pour vérifier qu'il n'y ai pas déjà une virgule saisie
    Dim isAlreadyAComma As Boolean = False

    ' Fonction qui renvoie le résultat du calcul
    Function calculate(leftNum, sign, rightNum) As Double

        Dim result As Double
        Select Case sign
            Case "-"
                result = Double.Parse(leftNum) - Double.Parse(rightNum)
            Case "+"
                result = Double.Parse(leftNum) + Double.Parse(rightNum)
            Case "x"
                result = Double.Parse(leftNum) * Double.Parse(rightNum)
            Case "÷"
                result = Double.Parse(leftNum) / Double.Parse(rightNum)
        End Select
        Return result
    End Function

    ' Action au click sur un des boutons de 1 à 9 et des signes de calcules
    Private Sub MultiButton_Click(sender As Object, e As EventArgs) Handles Button5.Click, virgule.Click, Button09.Click, Button08.Click, Button07.Click, Button06.Click, Button05.Click, Button04.Click, Button03.Click, Button02.Click, Button01.Click, Button0.Click

        ' On caste le sender dans le type voulu
        Dim btn As Button = CType(sender, Button)

        ' Si une virgule a déjà été utilisé alors on quitte la procédure, sinon on passe la variable isAlreadyAComma à true
        If btn.Text = "," And isAlreadyAComma Then
            Exit Sub
        ElseIf btn.Text = "," Then
            isAlreadyAComma = True
        End If

        'Si le bouton 0 à été cliqué par l'utilisateur et l'affichage est aussi à 0 on passe la variable à true
        If btn.Text = "0" And showRes.Text = "0" Then
            isZeroSelected = True
        End If

        ' On affiche le chiffre ou nombre sélectionné par l'utilisateur
        If showRes.Text = "0" And Not isZeroSelected And btn.Text IsNot "," Then
            showRes.Text = btn.Text
        ElseIf btn.Text = "0" And showRes.Text = "0" And isZeroSelected Then
            showRes.Text = btn.Text
            isZeroSelected = False
        Else
            showRes.Text += btn.Text
        End If
    End Sub

    Private Sub Assign_sign_Click(sender As Object, e As EventArgs) Handles SubButton.Click, PlusButton.Click, MultiButton.Click, DivButton.Click

        isAlreadyAComma = False
        ' On caste le sender dans le type voulu
        Dim btn As Button = CType(sender, Button)

        ' Si leftNum n'est pas encore assigné
        If leftNum.Text = "" Then
            ' On ajoute le signe au premier nombre
            sign.Text = btn.Text

            ' On place le nombre à calculé dans le label
            leftNum.Text = showRes.Text
            showRes.Text = 0

            ' On continue le calcule après avoir eu un premier résultat
        ElseIf equal.Text = "=" Then
            leftNum.Text = showRes.Text
            showRes.Text = 0
            rightNum.Text = ""
            equal.Text = ""
        ElseIf leftNum.Text <> "" Then
            Dim result = calculate(leftNum.Text, sign.Text, showRes.Text)
            leftNum.Text = result
            sign.Text = btn.Text
            showRes.Text = 0
        End If

    End Sub

    Private Sub Result_Click(sender As Object, e As EventArgs) Handles Result.Click

        isAlreadyAComma = False
        rightNum.Text = showRes.Text
        equal.Text = "="

        Dim result = calculate(leftNum.Text, sign.Text, rightNum.Text)

        showRes.Text = result
    End Sub

    Private Sub Reset_Click(sender As Object, e As EventArgs) Handles Reset.Click
        isAlreadyAComma = False
        leftNum.Text = ""
        equal.Text = ""
        sign.Text = ""
        rightNum.Text = ""
        showRes.Text = 0
    End Sub

    Private Sub RemoveOne_Click(sender As Object, e As EventArgs) Handles RemoveOne.Click

        ' On supprime le dernier élément entré si le showRes n'est pas égal à 0
        If showRes.Text <> "0" Then

            ' Si il n'y a qu'un chiffre alors on affiche 0, sinon on le supprime
            If showRes.Text.Length = 1 Then
                showRes.Text = 0
            Else
                If showRes.Text(showRes.Text.Length - 1) = "," Then
                    isAlreadyAComma = False
                End If
                showRes.Text = showRes.Text.Substring(0, showRes.Text.Length - 1)
            End If
        End If
    End Sub

    Private Sub ResetShow_Click(sender As Object, e As EventArgs) Handles ResetShow.Click
        isAlreadyAComma = False
        showRes.Text = 0

    End Sub
End Class
