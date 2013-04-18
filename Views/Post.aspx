<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.master" AutoEventWireup="true" CodeFile="Post.aspx.cs" Inherits="Views_Post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    Post your listing here
    <div id="form_item">
        <table align="center">
            <tr>
                <td>
                    <fieldset>
                        <label for="Title" class="form_label">Title</label><asp:TextBox ID="textbox_title" runat="server" name="Title" class="form_field"></asp:TextBox><br /><br />
                        <label for="Description" class="form_label">Description</label><textarea id="textbox_description" runat="server" name="Description" class="form_field"></textarea><br /><br />
                        <label for="Price" class="form_label">Price</label><asp:TextBox ID="textbox_price" runat="server" name="Price" class="form_field"></asp:TextBox><br /><br />
                        <label for="Location" class="form_label">Location</label><asp:TextBox ID="textbox_location" runat="server" name="Location" class="form_field"></asp:TextBox><br /><br />
                        <label for="Tags" class="form_label">Tags</label><asp:TextBox ID="textbox_tags" runat="server" name="Tags" class="form_field"></asp:TextBox><br /><br />
                        <label for="Tags" class="form_label"></label><asp:Button ID="button_post" runat="server" Text="Post Listing" class="form_button" OnClick="Button1_Click"/>
                    </fieldset>
                </td>
                <td style="background-color: #eee; width: 200px; height: 100px" >
                    Image here
                </td>
            </tr>
        </table>

    </div>
    
    
</asp:Content>

