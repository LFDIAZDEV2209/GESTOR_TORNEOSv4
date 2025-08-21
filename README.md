# 🏆 GESTOR_TORNEOSv4 - Sistema de Gestión de Torneos de Fútbol

## 📋 Descripción

**GESTOR_TORNEOSv4** es un sistema completo de gestión de torneos de fútbol desarrollado en C# con .NET 9.0. El sistema permite administrar equipos, jugadores, staff técnico, partidos, transferencias y generar estadísticas detalladas de rendimiento.

## 👨‍💻 Autor

**LFDIAZDEV2209** - Desarrollador Full Stack

## 🏗️ Arquitectura del Proyecto

El proyecto sigue una arquitectura limpia (Clean Architecture) con separación clara de responsabilidades:

```
GESTOR_TORNEOSv4/
├── src/
│   ├── Modules/           # Módulos de funcionalidad
│   │   ├── Cities/        # Gestión de ciudades
│   │   ├── Countries/     # Gestión de países
│   │   ├── MainMenu/      # Menú principal
│   │   ├── Matches/       # Gestión de partidos
│   │   ├── Players/       # Gestión de jugadores
│   │   ├── Staffs/        # Gestión de staff técnico y médico
│   │   ├── Stats/         # Estadísticas y reportes
│   │   ├── Teams/         # Gestión de equipos
│   │   ├── Tournaments/   # Gestión de torneos
│   │   ├── TournamentsTeams/ # Relación equipos-torneos
│   │   └── Transfers/     # Gestión de transferencias
│   └── Shared/            # Componentes compartidos
│       ├── Configuration/  # Configuraciones de Entity Framework
│       ├── Context/        # Contexto de base de datos
│       ├── Db/            # Scripts SQL (DDL y DML)
│       └── Helpers/       # Utilidades y helpers
```

## 🚀 Características Principales

### 🏅 Gestión de Torneos
- Crear, editar, eliminar y buscar torneos
- Definir fechas de inicio y fin
- Gestionar equipos inscritos

### ⚽ Gestión de Equipos
- Registro completo de equipos
- Asignación de ciudades
- Inscripción en torneos
- Gestión de staff técnico y médico

### 👥 Gestión de Jugadores
- Registro de jugadores con información completa
- Asignación de posiciones (Portero, Defensa, Centrocampista, Delantero)
- Gestión de valores de mercado
- Asignación a equipos

### 🏥 Gestión de Staff
- **Staff Técnico**: Entrenadores, asistentes, preparadores físicos
- **Staff Médico**: Médicos, fisioterapeutas, nutricionistas
- Asignación de roles y especialidades
- Gestión por equipos

### ⚽ Gestión de Partidos
- Crear y programar partidos
- Asignar equipos local y visitante
- Finalizar partidos con marcadores
- Actualización automática de estadísticas

### 📊 Sistema de Estadísticas
- **Jugadores con más asistencias por torneo**
- **Equipos con más goles por torneo**
- **Jugadores más caros por equipo**
- **Jugadores menores al promedio de edad por equipo**
- Cálculo automático de promedios y rankings

### 💰 Sistema de Transferencias
- **Compra de jugadores** con montos específicos
- **Préstamos de jugadores** entre equipos
- Historial completo de movimientos
- Gestión de valores de mercado

## 🛠️ Tecnologías Utilizadas

- **.NET 9.0** - Framework de desarrollo
- **C#** - Lenguaje de programación
- **Entity Framework Core 9.0.8** - ORM para base de datos
- **MySQL** - Base de datos relacional
- **Pomelo.EntityFrameworkCore.MySql** - Proveedor MySQL para EF Core
- **Spectre.Console 0.50.0** - Librería para interfaces de consola ricas
- **Microsoft.Extensions.Configuration** - Gestión de configuración

## 🗄️ Base de Datos

### Esquema Principal
- **Positions**: Posiciones de jugadores (20 posiciones predefinidas)
- **Cities**: Ciudades de los equipos (35 ciudades globales)
- **Countries**: Países de origen (30 países)
- **StaffTypes**: Tipos de staff (5 categorías)
- **Tournaments**: Torneos disponibles
- **Teams**: Equipos registrados
- **StaffRoles**: Roles específicos del staff
- **Players**: Jugadores con información completa
- **TournamentTeams**: Relación muchos-a-muchos entre torneos y equipos
- **Staff**: Personal técnico y médico
- **Matches**: Partidos programados y finalizados
- **PlayerStats**: Estadísticas de jugadores por partido
- **Transfers**: Historial de transferencias

### Datos de Prueba
El sistema incluye un conjunto completo de datos de prueba:
- **10 torneos** (Liga Española, Champions League, Copa Libertadores, etc.)
- **48 equipos** de diferentes países y continentes
- **100+ jugadores** con estadísticas realistas
- **50+ partidos** con marcadores y estadísticas
- **Staff técnico** para todos los equipos principales
- **Transferencias** históricas y recientes

## 🚀 Instalación y Configuración

### Prerrequisitos
- .NET 9.0 SDK
- MySQL Server 8.0+
- Visual Studio 2022 o VS Code

### Pasos de Instalación

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/LFDIAZDEV2209/GESTOR_TORNEOSv4
   cd GESTOR_TORNEOSv4
   ```

2. **Configurar la base de datos**
   - Crear base de datos MySQL
   - Ejecutar `src/Shared/Db/ddl.sql` para crear las tablas
   - Ejecutar `src/Shared/Db/dml.sql` para insertar datos de prueba

3. **Configurar la conexión**
   - Editar `appsettings.json` con tus credenciales MySQL
   ```json
   {
     "ConnectionStrings": {
       "MySqlDb": "server=localhost;database=gestor_torneos;user=tu_usuario;password=tu_password;"
     }
   }
   ```

4. **Restaurar dependencias y compilar**
   ```bash
   dotnet restore
   dotnet build
   ```

5. **Ejecutar la aplicación**
   ```bash
   dotnet run
   ```

## 🎮 Uso del Sistema

### Menú Principal
```
🏆 GESTOR DE TORNEOS

