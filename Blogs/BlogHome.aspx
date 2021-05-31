<%@ Page Title="Shabel Reports Page" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="BlogHome.aspx.cs" Inherits="Report_Tracker_Website.Blogs.BlogHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td class="col-sm-12">
                <h1>All Reports</h1>
            </td>
            <td class="col-sm-3">
                <asp:Button ID="NewPostButton" runat="server" Text="New Report" CssClass="new-button button" OnClick="NewPostButton_Click" />
            </td>
        </tr>
    </table>
    <hr />
    <div>
        <asp:Repeater ID="RepBlogDetails" runat="server" OnItemCommand="RepBlog_ItemCommand">
            <ItemTemplate>
                <table class="col-sm-12">
                    <tr>
                        <td class="float-sm-start">
                            <h4>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("Bid") %>' Text='<%#Eval("Btitle") %>' CommandName="click" Font-Bold="True" Font-Underline="True"></asp:LinkButton></h4>
                        </td>
                        <td class="float-sm-start">&nbsp;&nbsp;
                            <asp:Image ID="attImage" runat="server" Visible='<%# String.IsNullOrEmpty(Eval("Battach").ToString()) ? false : Convert.ToInt32(Eval("Battach")) == 1 ? true:false %>' ImageUrl="~/images/paper-clip.png" Height="15px" Width="15px" ImageAlign="Middle" />
                        </td>

                        <td class="float-sm-end">
                            <h5>
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("Bid") %>' Text='<%#Eval("Blocation") %>' CommandName="click" Font-Italic="True"><h5></h5></asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td class="col-sm-12 fade-out">
                            <p class="card-text">
                                <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%#Eval("Bid") %>' Text='<%# Eval("Btext").ToString().Length > 500 ? Eval("Btext").ToString().Substring(0, 500) : Eval("Btext")%>' CommandName="click"></asp:LinkButton>
                            </p>
                        </td>
                    </tr>
                    <tr class="col-sm-12 card-footer text-muted">
                        <td class="float-sm-start">Posted on: <%#Eval("Bpostdate","{0: MMMM dd, yyyy hh:mm tt}") %></td>
                        <td class="float-sm-end">Last updated: <%#Eval("Bupdate","{0: MMMM dd, yyyy hh:mm tt}") %></td>
                    </tr>
                    <hr />
                </table>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    &nbsp;
</asp:Content>
