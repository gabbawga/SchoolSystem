<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SchoolManagementSystem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>School Management System</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.0.0.min.js"></script>
    <script src="../Scripts/popper.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>

    <style>
        html, body {
            height: 100%;
        }

        .login-container {
            display: flex;
            height: 100vh;
        }

        .login-image {
            flex: 1;
            background-image: url('/Image/OF18H90.jpg');
            background-size: cover;
            background-position: center;
        }

        .login-form {
            flex: 1;
            display: flex;
            align-items: center;
            justify-content: center;
            padding: 40px;
        }

        .form-box {
            width: 100%;
            max-width: 400px;
        }

            .form-box h2 {
                margin-bottom: 30px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">

            <div class="login-image">
            </div>

            <div class="login-form">
                <div class="form-box">

                    <h2 class="text-center">Login</h2>
                    <div>
                        <asp:Label ID="lblMsg" runat="server" CssClass="mt-10"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label for="txtUsuario">Usuário</label>
                        <input type="text" id="txtUsuario" runat="server" class="form-control" placeholder="Digite seu usuário" />
                    </div>

                    <div class="form-group">
                        <label for="txtSenha">Senha</label>
                        <input type="password" id="txtSenha" runat="server" class="form-control" placeholder="Digite sua senha" />
                    </div>

                    <div class="form-group text-center mt-4">
                        <asp:Button ID="btnEntrar" runat="server" CssClass="btn btn-primary btn-block" Text="Entrar" OnClick="btnEntrar_Click" />
                    </div>

                    <asp:Label ID="lblMensagem" runat="server" CssClass="text-danger text-center d-block mt-2" />
                </div>
            </div>

        </div>
    </form>
</body>
</html>


