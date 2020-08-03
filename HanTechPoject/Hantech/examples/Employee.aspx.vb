Imports System.Data
Imports System.Data.SqlClient

Public Class Employee
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection("Data Source=DESKTOP-J5H1O78;Initial Catalog=HanTechICT; Integrated Security=True;")
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim sdate As DateTime


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '==================================Auto Increament EmpID============================================
        If Not IsPostBack Then
            generateID()
        End If

        '=========================================Connectionkii cadiga aha=================================
        cmd.Connection = con
        cmd.CommandText = "select *from Employee"
        con.Open()
        dr = cmd.ExecuteReader()
        GridViewEmployee.DataSource = dr
        GridViewEmployee.DataBind()
        con.Close()
        display()
    End Sub
    Sub display()
        cmd.Connection = con
        cmd.CommandText = "select *from Employee"
        con.Open()
        dr = cmd.ExecuteReader()
        GridViewEmployee.DataSource = dr
        GridViewEmployee.DataBind()
        con.Close()
    End Sub
    Sub generateID()
        '========================ID Generator==============================
        con.Open()
        Dim Num As Integer
        cmd = New SqlCommand("Select max (EmpID) from Employee", con)
        If IsDBNull(cmd.ExecuteScalar) Then
            Num = 1
            TxtEmpID.Text = Num
        Else
            Num = cmd.ExecuteScalar + 1
            TxtEmpID.Text = Num
        End If
        con.Close()
    End Sub

    Protected Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        '--------------------------------------Insert Employee---------------------------------------
        cmd.Connection = con
        cmd.CommandText = "INSERT INTO  Employee  VALUES (@EmpID,@EmpName,@Phone,@Gmail,@Blood,@EmpAddress,@EmpTitle,@Gender,@Regdete)"
        cmd.Parameters.AddWithValue("@EmpID", TxtEmpID.Text)
        cmd.Parameters.AddWithValue("@EmpName", TxtEmpName.Text)
        cmd.Parameters.AddWithValue("@Phone", TxtPhone.Text)
        cmd.Parameters.AddWithValue("@Gmail", TxtGmail.Text)
        cmd.Parameters.AddWithValue("@Blood", DblBlood.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@EmpAddress", TxtAddress.Text)
        cmd.Parameters.AddWithValue("@EmpTitle", DblEmpTitle.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@Gender", DdlGender.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@Regdete", TxtRDate.Text)
        con.Open()
        cmd.ExecuteNonQuery()
        Response.Write("<script>alert('New Employee Is Added Mahadsanid!')</Script>")
        con.Close()
        display()
        generateID()

    End Sub

    Protected Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        '----------------------------------Update Employee-----------------------------------------
        cmd.Connection = con
        cmd.CommandText = "update  Employee  set EmpName=@EmpName,Phone=@Phone,Gmail=@Gmail,Blood=@Blood,EmpAddress=@EmpAddress,EmpTitle=@EmpTitle,Gender=@Gender,Regdete=@Regdete WHERE EmpID=@EmpID "
        cmd.Parameters.AddWithValue("@EmpID", TxtEmpID.Text)
        cmd.Parameters.AddWithValue("@EmpName", TxtEmpName.Text)
        cmd.Parameters.AddWithValue("@Phone", TxtPhone.Text)
        cmd.Parameters.AddWithValue("@Gmail", TxtGmail.Text)
        cmd.Parameters.AddWithValue("@Blood", DblBlood.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@EmpAddress", TxtAddress.Text)
        cmd.Parameters.AddWithValue("@EmpTitle", DblEmpTitle.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@Gender", DdlGender.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@Regdete", TxtRDate.Text)
        con.Open()
        cmd.ExecuteNonQuery()

        Response.Write("<script>alert('Employee Is Update Mahadsanid!')</Script>")
        con.Close()
        display()


    End Sub

    Protected Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        '----------------------------------Clear Employee--------------------------------------------------------
        TxtEmpID.Text = ""
        TxtEmpName.Text = ""
        TxtPhone.Text = ""
        TxtGmail.Text = ""
        DblBlood.Items.Clear()
        TxtAddress.Text = ""
        DblEmpTitle.Items.Clear()
        DdlGender.Items.Clear()
        TxtRDate.Text = ""


    End Sub

    Protected Sub GridViewEmployee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridViewEmployee.SelectedIndexChanged
        '================================Select Row==================================================
        Dim row As GridViewRow = GridViewEmployee.SelectedRow
        TxtEmpID.Text = row.Cells(1).Text
        TxtEmpName.Text = row.Cells(2).Text
        TxtPhone.Text = row.Cells(3).Text
        TxtGmail.Text = row.Cells(4).Text
        DblBlood.SelectedItem.Text = row.Cells(5).Text
        TxtAddress.Text = row.Cells(6).Text
        DblEmpTitle.SelectedItem.Text = row.Cells(7).Text
        DdlGender.SelectedItem.Text = row.Cells(8).Text
        sdate = row.Cells(9).Text
        TxtRDate.Text = Format(sdate, "yyy-MM-dd")
    End Sub

    Protected Sub BtnDelete_Click(Sender As Object, e As EventArgs) Handles BtnDelete.Click
        '=======================Delete Employee===================================
        cmd.Connection = con
        cmd.CommandText = "DELETE FROM Employee WHERE EmpID=@EmpID ;"
        cmd.Parameters.AddWithValue("@EmpID", TxtEmpID.Text)
        con.Open()
        cmd.ExecuteNonQuery()
        Response.Write("<script>alert('One Employee Is Delete Mahadsanid!')</Script>")
        con.Close()
        display()
    End Sub

    Protected Sub TxtSearch_TextChanged(sender As Object, e As EventArgs) Handles TxtSearch.TextChanged


        '==============================Searching===========================================
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = con
        da.SelectCommand.CommandText = "select *from Employee where EmpName like '" & TxtSearch.Text & "%'"
        da.SelectCommand.Connection = con

        da.Fill(ds, "Employee")
        GridViewEmployee.DataSource = ds.Tables("Employee")
        GridViewEmployee.DataBind()
    End Sub






End Class