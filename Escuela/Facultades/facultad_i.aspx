<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="facultad_i.aspx.cs" Inherits="Escuela.Facultades.facultad_i" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="table table-bordered custom_tables">
                <tr>
                    <td>Codigo: </td>
                    <td>
                        <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_codigo" runat="server" ErrorMessage="El código es requerido"
                            ControlToValidate="txtCodigo" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_codigo" runat="server"
                            ErrorMessage="El formato del código debe ser de cuatro letras mayúsculas y dos números. Ejemplo: FIME01"
                            ControlToValidate="txtCodigo" ValidationExpression="^([A-Z]){4}(\d){2}$" ValidationGroup="vlg1" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Nombre: </td>
                    <td>
                        <asp:TextBox ID="txtNombre" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ErrorMessage="El nombre es requerido"
                            ControlToValidate="txtNombre" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Fecha de Creacion: </td>
                    <td>
                        <asp:TextBox ID="txtFechaCreacion" runat="server" autocomplete="off"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_fecha" runat="server" ErrorMessage="La fecha de creación es requerida"
                            ControlToValidate="txtFechaCreacion" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                        <%--<asp:CompareValidator ID="cv_fecha" runat="server"
                            ErrorMessage="El formato de fecha es incorrecto (dd/mm/yyyy) o (mm/dd/yyyy)"
                            ControlToValidate="txtFechaCreacion" Type="Date" Operator="DataTypeCheck"
                            ValidationGroup="vlg1" Display="Dynamic"></asp:CompareValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td>Universidad: </td>
                    <td>
                        <asp:DropDownList ID="ddlUniversidad" runat="server" AutoPostBack="true" CssClass="lista"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_universidad" runat="server" ErrorMessage="La universidad es requerida"
                            ControlToValidate="ddlUniversidad" ValidationGroup="vlg1" InitialValue="0" Display="Dynamic"></asp:RequiredFieldValidator>
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

    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click"
        ValidationGroup="vlg1" />


    <asp:GridView ID="grd_facultades" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered custom_tables">
        <Columns>
            <asp:BoundField HeaderText="Codigo" DataField="codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="nombre" />
        </Columns>
    </asp:GridView>

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
