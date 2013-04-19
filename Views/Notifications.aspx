<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.master" AutoEventWireup="true" CodeFile="Notifications.aspx.cs" Inherits="Views_Notifications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    See your notifications here
        <script type="text/javascript">
            function previewchat(parameter) {
                __doPostBack('', parameter)
            }
        </script>

        <asp:MultiView ID="notifications_multiview" runat="server">
            <asp:View ID="onenotification_view" runat="server">
                one message
                <div id="conversation_div" runat="server">

                </div>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Back to Messages" />
            </asp:View>
            <asp:View ID="notifications_view" runat="server">
                all messages
                <div id="notifications_div" runat="server">

                </div>
                    
                    
            </asp:View>
        </asp:MultiView>

    
</asp:Content>

