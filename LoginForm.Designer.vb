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
        Me.components = New System.ComponentModel.Container()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.pnl_left = New Guna.UI2.WinForms.Guna2Panel()
        Me.pic_logo = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.lbl_brand_desc = New System.Windows.Forms.Label()
        Me.lbl_brand_title = New System.Windows.Forms.Label()
        Me.pnl_right = New Guna.UI2.WinForms.Guna2Panel()
        Me.btn_exit = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_login = New Guna.UI2.WinForms.Guna2Button()
        Me.txt_password = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txt_username = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.msg_dialog = New Guna.UI2.WinForms.Guna2MessageDialog()

        Me.pnl_left.SuspendLayout()
        CType(Me.pic_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_right.SuspendLayout()
        Me.SuspendLayout()
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.BorderRadius = 20
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'pnl_left (Mart Navy Background)
        '
        Me.pnl_left.BackColor = System.Drawing.Color.Empty
        Me.pnl_left.Controls.Add(Me.pic_logo)
        Me.pnl_left.Controls.Add(Me.lbl_brand_desc)
        Me.pnl_left.Controls.Add(Me.lbl_brand_title)
        Me.pnl_left.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnl_left.FillColor = System.Drawing.Color.FromArgb(15, 52, 97)
        Me.pnl_left.Location = New System.Drawing.Point(0, 0)
        Me.pnl_left.Name = "pnl_left"
        Me.pnl_left.Size = New System.Drawing.Size(320, 450)
        Me.pnl_left.TabIndex = 1
        '
        'pic_logo (LOGO PLACEHOLDER)
        '
        Me.pic_logo.BackColor = System.Drawing.Color.Transparent
        Me.pic_logo.BorderRadius = 10
        Me.pic_logo.FillColor = System.Drawing.Color.WhiteSmoke
        Me.pic_logo.Location = New System.Drawing.Point(110, 80)
        Me.pic_logo.Name = "pic_logo"
        Me.pic_logo.Size = New System.Drawing.Size(100, 100)
        Me.pic_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic_logo.TabIndex = 10
        Me.pic_logo.TabStop = False
        Me.pic_logo.UseTransparentBackground = True
        '
        'lbl_brand_desc
        '
        Me.lbl_brand_desc.AutoSize = True
        Me.lbl_brand_desc.BackColor = System.Drawing.Color.Transparent
        Me.lbl_brand_desc.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lbl_brand_desc.ForeColor = System.Drawing.Color.FromArgb(200, 200, 220)
        Me.lbl_brand_desc.Location = New System.Drawing.Point(40, 250)
        Me.lbl_brand_desc.Name = "lbl_brand_desc"
        Me.lbl_brand_desc.Size = New System.Drawing.Size(240, 38)
        Me.lbl_brand_desc.TabIndex = 1
        Me.lbl_brand_desc.Text = "Solusi Pintar untuk Pengelolaan Toko" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Efisiensi dalam genggaman."
        Me.lbl_brand_desc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_brand_title
        '
        Me.lbl_brand_title.AutoSize = True
        Me.lbl_brand_title.BackColor = System.Drawing.Color.Transparent
        Me.lbl_brand_title.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_brand_title.ForeColor = System.Drawing.Color.White
        Me.lbl_brand_title.Location = New System.Drawing.Point(75, 200)
        Me.lbl_brand_title.Name = "lbl_brand_title"
        Me.lbl_brand_title.Size = New System.Drawing.Size(167, 45)
        Me.lbl_brand_title.TabIndex = 0
        Me.lbl_brand_title.Text = "FoxeMart"
        '
        'pnl_right
        '
        Me.pnl_right.BackColor = System.Drawing.Color.White
        Me.pnl_right.Controls.Add(Me.btn_exit)
        Me.pnl_right.Controls.Add(Me.Label2)
        Me.pnl_right.Controls.Add(Me.btn_login)
        Me.pnl_right.Controls.Add(Me.txt_password)
        Me.pnl_right.Controls.Add(Me.txt_username)
        Me.pnl_right.Controls.Add(Me.Label1)
        Me.pnl_right.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_right.Location = New System.Drawing.Point(320, 0)
        Me.pnl_right.Name = "pnl_right"
        Me.pnl_right.Size = New System.Drawing.Size(430, 450)
        Me.pnl_right.TabIndex = 0
        '
        'btn_exit
        '
        Me.btn_exit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_exit.FillColor = System.Drawing.Color.White
        Me.btn_exit.HoverState.FillColor = System.Drawing.Color.Red
        Me.btn_exit.IconColor = System.Drawing.Color.Gray
        Me.btn_exit.Location = New System.Drawing.Point(380, 5)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(45, 29)
        Me.btn_exit.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(90, 107, 125)
        Me.Label2.Location = New System.Drawing.Point(55, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(225, 19)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Silakan login untuk mengakses kasir."
        '
        'btn_login (Fox Orange)
        '
        Me.btn_login.BorderRadius = 22
        Me.btn_login.FillColor = System.Drawing.Color.FromArgb(240, 127, 35)
        Me.btn_login.BackColor = System.Drawing.Color.Transparent
        Me.btn_login.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btn_login.ForeColor = System.Drawing.Color.White
        Me.btn_login.HoverState.FillColor = System.Drawing.Color.FromArgb(220, 100, 20)
        Me.btn_login.Location = New System.Drawing.Point(55, 310)
        Me.btn_login.Name = "btn_login"
        Me.btn_login.ShadowDecoration.BorderRadius = 22
        Me.btn_login.ShadowDecoration.Color = System.Drawing.Color.FromArgb(200, 200, 255)
        Me.btn_login.ShadowDecoration.Depth = 10
        Me.btn_login.ShadowDecoration.Enabled = True
        Me.btn_login.Size = New System.Drawing.Size(320, 45)
        Me.btn_login.TabIndex = 3
        Me.btn_login.Text = "MASUK"
        '
        'txt_password
        '
        Me.txt_password.BorderColor = System.Drawing.Color.FromArgb(221, 226, 232)
        Me.txt_password.BorderRadius = 8
        Me.txt_password.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_password.DefaultText = ""
        Me.txt_password.FillColor = System.Drawing.Color.FromArgb(244, 246, 248)
        Me.txt_password.FocusedState.BorderColor = System.Drawing.Color.FromArgb(240, 127, 35)
        Me.txt_password.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txt_password.ForeColor = System.Drawing.Color.Black
        Me.txt_password.Location = New System.Drawing.Point(55, 230)
        Me.txt_password.Name = "txt_password"
        Me.txt_password.PasswordChar = "●"
        Me.txt_password.PlaceholderForeColor = System.Drawing.Color.DarkGray
        Me.txt_password.PlaceholderText = "Password"
        Me.txt_password.SelectedText = ""
        Me.txt_password.Size = New System.Drawing.Size(320, 45)
        Me.txt_password.TabIndex = 2
        Me.txt_password.TextOffset = New System.Drawing.Point(10, 0)
        '
        'txt_username
        '
        Me.txt_username.BorderColor = System.Drawing.Color.FromArgb(221, 226, 232)
        Me.txt_username.BorderRadius = 8
        Me.txt_username.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_username.DefaultText = ""
        Me.txt_username.FillColor = System.Drawing.Color.FromArgb(244, 246, 248)
        Me.txt_username.FocusedState.BorderColor = System.Drawing.Color.FromArgb(240, 127, 35)
        Me.txt_username.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txt_username.ForeColor = System.Drawing.Color.Black
        Me.txt_username.Location = New System.Drawing.Point(55, 170)
        Me.txt_username.Name = "txt_username"
        Me.txt_username.PlaceholderForeColor = System.Drawing.Color.DarkGray
        Me.txt_username.PlaceholderText = "Username"
        Me.txt_username.SelectedText = ""
        Me.txt_username.Size = New System.Drawing.Size(320, 45)
        Me.txt_username.TabIndex = 1
        Me.txt_username.TextOffset = New System.Drawing.Point(10, 0)
        '
        'Label1 (Primary Text Color)
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(15, 52, 97)
        Me.Label1.Location = New System.Drawing.Point(50, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Text = "Selamat Datang!"
        '
        ' msg_dialog
        '
        Me.msg_dialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK
        Me.msg_dialog.Caption = "Login"
        Me.msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information
        Me.msg_dialog.Parent = Me
        Me.msg_dialog.Style = Guna.UI2.WinForms.MessageDialogStyle.Light
        Me.msg_dialog.Text = Nothing
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AcceptButton = Me.btn_login
        Me.ClientSize = New System.Drawing.Size(750, 450)
        Me.Controls.Add(Me.pnl_right)
        Me.Controls.Add(Me.pnl_left)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "LoginForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login System"
        Me.pnl_left.ResumeLayout(False)
        Me.pnl_left.PerformLayout()
        CType(Me.pic_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_right.ResumeLayout(False)
        Me.pnl_right.PerformLayout()
        Me.ResumeLayout(False)

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
