# Best Practices Workshop - ASP.NET Core MVC

**Autor:** Mundrack

## Descripción

Este proyecto es una aplicación web ASP.NET Core MVC que demuestra la implementación de patrones de diseño y mejores prácticas en el desarrollo de software.

## Patrones de Diseño Implementados

### 1. Factory Pattern (Patrón Fábrica)
- **Ubicación:** `Infraestructure/Factories/`
- **Implementación:** Sistema de creación de vehículos
- **Clases:**
  - `Creator.cs` - Clase base abstracta del factory
  - `FordEscapeCreator.cs` - Factory para crear Ford Escape
  - `FordExplorerCreator.cs` - Factory para crear Ford Explorer
  - `FordMustangCreator.cs` - Factory para crear Ford Mustang

### 2. Singleton Pattern (Patrón Singleton)
- **Ubicación:** `Infraestructure/Singletons/`
- **Implementación:** `VehicleCollection.cs`
- **Propósito:** Gestión centralizada de la colección de vehículos

### 3. Builder Pattern (Patrón Constructor)
- **Ubicación:** `ModelBuilders/`
- **Implementación:** `CarBuilder.cs`
- **Propósito:** Construcción paso a paso de objetos Car complejos

### 4. Repository Pattern (Patrón Repositorio)
- **Ubicación:** `Repositories/`
- **Implementación:**
  - `IVehicleRepository.cs` - Interfaz del repositorio
  - `MyVehiclesRepository.cs` - Implementación en memoria
  - `DBVehicleRepository.cs` - Implementación para base de datos

### 5. Dependency Injection (Inyección de Dependencias)
- **Ubicación:** `Infraestructure/DependencyInjection/`
- **Implementación:** `ServicesConfiguration.cs`
- **Propósito:** Configuración centralizada de servicios e inyección de dependencias

## Estructura del Proyecto

```
BestPractices/
├── Controllers/          # Controladores MVC
├── Models/              # Modelos de dominio
│   ├── IVehicle.cs
│   ├── Vehicle.cs
│   ├── Car.cs
│   └── Motocycle.cs
├── Views/               # Vistas Razor
│   ├── Home/
│   └── Shared/
├── Infraestructure/     # Infraestructura y patrones
│   ├── Factories/
│   ├── Singletons/
│   └── DependencyInjection/
├── Repositories/        # Capa de acceso a datos
├── ModelBuilders/       # Constructores de modelos
└── wwwroot/            # Archivos estáticos
```

## Tecnologías Utilizadas

- ASP.NET Core MVC
- C#
- Bootstrap 4
- jQuery
- jQuery Validation

## Configuración y Ejecución

1. Clonar el repositorio:
```bash
git clone https://github.com/Mundrack/Tarea-12-WEB.git
```

2. Navegar al directorio del proyecto:
```bash
cd Tarea-12-WEB
```

3. Restaurar las dependencias:
```bash
dotnet restore
```

4. Ejecutar la aplicación:
```bash
dotnet run
```

5. Abrir en el navegador:
```
https://localhost:5001
```

## Características Principales

- **Separación de Responsabilidades:** Arquitectura bien organizada con capas claramente definidas
- **Código Mantenible:** Uso de patrones de diseño para facilitar el mantenimiento
- **Extensibilidad:** Fácil adición de nuevos tipos de vehículos y funcionalidades
- **Testabilidad:** Uso de interfaces y DI para facilitar pruebas unitarias
- **Buenas Prácticas:** Aplicación de principios SOLID

## Principios SOLID Aplicados

- **S** - Single Responsibility: Cada clase tiene una única responsabilidad
- **O** - Open/Closed: Abierto para extensión, cerrado para modificación
- **L** - Liskov Substitution: Las clases derivadas pueden sustituir a sus clases base
- **I** - Interface Segregation: Interfaces específicas en lugar de una general
- **D** - Dependency Inversion: Dependencia de abstracciones, no de implementaciones

## Autor

**Mundrack**

## Licencia

Este proyecto es de código abierto y está disponible para fines educativos.
