Imports System.Data
Imports System.Data.SqlClient

Public Class Login_Page
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection("Data Source=DESKTOP-J5H1O78;Initial Catalog=HanTechICT; Integrated Security=True;")
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    
    End Sub

    Protected Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        '===================================Login Page Query Parameterized=============================================
        cmd.Connection = con
        cmd.CommandText = " select UserName, Password from Users where UserName=@UserName and Password=@Password"
        cmd.Parameters.AddWithValue("@UserName", TxtUserName.Text)
        cmd.Parameters.AddWithValue("@Password", TxtPassword.Text)
        con.Open()

        dr = cmd.ExecuteReader
        If dr.Read Then
            Response.Redirect("Dashboard.aspx")
        Else
            Response.Write("<script>alert('Invalid UserName & Passwor')</Script>")

        End If

        con.Close()

    End Sub
End Class