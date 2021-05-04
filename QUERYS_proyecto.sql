-- Listado de profesionales ordenados por apellidos y nombre.

SELECT *
FROM tablaprofesional
ORDER BY apellido1, nombre

-- Listado de pacientes menores de edad ordenados por apellidos y nombre.

SELECT *
FROM tablapaciente
WHERE TIMESTAMPDIFF(YEAR, Fecha_de_nacimiento, CURDATE()) < 18
ORDER BY apellido1,apellido2,nombre

-- Listado de las patologías ordenados por código.

SELECT codigo AS Codigo,c.enfermedad AS Enfermedad,p.Descripcion
FROM tablapatologias p
INNER JOIN tablacodigociap c ON (c.id=p.Id_paciente) 
ORDER BY codigo