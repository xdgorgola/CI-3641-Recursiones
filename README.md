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

# Análisis comparativo
Antes de hacer el análisis, los valores constantes usados son **X = 2, Y = 6, Z = 4, α = 6 y β = 3.**

## Datos recolectados
Para las tres implementaciones de la función, se recolectaron los siguientes datos realizando 500 iteraciones para cada implementación:

- Tiempo promedio de ejecución para un valor n.
- Tiempo máximo de ejecución para un valor n.
- Tiempo mínimo de ejecución para un valor.

Los n utilizados fueron 10, 18, 70, 100, 300, 500 y 1000, siendo 10 y 18 elegidos especificamente porque para el primer valor las implementaciones 
entran en un caso borde tal que no hay más ejecución de código que un if y un return, mientras que para el segundo valor ya empieza a generarse 
recursión. Cabe destacar que para la implementación iterativa no se recolectaron datos para n > 100 ya que el tiempo de ejecución del programa es 
bastante elevado, y al intentar ejecutar 500 iteraciones con n = 300, la ejecución total no finalizaba en 8 horas transcurridas.

### Tiempos promedios de ejecución entre las 3 implementaciones

|               Tiempo en ms/n |         10 |         18 |         70 |            100 |
|-----------------------------:|-----------:|-----------:|-----------:|---------------:|
|         Tiempo AVG recursión | 0,00039339 |  0,0002496 |   1,484839 | 1.330,62477739 |
| Tiempo AVG recursión de cola |  0,0002408 | 0,00036139 | 0,00042839 |      0,0004629 |
|         Tiempo AVG iterativo |  0,0003934 |  0,0004356 |  0,0004792 |      0,0004848 |

### Tiempos promedios de ejecución entre recursión de cola e iteraciones

|               Tiempo en ms/n |        10 |         18 |         70 |       100 |       300 |        500 |       1000 |
|-----------------------------:|----------:|-----------:|-----------:|----------:|----------:|-----------:|-----------:|
| Tiempo AVG recursión de cola | 0,0002408 | 0,00036139 | 0,00042839 | 0,0004629 | 0,0007392 | 0,00099779 | 0,00167819 |
|         Tiempo AVG iterativo | 0,0003934 |  0,0004356 |  0,0004792 | 0,0004848 | 0,0006209 |  0,0007324 | 0,00104979 |

### Tiempos máximos y mínimos entre las 3 implementaciones

| Tiempo en ms/n |     10 |     18 |     70 |       100 |
|----------------|-------:|-------:|-------:|----------:|
| Máx. Recu      | 0,0947 | 0,1054 | 2,2551 |  1601,655 |
| Mín. Recu      |      0 |      0 | 1,3697 | 1266,3362 |
| Máx. Cola      | 0,1098 | 0,1564 | 0,1586 |    0,1571 |
| Mín. Cola      |      0 |      0 | 0,0001 |    0,0001 |
| Máx. Iter      | 0,1878 | 0,2065 | 0,2069 |    0,2061 |
| Mín. Iter      |      0 |      0 |      0 |         0 |

### Tiempos máximos y mínimos entre recursión de cola e iteraciones

| Tiempo en ms/n   |     10 |     18 |     70 |    100 |    300 |    500 |   1000 |
|------------------|-------:|-------:|-------:|-------:|-------:|-------:|-------:|
| Tiempo Máx. Cola | 0,1098 | 0,1564 | 0,1586 | 0,1571 | 0,1522 | 0,1511 | 0,1515 |
| Tiempo Mín. Cola |      0 |      0 | 0,0001 | 0,0001 | 0,0004 | 0,0006 | 0,0013 |
| Tiempo Máx. Iter | 0,1878 | 0,2065 | 0,2069 | 0,2061 | 0,2126 |  0,208 | 0,2075 |
| Tiempo Mín. Iter |      0 |      0 |      0 |      0 | 0,0001 | 0,0003 | 0,0006 |

