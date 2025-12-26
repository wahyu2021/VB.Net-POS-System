<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LoginForm
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim CustomizableEdges13 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges14 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges11 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges12 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges9 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges10 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(components)
        pnl_left = New Guna.UI2.WinForms.Guna2Panel()
        pic_logo = New Guna.UI2.WinForms.Guna2PictureBox()
        lbl_brand_desc = New Label()
        lbl_brand_title = New Label()
        pnl_right = New Guna.UI2.WinForms.Guna2Panel()
        btn_exit = New Guna.UI2.WinForms.Guna2ControlBox()
        Label2 = New Label()
        btn_login = New Guna.UI2.WinForms.Guna2Button()
        txt_password = New Guna.UI2.WinForms.Guna2TextBox()
        txt_username = New Guna.UI2.WinForms.Guna2TextBox()
        Label1 = New Label()
        msg_dialog = New Guna.UI2.WinForms.Guna2MessageDialog()
        pnl_left.SuspendLayout()
        CType(pic_logo, ComponentModel.ISupportInitialize).BeginInit()
        pnl_right.SuspendLayout()
        SuspendLayout()
        ' 
        ' Guna2BorderlessForm1
        ' 
        Guna2BorderlessForm1.BorderRadius = 20
        Guna2BorderlessForm1.ContainerControl = Me
        Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Guna2BorderlessForm1.TransparentWhileDrag = True
        ' 
        ' pnl_left
        ' 
        pnl_left.Controls.Add(pic_logo)
        pnl_left.Controls.Add(lbl_brand_desc)
        pnl_left.Controls.Add(lbl_brand_title)
        pnl_left.CustomizableEdges = CustomizableEdges13
        pnl_left.Dock = DockStyle.Left
        pnl_left.FillColor = Color.FromArgb(CByte(15), CByte(52), CByte(97))
        pnl_left.Location = New Point(0, 0)
        pnl_left.Name = "pnl_left"
        pnl_left.ShadowDecoration.CustomizableEdges = CustomizableEdges14
        pnl_left.Size = New Size(320, 450)
        pnl_left.TabIndex = 1
        ' 
        ' pic_logo
        ' 
        pic_logo.BackColor = Color.Transparent
        pic_logo.BorderRadius = 10
        pic_logo.CustomizableEdges = CustomizableEdges11
        pic_logo.FillColor = Color.WhiteSmoke
        pic_logo.ImageRotate = 0F
        pic_logo.Location = New Point(107, 80)
        pic_logo.Name = "pic_logo"
        pic_logo.ShadowDecoration.CustomizableEdges = CustomizableEdges12
        pic_logo.Size = New Size(100, 100)
        pic_logo.SizeMode = PictureBoxSizeMode.StretchImage
        pic_logo.TabIndex = 10
        pic_logo.TabStop = False
        pic_logo.UseTransparentBackground = True
        ' 
        ' lbl_brand_desc
        ' 
        lbl_brand_desc.AutoSize = True
        lbl_brand_desc.BackColor = Color.Transparent
        lbl_brand_desc.Font = New Font("Segoe UI", 10F)
        lbl_brand_desc.ForeColor = Color.FromArgb(CByte(200), CByte(200), CByte(220))
        lbl_brand_desc.Location = New Point(48, 237)
        lbl_brand_desc.Name = "lbl_brand_desc"
        lbl_brand_desc.Size = New Size(234, 38)
        lbl_brand_desc.TabIndex = 1
        lbl_brand_desc.Text = "Solusi Pintar untuk Pengelolaan Toko" & vbCrLf & "Efisiensi dalam genggaman."
        lbl_brand_desc.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lbl_brand_title
        ' 
        lbl_brand_title.AutoSize = True
        lbl_brand_title.BackColor = Color.Transparent
        lbl_brand_title.Font = New Font("Segoe UI", 24F, FontStyle.Bold)
        lbl_brand_title.ForeColor = Color.White
        lbl_brand_title.Location = New Point(78, 183)
        lbl_brand_title.Name = "lbl_brand_title"
        lbl_brand_title.Size = New Size(164, 45)
        lbl_brand_title.TabIndex = 0
        lbl_brand_title.Text = "FoxeMart"
        ' 
        ' pnl_right
        ' 
        pnl_right.BackColor = Color.White
        pnl_right.Controls.Add(btn_exit)
        pnl_right.Controls.Add(Label2)
        pnl_right.Controls.Add(btn_login)
        pnl_right.Controls.Add(txt_password)
        pnl_right.Controls.Add(txt_username)
        pnl_right.Controls.Add(Label1)
        pnl_right.CustomizableEdges = CustomizableEdges9
        pnl_right.Dock = DockStyle.Fill
        pnl_right.Location = New Point(320, 0)
        pnl_right.Name = "pnl_right"
        pnl_right.ShadowDecoration.CustomizableEdges = CustomizableEdges10
        pnl_right.Size = New Size(430, 450)
        pnl_right.TabIndex = 0
        ' 
        ' btn_exit
        ' 
        btn_exit.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btn_exit.BorderRadius = 12
        btn_exit.CustomizableEdges = CustomizableEdges3
        btn_exit.FillColor = Color.FromArgb(CByte(255), CByte(240), CByte(240))
        btn_exit.HoverState.FillColor = Color.FromArgb(CByte(220), CByte(53), CByte(69))
        btn_exit.HoverState.IconColor = Color.White
        btn_exit.IconColor = Color.FromArgb(CByte(220), CByte(53), CByte(69))
        btn_exit.Location = New Point(375, 10)
        btn_exit.Name = "btn_exit"
        btn_exit.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        btn_exit.Size = New Size(40, 40)
        btn_exit.TabIndex = 10
        '
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10F)
        Label2.ForeColor = Color.FromArgb(CByte(90), CByte(107), CByte(125))
        Label2.Location = New Point(55, 120)
        Label2.Name = "Label2"
        Label2.Size = New Size(232, 19)
        Label2.TabIndex = 4
        Label2.Text = "Silakan login untuk mengakses kasir."
        ' 
        ' btn_login
        ' 
        btn_login.BackColor = Color.Transparent
        btn_login.BorderRadius = 22
        btn_login.CustomizableEdges = CustomizableEdges1
        btn_login.FillColor = Color.FromArgb(CByte(240), CByte(127), CByte(35))
        btn_login.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btn_login.ForeColor = Color.White
        btn_login.HoverState.FillColor = Color.FromArgb(CByte(220), CByte(100), CByte(20))
        btn_login.Location = New Point(55, 310)
        btn_login.Name = "btn_login"
        btn_login.ShadowDecoration.BorderRadius = 22
        btn_login.ShadowDecoration.Color = Color.FromArgb(CByte(200), CByte(200), CByte(255))
        btn_login.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        btn_login.ShadowDecoration.Depth = 10
        btn_login.ShadowDecoration.Enabled = True
        btn_login.Size = New Size(320, 45)
        btn_login.TabIndex = 3
        btn_login.Text = "MASUK"
        ' 
        ' txt_password
        ' 
        txt_password.BorderColor = Color.FromArgb(CByte(221), CByte(226), CByte(232))
        txt_password.BorderRadius = 8
        txt_password.Cursor = Cursors.IBeam
        txt_password.CustomizableEdges = CustomizableEdges5
        txt_password.DefaultText = ""
        txt_password.FillColor = Color.FromArgb(CByte(244), CByte(246), CByte(248))
        txt_password.FocusedState.BorderColor = Color.FromArgb(CByte(240), CByte(127), CByte(35))
        txt_password.Font = New Font("Segoe UI", 10F)
        txt_password.ForeColor = Color.Black
        txt_password.Location = New Point(55, 230)
        txt_password.Name = "txt_password"
        txt_password.PasswordChar = "●"c
        txt_password.PlaceholderForeColor = Color.DarkGray
        txt_password.PlaceholderText = "Password"
        txt_password.SelectedText = ""
        txt_password.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        txt_password.Size = New Size(320, 45)
        txt_password.TabIndex = 2
        txt_password.TextOffset = New Point(10, 0)
        ' 
        ' txt_username
        ' 
        txt_username.BorderColor = Color.FromArgb(CByte(221), CByte(226), CByte(232))
        txt_username.BorderRadius = 8
        txt_username.Cursor = Cursors.IBeam
        txt_username.CustomizableEdges = CustomizableEdges7
        txt_username.DefaultText = ""
        txt_username.FillColor = Color.FromArgb(CByte(244), CByte(246), CByte(248))
        txt_username.FocusedState.BorderColor = Color.FromArgb(CByte(240), CByte(127), CByte(35))
        txt_username.Font = New Font("Segoe UI", 10F)
        txt_username.ForeColor = Color.Black
        txt_username.Location = New Point(55, 170)
        txt_username.Name = "txt_username"
        txt_username.PlaceholderForeColor = Color.DarkGray
        txt_username.PlaceholderText = "Username"
        txt_username.SelectedText = ""
        txt_username.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        txt_username.Size = New Size(320, 45)
        txt_username.TabIndex = 1
        txt_username.TextOffset = New Point(10, 0)
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 20F, FontStyle.Bold)
        Label1.ForeColor = Color.FromArgb(CByte(15), CByte(52), CByte(97))
        Label1.Location = New Point(50, 80)
        Label1.Name = "Label1"
        Label1.Size = New Size(231, 37)
        Label1.TabIndex = 11
        Label1.Text = "Selamat Datang!"
        ' 
        ' msg_dialog
        ' 
        msg_dialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK
        msg_dialog.Caption = "Login"
        msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information
        msg_dialog.Parent = Me
        msg_dialog.Style = Guna.UI2.WinForms.MessageDialogStyle.Light
        msg_dialog.Text = Nothing
        ' 
        ' LoginForm
        ' 
        AcceptButton = btn_login
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(750, 450)
        Controls.Add(pnl_right)
        Controls.Add(pnl_left)
        FormBorderStyle = FormBorderStyle.None
        Name = "LoginForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Login System"
        pnl_left.ResumeLayout(False)
        pnl_left.PerformLayout()
        CType(pic_logo, ComponentModel.ISupportInitialize).EndInit()
        pnl_right.ResumeLayout(False)
        pnl_right.PerformLayout()
        ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents pnl_left As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnl_right As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lbl_brand_title As System.Windows.Forms.Label
    Friend WithEvents lbl_brand_desc As System.Windows.Forms.Label
    Friend WithEvents pic_logo As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_username As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txt_password As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btn_login As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_exit As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents msg_dialog As Guna.UI2.WinForms.Guna2MessageDialog

End Class
