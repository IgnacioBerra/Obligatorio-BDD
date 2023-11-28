# Obligatorio-BDD


Para ejecutar el programa se deben seguir los siguientes pasos : 

     *Para que funcione Angular*

- Se deben instalar las dependencias con el comando: npm i
- Para levantar el Angular se debe ejecutar el comando: ng serve --o

    *Para que funcione la Base de Datos*

 - Tener SQL Server instalado, copiar y pegar link en el buscador para iniciar la descarga. https://go.microsoft.com/fwlink/p/?linkid=2216019&clcid=0x40A&culture=es-es&country=es
   
 - Una vez instalado SQL Server, le preguntará si quiere instalar SSMS, recomendamos instalarlo para correr la base de datos de manera más rapida.
   
 - Abrir SQL Server y correr el script de creacion de tablas e inserción.
   

   *Para que funcione la API*

 - Tener Visual Studio 2022 instalado, copiar y pegar link en el buscador para iniciar la descarga. https://visualstudio.microsoft.com/es/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false

 - Abrir la WEB Api en Visual Studio, y seleccionamos depurar API (No Docker ni las otras opciones).

 - Como implementamos CACHE, se debe ejecutar los siguientes comandos en el CMD:
 
docker pull redis
docker run -p 6379:6379 --name local-redis -d redis
