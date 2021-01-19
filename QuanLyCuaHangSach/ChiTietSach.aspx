<%@ Page Language="C#" MasterPageFile="~/MasterPage_TrangChu.master" AutoEventWireup="true" CodeBehind="ChiTietSach.aspx.cs" Inherits="QuanLyCuaHangSach.ChiTietSach" %>

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
                CHI TIẾT SÁCH</td>
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
                                        <td class="style6" rowspan="6">
                                            <asp:Image ID="Image1" runat="server" Height="110px" 
                                                ImageUrl='<%# "~/Images/" + Eval("TenFileAnh") %>' Width="103px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#6600CC" 
                                                Text='<%# Eval("TenSach") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>Tác giả: </strong>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("TacGia") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>NXB: </strong>
                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("TenNXB") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>Năm xuất bản: </strong>
                                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("NamXB") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>Giá bán: </strong>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("DonGia") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>Số lượng hiện có: </strong>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("SoLuong") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table cellspacing="1" class="style4">
                                    <tr>
                                        <td>
                                            <strong>Mô tả sách:<br /> </strong>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("MoTa") %>'></asp:Label>
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
