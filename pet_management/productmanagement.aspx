<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="productmanagement.aspx.cs" Inherits="pet_management.productmanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="product_id" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                    <Columns>
                        <asp:BoundField DataField="cat_name" HeaderText="category" />
                        <asp:BoundField DataField="pro_name" HeaderText="product name" />
                        <asp:BoundField DataField="pro_price" HeaderText="product price" />
                        <asp:ImageField DataImageUrlField="pro_image" HeaderText="product image">
                        </asp:ImageField>
                        <asp:BoundField DataField="pro_description" HeaderText="product description" />
                        <asp:BoundField DataField="pro_status" HeaderText="product status" />
                        <asp:BoundField DataField="pro_stock" HeaderText="product stock" />
                        <asp:TemplateField HeaderText="block or unblock">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton3" runat="server" OnCommand="LinkButton3_Command" Text="click here" CommandArgument='<%# Eval("product_id") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField HeaderText="edit" ShowEditButton="True" />
                    </Columns>
                    <EmptyDataTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" Text='<%# Eval("cat_id") %>'></asp:LinkButton>
                    </EmptyDataTemplate>
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
            <td class="auto-style1">
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/addproduct.aspx">Add products</asp:LinkButton>
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
            <td>&nbsp;</td>
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
