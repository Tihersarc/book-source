# BookSource

---

La **BookSource** es una plataforma web diseñada para guardar los libros que te interesan, hayas leido o quieras leer en tus listas personales para no olvidarte. Tambien funciona como pequeña red social literaria en la que puedes recomendar los mismos que te gusten o puntuarlos.

## Tecnologías

- C# ASP.NET

## 📚 Dashboard Principal de Busqueda

![BookSource Dashboard](https://www.danipoal.com/assets/bookSource.PNG)

Esta imagen muestra la vista del buscador de **BookSource**, una de las muchas interfaces que presenta la aplicación, en ella los usuarios pueden explorar, buscar y filtrar libros de manera eficiente, accediendo a información relevante de cada título.

🚀 **Características del Buscador:**
- 🔍 Búsqueda avanzada de libros.
- 📖 Visualización optimizada para explorar títulos.
- ⚡ Interfaz intuitiva y fácil de usar.

Los datos (Libros), han sido extraidos de la Google Book Api, de manera que el contenido de la BD de la aplicación se encuentra actualizado con los libros del momento en función de fechas, relevancia y calificaciones. 


## Features

---

### Main Features

Características principales de nuestra replica de LetterBox

- Usuarios
- Publicaciones
- Libros
- Feed
- Buscador - Libros [Filtros]

---

## Gitflow

Nomenclatura a usar para las ramas.

La estructura de las ramas esta organizada por las siguientes ramas principales

- master
    - develop
        - backend
        - frontend

Para crear nuevas ramas usaremos la siguiente nomenclatura:

feature/{RamaPrincipal}/funcion

Intentemos que cada feature tenga una función concreta por ejemplo:

feature/frontend/pagina-perfil

(No usar mayúsculas)

## Base de Datos

### Diagrama E-R


![Diagrama de Entidad - Relación](/resourcesReadme/Flujo_E-R_BookSource.drawio.png)

Diagrama de Entidad - Relación

![Diseño Base de datos Post Normalización](/resourcesReadme/DiagramaBBDD.drawio.png)

Diseño Base de datos Post Normalización

### Tablas

- **Usuario**
    - IdUser *PK*
    - UserName
    - Password
    - Birthdate
    - Email
    - ImagenPerfil
    - Seguidos
    - Seguidores
- **Seguidos_Seguidores**
    - Seguido *PK FK*
    - Seguidor *PK FK*
- **Resena**
    - Puntuacion
    - Comentario
    - FKUsuario
    - FKLibro

- **Libro**
    - Campos Api
        - VolumInfo {}
            - title
            - subtitle
            - authors []
            - publisher
            - publishedDate
            - description
        - pageCount
        - imageLinks
            - smallThumbnails
            - thumbnail
    - IdLibro *PK*
    - Title
    - Subtitle
    - Categoria
    - Author
    - Publisher
    - Date
    - Description
    - pageCount
    - ImageLink
    

- **Lista**
    - IdLista
    - IdUsuario *PK*
    - NombreLista
    - IdLibros *FK*[]
- **Publicacion**
    - IdPublicacion *PK*
    - Titulo
    - Contenido
    - Likes
    - Imagen?
- Lista_Libro
    - PF FK Libro
    - PK FK Lista
- Json APi Google
    
    ```json
    "kind": "books#volume",
          "id": "BcG2dVRXKukC",
          "etag": "Kap0k68SK5o",
          "selfLink": "https://www.googleapis.com/books/v1/volumes/BcG2dVRXKukC",
          "**volumeInfo**": {
            "title": "The Name of the Wind",
            "subtitle": "The legendary must-read fantasy masterpiece",
            "authors": [
              "Patrick Rothfuss"
            ],
            "publisher": "Hachette UK",
            "publishedDate": "2010-04-22",
            "description": "The lyrical fantasy masterpiece about stories, legends and how they change the world. The Name of the Wind is an absolute must-read for any fan of fantasy fiction. 'This is a magnificent book' Anne McCaffrey 'I was reminded of Ursula K. Le Guin, George R. R. Martin, and J. R. R. Tolkein, but never felt that Rothfuss was imitating anyone' THE TIMES 'I have stolen princesses back from sleeping barrow kings. I burned down the town of Trebon. I have spent the night with Felurian and left with both my sanity and my life. I was expelled from the University at a younger age than most people are allowed in. I tread paths by moonlight that others fear to speak of during day. I have talked to Gods, loved women, and written songs that make the minstrels weep. My name is Kvothe. You may have heard of me' So begins the tale of Kvothe - currently known as Kote, the unassuming innkeepter - from his childhood in a troupe of traveling players, through his years spent as a near-feral orphan in a crime-riddled city, to his daringly brazen yet successful bid to enter a difficult and dangerous school of magic. In these pages you will come to know Kvothe the notorious magician, the accomplished thief, the masterful musician, the dragon-slayer, the legend-hunter, the lover, the thief and the infamous assassin. The Name of the Wind is fantasy at its very best, and an astounding must-read coming-of-age adventure. Readers adore The Name of the Wind: 'The quality of the writing breathes magic into even fairly ordinary scenes, and makes some of the important ones extraordinary' Mark Lawrence 'This is why I love fantasy so much . . . The writing style is smooth, the pacing just right . . . I would easily recommend this to anyone who enjoys fantasy, but also to people who enjoy great stories told wonderfully well' Goodreads reviewer, ⭐ ⭐ ⭐ ⭐ ⭐ 'For the love of God, if you haven't read this book and love these kinds of high fantasy novels, READ IT!' Goodreads reviewer, ⭐ ⭐ ⭐ ⭐ ⭐ 'The story is fantastic, the writing is amazing, and if you have a heart the main character will capture it' Goodreads reviewer, ⭐ ⭐ ⭐ ⭐ ⭐ 'Patrick Rothfuss is such a talented storyteller and there was never a dull moment throughout the entire book! . . . The Name of the Wind is a masterpiece and Patrick Rothfuss is a freaking genius' Goodreads reviewer, ⭐ ⭐ ⭐ ⭐ ⭐ 'This story was, simply put, excellent . . . Rothfuss has more than earnt his reputation. I'm so glad this book lived up to the hype . . . A jaw dropping five stars' Goodreads reviewer, ⭐ ⭐ ⭐ ⭐ ⭐ 'One of the best fantasy books of all time' Goodreads reviewer, ⭐ ⭐ ⭐ ⭐ ⭐ 'A legitimately wonderful story that is written beautifully . . . This should be one of the required reading books for any fan of fantasy' Goodreads reviewer, ⭐ ⭐ ⭐ ⭐ ⭐",
            "industryIdentifiers": [
              {
                "type": "ISBN_13",
                "identifier": "9780575087057"
              },
              {
                "type": "ISBN_10",
                "identifier": "0575087056"
              }
            ],
            "readingModes": {
              "text": true,
              "image": false
            },
            "**pageCount**": 880,
            "printType": "BOOK",
            "categories": [
              "Fiction"
            ],
            "averageRating": 4.5,
            "ratingsCount": 67,
            "maturityRating": "NOT_MATURE",
            "allowAnonLogging": true,
            "contentVersion": "1.25.23.0.preview.2",
            "panelizationSummary": {
              "containsEpubBubbles": false,
              "containsImageBubbles": false
            },
            **"imageLinks":** {
              "smallThumbnail": "http://books.google.com/books/content?id=BcG2dVRXKukC&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
              "thumbnail": "http://books.google.com/books/content?id=BcG2dVRXKukC&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
            },
            "language": "en",
            "previewLink": "http://books.google.es/books?id=BcG2dVRXKukC&pg=PT92&dq=nameofthewind&hl=&cd=4&source=gbs_api",
            "infoLink": "https://play.google.com/store/books/details?id=BcG2dVRXKukC&source=gbs_api",
            "canonicalVolumeLink": "https://play.google.com/store/books/details?id=BcG2dVRXKukC"
          },
          "saleInfo": {
            "country": "ES",
            "saleability": "FOR_SALE",
            "isEbook": true,
            "listPrice": {
              "amount": 5.49,
              "currencyCode": "EUR"
            },
            "retailPrice": {
              "amount": 5.49,
              "currencyCode": "EUR"
            },
            "buyLink": "https://play.google.com/store/books/details?id=BcG2dVRXKukC&rdid=book-BcG2dVRXKukC&rdot=1&source=gbs_api",
            "offers": [
              {
                "finskyOfferType": 1,
                "listPrice": {
                  "amountInMicros": 5490000,
                  "currencyCode": "EUR"
                },
                "retailPrice": {
                  "amountInMicros": 5490000,
                  "currencyCode": "EUR"
                },
                "giftable": true
              }
            ]
          },
          "accessInfo": {
            "country": "ES",
            "viewability": "PARTIAL",
            "embeddable": true,
            "publicDomain": false,
            "textToSpeechPermission": "ALLOWED",
            "epub": {
              "isAvailable": true,
              "acsTokenLink": "http://books.google.es/books/download/The_Name_of_the_Wind-sample-epub.acsm?id=BcG2dVRXKukC&format=epub&output=acs4_fulfillment_token&dl_type=sample&source=gbs_api"
            },
            "pdf": {
              "isAvailable": false
            },
            "webReaderLink": "http://play.google.com/books/reader?id=BcG2dVRXKukC&hl=&source=gbs_api",
            "accessViewStatus": "SAMPLE",
            "quoteSharingAllowed": false
          },
          "searchInfo": {
            "textSnippet": "... didn&#39;t know what to believe . So I invited him into our troupe , hoping to find answers to my questions . Though I didn&#39;t know it at the time , I was looking for the <b>name of the wind</b> . CHAPTER NINE Riding in the Wagon with Ben A BENTHY."
          }
        },
    ```
    

---

## Paginas

Características principales que si o si deberíamos ser capaces de integrar en la aplicación y que funcionen correctamente:

### **Basicos**

- **Landing page**(”/”)
    - Pequeña lista con los top 10 libros.
        - Redirigir al libro
- **About**(”/about”)
    - Informacion de la empresa y valores
- **Profile**(”/{usuario}”)
    - Usuario/datos info
    - Si usuario logueado es usuario del perfil mostrar boton de configuracion.
        - Redirigir a ”{user}/configuration”
    - Seguidos y seguidores
        - Redirigir a “/{usuario}/followList”
    - Area de publicaciones/threads
    - Ocultar opciones de Configuracion si es un usuario diferente a login.
    - Mostrar boton para seguir si es un usuario diferente a login y esta loggueado.

- **Login**(”/login”)
    - Email, Contraseña
    - Si OK redirigir a “/”
- **Register**(”/register”)
    - Email, usuario, contraseña
    - Si OK redirigir a “/”
- **Configuración**(”{user}/configuration”)
    - Cambiar nombre usuario, contraseña, email, teléfono
    - Recibir o no correos / 2AUth
- **Library (”{usuario}/{library Name}”)**
    - Listas de libros guardadas
    - Botones para tipos de lista (leidos, por leer, favoritos, ….)
    - Filtros simples en la derecha

### Componentes

- **Navbar**
    - Nombre de la pagina
        - Redireccion “/”
    - AboutUs
        - Redireccion “/about”
    - Login/SignUp(Si login no realizado)
        - Redireccion”/login”|”/register”
    - UserName(Si login realizado)
    - Search con ComboBox(Autores/generos/usuarios…)
        - Si CB usuario redirigir “/profile”
        - Resto redirigir “/search” pasando filtro CB
        
        Threats
        
        - Redirigir a “/feed”

- **BookList**
    - Listado de libros
        - Redirecciona al “/libro/{libro.name}”

### **Específicos**

***THREADS***

- **Feed/Foro Threads** (”/feed”)
    - Opcion 1 : Ver todos lo threads
    - Opcion 2: Ver Threads de seguidos
- **Add publication** (”/addPublication/*”)
    - Publicacion→ userId, content,  image(?)
    - nombre, contenido,

- **Profile follows** (”/{usuario}/followList”)
    - Listado de usuarios que sigues. Tambien tiene que haber de los que te siguen “/followerList”(Aprovechar la misma vista)
        - Redirigir a “/usuario”
- **Reseña(**Partial view**)**
    - Mostrar comentario,valoracion,usuario.
        - Redirigir a “/usuario”
- **AddReseña**(Partial view)
    - Cuadro de texto de la reseña
    - Valoracion
    - Boton AñadirReseña
        - AñadeReseña

***LIBROS***

- **Search** (Buscador de libros)(”/search?lib=””&…)
    - Buscar por nombre / Autor…
    - Filtros a la izquierda segun puntuación, alfabetico, genero…
    - Filtros multiseleccion Genero,Autor,Editorial
- Libros(”libros”)
    - Listar todos los libros
    - Filtros multiseleccion Genero,Autor,Editorial
- **Libro** (”/libro/{libro.name}”)(En vez de libro name usar Id)
    - Vista única de el libro seleccionado
    - Descripción, imagen, toda la info…
        - Al click genero/editorial/autor redirigir a “libros” filtrando por genero… seleccionado.
    - Que se pueda añadir a mi lista con un boton
    - Añadir(Si estas logeado)/Mostrar reseñas

### Secondary Features

Características secundarias que si llegamos a hacer seria la ostia:

- Login Auth (Google)
- Deploy

### Buenas Prácticas

- **Hacer Commits Frecuentes**: Realiza commits con frecuencia para registrar cambios incrementales.
- **Describir los Commits**: Usa mensajes de commit claros y descriptivos para facilitar la comprensión del historial de cambios.
- **Revisar Código**: Realiza revisiones de código antes de fusionar ramas para mantener la calidad del código.
- **Actualizar Ramas**: Asegúrate de mantener las ramas `develop` y `main` actualizadas para evitar conflictos.

## Librerías / Recursos

---

Frontend:

- Tailgrid (Componentes React & Tailwind)

Backend

- [https://www.youtube.com/watch?v=cMXTd6PoFpo](https://www.youtube.com/watch?v=cMXTd6PoFpo) DEPLOY JAVA + SPRINGBOOT + DOCKER
- jwt (LOGIN)
