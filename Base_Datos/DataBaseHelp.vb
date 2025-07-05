Imports System.Data.SqlClient
Public Class DataBaseHelp
    Private connectionString As String = ConfigurationManager.ConnectionStrings("conexionDB").ConnectionString
    Public Function CreateProveedor(proveedor As Proveedor) As String
        Try
            Dim fechaDate As Date = Date.Now

            Dim query As String = "INSERT INTO Proveedor (ProveedorId, NombreEmpresa, Contacto, Telefono) 
            VALUES (@ProveedorId, @NombreEmpresa, @Contacto, @Telefono)"
            Dim parameters As New List(Of SqlParameter) From {
                New SqlParameter("@ProveedorId", proveedor.ProveedorID),
                New SqlParameter("@NombreEmpresa", proveedor.NombreEmpresa),
                New SqlParameter("@Contacto", proveedor.Contacto),
                New SqlParameter("@Telefono", proveedor.Telefono)
            }
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddRange(parameters.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
            Return "Persona creada exitosamente."
        Catch ex As FormatException
            Return "Formato de fecha inválido. Por favor, use el formato 'dd/MM/yyyy'."
        Catch ex As Exception
            Return "Error al crear el empleado: " & ex.Message
        End Try
    End Function
    Public Function DeletePtoveedor(id As Integer) As String

        Try
            Dim query As String = "DELETE FROM Proveedor WHERE ProveedorId = @Id"
            Dim parameters As New List(Of SqlParameter) From {
                New SqlParameter("@Id", id)
            }
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddRange(parameters.ToArray())
                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    If rowsAffected = 0 Then
                        Return "No se encontró el empleado con el ID especificado."
                    End If
                End Using
            End Using
            Return "Persona eliminada exitosamente."
        Catch ex As Exception
            Return "Error al eliminar el empleado: " & ex.Message
        End Try
    End Function

    Friend Function UpdateProveedor(id As String, proveedor As Proveedor) As String
        Try
            Dim query As String = "UPDATE Proveedor SET NombreEmpresa = @NombreEmpresa,
Contacto = @Contacto, Telefono = @Telefono WHERE ProveedorId = @Id"
            Dim parameters As New List(Of SqlParameter) From {
                New SqlParameter("@Id", id),
                New SqlParameter("@NombreEmpresa", proveedor.NombreEmpresa),
                New SqlParameter("@Contacto", proveedor.Contacto),
                New SqlParameter("@Telefono", proveedor.Telefono)
            }
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddRange(parameters.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
            Return "Empleado actualizado exitosamente."
        Catch ex As Exception
            Return "Error al actualizar el empleado: " & ex.Message
        End Try
    End Function

End Class
