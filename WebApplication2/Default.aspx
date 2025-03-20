<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h4>Employee List</h4>
    <br />
    <main>
        <asp:Button ID="btnAddnew" runat="server" OnClick="btnAddnew_Click" Text="Add New Employee" /><br />
        <asp:DataGrid runat="server" ID="grid1" CssClass="table">
            <Columns>
                <asp:BoundColumn DataField="FirstName" HeaderText="First Name" />
                <asp:BoundColumn DataField="LastName" HeaderText="Last Name" />
                <asp:BoundColumn DataField="gender" HeaderText="Gender"></asp:BoundColumn>
                <asp:BoundColumn DataField="city" HeaderText="City"></asp:BoundColumn>
                <asp:BoundColumn DataField="state" HeaderText="State"></asp:BoundColumn>
            </Columns>
        </asp:DataGrid>
    </main>

</asp:Content>
