<%@ Page Language="C#" MasterPageFile="~/Views/Layout.master" CodeFile="GarageSale.aspx.cs" Inherits="Views_Private_GarageSale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function changeImagePreview(uploadControl) {
            if (uploadControl.files && uploadControl.files[0]) {
                var fileReader = new FileReader();
                fileReader.onload = function (x) {
                    document.getElementById('image_preview').setAttribute('src', x.target.result);
                };
                fileReader.readAsDataURL(uploadControl.files[0]);
            } else {
                document.getElementById('image_preview').setAttribute('src', "../../public/img/grey_wash_wall.png");
            }
        }
    </script>
    <div id="form_item">
        Create a new Garage Sale <br />
        <table align="center">
            <tr>
                <td>
                    <fieldset>
                        <label for="Date" class="form_label">Date of Sale</label><br />
                        <%--<asp:TextBox ID="textbox_date" runat="server" name="Date" class="form_field"></asp:TextBox>--%>
                        <asp:Calendar width="100%" ID="date_cal" runat="server"></asp:Calendar>

                        <br />
                        <label for="BeginTime" class="form_label">Begin Time</label><br /><asp:DropDownList ID="begin_time_list" width="100%" runat="server"></asp:DropDownList>
                        <br /><br />
                        <label for="EndTime" class="form_label">End Time</label><asp:DropDownList ID="end_time_list" width="100%" runat="server"></asp:DropDownList><br /><br />
                        <label for="Location" class="form_label">Address</label><textarea ID="textbox_location" runat="server" name="Location" class="form_field"></textarea>
                        <br /><br />
                        <label for="Description" class="form_label">Description</label><textarea id="textbox_description" runat="server" name="Description" class="form_field"></textarea><br /><br />
                        <label for="Image" class="form_label">Image (Optional)</label><asp:FileUpload ID="imageUpload" runat="server" onchange="changeImagePreview(this)"/><br /><br />
                        <asp:Label ID="creategarage_output" runat="server" Text=""></asp:Label><br />
                        <asp:Button ID="button_post" runat="server" Text="List New Garage Sale" class="form_button" OnClick="Button1_Click"/>
                        
                    </fieldset>
                </td>
                <td style="background-color: #eee; width: 200px; height: 100px" >
                    <img id="image_preview" src="../../public/img/grey_wash_wall.png" width="200"/>
                </td>
            </tr>
        </table>

    </div>
</asp:Content>