<%@ Page Language="C#"  MasterPageFile="~/Views/Layout.master" AutoEventWireup="true" CodeFile="UpdatePost.aspx.cs" Inherits="Views_Private_UpdatePost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script type="text/javascript">
        function changeImagePreview(uploadControl) {
            if (uploadControl.files && uploadControl.files[0]) {
                var fileReader = new FileReader();
                fileReader.onload = function (x) {
                    document.getElementById('MainContent_image_preview').setAttribute('src', x.target.result);
                };
                fileReader.readAsDataURL(uploadControl.files[0]);
            } else {
                var id = document.getElementById('MainContent_original_imageid').getAttribute('Value');
                document.getElementById('MainContent_image_preview').setAttribute('src', "../../Helpers/GetImage.ashx?ID=" + id);
            }
        }

        function confirmDelete() {
            if (confirm('Are you sure you want to Delete This Listing?')) {
                var button = document.getElementById('MainContent_do_delete');
                button.click();
            }
        }
    </script>
    <div id="form_item">
        <table align="center">
            <tr>
                <td>Listing: </td>
                <td><asp:Label ID="listing_id" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <fieldset>
                        <asp:HiddenField ID="original_imageid" runat="server" />                        
                        <label for="Title" class="form_label">Title</label><asp:TextBox ID="textbox_title" runat="server" name="Title" class="form_field"></asp:TextBox><br /><br />
                        <label for="Description" class="form_label">Description</label><textarea id="textbox_description" runat="server" name="Description" class="form_field"></textarea><br /><br />
                        <label for="Price" class="form_label">Price</label><asp:TextBox ID="textbox_price" runat="server" name="Price" class="form_field"></asp:TextBox><br /><br />
                        <label for="Location" class="form_label">Location</label><asp:TextBox ID="textbox_location" runat="server" name="Location" class="form_field"></asp:TextBox><br /><br />
                        <label for="Tags" class="form_label">Tags</label><asp:TextBox ID="textbox_tags" runat="server" name="Tags" class="form_field"></asp:TextBox><br /><br />
                        <label for="Image" class="form_label">Image (Optional)</label><asp:FileUpload ID="imageUpload" runat="server" onchange="changeImagePreview(this)"/><br /><br />
                        <asp:Label ID="addlisting_output" runat="server" Text=""></asp:Label><br />
                        <asp:Button ID="button_post" runat="server" Text="Update Listing" class="form_button" OnClick="Update_Click"/>
                        <br />
                        <br />
                        <button id="confirm_delete" runat="server" class="form_button" onclick="confirmDelete()">Delete Listing</button><br />
                        <div style="display: none">
                            <asp:Button ID="do_delete" runat="server" class="form_button" OnClick="do_delete_Click" />
                        </div>

                    </fieldset>
                </td>
                <td style="background-color: #eee; width: 200px; height: 100px" >                   
                    <asp:Image ID="image_preview" runat="server" Width="200" />
                </td>
            </tr>
        </table>

    </div>
    
    
</asp:Content>
