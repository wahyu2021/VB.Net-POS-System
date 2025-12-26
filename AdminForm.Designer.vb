<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdminForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        
        Dim DataGridViewCellStyleHistory1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyleHistory2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyleHistory3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()

        Me.pnl_sidebar = New Guna.UI2.WinForms.Guna2Panel()
        Me.pic_logo_admin = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.btn_logout = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_nav_history = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_nav_products = New Guna.UI2.WinForms.Guna2Button()
        Me.lbl_admin_title = New System.Windows.Forms.Label()
        
        Me.pnl_header = New Guna.UI2.WinForms.Guna2Panel()
        Me.lbl_page_title = New System.Windows.Forms.Label()
        
        Me.tc_admin = New Guna.UI2.WinForms.Guna2TabControl()
        Me.tab_products = New System.Windows.Forms.TabPage()
        Me.tab_history = New System.Windows.Forms.TabPage()

        ' -- Components for Product Tab --
        Me.pnl_product_wrapper = New Guna.UI2.WinForms.Guna2Panel()
        Me.dgv_products = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.pnl_product_form = New Guna.UI2.WinForms.Guna2Panel()
        Me.txt_p_code = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txt_p_name = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txt_p_price = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txt_p_stock = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btn_p_save = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_p_delete = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_p_clear = New Guna.UI2.WinForms.Guna2Button()
        Me.lbl_p_info = New System.Windows.Forms.Label()
        Me.Guna2Separator1 = New Guna.UI2.WinForms.Guna2Separator()

        ' -- Components for History Tab --
        Me.pnl_history_wrapper = New Guna.UI2.WinForms.Guna2Panel()
        Me.dgv_history = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.msg_dialog = New Guna.UI2.WinForms.Guna2MessageDialog()

        Me.pnl_sidebar.SuspendLayout()
        CType(Me.pic_logo_admin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_header.SuspendLayout()
        Me.tc_admin.SuspendLayout()
        Me.tab_products.SuspendLayout()
        Me.pnl_product_wrapper.SuspendLayout()
        CType(Me.dgv_products, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_product_form.SuspendLayout()
        Me.tab_history.SuspendLayout()
        Me.pnl_history_wrapper.SuspendLayout()
        CType(Me.dgv_history, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        ' 
        ' Form Settings
        ' 
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(244, 246, 248)
        Me.ClientSize = New System.Drawing.Size(1100, 700)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.ControlBox = False
        Me.Name = "AdminForm"
        Me.Text = "Admin Dashboard"

        ' 
        ' pnl_sidebar
        ' 
        Me.pnl_sidebar.BackColor = System.Drawing.Color.FromArgb(15, 52, 97) ' Mart Navy
        Me.pnl_sidebar.Controls.Add(Me.pic_logo_admin)
        Me.pnl_sidebar.Controls.Add(Me.btn_logout)
        Me.pnl_sidebar.Controls.Add(Me.btn_nav_history)
        Me.pnl_sidebar.Controls.Add(Me.btn_nav_products)
        Me.pnl_sidebar.Controls.Add(Me.lbl_admin_title)
        Me.pnl_sidebar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnl_sidebar.Location = New System.Drawing.Point(0, 0)
        Me.pnl_sidebar.Name = "pnl_sidebar"
        Me.pnl_sidebar.Size = New System.Drawing.Size(250, 700)
        Me.pnl_sidebar.TabIndex = 0

        ' pic_logo_admin
        Me.pic_logo_admin.BackColor = System.Drawing.Color.Transparent
        Me.pic_logo_admin.FillColor = System.Drawing.Color.WhiteSmoke
        Me.pic_logo_admin.Location = New System.Drawing.Point(30, 30)
        Me.pic_logo_admin.Name = "pic_logo_admin"
        Me.pic_logo_admin.Size = New System.Drawing.Size(50, 50)
        Me.pic_logo_admin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic_logo_admin.BorderRadius = 5

        ' lbl_admin_title
        Me.lbl_admin_title.AutoSize = False
        Me.lbl_admin_title.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_admin_title.ForeColor = System.Drawing.Color.White
        Me.lbl_admin_title.Location = New System.Drawing.Point(90, 30)
        Me.lbl_admin_title.Size = New System.Drawing.Size(155, 60)
        Me.lbl_admin_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl_admin_title.Name = "lbl_admin_title"
        Me.lbl_admin_title.Text = "ADMIN"

        ' btn_nav_products
        Me.btn_nav_products.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton
        Me.btn_nav_products.BackColor = System.Drawing.Color.Transparent
        Me.btn_nav_products.Checked = True
        Me.btn_nav_products.CheckedState.FillColor = System.Drawing.Color.FromArgb(240, 127, 35) ' Fox Orange
        Me.btn_nav_products.CheckedState.ForeColor = System.Drawing.Color.White
        Me.btn_nav_products.FillColor = System.Drawing.Color.Transparent
        Me.btn_nav_products.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btn_nav_products.ForeColor = System.Drawing.Color.FromArgb(200, 200, 220)
        Me.btn_nav_products.Location = New System.Drawing.Point(15, 130)
        Me.btn_nav_products.Name = "btn_nav_products"
        Me.btn_nav_products.Size = New System.Drawing.Size(220, 45)
        Me.btn_nav_products.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btn_nav_products.TextOffset = New System.Drawing.Point(20, 0)
        Me.btn_nav_products.Text = "Kelola Produk"
        Me.btn_nav_products.BorderRadius = 8

        ' btn_nav_history
        Me.btn_nav_history.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton
        Me.btn_nav_history.BackColor = System.Drawing.Color.Transparent
        Me.btn_nav_history.CheckedState.FillColor = System.Drawing.Color.FromArgb(240, 127, 35)
        Me.btn_nav_history.CheckedState.ForeColor = System.Drawing.Color.White
        Me.btn_nav_history.FillColor = System.Drawing.Color.Transparent
        Me.btn_nav_history.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btn_nav_history.ForeColor = System.Drawing.Color.FromArgb(200, 200, 220)
        Me.btn_nav_history.Location = New System.Drawing.Point(15, 185)
        Me.btn_nav_history.Name = "btn_nav_history"
        Me.btn_nav_history.Size = New System.Drawing.Size(220, 45)
        Me.btn_nav_history.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btn_nav_history.TextOffset = New System.Drawing.Point(20, 0)
        Me.btn_nav_history.Text = "Riwayat Transaksi"
        Me.btn_nav_history.BorderRadius = 8

        ' btn_logout
        Me.btn_logout.Anchor = System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left
        Me.btn_logout.FillColor = System.Drawing.Color.FromArgb(220, 53, 69)
        Me.btn_logout.BackColor = System.Drawing.Color.Transparent
        Me.btn_logout.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btn_logout.ForeColor = System.Drawing.Color.White
        Me.btn_logout.Location = New System.Drawing.Point(25, 630)
        Me.btn_logout.Name = "btn_logout"
        Me.btn_logout.Size = New System.Drawing.Size(200, 40)
        Me.btn_logout.Text = "LOGOUT"
        Me.btn_logout.BorderRadius = 20

        ' 
        ' pnl_header
        ' 
        Me.pnl_header.BackColor = System.Drawing.Color.White
        Me.pnl_header.Controls.Add(Me.lbl_page_title)
        Me.pnl_header.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_header.Location = New System.Drawing.Point(250, 0)
        Me.pnl_header.Name = "pnl_header"
        Me.pnl_header.ShadowDecoration.Enabled = True
        Me.pnl_header.Size = New System.Drawing.Size(850, 70)
        Me.pnl_header.TabIndex = 1

        ' lbl_page_title
        Me.lbl_page_title.AutoSize = True
        Me.lbl_page_title.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_page_title.ForeColor = System.Drawing.Color.FromArgb(15, 52, 97)
        Me.lbl_page_title.Location = New System.Drawing.Point(30, 20)
        Me.lbl_page_title.Name = "lbl_page_title"
        Me.lbl_page_title.Text = "Manajemen Produk"

        ' 
        ' tc_admin
        ' 
        Me.tc_admin.Controls.Add(Me.tab_products)
        Me.tc_admin.Controls.Add(Me.tab_history)
        Me.tc_admin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tc_admin.TabMenuVisible = False
        Me.tc_admin.Location = New System.Drawing.Point(250, 70)
        Me.tc_admin.Name = "tc_admin"
        Me.tc_admin.SelectedIndex = 0
        Me.tc_admin.Size = New System.Drawing.Size(850, 630)
        Me.tc_admin.TabIndex = 2
        
        ' 
        ' tab_products
        ' 
        Me.tab_products.BackColor = System.Drawing.Color.FromArgb(244, 246, 248)
        Me.tab_products.Controls.Add(Me.pnl_product_wrapper)
        Me.tab_products.Location = New System.Drawing.Point(184, 4)
        Me.tab_products.Name = "tab_products"
        Me.tab_products.Padding = New System.Windows.Forms.Padding(20)
        Me.tab_products.Size = New System.Drawing.Size(662, 622)
        Me.tab_products.TabIndex = 0
        Me.tab_products.Text = "Products"

        ' pnl_product_wrapper (Card)
        Me.pnl_product_wrapper.BackColor = System.Drawing.Color.Transparent
        Me.pnl_product_wrapper.BorderRadius = 10
        Me.pnl_product_wrapper.FillColor = System.Drawing.Color.White
        Me.pnl_product_wrapper.Controls.Add(Me.dgv_products)
        Me.pnl_product_wrapper.Controls.Add(Me.pnl_product_form)
        Me.pnl_product_wrapper.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_product_wrapper.Padding = New System.Windows.Forms.Padding(10)
        Me.pnl_product_wrapper.ShadowDecoration.BorderRadius = 10
        Me.pnl_product_wrapper.ShadowDecoration.Depth = 5
        Me.pnl_product_wrapper.ShadowDecoration.Enabled = True
        Me.pnl_product_wrapper.Location = New System.Drawing.Point(20, 20)
        Me.pnl_product_wrapper.Name = "pnl_product_wrapper"
        Me.pnl_product_wrapper.Size = New System.Drawing.Size(622, 582)
        Me.pnl_product_wrapper.TabIndex = 0

        ' pnl_product_form
        Me.pnl_product_form.Controls.Add(Me.Guna2Separator1)
        Me.pnl_product_form.Controls.Add(Me.lbl_p_info)
        Me.pnl_product_form.Controls.Add(Me.btn_p_clear)
        Me.pnl_product_form.Controls.Add(Me.btn_p_delete)
        Me.pnl_product_form.Controls.Add(Me.btn_p_save)
        Me.pnl_product_form.Controls.Add(Me.txt_p_stock)
        Me.pnl_product_form.Controls.Add(Me.txt_p_price)
        Me.pnl_product_form.Controls.Add(Me.txt_p_name)
        Me.pnl_product_form.Controls.Add(Me.txt_p_code)
        Me.pnl_product_form.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_product_form.Location = New System.Drawing.Point(10, 10)
        Me.pnl_product_form.Name = "pnl_product_form"
        Me.pnl_product_form.Size = New System.Drawing.Size(602, 240)
        Me.pnl_product_form.TabIndex = 0

        ' Inputs (Disusun Vertikal agar aman & rapi)
        Me.txt_p_code.PlaceholderText = "Kode Produk (Unik)"
        Me.txt_p_code.Location = New System.Drawing.Point(20, 20)
        Me.txt_p_code.Size = New System.Drawing.Size(250, 40)
        Me.txt_p_code.BorderRadius = 5
        
        Me.txt_p_name.PlaceholderText = "Nama Produk"
        Me.txt_p_name.Location = New System.Drawing.Point(20, 75)
        Me.txt_p_name.Size = New System.Drawing.Size(400, 40)
        Me.txt_p_name.BorderRadius = 5

        Me.txt_p_price.PlaceholderText = "Harga (Rp)"
        Me.txt_p_price.Location = New System.Drawing.Point(20, 130)
        Me.txt_p_price.Size = New System.Drawing.Size(190, 40)
        Me.txt_p_price.BorderRadius = 5

        Me.txt_p_stock.PlaceholderText = "Stok Awal"
        Me.txt_p_stock.Location = New System.Drawing.Point(230, 130)
        Me.txt_p_stock.Size = New System.Drawing.Size(190, 40)
        Me.txt_p_stock.BorderRadius = 5

        ' Buttons (Disusun di Kanan Atas)
        Me.btn_p_save.Text = "SIMPAN"
        Me.btn_p_save.FillColor = System.Drawing.Color.FromArgb(240, 127, 35)
        Me.btn_p_save.BackColor = System.Drawing.Color.Transparent
        Me.btn_p_save.Location = New System.Drawing.Point(450, 20)
        Me.btn_p_save.Size = New System.Drawing.Size(130, 45)
        Me.btn_p_save.BorderRadius = 8
        Me.btn_p_save.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right

        Me.btn_p_delete.Text = "HAPUS"
        Me.btn_p_delete.FillColor = System.Drawing.Color.FromArgb(220, 53, 69)
        Me.btn_p_delete.BackColor = System.Drawing.Color.Transparent
        Me.btn_p_delete.Location = New System.Drawing.Point(450, 75)
        Me.btn_p_delete.Size = New System.Drawing.Size(130, 45)
        Me.btn_p_delete.BorderRadius = 8
        Me.btn_p_delete.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        
        Me.btn_p_clear.Text = "RESET"
        Me.btn_p_clear.FillColor = System.Drawing.Color.Gray
        Me.btn_p_clear.BackColor = System.Drawing.Color.Transparent
        Me.btn_p_clear.Location = New System.Drawing.Point(450, 130)
        Me.btn_p_clear.Size = New System.Drawing.Size(130, 45)
        Me.btn_p_clear.BorderRadius = 8
        Me.btn_p_clear.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        
        Me.Guna2Separator1.Location = New System.Drawing.Point(20, 190)
        Me.Guna2Separator1.Size = New System.Drawing.Size(560, 10)
        Me.Guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right

        Me.lbl_p_info.Text = "*Klik baris di tabel untuk mengedit data produk."
        Me.lbl_p_info.ForeColor = System.Drawing.Color.Gray
        Me.lbl_p_info.Location = New System.Drawing.Point(20, 205)
        Me.lbl_p_info.AutoSize = True

        ' dgv_products
        Me.dgv_products.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_products.BackgroundColor = System.Drawing.Color.White
        Me.dgv_products.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv_products.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgv_products.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_products.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_products.ColumnHeadersHeight = 45
        Me.dgv_products.ReadOnly = True
        Me.dgv_products.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_products.AllowUserToAddRows = False
        Me.dgv_products.AllowUserToDeleteRows = False
        Me.dgv_products.AllowUserToResizeRows = False
        
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(15, 52, 97)
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(15, 52, 97)
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True
        Me.dgv_products.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(71, 69, 94)
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(231, 240, 255)
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(71, 69, 94)
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False
        Me.dgv_products.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_products.GridColor = System.Drawing.Color.FromArgb(240, 240, 240)
        Me.dgv_products.RowHeadersVisible = False
        Me.dgv_products.RowTemplate.Height = 35

        ' 
        ' tab_history
        ' 
        Me.tab_history.BackColor = System.Drawing.Color.FromArgb(244, 246, 248)
        Me.tab_history.Controls.Add(Me.pnl_history_wrapper)
        Me.tab_history.Location = New System.Drawing.Point(184, 4)
        Me.tab_history.Name = "tab_history"
        Me.tab_history.Padding = New System.Windows.Forms.Padding(20)
        Me.tab_history.Size = New System.Drawing.Size(662, 622)
        Me.tab_history.TabIndex = 1
        Me.tab_history.Text = "History"

        ' pnl_history_wrapper
        Me.pnl_history_wrapper.BackColor = System.Drawing.Color.Transparent
        Me.pnl_history_wrapper.BorderRadius = 10
        Me.pnl_history_wrapper.FillColor = System.Drawing.Color.White
        Me.pnl_history_wrapper.Controls.Add(Me.dgv_history)
        Me.pnl_history_wrapper.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_history_wrapper.ShadowDecoration.BorderRadius = 10
        Me.pnl_history_wrapper.ShadowDecoration.Depth = 5
        Me.pnl_history_wrapper.ShadowDecoration.Enabled = True
        Me.pnl_history_wrapper.Location = New System.Drawing.Point(20, 20)
        Me.pnl_history_wrapper.Name = "pnl_history_wrapper"
        Me.pnl_history_wrapper.Size = New System.Drawing.Size(622, 582)
        Me.pnl_history_wrapper.TabIndex = 0
        Me.pnl_history_wrapper.Padding = New System.Windows.Forms.Padding(10)

        ' dgv_history
        Me.dgv_history.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_history.BackgroundColor = System.Drawing.Color.White
        Me.dgv_history.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv_history.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        
        DataGridViewCellStyleHistory2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyleHistory2.BackColor = System.Drawing.Color.FromArgb(15, 52, 97)
        DataGridViewCellStyleHistory2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyleHistory2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyleHistory2.SelectionBackColor = System.Drawing.Color.FromArgb(15, 52, 97)
        Me.dgv_history.ColumnHeadersDefaultCellStyle = DataGridViewCellStyleHistory2
        Me.dgv_history.ColumnHeadersHeight = 45
        Me.dgv_history.ReadOnly = True
        Me.dgv_history.RowHeadersVisible = False
        Me.dgv_history.RowTemplate.Height = 35
        Me.dgv_history.AllowUserToAddRows = False
        Me.dgv_history.AllowUserToDeleteRows = False
        
        ' msg_dialog
        Me.msg_dialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK
        Me.msg_dialog.Caption = "Admin"
        Me.msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information
        Me.msg_dialog.Parent = Me
        Me.msg_dialog.Style = Guna.UI2.WinForms.MessageDialogStyle.Light
        Me.msg_dialog.Text = Nothing
        
        Me.Controls.Add(Me.tc_admin)
        Me.Controls.Add(Me.pnl_header)
        Me.Controls.Add(Me.pnl_sidebar)
        
        Me.pnl_sidebar.ResumeLayout(False)
        Me.pnl_sidebar.PerformLayout()
        CType(Me.pic_logo_admin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_header.ResumeLayout(False)
        Me.pnl_header.PerformLayout()
        Me.tc_admin.ResumeLayout(False)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.tab_products.ResumeLayout(False)
        Me.pnl_product_wrapper.ResumeLayout(False)
        CType(Me.dgv_products, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_product_form.ResumeLayout(False)
        Me.pnl_product_form.PerformLayout()
        Me.tab_history.ResumeLayout(False)
        Me.pnl_history_wrapper.ResumeLayout(False)
        CType(Me.dgv_history, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnl_sidebar As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pic_logo_admin As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents pnl_header As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents tc_admin As Guna.UI2.WinForms.Guna2TabControl
    Friend WithEvents tab_products As System.Windows.Forms.TabPage
    Friend WithEvents tab_history As System.Windows.Forms.TabPage
    
    Friend WithEvents lbl_admin_title As System.Windows.Forms.Label
    Friend WithEvents lbl_page_title As System.Windows.Forms.Label
    
    Friend WithEvents btn_nav_products As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_nav_history As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_logout As Guna.UI2.WinForms.Guna2Button

    ' Product Tab
    Friend WithEvents pnl_product_wrapper As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents dgv_products As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents pnl_product_form As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents txt_p_code As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txt_p_name As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txt_p_price As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txt_p_stock As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btn_p_save As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_p_delete As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_p_clear As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lbl_p_info As System.Windows.Forms.Label
    Friend WithEvents Guna2Separator1 As Guna.UI2.WinForms.Guna2Separator

    ' History Tab
    Friend WithEvents pnl_history_wrapper As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents dgv_history As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents msg_dialog As Guna.UI2.WinForms.Guna2MessageDialog

End Class
