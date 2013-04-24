<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Views_Landing" %>

<asp:Content ID="Search" ContentPlaceHolderID="MainContent" Runat="Server">

    <script type="text/javascript">
        function preview(parameter, number) {
            __doPostBack(number, parameter)
        }
    </script>
    <!--hr id="hr_search"/-->
    <div id="featured-results">        
        <asp:MultiView ID="fr_view" runat="server">
            <asp:View ID="view_item" runat="server">
                <button onclick="history.go(-1)">Back</button><br /><br />
                <table align="center">                    
                    <tr>
                        <td>
                            <asp:Button ID="update_button" Text="Update Listing" runat="server" /><br /><br />
                            <asp:Image ID="item_image" runat="server" Width="200" Height="200"/>
                        </td>
                        <td>
                            <div class="preview_item">
                                <!--
                                <asp:Button ID="Button1" runat="server" Text="Back To Search" OnClick="backto_search"/>
                                -->
                                
                                <fieldset>
                                    <asp:HiddenField ID="view_item_userid" runat="server" />
                                    <asp:HiddenField ID="view_item_listingid" runat="server" />
                                    <asp:Label ID="Label1" class="form_label" runat="server" Text="Label">Title: </asp:Label><asp:Label ID="view_item_title" runat="server" Text="Label"></asp:Label><br />
                                    <asp:Label ID="Label3" class="form_label" runat="server" Text="Label">Description: </asp:Label><asp:Label ID="view_item_description" runat="server" Text="Label"></asp:Label><br />
                                    <asp:Label ID="Label4" class="form_label" runat="server" Text="Label">Price: </asp:Label><asp:Label ID="view_item_price" runat="server" Text="Label"></asp:Label><br />
                                    <asp:Label ID="Label2" class="form_label" runat="server" Text="Label">Location: </asp:Label><asp:Label ID="view_item_location" runat="server" Text="Label"></asp:Label><br />
                                    <asp:Label ID="Label5" class="form_label" runat="server" Text="Label">Posting Date: </asp:Label><asp:Label ID="view_item_date" runat="server" Text="Label"></asp:Label><br />
                                    <asp:Label ID="Label6" class="form_label" runat="server" Text="Label">Seller:</asp:Label><asp:Label ID="view_item_user" runat="server" Text="Label"></asp:Label><br /><br />
                                    <asp:Label ID="Label7" class="form_label" runat="server" Text="Label">Contact Seller:</asp:Label>
                                    <textarea id="textarea_message" cols="20" rows="2" runat="server"></textarea>
                                    <asp:Label ID="contact_log" runat="server" Text=""></asp:Label>
                                    <asp:Button ID="Button2" runat="server" Text="Send" OnClick="contact_seller"/>
                                </fieldset>
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="view_featured" runat="server">
                <span>Featured Items</span>
                <br /><br />
                <table id="table_featured" align="center">
                    <tr>
                        <td class="featured" valign="top">
                            <div>
                                Recently Posted
                            </div> <br />
                            <div id="featured1" runat="server">

                            </div>
                        </td>
                        <td class="vertical_hr"></td>
                        <td class="featured" valign="top">
                            <div>
                                Appartments
                            </div><br />
                            <div id="featured2" runat="server">

                            </div>
                        </td>
                        <td class="vertical_hr"></td>
                        <td class="featured" valign="top">
                            <div>
                                Around You
                            </div><br />
                            <div id="featured3" runat="server">

                            </div>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="view_results" runat="server">
                <table id="table_results" align="center">
                    <tr>
                        <td>
                            <asp:Button ID="Button4" runat="server" Text="Back to Featured" OnClick="backto_featured"/><br /><br />
                            <div id="results" runat="server"></div>
                        </td>
                    </tr>

                    </table>
            </asp:View>
        </asp:MultiView>
    </div>
    
</asp:Content>

