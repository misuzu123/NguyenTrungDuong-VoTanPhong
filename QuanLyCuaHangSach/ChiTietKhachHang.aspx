<%@ Page Language="C#" MasterPageFile="~/MasterPage_Admin.master" AutoEventWireup="true" CodeBehind="ChiTietKhachHang.aspx.cs" Inherits="QuanLyCuaHangSach.ChiTietKhachHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            width: 101px;
        }
        .auto-style3 {
            width: 174px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellspacing="1" class="style4">
        <tr>
            <td class="style5" style="background-color: #999900">
                TẤT CẢ SÁCH ĐÃ MUA</td>
        </tr>
        <tr>
            <td> <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <Columns>
                        <asp:BoundField DataField="MaHD" HeaderText="Mã HD" />
                        <asp:BoundField DataField="TenSach" HeaderText="Tên sách" />
                        <asp:BoundField DataField="DonGia" HeaderText="Đơn giá" />
                        <asp:BoundField DataField="SoLuong" HeaderText="Số lượng" />
                        <asp:BoundField DataField="NgayBan" HeaderText="Ngày bán" />
                        <asp:BoundField DataField="TongTien" HeaderText="Tổng tiền" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView></td>
        </tr>
        <tr><td class="style5" style="background-color: #999900">
                <asp:Label ID="lblTongSoTien" runat="server" Font-Bold="True"></asp:Label>
            </td></tr>
    </table>
    
</asp:Content>
