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
INNER JOIN tablacodigociap c ON (c.id=p.TablaCodigoCIAPId) 
ORDER BY codigo

-- Listado de cuantas citas diarias tiene de media cada profesional.
-- COUNT (DISTINCT) cuenta el numero de citas distintas, si tienes
SELECT p.nombre, COUNT(1)/COUNT(DISTINCT c.Fecha_atencion)
FROM tablaprofesional p
INNER JOIN tablacitaspaciente c ON (p.id=c.Id_profesional) 
GROUP BY p.id

-- Listado de los medicamentos ordenados por nombre.
SELECT nombre_medicamento
FROM tablamedicamentos
ORDER BY nombre_medicamento

-- Listado de personas polirecetadas. (Han recibido más de 10 medicamentos en los últimos 2 años)

SELECT p.nombre,COUNT(1) AS "Numero de medicamentos"
FROM tablarecetas r
INNER JOIN tablapaciente p ON(p.id = r.ID_paciente)
GROUP BY r.ID_paciente
HAVING COUNT(1) >=2

-- Listado de profesionales que tienen de media más de 5 episodios abiertos por paciente. (Profesionales que NO cierran episodios)

SELECT p.id, p.nombre, AVG(episodiosAbiertos)
FROM (
    SELECT id_paciente, COUNT(1) episodiosAbiertos
    FROM tablaepisodios
    WHERE fechafinal IS NULL
    GROUP BY id_paciente
) e
INNER JOIN tablaprofesional_paciente i ON (i.id_Paciente=e.id_paciente)
INNER JOIN tablaprofesional p ON (p.id = i.id_profesional)
GROUP BY p.id, p.nombre
HAVING AVG(episodiosAbiertos) > 5

-- Listado de los antecedentes de un paciente seleccionado.

SELECT a.id,c.enfermedad,p.nombre
FROM tablaantecedentes a
INNER JOIN tablapaciente p
	ON(p.id = a.Id_paciente)
INNER JOIN tablacodigociap c
	ON(c.id=a.id_ciap)
	
-- Con parámetros sencillos:
-- Listado de episodios (con patología) abiertos que tiene un paciente seleccionado.

SELECT e.id,p.Nombre,p.Apellido1
FROM tablaepisodios e
INNER JOIN tablapaciente p
	ON(p.id=e.Id_Paciente)
WHERE e.FechaFinal IS NULL 

-- Listado de recetas (con información del medicamento) que tiene un paciente seleccionado.

SELECT p.nombre,r.Id_medicamento,m.Nombre_medicamento
FROM tablarecetas r
INNER JOIN tablapaciente p
	ON(p.id=r.ID_Paciente)
INNER JOIN tablamedicamentos m
	ON(m.id=r.Id_medicamento)
WHERE p.nombre="Maria del Carmen"

-- Listado de recetas realizadas por un profesional de un medicamento concreto ordenado por fecha (incluir datos del paciente).
SELECT p.nombre NombrePaciente, pro.nombre NombreProfesional, m.Nombre_medicamento
FROM tablarecetas r
INNER JOIN tablapaciente p 
    ON(p.id=r.ID_Paciente)
INNER JOIN tablaprofesional_paciente pp
    ON(p.id=pp.Id_Paciente)
INNER JOIN tablaprofesional pro
    ON(pro.id=pp.Id_Profesional)
INNER JOIN tablamedicamentos m
    ON(m.id=r.Id_medicamento)
     
-- Listado de citas de un día de un profesional seleccionado. 
SELECT cp.id, cp.Fecha_atencion, p.Nombre NombreProfesional
FROM tablacitaspaciente cp
INNER JOIN tablaprofesional p
    ON(p.id=cp.Id_profesional)
    
-- Listado de citas de un paciente.
SELECT p.Id,p.Nombre,cp.Fecha_atencion,cp.Fecha_acabar,cp.Fecha_registro
FROM tablacitaspaciente cp
INNER JOIN tablapaciente p
	ON(p.id=cp.Id_paciente)
	
-- Listado de siguiente hueco libre de las citas de un profesional seleccionado.

