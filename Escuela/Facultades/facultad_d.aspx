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
        <tr>
            <td>Materias: </td>
            <td>
                <asp:ListBox ID="listBoxMaterias" runat="server" SelectionMode="Multiple" CssClass="lista" Width="150px"></asp:ListBox>
            </td>
        </tr>

    </table>
    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />

    <script type="text/javascript">
        $(document).ready(function () {

            function load_plugins() {
                $("#MainContent_txtFechaCreacion").datepicker({
                    changeMonth: true,
                    changeYear: true,
                    yearRange: "1900:2010",
                    dateFormat: "dd-mm-yy"
                });

                $(".lista").chosen();
            }

            load_plugins();

            var manager = Sys.WebForms.PageRequestManager.getInstance();

            manager.add_endRequest(load_plugins);
        });
    </script>
</asp:Content>
