<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMst.Master" AutoEventWireup="true" CodeBehind="EmployeeAttendance.aspx.cs" Inherits="SchoolManagementSystem.Admin.EmployeeAttendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; heigth: 100%; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">

        <div>
            <asp:Label ID="lblMsg" runat="server" CssClass="mt-10"></asp:Label>
        </div>

        <div class="ml-auto text-right">
            <<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick" />
                    <asp:Label ID="lblTimer" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="Blue" />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                </Triggers>
            </asp:UpdatePanel>
        </div>

        <h3 class="text-center">Teacher's Attendance</h3>


    </div>

    <div class="row mb-3 mr-lg-5 ml-lg-5">
        <div class="col-md-10">
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover">

                <Columns>
                    <asp:TemplateField HeaderText="Class">
                        <ItemTemplate>
                            <div class="form-check form-check-inline">
                                <asp:RadioButton ID="RadioButton1" runat="server" Text="Present" Checked="true" GroupName="attendance" CssClass="form-check-input"/>
                            </div>
                            <div class="form-check form-check-inline">
                                <asp:RadioButton ID="RadioButton2" runat="server" Text="Absent" Checked="true" GroupName="attendance" CssClass="form-check-input"/>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <HeaderStyle BackColor="#5558C9" ForeColor="White" />
            </asp:GridView>
        </div>
    </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
        <div class="col-md-3 col-md-offset-2 mb-3">
            <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Add Mark" OnClick="btnAdd_Click" />
        </div>
    </div>
</asp:Content>
