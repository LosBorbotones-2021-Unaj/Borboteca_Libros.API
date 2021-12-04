using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Borboteca_Libros.Domain.Entities;

namespace Borboteca_Libros.AccessData.Configurations
{
    public class ConfigLibro
    {
        public ConfigLibro(EntityTypeBuilder<Libro> BuilderLibro) 
        {

            BuilderLibro.HasKey(x => x.Id);
            BuilderLibro.Property(x => x.Titulo).IsRequired().HasMaxLength(50);
            BuilderLibro.Property(x => x.Resenia).IsRequired().HasMaxLength(1000);
            BuilderLibro.Property(x => x.Editorial).IsRequired().HasMaxLength(50);
            BuilderLibro.Property(x => x.FechaDePublicacion).IsRequired();
            BuilderLibro.Property(x => x.Imagen).IsRequired();
            BuilderLibro.Property(x => x.Pach).IsRequired().HasMaxLength(120);
            BuilderLibro.Property(x => x.Precio).IsRequired();
            BuilderLibro.HasMany(x => x.LibroGenero).WithOne(x => x.Libro).HasForeignKey(x => x.LibroId);
            BuilderLibro.HasOne(x => x.Autor).WithMany(x => x.Libro).HasForeignKey(x => x.AutorId);

            BuilderLibro.HasData(
                new Libro
                {
                    Id = Guid.Parse("2550E1B1-9E48-43B4-875F-14634D4C07F1"),
                    Titulo = "Frutas del mundo",
                    Resenia = "La fruta ocupa un lugar fundamental en la dita mediterránea, y todos conocemos las enormes ventajas de integrarla en la alimentación. Nos resulta muy habitual su consumo, y en nuestro país es muy común ver campos cultivados con las más diversas especies. Además, gracias a la globalización del mercado y la rapidez en los transportes, podemos acceder a numerosas frutas que hace un tiempo nos eran desconocidas. Susanna Lyle ha elaborado esta guía exhaustiva que pretende ser una fuente de inspiración para todo aquel que desee cultivar y probar nuevos alimentos. Incluye especies muy comunes y otras menos conocidas, pero igualmente interesantes, que crecen en climas templados y subtropicales. Se presentan más de 300, y se proporciona información detallada sobre cada una, lo que hace de esta obra un enciclopedia única.",
                    Editorial = "Free Editorial",
                    FechaDePublicacion = DateTime.Parse("2021-11-01 00:00:00.0000000"),
                    Imagen = "https://www.elsotano.com/imagenes/9788431/978843155164.JPG",
                    Pach = "C:/Borboteca-libros/frutas_del_mundo.pdf",
                    Precio = 3000,
                    AutorId = 5
                });
            BuilderLibro.HasData(
                new Libro
                {
                    Id = Guid.Parse("A76D59D2-3CB0-44B3-9041-4421E14C69C3"),
                    Titulo = "Hawai",
                    Resenia = "'Hawai' es la historia de hombres y mujeres de distintas razas, religiones, costumbres y tradiciones, que cruzaron los mares atraídos por el hechizo de esas islas. James Michener concentra el interés del lector en un grupo familiar que vive las emociones, idilios y aventuras propias del ambiente que imperaba en las islas. Todo el acento de esta novela ha sido puesto por el autor en los personajes y en sus triunfos, tragedias, amores y odios personales.",
                    Editorial = "Free Editorial",
                    FechaDePublicacion = DateTime.Parse("2021-11-01 00:00:00.0000000"),
                    Imagen = "https://viajes.nationalgeographic.com.es/medio/2021/08/23/la-exclusiva-costa-de-na-pali_a5d66976_2000x1333.jpg",
                    Pach = "C:/Borboteca-libros/hawai.pdf",
                    Precio = 2000,
                    AutorId = 5
                });
            BuilderLibro.HasData(
                new Libro
                {
                    Id = Guid.Parse("72B51E64-C5E0-40CC-9022-9F0D3906DCC3"),
                    Titulo = "El principito",
                    Resenia = "El principito es una novela corta y la obra más famosa del escritor y aviador francés Antoine de Saint-Exupéry.",
                    Editorial = "Desconocida",
                    FechaDePublicacion = DateTime.Parse("2021-10-23 14:04:18.7870000"),
                    Imagen = "https://static.ellitoral.com/um/fotos/294484_princi.jpg",
                    Pach = "C:/Borboteca-libros/El_Principito_completo.pdf",
                    Precio = 5000,
                    AutorId = 1
                });
            BuilderLibro.HasData(
                new Libro
                {
                    Id = Guid.Parse("2650BAA6-334B-4E17-B7D5-9F773F964E37"),
                    Titulo = "El gran fraude del calentamiento global",
                    Resenia = "Free Spotlight trancribe este análisis realizado por expertos sobre la teoria del “calentamiento global por culpa del ser humano”, un tema tan polémico como inserto en la sociedad actual.",
                    Editorial = "Free Editorial",
                    FechaDePublicacion = DateTime.Parse("2021-11-01 00:00:00.0000000"),
                    Imagen = "https://pics.filmaffinity.com/the_great_global_warming_swindle_tv_tv-508851081-large.jpg",
                    Pach = "C:/Borboteca-libros/el_gran_fraude_del_calentamiento_global.pdf",
                    Precio = 1000,
                    AutorId = 5
                });
            BuilderLibro.HasData(
                new Libro
                {
                    Id = Guid.Parse("B8778F7A-15BA-40A0-A66C-A50A7B01F2F3"),
                    Titulo = "La correccion",
                    Resenia = "Tras el suicidio de su amigo Roithamer, el anónimo narrador de la novela llega a la casa del taxidermista Höller, en cuya buhardilla el suicida ha permanecido durante seis años entregado a la tarea de planear y construir, en el centro geométrico exacto del bosque de Kobernauss, un Cono que, desafiando las leyes de la construcción tradicional, estaba destinado a ser residencia y «felicidad suprema» de su hermana. Urdida en torno a un proceso obsesivo de creación y destrucción que se plasma en un afán de constante corrección, la novela es una reflexión sobre los problemas del hombre contemporáneo, enfrentado a la deshumanización, el desamor y la soledad.",
                    Editorial = "Free Editorial",
                    FechaDePublicacion = DateTime.Parse("2021-11-01 00:00:00.0000000"),
                    Imagen = "https://www.tuslibros.com/2d_covers/upscaled/1332021893.jpg",
                    Pach = "C:/Borboteca-libros/la_correccion.pdf",
                    Precio = 1500,
                    AutorId = 5
                });
            BuilderLibro.HasData(
                new Libro
                {
                    Id = Guid.Parse("2DD83FCA-7E9F-45D0-A7DF-A9E734BF1E79"),
                    Titulo = "Lo que es bueno para ti es malo para mi",
                    Resenia = "Se trata de una persona que entendió la vida",
                    Editorial = "Free Editorial",
                    FechaDePublicacion = DateTime.Parse("2021-11-01 00:00:00.0000000"),
                    Imagen = "https://www.minceraft.cl/media/k2/items/cache/4d914480da9f0e177f0711403821d47b_M.jpg",
                    Pach = "C:/Borboteca-libros/lo_que_es_bueno_para_ti_es_malo_para_mí.pdf",
                    Precio = 4000,
                    AutorId = 5
                });
            BuilderLibro.HasData(
                new Libro
                {
                    Id = Guid.Parse("67F3D74E-039E-415C-8F82-BE1A87111B3F"),
                    Titulo = "La barraca",
                    Resenia = "El tema de La Barraca es la injusticia de las personas ignorantes y pobres, cuyo sentido de la existencia se basa en la supervivencia. En esta novela critica a la vez que describe la sociedad de la época. Dicha novela cuenta la desgraciada historia de una familia pobre en la huerta valenciana.",
                    Editorial = "Free Editorial",
                    FechaDePublicacion = DateTime.Parse("2021-11-01 00:00:00.0000000"),
                    Imagen = "https://m.media-amazon.com/images/I/413zycyOWKL.jpg",
                    Pach = "C:/Borboteca-libros/la_barraca.pdf",
                    Precio = 3000,
                    AutorId = 5
                });
            BuilderLibro.HasData(
                new Libro
                {
                    Id = Guid.Parse("3FE0DEBA-7374-4293-9067-C0EDE9C768FE"),
                    Titulo = "Lo que la luna grande cambio",
                    Resenia = "Libro de inspiración que nos cuenta los grandes cambios de un satélite natural de la tierra",
                    Editorial = "Free Editorial",
                    FechaDePublicacion = DateTime.Parse("2021-11-01 00:00:00.0000000"),
                    Imagen = "https://estaticos.muyinteresante.es/media/cache/1140x_thumb/uploads/images/gallery/5e5fce075bafe8711d08b2d5/nombres-luna_1.jpg",
                    Pach = "C:/Borboteca-libros/lo_que_la_luna_grande_cambio.pdf",
                    Precio = 2000,
                    AutorId = 5
                });
            BuilderLibro.HasData(
                new Libro
                {
                    Id = Guid.Parse("1759CD7F-A67E-419E-8923-DB27B73B637D"),
                    Titulo = "A los pies de Venus",
                    Resenia = "Continuación de El Papa del Mar, en la que se da inicio a la historia amorosa que liga a Claudio Borja, un joven poeta valenciano, y Rosaura Salcedo, una rica dama argentina, esta novela en la que prosiguen sus avatares puede leerse perfectamente, sin embargo, como novela suelta.",
                    Editorial = "Freak World",
                    FechaDePublicacion = DateTime.Parse("2021-11-01 00:00:00.0000000"),
                    Imagen = "https://www.storytel.com/images/e/200x200/0002398771.jpg",
                    Pach = "C:/Borboteca-libros/a_los_pies_de_venus.pdf",
                    Precio = 3000,
                    AutorId = 5
                });
            BuilderLibro.HasData(
                new Libro
                {
                    Id = Guid.Parse("93CD1293-5D5E-455E-A2CC-DEAA1ECEB064"),
                    Titulo = "La vuelta al mundo de un novelista",
                    Resenia = "Es un carrusel ameno e inolvidable de lugares, pueblos y personas en el que Blasco, como incomparable compañero de viaje, hace desfilar ante nuestros ojos la espléndida y fascinante variedad de unos paisajes de leyenda hoy en gran parte trivializados o desaparecidos",
                    Editorial = "Free Editorial",
                    FechaDePublicacion = DateTime.Parse("2021-11-01 00:00:00.0000000"),
                    Imagen = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/75/Nyolcvan_nap_alatt_a_F%C3%B6ld_k%C3%B6r%C3%BCl.jpg/220px-Nyolcvan_nap_alatt_a_F%C3%B6ld_k%C3%B6r%C3%BCl.jpg",
                    Pach = "C:/Borboteca-libros/la_vuelta_al_mundo_de_un_novelista_tomo_i.pdf",
                    Precio = 3000,
                    AutorId = 5
                });
            BuilderLibro.HasData(
                new Libro
                {
                    Id = Guid.Parse("E87266D6-99CB-4AFD-849B-89C49D36C250"),
                    Titulo = "Idioteces de los idiotas y otras tonterías",
                    Resenia = "Es el escritor actual en español más leído del mundo, y leyendo sus relatos se comprende el por qué: sencillamente porque nos divierte con sus brillantes reflexiones sobre temas cotidianos que a todos nos afectan. ",
                    Editorial = "Free Editorial",
                    FechaDePublicacion = DateTime.Parse("2021-11-01 00:00:00.0000000"),
                    Imagen = "https://www.tuslibros.com/2d_covers/large/1509826828.jpg",
                    Pach = "C:/Borboteca-libros/idioteces_de_los_idiotas_y_otras_tonterías.pdf",
                    Precio = 6000,
                    AutorId = 5
                });
            BuilderLibro.HasData(
                new Libro
                {
                    Id = Guid.Parse("EBF123B7-0841-40EA-9546-FF7CCC17835C"),
                    Titulo = "En la puerta del cielo",
                    Resenia = "Antes de desaparecer junto a su ayudante americana, el astrofísico Lalo Múgica informa a una de sus vecinas de que ha encontrado las claves para abrir la puerta del cielo. Gerardo Vilela, un sencillo profesor de Instituto, gana una beca que le lleva de Lugo a Madrid. Cuando las enigmáticas vecinas del número 12 le realquilan la antigua casa de Múgica, él se siente feliz. Pero el ático guarda algo para él: un acta firmada por Pilatos que narra otra desaparición ocurrida en Judea el año de la muerte de Jesucristo. Con veinte siglos de diferencia, ambas desapariciones parecen estar extrañamente relacionadas..",
                    Editorial = "Free Editorial",
                    FechaDePublicacion = DateTime.Parse("2021-11-01 00:00:00.0000000"),
                    Imagen = "https://http2.mlstatic.com/D_NQ_NP_2X_822295-MLA45613745505_042021-F.webp",
                    Pach = "C:/Borboteca-libros/en_la_puerta_del_cielo.pdf",
                    Precio = 3000,
                    AutorId = 5
                });
        }
    }
}
