<%@ Page Language="C#" MasterPageFile="~/MasterPage_TrangChu.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="QuanLyCuaHangSach.Default" %>

<%@ Register src="UCC_AllSachDataList.ascx" tagname="UCC_AllSachDataList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <table cellspacing="1" class="style4" width="100%">
         <tr><td class="style5" style="background-color: #999900">
                <asp:Label ID="lblTongSoSach" runat="server" Font-Bold="True"></asp:Label>
            </td></tr>
         <tr>
             <td>
                 <uc1:UCC_AllSachDataList ID="UCC_AllSachDataList1" runat="server" />
             </td>
         </tr>
    
         </table>
</asp:Content>
