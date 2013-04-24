<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Views_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    Hello <asp:LoginName ID="LoginName1" runat="server" />!<br /><br />
    <div style="text-align: center">
            <table align="center">
                <tr>
                    <td>
                        <div style="text-align:left">Profile Info:
                            <br /><br />
                            <asp:Image Width="300px" Height="300px" ID="user_photo" runat="server" />
                            <br /><br />

                        </div>
                        <div>
                            <asp:Button ID="ChangeInfo" runat="server" Text="Update My Info" PostBackUrl="~/Views/Private/UpdateProfile.aspx" />
                        </div>
                    </td>
                    <td style="width: 600px; text-align: left">
                        <fieldset>
                            <asp:Label class="form_label" runat="server">Name:</asp:Label><asp:Label ID="name" runat="server" Text="Label"></asp:Label><br /><br />
                            <asp:Label class="form_label" ID="Label1" runat="server">Location:</asp:Label><asp:Label ID="location" runat="server" Text="Label"></asp:Label><br /><br />
                            <asp:Label class="form_label" ID="Label3" runat="server">Email:</asp:Label><asp:Label ID="email" runat="server" Text="Label"></asp:Label>
                        </fieldset>
                    </td>
                </tr>
            </table>
        </div>

</asp:Content>

