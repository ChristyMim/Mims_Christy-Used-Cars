Public Class frmUsedCars
    'Program: Used Cars
    'Programmer: Christy Mims
    'Date: 4/26/17
    'Description: This program allows the user to open, save, close, and display information about cars in the companies
    'inventory. The program does this through the use of a menu strip, a dialog box, a save file dialog box, buttons, and
    'text boxes. The user is also able to add and save new cars to the inventory. 


    Dim index As Integer = 0
    Dim cars(), file_name As String
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Call SaveRecord()
        If index < cars.Count - 1 Then
            index += 1
            Call DisplayRecord()
        End If
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        ' write code to display the previous record
        Call SaveRecord()
        If index > 0 Then
            index = index - 1
            Call DisplayRecord()
        End If
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim new_upper_bound As Integer = cars.GetUpperBound(0) + 1
        ReDim Preserve cars(new_upper_bound)
        Call ClearTextBoxes()
        index = new_upper_bound
    End Sub
    Sub DisplayRecord()

        Dim line As String = cars(index)
        Dim data() As String = line.Split("/"c)
        txtMake.Text = data(0)
        txtModel.Text = data(1)
        txtYear.Text = data(2)
        txtMileage.Text = data(3)
        txtPrice.Text = data(4)

    End Sub
    Sub SaveRecord()
        Dim data(4) As String
        data(0) = txtMake.Text
        data(1) = txtModel.Text
        data(2) = txtYear.Text
        data(3) = txtMileage.Text
        data(4) = txtPrice.Text

        Dim line As String
        line = Join(data, "/"c)
        cars(index) = line
    End Sub
    Sub ClearTextBoxes()
        txtMake.Text = ""
        txtModel.Text = ""
        txtYear.Text = ""
        txtMileage.Text = ""
        txtPrice.Text = ""
        txtMake.Focus()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFileDialog1.ShowDialog()
        file_name = OpenFileDialog1.FileName
        cars = IO.File.ReadAllLines(file_name)
        Call DisplayRecord()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Call ClearTextBoxes()
        file_name = ""
        index = 0
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Call SaveFile(file_name)
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        SaveFileDialog1.ShowDialog()
        Call SaveFile(SaveFileDialog1.FileName)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Dim response As String = MsgBox("Do you want to save the file before closing the program?", 3, "Save file?")
        If response = vbNo Then
            Me.Close()
        ElseIf response = vbYes Then
            Call SaveFile(file_name)
            Me.Close()
        End If
    End Sub

    Sub SaveFile(file As String)
        IO.File.WriteAllLines(file, cars)
    End Sub



    ' ************************************ Menu Items *************************



    ' CODE FOR MENU ITEM "Open" 
    '    OpenFileDialog1.ShowDialog()
    '    file_name = OpenFileDialog1.FileName
    '    contacts = IO.File.ReadAllLines(file_name)
    '    Call DisplayRecord()

    ' CODE FOR MENU ITEM "Close"
    '    Call ClearTextBoxes()
    '    file_name = ""
    '    index = 0


    ' CODE FOR MENU ITEM "Save"
    '    Call SaveFile(file_name)


    ' CODE FOR MENU ITEM "Save As"
    '    SaveFileDialog1.ShowDialog()
    '    Call SaveFile(SaveFileDialog1.FileName)


    ' CODE FOR MENU ITEM "Exit"
    '    Dim response As String = MsgBox("Do you want to save the file before closing the program?", 3, "Save file?")
    '    If response = vbNo Then
    '        Me.Close()
    '    ElseIf response = vbYes Then
    '        Call SaveFile(file_name)
    '        Me.Close()
    '    End If

End Class
