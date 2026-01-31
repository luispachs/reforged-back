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

Si requieres restaurar la base de datos al punto inicia, debes de usar el siguiente comando.
> DO $$ 

> DECLARE 

> r RECORD;  

> BEGIN  
 
> FOR r IN (SELECT tablename FROM pg_tables WHERE schemaname = current_schema()) LOOP  

> EXECUTE 'TRUNCATE TABLE ' || quote_ident(r.tablename) || ' CASCADE';  

> END LOOP; 

> END $$;  


### Ejecución para Despligue
1. Construir aplicación
> dotnet build
2. Ejecutar aplicativo
> dotnet run
3. Configurar servidor para realizar reverser proxy a la aplicación construida

