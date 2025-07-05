Imports Microsoft.Ajax.Utilities
Public Class Proveedores
    Inherits System.Web.UI.Page
    Protected dbHelper As New DataBaseHelp()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim proveedores As DataTable = dbHelper.CargarProveedores()
        ' GvProveedores.DataSource = proveedores
    End Sub
    Protected Sub BtnGuardar_Click(sender As Object, e As EventArgs)
        If IdProveedor.Value.IsNullOrWhiteSpace Then
            ' CREAR
            Dim proveedor As New Proveedor() With {
                .NombreEmpresa = TxtNombreEmpresa.Text,
                .Contacto = TxtContacto.Text,
                .Telefono = TxtTelefono.Text
            }
            Dim resultado As String = dbHelper.CreateProveedor(proveedor)
            LblMensaje.Text = resultado
            LimpiarFormulario()
            GvProveedores.DataSource = dbHelper.CreateProveedor(proveedor)
            GvProveedores.DataBind()
        Else
            ' ACTUALIZAR
            Dim proveedor As New Proveedor() With {
                .NombreEmpresa = TxtNombreEmpresa.Text,
                .Contacto = TxtContacto.Text,
                .Telefono = TxtTelefono.Text
            }
            Dim resultado As String = dbHelper.UpdateProveedor(Convert.ToInt32(IdProveedor.Value), proveedor)
            LblMensaje.Text = resultado
            LimpiarFormulario()
            IdProveedor.Value = ""
            GvProveedores.DataSource = dbHelper.UpdateProveedor(IdProveedor.Value, proveedor)
            GvProveedores.DataBind()
        End If
    End Sub

    Protected Sub BtnCancelar_Click(sender As Object, e As EventArgs)
        LimpiarFormulario()
        IdProveedor.Value = ""
        LblMensaje.Text = ""
    End Sub

    Protected Sub LimpiarFormulario()
        TxtNombreEmpresa.Text = ""
        TxtContacto.Text = ""
        TxtTelefono.Text = ""
    End Sub

    Protected Sub GvProveedores_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim index = GvProveedores.SelectedIndex
        Dim id As Integer = Convert.ToInt32(GvProveedores.SelectedDataKey.Value)

        If index >= 0 Then
            Dim row = GvProveedores.Rows(index)
            Dim proveedor As New Proveedor With {
                .NombreEmpresa = row.Cells(2).Text,
                .Contacto = row.Cells(3).Text,
                .Telefono = row.Cells(4).Text
            }
            IdProveedor.Value = row.Cells(1).Text
            TxtNombreEmpresa.Text = proveedor.NombreEmpresa
            TxtContacto.Text = proveedor.Contacto
            TxtTelefono.Text = proveedor.Telefono
        End If
    End Sub

    Protected Sub GvProveedores_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim id As Integer = Convert.ToInt32(GvProveedores.DataKeys(e.RowIndex).Value)
        Dim resultado As String = dbHelper.DeleteProveedor(id)
        LblMensaje.Text = resultado
        e.Cancel = True
        GvProveedores.DataBind()
    End Sub
End Class