<%@ Page Language="C#" MasterPageFile="~/MasterPage_Admin.master" AutoEventWireup="true" CodeBehind="BanHang.aspx.cs" Inherits="QuanLyCuaHangSach.BanHang" %>

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
            width: 81px;
        }
        .auto-style5 {
            width: 81px;
            height: 14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellspacing="1" class="style3" width="100%">
        <tr>
            <td align="center" colspan="4" 
                style="background-color: #9999FF; font-weight: bold">
                BÁN SÁCH</td>
        </tr>
        <tr>
            <td class="auto-style4">
                Mã hóa đơn:</td>
            <td class="style4">
                <asp:TextBox ID="txtMaHD" runat="server">HD01</asp:TextBox>
                
            </td>
            <td>

            </td>
            <td>
                <asp:TextBox ID="txtTimSach" runat="server"></asp:TextBox>
                <asp:Button ID="btnTimSach" runat="server" onclick="btnTimKiem_Click" 
                    Text="Tìm Kiếm" />
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                Mã sách:</td>
            <td class="style4">
                <asp:TextBox ID="txtMaSach" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style5">
                &nbsp;</td>
            <td>
                
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                Tên sách:</td>
            <td class="style4">
                <asp:TextBox ID="txtTenSach" runat="server" Width="268px" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style5">
                <asp:Label ID="lblAnhSach" runat="server" Text="Image sách:"></asp:Label>
            </td>
            <td rowspan="5">
                <asp:Image ID="imgSach" runat="server" Height="167px" Width="134px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                Tác giả:</td>
            <td class="style4">
                <asp:TextBox ID="txtTacGia" runat="server" Width="268px" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                Khách hàng:</td>
            <td class="style4">
                <asp:DropDownList ID="DDLKhachHang" runat="server">
                </asp:DropDownList>
            </td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                Đơn
                Giá:</td>
            <td class="style4">
                <asp:TextBox ID="txtGia" type="number" runat="server" ReadOnly="True" ></asp:TextBox>
            </td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                Số lượng:</td>
            <td class="style4">
                <asp:TextBox ID="txtSoLuong" type="number" runat="server" >1</asp:TextBox>
            </td>
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
            <td align="center" colspan="4">
                <asp:Button ID="btnBan" runat="server" onclick="btnBan_Click" Text="Bán Hàng" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnRefresh" runat="server" onclick="btnRefresh_Click" Text="Refresh" Width="85px" />
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
                    BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                    CellPadding="2" DataKeyNames="MaSach" 
                    ForeColor="Black" GridLines="None" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged" Width="100%">
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    <Columns>
                        <asp:BoundField DataField="MaSach" HeaderText="Mã sách" />
                        <asp:BoundField DataField="TenSach" HeaderText="Tên sách" />
                        <asp:BoundField DataField="TacGia" HeaderText="Tác giả" />
                        <asp:BoundField DataField="DonGia" HeaderText="Đơn Giá" />
                        <asp:BoundField DataField="SoLuong" HeaderText="Số lượng" />
                        <asp:BoundField DataField="MoTa" HeaderText="Mô tả" />
                        <asp:BoundField DataField="TenFileAnh" HeaderText="Tên File ảnh" Visible="False" />
                        <asp:BoundField DataField="MaLoai" HeaderText="Mã loại" />
                        <asp:CommandField SelectText="Chọn" ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="Tan" />
                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                        HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
