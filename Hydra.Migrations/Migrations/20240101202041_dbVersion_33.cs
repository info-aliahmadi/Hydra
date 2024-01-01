using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hydra.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class dbVersion_33 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Sale");

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    MetaKeywords = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    MetaTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true),
                    PictureId = table.Column<int>(type: "int", nullable: false),
                    ShowOnHomepage = table.Column<bool>(type: "bit", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category",
                        column: x => x.ParentCategoryId,
                        principalSchema: "Sale",
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TwoLetterIsoCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ThreeLetterIsoCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    AllowsBilling = table.Column<bool>(type: "bit", nullable: false),
                    AllowsShipping = table.Column<bool>(type: "bit", nullable: false),
                    NumericIsoCode = table.Column<int>(type: "int", nullable: false),
                    SubjectToVat = table.Column<bool>(type: "bit", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    LimitedToStores = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    DisplayLocale = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomFormatting = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    LimitedToStores = table.Column<bool>(type: "bit", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    RoundingTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryDate",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryDate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CouponCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdminComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountTypeId = table.Column<int>(type: "int", nullable: false),
                    UsePercentage = table.Column<bool>(type: "bit", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    MaximumDiscountAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    StartDateUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: true),
                    EndDateUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: true),
                    RequiresCouponCode = table.Column<bool>(type: "bit", nullable: false),
                    DiscountLimitationId = table.Column<int>(type: "int", nullable: false),
                    LimitationTimes = table.Column<int>(type: "int", nullable: false),
                    MaximumDiscountedQuantity = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    MetaKeywords = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    MetaTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PictureId = table.Column<int>(type: "int", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTag",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SearchTerm",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Keyword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchTerm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingMethod",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxCategory",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StateProvince",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateProvince", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StateProvince_Country",
                        column: x => x.CountryId,
                        principalSchema: "Sale",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiscountCategory",
                schema: "Sale",
                columns: table => new
                {
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount_AppliedToCategories", x => new { x.DiscountId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_DiscountCategory_Category",
                        column: x => x.CategoryId,
                        principalSchema: "Sale",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiscountCategory_Discount",
                        column: x => x.DiscountId,
                        principalSchema: "Sale",
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiscountManufacturer",
                schema: "Sale",
                columns: table => new
                {
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount_AppliedToManufacturers", x => new { x.DiscountId, x.ManufacturerId });
                    table.ForeignKey(
                        name: "FK_DiscountManufacturer_Discount",
                        column: x => x.DiscountId,
                        principalSchema: "Sale",
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiscountManufacturer_Manufacturer",
                        column: x => x.ManufacturerId,
                        principalSchema: "Sale",
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MetaKeywords = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    MetaTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FullDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminComment = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DeliveryDateId = table.Column<int>(type: "int", nullable: false),
                    TaxCategoryId = table.Column<int>(type: "int", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    MinStockQuantity = table.Column<int>(type: "int", nullable: false),
                    NotifyAdminForQuantityBelow = table.Column<int>(type: "int", nullable: false),
                    OrderMinimumQuantity = table.Column<int>(type: "int", nullable: false),
                    OrderMaximumQuantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    OldPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Length = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Width = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    AvailableStartDateTimeUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: true),
                    AvailableEndDateTimeUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    ApprovedRatingSum = table.Column<int>(type: "int", nullable: false),
                    NotApprovedRatingSum = table.Column<int>(type: "int", nullable: false),
                    ApprovedTotalReviews = table.Column<int>(type: "int", nullable: false),
                    NotApprovedTotalReviews = table.Column<int>(type: "int", nullable: false),
                    HasDiscountsApplied = table.Column<bool>(type: "bit", nullable: false),
                    MarkAsNew = table.Column<bool>(type: "bit", nullable: false),
                    MarkAsNewStartDateTimeUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: true),
                    MarkAsNewEndDateTimeUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: true),
                    NotReturnable = table.Column<bool>(type: "bit", nullable: false),
                    AllowedQuantities = table.Column<bool>(type: "bit", nullable: true),
                    IsTaxExempt = table.Column<bool>(type: "bit", nullable: false),
                    ShowOnHomepage = table.Column<bool>(type: "bit", nullable: false),
                    IsFreeShipping = table.Column<bool>(type: "bit", nullable: false),
                    AllowCustomerReviews = table.Column<bool>(type: "bit", nullable: false),
                    DisplayStockQuantity = table.Column<bool>(type: "bit", nullable: false),
                    DisableBuyButton = table.Column<bool>(type: "bit", nullable: false),
                    DisableWishlistButton = table.Column<bool>(type: "bit", nullable: false),
                    AvailableForPreOrder = table.Column<bool>(type: "bit", nullable: false),
                    CallForPrice = table.Column<bool>(type: "bit", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_DeliveryDate",
                        column: x => x.DeliveryDateId,
                        principalSchema: "Sale",
                        principalTable: "DeliveryDate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_TaxCategory",
                        column: x => x.TaxCategoryId,
                        principalSchema: "Sale",
                        principalTable: "TaxCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_User",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    StateProvinceId = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    County = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ZipPostalCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FaxNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Country",
                        column: x => x.CountryId,
                        principalSchema: "Sale",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_StateProvince",
                        column: x => x.StateProvinceId,
                        principalSchema: "Sale",
                        principalTable: "StateProvince",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_User",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaxRate",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxCategoryId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    StateProvinceId = table.Column<int>(type: "int", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxRate_Country",
                        column: x => x.CountryId,
                        principalSchema: "Sale",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaxRate_StateProvince",
                        column: x => x.StateProvinceId,
                        principalSchema: "Sale",
                        principalTable: "StateProvince",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaxRate_TaxCategory",
                        column: x => x.TaxCategoryId,
                        principalSchema: "Sale",
                        principalTable: "TaxCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiscountProduct",
                schema: "Sale",
                columns: table => new
                {
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount_AppliedToProducts", x => new { x.DiscountId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_DiscountProduct_Discount",
                        column: x => x.DiscountId,
                        principalSchema: "Sale",
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiscountProduct_Product",
                        column: x => x.ProductId,
                        principalSchema: "Sale",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Category_Mapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Category",
                        column: x => x.CategoryId,
                        principalSchema: "Sale",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Product",
                        column: x => x.ProductId,
                        principalSchema: "Sale",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductInventory",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    ReservedQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWarehouseInventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductInventory_Product",
                        column: x => x.ProductId,
                        principalSchema: "Sale",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductManufacturer",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Manufacturer_Mapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductManufacturer_Manufacturer",
                        column: x => x.ManufacturerId,
                        principalSchema: "Sale",
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductManufacturer_Product",
                        column: x => x.ProductId,
                        principalSchema: "Sale",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductPicture",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Picture_Mapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPicture_Product",
                        column: x => x.ProductId,
                        principalSchema: "Sale",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductTag",
                schema: "Sale",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductTagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_ProductTag_Mapping", x => new { x.ProductId, x.ProductTagId });
                    table.ForeignKey(
                        name: "FK_ProductProductTag_Product",
                        column: x => x.ProductId,
                        principalSchema: "Sale",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductProductTag_ProductTag",
                        column: x => x.ProductTagId,
                        principalSchema: "Sale",
                        principalTable: "ProductTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductReview",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ReplyText = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CustomerNotifiedOfReply = table.Column<bool>(type: "bit", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    HelpfulYesTotal = table.Column<int>(type: "int", nullable: false),
                    HelpfulNoTotal = table.Column<int>(type: "int", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReview_Product",
                        column: x => x.ProductId,
                        principalSchema: "Sale",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductReview_User",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RelatedProduct",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId1 = table.Column<int>(type: "int", nullable: false),
                    ProductId2 = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelatedProduct_Product",
                        column: x => x.ProductId1,
                        principalSchema: "Sale",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RelatedProduct_Product1",
                        column: x => x.ProductId2,
                        principalSchema: "Sale",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItem",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_Product",
                        column: x => x.ProductId,
                        principalSchema: "Sale",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_User",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ShipmentId = table.Column<int>(type: "int", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    ShippingMethodId = table.Column<int>(type: "int", nullable: false),
                    OrderStatusId = table.Column<byte>(type: "tinyint", nullable: false),
                    ShippingStatusId = table.Column<byte>(type: "tinyint", nullable: false),
                    PaymentStatusId = table.Column<byte>(type: "tinyint", nullable: false),
                    PaymentMethodId = table.Column<byte>(type: "tinyint", nullable: true),
                    UserCurrencyId = table.Column<int>(type: "int", nullable: false),
                    OrderShippingTax = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    OrderTax = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    OrderDiscount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    OrderTotal = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    RefundedAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CustomerIp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AllowStoringCreditCardNumber = table.Column<bool>(type: "bit", nullable: false),
                    PaidDateUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Address",
                        column: x => x.AddressId,
                        principalSchema: "Sale",
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Currency",
                        column: x => x.UserCurrencyId,
                        principalSchema: "Sale",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_ShippingMethod",
                        column: x => x.ShippingMethodId,
                        principalSchema: "Sale",
                        principalTable: "ShippingMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_User",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductReviewHelpfulness",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductReviewId = table.Column<int>(type: "int", nullable: false),
                    WasHelpful = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviewHelpfulness", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReviewHelpfulness_ProductReview",
                        column: x => x.ProductReviewId,
                        principalSchema: "Sale",
                        principalTable: "ProductReview",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductReviewHelpfulness_User",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDiscount",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDiscount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDiscount_Discount",
                        column: x => x.DiscountId,
                        principalSchema: "Sale",
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDiscount_Order",
                        column: x => x.OrderId,
                        principalSchema: "Sale",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPriceTax = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PriceTax = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DiscountAmountTax = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order",
                        column: x => x.OrderId,
                        principalSchema: "Sale",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_ProductId_Product_Id",
                        column: x => x.ProductId,
                        principalSchema: "Sale",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderNote",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderNote_Order",
                        column: x => x.OrderId,
                        principalSchema: "Sale",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderNote_User",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    TransactionTrackingCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PaymentTrackingCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PaymentDateUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: true),
                    PaymentTypeId = table.Column<byte>(type: "tinyint", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    CardType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CardName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaskedCreditCardNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CardCvv2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CardExpirationMonth = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CardExpirationYear = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurringPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Order",
                        column: x => x.OrderId,
                        principalSchema: "Sale",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shipment",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    TrackingNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalWeight = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    ShippedDateUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: true),
                    DeliveryDateUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: true),
                    ReadyForPickupDateUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: true),
                    AdminComment = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shipment_Order",
                        column: x => x.OrderId,
                        principalSchema: "Sale",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentItem",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipmentId = table.Column<int>(type: "int", nullable: false),
                    OrderItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipmentItem_OrderItem",
                        column: x => x.OrderItemId,
                        principalSchema: "Sale",
                        principalTable: "OrderItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShipmentItem_Shipment",
                        column: x => x.ShipmentId,
                        principalSchema: "Sale",
                        principalTable: "Shipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryId",
                schema: "Sale",
                table: "Address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StateProvinceId",
                schema: "Sale",
                table: "Address",
                column: "StateProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId",
                schema: "Sale",
                table: "Address",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_DisplayOrder",
                schema: "Sale",
                table: "Category",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentCategoryId",
                schema: "Sale",
                table: "Category",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_DisplayOrder",
                schema: "Sale",
                table: "Country",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Currency_DisplayOrder",
                schema: "Sale",
                table: "Currency",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_AppliedToCategories_Category_Id",
                schema: "Sale",
                table: "DiscountCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_AppliedToCategories_Discount_Id",
                schema: "Sale",
                table: "DiscountCategory",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_AppliedToManufacturers_Discount_Id",
                schema: "Sale",
                table: "DiscountManufacturer",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_AppliedToManufacturers_Manufacturer_Id",
                schema: "Sale",
                table: "DiscountManufacturer",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_AppliedToProducts_Discount_Id",
                schema: "Sale",
                table: "DiscountProduct",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_AppliedToProducts_Product_Id",
                schema: "Sale",
                table: "DiscountProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturer_DisplayOrder",
                schema: "Sale",
                table: "Manufacturer",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Order_AddressId",
                schema: "Sale",
                table: "Order",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CreatedOnUtc",
                schema: "Sale",
                table: "Order",
                column: "CreatedOnUtc",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShippingAddressId",
                schema: "Sale",
                table: "Order",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShippingMethodId",
                schema: "Sale",
                table: "Order",
                column: "ShippingMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserCurrencyId",
                schema: "Sale",
                table: "Order",
                column: "UserCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                schema: "Sale",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDiscount",
                schema: "Sale",
                table: "OrderDiscount",
                columns: new[] { "DiscountId", "OrderId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDiscount_OrderId",
                schema: "Sale",
                table: "OrderDiscount",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                schema: "Sale",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                schema: "Sale",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderNote_OrderId",
                schema: "Sale",
                table: "OrderNote",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderNote_UserId",
                schema: "Sale",
                table: "OrderNote",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringPayment_InitialOrderId",
                schema: "Sale",
                table: "Payment",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Deleted_and_Published",
                schema: "Sale",
                table: "Product",
                columns: new[] { "Published", "Deleted", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_DeliveryDateId",
                schema: "Sale",
                table: "Product",
                column: "DeliveryDateId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_TaxCategoryId",
                schema: "Sale",
                table: "Product",
                column: "TaxCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UserId",
                schema: "Sale",
                table: "Product",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PCM_Product_and_Category",
                schema: "Sale",
                table: "ProductCategory",
                columns: new[] { "CategoryId", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Category_Mapping_CategoryId",
                schema: "Sale",
                table: "ProductCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Category_Mapping_ProductId",
                schema: "Sale",
                table: "ProductCategory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWarehouseInventory_ProductId",
                schema: "Sale",
                table: "ProductInventory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PMM_Product_and_Manufacturer",
                schema: "Sale",
                table: "ProductManufacturer",
                columns: new[] { "ManufacturerId", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Manufacturer_Mapping_ManufacturerId",
                schema: "Sale",
                table: "ProductManufacturer",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Manufacturer_Mapping_ProductId",
                schema: "Sale",
                table: "ProductManufacturer",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Picture_Mapping_PictureId",
                schema: "Sale",
                table: "ProductPicture",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Picture_Mapping_ProductId",
                schema: "Sale",
                table: "ProductPicture",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTag_Mapping_Product_Id",
                schema: "Sale",
                table: "ProductProductTag",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTag_Mapping_ProductTag_Id",
                schema: "Sale",
                table: "ProductProductTag",
                column: "ProductTagId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_CustomerId",
                schema: "Sale",
                table: "ProductReview",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_ProductId",
                schema: "Sale",
                table: "ProductReview",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviewHelpfulness_ProductReviewId",
                schema: "Sale",
                table: "ProductReviewHelpfulness",
                column: "ProductReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviewHelpfulness_UserId",
                schema: "Sale",
                table: "ProductReviewHelpfulness",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTag_Name",
                schema: "Sale",
                table: "ProductTag",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedProduct_ProductId1",
                schema: "Sale",
                table: "RelatedProduct",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedProduct_ProductId2",
                schema: "Sale",
                table: "RelatedProduct",
                column: "ProductId2");

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_OrderId",
                schema: "Sale",
                table: "Shipment",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentItem_OrderItemId",
                schema: "Sale",
                table: "ShipmentItem",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentItem_ShipmentId",
                schema: "Sale",
                table: "ShipmentItem",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem",
                schema: "Sale",
                table: "ShoppingCartItem",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ProductId",
                schema: "Sale",
                table: "ShoppingCartItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_UserId",
                schema: "Sale",
                table: "ShoppingCartItem",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StateProvince_CountryId",
                schema: "Sale",
                table: "StateProvince",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRate_CountryId",
                schema: "Sale",
                table: "TaxRate",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRate_StateProvinceId",
                schema: "Sale",
                table: "TaxRate",
                column: "StateProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRate_TaxCategoryId",
                schema: "Sale",
                table: "TaxRate",
                column: "TaxCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscountCategory",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "DiscountManufacturer",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "DiscountProduct",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "OrderDiscount",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "OrderNote",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "Payment",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "ProductCategory",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "ProductInventory",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "ProductManufacturer",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "ProductPicture",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "ProductProductTag",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "ProductReviewHelpfulness",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "RelatedProduct",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "SearchTerm",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "ShipmentItem",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "ShoppingCartItem",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "TaxRate",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "Discount",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "Manufacturer",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "ProductTag",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "ProductReview",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "OrderItem",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "Shipment",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "DeliveryDate",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "TaxCategory",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "Currency",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "ShippingMethod",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "StateProvince",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "Sale");
        }
    }
}
