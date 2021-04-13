<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GRIP_bank._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row intro py-1" style="background-color: #C86DFB;">
            <div class="col-sm-12 col-md">
                <div class="heading text-center my-5">
                    <h2>Welcome to</h2>
                    <h1>TSF Bank</h1>
                </div>
            </div>
            <div class="col-sm-12 col-md img text-center">
                <img src='<%=ResolveUrl("~/img/bank.jpg") %>' class="img-fluid pt-2">
            </div>
        </div>

        <div class="row activity text-center">
            <div class="col-md act">
                <img src='<%=ResolveUrl("~/img/user.jpg") %>' alt="userimg" class="img-fluid">
                <br>
                <asp:Button ID="Button1" style="background-color: #C86DFB;" runat="server" Text="Create User" OnClick="Button1_Click" />
                
            </div>

            <div class="col-md act">
                <img src='<%=ResolveUrl("~/img/transfer.jpg") %>' alt="transferimg" class="img-fluid">
                <br>
                <asp:Button ID="Button2" style="background-color: #C86DFB;" runat="server" Text="Make a Transaction" OnClick="Button2_Click" />
                
            </div>

            <div class="col-md act">
                <img src='<%=ResolveUrl("~/img/history.jpg") %>' alt="historyimg" class="img-fluid">
                <br>
                <asp:Button ID="Button3" style="background-color: #C86DFB;" runat="server" Text="Transaction History" OnClick="Button3_Click" />

            </div>

        </div>

    </div>

</asp:Content>
