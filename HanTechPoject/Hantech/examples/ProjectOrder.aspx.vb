Imports System.Data
Imports System.Data.SqlClient

Public Class ProjectOrder
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection("Data Source=DESKTOP-J5H1O78;Initial Catalog=HanTechICT; Integrated Security=True;")
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim stade As DateTime
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Generate()
        End If

        '========================================Connection cadiga aha===============================
        cmd.Connection = con
        cmd.CommandText = "Select *from ProjectOrder"
        con.Open()
        dr = cmd.ExecuteReader()
        GridViewProjectOrder.DataSource = dr
        GridViewProjectOrder.DataBind()

        con.Close()

        display()


    End Sub
    Sub display()
        cmd.Connection = con
        cmd.CommandText = "Select *from ProjectOrder"
        con.Open()
        dr = cmd.ExecuteReader()
        GridViewProjectOrder.DataSource = dr
        GridViewProjectOrder.DataBind()
        con.Close()
    End Sub
    Sub Generate()
        '==================================Auto Increament PID============================================
        con.Open()
        Dim Num As Integer
        cmd = New SqlCommand("Select max (PID) from ProjectOrder", con)
        cmd.ExecuteNonQuery()

        If IsDBNull(cmd.ExecuteScalar) Then
            Num = 1
            TxtPID.Text = Num
        Else
            Num = cmd.ExecuteScalar + 1
            TxtPID.Text = Num
        End If
        con.Close()
    End Sub

    Protected Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
      
        '=======================================Insert ProjectOrder================================================
        cmd.Connection = con
        cmd.CommandText = "INSERT INTO  ProjectOrder VALUES (@PID,@FulName,@Phone,@Gmail,@Gender,@Address,@Regdate)"
        cmd.Parameters.AddWithValue("@PID", TxtPID.Text)
        cmd.Parameters.AddWithValue("@FulName", TxtFullName.Text)
        cmd.Parameters.AddWithValue("@Phone", TxtPhone.Text)
        cmd.Parameters.AddWithValue("@Gmail", TxtGmail.Text)
        cmd.Parameters.AddWithValue("@Gender", DdlGender.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@Address", TxtAddress.Text)
        cmd.Parameters.AddWithValue("@Regdate", TxtRDate.Text)
        con.Open()
        cmd.ExecuteNonQuery()
        Response.Write("<script>alert('New Project Order Aded Mahadsanid!')</Script>")
        con.Close()
        display()
        Generate()

    End Sub

    Protected Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        '============================================Update ProjectOrder==========================================================
        cmd.Connection = con
        cmd.CommandText = "update  ProjectOrder  set FulName=@FulName,Phone=@Phone,Gmail=@Gmail,Gender=@Gender,Address=@Address,Regdate=@Regdate WHERE PID=@PID "
        cmd.Parameters.AddWithValue("@PID", TxtPID.Text)
        cmd.Parameters.AddWithValue("@FulName", TxtFullName.Text)
        cmd.Parameters.AddWithValue("@Phone", TxtPhone.Text)
        cmd.Parameters.AddWithValue("@Gmail", TxtGmail.Text)
        cmd.Parameters.AddWithValue("@Gender", DdlGender.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@Address", TxtAddress.Text)
        cmd.Parameters.AddWithValue("@Regdate", TxtRDate.Text)
        con.Open()
        cmd.ExecuteNonQuery()
        Response.Write("<script>alert('Project Orde Update Mahadsanaid!')</Script>")
        con.Close()
        display()
    End Sub

    Protected Sub GridViewProjectOrder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridViewProjectOrder.SelectedIndexChanged
        '==============================SelectRow ProjectOrder===================================
        Dim row As GridViewRow = GridViewProjectOrder.SelectedRow
        TxtPID.Text = row.Cells(1).Text
        TxtFullName.Text = row.Cells(2).Text
        TxtPhone.Text = row.Cells(3).Text
        TxtGmail.Text = row.Cells(4).Text
        DdlGender.SelectedItem.Text = row.Cells(5).Text
        TxtAddress.Text = row.Cells(6).Text
        stade = row.Cells(7).Text
        TxtRDate.Text = Format(stade, "yyy-MM-dd")
    End Sub

    Protected Sub BtnDelete_Click(Sender As Object, e As EventArgs) Handles BtnDelete.Click
        '=======================Delete Project Order===================================
        cmd.Connection = con
        cmd.CommandText = "DELETE FROM ProjectOrder WHERE PID=@PID ;"
        cmd.Parameters.AddWithValue("@PID", TxtPID.Text)
        con.Open()
        cmd.ExecuteNonQuery()
        Response.Write("<script>alert('Project Order Delete Mahadsanid!')</Script>")
        con.Close()
        display()
    End Sub

    Protected Sub TxtSearch_TextChanged(sender As Object, e As EventArgs) Handles TxtSearch.TextChanged
        '==============================Searching===========================================
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = con
        da.SelectCommand.CommandText = "select *from ProjectOrder  where FulName like '" & TxtSearch.Text & "%'"
        da.SelectCommand.Connection = con

        da.Fill(ds, "ProjectOrder")
        GridViewProjectOrder.DataSource = ds.Tables("ProjectOrder")
        GridViewProjectOrder.DataBind()
    End Sub

    Protected Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        '===============================Clear Project Order===================================
        TxtPID.Text = ""
        TxtFullName.Text = ""
        TxtPhone.Text = ""
        TxtGmail.Text = ""
        DdlGender.SelectedItem.Text = ""
        TxtAddress.Text = ""
        TxtRDate.Text = ""

    End Sub
End Class