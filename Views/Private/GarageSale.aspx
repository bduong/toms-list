<%@ Page Language="C#" MasterPageFile="~/Views/Layout.master" CodeFile="GarageSale.aspx.cs" Inherits="Views_Private_GarageSale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="form_item">
        Create a new Garage Sale <br />
        <table align="center">
            <tr>
                <td>
                    <fieldset>
                        <label for="Date" class="form_label">Date of Sale</label><asp:TextBox ID="textbox_date" runat="server" name="Date" class="form_field"></asp:TextBox><br /><br />
                        <label for="BeginTime" class="form_label">Begin Time</label><asp:TextBox ID="textbox_begin" runat="server" name="BeginTime" class="form_field"></asp:TextBox><br /><br />
                        <label for="EndTime" class="form_label">End Time</label><asp:TextBox ID="textbox_end" runat="server" name="EndTime" class="form_field"></asp:TextBox><br /><br />
                        <label for="Location" class="form_label">Location</label><asp:TextBox ID="textbox_location" runat="server" name="Location" class="form_field"></asp:TextBox><br /><br />
                        <label for="Description" class="form_label">Description</label><textarea id="textbox_description" runat="server" name="Description" class="form_field"></textarea><br /><br />
                        <asp:Label ID="creategarage_output" runat="server" Text=""></asp:Label><br />
                        <label for="Tags" class="form_label"></label><asp:Button ID="button_post" runat="server" Text="List New Garage Sale" class="form_button" OnClick="Button1_Click"/>
                        
                    </fieldset>
                </td>
                <td style="background-color: #eee; width: 200px; height: 100px" >
                    Image here
                </td>
            </tr>
        </table>

    </div>
</asp:Content>