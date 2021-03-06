﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Views_Landing" %>

<asp:Content ID="Search" ContentPlaceHolderID="MainContent" Runat="Server">

    <script type="text/javascript">
        function preview(parameter, number) {
            __doPostBack(number, parameter)
        }

        function tag_double_click(box) {
            var index = box.selectedIndex;
            if (index >= 0) {
                var tag = box.options[index].text;
                if (tag !== "") {
                    window.location = "./Search.aspx?query=" + tag;
                }
            }

        }
    </script>
    <!--hr id="hr_search"/-->
    <div id="featured-results">        
        <asp:MultiView ID="fr_view" runat="server">
            <asp:View ID="view_item" runat="server">
                <button class="form_button" onclick="history.go(-1)">Back</button><br /><br />
                <table align="center">                    
                    <tr>
                        <td>
                            <asp:Image ID="item_image" runat="server" Width="200" Height="200"/><br />
                            <asp:Button class="form_button" ID="update_button" Text="Update Listing" runat="server" OnClick="update_button_Click" /><br /><br />
                            
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
                                    <asp:Label ID="Label3" class="form_label" runat="server" Text="Label">Description: </asp:Label><asp:Label ID="view_item_description" runat="server" Text="Label" Width="300px"></asp:Label><br />
                                    <asp:Label ID="Label4" class="form_label" runat="server" Text="Label">Price: </asp:Label><asp:Label ID="view_item_price" runat="server" Text="Label"></asp:Label><br />
                                    <asp:Label ID="Label2" class="form_label" runat="server" Text="Label">Location: </asp:Label><asp:Label ID="view_item_location" runat="server" Text="Label"></asp:Label><br />
                                    <asp:Label ID="Label5" class="form_label" runat="server" Text="Label">Posting Date: </asp:Label><asp:Label ID="view_item_date" runat="server" Text="Label"></asp:Label><br />
                                    <asp:Label ID="Label6" class="form_label" runat="server" Text="Label">Seller:</asp:Label><asp:Label ID="view_item_user" runat="server" Text="Label"></asp:Label><br />
                                    <asp:Label ID="Label8" class="form_label" runat="server" Text="Label">Tags:</asp:Label><asp:ListBox ID="tags_box" Rows="2" Width="50%" ondblclick="tag_double_click(this)" runat="server"></asp:ListBox><br /><br />
                                    <asp:Label ID="Label7" class="form_label" runat="server" Text="Label">Contact Seller:</asp:Label>
                                    <textarea id="textarea_message" cols="20" rows="3" runat="server" ></textarea>
                                    <asp:Button style="height: 40px;" class="form_button" ID="Button2" runat="server" Text="Send" OnClick="contact_seller"/>
                                    
                                    <asp:Label ID="contact_log" runat="server" Text=""></asp:Label>
                                    
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
                                Apartments
                            </div><br />
                            <div id="featured2" runat="server">

                            </div>
                        </td>
                        <td class="vertical_hr"></td>
                        <td class="featured" valign="top">
                            <div>
                                <asp:Label ID="featured3_header" runat="server" Text="Label">Around You</asp:Label>
                                <asp:DropDownList ID="networks" runat="server" OnSelectedIndexChanged="networks_SelectedIndexChanged" Visible="False" style="width: 100px"></asp:DropDownList> 
                                <asp:Button ID="networks_button" class="side_button" runat="server" Text="Go" Visible="False" OnClick="networks_button_Click" />
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
                            <asp:Button ID="Button4" class="form_button" runat="server" Text="Back to Featured" OnClick="backto_featured"/><br /><br />
                            <div id="results" runat="server"></div>
                        </td>
                    </tr>

                    </table>
            </asp:View>
        </asp:MultiView>
    </div>
    
</asp:Content>

