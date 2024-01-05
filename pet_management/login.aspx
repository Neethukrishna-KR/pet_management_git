<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="pet_management.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        width: 226px;
    }
    .auto-style2 {
        width: 168px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="Black" Text="UserName"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label2" runat="server" Font-Size="Large" ForeColor="Black" Text="Password"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBox2" runat="server" CssClass="offset-sm-0" TextMode="Password"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style1">
                <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" Font-Size="Large" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style1">
                <asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style1">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/userreg.aspx">Do Not Have an Account?</asp:HyperLink>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Font-Size="Large" ForeColor="Black" Text="User"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style1">
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/adminreg.aspx">Do Not Have an Account?</asp:HyperLink>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Font-Size="Large" Text="Admin" ForeColor="Black"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
