<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Views_Landing" %>

<asp:Content ID="Search" ContentPlaceHolderID="MainContent" Runat="Server">
    Do your search here

    <script type="text/javascript">
        function preview(parameter) {
            __doPostBack('', parameter)
        }
    </script>
    <!--hr id="hr_search"/-->
    <div id="featured-results">
        <asp:MultiView ID="fr_view" runat="server">
            <asp:View ID="view_item" runat="server">
                <table align="center">
                    <tr>
                        <td>
                            <img />
                        </td>
                        <td>
                            <div class="preview_item">
                                <fieldset>
                                    <asp:Label ID="Label1" class="form_label" runat="server" Text="Label">Title: </asp:Label><asp:Label ID="view_item_title" runat="server" Text="Label"></asp:Label><br />
                                    <asp:Label ID="Label3" class="form_label" runat="server" Text="Label">Description: </asp:Label><asp:Label ID="view_item_description" runat="server" Text="Label"></asp:Label><br />
                                    <asp:Label ID="Label4" class="form_label" runat="server" Text="Label">Price: </asp:Label><asp:Label ID="view_item_price" runat="server" Text="Label"></asp:Label><br />
                                    <asp:Label ID="Label2" class="form_label" runat="server" Text="Label">Location: </asp:Label><asp:Label ID="view_item_location" runat="server" Text="Label"></asp:Label><br />
                                    <asp:Label ID="Label5" class="form_label" runat="server" Text="Label">Posting Date: </asp:Label><asp:Label ID="view_item_date" runat="server" Text="Label"></asp:Label><br />
                                    <asp:Label ID="Label6" class="form_label" runat="server" Text="Label">Seller:</asp:Label><asp:Label ID="view_item_user" runat="server" Text="Label"></asp:Label><br /><br />
                                    <asp:Label ID="Label7" class="form_label" runat="server" Text="Label">Contact Seller:</asp:Label>
                                    <textarea id="TextArea1" cols="20" rows="2" runat="server"></textarea>
                                    <asp:Button ID="Button2" runat="server" Text="Button" />
                                </fieldset>
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="view_featured" runat="server">
                featured items will show here
                <table id="table_featured" align="center">
                    <tr>
                        <td id="featured1" class="featured" runat="server">
                            
                        </td>
                        <td id="featured2" class="featured" runat="server">
                        </td>
                        <td id="featured3" class="featured" runat="server">
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="view_results" runat="server">
                <div id="results" runat="server"></div>
            </asp:View>
        </asp:MultiView>
    </div>
    
</asp:Content>

