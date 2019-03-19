<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
   <title>Login</title>
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
        <asp:Label ID="LblLogin" runat="server" Style="font-size:24px; margin-left:43%;" Text="Register" CssClass="text-primary"></asp:Label><br />
        <asp:Label ID="LblUsername" runat="server" Style="font-size:20px;" Text="Username" CssClass="text-primary"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="valStyle" ErrorMessage="Required" ControlToValidate="TxtUsername"></asp:RequiredFieldValidator> 
            <br />
        <asp:TextBox ID="TxtUsername" runat="server"  CssClass="txtbx btn-block"></asp:TextBox>
        <asp:Label ID="LblEmail" runat="server" Text="Email" Style="font-size:20px;" CssClass="text-primary"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="valStyle" ErrorMessage="Required" ControlToValidate="TxtEmail"></asp:RequiredFieldValidator> 
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="valStyle" ErrorMessage="Invalid" ControlToValidate="TxtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>            
            <br />
        <asp:TextBox ID="TxtEmail" runat="server" CssClass="txtbx btn-block"></asp:TextBox>
        <asp:Label ID="LblMobile" runat="server" Style="font-size:20px;" Text="Mobile Number" CssClass="text-primary"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="valStyle" ErrorMessage="Required" ControlToValidate="TxtMobile"></asp:RequiredFieldValidator> 
            <asp:RegularExpressionValidator ControlToValidate = "TxtMobile" CssClass="valStyle" ID="RegularExpressionValidator2" ValidationExpression = "^[\s\S]{10,10}$" runat="server" ErrorMessage="Must be 10 digits"></asp:RegularExpressionValidator>
            <br />
        <asp:TextBox ID="TxtMobile" runat="server"  CssClass="txtbx btn-block"></asp:TextBox>
        <asp:Label ID="LblAddress" runat="server" Text="Address" Style="font-size:20px;" CssClass="text-primary"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="valStyle" ErrorMessage="Required" ControlToValidate="TxtAddress"></asp:RequiredFieldValidator>             
            <br />
        <asp:TextBox ID="TxtAddress" Style="height:150px;" runat="server" CssClass="txtbx btn-block" TextMode="MultiLine"></asp:TextBox>                
        <asp:Label ID="LblPin" runat="server" Style="font-size:20px;" Text="Pincode" CssClass="text-primary"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" CssClass="valStyle" ErrorMessage="Required" ControlToValidate="TxtPin"></asp:RequiredFieldValidator> 
            <asp:RegularExpressionValidator ControlToValidate = "TxtPin" CssClass="valStyle" ID="RegularExpressionValidator5" ValidationExpression = "^[\s\S]{6,6}$" runat="server" ErrorMessage="Must be 6 disits"></asp:RegularExpressionValidator>
            <br />
        <asp:TextBox ID="TxtPin" runat="server"  CssClass="txtbx btn-block"></asp:TextBox>        
        <asp:Label ID="LblPassword" runat="server" Style="font-size:20px;" Text="Password" CssClass="text-primary"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" CssClass="valStyle" ErrorMessage="Required" ControlToValidate="TxtPassword"></asp:RequiredFieldValidator>            
                        <asp:RegularExpressionValidator ControlToValidate = "TxtPassword" CssClass="valStyle" ID="RegularExpressionValidator6" ValidationExpression = "^[\s\S]{8,16}$" runat="server" ErrorMessage="Minimum 8 characters"></asp:RegularExpressionValidator>
            <br />
        <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" CssClass="txtbx btn-block"></asp:TextBox>        
        <asp:Label ID="LblCpassword" runat="server" Style="font-size:20px;" Text="Confirm Password" CssClass="text-primary"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" CssClass="valStyle" ErrorMessage="Required" ControlToValidate="TxtCpassword"></asp:RequiredFieldValidator> 
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TxtCpassword" CssClass="valStyle" ControlToCompare="TxtPassword" ErrorMessage="No match" ToolTip="Password must be the same" />
            <br />
        <asp:TextBox ID="TxtCpassword" runat="server" TextMode="Password" CssClass="txtbx btn-block"></asp:TextBox>        
            <div class="cls" runat="server" id="MyServerControlDiv"></div>
        <asp:Button ID="BtnRegister" runat="server" Text="Register" CausesValidation="true" OnClick="BtnRegister_Click1" Style="margin-top:8px;" CssClass="btn btn-primary btn-block" />        
        <asp:Button ID="BtnBack" runat="server" Text="Back" CausesValidation="false" OnClick="BtnBack_Click" Style="margin-top:3px;" CssClass="btn btn-block btn-primary"/>
    </form>
        </div>
    </div>    
</body>
</html>
