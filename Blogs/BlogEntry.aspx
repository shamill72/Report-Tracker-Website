<%@ Page Title="Shabel Report Entry Page" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="BlogEntry.aspx.cs" Inherits="Report_Tracker_Website.Blogs.BlogEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="col-sm-12">
        <tr>
            <td>
                <h1>Report Entry Page</h1>
            </td>
            <td class="float-sm-end">
                <asp:Button ID="CancelButton" runat="server" Text="Cancel Report" CssClass="button-cancel" OnClick="CancelButton_Click" CausesValidation="False" /></td>
        </tr>
    </table>
    <hr />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="summary text-danger" HeaderText="Fields marked with an * are required for a new report" ShowSummary="True" ShowValidationErrors="True" ShowModelStateErrors="True" DisplayMode="SingleParagraph" />
    <div>
        <div class="form-group">
            <asp:RequiredFieldValidator ID="locRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="DDLLocation" Display="Dynamic" CssClass="text-danger" InitialValue="Select Location..."></asp:RequiredFieldValidator><label class="col-sm-3 control-label">Location</label>
            <div class="col-sm-4">
                <asp:DropDownList ID="DDLLocation" runat="server" CssClass="form-control">
                    <asp:ListItem Selected="True">Select Location...</asp:ListItem>
                    <asp:ListItem>Nashville</asp:ListItem>
                    <asp:ListItem>Gallatin</asp:ListItem>
                    <asp:ListItem>Cookeville</asp:ListItem>
                    <asp:ListItem>Knoxville</asp:ListItem>
                    <asp:ListItem>Memphis</asp:ListItem>
                </asp:DropDownList>
            </div>

        </div>
        <div class="form-group">
            <asp:RequiredFieldValidator ID="ttlRequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="TxtTitle" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
            <label class="col-sm-3 control-label">Title</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TxtTitle" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

        </div>

        <div class="form-group">
            <label class="col-sm-3 control-label">Report</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TxtReport" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="8"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-3">
                <asp:Label ID="LblPostDate" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-2">
                <asp:Button ID="BtnSubmit" runat="server" Text="Submit" CssClass="button" OnClick="BtnSubmit_Click" />
            </div>
        </div>
    </div>
</asp:Content>

