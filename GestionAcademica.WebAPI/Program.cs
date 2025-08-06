using GestionAcademica.Services;
using GestionAcademica.Domain;
using GestionAcademica.DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpLogging();
}

app.UseHttpsRedirection();

app.MapGet("/alumnos/{id}", (int id) =>
{
    AlumnoService alumnoService = new AlumnoService();

  

   

    Alumno alumno = alumnoService.Get(id);

    if (alumno == null)
    {
        return Results.NotFound();
    }

    var dto = new GestionAcademica.DTOs.AlumnoDto
    {
        Id = alumno.Id,
        Nombre = alumno.Nombre,
        Apellido = alumno.Apellido,
        Legajo = alumno.Legajo,
        Email = alumno.Email,
        FechaNacimiento = alumno.FechaNacimiento
    };

    return Results.Ok(dto);
})
.WithName("GetAlumno")
.Produces<AlumnoDto>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);

app.MapGet("/alumnos", () =>
{
    var alumnoService = new AlumnoService();

    var alumnos = alumnoService.GetAll();

    var dtos = alumnos.Select(alumno => new AlumnoDto
    {
        Id = alumno.Id,
        Nombre = alumno.Nombre,
        Apellido = alumno.Apellido,
        Legajo = alumno.Legajo,
        Email = alumno.Email,
        FechaNacimiento = alumno.FechaNacimiento
    }).ToList();

    return Results.Ok(dtos);
})
.WithName("GetAllAlumnos")
.Produces<List<AlumnoDto>>(StatusCodes.Status200OK);

app.MapPost("/alumnos", (AlumnoDto dto) =>
{
    try
    {
        var alumnoService = new AlumnoService();

        var alumno = new Alumno(dto.Id, dto.Nombre, dto.Apellido, dto.Legajo, dto.Email, dto.FechaNacimiento);

        alumnoService.Add(alumno);

        var dtoResultado = new AlumnoDto
        {
            Id = alumno.Id,
            Nombre = alumno.Nombre,
            Apellido = alumno.Apellido,
            Legajo = alumno.Legajo,
            Email = alumno.Email,
            FechaNacimiento = alumno.FechaNacimiento
        };

        return Results.Created($"/alumnos/{dtoResultado.Id}", dtoResultado);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
})
.WithName("AddAlumno")
.Produces<AlumnoDto>(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest);

app.MapPut("/alumnos", (AlumnoDto dto) =>
{
    try
    {
        var alumnoService = new AlumnoService();

        var alumno = new Alumno(dto.Id, dto.Nombre, dto.Apellido, dto.Legajo, dto.Email, dto.FechaNacimiento);

        var found = alumnoService.Update(alumno);

        if (!found)
        {
            return Results.NotFound();
        }

        return Results.NoContent();
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
})
.WithName("UpdateAlumno")
.Produces(StatusCodes.Status404NotFound)
.Produces(StatusCodes.Status400BadRequest);

app.MapDelete("/alumnos/{id}", (int id) =>
{
    var alumnoService = new AlumnoService();

    var deleted = alumnoService.Delete(id);

    if (!deleted)
    {
        return Results.NotFound();
    }

    return Results.NoContent();

})
.WithName("DeleteAlumno")
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status404NotFound);

app.MapGet("/materias/{id}", (int id) =>
{
    var materiaService = new MateriaService();

    var materia = materiaService.Get(id);

    if (materia == null)
    {
        return Results.NotFound();
    }

    var dto = new MateriaDto
    {
        Id = materia.Id,
        Nombre = materia.Nombre,
        Codigo = materia.Codigo,
        Creditos = materia.Creditos
    };

    return Results.Ok(dto);
})
   .WithName("GetMateria")
   .Produces<MateriaDto>(StatusCodes.Status200OK)
   .Produces(StatusCodes.Status404NotFound);

app.MapGet("/materias", () =>
{
    var materiaService = new MateriaService();

    var materias = materiaService.GetAll();

    var dtos = materias.Select(materia => new MateriaDto
    {
        Id = materia.Id,
        Nombre = materia.Nombre,
        Codigo = materia.Codigo,
        Creditos = materia.Creditos
    }).ToList();

    return Results.Ok(dtos);
})
.WithName("GetAllMaterias")
.Produces<List<MateriaDto>>(StatusCodes.Status200OK);

app.MapPost("/materias", (MateriaDto dto) =>
{
    try
    {
        var materiaService = new MateriaService();

        var materia = new Materia(dto.Id, dto.Nombre, dto.Codigo, dto.Creditos);

        materiaService.Add(materia);

        var dtoResultado = new MateriaDto
        {
            Id = materia.Id,
            Nombre = materia.Nombre,
            Codigo = materia.Codigo,
            Creditos = materia.Creditos
        };

        return Results.Created($"/materias/{dtoResultado.Id}", dtoResultado);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
})
.WithName("AddMateria")
.Produces<MateriaDto>(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest);

app.MapPut("/materias", (MateriaDto dto) =>
{
    try
    {
        var materiaService = new MateriaService();

        var materia = new Materia(dto.Id, dto.Nombre, dto.Codigo, dto.Creditos);

        var found = materiaService.Update(materia);

        if (!found)
        {
            return Results.NotFound();
        }

        return Results.NoContent();
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
})
.WithName("UpdateMateria")
.Produces(StatusCodes.Status404NotFound)
.Produces(StatusCodes.Status400BadRequest);

app.MapDelete("/materias/{id}", (int id) =>
{
    var materiaService = new MateriaService();

    var deleted = materiaService.Delete(id);

    if (!deleted)
    {
        return Results.NotFound();
    }

    return Results.NoContent();

})
.WithName("DeleteMateria")
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status404NotFound);

app.Run();