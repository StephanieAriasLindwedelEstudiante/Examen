<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Proveedores.aspx.vb" Inherits="Examen.Proveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:HiddenField ID="IdProveedor" runat="server" />

    <div class="row mb-3">
        <div class="col-md-4">
            <div class="form-group mb-3">
                <label for="TxtNombreEmpresa">Nombre Empresa</label>
                <asp:TextBox ID="TxtNombreEmpresa" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group mb-3">
                <label for="TxtContacto">Contacto</label>
                <asp:TextBox ID="TxtContacto" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group mb-3">
                <label for="TxtTelefono">Teléfono</label>
                <asp:TextBox ID="TxtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group mb-3">
                <asp:Button ID="BtnGuardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="BtnGuardar_Click" />
                <asp:Button ID="BtnCancelar" CssClass="btn btn-secondary" runat="server" Text="Cancelar" OnClick="BtnCancelar_Click" />
            </div>
        </div>

        <asp:Label ID="LblMensaje" runat="server" CssClass="text-danger"></asp:Label>
    </div>

    <asp:GridView ID="GvProveedores" runat="server" AllowPaging="True"
        OnSelectedIndexChanged="GvProveedores_SelectedIndexChanged"
        OnRowDeleting="GvProveedores_RowDeleting"
        AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ProveedorId" 
        DataSourceID="SqlDataSourceProveedores" CssClass="table table-bordered table-striped">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="ProveedorId" HeaderText="ProveedorId" InsertVisible="False" ReadOnly="True" SortExpression="ProveedorId" />
            <asp:BoundField DataField="NombreEmpresa" HeaderText="Nombre Empresa" SortExpression="NombreEmpresa" />
            <asp:BoundField DataField="Contacto" HeaderText="Contacto" SortExpression="Contacto" />
            <asp:BoundField DataField="Telefono" HeaderText="Teléfono" SortExpression="Telefono" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSourceProveedores" runat="server"
        ConnectionString="<%$ ConnectionStrings:conexionDB %>"
        SelectCommand="SELECT * FROM [Proveedor]">
    </asp:SqlDataSource>

</asp:Content>
