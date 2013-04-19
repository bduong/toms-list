<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.master" AutoEventWireup="true" CodeFile="Notifications.aspx.cs" Inherits="Views_Notifications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    See your notifications here
    

        <asp:MultiView ID="notifications_multiview" runat="server">
            <asp:View ID="onenotification_view" runat="server">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Back to Messages" />
            </asp:View>
            <asp:View ID="notifications_view" runat="server">
                <div id="notifications_div" runat="server"></div>
                    
                    
            </asp:View>
        </asp:MultiView>

    
</asp:Content>

