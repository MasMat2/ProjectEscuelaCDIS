<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="alumno_d.aspx.cs" Inherits="Escuela.Alumnos.alumno_d" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table table-bordered custom_tables">
        <tr>
            <td>Matricula: </td>
            <td>
                <asp:Label ID="lblMatricula" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Nombre: </td>
            <td>
                <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Fecha de Nacimiento: </td>
            <td>
                <asp:Label ID="lblFechaNacimiento" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Semestre: </td>
            <td>
                <asp:Label ID="lblSemestre" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Facultad: </td>
            <td>
                <asp:DropDownList ID="ddlFacultad" runat="server" Enabled="false"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Materias: </td>
            <td>
                <asp:ListBox ID="listBoxMaterias" runat="server" SelectionMode="Multiple" CssClass="lista" Width="150px"></asp:ListBox>
            </td>
        </tr>
    </table>
    <asp:Button ID="Button1" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />

    <script type="text/javascript">
        $(document).ready(function () {

            function load_plugins() {
                $("#MainContent_txtFechaNacimiento").datepicker({
                    changeMonth: true,
                    changeYear: true,
                    yearRange: "1960:2008",
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
