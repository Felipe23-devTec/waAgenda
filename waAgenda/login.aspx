<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="waAgenda.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .login-label {
            width: 92px;
            margin-left: 3px;
        }
    </style>
</head>
<body style="height: 652px">
    <form id="form1" runat="server">
        <div style="width: 438px; height: 313px; margin-left: 403px; margin-top: 168px;">
            <p class="login-label">Faça login</p>
            
            <p>Email</p>
            <p><asp:TextBox ID="email" runat="server" Width="336px" Height="21px"></asp:TextBox>
            </p>
            <p >Senha</p>
            <p ><asp:TextBox ID="senha" runat="server" Width="336px" Height="24px"></asp:TextBox></p>
            <p >
                <asp:Button ID="btnLogar" runat="server" OnClick="btnLogar_Click" Text="Logar" />
            </p>
            <p >
                <asp:Label ID="message" runat="server"></asp:Label>
            </p>
        </div>
        
    </form>
</body>
</html>
