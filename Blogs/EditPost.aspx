<%@ Page Title="Shabel Edit Report Page" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="EditPost.aspx.cs" Inherits="Report_Tracker_Website.Blogs.EditPost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="col-sm-12">
        <tr>
            <td>
                <h1>Edit Report Page</h1>
            </td>
            <td class="float-sm-start">
                <asp:Button ID="BtnSubmit" runat="server" Text="Confirm Edit" CssClass="button" OnClick="BtnSubmit_Click" />
            </td>
            <td class="float-sm-end">
                <asp:Button ID="CancelButton" runat="server" Text="Cancel Edit" CssClass="button-cancel" OnClick="CancelButton_Click" /></td>
        </tr>
    </table>

    <hr />
    <div>
        <div class="form-group">
            <label class="col-sm-3 control-label">Location</label>
            <div class="col-sm-4">
                <asp:DropDownList ID="DDLLocation" runat="server" CssClass="form-control">
                    <asp:ListItem>Nashville</asp:ListItem>
                    <asp:ListItem>Gallatin</asp:ListItem>
                    <asp:ListItem>Cookeville</asp:ListItem>
                    <asp:ListItem>Knoxville</asp:ListItem>
                    <asp:ListItem>Memphis</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
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
            <div>&nbsp;</div>
        </div>
        <%-- Javascript to add dynamic file upload control --%>
        <script src="../Scripts/jquery-1.10.2.js"></script>
        <script type="text/javascript">
            $(document).ready(function () {
                var DivElement = $('#FileUploaders');
                var i = $('#FileUploaders p').size() + 1;

                $('#addUploader').on('click', function () {
                    $('<p class="p-style"><input type="file" id="FileUploader' + i + '" name="FileUploader' + i + '" /><a href="#" ID="removeUploader">Remove</a></p>').appendTo(DivElement);
                    i++;
                    return false;
                });
                $(document).on('click', '#removeUploader', function () {
                    $(this).parent('p').remove();
                    i--;

                    return false;
                });
            });
        </script>
        <div id="FileUploaders">
            <p class="p-style">
                <input type="file" id="FileUploader1" name="FileUploader1" /></p>
        </div>
        <a href="#" id="addUploader">Add Another</a>
        <br />
        <br />
        <asp:Button ID="btnUploadAll" runat="server" Text="Upload File(s)" OnClick="Upload" CssClass="button" />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CellPadding="10" OnRowCommand="GridView1_RowCommand" class="gridview-style" BorderStyle="None">
            <Columns>
                <asp:BoundField HeaderText="File name" DataField="FileName" />
                <asp:BoundField HeaderText="File size" DataField="FileSize" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnDownload" runat="server" CommandName="Download" CommandArgument='<%#Eval("FileId") %>'>Download</asp:LinkButton>&nbsp;&nbsp;
                        <asp:ImageButton ID="imgDeleteBtn" runat="server" ImageUrl="~/images/delete.png" Width="1 em" AlternateText="Delete File" CommandName="Delete" CommandArgument='<%#Eval("FileId") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BorderStyle="Groove" BorderWidth="1px" />
        </asp:GridView>
        <div class="col-sm-12">&nbsp;</div>
    </div>
</asp:Content>
