<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCC_AllSachDataList.ascx.cs" Inherits="QuanLyCuaHangSach.UCC_AllSachDataList" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        width: 106px;
    }
</style>

<asp:DataList ID="DataList1" runat="server" Width="100%" BackColor="#FFFFC0" 
    RepeatColumns="3">
    <ItemTemplate>
        <table cellspacing="1" class="style1">
            <tr>
                <td class="style2" rowspan="3">
                    <asp:Image ID="Image1" runat="server" Height="101px" 
                        ImageUrl='<%# "~/Images/" + Eval("TenFileAnh") %>' Width="101px" />
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
                    <strong>Giá bán: </strong>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("DonGia") %>'></asp:Label>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:DataList>