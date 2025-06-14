<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMst.Master" AutoEventWireup="true" CodeBehind="TeacherSubject.aspx.cs" Inherits="SchoolManagementSystem.Admin.TeacherSubject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; heigth: 100%; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">

        <div>
            <asp:Label ID="lblMsg" runat="server" CssClass="mt-10"></asp:Label>
        </div>

        <h3 class="text-center">Add Teacher Subject</h3>

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
                <div class="col-md-6">
                    <label for="ddlTeacher">Teacher</label>
                    <asp:DropDownList ID="ddlTeacher" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>

            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-3 col-md-offset-2 mb-3">
                    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Add Class" OnClick="btnAdd_Click" />
                </div>
            </div>
        </div>
</asp:Content>
