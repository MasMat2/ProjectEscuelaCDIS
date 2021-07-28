<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="alumno_i.aspx.cs" Inherits="Escuela.Alumnos.alumno_i" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="table table-bordered custom_tables">
                <tr>
                    <td>Matricula: </td>
                    <td>
                        <asp:TextBox ID="txtMatricula" runat="server" MaxLength="8"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_matricula" runat="server"
                            ErrorMessage="La matricula es requerida" ControlToValidate="txtMatricula" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_matricula" runat="server"
                            ErrorMessage="Solo se aceptan numeros enteros" ControlToValidate="txtMatricula"
                            ValidationExpression="^[0-9]+$" ValidationGroup="vlg1" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Nombre: </td>
                    <td>
                        <asp:TextBox ID="txtNombre" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_Nombre" runat="server"
                            ErrorMessage="El nombre es requerido" ControlToValidate="txtNombre" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td>Fecha de Nacimiento: </td>
                    <td>
                        <asp:TextBox ID="txtFechaNacimiento" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_fecha" runat="server"
                            ErrorMessage="La fecha es requerida" ControlToValidate="txtFechaNacimiento" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cv_fecha" runat="server"
                            ErrorMessage="El formato de fecha es incorrecto (dd/mm/yyyy) o (mm/dd/yyyy)"
                            ControlToValidate="txtFechaNacimiento" Type="Date" Operator="DataTypeCheck"
                            ValidationGroup="vlg1" Display="Dynamic"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>Semestre: </td>
                    <td>
                        <asp:TextBox ID="txtSemestre" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_semestre" runat="server"
                            ErrorMessage="El semestre es requerida" ControlToValidate="txtSemestre" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rv_semestre" runat="server"
                            ErrorMessage="El semestre debe ser un valor entero entre 1 y 12" ControlToValidate="txtSemestre"
                            Type="Integer" MinimumValue="1" MaximumValue="12" ValidationGroup="vlg1" Display="Dynamic"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td>Facultad: </td>
                    <td>
                        <asp:DropDownList ID="ddlFacultad" runat="server" CssClass="lista"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_facultad" runat="server"
                            ErrorMessage="La facultad es requerida" ControlToValidate="ddlFacultad"
                            InitialValue="0" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td>Estado: </td>
                    <td>
                        <asp:DropDownList ID="ddlEstado" runat="server" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" 
                            AutoPostBack="true" CssClass="lista"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Ciudad: </td>
                    <td>
                        <asp:DropDownList ID="ddlCiudad" runat="server" AutoPostBack="true" CssClass="lista"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" ValidationGroup="vlg1" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:GridView ID="grd_alumnos" runat="server" AutoGenerateColumns="false" CssClass="table">
        <Columns>
            <asp:BoundField HeaderText="Matricula" DataField="matricula" />
            <asp:BoundField HeaderText="Nombre" DataField="nombre" />
        </Columns>
    </asp:GridView>

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
