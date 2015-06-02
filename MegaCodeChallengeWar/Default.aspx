<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MegaCodeChallengeWar.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-family: Arial, Helvetica, sans-serif;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1 class="auto-style1">Play War!</h1>
    
    </div>
        <p>
            <asp:Button ID="playButton" runat="server" OnClick="playButton_Click" Text="Play" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
