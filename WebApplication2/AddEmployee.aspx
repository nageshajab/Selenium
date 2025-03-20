<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="WebApplication2.AddEmployee" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <h5>Add New Employee</h5>
        <h6>Personal Details</h6>
        <div>
           <table>
               <tr>
                   <td>First Name:</td>
                   <td>
                       <asp:TextBox runat="server" id="firstname"/>
                   </td>
               </tr>
               <tr>
                   <td>Last Name:</td>
                   <td>
                       <asp:TextBox runat="server"  id="lastname" />
                   </td>
               </tr>
               <tr>
                   <td>
                       Gender
                   </td>
                   <td>
                       Male<asp:RadioButton runat="server" ID="male" GroupName="gender" />
                       Female<asp:RadioButton runat="server" ID="female" GroupName="gender" />
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
