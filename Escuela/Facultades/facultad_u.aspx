<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="facultad_u.aspx.cs" Inherits="Escuela.Facultades.facultad_u" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="table table-bordered custom_tables">
                <tr>
                    <td>Codigo: </td>
                    <td>
                        <asp:Label ID="lblCodigo" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Nombre: </td>
                    <td>
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Fecha de Creacion: </td>
                    <td>
                        <asp:TextBox ID="txtFechaCreacion" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Universidad: </td>
                    <td>
                        <asp:DropDownList ID="ddlUniversidad" runat="server" AutoPostBack="true" CssClass="lista"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Pais: </td>
                    <td>
                        <asp:DropDownList ID="ddlPais" runat="server" OnSelectedIndexChanged="ddlPais_SelectedIndexChanged"
                            AutoPostBack="true" CssClass="lista">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Estado: </td>
                    <td>
                        <asp:DropDownList ID="ddlEstado" runat="server" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged"
                            AutoPostBack="true" CssClass="lista">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Ciudad: </td>
                    <td>
                        <asp:DropDownList ID="ddlCiudad" runat="server" AutoPostBack="true" CssClass="lista"></asp:DropDownList>
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

    <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" />

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
