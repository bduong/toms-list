<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Views_Landing" %>

<asp:Content ID="Search" ContentPlaceHolderID="MainContent" Runat="Server">
    Do your search here
    <div id="search">
        <asp:TextBox ID="search_box" runat="server"></asp:TextBox><span> </span><asp:Button ID="Button1" runat="server" Text="Button" OnClick="search"/>
    </div>
    <!--hr id="hr_search"/-->
    <div id="featured-results">
        <asp:MultiView ID="fr_view" runat="server">
            <asp:View ID="view_featured" runat="server">
                <table id="table_featured" align="center">
                    <tr>
                        <td class="featured">&nbsp;</td>
                        <td class="featured"></td>
                        <td class="featured"></td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="view_results" runat="server">
                <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
            </asp:View>
        </asp:MultiView>
    </div>
    
</asp:Content>

