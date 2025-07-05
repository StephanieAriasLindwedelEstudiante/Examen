Public Class Proveedor
    Private _ProveedorID As Integer
    Private _NombreEmpresa As String
    Private _Contacto As String
    Private _Telefono As String
    ' Propiedades públicas para acceder a los campos privados
    Public Sub New(proveedorID As Integer, nombreEmpresa As String, contacto As String, telefono As String)
        Me.ProveedorID = proveedorID
        Me.NombreEmpresa = nombreEmpresa
        Me.Contacto = contacto
        Me.Telefono = telefono
    End Sub

    Public Property ProveedorID As Integer
        Get
            Return _ProveedorID
        End Get
        Set(value As Integer)
            _ProveedorID = value
        End Set
    End Property

    Public Property NombreEmpresa As String
        Get
            Return _NombreEmpresa
        End Get
        Set(value As String)
            _NombreEmpresa = value
        End Set
    End Property

    Public Property Contacto As String
        Get
            Return _Contacto
        End Get
        Set(value As String)
            _Contacto = value
        End Set
    End Property

    Public Property Telefono As String
        Get
            Return _Telefono
        End Get
        Set(value As String)
            _Telefono = value
        End Set
    End Property
End Class
