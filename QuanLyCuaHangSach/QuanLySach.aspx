<%@ Page Language="C#" MasterPageFile="~/MasterPage_Admin.master" AutoEventWireup="true" CodeBehind="QuanLySach.aspx.cs" Inherits="QuanLyCuaHangSach.QuanLySach" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style3
        {
            width: 100%;
        }
        .style4
        {
            width: 300px;
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
            width: 300px;
            height: 14px;
        }
        .style13
        {
            width: 122px;
            height: 14px;
        }
        .auto-style3 {
            margin-bottom: 3px;
        }
        .auto-style4 {
            height: 51px;
        }
        .auto-style5 {
            width: 280px;
            height: 51px;
        }
        .auto-style6 {
            width: 122px;
            height: 51px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellspacing="1" class="style3" width="100%">
        <tr>
            <td align="center" colspan="4" 
                style="background-color: #9999FF; font-weight: bold">
                QUẢN LÝ SÁCH</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                <asp:TextBox ID="txtTimSach" runat="server" CssClass="auto-style3"></asp:TextBox>
            </td>
            <td class="style5">
                <asp:Button ID="btnTimSach" runat="server" onclick="btnTimSach_Click" 
                    Text="Tìm Sách" />
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                Mã sách:</td>
            <td class="auto-style5">
                <asp:TextBox ID="txtMaSach" runat="server">Sach01</asp:TextBox>
            </td>
            <td class="auto-style6">
                &nbsp;</td>
            <td class="auto-style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                Tên sách:</td>
            <td class="style4">
                <asp:TextBox ID="txtTenSach" runat="server" Width="231px"></asp:TextBox>
            </td>
            <td class="style5">
                Chọn Image sách:</td>
            <td class="style5">
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Button ID="btnUploadAnh" runat="server" onclick="btnUploadAnh_Click" 
                    Text="Upload ảnh" />
            </td>
            
        </tr>
        <tr>
            <td class="style6">
                Tác giả:</td>
            <td class="style4">
                <asp:TextBox ID="txtTacGia" runat="server" Width="231px"></asp:TextBox>
            </td>
            <td class="style5">
                <asp:Label ID="lblAnhSach" runat="server" Text="Image sách:"></asp:Label>
            </td>
            <td rowspan="5" class="style5">
                <asp:Image ID="imgSach" runat="server" Height="167px" Width="134px" />
            </td>
        </tr>
        <tr>
            <td class="style6">
                NXB:</td>
            <td class="style4">
                <asp:DropDownList ID="DDLNXB" runat="server" OnSelectedIndexChanged="DDLTheLoai_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td class="style5">
                <asp:TextBox ID="txtTenFileAnh" runat="server" Width="81px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style6">
                Năm XB:</td>
            <td class="style4">
                <asp:TextBox ID="txtNamXB" type="number" runat="server" ></asp:TextBox>
            </td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                Đơn
                Giá:</td>
            <td class="style4">
                <asp:TextBox ID="txtGia" type="number" runat="server" ></asp:TextBox>
            </td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                Số lượng:</td>
            <td class="style4">
                <asp:TextBox ID="txtSoLuong" type="number" runat="server" ></asp:TextBox>
            </td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                Mô tả:</td>
            <td class="style4">
                <asp:TextBox ID="txtMoTa" runat="server" Rows="4" TextMode="MultiLine" 
                    Width="268px"></asp:TextBox>
            </td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                Thể loại:</td>
            <td class="style4">
                <asp:DropDownList ID="DDLTheLoai" runat="server" OnSelectedIndexChanged="DDLTheLoai_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td class="style5">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
            </td>
            <td class="style12">
            </td>
            <td class="style13">
            </td>
            <td class="style13">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                <asp:Button ID="btnThem" runat="server" onclick="btnThem_Click" Text="Thêm" Width="65px" />
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnXoa" runat="server" onclick="btnXoa_Click" Text="Xóa" Width="65px" />
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSua" runat="server" onclick="btnSua_Click" Text="Sửa" Width="65px" />
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" OnClick="btnRefresh_Click" Width="65px" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                </td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                <asp:Label ID="lblMessage" runat="server" ForeColor="#CC3300"></asp:Label>
&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;
                </td>
        </tr>
        <tr>
            <td class="style7">
            </td>
            <td class="style12">
            </td>
            <td class="style13">
            </td>
            <td class="style13">
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
                        <asp:BoundField DataField="MaNXB" HeaderText="Mã NXB" />
                        <asp:BoundField DataField="NamXB" HeaderText="Năm XB" />
                        <asp:BoundField DataField="DonGia" HeaderText="Đơn Giá" />
                        <asp:BoundField DataField="SoLuong" HeaderText="Số lượng" />
                        <asp:BoundField DataField="MoTa" HeaderText="Mô tả" />
                        <asp:BoundField DataField="TenFileAnh" HeaderText="Tên File ảnh" />
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
