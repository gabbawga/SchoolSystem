<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMst.Master" AutoEventWireup="true" CodeBehind="Teacher.aspx.cs" Inherits="SchoolManagementSystem.Admin.Teacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; heigth: 100%; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">
        <div class="container p-md-4 p-sm-4">
            <asp:Label ID="lblMsg" runat="server" CssClass="mt-10"></asp:Label>
        </div>

        <h3 class="text-center">New Teacher</h3>

        <div class="row m-5 mr-lg-5 mt-md-5">
            <div class="col-md-6">
                <label for="txtName">Name</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
            <div class="col-md-6">
                <label for="txtCalendar">Date of Birthday</label>
                <asp:TextBox ID="txtCalendar" runat="server" CssClass="form-control" TextMode="Date" required></asp:TextBox>
            </div>
        </div>


        <div class="row m-5 mr-lg-5 mt-md-5">
            <div class="col-md-6">
                <label for="ddlGender">Gender</label>
                <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-6">
                <label for="txtMobile">Mobile</label>
                <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" TextMode="Number" required></asp:TextBox>
            </div>
        </div>


        <div class="row m-5 mr-lg-5 mt-md-5">
            <div class="col-md-6">
                <label for="txtEmail">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" required></asp:TextBox>
            </div>
            <div class="col-md-6">
                <label for="txtPassword">Password</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" required></asp:TextBox>
            </div>
        </div>

        <div class="row m-5 mr-lg-5 mt-md-5">
            <div class="col-md-12">
                <label for="txtAddress">Address</label>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="Multiline" placeholder="Enter Address" required></asp:TextBox>
            </div>
        </div>

        <div class="row m-5 mr-lg-5 ml-lg-5 mt-md-5">
            <div class="col-md-3 col-md-offset-2 mb-3">
                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Add Teacher" OnClick="btnAdd_Click" />
            </div>
        </div>

        <div class="row m-5 mr-lg-5 ml-lg-5 mt-md-5">
            <div class="col-md-6">
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" DataKeyNames="TeacherId" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:TemplateField HeaderText="Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNameEdit" runat="server" Text='<%# Eval("Name") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Mobile">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtMobileEdit" runat="server" Text='<%# Eval("Mobile") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Mobile") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Password">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPasswordEdit" runat="server" Text='<%# Eval("Password") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Password") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Email">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEmailEdit" runat="server" Text='<%# Eval("Email") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
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
