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

      <script type="text/javascript">
        $(document).ready(function () {
            $.ajax({
                type: "GET",
                url: '<%= ResolveUrl("~/ServicoWCFEscuela.svc/consultaFacultadesJSON") %>',
                success: function (data) {
                    console.log("LLamada de AJAX exitosa");
                    console.log(data);
                    table = `<table class="table table-bordered custom_tables" cellspacing="0" rules="all" border="1" id="MainContent_grd_facultades"
                    style="border-collapse:collapse;">
                    <tbody>
                        <tr>
                            <th scope="col">&nbsp;</th>
                            <th scope="col">&nbsp;</th>
                            <th scope="col">Codigo</th>
                            <th scope="col">Nombre</th>
                            <th scope="col">Fecha de Creacion</th>
                            <th scope="col">Universidad</th>
                            <th scope="col">Ciudad</th>
                        </tr>`
                    facultades = JSON.parse(data);
                   for (facultad of facultades) {
                       table += `<tr>
                        <td>
                            <a href="/Facultades/facultad_u?pCodigo=${facultad.codigo}"><img src="../Images/pencil.png"
                                    style="height:20px;width:20px;"></a>
                        </td>
                        <td>
                            <a href="/Facultades/facultad_d?pCodigo=${facultad.codigo}"><img src="../Images/trash.png"
                                    style="height:20px;width:20px;"></a>
                        </td>
                        <td>${facultad.codigo}</td>
                        <td>${facultad.nombre}</td>
                        <td>${facultad.fechaCreacion}</td>
                        <td>${facultad.universidad}/td>
                        <td>${facultad.nombreCiudad}</td>
                    </tr>`
                        
                    }
                    table += `</tbody ></table >`
                    contentRef = document.getElementsByClassName("body-content")[0];
                    contentRef.innerHTML = table;
                },
                error: function (e) {
                    console.log("LLamada de AJAX fallida");
                    console.log(e);
                },
            });
        })
      </script>
</asp:Content>