0. Crear Torneo
1. Registro Equipos
2. Registro Jugadores
3. Transferencia (Compra, Préstamo)
4. Estadísticas
5. Partidos
6. Salir
```

### Funcionalidades por Módulo

#### 🏅 Torneos (Opción 0)
- Crear nuevos torneos
- Buscar torneos existentes
- Editar información de torneos
- Eliminar torneos

#### ⚽ Equipos (Opción 1)
- Registrar nuevos equipos
- Asignar ciudades
- Inscribir en torneos
- Gestionar staff técnico y médico
- Buscar y editar equipos

#### 👥 Jugadores (Opción 2)
- Crear nuevos jugadores
- Asignar posiciones y países
- Gestionar valores de mercado
- Buscar y actualizar información
- Eliminar jugadores

#### 💰 Transferencias (Opción 3)
- **Comprar jugadores**: Transferencias con monto
- **Prestar jugadores**: Préstamos temporales
- Historial de movimientos

#### 📊 Estadísticas (Opción 4)
- **4.1** Jugadores con más asistencias por torneo
- **4.2** Equipos con más goles por torneo
- **4.3** Jugadores más caros por equipo
- **4.4** Jugadores menores al promedio de edad por equipo

#### ⚽ Partidos (Opción 5)
- **5.1** Crear/Programar partido
- **5.2** Finalizar partido (ingresar marcadores)
- Actualización automática de estadísticas

## 🔧 Estructura del Código

### Patrón de Diseño
- **Clean Architecture** con separación de capas
- **Repository Pattern** para acceso a datos
- **Service Layer** para lógica de negocio
- **UI Layer** para interfaces de usuario

### Organización de Módulos
Cada módulo sigue la misma estructura:
```
ModuleName/
├── Application/
│   ├── Interfaces/     # Contratos de servicios
│   ├── Services/       # Implementación de lógica de negocio
│   └── UI/            # Interfaces de usuario
├── Domain/
│   └── Entities/      # Entidades del dominio
└── Infrastructure/
    └── [ModuleName]Repository.cs  # Acceso a datos
```

## 📊 Características Técnicas

### Manejo de Datos
- **Async/Await** para operaciones asíncronas
- **LINQ** para consultas de datos
- **Entity Framework Core** para mapeo objeto-relacional
- **Transacciones** para operaciones complejas

### Interfaz de Usuario
- **Spectre.Console** para interfaces ricas en consola
- **Menús interactivos** con selección por teclas
- **Tablas formateadas** para mostrar datos
- **Colores y estilos** para mejor experiencia de usuario

### Validaciones
- Validación de datos de entrada
- Verificación de integridad referencial
- Manejo de errores con mensajes informativos
- Prevención de operaciones inválidas

## 🧪 Testing y Datos de Prueba

El sistema incluye un conjunto completo de datos de prueba que permite:
- Probar todas las funcionalidades
- Ver estadísticas realistas
- Simular transferencias y partidos
- Validar cálculos y reportes

### Datos Incluidos
- **Equipos reales** (Real Madrid, Barcelona, PSG, Bayern, etc.)
- **Jugadores famosos** con estadísticas realistas
- **Torneos internacionales** (Champions League, Copa Libertadores)
- **Staff técnico** reconocido
- **Historial de transferencias** con montos realistas

## 🚀 Funcionalidades Avanzadas

### Cálculo Automático de Estadísticas
- **Edad promedio** de equipos calculada dinámicamente
- **Rankings** actualizados automáticamente
- **Estadísticas por torneo** filtradas y ordenadas
- **Métricas de rendimiento** por jugador y equipo

### Gestión de Relaciones
- **Equipos en torneos** con validaciones
- **Jugadores por equipo** con posiciones
- **Staff asignado** por roles y especialidades
- **Partidos programados** con equipos participantes

## 🔒 Seguridad y Validaciones

- **Validación de datos** en todas las entradas
- **Verificación de integridad** referencial
- **Manejo de errores** robusto
- **Transacciones** para operaciones críticas

## 📈 Roadmap y Mejoras Futuras

- [ ] **Sistema de usuarios** y autenticación
- [ ] **API REST** para integración web
- [ ] **Reportes en PDF** y exportación de datos
- [ ] **Dashboard web** con gráficos interactivos
- [ ] **Sistema de notificaciones** para eventos importantes
- [ ] **Backup automático** de base de datos
- [ ] **Logs de auditoría** para cambios críticos

## 🤝 Contribuciones

Este proyecto está abierto a contribuciones. Para contribuir:

1. Fork el repositorio
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

## 📄 Licencia

Este proyecto está bajo la Licencia MIT. Ver el archivo `LICENSE` para más detalles.

## 📞 Contacto

**LFDIAZDEV2209**
- GitHub: [@LFDIAZDEV2209](https://github.com/LFDIAZDEV2209)
- Email: [diazf7583@gmail.com](mailto:diazf7583@gmail.com)

## 🙏 Agradecimientos

- **Spectre.Console** por la excelente librería de interfaces de consola
- **Entity Framework Core** por el ORM robusto y eficiente
- **MySQL** por la base de datos confiable y escalable
- **Comunidad .NET** por el soporte y recursos disponibles

---

**GESTOR_TORNEOSv4** - Sistema profesional de gestión de torneos de fútbol ⚽🏆
