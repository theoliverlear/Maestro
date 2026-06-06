# Guía del módulo

Este repositorio usa proyectos `.csproj` pequeños como módulos. Hay dos casos
principales:

- Módulos principales del repositorio, con `Maestro` en el nombre.
- Bibliotecas internas dentro de `Maestro-Biblioteca`, referenciadas por
  `Maestro.Biblioteca`.

En ambos casos, el proyecto debe agregarse a `Maestro.sln` para que el IDE y
`dotnet build` puedan verlo.

## Agregar un módulo principal de Maestro

Usa este proceso cuando agregues un proyecto de primer nivel, hermano de
`Maestro-Api`, `Maestro-Biblioteca` o `Maestro-Sitio-Web`. El nombre del
proyecto y del ensamblado debe incluir `Maestro`.

1. Crea la carpeta del proyecto y el archivo `.csproj`.

```powershell
dotnet new classlib `
  --framework net8.0 `
  --name Maestro.Example `
  --output Maestro-Example
```

2. Agrega el proyecto a la solución.

```powershell
dotnet sln Maestro.sln add `
  Maestro-Example\Maestro.Example.csproj `
  --solution-folder Maestro-Example
```

3. Verifica la solución.

```powershell
dotnet sln Maestro.sln list
dotnet build Maestro.sln
```

## Agregar una biblioteca en Maestro-Biblioteca

Usa este proceso cuando agregues una biblioteca dentro de `Maestro-Biblioteca`,
como un proyecto hermano de `Biblioteca-Api` o `Biblioteca-Universal`.

1. Crea la carpeta del proyecto y el archivo `.csproj`.

```powershell
dotnet new classlib `
  --framework net8.0 `
  --name Biblioteca.Example `
  --output Maestro-Biblioteca\Biblioteca-Example
```

2. Edita `Maestro-Biblioteca\Maestro.Biblioteca.csproj`.

Agrega el módulo a los tres grupos de elementos:

```xml
<ItemGroup>
    <Compile Remove="Biblioteca-Api\**\*.cs" />
    <Compile Remove="Biblioteca-Universal\**\*.cs" />
    <Compile Remove="Biblioteca-Example\**\*.cs" />
</ItemGroup>

<ItemGroup>
    <ProjectReference Include="Biblioteca-Api\Biblioteca.Api.csproj" />
    <ProjectReference Include="Biblioteca-Universal\Biblioteca.Universal.csproj" />
    <ProjectReference Include="Biblioteca-Example\Biblioteca.Example.csproj" />
</ItemGroup>

<ItemGroup>
    <Content Include="Biblioteca-Api\Biblioteca.Api.csproj" />
    <Content Include="Biblioteca-Universal\Biblioteca.Universal.csproj" />
    <Content Include="Biblioteca-Example\Biblioteca.Example.csproj" />
</ItemGroup>
```

La línea `Compile Remove` es importante. Sin ella, el proyecto contenedor puede
compilar directamente los archivos generados del módulo anidado y producir
errores por atributos de ensamblado duplicados.

3. Agrega el proyecto a la solución.

```powershell
dotnet sln Maestro.sln add `
  Maestro-Biblioteca\Biblioteca-Example\Biblioteca.Example.csproj `
  --solution-folder Maestro-Biblioteca
```

4. Verifica la solución.

```powershell
dotnet sln Maestro.sln list
dotnet build Maestro.sln
```
