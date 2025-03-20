<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="address.aspx.cs" Inherits="WebApplication2.address" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <h5>Add New Employee</h5>
        <h6>Address Details</h6>
        <div>
            <table>
                <tr>
                    <td>Address Line 1:</td>
                    <td>
                        <asp:TextBox runat="server" ID="addressline1" />
                    </td>
                </tr>
                <tr>
                    <td>Address Line 2:</td>
                    <td>
                        <asp:TextBox runat="server" ID="addressline2" />
                    </td>
                </tr>
                <tr>
                    <td>City
                    </td>
                    <td>
                        <asp:TextBox ID="city" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>State
                    </td>
                    <td>
                        <asp:TextBox ID="state" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Zipcode
                    </td>
                    <td>
                        <asp:TextBox ID="zipcode" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button runat="server" type="submit" value="Save" Text="Save" OnClick="Unnamed1_Click" />
                    </td>
                </tr>
            </table>

        </div>
    </main>

</asp:Content>
