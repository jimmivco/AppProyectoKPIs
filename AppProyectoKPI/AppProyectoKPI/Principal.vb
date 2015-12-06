﻿Public Class Principal
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        activarColorFondoMDI(sender, e)
        Dim permisos() As String = {"Operaciones", "GestionarProspectos", "ImportarProspectos", "ImportarUsuarios", "GenerarRegistroMercadeo", "AsignarKpis",
            "GestionarVentas", "Configuracion", "Eventos", "Entidades", "Kpis", "Reportes", "IngresosUsuario", "Ventas", "IndicadoresKpi",
            "FuentesProspectos", "ListarProfesores", "ListarEstudiantes", "ListarCursos", "Seguridad", "Usuarios", "Roles", "Permisos"}
        accederMenuPrincipal(permisos)

    End Sub

    Private Sub activarColorFondoMDI(sender As Object, e As EventArgs)
        Dim ctl As Control
        Dim ctlMDI As MdiClient
        For Each ctl In Me.Controls
            Try
                ctlMDI = CType(ctl, MdiClient)
                ctlMDI.BackColor = Me.BackColor
            Catch exc As InvalidCastException
            End Try
        Next
    End Sub

    Private Sub accederMenuPrincipal(ByVal permisos() As String)
        Dim i As Integer
        Dim isItem As Boolean
        For q As Integer = 0 To permisos.Length - 1
            i = 0
            isItem = False
            While i < MenuStrip1.Items.Count And isItem = False
                Dim opcion As New ToolStripMenuItem
                opcion.Name = "mnu_" + permisos(q)
                If MenuStrip1.Items.Item(i).Name = opcion.Name Then
                    MenuStrip1.Items.Item(i).Visible = True
                    Dim op As ToolStripMenuItem = MenuStrip1.Items.Item(i)
                    accederSubMenus(permisos, op)
                    isItem = True
                End If
                i = i + 1
            End While
        Next
    End Sub
    Private Sub accederSubMenus(ByVal permisos() As String, ByVal op As ToolStripMenuItem)

        Dim opcion As New ToolStripMenuItem

        For Each subMenu As ToolStripMenuItem In op.DropDownItems
            For k As Integer = 0 To permisos.Length - 1
                opcion.Name = "mnu_" + permisos(k)
                If subMenu.Name = opcion.Name Then
                    subMenu.Visible = True
                End If
            Next
        Next

    End Sub

    Private Sub mnu_GestionarProspectos_Click(sender As Object, e As EventArgs) Handles mnu_GestionarProspectos.Click
        'Dim gestionarProspectos As New GestionProspectos
        'gestionarProspectos.MdiParent = Me
        'gestionarProspectos.ShowDialog(Me)

        Dim p2 As New GestionProspectos()

        abrirVentana(p2)


    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub mnu_Kpis_Click(sender As Object, e As EventArgs) Handles mnu_Kpis.Click
        Dim form As New CreacionKPIs

        abrirVentana(form)
    End Sub

    Private Sub abrirVentana(form As Form)
        Dim active As Form = Me.ActiveMdiChild
        If (Not active Is Nothing) Then
            active.Close()
        End If
        form.MdiParent = Me
        form.WindowState = FormWindowState.Maximized
        form.Show()
    End Sub

    Private Sub mnu_Usuarios_Click(sender As Object, e As EventArgs) Handles mnu_Usuarios.Click
        Dim xg As New Usuarios()
        abrirVentana(xg)
    End Sub

    Private Sub mnu_Roles_Click(sender As Object, e As EventArgs) Handles mnu_Roles.Click
        Dim xy As New Roles()
        abrirVentana(xy)
    End Sub

    Private Sub mnu_AsignarKpis_Click(sender As Object, e As EventArgs) Handles mnu_AsignarKpis.Click
        Dim asignarForm As New AsignacionKPIs()
        abrirVentana(asignarForm)
    End Sub

    Private Sub mnu_IndicadoresKpi_Click(sender As Object, e As EventArgs) Handles mnu_IndicadoresKpi.Click
        Dim reportesKPI As New ReportesKPI()
        abrirVentana(reportesKPI)
    End Sub

    Private Sub mnu_ImportarProspecto_Click(sender As Object, e As EventArgs) Handles mnu_ImportarProspecto.Click
        abrirVentana(ImportarProspecto)
    End Sub

    Private Sub mnu_ImportarUsuarios_Click(sender As Object, e As EventArgs) Handles mnu_ImportarUsuarios.Click
        abrirVentana(ImportarUsuarios)
    End Sub

    Private Sub mnu_Entidades_Click(sender As Object, e As EventArgs) Handles mnu_Entidades.Click
        'abrirVentana(GestionEmpresarial)
    End Sub

    Private Sub mnu_Eventos_Click(sender As Object, e As EventArgs) Handles mnu_Eventos.Click
        ' abrirVentana(GestionEventos)
    End Sub

    Private Sub mnu_GestionarVentas_Click(sender As Object, e As EventArgs) Handles mnu_GestionarVentas.Click
        'abrirVentana(RegistrarVentas)
    End Sub

    Private Sub mnu_ImportarCursos_Click(sender As Object, e As EventArgs) Handles mnu_ImportarCursos.Click
        abrirVentana(ImportarCursos)
    End Sub

    Private Sub mnu_ListarProfesores_Click(sender As Object, e As EventArgs) Handles mnu_ListarProfesores.Click
        abrirVentana(ListarProfesores)
    End Sub

    Private Sub mnu_ListarEstudiantes_Click(sender As Object, e As EventArgs) Handles mnu_ListarEstudiantes.Click
        abrirVentana(ListarEstudiantes)
    End Sub

    Private Sub mnu_ListarCursos_Click(sender As Object, e As EventArgs) Handles mnu_ListarCursos.Click
        abrirVentana(ListarCursos)
    End Sub
End Class