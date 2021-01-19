<%@ Page Language="C#" MasterPageFile="~/MasterPage_TrangChu.master" AutoEventWireup="true" CodeBehind="SachTheoTheLoai.aspx.cs" Inherits="QuanLyCuaHangSach.SachTheoTheLoai" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            width: 100px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellspacing="1" class="style4" width="100%">
        <tr>
            <td class="style5" style="background-color: #999900">
                <asp:Label ID="lblTongSoSach" runat="server" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="DataList1" runat="server" BackColor="#FFFFC0" 
                    RepeatColumns="3" Width="100%">
                    <ItemTemplate>
                        <table cellspacing="1" class="style4">
                            <tr>
                                <td class="style6" rowspan="4">
                                    <asp:Image ID="Image1" runat="server" Height="109px" 
                                        ImageUrl='<%# "~/Images/" + Eval("TenFileAnh") %>' Width="103px" />
                                </td>
                                <td>
                                    <asp:HyperLink ID="HyperLink1" runat="server" 
                                        NavigateUrl='<%# "ChiTietSach.aspx?MaSach=" + Eval("MaSach") %>' 
                                        Text='<%# Eval("TenSach") %>'></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>Tác giả: </strong>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("TacGia") %>'></asp:Label>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <strong>NXB: </strong>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("TenNXB") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>Giá bán: </strong>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("DonGia") %>'></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>
</asp:Content>

