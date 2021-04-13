<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SelectedUserDetails.aspx.cs" Inherits="GRIP_bank.SelectedUserDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <h2 class="text-center pt-4" style="color : black;">Transaction</h2>
        <table class="table table-hover table-sm table-striped table-condensed table-bordered" style="border-color:black;">  
            <tr>  
                <td align="center">  
                    <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>  
                </td>  
            </tr>  
        </table>  
        <br/><br/><br/>
        <table class="table table-hover table-sm table-striped table-condensed table-bordered" style="border-color:black;">
            <tr>
                <td>
                    <label style="color : black;"><b>Transfer To:</b></label>
                    <br />
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="200px"></asp:DropDownList>
                </td>
                <td>
                    <label style="color : black;"><b>Amount:</b></label><br />
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br/><br/><br/>
        <div class="row activity text-center">
            <div class="col-md act">
                <asp:Button ID="Button1" runat="server" Text="Transfer Money" Width="250px" OnClick="Button1_Click"/>
                
            </div>
        </div>
    </div>

</asp:Content>
