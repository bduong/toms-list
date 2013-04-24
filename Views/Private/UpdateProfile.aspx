<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.master" AutoEventWireup="true" CodeFile="UpdateProfile.aspx.cs" Inherits="Views_UpdateProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <script type="text/javascript">
         function changeImagePreview(uploadControl) {
             if (uploadControl.files && uploadControl.files[0]) {
                 var fileReader = new FileReader();
                 fileReader.onload = function (x) {
                     document.getElementById('MainContent_user_photo').setAttribute('src', x.target.result);
                 };
                 fileReader.readAsDataURL(uploadControl.files[0]);
             } else {
                 document.getElementById('MainContent_user_photo').setAttribute('src', "../../public/img/grey_wash_wall.png");
             }
         }
    </script>
    Hello <asp:LoginName ID="LoginName1" runat="server" />!<br /><br />
    <div style="text-align: center">
        <table align="center">
            <tr>
                <td>
                    <div style="text-align:left">Profile Info:
                        <br /><br />
                        <asp:Image Width="300px" Height="300px" ID="user_photo" runat="server" /> <br /> <br />
                        <asp:FileUpload ID="imageUpload" runat="server" onchange="changeImagePreview(this)"/><br />
                    </div>
                </td>
                <td style="width: 600px; text-align: left">
                    <div>
                        <fieldset>
                            <asp:Label class="form_label" runat="server">Name:</asp:Label><asp:Label ID="NameLabel" runat="server" Text="Label"></asp:Label><br /><br />
                            <asp:Label class="form_label" runat="server">Location:</asp:Label><asp:TextBox ID="LocationTextBox" runat="server"></asp:TextBox><br /><br />
                            <asp:Label class="form_label" runat="server">Email:</asp:Label><asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox><br /><br />
                            <asp:Label ID="Label1" class="form_label" runat="server"> </asp:Label><asp:Button ID="ChangePassword" runat="server" Text="Change My Password" PostBackUrl="~/Views/Private/ChangePassword.aspx" /><br /><br />
                            <asp:Label ID="Label2" class="form_label" runat="server"> </asp:Label><asp:Button ID="ChangeInfo" runat="server" Text="Update My Info" OnClick="ChangeInfo_Click" /><br /><br />
                        </fieldset>
                        
                </td>
            </tr>
        </table>


</asp:Content>

