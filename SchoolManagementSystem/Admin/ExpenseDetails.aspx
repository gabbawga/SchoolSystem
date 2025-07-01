<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMst.Master" AutoEventWireup="true" CodeBehind="ExpenseDetails.aspx.cs" Inherits="SchoolManagementSystem.Admin.ExpenseDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript"
        src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript"
        src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
    <link href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.css"
        rel="stylesheet" type="text/css" />

    <script type="text/javascript">
    $(document).ready(function () {
        $("#<%= GridView1.ClientID %>").prepend($("<thead></thead>").append($(this).find("tr:first")))
        .DataTable({ "paging": true, "ordering": true, "searching": true });
    });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; height: 100%; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">

        <div class="row mb-3 mr-lg-5 ml-lg-5">
            <div class="col-md-10">
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="className" HeaderText="Class" ReadOnly="True" />
                        <asp:BoundField DataField="subjectName" HeaderText="Subject" ReadOnly="True" />
                        <asp:BoundField DataField="chargeAmount" HeaderText="ChargeAmount" ReadOnly="True" />
                    </Columns>
                    <HeaderStyle BackColor="#5558C9" ForeColor="White" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
