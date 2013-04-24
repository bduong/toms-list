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
                 var id = document.getElementById('MainContent_original_image_id').getAttribute('Value');
                 document.getElementById('MainContent_user_photo').setAttribute('src', "../../Helpers/GetImage.ashx?ID=" + id);
             }
         }
    </script>
    <asp:HiddenField ID="original_image_id" runat="server" />
    Hello <asp:LoginName ID="LoginName1" runat="server" />!<br /><br />
    <div style="text-align:left">Profile Info:<br /><br /><br />
        You:<br /><br />
        <asp:FileUpload ID="imageUpload" runat="server" onchange="changeImagePreview(this)"/><br />
        <asp:Image Width="300px" Height="300px" ID="user_photo" runat="server" />
        <br /><br /><br /><br />
        Name: 
        <asp:Label ID="NameLabel" runat="server" Text="Label"></asp:Label>
        <br /><br />
        Location: 
        <asp:TextBox ID="LocationTextBox" runat="server"></asp:TextBox>
        <br /><br />
        E-mail: 
        <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="ChangePassword" runat="server" Text="Change My Password" PostBackUrl="~/Views/Private/ChangePassword.aspx" />
    </div>
            <br /><br />
    <div>
        <asp:Button ID="ChangeInfo" runat="server" Text="Update My Info" OnClick="ChangeInfo_Click" />
        <br /><br />
    </div>
</asp:Content>

