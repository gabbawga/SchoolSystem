<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMst.Master" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="SchoolManagementSystem.Admin.EmployeeDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; heigth: 100%; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">

        <div>
            <asp:Label ID="lblMsg" runat="server" CssClass="mt-10"></asp:Label>
        </div>

        <h3 class="text-center">Employee Details</h3>

        <div class="row m-5 mr-lg-5 mt-md-5">
            <div class="col-md-6">
                <label for="ddlTeacher">Teacher</label>
                <asp:DropDownList ID="ddlTeacher" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="col-md-6">
                <label for="txtCalendar">Date</label>
                <asp:TextBox ID="txtCalendar" runat="server" CssClass="form-control" TextMode="Date" required></asp:TextBox>
            </div>
        </div>



        <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
            <div class="col-md-3 col-md-offset-2 mb-3">
                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Check" OnClick="btnAdd_Click" />
            </div>
        </div>
        <div class="row mb-3 mr-lg-5 ml-lg-5">
            <div class="col-md-">
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover"
                    DataKeyNames="Id" AutoGenerateColumns="false">

                    <Columns>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <%# Convert.ToBoolean(Eval("status")) ? "Presente" : "Ausente" %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <HeaderStyle BackColor="#5558C9" ForeColor="White" />
                </asp:GridView>
            </div>
        </div>
</asp:Content>
