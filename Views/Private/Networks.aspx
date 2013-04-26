<%@ Page Language="C#" MasterPageFile="~/Views/Layout.master" AutoEventWireup="true" CodeFile="Networks.aspx.cs" Inherits="Views_Private_Networks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <table align="center">
        <tr>
            <td style="padding: 30px">
                Search For Networks<br />
                <br />
                <asp:TextBox ID="Network_Search" runat="server" ></asp:TextBox>
                <asp:Button ID="Do_Search" runat="server" Text="Search" OnClick="Do_Search_Click" />
                <br />
                <br />

                <asp:ListBox ID="Results" runat="server" Width="50%" Font-Size="Large"></asp:ListBox><br /><br />
                <asp:Button ID="Join" Text="Join" runat="server"  Visible="false" OnClick="Join_Click" /> 
                <br />
                <br />
                <asp:Label ID="Domain" runat="server" Visible="false"></asp:Label><br /><br />
                <asp:Label ID="Info" runat="server" Text="Enter Email" Visible="false"></asp:Label>
                <br />
                <br />
                <asp:TextBox ID="Email" runat="server" Width="100px" Visible="false" ></asp:TextBox><br />
                <asp:Button ID="Send" Width="100px" runat="server" Text="Send" Visible="false" OnClick="Send_Click" />
                <asp:Button ID="Cancel" Width="100px" runat="server" Text="Cancel" Visible="false" OnClick="Cancel_Click" />
                <br />
                <br />
                <asp:Label ID="ErrorMessage" runat="server"></asp:Label>
            </td>
            <td width="1px" style="background-color: #eee">

            </td>
            <td style="padding: 30px;">
                Add Network:<br />
                <asp:Label ID="name_label" runat="server" Visible="false" Text="Name:"></asp:Label><asp:TextBox ID="addnetwork_name" runat="server" Visible="False"></asp:TextBox><br />
                <asp:Label ID="pattern_label" runat="server" Visible="false" Text="Pattern:"></asp:Label><asp:TextBox ID="addnetwork_pattern" runat="server" Visible="False"></asp:TextBox><br />
                <asp:Label ID="addnetwork_label" runat="server" Text=""></asp:Label>
                <asp:Button ID="addnetwork_button" runat="server" Text="Add Network" Visible="False" OnClick="addnetwork_button_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
