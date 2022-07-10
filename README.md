# CI-3641-Recursiones
Implementación de la siguiente función usando recursión (no de cola), recursión de cola e iterativamente, usando **α = 6 y β = 3.**

![image](https://user-images.githubusercontent.com/38512021/178129755-1db29f39-2238-450f-9a0b-ef8399f0decc.png)

Calcula el promedio, máximo y mínimo tiempo de corrida de la implementación elegida en el programa.

##  Requisitos
- .NET Core 6.0 SDK

## Obtener .NET Core 6.0 SDK
Las distintas versiones de .NET 6.0 SDK se pueden obtener para todas las plataformas desde este [link](https://dotnet.microsoft.com/en-us/download/dotnet/6.0 "link"). Para este proyecto se usó la versión 6.0.301 del SDK.

# Cómo usar
## Buildeo
Para buildear el ejecutable debe usarse el comando:
  
    dotnet build <path al archivo .csproj> -r <rid> -c <Config>
  
O el comando:
  
    dontet build <path al archivo .csproj> --os <rid os> -c <Config>
 
Donde:
  - <path al archivo .csproj>: Path al archivo CI-3641-Recursions.csproj en el projecto.
  - <rid>: Identificador de runtime al cual buildear (posibles runtimes en la sección notas).
  - <rid os>: Similar al rid pero en vez de indicar arquitectura, solo se indica el os (win, linux, osx).
  - <Config>: Configuración a buildear. Puede usarse Debug (sin optimizaciones) y Release (con optimizaciones).

Una vez buildeado el archivo quedara en los siguientes paths:

    ./<raiz proyecto>/CI-3641-Recursions/bin/<Config>/net6.0/<rid u os>/CI-3641-Recursions.*formato de ejecutable*
  
## Comandos
Una vez buildeado el se ejecuta el ejecutable de nombre **CI-3641-Recursions** y formato dependiente del OS buildeado.
Este se puede usar de la siguiente forma:

```
<ejecutable> <modo> <n a calcular> <iteraciones>
```

Tal que modo es uno de los siguientes valores:

- REC: Ejecutar recursión (no de cola).
- TAIL: Ejecutar recursión de cola.
- ITER: Ejecutar modo iterativo.

## Notas
- RUNTIME_IDENTIFIER o RID es la plataforma para la que vas a buildear. Estos se pueden encontrar en el siguiente [enlace](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog).

## De interés
- Como instalar .NET 6.0 en múltiples sistemas operativos https://docs.microsoft.com/en-us/dotnet/core/install/
- Comando dotnet build https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build
