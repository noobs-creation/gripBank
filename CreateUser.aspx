<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="GRIP_bank.CreateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="text-center pt-4" style="color : black;">Create a User</h2>
    <br>

    <div class="background">
        <div class="container">
            <div class="screen">
                <div class="screen-header">
                    <div class="screen-header-right">
                        <div class="screen-header-ellipsis"></div>
                        <div class="screen-header-ellipsis"></div>
                        <div class="screen-header-ellipsis"></div>
                    </div>
                </div>
                <div class="screen-body">
                    <div class="screen-body-item left">
                        <img class="img-fluid" src="img/user.jpg" style="border: none; border-radius: 50%;">
                    </div>
                    <div class="screen-body-item">
                        <form class="app-form" method="post">
                            <div class="app-form-group">
                                <asp:TextBox ID="TextBox1" placeholder="ENTER NAME" class="app-form-control" runat="server"></asp:TextBox>
                                <!--<input class="app-form-control" placeholder="NAME" type="text" name="name" required>-->
                            </div>
                            <div class="app-form-group">
                                <asp:TextBox ID="TextBox2" placeholder="ENTER EMAIL" class="app-form-control" runat="server"></asp:TextBox>
                                <!--<input class="app-form-control" placeholder="EMAIL" type="email" name="email" required>-->
                            </div>
                            <div class="app-form-group">
                                <asp:TextBox ID="TextBox3" placeholder="ENTER BALANCE" class="app-form-control" runat="server"></asp:TextBox>
                                <!--<input class="app-form-control" placeholder="BALANCE" type="number" name="balance" required>-->
                            </div>
                            <br>
                            <div class="app-form-group button">
                                <asp:Button ID="Button1" class="app-form-button" runat="server" Text="CREATE" OnClick="Button1_Click" />
                                <asp:Button ID="Button2" class="app-form-button" runat="server" Text="RESET" OnClick="Button2_Click" />
                                <!--<input class="app-form-button" type="submit" value="CREATE" name="submit"></input>
                                <input class="app-form-button" type="reset" value="RESET" name="reset"></input>-->
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
