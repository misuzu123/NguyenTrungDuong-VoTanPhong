<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCC_TheLoaiSach.ascx.cs" Inherits="QuanLyCuaHangSach.UCC_TheLoaiSach" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        width: 3%;
    }
</style>
<asp:GridView ID="GridView1" runat="server" Width="100%" 
    AutoGenerateColumns="False" EnableModelValidation="True" 
    ShowHeader="False">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <table cellspacing="1" class="style1">
                    <tr>
                        <td class="style2" style="background-color: #CCCCFF">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/icon_list1.gif" />
                        </td>
                        <td style="background-color: #CCCCFF" width="100%">
                            <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="False" 
                                NavigateUrl='<%# "SachTheoTheLoai.aspx?MaLoai=" + Eval("MaLoai") %>' 
                                Text='<%# Eval("TenLoai") %>'></asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>