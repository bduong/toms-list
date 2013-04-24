<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Views_Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
        function showDiv1(checked) {
            document.getElementById("user").style.display = "none";
            if (checked == 1) {
                document.getElementById("user").style.display = "block";
            }
        }
        function showDiv2(checked) {
            document.getElementById("network").style.display = "none";
            if (checked == 1) {
                document.getElementById("network").style.display = "block";
            }
        }
        function showDiv3(checked) {
            document.getElementById("tags").style.display = "none";
            if (checked == 1) {
                document.getElementById("tags").style.display = "block";
            }
        }
    </script>
    Hello Admin!<br />
    <br />
    <div style="text-align: center"><span style="font-size: xx-large">This is the admin page!</span><br />
        <br />
        <br />
    </div>
    <div>
        <asp:CheckBox ID="UserCheckBox" runat="server" Text="User" onclick="showDiv1(this.checked)" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:CheckBox ID="NetworkCheckBox" runat="server" Text="Network" onclick="showDiv2(this.checked)" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="TagCheckBox" runat="server" Text="Tags" onclick="showDiv3(this.checked)" />
        <table style="table-layout:fixed; width: 100%;">
            <tr>
                <td>
                    <div id="user" style="display: none; text-align: left">
                        <br /><br />
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
                        <br />
                        <br />
                    </div>
                </td>
                <td>
                    <div id="network" style="display: none; text-align: left">
                        <br /><br />
                        Query Network:<br />
                        <br />
                        <asp:TextBox ID="TextBox2" runat="server" Height="21px" Width="328px"></asp:TextBox>
                        &nbsp;
        <br />
                        <br />
                        <asp:ListBox ID="ListBox2" runat="server" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="UserId" Width="201px"></asp:ListBox>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TomsListConnString %>" SelectCommand="SELECT [UserId], [Name] FROM [Users] WHERE [Name] = @username" DeleteCommand="DELETE FROM Users">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="TextBox1" DefaultValue=" " Name="username" PropertyName="Text" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:Button ID="Button1" runat="server" Text="Delete Network" OnClick="Deletebutton_Click" />
                        <br />
                        <br />
                    </div>
                </td>
                <td>
                    <div id="tags" style="display: none; text-align: left">
                        <br /><br />
                        Query Tags:<br />
                        <br />
                        <asp:TextBox ID="TextBox3" runat="server" Height="21px" Width="328px"></asp:TextBox>
                        &nbsp;
                          <br />
                        <br />
                        <asp:ListBox ID="ListBox3" runat="server" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="UserId" Width="201px"></asp:ListBox>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:TomsListConnString %>" SelectCommand="SELECT [UserId], [Name] FROM [Users] WHERE [Name] = @username" DeleteCommand="DELETE FROM Users">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="TextBox1" DefaultValue=" " Name="username" PropertyName="Text" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:Button ID="Button2" runat="server" Text="Delete Tag" OnClick="Deletebutton_Click" />
                        <br />
                        <br />
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
