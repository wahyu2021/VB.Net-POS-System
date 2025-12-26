# UAS-1 - Aplikasi Penjualan (Point of Sale)

Aplikasi desktop Windows Forms untuk manajemen penjualan menggunakan VB.NET dan MySQL.

## 📋 Persyaratan Sistem

- **.NET 10.0** atau lebih baru
- **MySQL Server** (XAMPP/WAMP atau MySQL standalone)
- **Visual Studio 2022** (dengan workload .NET Desktop Development)

## 🗄️ Setup Database

1. **Jalankan MySQL Server** (melalui XAMPP/WAMP atau service MySQL)

2. **Buat database baru** dengan nama `uas_vb_db_penjualan`:
   ```sql
   CREATE DATABASE uas_vb_db_penjualan;
   USE uas_vb_db_penjualan;
   ```

3. **Buat tabel-tabel yang diperlukan**:

   ```sql
   -- Tabel Users
   CREATE TABLE users (
       id INT AUTO_INCREMENT PRIMARY KEY,
       username VARCHAR(50) NOT NULL UNIQUE,
       password VARCHAR(255) NOT NULL,
       role VARCHAR(20) NOT NULL DEFAULT 'kasir',
       created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
   );

   -- Tabel Products
   CREATE TABLE products (
       id INT AUTO_INCREMENT PRIMARY KEY,
       name VARCHAR(100) NOT NULL,
       price DECIMAL(15,2) NOT NULL,
       stock INT NOT NULL DEFAULT 0,
       created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
   );

   -- Tabel Sales
   CREATE TABLE sales (
       id INT AUTO_INCREMENT PRIMARY KEY,
       user_id INT,
       total DECIMAL(15,2) NOT NULL,
       discount DECIMAL(15,2) DEFAULT 0,
       grand_total DECIMAL(15,2) NOT NULL,
       sale_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
       FOREIGN KEY (user_id) REFERENCES users(id)
   );

   -- Tabel Sale Details
   CREATE TABLE sale_details (
       id INT AUTO_INCREMENT PRIMARY KEY,
       sale_id INT,
       product_id INT,
       quantity INT NOT NULL,
       price DECIMAL(15,2) NOT NULL,
       subtotal DECIMAL(15,2) NOT NULL,
       FOREIGN KEY (sale_id) REFERENCES sales(id),
       FOREIGN KEY (product_id) REFERENCES products(id)
   );
   ```

4. **Insert data awal** (opsional):
   ```sql
   -- Tambah user admin (password: admin123)
   INSERT INTO users (username, password, role) VALUES ('admin', 'admin123', 'admin');
   
   -- Tambah user kasir (password: kasir123)
   INSERT INTO users (username, password, role) VALUES ('kasir', 'kasir123', 'kasir');
   
   -- Tambah sample produk
   INSERT INTO products (name, price, stock) VALUES 
   ('Produk A', 10000, 100),
   ('Produk B', 25000, 50),
   ('Produk C', 15000, 75);
   ```

## ⚙️ Konfigurasi Koneksi Database

Jika konfigurasi MySQL Anda berbeda, edit file `UAS-1\Core\DatabaseConnection.vb`:

```vb
Dim conn As New MySqlConnection("Server=localhost;Database=uas_vb_db_penjualan;Uid=root;Pwd=;")
```

Sesuaikan parameter berikut:
- `Server` - alamat server MySQL (default: localhost)
- `Database` - nama database (default: uas_vb_db_penjualan)
- `Uid` - username MySQL (default: root)
- `Pwd` - password MySQL (default: kosong)

## 🚀 Cara Menjalankan

### Via Visual Studio
1. Buka file `UAS-1.slnx` dengan Visual Studio 2022
2. Restore NuGet packages (otomatis atau via `dotnet restore`)
3. Tekan **F5** atau klik **Start** untuk menjalankan

### Via Command Line
```bash
cd UAS-1

# Restore dependencies
dotnet restore

# Build project
dotnet build

# Run aplikasi
dotnet run
```

## 📦 Dependencies (NuGet Packages)

- **Guna.UI2.WinForms** (v2.0.4.7) - Modern UI components
- **MySql.Data** (v9.5.0) - MySQL connector

## 📁 Struktur Folder

```
UAS-1/
├── UAS-1.slnx            # Solution file
└── UAS-1/                # Project folder
    ├── Core/             # Database connection & Session management
    │   ├── DatabaseConnection.vb
    │   └── Session.vb
    ├── Models/           # Data models/entities
    │   ├── Product.vb
    │   ├── Sale.vb
    │   ├── SaleDetail.vb
    │   └── User.vb
    ├── Repositories/     # Data access layer
    │   ├── ProductRepository.vb
    │   ├── SaleRepository.vb
    │   └── UserRepository.vb
    ├── Services/         # Business logic
    │   └── DiscountService.vb
    ├── Utils/            # Utility classes
    │   └── Logger.vb
    ├── Assets/           # Images, icons, etc.
    ├── LoginForm.vb      # Form login
    ├── Form1.vb          # Form utama (kasir)
    ├── AdminForm.vb      # Form admin
    └── UAS-1.vbproj      # Project file
```

## 🔐 Default Login

| Username | Password  | Role  |
|----------|-----------|-------|
| admin    | admin123  | Admin |
| kasir    | kasir123  | Kasir |

## 📝 Catatan

- Pastikan MySQL Server berjalan sebelum menjalankan aplikasi
- Jika menggunakan XAMPP, pastikan module MySQL sudah di-start
- Untuk production, disarankan menggunakan password yang di-hash

## 👨‍💻 Dibuat Untuk

Tugas UAS Mata Kuliah **Pemrograman Visual** - Semester 5
