using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaprichoHexagonal.Adaptors.SQLServerDataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_administrador",
                columns: table => new
                {
                    administrador_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    reestablecer = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_administrador", x => x.administrador_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_categoria",
                columns: table => new
                {
                    categoria_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_categoria", x => x.categoria_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_cliente",
                columns: table => new
                {
                    cliente_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    reestablecer = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cliente", x => x.cliente_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_departamento",
                columns: table => new
                {
                    departamento_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_departamento", x => x.departamento_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_marca",
                columns: table => new
                {
                    marca_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_marca", x => x.marca_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_venta",
                columns: table => new
                {
                    venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cliente_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    total_producto = table.Column<int>(type: "int", nullable: false),
                    monto_total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    contacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_venta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    transaccion_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    comarca_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_venta", x => x.venta_id);
                    table.ForeignKey(
                        name: "FK_tb_venta_tb_cliente_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "tb_cliente",
                        principalColumn: "cliente_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_municipio",
                columns: table => new
                {
                    municipio_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    departamento_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_municipio", x => x.municipio_id);
                    table.ForeignKey(
                        name: "FK_tb_municipio_tb_departamento_departamento_id",
                        column: x => x.departamento_id,
                        principalTable: "tb_departamento",
                        principalColumn: "departamento_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_producto",
                columns: table => new
                {
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    ruta_imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre_imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    marca_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    categoria_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_producto", x => x.producto_id);
                    table.ForeignKey(
                        name: "FK_tb_producto_tb_categoria_categoria_id",
                        column: x => x.categoria_id,
                        principalTable: "tb_categoria",
                        principalColumn: "categoria_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_producto_tb_marca_marca_id",
                        column: x => x.marca_id,
                        principalTable: "tb_marca",
                        principalColumn: "marca_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_comarca",
                columns: table => new
                {
                    comarca_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    municipio_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_comarca", x => x.comarca_id);
                    table.ForeignKey(
                        name: "FK_tb_comarca_tb_municipio_municipio_id",
                        column: x => x.municipio_id,
                        principalTable: "tb_municipio",
                        principalColumn: "municipio_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_carrito",
                columns: table => new
                {
                    cliente_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_carrito", x => new { x.cliente_id, x.producto_id });
                    table.ForeignKey(
                        name: "FK_tb_carrito_tb_cliente_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "tb_cliente",
                        principalColumn: "cliente_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_carrito_tb_producto_producto_id",
                        column: x => x.producto_id,
                        principalTable: "tb_producto",
                        principalColumn: "producto_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_detalleventa",
                columns: table => new
                {
                    venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_detalleventa", x => new { x.venta_id, x.producto_id });
                    table.ForeignKey(
                        name: "FK_tb_detalleventa_tb_producto_producto_id",
                        column: x => x.producto_id,
                        principalTable: "tb_producto",
                        principalColumn: "producto_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_detalleventa_tb_venta_venta_id",
                        column: x => x.venta_id,
                        principalTable: "tb_venta",
                        principalColumn: "venta_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_carrito_producto_id",
                table: "tb_carrito",
                column: "producto_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_comarca_municipio_id",
                table: "tb_comarca",
                column: "municipio_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_detalleventa_producto_id",
                table: "tb_detalleventa",
                column: "producto_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_municipio_departamento_id",
                table: "tb_municipio",
                column: "departamento_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_producto_categoria_id",
                table: "tb_producto",
                column: "categoria_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_producto_marca_id",
                table: "tb_producto",
                column: "marca_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_venta_cliente_id",
                table: "tb_venta",
                column: "cliente_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_administrador");

            migrationBuilder.DropTable(
                name: "tb_carrito");

            migrationBuilder.DropTable(
                name: "tb_comarca");

            migrationBuilder.DropTable(
                name: "tb_detalleventa");

            migrationBuilder.DropTable(
                name: "tb_municipio");

            migrationBuilder.DropTable(
                name: "tb_producto");

            migrationBuilder.DropTable(
                name: "tb_venta");

            migrationBuilder.DropTable(
                name: "tb_departamento");

            migrationBuilder.DropTable(
                name: "tb_categoria");

            migrationBuilder.DropTable(
                name: "tb_marca");

            migrationBuilder.DropTable(
                name: "tb_cliente");
        }
    }
}
