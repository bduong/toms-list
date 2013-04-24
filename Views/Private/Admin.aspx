<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Views_Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script type = "text/javascript">

        function showDiv() {
            document.getElementById("div1").style.display = "none";
            document.getElementById("div2").style.display = "none";
            if (document.forms[0].rad1[0].checked) {
                document.getElementById("div1").style.display = "block";
            }
            if (document.forms[0].rad1[1].checked) {
                document.getElementById("div2").style.display = "block";
            }
        }
    </script>
    Hello Admin!<br /><br />
    <div style="text-align:center"><span style="font-size: xx-large">This is the admin page!</span><br /><br /><br /></div>
    <div id="query"; style="display:block; text-align:left">
        Query User:<br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="21px" Width="328px"></asp:TextBox>
        &nbsp;
        <br />
        <br />
        <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="UserId" Width="201px"></asp:ListBox>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TomsListConnString %>" SelectCommand="SELECT [UserId], [Name] FROM [Users] WHERE [Name] = @username" DeleteCommand="DELETE FROM Users">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBox1" DefaultValue=" " Name="username" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Button ID="Deletebutton" runat="server" Text="Delete User" OnClick="Deletebutton_Click" />
        <br /><br />
    </div>
</asp:Content>