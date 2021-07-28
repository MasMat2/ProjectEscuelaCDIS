<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="alumno_s.aspx.cs" Inherits="Escuela.Alumnos.alumno_s" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="grd_alumnos" runat="server" AutoGenerateColumns="false" OnRowCommand="grd_alumnos_RowCommand" CssClass="table table-bordered custom_tables">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" imageUrl="~/Images/pencil.png" Height="20px" Width="20px"
                        CommandName="Editar" CommandArgument='<%# Eval("matricula") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEliminar" runat="server" imageUrl="~/Images/trash.png" Height="20px" Width="20px"
                        CommandName="Eliminar" CommandArgument='<%# Eval("matricula") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Matricula" DataField="matricula"/>
            <asp:BoundField HeaderText="Nombre" DataField="nombre"/>
            <asp:BoundField HeaderText="Fecha de Nacimiento" DataField="fechaNacimiento" DataFormatString="{0:dd/MM/yyyy}"/>
            <asp:BoundField HeaderText="Semestre" DataField="semestre"/>
            <asp:BoundField HeaderText="Facultad" DataField="nombreFacultad"/>
            <asp:BoundField HeaderText="Ciudad" DataField="nombreCiudad"/>
        </Columns>

    </asp:GridView>

</asp:Content>
