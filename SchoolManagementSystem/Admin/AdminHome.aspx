<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMst.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="SchoolManagementSystem.Admin.AdminHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-image: url('../Image/bg-school.jpg'); width: 100%; height: 100%; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">
        <div class="container p-md-4 p-sm-4">
            <div>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-3">
                    <div class="card border-info mx-sm-1 p-3">
                        <div class="card border-info shadow text-info p-3 my-card"><span class="fa-solid fa-database" aria-hidden="true"></span></div>
                        <div class="text-info text-center mt-3">
                            <h4>Students</h4>
                        </div>
                        <div class="text-info text-center mt-2">
                            <h1>9332</h1>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="card border-success mx-sm-1 p-3">
                        <div class="card border-success shadow text-success p-3 my-card"><span class="fa-solid fa-database" aria-hidden="true"></span></div>
                        <div class="text-success text-center mt-3">
                            <h4>Teachers</h4>
                        </div>
                        <div class="text-success text-center mt-2">
                            <h1>250</h1>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="card border-danger mx-sm-1 p-3">
                        <div class="card border-danger shadow text-danger p-3 my-card"><span class="fa-solid fa-database" aria-hidden="true"></span></div>
                        <div class="text-danger text-center mt-3">
                            <h4>Subjects</h4>
                        </div>
                        <div class="text-danger text-center mt-2">
                            <h1>346</h1>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="card border-warning mx-sm-1 p-3">
                        <div class="card border-warning shadow text-warning p-3 my-card"><span class="fa-solid fa-database" aria-hidden="true"></span></div>
                        <div class="text-warning text-center mt-3">
                            <h4>Class</h4>
                        </div>
                        <div class="text-warning text-center mt-2">
                            <h1>346</h1>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
