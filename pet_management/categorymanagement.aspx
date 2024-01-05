<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="categorymanagement.aspx.cs" Inherits="pet_management.categorymanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="category_id" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" BackColor="#99FF66" BorderColor="#669900">
                    <Columns>
                        <asp:BoundField DataField="category_id" HeaderText="Category id" />
                        <asp:BoundField DataField="cat_name" HeaderText="Category Name" >
                        <ControlStyle ForeColor="#990000" />
                        </asp:BoundField>
                        <asp:ImageField DataImageUrlField="cat_image" HeaderText="category image">
                            <ControlStyle Height="200px" Width="150px" />
                        </asp:ImageField>
                        <asp:BoundField DataField="cat_description" HeaderText="category decription" />
                        <asp:BoundField DataField="cat_status" HeaderText="category status" />
                        <asp:TemplateField HeaderText="Block or unblock">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("category_id") %>' OnCommand="LinkButton2_Command">Click here</asp:LinkButton>
                            </ItemTemplate>
                            <ControlStyle ForeColor="Black" />
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" HeaderText="Edit" >
                        <ControlStyle ForeColor="Black" />
                        </asp:CommandField>
                    </Columns>
                    <EditRowStyle ForeColor="Maroon" />
                </asp:GridView>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/addcategory.aspx" Font-Size="Large">Add category</asp:LinkButton>
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
