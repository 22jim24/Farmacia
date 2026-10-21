# Farmaco API - Sistema de Gestión de Ventas Farmacéuticas

API RESTful desarrollada en **C# con ASP.NET Core** para la gestión y facturación de ventas en una farmacia. El proyecto implementa una arquitectura en capas con almacenamiento en memoria, programación orientada a objetos (herencia, polimorfismo y encapsulamiento), validación con DTOs y manejo centralizado de errores mediante un Middleware personalizado.

---

## Estructura del Proyecto

```text
Farmaco/
├── Controllers/
│   └── VentasController.cs
├── Dtos/
│   ├── CreateVenta.cs
│   ├── UpdateVenta.cs
│   └── ErrorResponse.cs
├── Excepciones/
│   ├── ConflictoException.cs
│   └── RecursoNoEncontradoException.cs
├── Middlewares/
│   └── ManejoErroresMiddleware.cs
├── Modelos/
│   ├── Persona.cs
│   ├── Cliente.cs
│   ├── Empleados.cs
│   ├── Producto.cs
│   ├── Proovedor.cs
│   └── Ventas.cs
├── Repositorios/
│   ├── IReVenta.cs
│   └── RepositorioVentasMemoria.cs
├── Servicios/
│   └── ServicioVentas.cs
├── Program.cs
├── README.md
└── Farmaco.postman_collection.json
```

---

## Tecnologías y Conceptos Aplicados

* **Framework:** .NET / ASP.NET Core Web API
* **POO (Programación Orientada a Objetos):**
  * **Herencia y Polimorfismo:** Clase abstracta `Persona` con el método abstracto `ObtenerRol()`, heredada por `Cliente` y `Empleado`.
  * **Encapsulamiento y Reglas de Dominio:** Propiedades con `private set` y métodos de validación en `Ventas`, `Producto`, `Cliente`, `Empleado` y `Proovedor`.
* **Arquitectura en Capas:**
  * **Modelos:** Entidades del dominio farmacéutico con sus propias validaciones de negocio.
  * **DTOs (`DataAnnotations`):** Objetos de transferencia de datos para validar las entradas (`CreateVenta`, `UpdateVenta`) y estandarizar las respuestas de error (`ErrorResponse`).
  * **Repositorios (In-Memory):** Persistencia en memoria inyectada como `Singleton` mediante la interfaz `IReVenta`.
  * **Servicios:** Lógica de negocio, cálculos con LINQ y control de excepciones (`ServicioVentas`).
* **Manejo Global de Errores:** Middleware personalizado (`ManejoErroresMiddleware`) que intercepta excepciones y devuelve respuestas JSON estandarizadas con códigos HTTP `400`, `404`, `409` y `500`.

---

##  Requisitos y Ejecución

1. Tener instalado el **SDK de .NET** (versión 8.0 o superior).
2. Clonar o abrir la carpeta del proyecto en **Visual Studio** o **VS Code**.
3. Ejecutar el proyecto desde la terminal con el comando:
   ```bash
   dotnet run
   ```
4. La API se levantará localmente (por ejemplo, en `http://localhost:5124`).

---

##  Endpoints de la API (`Ventas`)

| Método HTTP | Ruta (Endpoint) | Descripción | Códigos de Respuesta |
| :--- | :--- | :--- | :--- |
| **GET** | `/api/ventas` | Lista todas las ventas registradas en memoria. | `200 OK` |
| **GET** | `/api/ventas/{nombreCliente}` | Busca una venta específica por el nombre del cliente. | `200 OK`, `404 Not Found` |
| **GET** | `/api/ventas/metodo-pago/{metodo}` | Filtra las ventas según el método de pago. | `200 OK` |
| **GET** | `/api/ventas/total-ingresos` | Calcula la suma total de ingresos de todas las ventas. | `200 OK` |
| **POST** | `/api/ventas` | Registra una nueva venta y calcula el total automáticamente. | `201 Created`, `400 Bad Request`, `409 Conflict` |
| **PUT** | `/api/ventas/{nombreCliente}` | Actualiza los datos de una venta existente y recalcula su total. | `200 OK`, `400 Bad Request`, `404 Not Found` |
| **DELETE** | `/api/ventas/{nombreCliente}` | Elimina la venta asociada a un cliente. | `200 OK`, `404 Not Found` |

---

## Reglas de Validación del Dominio

* **Métodos de pago permitidos:** `EFECTIVO`, `TARJETA`, `YAPE_PLIN`, `TRANSFERENCIA`.
* **Cantidades y Precios:** La cantidad comprada debe ser mayor que `0` y el precio no puede ser negativo.
* **Cargos de empleados permitidos:** `ADMIN`, `FARMACEUTICO`, `CAJERO`, `ALMACENERO`.
* **Proveedores:** El teléfono del proveedor debe tener exactamente `9` dígitos.

---

## Formato de Respuesta de Errores (`ErrorResponse`)

Cuando ocurre una excepción controlada por el `ManejoErroresMiddleware`, la API devuelve un objeto JSON con el siguiente formato estándar:

* **`400 Bad Request` (`ArgumentException`):** Datos fuera de rango o métodos de pago/cargos no válidos.
* **`404 Not Found` (`RecursoNoEncontradoException`):** El cliente o registro solicitado no existe.
* **`409 Conflict` (`ConflictoException`):** Intento de registrar una venta para un cliente que ya existe.

**Ejemplo de respuesta de error:**
```json
{
  "status": 404,
  "mensaje": "No existe una venta del cliente Juan Perez",
  "fecha": "2026-10-18T22:35:00"
}
```

---

## 🧪 Pruebas en Postman

En la raíz del proyecto se incluye el archivo **`Farmaco.postman_collection.json`**. Para ejecutar las pruebas:
1. Abrir **Postman** y hacer clic en **Import**.
2. Seleccionar el archivo `Farmaco.postman_collection.json`.
3. Verificar que el puerto en las peticiones coincida con el puerto local asignado al ejecutar la aplicación (ej. `http://localhost:5124`).