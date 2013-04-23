﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.master" AutoEventWireup="true" CodeFile="Notifications.aspx.cs" Inherits="Views_Notifications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

        <script type="text/javascript">
            function previewchat(parameter) {
                __doPostBack('', parameter)
            }
        </script>

        <asp:MultiView ID="notifications_multiview" runat="server">
            <asp:View ID="onenotification_view" runat="server">
                <div class="conversation_window">
                    <asp:Button class="backto_messages" ID="backto_messages" runat="server" OnClick="Button1_Click" Text="Back to Messages" />
                    <br />
                    <asp:Label class="conversation_title" ID="conversation_title" runat="server" Text=""></asp:Label>
                    <br />
                    <div class="conversation_div" id="conversation_div" runat="server">

                    </div>

                </div>
                <!--textarea class="chat_area" id="TextArea1" cols="20" rows="2"></!--textarea><br />
                        <asp:Button ID="Button1" runat="server" Text="Send" />
                    --> 
            </asp:View>
            <asp:View ID="notifications_view" runat="server">
                
                <div class="notification_window" runat="server">
                    <span class="notifications_title">Your recent Notifications</span>
                    <div id="notifications_div" runat="server">

                    </div>
                    
                </div>

                    
                    
            </asp:View>
        </asp:MultiView>

    
</asp:Content>
