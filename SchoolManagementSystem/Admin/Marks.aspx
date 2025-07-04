<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMst.Master" AutoEventWireup="true" CodeBehind="Marks.aspx.cs" Inherits="SchoolManagementSystem.Admin.Marks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; heigth: 100%; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">

        <div>
            <asp:Label ID="lblMsg" runat="server" CssClass="mt-10"></asp:Label>
        </div>

        <h3 class="text-center">Add Marks</h3>

        <div class="row m-5 mr-lg-5 mt-md-5">
            <div class="col-md-6">
                <label for="ddlClass">Class</label>
                <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="col-md-6">
                <label for="dllSubject">Subject</label>
                <asp:DropDownList ID="ddlSubject" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>

        <div class="row m-5 mr-lg-5 mt-md-5">
            <div class="col-md-12">
                <label for="txtRollNumber">Student Roll Number</label>
                <asp:TextBox ID="txtRollNumber" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
        </div>

        <div class="row m-5 mr-lg-5 mt-md-5">
            <div class="col-md-6">
                <label for="txtTotalMark">Total Mark</label>
                <asp:TextBox ID="txtTotalMark" runat="server" CssClass="form-control" TextMode="Number" required></asp:TextBox>
            </div>
            <div class="col-md-6">
                <label for="txtOutOfMark">Out Of Mark</label>
                <asp:TextBox ID="txtOutOfMark" runat="server" CssClass="form-control" TextMode="Number" required></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
        <div class="col-md-3 col-md-offset-2 mb-3">
            <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Add Mark" OnClick="btnAdd_Click" />
        </div>
    </div>
    <div class="row mb-3 mr-lg-5 ml-lg-5">
        <div class="col-md-">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-hover"
                DataKeyNames="ExameId"
                OnRowEditing="GridView1_RowEditing"
                OnRowUpdating="GridView1_RowUpdating"
                OnRowCancelingEdit="GridView1_RowCancelingEdit"
                OnRowDeleting="GridView1_RowDeleting"
                OnPageIndexChanging="GridView1_PageIndexChanging"
                OnRowDataBound="GridView1_RowDataBound">

                <Columns>

                    <asp:TemplateField HeaderText="Class">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlClassEdit" runat="server" CssClass="form-control" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblClass" runat="server" Text='<%# Eval("ClassName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Subject">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlSubjectEdit" runat="server" CssClass="form-control" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblSubject" runat="server" Text='<%# Eval("SubjectName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Roll Number">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtRollNolEdit" runat="server" Text='<%# Eval("RollNo") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblRollNo" runat="server" Text='<%# Eval("RollNo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Total Marks">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTotalMarksEdit" runat="server" Text='<%# Eval("TotalMarks") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblTotalMarksEdit" runat="server" Text='<%# Eval("TotalMarks") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Out Of Mark">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtOutOfMarkEdit" runat="server" Text='<%# Eval("OutOfMarks") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblOutOfMarkEdit" runat="server" Text='<%# Eval("OutOfMarks") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>

                <HeaderStyle BackColor="#5558C9" ForeColor="White" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
