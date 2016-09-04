<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="AmeriaPaymentTest._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to AmeriaVPOS example
    </h2>
    <div>
       <div> OrderID:<asp:TextBox ID="txtOrderID" runat="server"></asp:TextBox>(Should be unque, please change)</div>
       <div> Amount:<asp:TextBox ID="txtAmount" runat="server"></asp:TextBox></div>
    </div>
    <asp:Button ID="btnExecTransaction" runat="server" 
    Text="Execute Transaction" onclick="btnExecTransaction_Click" />
    <asp:Button ID="btnGetPaymentFields" runat="server" 
    Text="Get Transaction Status" onclick="btnGetPaymentFields_Click" />
    <asp:Button ID="btnConfirmTransaction" runat="server" 
    Text="Confirm Transaction" onclick="btnConfirmTransaction_Click" />
    <asp:Button ID="btnReverseTransaction" runat="server" 
    Text="Reverse Transaction" onclick="btnReverseTransaction_Click" />
    <asp:Button ID="btnRefundTransaction" runat="server" 
    Text="Refund Transaction" onclick="btnRefundTransaction_Click" />
    <div>
        <asp:Literal ID="ltMessage" runat="server"></asp:Literal>
    </div>
</asp:Content>
