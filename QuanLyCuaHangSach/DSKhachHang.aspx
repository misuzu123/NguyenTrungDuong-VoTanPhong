<%@ Page Language="C#" MasterPageFile="~/MasterPage_Admin.master" AutoEventWireup="true" CodeBehind="DSKhachHang.aspx.cs" Inherits="QuanLyCuaHangSach.DSKhachHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            width: 101px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellspacing="1" class="style4">
        <tr>
            <td align="center" colspan="4" 
                style="background-color: #9999FF; font-weight: bold">
                DANH SÁCH KHÁCH HÀNG</td>
        </tr>
        <tr>
            <td>
    <asp:DataList ID="DataList1" runat="server" Width="100%" BackColor="#FFFFC0" 
    RepeatColumns="5">
    <ItemTemplate>
        <table cellspacing="1" class="style1">
            <tr>
                <td class="style2" rowspan="5">
                </td>
                <td>
                    <strong>Mã khách hàng: </strong>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("MaKH") %>'></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Tên khách hàng: </strong>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("HoTen") %>'></asp:Label>
                </td>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Địa chỉ: </strong>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("DiaChi") %>'></asp:Label>
                </td>
            </tr>
             <tr>
                <td>
                    <strong>Điện thoại: </strong>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("DienThoai") %>'></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" 
                        NavigateUrl='<%# "ChiTietKhachHang.aspx?MaKH=" + Eval("MaKH") %>' 
                        Text="Xem các hóa đơn"></asp:HyperLink>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:DataList>
                </td>
            </tr>
            </table>
    </asp:Content>
