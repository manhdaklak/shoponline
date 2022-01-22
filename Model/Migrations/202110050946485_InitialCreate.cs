namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CT_DatHang",
                c => new
                    {
                        MaChiTiet = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        MaHD = c.Int(nullable: false),
                        MaSP = c.Int(nullable: false),
                        MaChiTietSP = c.Int(),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Decimal(nullable: false, storeType: "money"),
                        ChietKhau = c.Decimal(storeType: "money"),
                        ThanhTien = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => t.MaChiTiet)
                .ForeignKey("dbo.CT_SanPham", t => t.MaChiTietSP)
                .ForeignKey("dbo.SanPham", t => t.MaSP)
                .ForeignKey("dbo.DatHang", t => t.MaHD)
                .Index(t => t.MaHD)
                .Index(t => t.MaSP)
                .Index(t => t.MaChiTietSP);
            
            CreateTable(
                "dbo.CT_SanPham",
                c => new
                    {
                        MaChiTiet = c.Int(nullable: false),
                        MaSP = c.Int(),
                        Size = c.String(maxLength: 10, fixedLength: true),
                        MauSac = c.String(maxLength: 50),
                        SoLuong = c.Int(),
                    })
                .PrimaryKey(t => t.MaChiTiet)
                .ForeignKey("dbo.SanPham", t => t.MaSP)
                .Index(t => t.MaSP);
            
            CreateTable(
                "dbo.SanPham",
                c => new
                    {
                        MaSP = c.Int(nullable: false, identity: true),
                        AnhSP = c.String(nullable: false, maxLength: 300, unicode: false),
                        TenSP = c.String(nullable: false, maxLength: 300),
                        TieuDeSP = c.String(maxLength: 250),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Decimal(nullable: false, storeType: "money"),
                        MoTa = c.String(unicode: false, storeType: "text"),
                        MaNCC = c.Int(nullable: false),
                        NgayNhap = c.DateTime(),
                        NgayThayDoi = c.DateTime(),
                        TrangThai = c.Boolean(),
                    })
                .PrimaryKey(t => t.MaSP)
                .ForeignKey("dbo.NhaCungCap", t => t.MaNCC)
                .Index(t => t.MaNCC);
            
            CreateTable(
                "dbo.DanhMucSanPham",
                c => new
                    {
                        MaDMSP = c.Int(nullable: false, identity: true),
                        MaDM = c.Int(),
                        MaSP = c.Int(),
                        TieuDe = c.String(maxLength: 250),
                        NgayTao = c.DateTime(),
                        NgayThayDoi = c.DateTime(),
                        TrangThai = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaDMSP)
                .ForeignKey("dbo.DanhMuc", t => t.MaDM)
                .ForeignKey("dbo.SanPham", t => t.MaSP)
                .Index(t => t.MaDM)
                .Index(t => t.MaSP);
            
            CreateTable(
                "dbo.DanhMuc",
                c => new
                    {
                        MaDM = c.Int(nullable: false, identity: true),
                        TenDM = c.String(nullable: false, maxLength: 250),
                        TieuDe = c.String(maxLength: 250),
                        NgayTao = c.DateTime(),
                        NgayThayDoi = c.DateTime(),
                        TrangThai = c.Boolean(),
                    })
                .PrimaryKey(t => t.MaDM);
            
            CreateTable(
                "dbo.GioHang",
                c => new
                    {
                        MaKH = c.Int(nullable: false),
                        MaSP = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MaKH, t.MaSP })
                .ForeignKey("dbo.KhachHang", t => t.MaKH)
                .ForeignKey("dbo.SanPham", t => t.MaSP)
                .Index(t => t.MaKH)
                .Index(t => t.MaSP);
            
            CreateTable(
                "dbo.KhachHang",
                c => new
                    {
                        MaKH = c.Int(nullable: false, identity: true),
                        TenKH = c.String(nullable: false, maxLength: 50),
                        SDT = c.String(maxLength: 50),
                        DiaChi = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaKH);
            
            CreateTable(
                "dbo.NguoiDung",
                c => new
                    {
                        MaND = c.Int(nullable: false, identity: true),
                        TenND = c.String(nullable: false, maxLength: 200),
                        SDT = c.String(nullable: false, maxLength: 50),
                        Email = c.String(maxLength: 50),
                        TenDangNhap = c.String(nullable: false, maxLength: 50, unicode: false),
                        MatKhau = c.String(nullable: false, maxLength: 50, unicode: false),
                        DiaChi = c.String(maxLength: 250),
                        KhachHangID = c.Int(),
                        RoleID = c.Int(),
                        NgayTao = c.DateTime(),
                        NgayThayDoi = c.DateTime(),
                        TrangThai = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaND)
                .ForeignKey("dbo.Role", t => t.RoleID)
                .ForeignKey("dbo.KhachHang", t => t.KhachHangID)
                .Index(t => t.KhachHangID)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.DatHang",
                c => new
                    {
                        MaHD = c.Int(nullable: false, identity: true),
                        MaNV = c.Int(nullable: false),
                        NgayMua = c.DateTime(nullable: false),
                        NgayGiao = c.DateTime(),
                        TrangThai = c.Boolean(),
                    })
                .PrimaryKey(t => t.MaHD)
                .ForeignKey("dbo.NguoiDung", t => t.MaNV)
                .Index(t => t.MaNV);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        TenRole = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.NhaCungCap",
                c => new
                    {
                        MaNCC = c.Int(nullable: false, identity: true),
                        TenNCC = c.String(maxLength: 50),
                        DiaChi = c.String(maxLength: 50),
                        Email = c.String(maxLength: 10, fixedLength: true),
                        SDT = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.MaNCC);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPham", "MaNCC", "dbo.NhaCungCap");
            DropForeignKey("dbo.GioHang", "MaSP", "dbo.SanPham");
            DropForeignKey("dbo.NguoiDung", "KhachHangID", "dbo.KhachHang");
            DropForeignKey("dbo.NguoiDung", "RoleID", "dbo.Role");
            DropForeignKey("dbo.DatHang", "MaNV", "dbo.NguoiDung");
            DropForeignKey("dbo.CT_DatHang", "MaHD", "dbo.DatHang");
            DropForeignKey("dbo.GioHang", "MaKH", "dbo.KhachHang");
            DropForeignKey("dbo.DanhMucSanPham", "MaSP", "dbo.SanPham");
            DropForeignKey("dbo.DanhMucSanPham", "MaDM", "dbo.DanhMuc");
            DropForeignKey("dbo.CT_SanPham", "MaSP", "dbo.SanPham");
            DropForeignKey("dbo.CT_DatHang", "MaSP", "dbo.SanPham");
            DropForeignKey("dbo.CT_DatHang", "MaChiTietSP", "dbo.CT_SanPham");
            DropIndex("dbo.DatHang", new[] { "MaNV" });
            DropIndex("dbo.NguoiDung", new[] { "RoleID" });
            DropIndex("dbo.NguoiDung", new[] { "KhachHangID" });
            DropIndex("dbo.GioHang", new[] { "MaSP" });
            DropIndex("dbo.GioHang", new[] { "MaKH" });
            DropIndex("dbo.DanhMucSanPham", new[] { "MaSP" });
            DropIndex("dbo.DanhMucSanPham", new[] { "MaDM" });
            DropIndex("dbo.SanPham", new[] { "MaNCC" });
            DropIndex("dbo.CT_SanPham", new[] { "MaSP" });
            DropIndex("dbo.CT_DatHang", new[] { "MaChiTietSP" });
            DropIndex("dbo.CT_DatHang", new[] { "MaSP" });
            DropIndex("dbo.CT_DatHang", new[] { "MaHD" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.NhaCungCap");
            DropTable("dbo.Role");
            DropTable("dbo.DatHang");
            DropTable("dbo.NguoiDung");
            DropTable("dbo.KhachHang");
            DropTable("dbo.GioHang");
            DropTable("dbo.DanhMuc");
            DropTable("dbo.DanhMucSanPham");
            DropTable("dbo.SanPham");
            DropTable("dbo.CT_SanPham");
            DropTable("dbo.CT_DatHang");
        }
    }
}
