<%@ Page Title="" Language="C#" MasterPageFile="~/Radical.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <h2>Login <small>Radical Courier Service</small></h2>
    <hr class="colorgraph" />

    <div class="container">
        <%--To learn more about bundling scripts in ScriptManager see http://go.microsoft.com/fwlink/?LinkID=301884 --%>
        <label><b>Username</b></label>
        <div class="input-group">
            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
            <asp:TextBox ID="tx_user" runat="server" class="form-control" placeholder="UserName/Email" required></asp:TextBox><br />
        </div>

        <%--Framework Scripts--%>
        <label><b>Password</b></label>
        <div class="input-group">
            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
            <asp:TextBox ID="tx_password" runat="server" class="form-control" placeholder="Password" required TextMode="Password"></asp:TextBox>
        </div>

        <br />
        <div class="input-group">
            <%--<asp:Button ID="btn_login" class="btn btn-success" runat="server" Text="Login" OnClick="btn_login_Click" />--%>
            <asp:Button ID="btn_login" class="btn btn-link" runat="server" Text="Sign In" OnClick="btn_login_Click" /> |
            <asp:Button ID="btn_SignUp" class="btn btn-link" runat="server" Text="Sign Up" OnClientClick="window.location='Registration.aspx';" />|
            <asp:LinkButton ID="btn_PasswordRecovery" class="btn btn-link" runat="server" OnClick="btn_PasswordRecovery_Click">Forget Password ?</asp:LinkButton>
            <%--<button  onclick="document.getElementById('id01').style.display='block'" style="width: auto;"></button>--%>
        </div>

        <%--Site Scripts--%>

<%--        <div>
            <h4>New User</h4>
            <button class=" btn btn-info" onclick="document.getElementById('id01').style.display='block'" style="width: auto;">Register</button>
        </div>--%>

    </div>

    <%-- Mymodal for Information --%>

    <div class="modal fade" id="myModal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Information</h4>
                </div>
                <div class="modal-body" style="text-align: center">
                    <h1>
                        <asp:Label ID="lb_reg_result" runat="server" Text=""></asp:Label>
                    </h1>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">
                        Close</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <%-- MyModal for Password  --%>
    <div class="modal fade" id="mdl-password">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Forgot Password?</h4>
                </div>
                <div class="modal-body" style="text-align: center">

                    <p>You can reset your password here.</p>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-envelope"></i></span>
                        <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="UserName/Email"></asp:TextBox><br />
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">
                        Close</button>
                    <button type="button" class="btn btn-primary" data-dismiss="modal">
                        Submit</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <button type="button" style="display: none;" id="btnShowPopup" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#myModal">
        Launch demo modal</button>
    <button type="button" style="display: none;" id="btnpassword" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#mdl-password">
        Launch demo modal</button>

    <!--Validation--> 
        <script type="text/javascript">
            function ShowPopup() {
                $("#btnShowPopup").click();
            }

            function ShowPassword() {
                $("#btnpassword").click();
            }

            function Redirect() {
                window.location = "~/Registration.aspx";
            }

            $(document).ready(function () {
                for (i = 1; i <= 6; i++) {
                    if (i != 6) {
                        $('#' + i).removeClass('active');
                    }
                    else {
                        $('#' + 6).addClass('active');
                    }
                }
            }); 

        </script>

</asp:Content>

