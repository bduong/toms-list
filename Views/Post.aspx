<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.master" AutoEventWireup="true" CodeFile="Post.aspx.cs" Inherits="Views_Post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    Post your listing here
    <div id="form_item">
        <table align="center">
            <tr>
                <td>
                    <fieldset>
                        <label for="Title" class="form_label">Title</label><asp:TextBox ID="textbox_title" runat="server" name="Title" class="form_field"></asp:TextBox><br /><br />
                        <label for="Description" class="form_label">Description</label><textarea id="TextArea1" name="Description" class="form_field"></textarea><br /><br />
                        <label for="Price" class="form_label">Price</label><asp:TextBox ID="textbox1" runat="server" name="Price" class="form_field"></asp:TextBox><br /><br />
                        <label for="Location" class="form_label">Location</label><asp:TextBox ID="textbox2" runat="server" name="Location" class="form_field"></asp:TextBox><br /><br />
                        <label for="Tags" class="form_label">Tags</label><asp:TextBox ID="textbox3" runat="server" name="Tags" class="form_field"></asp:TextBox><br /><br />
                        <label for="Tags" class="form_label"></label><asp:Button ID="Button1" runat="server" Text="Post Listing" class="form_button"/>
                    </fieldset>
                </td>
                <td style="background-color: #eee; width: 200px; height: 100px" >
                    Image here
                </td>
            </tr>
        </table>

    </div>
    
    
</asp:Content>

