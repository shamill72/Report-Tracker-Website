<%@ Page Title="Shabel Report Details Page" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="PostDetails.aspx.cs" Inherits="Report_Tracker_Website.Blogs.PostDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="col-sm-12">
        <tr>
            <td>
                <h1>Report Details</h1>
            </td>
            <td class="float-sm-start">
                <asp:Button ID="EditPostButton" runat="server" Text="Edit Report" CssClass="button" OnClick="EditPostButton_Click" Font-Size="Small" /></td>
            <td class="float-sm-end">
                <asp:Button ID="DeletePostButton" runat="server" Text="Delete Report" CssClass="delete-button" OnClick="DeletePostButton_Click" /></td>
        </tr>
    </table>


    <hr />
    <div>
        <div class="form-group">
            <table class="col-sm-12">
                <tr>
                    <td class="float-sm-start">
                        <h4>
                            <asp:Label ID="LblTitle" runat="server" Font-Bold="True" Font-Underline="True"></asp:Label></h4>
                    </td>
                    <td class="float-sm-end">
                        <h5>
                            <asp:Label ID="LblLocation" runat="server" Font-Italic="True"></asp:Label></h5>
                    </td>
                </tr>
            </table>
        </div>
        <div class="form-group">
            <div class="col-sm-12">
                <asp:Label ID="LblReport" runat="server" Text="" CssClass="col-sm-12"></asp:Label>
            </div>
            &nbsp;
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="10" OnRowCommand="GridView1_RowCommand" class="gridview-style" BorderStyle="None">
                <Columns>
                    <asp:BoundField HeaderText="File name" DataField="FileName" />
                    <asp:BoundField HeaderText="File size" DataField="FileSize" DataFormatString="{0:###,###} bytes" />
                    <asp:TemplateField HeaderText="Download">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="lbtnDownload" runat="server" CommandName="Download" CommandArgument='<%#Eval("FileId") %>' ImageUrl="~/images/down-arrow.png" Width="14px" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <table class="col-sm-12">
            <tr class="col-sm-12 card-footer text-muted">
                <td class="float-sm-start">Posted on:
                    <asp:Label ID="LblPostDate" runat="server" Text=""></asp:Label></td>
                <td class="float-sm-end">Last Updated:
                    <asp:Label ID="LblUpdate" runat="server" Text="">"></asp:Label></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>

    </div>

</asp:Content>
