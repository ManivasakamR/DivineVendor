<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Complaint.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
     <h3 style="text-align:center; font-size:24px;" class="text-primary">New complaint</h3>
     <div style="margin-left:2%; margin-right:2%;">
         <asp:Label ID="LblDesc" runat="server" Style="font-size:20px;" Text="Notification" CssClass="text-primary"></asp:Label>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="valStyle" ErrorMessage="Required" ControlToValidate="TxtAreaComplaint"></asp:RequiredFieldValidator>          
         <br />         
         <asp:TextBox ID="TxtAreaComplaint" runat="server"  style="margin-top:5px; height:300px;" CssClass="txtbx btn-block" TextMode="MultiLine"></asp:TextBox>
         <div class="cls" runat="server" id="MyServerControlDiv"></div>
         <asp:Button ID="BtnRaise" runat="server" Text="Send" CausesValidation="true" OnClick="BtnRaise_Click" Style="margin-top:8px;" CssClass="btn btn-primary btn-block" />
     </div>
</asp:Content>

