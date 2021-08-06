<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="alumno_s.aspx.cs" Inherits="Escuela.Alumnos.alumno_s" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="grd_alumnos" runat="server" AutoGenerateColumns="false" OnRowCommand="grd_alumnos_RowCommand" CssClass="table table-bordered custom_tables">
        <Columns>
            <%--<asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="~/Images/pencil.png" Height="20px" Width="20px"
                        CommandName="Editar" CommandArgument='<%# Eval("matricula") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="~/Images/trash.png" Height="20px" Width="20px"
                        CommandName="Eliminar" CommandArgument='<%# Eval("matricula") %>' />
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:BoundField HeaderText="Matricula" DataField="matricula" />
            <asp:BoundField HeaderText="Nombre" DataField="nombre" />
            <asp:BoundField HeaderText="Fecha de Nacimiento" DataField="fechaNacimiento" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField HeaderText="Semestre" DataField="semestre" />
            <asp:BoundField HeaderText="Facultad" DataField="nombreFacultad" />
            <asp:BoundField HeaderText="Ciudad" DataField="nombreCiudad" />
        </Columns>
    </asp:GridView>
    <script type="text/javascript">
        $(document).ready(function () {
            $.ajax({
                type: "GET",
                url: '<%= ResolveUrl("~/ServicioWCFEscuela.svc/consultaAlumnosJSON") %>',
                success: function (data) {
                    console.log("LLamada de AJAX exitosa");
                    console.log(data);
                    table = `<table class="table table-bordered custom_tables" cellspacing="0" rules="all" border="1" id="MainContent_grd_alumnos"
                    style="border-collapse:collapse;">
                    <tbody>
                        <tr>
                            <th scope="col">&nbsp;</th>
                            <th scope="col">&nbsp;</th>
                            <th scope="col">Matricula</th>
                            <th scope="col">Nombre</th>
                            <th scope="col">Fecha de Nacimiento</th>
                            <th scope="col">Semestre</th>
                            <th scope="col">Facultad</th>
                            <th scope="col">Ciudad</th>
                        </tr>`
                    alumnos = JSON.parse(data);
                    for (alumno of alumnos) {
                        timestamp = alumno.fechaNacimiento.match(/\((-?\d+)\)/)[1];
                        date = new Date(parseInt(timestamp));
                        console.log(date);
                        dateName = `${date.getDate()}/${date.getMonth()+1}/${date.getFullYear()}`
                        table += `<tr>
                            <td>
                                <a href="/Alumnos/alumno_u?pMatricula=${alumno.matricula}"><img src="../Images/pencil.png"
                                        style="height:20px;width:20px;"></a>
                            </td>
                            <td>
                                <a href="/Alumnos/alumno_d?pMatricula=${alumno.matricula}"><img src="../Images/trash.png"
                                        style="height:20px;width:20px;"></a>
                            </td>
                        <td>${alumno.matricula}</td>
                        <td>${alumno.nombre}</td>
                        <td>${dateName}</td>
                        <td>${alumno.semestre}</td>
                        <td>${alumno.nombreFacultad}</td>
                        <td>${alumno.nombreCiudad}</td>
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
