<%@ Page Title="" Language="C#" MasterPageFile="~/Site4.Master" AutoEventWireup="true" CodeBehind="ordersummary.aspx.cs" Inherits="pet_management.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
    <tr>
        <td>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="pro_name" HeaderText="Product Name" />
                    <asp:ImageField DataImageUrlField="pro_image" HeaderText="product image">
                    </asp:ImageField>
                    <asp:BoundField DataField="quantity" HeaderText="quantity" />
                    <asp:BoundField DataField="total_price" HeaderText="Price" />
                    <asp:BoundField DataField="status" HeaderText="status" />
                </Columns>
            </asp:GridView>
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="place order" />
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
