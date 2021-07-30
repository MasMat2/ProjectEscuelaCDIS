<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="alumno_u.aspx.cs" Inherits="Escuela.Alumnos.alumno_u" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Fecha de Nacimiento: </td>
                    <td>
                        <asp:TextBox ID="txtFechaNacimiento" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Semestre: </td>
                    <td>
                        <asp:TextBox ID="txtSemestre" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Facultad: </td>
                    <td>
                        <asp:DropDownList ID="ddlFacultad" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Estado: </td>
                    <td>
                        <asp:DropDownList ID="ddlEstado" runat="server" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Ciudad: </td>
                    <td>
                        <asp:DropDownList ID="ddlCiudad" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td>Materias: </td>
                    <td>
                        <asp:ListBox ID="listBoxMaterias" runat="server" SelectionMode="Multiple" CssClass="lista" Width="150px"></asp:ListBox>
                    </td>
                </tr>
            </table>

        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button ID="Button1" runat="server" Text="Editar" OnClick="btnEditar_Click" />
                   
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
