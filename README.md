

[![logo_Odprz](https://user-content.gitlab-static.net/7c4eaa91dc957404baa533572ba737deb63db039/68747470733a2f2f692e696d6775722e636f6d2f466c66774d4d692e706e67)](https://user-content.gitlab-static.net/7c4eaa91dc957404baa533572ba737deb63db039/68747470733a2f2f692e696d6775722e636f6d2f466c66774d4d692e706e67)

# Aplicación Netcore

La aplicación de demostración permite las operaciones CRUD de usuarios,  
Permite añadir un nuevo usuario, modificar un usuario existente o eliminar un usuario, habilita el login de un usuario validando por usuario y contraseña,
permite el manejo de excepciones por validación de operaciones.

# Implementación de Backend

La aplicación esta dividida en las siguientes capas

**ARQ_ :** Arquitectura de la aplicación

**BR_:** Reglas de negocio y ViewModels

**DB_:** Capa de datos (Contexto y Modelos)

**WA_:** Capa de aplicación(Presentación) - en esta capa se implementan los endpoints  

Los endpoints que se definieron son los siguientes:

 **GET: api/v1/app/Users**

Retorna un listado de usuarios registrados

 **GET: api/v1/app/Users/{id}**

Retorna un usuario por su identificador

**POST: api/v1/app/Users**
Añade un nuevo registro de usuario

**PUT: api/app/Users/{id}**
Edita un usuario

**DELETE: api/app/Users/{id}**
Elimina un usuario (cambia su estatus a inactivo)

**GET: api/v1/app/Sexo**
Retorna un listado del catalogo de sexo (Masculino o femenino)

**POST: api/v1/login**
Valida las credenciales del usuario por nombre de usuario y contraseña


# Compilación

Para ejecutar la aplicación:

 1. instalar paquetes nuget
 2. compilar solución
 3. Por defecto la aplicación se ejecutará en el puerto 44394 mediante protocolo https.
 
 **nota:** si se cambia el puerto por defecto o el protocolo a http es necesario actualizar los servicios en la aplicación angular
 


