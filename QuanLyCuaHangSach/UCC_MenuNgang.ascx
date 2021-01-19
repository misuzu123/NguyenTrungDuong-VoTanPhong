<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCC_MenuNgang.ascx.cs" Inherits="QuanLyCuaHangSach.UCC_MenuNgang" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
</style>

<table cellspacing="1" class="style1">
    <tr>
        <td align="center" style="height: 35px; background-color: #009933;" 
            width="100%">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx" 
                Font-Bold="True" Font-Underline="False" ForeColor="#333399">Trang chủ</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp; |&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink2" runat="server">Giới thiệu</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp; |&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Login.aspx" 
                Font-Bold="True" Font-Underline="False" ForeColor="#333399">Đăng nhập</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp; |&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink4" runat="server">Liên hệ</asp:HyperLink>
        </td>
    </tr>
</table>