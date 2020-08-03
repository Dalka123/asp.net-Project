Imports System.Data
Imports System.Data.SqlClient
Public Class ProjectLoan
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection("Data Source=DESKTOP-J5H1O78;Initial Catalog=HanTechICT; Integrated Security=True;")
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            DisplayLoan()
        End If




    End Sub
    Sub display()
        cmd.Connection = con
        cmd.CommandText = "select *from Projects"
        con.Open()
        dr = cmd.ExecuteReader()
        GridViewpProjectLoan.DataSource = dr
        GridViewpProjectLoan.DataBind()
        con.Close()
    End Sub

    Sub DisplayLoan()
        '============================Inner Join=============================
        cmd.Connection = con
        cmd.CommandText = "select  c.PID,c.FulName, c.Phone ,a.ProjectName , a.Amount ,a.Paid, a.Blance from ProjectOrder c INNER JOIN Projects a ON c.PID=A.PID where a.Blance>0"


        con.Open()
        dr = cmd.ExecuteReader()
        GridViewpProjectLoan.DataSource = dr
        GridViewpProjectLoan.DataBind()
        con.Close()
    End Sub
    Protected Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        Dim Blance As Double
        '===========================Update Projects=================================
        cmd.Connection = con
        cmd.CommandText = "update Projects  set Paid=@Paid,Blance=@Blance WHERE PID=@PID "
        cmd.Parameters.AddWithValue("@PID", TxtPID.Text)
        cmd.Parameters.AddWithValue("@Paid", TxtPaid.Text)
        Blance = TxtBlance.Text - TxtPaid.Text
        cmd.Parameters.AddWithValue("@Blance", Blance)
        con.Open()
        cmd.ExecuteNonQuery()
        Response.Write("<script>alert('Project Loan Update Mahadsanid!')</Script>")
        con.Close()
        DisplayLoan()

    End Sub

    Protected Sub GridViewpProjectLoan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridViewpProjectLoan.SelectedIndexChanged
        '================================Select Row Projects==================================================
        Dim row As GridViewRow = GridViewpProjectLoan.SelectedRow
        TxtPID.Text = row.Cells(1).Text
        TxtOrderName.Text = row.Cells(2).Text
        TxtPhone.Text = row.Cells(3).Text
        TxtProjectName.Text = row.Cells(4).Text
        TxtAmount.Text = row.Cells(5).Text
        TxtPaid.Text = row.Cells(6).Text
        TxtBlance.Text = row.Cells(7).Text
    End Sub

    Protected Sub TxtPaid_TextChanged(sender As Object, e As EventArgs) Handles TxtPaid.TextChanged
        '====================Calculation Paid===============================
        'TxtPaid.Text = TxtPaid.Text + TxtPaid.Text
       

    End Sub

    Protected Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        '========================Clear ProjectLoan===============================
        TxtPID.Text = ""
        TxtOrderName.Text = ""
        TxtPhone.Text = ""
        TxtProjectName.Text = ""
        TxtAmount.Text = ""
        TxtPaid.Text = ""
        TxtBlance.Text = ""

    End Sub
End Class