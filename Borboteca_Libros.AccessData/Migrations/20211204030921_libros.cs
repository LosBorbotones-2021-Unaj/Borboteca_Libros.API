using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Borboteca_Libros.AccessData.Migrations
{
    public partial class libros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Resenia = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Editorial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaDePublicacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pach = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    AutorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Libro_Autor_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibroGenero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibroGenero", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibroGenero_Genero_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Genero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibroGenero_Libro_LibroId",
                        column: x => x.LibroId,
                        principalTable: "Libro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Autor",
                columns: new[] { "Id", "NombreCompleto" },
                values: new object[,]
                {
                    { 1, "Antoine de Saint-Exupéry" },
                    { 2, "Javier Alexis Villa" },
                    { 3, "Carlos Javier Suarez" },
                    { 4, "Tomas Rojas" },
                    { 5, "Anonimo" },
                    { 6, "Vicente Blasco Ibañez" }
                });

            migrationBuilder.InsertData(
                table: "Genero",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Novela" },
                    { 2, "Terror" },
                    { 3, "Comedia" },
                    { 4, "Ficción" },
                    { 5, "Aventura" },
                    { 6, "Suspenso" }
                });

            migrationBuilder.InsertData(
                table: "Libro",
                columns: new[] { "Id", "AutorId", "Editorial", "FechaDePublicacion", "Imagen", "Pach", "Precio", "Resenia", "Titulo" },
                values: new object[,]
                {
                    { new Guid("72b51e64-c5e0-40cc-9022-9f0d3906dcc3"), 1, "Desconocida", new DateTime(2021, 10, 23, 14, 4, 18, 787, DateTimeKind.Unspecified), "https://static.ellitoral.com/um/fotos/294484_princi.jpg", "C:/Borboteca-libros/El_Principito_completo.pdf", 5000, "El principito es una novela corta y la obra más famosa del escritor y aviador francés Antoine de Saint-Exupéry.", "El principito" },
                    { new Guid("2550e1b1-9e48-43b4-875f-14634d4c07f1"), 5, "Free Editorial", new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.elsotano.com/imagenes/9788431/978843155164.JPG", "C:/Borboteca-libros/frutas_del_mundo.pdf", 3000, "La fruta ocupa un lugar fundamental en la dita mediterránea, y todos conocemos las enormes ventajas de integrarla en la alimentación. Nos resulta muy habitual su consumo, y en nuestro país es muy común ver campos cultivados con las más diversas especies. Además, gracias a la globalización del mercado y la rapidez en los transportes, podemos acceder a numerosas frutas que hace un tiempo nos eran desconocidas. Susanna Lyle ha elaborado esta guía exhaustiva que pretende ser una fuente de inspiración para todo aquel que desee cultivar y probar nuevos alimentos. Incluye especies muy comunes y otras menos conocidas, pero igualmente interesantes, que crecen en climas templados y subtropicales. Se presentan más de 300, y se proporciona información detallada sobre cada una, lo que hace de esta obra un enciclopedia única.", "Frutas del mundo" },
                    { new Guid("a76d59d2-3cb0-44b3-9041-4421e14c69c3"), 5, "Free Editorial", new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://viajes.nationalgeographic.com.es/medio/2021/08/23/la-exclusiva-costa-de-na-pali_a5d66976_2000x1333.jpg", "C:/Borboteca-libros/hawai.pdf", 2000, "'Hawai' es la historia de hombres y mujeres de distintas razas, religiones, costumbres y tradiciones, que cruzaron los mares atraídos por el hechizo de esas islas. James Michener concentra el interés del lector en un grupo familiar que vive las emociones, idilios y aventuras propias del ambiente que imperaba en las islas. Todo el acento de esta novela ha sido puesto por el autor en los personajes y en sus triunfos, tragedias, amores y odios personales.", "Hawai" },
                    { new Guid("2650baa6-334b-4e17-b7d5-9f773f964e37"), 5, "Free Editorial", new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://pics.filmaffinity.com/the_great_global_warming_swindle_tv_tv-508851081-large.jpg", "C:/Borboteca-libros/el_gran_fraude_del_calentamiento_global.pdf", 1000, "Free Spotlight trancribe este análisis realizado por expertos sobre la teoria del “calentamiento global por culpa del ser humano”, un tema tan polémico como inserto en la sociedad actual.", "El gran fraude del calentamiento global" },
                    { new Guid("b8778f7a-15ba-40a0-a66c-a50a7b01f2f3"), 5, "Free Editorial", new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.tuslibros.com/2d_covers/upscaled/1332021893.jpg", "C:/Borboteca-libros/la_correccion.pdf", 1500, "Tras el suicidio de su amigo Roithamer, el anónimo narrador de la novela llega a la casa del taxidermista Höller, en cuya buhardilla el suicida ha permanecido durante seis años entregado a la tarea de planear y construir, en el centro geométrico exacto del bosque de Kobernauss, un Cono que, desafiando las leyes de la construcción tradicional, estaba destinado a ser residencia y «felicidad suprema» de su hermana. Urdida en torno a un proceso obsesivo de creación y destrucción que se plasma en un afán de constante corrección, la novela es una reflexión sobre los problemas del hombre contemporáneo, enfrentado a la deshumanización, el desamor y la soledad.", "La correccion" },
                    { new Guid("2dd83fca-7e9f-45d0-a7df-a9e734bf1e79"), 5, "Free Editorial", new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.minceraft.cl/media/k2/items/cache/4d914480da9f0e177f0711403821d47b_M.jpg", "C:/Borboteca-libros/lo_que_es_bueno_para_ti_es_malo_para_mí.pdf", 4000, "Se trata de una persona que entendió la vida", "Lo que es bueno para ti es malo para mi" },
                    { new Guid("67f3d74e-039e-415c-8f82-be1a87111b3f"), 5, "Free Editorial", new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://m.media-amazon.com/images/I/413zycyOWKL.jpg", "C:/Borboteca-libros/la_barraca.pdf", 3000, "El tema de La Barraca es la injusticia de las personas ignorantes y pobres, cuyo sentido de la existencia se basa en la supervivencia. En esta novela critica a la vez que describe la sociedad de la época. Dicha novela cuenta la desgraciada historia de una familia pobre en la huerta valenciana.", "La barraca" },
                    { new Guid("3fe0deba-7374-4293-9067-c0ede9c768fe"), 5, "Free Editorial", new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://estaticos.muyinteresante.es/media/cache/1140x_thumb/uploads/images/gallery/5e5fce075bafe8711d08b2d5/nombres-luna_1.jpg", "C:/Borboteca-libros/lo_que_la_luna_grande_cambio.pdf", 2000, "Libro de inspiración que nos cuenta los grandes cambios de un satélite natural de la tierra", "Lo que la luna grande cambio" },
                    { new Guid("1759cd7f-a67e-419e-8923-db27b73b637d"), 5, "Freak World", new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.storytel.com/images/e/200x200/0002398771.jpg", "C:/Borboteca-libros/a_los_pies_de_venus.pdf", 3000, "Continuación de El Papa del Mar, en la que se da inicio a la historia amorosa que liga a Claudio Borja, un joven poeta valenciano, y Rosaura Salcedo, una rica dama argentina, esta novela en la que prosiguen sus avatares puede leerse perfectamente, sin embargo, como novela suelta.", "A los pies de Venus" },
                    { new Guid("93cd1293-5d5e-455e-a2cc-deaa1eceb064"), 5, "Free Editorial", new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/commons/thumb/7/75/Nyolcvan_nap_alatt_a_F%C3%B6ld_k%C3%B6r%C3%BCl.jpg/220px-Nyolcvan_nap_alatt_a_F%C3%B6ld_k%C3%B6r%C3%BCl.jpg", "C:/Borboteca-libros/la_vuelta_al_mundo_de_un_novelista_tomo_i.pdf", 3000, "Es un carrusel ameno e inolvidable de lugares, pueblos y personas en el que Blasco, como incomparable compañero de viaje, hace desfilar ante nuestros ojos la espléndida y fascinante variedad de unos paisajes de leyenda hoy en gran parte trivializados o desaparecidos", "La vuelta al mundo de un novelista" },
                    { new Guid("e87266d6-99cb-4afd-849b-89c49d36c250"), 5, "Free Editorial", new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.tuslibros.com/2d_covers/large/1509826828.jpg", "C:/Borboteca-libros/idioteces_de_los_idiotas_y_otras_tonterías.pdf", 6000, "Es el escritor actual en español más leído del mundo, y leyendo sus relatos se comprende el por qué: sencillamente porque nos divierte con sus brillantes reflexiones sobre temas cotidianos que a todos nos afectan. ", "Idioteces de los idiotas y otras tonterías" },
                    { new Guid("ebf123b7-0841-40ea-9546-ff7ccc17835c"), 5, "Free Editorial", new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://http2.mlstatic.com/D_NQ_NP_2X_822295-MLA45613745505_042021-F.webp", "C:/Borboteca-libros/en_la_puerta_del_cielo.pdf", 3000, "Antes de desaparecer junto a su ayudante americana, el astrofísico Lalo Múgica informa a una de sus vecinas de que ha encontrado las claves para abrir la puerta del cielo. Gerardo Vilela, un sencillo profesor de Instituto, gana una beca que le lleva de Lugo a Madrid. Cuando las enigmáticas vecinas del número 12 le realquilan la antigua casa de Múgica, él se siente feliz. Pero el ático guarda algo para él: un acta firmada por Pilatos que narra otra desaparición ocurrida en Judea el año de la muerte de Jesucristo. Con veinte siglos de diferencia, ambas desapariciones parecen estar extrañamente relacionadas..", "En la puerta del cielo" }
                });

            migrationBuilder.InsertData(
                table: "LibroGenero",
                columns: new[] { "Id", "GeneroId", "LibroId" },
                values: new object[,]
                {
                    { 1, 5, new Guid("2550e1b1-9e48-43b4-875f-14634d4c07f1") },
                    { 12, 4, new Guid("2550e1b1-9e48-43b4-875f-14634d4c07f1") },
                    { 2, 5, new Guid("a76d59d2-3cb0-44b3-9041-4421e14c69c3") },
                    { 13, 1, new Guid("a76d59d2-3cb0-44b3-9041-4421e14c69c3") },
                    { 5, 4, new Guid("2650baa6-334b-4e17-b7d5-9f773f964e37") },
                    { 6, 1, new Guid("b8778f7a-15ba-40a0-a66c-a50a7b01f2f3") },
                    { 14, 4, new Guid("b8778f7a-15ba-40a0-a66c-a50a7b01f2f3") },
                    { 7, 1, new Guid("2dd83fca-7e9f-45d0-a7df-a9e734bf1e79") },
                    { 8, 4, new Guid("67f3d74e-039e-415c-8f82-be1a87111b3f") },
                    { 9, 6, new Guid("3fe0deba-7374-4293-9067-c0ede9c768fe") },
                    { 10, 4, new Guid("93cd1293-5d5e-455e-a2cc-deaa1eceb064") },
                    { 3, 3, new Guid("e87266d6-99cb-4afd-849b-89c49d36c250") },
                    { 4, 5, new Guid("e87266d6-99cb-4afd-849b-89c49d36c250") },
                    { 11, 1, new Guid("ebf123b7-0841-40ea-9546-ff7ccc17835c") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libro_AutorId",
                table: "Libro",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_LibroGenero_GeneroId",
                table: "LibroGenero",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_LibroGenero_LibroId",
                table: "LibroGenero",
                column: "LibroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibroGenero");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "Libro");

            migrationBuilder.DropTable(
                name: "Autor");
        }
    }
}
