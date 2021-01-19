<%@ Page Language="C#" MasterPageFile="~/MasterPage_Admin.master" AutoEventWireup="true" CodeBehind="KhachHang.aspx.cs" Inherits="QuanLyCuaHangSach.KhachHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style3
        {
            width: 100%;
        }
        .style4
        {
            width: 280px;
        }
        .style5
        {
            width: 122px;
        }
        .style6
        {
        }
        .style7
        {
            width: 65px;
            height: 14px;
        }
        .style11
        {
            height: 14px;
        }
        .style12
        {
            width: 280px;
            height: 14px;
        }
        .style13
        {
            width: 122px;
            height: 14px;
        }
        .auto-style4 {
            width: 101px;
        }
        .auto-style5 {
            width: 101px;
            height: 14px;
        }
        .auto-style6 {
            font-weight: bold;
            height: 22px;
        }
        .auto-style7 {
            width: 101px;
            height: 25px;
        }
        .auto-style8 {
            width: 280px;
            height: 25px;
        }
        .auto-style9 {
            width: 122px;
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellspacing="1" class="style3" width="100%">
        <tr>
            <td align="center" colspan="4" 
                style="background-color: #9999FF; " class="auto-style6">
                QUẢN LÝ KHÁCH HÀNG</td>
        </tr>
        <tr>
            <td class="auto-style4">
                Mã khách hàng:</td>
            <td class="style4">
                <asp:TextBox ID="txtMaKH" runat="server"></asp:TextBox>
            </td>
            <td class="style5">
                &nbsp;</td>
            <td>
                <asp:TextBox ID="txtTimKhachHang" runat="server"></asp:TextBox>
                <asp:Button ID="btnTimKiem" runat="server" onclick="btnTimKiem_Click" 
                    Text="Tìm Kiếm" />
            </td>
        </tr>
        <tr>
            <td class="auto-style7">
                Tên khách hàng:</td>
            <td class="auto-style8">
                <asp:TextBox ID="txtHoTen" runat="server" Width="268px"></asp:TextBox>
            </td>
            <td class="auto-style9">
                </td>
            <td class="auto-style9">
                </td>
        </tr>
        <tr>
            <td class="auto-style4">
                Địa chỉ:</td>
            <td class="style4">
                <asp:TextBox ID="txtDiaChi" runat="server" Rows="4" TextMode="MultiLine" 
                    Width="268px"></asp:TextBox>
            </td>
            <td class="style5">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                Điện thoại:</td>
            <td class="style4">
                <asp:TextBox ID="txtDienThoai" type="number" runat="server" ></asp:TextBox>
            </td>
            <td class="style5">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                <asp:Button ID="btnThem" runat="server" onclick="btnThem_Click" Text="Thêm" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnXoa" runat="server" onclick="btnXoa_Click" Text="Xóa" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSua" runat="server" onclick="btnSua_Click" Text="Sửa" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" OnClick="btnRefresh_Click" />
                </td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                <asp:Label ID="lblMessage" runat="server" ForeColor="#CC3300"></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="auto-style5">
            </td>
            <td class="style12">
            </td>
            <td class="style13">
            </td>
            <td class="style11">
            </td>
        </tr>
        <tr>
            <td class="style6" colspan="4">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#999999" BorderWidth="1px" 
                    CellPadding="3" DataKeyNames="MaKH" GridLines="Vertical" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged" Width="100%" BorderStyle="None">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <Columns>
                        <asp:BoundField DataField="MaKH" HeaderText="Mã khách hàng" />
                        <asp:BoundField DataField="HoTen" HeaderText="Tên khách hàng" />
                        <asp:BoundField DataField="DiaChi" HeaderText="Địa chỉ" />
                        <asp:BoundField DataField="DienThoai" HeaderText="Điện thoại" />
                        <asp:CommandField SelectText="Chọn" ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" 
                        HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" ForeColor="White" Font-Bold="True" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
