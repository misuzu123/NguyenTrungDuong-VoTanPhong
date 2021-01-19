<%@ Page Language="C#" MasterPageFile="~/MasterPage_Admin.Master" AutoEventWireup="true" CodeBehind="QuanLyNXB.aspx.cs" Inherits="QuanLyCuaHangSach.QuanLyNXB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style3
        {
            width: 100%;
        }
        .style4
        {
            height: 25px;
        }
        .style5
        {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table cellspacing="1" class="style3" 
        style="padding-right: 150px; padding-left: 150px;" width="100%">
        <tr>
            <td align="center" class="style4" colspan="2" 
                style="background-color: #9999FF; font-weight: bold;">
                QUẢN LÝ NXB SÁCH</td>
        </tr>
        <tr>
            <td class="style5">
                Mã NXB:</td>
            <td>
                <asp:TextBox ID="txtMaNXB" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                Tên NXB:</td>
            <td>
                <asp:TextBox ID="txtTenNXB" runat="server" Width="311px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                Địa Chỉ:</td>
            <td>
                <asp:TextBox ID="txtDiaChi" runat="server" Rows="4" TextMode="MultiLine" 
                    Width="268px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" class="style5" colspan="2">
                <asp:Button ID="btnThem" runat="server" onclick="btnThem_Click" Text="Thêm" />
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnXoa" runat="server" onclick="btnXoa_Click" Text="Xóa" />
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSua" runat="server" onclick="btnSua_Click" Text="Sửa" />
&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;
                </td>
        </tr>
        <tr>
            <td align="center" class="style5" colspan="2">
                <asp:Label ID="lblMessage" runat="server" ForeColor="#CC3300"></asp:Label>
&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;
                </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5" colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" GridLines="Vertical" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged" Width="100%" 
                    DataKeyNames="MaNXB">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <Columns>
                        <asp:BoundField DataField="MaNXB" HeaderText="Mã NXB" />
                        <asp:BoundField DataField="TenNXB" HeaderText="Tên NXB" />
                        <asp:BoundField DataField="DiaChi" HeaderText="Địa Chỉ" />
                        <asp:CommandField SelectText="Chọn" ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
    </table>

</asp:Content>
