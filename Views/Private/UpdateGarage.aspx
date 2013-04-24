<%@ Page Language="C#"  MasterPageFile="~/Views/Layout.master" AutoEventWireup="true" CodeFile="UpdateGarage.aspx.cs" Inherits="Views_Private_UpdateGarage" %>

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
            if (confirm('Are you sure you want to delete this Garage Sale?')) {
                var button = document.getElementById('MainContent_do_delete');
                button.click();
            }
        }
    </script>
    <div id="form_item">
        <table align="center">
            <tr>
                <td>Garage Sale: </td>
                <td><asp:Label ID="listing_id" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    
                    <fieldset>
                        <asp:HiddenField ID="original_imageid" runat="server" />     
                        <label for="Date" class="form_label">Date of Sale</label><br />
                        <asp:Calendar width="100%" ID="date_cal" runat="server"></asp:Calendar>
                        <br />
                        <label for="BeginTime" class="form_label">Begin Time</label><br /><asp:DropDownList ID="begin_time_list" width="100%" runat="server"></asp:DropDownList>
                        <br /><br />
                        <label for="EndTime" class="form_label">End Time</label><asp:DropDownList ID="end_time_list" width="100%" runat="server"></asp:DropDownList><br /><br />
                        <label for="Location" class="form_label">Address</label><textarea ID="textbox_location" runat="server" name="Location" class="form_field"></textarea>
                        <br /><br />
                        <label for="Description" class="form_label">Description</label><textarea id="textbox_description" runat="server" name="Description" class="form_field"></textarea><br /><br />
                        <label for="Image" class="form_label">Image (Optional)</label><asp:FileUpload ID="imageUpload" runat="server" onchange="changeImagePreview(this)"/><br /><br />
                        <asp:Label ID="updategarage_output" runat="server" Text=""></asp:Label><br />
                        <asp:Button ID="button_post" runat="server" Text="Update Garage Sale" class="form_button" OnClick="Update_Click"/>
                        <br />
                        <br />
                        <button id="confirm_delete" runat="server" class="form_button" onclick="confirmDelete()">Delete Garage Sale</button><br />
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
