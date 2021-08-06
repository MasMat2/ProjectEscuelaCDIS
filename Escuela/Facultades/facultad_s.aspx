<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="facultad_s.aspx.cs" Inherits="Escuela.Facultades.facultad_s" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="grd_facultades" runat="server" AutoGenerateColumns="false" OnRowCommand="grd_facultades_RowCommand"
        CssClass="table table-bordered custom_tables">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" imageUrl="~/Images/pencil.png" Height="20px" Width="20px"
                        CommandName="Editar" CommandArgument='<%# Eval("codigo") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEliminar" runat="server" imageUrl="~/Images/trash.png" Height="20px" Width="20px"
                        CommandName="Eliminar" CommandArgument='<%# Eval("codigo") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Codigo" DataField="codigo"/>
            <asp:BoundField HeaderText="Nombre" DataField="nombre"/>
            <asp:BoundField HeaderText="Fecha de Creacion" DataField="fechaCreacion" DataFormatString="{0:dd/MM/yyyy}"/>
            <asp:BoundField HeaderText="Universidad" DataField="nombreUniversidad"/>
            <asp:BoundField HeaderText="Ciudad" DataField="nombreCiudad"/>
        </Columns>
        </asp:GridView>
</asp:Content>
