<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="QRparser.aspx.cs" Inherits="Default2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <div style="margin-left:2%; margin-right:2%;">
    <h1 style="font-size:24px !important; color:white !important; text-align:center;">Customer details</h1>    
    <div class="cls" runat="server" id="MyServerControlDiv"></div>
    </div>
    <div class="cls" runat="server" id="DivInfo"></div>
    <asp:Button ID="BtnProcess" runat="server"  Text="Proc Mor." Style="margin-top:8px;" CssClass="btn btn-primary btn-block" OnClick="BtnProcess_Click" />
    <asp:Button ID="BtnProcess1" runat="server"  Text="Proc Eve." Style="margin-top:8px;" CssClass="btn btn-primary btn-block" OnClick="BtnProcess1_Click" />
    <div class="cls" runat="server" id="DivBtn"></div>
</asp:Content>

