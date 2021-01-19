<%@ Page Language="C#" MasterPageFile="~/MasterPage_Admin.master" AutoEventWireup="true" CodeBehind="HoaDon.aspx.cs" Inherits="QuanLyCuaHangSach.HD" %>

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
                DANH SÁCH HÓA ĐƠN</td>
        </tr>
        <tr>
            <td>
    <asp:DataList ID="DataList1" runat="server" Width="100%" BackColor="#FFFFC0" 
    RepeatColumns="5">
    <ItemTemplate>
        <table cellspacing="1" class="style1">
            <tr>
                <td class="style2" rowspan="3">
                </td>
                <td>
                    <strong>Mã hóa đơn: </strong>
                    <asp:HyperLink ID="HyperLink1" runat="server" 
                        NavigateUrl='<%# "ChiTietHD.aspx?MaHD=" + Eval("MaHD") %>' 
                        Text='<%# Eval("MaHD") %>'></asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Tên khách hàng: </strong>
                    <asp:HyperLink ID="HyperLink2" runat="server" 
                        NavigateUrl='<%# "DSKhachHang.aspx?MaKH=" + Eval("MaKH") %>' 
                        Text='<%# Eval("HoTen") %>'></asp:HyperLink>
                </td>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Ngày bán: </strong>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("NgayBan") %>'></asp:Label>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:DataList>
                </td>
            </tr>
            </table>
    </asp:Content>
