# NAGO Reforged - ERP para uso interno e TERCOL

### Requerimientos.
1. DOTNET 9.0.10 o Superior.
2. PostgreSQL 16 o Superior
3. MongoDB 8.0
4. Servidor HTTP (**Apache2.4**/**nginx**)

### Ejecución por Primera vez Localmente
1. Ejecutar contexto de aplicativo 
> dotnet ef dbcontext scaffold "Host=localhost;Database=nago_reforged;Username=admin;Password=admin1234" Npgsql.EntityFrameworkCore.PostgreSQL --output-dir Models --context-dir Context --context ReforgedContext --force
2. Ejecutar seeder para datos iniciales
> dotnet ef database update
3. Ejecutar aplicactivo con Hot Reload 
> dotnet watch

### Ejecución para Despligue
1. Construir aplicación
> dotnet build
2. Ejecutar aplicativo
> dotnet run
3. Configurar servidor para realizar reverser proxy a la aplicación construida