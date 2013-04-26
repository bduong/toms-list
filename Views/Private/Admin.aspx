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
                    <div id="user" style="display: block; text-align: left">
                        <br /><br />
                        Query User:<br />
                        <br />
                        <asp:TextBox ID="TextBox1" runat="server" Height="21px" Width="328px"></asp:TextBox>
                        &nbsp;
        <br />
                        <asp:Button ID="Usersearch" runat="server" OnClick="User_search" Text="Search" />
                        <br />
                        <br />
                        <asp:ListBox ID="ListBox1" runat="server" Width="201px"></asp:ListBox>
                        <br />
                        <br />
                        <asp:Button ID="Deleteuser" runat="server" Text="Delete User" OnClick="Delete_user" />
                        <br />
                        <br />
                    </div>
                </td>
                <td>
                    <div id="network" style="display: block; text-align: left">
                        <br /><br />
                        Query Network:<br />
                        <br />
                        <asp:TextBox ID="TextBox2" runat="server" Height="21px" Width="328px"></asp:TextBox>
                        &nbsp;
                        <br />
                        <asp:Button ID="Networksearch" runat="server" OnClick="Network_search" Text="Search" />
        <br />
                        <br />
                        <asp:ListBox ID="ListBox2" runat="server" Width="201px"></asp:ListBox>
                        <br />
                        <br />
                        <asp:Button ID="Deletenetwork" runat="server" Text="Delete Network" OnClick="Delete_network" />
                        <br />
                        <br />
                    </div>
                </td>
                <td>
                    <div id="tags" style="display: block; text-align: left">
                        <br /><br />
                        Query Tags:<br />
                        <br />
                        <asp:TextBox ID="TextBox3" runat="server" Height="21px" Width="328px"></asp:TextBox>
                        &nbsp;
                          <br />
                        <asp:Button ID="Tagsearch" runat="server" OnClick="Tag_search" Text="Search" />
                          <br />
                        <br />
                        <asp:ListBox ID="ListBox3" runat="server" Width="201px"></asp:ListBox>
                        <br />
                        <br />
                        <asp:Button ID="Deletetag" runat="server" Text="Delete Tag" OnClick="Delete_tag" />
                        <br />
                        <br />
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
