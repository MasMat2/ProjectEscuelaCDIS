<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="facultad_d.aspx.cs" Inherits="Escuela.Facultades.facultad_d" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table table-bordered custom_tables">
        <tr>
            <td>Codigo: </td>
            <td>
                <asp:Label ID="lblCodigo" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Nombre: </td>
            <td>
                <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Fecha de Creacion: </td>
            <td>
                <asp:Label ID="lblFechaCreacion" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Universidad: </td>
            <td>
                <asp:DropDownList ID="ddlUniversidad" runat="server" Enabled="false"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Ciudad: </td>
            <td>
                <asp:DropDownList ID="ddlCiudad" runat="server" Enabled="false"></asp:DropDownList>
            </td>
        </tr>

    </table>
    <%--  <tr>
            <td></td>
            <td>--%>
    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
    <%-- </td>
        </tr>--%>
</asp:Content>