### Análisis de los datos

Lo primero que podemos observar es que los tiempos promedios de las tres implementaciones son muy similares para los valores 10 y 18, esto debido a que 
para los n menores a α * β = 18 se entra al caso base de las tres implementaciones el cual es un mero if y un return del valor n, y para el valor 
n = 18 las tres implementaciones ya empiezan a hacer recursiones/iteraciones pero no muy profundas, por lo que el tiempo promedio es muy similar para las tres.

Lo siguiente a destacar de estos datos es que para n = 70 ya hay un mayor tiempo promedio de ejecución en la implementación recursiva (1ms) a comparación 
de las otras implementaciones que mantienen un tiempo promedio muy similar para todos los n. Por último, ya para        
n = 100, la implementación recursiva tiene un tiempo promedio mucho mayor que las demás, siendo este de 1.330ms o 1s.

En la siguiente gráfica podemos ver como el tiempo de la implementación recursiva parece crecer exponencialmente a partir de un punto, mientras que para 
las otras dos implementaciones el tiempo promedio parece casi constante y parecen converger al mismo punto, aunque si existe un crecimiento mínimo.

![chart](https://user-images.githubusercontent.com/38512021/178164225-e32535ab-4196-44bb-bf93-b9ecfd1a004f.png)

Ahora, examinando únicamente el tiempo promedio de ejecución para las implementaciones recursiva de cola e iterativa, podemos ver que los tiempos son bastantes 
cercanos entre si, pero observando la siguiente gráfica podemos fijarnos que para n <= 100, la implementación iterativa tiene mayor tiempo promedio de ejecución 
que la recursión de cola y a partir de un punto entre el rango (100..300], la implementación iterativa pasa a ser la que tiene menor tiempo promedio de ejecución.

![chart (1)](https://user-images.githubusercontent.com/38512021/178166251-0d06b927-5745-4001-bd43-277791e3f47c.png)

Lo último a examinar entre las implementaciones de recursión de cola e iteraciones, son los tiempos máximos y mínimos. Para la implementación 
iterativa de la función, el valor del mayor tiempo de ejecución de la función es mayor que la misma data pero para la implementación recursiva. 
Respecto a los tiempos mínimos de ejecución, son bastantes similares y muy cercanos al cero como para concluir que son practicamente iguales para 
todos los n probados.

![chart (2)](https://user-images.githubusercontent.com/38512021/178166705-28c5afdf-a48d-4575-b991-52323a807b6f.png)

### Conclusiones

Claramente se puede observar que la implementación menos eficiente de esta función es la recursiva y por mucho, ya que a pesar de que para n <= 100 los tiempos 
son aceptables, en n = 300 el tiempo aumenta considerablemente hasta el punto de que no se pudo recolectar la data de esta implementación para ese n. Ahora, 
claramente las implementaciones que usan recursión de cola e iteraciones son muchísimo mejor respecto al tiempo promedio, máximo y mínimo de ejecución, siendo 
todos estos valores muy cercanos a 0 para todos los n probados, aún así, estas implementaciones también tienen sus propias desventajas y son las siguientes:

- La implementación recursiva no de cola fue muchísimo más fácil de implementar que las implementaciones con recursión de cola e iteraciones, dado 
a que la función a implementar está definida como una función recursiva y es posible implementarla tal cual como la definición.

- La recursión de cola no está libre de problemas relacionados a una gran profundidad de recursión, sigue siendo una recursión y estas pueden 
llegar al límite máximo de recursión permitido en el lenguaje o causar stack overflows.

Ya concluyendo, lo ideal sería usar en lo posible implementaciones que utilicen recursiones de cola o iteraciones (para evitar problemas con la 
profundidad de recursión) ya que son muchísimo más rápidas que una recursión no de cola, pero sin olvidar que puede llegar a no ser tan trivial 
transformar una recursión a recursión de cola o iteraciones.
