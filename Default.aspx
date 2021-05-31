<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Report_Tracker_Website.Defualt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shabel Group Login</title>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-BmbxuPwQa2lc/FVzBcNJ7UAyJxM6wuqIj61tLrc4wSX0szH/Ev+nYRRuWlolflfl" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/js/bootstrap.bundle.min.js" integrity="sha384-b5kHyXgcpbZJO/tY9Ul7kGkf1S0CWuKcCD38l8YkeH8z8QjE0GmW1gYU5S9FOnJ0" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.0/css/all.css" integrity="sha384-lZN37f5QGtY3VHgisS14W3ExzMWZxybE1SJSEsQp9S+oqd12jhcu+A56Ebc1zFSJ" crossorigin="anonymous">
    <script src="https://use.fontawesome.com/b4e4cb56ff.js"></script>
    <script src="Scripts/jquery-1.10.2.js"></script>
     <script type="text/javascript" src="cookie.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link href="CSS/ShabelStyle.css" rel="stylesheet" />

    <style type="text/css">
        .auto-style2 {
            width: 323px;
        }
    </style>
    <script type="text/javascript">  
        $(document).ready(function () {  
            $('#show_password').hover(function show() {  
                //Change the attribute to text  
                $('#psswrd').attr('type', 'text');  
                $('.icon').removeClass('fa fa-eye-slash').addClass('fa fa-eye');  
            },  
            function () {  
                //Change the attribute back to password  
                $('#psswrd').attr('type', 'password');  
                $('.icon').removeClass('fa fa-eye').addClass('fa fa-eye-slash');  
            });  
            //CheckBox Show Password  
            $('#ShowPassword').click(function () {  
                $('#Password').attr('type', $(this).is(':checked') ? 'text' : 'password');  
            });  
        });  
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="row d-flex">
            <table class="table-size">
                <tr>
                    <td class="row-cols-2" colspan="2">
                        <asp:Image ID="Image1" runat="server" class="mx-auto d-block" Height="250px" ImageAlign="Middle" ImageUrl="~/images/shabellogo.png" />
                    </td>
                </tr>
                <tr>
                    <td class="row-cols-1">
                        <label for="user" style="text-align: right;">Username: &nbsp;</label>
                    </td>
                    <td class="row-cols-1">
                        <asp:TextBox ID="user" CssClass="textbox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="row-cols-1">
                        <label for="psswrd" style="text-align: right;">Password: &nbsp;</label>
                    </td>
                    <td class="row-cols-1">
                        <asp:TextBox ID="psswrd" CssClass="textbox" runat="server"></asp:TextBox><button id="show_password" class="hide-button" style="width: 30px; height: 30px; vertical-align: middle;"  type="button"><span class="fa fa-eye-slash icon" style="align-content: center;"></span></button>
                    </td>
                </tr>
                <tr>
                    <td class="row-cols-2" colspan="2" style="min-height: 12px;">&nbsp;</td>
                </tr>
                <tr>
                    <td class="row-cols-2" colspan="2" align="center">
                        <asp:Button ID="login" runat="server" Text="Log In" OnClick="login_Click" OnItemCommand="LogIn" CssClass="button login-button"  />
                    </td>
                </tr>
            </table>
          </div>
    </form>
</body>
</html>
