<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>Divine milks-Vendors</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />         
    <link rel="stylesheet" href="Site/site.css" type="text/css" />    
    <script src="Scripts/jquery-3.0.0.js" type="text/javascript"></script>                                     
    <script src="Scripts/bootstrap.js" type="text/javascript"></script> 
    <script src="Site/SomeeAdsRemover.js"  type="text/javascript"></script>
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
  <a class="navbar-brand" href="#">
     <img src="Images/logo1.png" width="30" height="30" class="rounded-circle" alt=""/>
    Divine milk 
  </a>
</nav>
    <div class="row">
        <div class=" container-fluid" style="margin-left:2%; margin-right:2%;">
        <form id="form1" runat="server">
        <asp:Label ID="LblLogin" runat="server" Style="font-size:24px; margin-left:47%;" Text="Login" CssClass="text-primary"></asp:Label><br />
        <asp:Label ID="LblUsername" runat="server" Style="font-size:20px;" Text="Email" CssClass="text-primary"></asp:Label>                    
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="valStyle" ErrorMessage="Required" ControlToValidate="TxtUsername"></asp:RequiredFieldValidator> 
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="valStyle" ErrorMessage="Invalid" ControlToValidate="TxtUsername" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><br />
        <asp:TextBox ID="TxtUsername" runat="server" OnTextChanged="TxtUsername_TextChanged" BackColor="" CssClass="txtbx btn-block"></asp:TextBox>                                               
        <asp:Label ID="LblPassword" runat="server" Text="Password" Style="font-size:20px;" CssClass="text-primary"></asp:Label>
            <asp:RegularExpressionValidator ControlToValidate = "TxtPassword" CssClass="valStyle" ID="RegularExpressionValidator3" ValidationExpression = "^[\s\S]{8,16}$" runat="server" ErrorMessage="Minimum 8 characters"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="valStyle" ErrorMessage="Required" ControlToValidate="TxtPassword"></asp:RequiredFieldValidator> <br />                   
        <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" CssClass=" txtbx btn-block"></asp:TextBox>                            
            <div class="cls" runat="server" id="MyServerControlDiv"></div>
        <asp:Button ID="BtnLogin" runat="server"  CausesValidation="true" Text="Login" OnClick="btnlogin_Click" Style="margin-top:8px;" CssClass="btn btn-primary btn-block" />
        <asp:Button ID="BtnRegister" runat="server" CausesValidation="false" Text="Register" OnClick="btnRegister_Click" Style="margin-top:3px;" CssClass="btn btn-block btn-primary"/>
    </form>
        </div>
    </div>    
</body>
</html>
