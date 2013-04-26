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
        <div style="text-align: center">
                <asp:Button ID="Button1" runat="server" Text="Explore Around You" OnClick="Button1_Click1" /> <span> </span>
                <asp:Button ID="Button2" runat="server" Text="Setup Your Own" OnClick="Button2_Click" />
                <asp:Button ID="Button3" runat="server" Text="Edit Existing Garage Sales" OnClick="Button3_Click" />
        </div>

            <asp:MultiView ID="garagesale_view" runat="server">
                
                <asp:View ID="view_viewgarage" runat="server">
                    
                    <div id="viewgarage_title">
                        Garage Sales Around You
                    </div>
                    <table align="center">
                        <tr>
                            <td>

                                <div id="garagesales" runat="server">

                                </div>
                            </td>
                        </tr>
                    </table>

                </asp:View>
                <asp:View ID="view_creategarage" runat="server">
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
                </asp:View>
                <asp:View ID="view_editgarage" runat="server">

                    List of your garage sales here
                    <script type="text/javascript">
                        function editgarage(parameter, number) {
                            __doPostBack(parameter, parameter)
                        }
                    </script>
                    <table align="center">
                        <tr>
                            <td>
                                <div id="your_garages" runat="server">
                                            
                                </div>
                            </td>
                        </tr>
                    </table>

                </asp:View>
            </asp:MultiView>
        

    </div>
</asp:Content>