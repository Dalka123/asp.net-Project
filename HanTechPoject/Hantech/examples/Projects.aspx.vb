Imports System.Data
Imports System.Data.SqlClient
Public Class Projects
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection("Data Source=DESKTOP-J5H1O78;Initial Catalog=HanTechICT; Integrated Security=True;")
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim stdate As DateTime

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
        If Not IsPostBack Then
            sooAqrin()
        End If
        '=======================Connection Cadi Ahaa==================================
        cmd.Connection = con
        cmd.CommandText = "select *from Projects"
        con.Open()
        dr = cmd.ExecuteReader()
        GridViewProjects.DataSource = dr
        GridViewProjects.DataBind()
        con.Close()
        display()

    End Sub
    Sub display()
        cmd.Connection = con
        cmd.CommandText = "select *from Projects"
        con.Open()
        dr = cmd.ExecuteReader()
        GridViewProjects.DataSource = dr
        GridViewProjects.DataBind()
        con.Close()
    End Sub

    Sub sooAqrin()
        '============================ID Soo Aqrin=============================
        cmd.Connection = con
        cmd.CommandText = "select PID from ProjectOrder"
        con.Open()
        dr = cmd.ExecuteReader
        While dr.Read = True
            DblPID.Items.Add(dr(0))
        End While
        dr.Close()
        con.Close()
    End Sub

    Protected Sub DbCategoryName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DbCategoryName.SelectedIndexChanged
        '=====================================CategorName AND Category Type=======================================
        If DbCategoryName.SelectedItem.Text = "Web-Development" Then
            DbCategoryType.Items.Add("School Manegment")
            DbCategoryType.Items.Add("University Manegment")
            DbCategoryType.Items.Add("E-Commerce")
            DbCategoryType.Items.Add("E-Learn")


        ElseIf DbCategoryName.SelectedItem.Text = "Software-Development" Then
            DbCategoryType.Items.Clear()
            DbCategoryType.Items.Add("Software E-Learn")
            DbCategoryType.Items.Add("Software E-Commerce")
            DbCategoryType.Items.Add("Software School Manegment")
            DbCategoryType.Items.Add("Software University Manegment")
        ElseIf DbCategoryName.SelectedItem.Text = "Mobile Application" Then
            DbCategoryType.Items.Clear()
            DbCategoryType.Items.Add("Flater")

        ElseIf DbCategoryName.SelectedItem.Text = "Desktop Application" Then
            DbCategoryType.Items.Clear()
            DbCategoryType.Items.Add("Desk School Manegement")
            DbCategoryType.Items.Add("Desk University")
            DbCategoryType.Items.Clear()
        End If
    End Sub

    Protected Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        '----------------------------Insert Project AND Cash--------------------------------
        cmd.Connection = con
        cmd.CommandText = "INSERT INTO Projects VALUES (@PID,@ProjectName,@CategoryName,@CategoryType,@ToolName,@Amount,@Paid,@Blance,@StartDate,@EndDate,@Date)"
        cmd.Parameters.AddWithValue("@PID", DblPID.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@ProjectName", TxtProjectName.Text)
        cmd.Parameters.AddWithValue("@CategoryName", DbCategoryName.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@CategoryType", DbCategoryType.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@ToolName", DbToolName.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@Amount", TxtAmount.Text)
        cmd.Parameters.AddWithValue("@Paid", TxtPaid.Text)
        cmd.Parameters.AddWithValue("@Blance", TxtBlance.Text)
        cmd.Parameters.AddWithValue("@StartDate", TxtStartDate.Text)
        cmd.Parameters.AddWithValue("@EndDate", TxtEndDate.Text)
        cmd.Parameters.AddWithValue("@Date", TxtDate.Text)
        con.Open()
        cmd.ExecuteNonQuery()
        Response.Write("<script>alert('New Project Added Mahadsandi!')</Script>")
        con.Close()
        display()

    End Sub

    Protected Sub TxtPaid_TextChanged(sender As Object, e As EventArgs) Handles TxtPaid.TextChanged
        Dim Amount As Double = CDbl(TxtAmount.Text)
        Dim paid As Double = CDbl(TxtPaid.Text)
        Dim blance As Double = Amount - paid
        TxtBlance.Text = CStr(blance)
        'TxtBlance.Text = TxtAmount.Text - TxtPaid.Text
    End Sub

    Protected Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        '============================Delete Projects====================================
        cmd.Connection = con
        cmd.CommandText = "DELETE FROM Projects WHERE ProjectName=@ProjectName ;"
        cmd.Parameters.AddWithValue("@ProjectName", TxtProjectName.Text)
        con.Open()
        cmd.ExecuteNonQuery()
        Response.Write("<script>alert('One Project Delete!')</Script>")
        con.Close()
        display()
    End Sub

    Protected Sub GridViewProjects_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridViewProjects.SelectedIndexChanged
        '================================Select Row Projects==================================================
        Dim row As GridViewRow = GridViewProjects.SelectedRow
        DblPID.SelectedItem.Text = row.Cells(1).Text
        TxtProjectName.Text = row.Cells(2).Text
        DbCategoryName.SelectedItem.Text = row.Cells(3).Text
        DbCategoryType.SelectedItem.Text = row.Cells(4).Text
        DbToolName.SelectedItem.Text = row.Cells(5).Text
        TxtAmount.Text = row.Cells(6).Text
        TxtPaid.Text = row.Cells(7).Text
        TxtBlance.Text = row.Cells(8).Text
        stdate = row.Cells(9).Text
        TxtStartDate.Text = Format(stdate, "yyy-MM-dd")
        stdate = row.Cells(10).Text
        TxtEndDate.Text = Format(stdate, "yyy-MM-dd")
        stdate = row.Cells(11).Text
        TxtDate.Text = Format(stdate, "yyy-MM-dd")
    End Sub

    Protected Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        '========================== Clear Projects======================================
        DblPID.SelectedItem.Text = ""
        TxtProjectName.Text = ""
        DbCategoryType.SelectedItem.Text = ""
        DbCategoryType.SelectedItem.Text = ""
        DbToolName.SelectedItem.Text = ""
        TxtAmount.Text = ""
        TxtPaid.Text = ""
        TxtBlance.Text = ""
        TxtStartDate.Text = ""
        TxtEndDate.Text = ""
        TxtDate.Text = ""
    End Sub

    Protected Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        '============================Edit Project============================================
        cmd.Connection = con
        cmd.CommandText = "update Projects  set ProjectName=@ProjectName,CategoryName=@CategoryName,CategoryType=@CategoryType,ToolName=@ToolName,StartDate=@StartDate,EndDate=@EndDate,Date=@Date WHERE PID=@PID "
        cmd.Parameters.AddWithValue("@PID", DblPID.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@ProjectName", TxtProjectName.Text)
        cmd.Parameters.AddWithValue("@CategoryName", DbCategoryName.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@CategoryType", DbCategoryType.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@ToolName", DbToolName.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@StartDate", TxtStartDate.Text)
        cmd.Parameters.AddWithValue("@EndDate", TxtEndDate.Text)
        cmd.Parameters.AddWithValue("@Date", TxtDate.Text)
        con.Open()
        cmd.ExecuteNonQuery()
        Response.Write("<script>alert('Projects Update!')</Script>")
        con.Close()
        display()
    End Sub

    Protected Sub TxtSearch_TextChanged(sender As Object, e As EventArgs) Handles TxtSearch.TextChanged
        '==============================Searching Projects===========================================
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = con
        da.SelectCommand.CommandText = "select *from Projects  where ProjectName like '" & TxtSearch.Text & "%'"
        da.SelectCommand.Connection = con

        da.Fill(ds, "Projects")
        GridViewProjects.DataSource = ds.Tables("Projects")
        GridViewProjects.DataBind()
    End Sub
End Class