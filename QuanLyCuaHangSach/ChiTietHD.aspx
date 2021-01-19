<%@ Page Language="C#" MasterPageFile="~/MasterPage_Admin.master" AutoEventWireup="true" CodeBehind="ChiTietHD.aspx.cs" Inherits="QuanLyCuaHangSach.ChiTietHD" %>

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
            <td class="style5" style="background-color: #999900">
                CHI TIẾT HÓA ĐƠN</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    EnableModelValidation="True" ShowHeader="False" Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <table class="style4" width="100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#6600CC" 
                                                Text='<%# Eval("MaHD") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>Tên Sách: </strong>
                                            <asp:HyperLink ID="HyperLink1" runat="server" 
                                             NavigateUrl='<%# "ChiTietSach.aspx?MaSach=" + Eval("MaSach") %>' 
                                             Text='<%# Eval("TenSach") %>'></asp:HyperLink>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>Đơn giá: </strong>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("DonGia") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>Số lượng: </strong>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("SoLuong") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>Tổng tiền: </strong>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("TongTien") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
