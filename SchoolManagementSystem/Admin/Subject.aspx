<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMst.Master" AutoEventWireup="true" CodeBehind="Subject.aspx.cs" Inherits="SchoolManagementSystem.Admin.Subject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; height: 100%; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">
     <div class="container p-md-4 p-sm-4">
         <div>
             <asp:Label ID="lblMsg" runat="server" CssClass="mt-10"></asp:Label>
         </div>
         <h3 class="text-center">New Subject</h3>

         <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">

             <div class="col-md-6">
                 <label for="ddlClass">Class</label>
                 <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control"></asp:DropDownList>
             </div>

             <div class="col-md-6">
                 <label for="txtSubject">Subject</label>
                 <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control" placeholder="Enter Subject Name"></asp:TextBox>
             </div>

         </div>

         <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
             <div class="col-md-3 col-md-offset-2 mb-3">
                 <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Add Subject" OnClick="btnAdd_Click"/>
             </div>
         </div>

         <div class="row mb-3 mr-lg-5 ml-lg-5">
             <div class="col-md-6">
                 <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover" AutoGenerateColumns="False" DataKeyNames="subjectId" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                     <Columns>
                         <asp:BoundField DataField="ClassName" HeaderText="Class" ReadOnly="True" />
                         <asp:TemplateField HeaderText="Subject">
                             <EditItemTemplate>
                                 <asp:TextBox ID="txtSubjectEdit" runat="server" Text='<%# Eval("subjectName") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label1" runat="server" Text='<%# Eval("subjectName") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:CommandField ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" />
                     </Columns>
                     <HeaderStyle BackColor="#5558C9" ForeColor="White" />
                 </asp:GridView>
             </div>
         </div>
     </div>
</asp:Content>
