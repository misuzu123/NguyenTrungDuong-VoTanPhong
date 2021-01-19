<%@ Page Language="C#" MasterPageFile="~/MasterPage_TrangChu.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="QuanLyCuaHangSach.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellspacing="3" class="style1" 
            style= width="100%">
            <tr>
                <td align="center" class="style2" colspan="2" 
                    style="background-color: #9999FF; font-weight: bold;">
                    ĐĂNG NHẬP TRANG QUẢN TRỊ&nbsp;</td>
            </tr>
            <tr>
                <td class="style4" colspan="2" >
                    <strong>Vui lòng nhập tên tài khoản và mật khẩu bên dưới!</strong></td>
            </tr>
            <tr>
                <td class="auto-style1">
                    Tên đăng nhập:</td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtUserName" ErrorMessage="Chưa nhập tên đăng nhập!">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    Mật khẩu:</td>
                <td>
                    <asp:TextBox type="password" ID="txtPassword" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtPassword" ErrorMessage="Chưa nhập mật khẩu!">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnDangNhap" runat="server" onclick="btnDangNhap_Click" 
                        Text="Đăng nhập" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
            </tr>
            <tr>
                <td class="style3" colspan="2" >
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="style3" colspan="2" >
                    <asp:Label ID="lblMessage" runat="server" ForeColor="#CC3300"></asp:Label>
                </td>
            </tr>
        </table>
</asp:Content>

