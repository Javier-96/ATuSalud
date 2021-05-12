sql15-- Listado de pacientes que no han asistido a la cita.

ALTER TABLE tablacitaspaciente ADD Asistencia VARCHAR(200) NOT NULL
			CHECK(Asistencia IN('Si','No'))
			DEFAULT 'No'
			
SELECT p.nombre,p.apellido1,p.apellido2
FROM tablacitaspaciente cp
INNER JOIN tablapaciente p ON(p.id=cp.Id_paciente)
WHERE cp.Asistencia='No' AND Fecha_acabar < CURDATE()

sql16_Sandra-- Listado de pacientes que reciben medicamentos de manera crónica y que son incompatibles.

CREATE TABLE Incompatibilidades(
	id INT PRIMARY KEY AUTO_INCREMENT,
	id_medicamento INT,
	id_medicamento_incompatible INT,
	CONSTRAINT medicamento FOREIGN KEY (id_medicamento) 
				REFERENCES tablamedicamentos(id),
	CONSTRAINT medicamento_inc FOREIGN KEY (id_medicamento_incompatible) 
				REFERENCES tablamedicamentos(id)			
)

ALTER TABLE tablarecetas ADD dias_regenerado INT NOT NULL DEFAULT 0;


SELECT *
FROM tablapaciente 
WHERE id IN (
    SELECT tr.id_paciente
    FROM incompatibilidades ti 
    INNER JOIN tablarecetas tr ON(tr.id_medicamento = ti.id_medicamento)
    INNER JOIN tablarecetas tr2 ON(tr2.id_medicamento = ti.id_medicamento_incompatible)
    WHERE tr.id_paciente = tr2.id_paciente AND tr.dias_regenerado!=0
) 


sql17_Javier-- Listado de los centros de trabajo que tienen profesionales de una especialidad seleccionada.

CREATE TABLE tablaCentros(
	id INT PRIMARY KEY AUTO_INCREMENT,
	nombre VARCHAR(200),
	direccion VARCHAR(200)
);

ALTER TABLE tablaprofesional ADD id_centro INT;
ALTER TABLE tablaprofesional ADD FOREIGN KEY (id_centro) REFERENCES tablaCentros(id);

SELECT c.nombre,p.especialidad
FROM tablaprofesional p
INNER JOIN tablaCentros c ON(c.id=p.id_centro)
WHERE p.especialidad ='Oncologia'

sql18_Victor-- Listado de los pacientes que tienen antecedentes de una patología relativa al CIAP relativo a la psicología (CIAP empieza por P).

SELECT p.nombre,c.codigo,c.Enfermedad,a.Familiar
FROM tablapaciente p 
INNER JOIN tablaantecedentes a ON (p.id=a.Id_Paciente)
INNER JOIN tablacodigociap c ON (c.id=a.id_ciap)
WHERE c.Codigo LIKE 'P%'

sql19_Nils-- Listado de los medicamentos que tienen efectos secundarios que pueden ser severos. (Respetar los datos que ya se disponen)

CREATE TABLE TablaEfectos_secundarios(
	id INT PRIMARY KEY AUTO_INCREMENT,
	nombre_efecto VARCHAR(200),
	severidad VARCHAR(200) CHECK (severidad IN('Grave','Medio','Leve')) 
	DEFAULT 'Leve'
);

CREATE TABLE TablaMedicamento_efectos(
	id INT PRIMARY KEY AUTO_INCREMENT,
	id_medicamento INT,
	id_efectoSec INT,
	FOREIGN KEY (id_medicamento) 
		REFERENCES tablamedicamentos(id),
	FOREIGN KEY (id_efectoSec)
		REFERENCES TablaEfectos_secundarios(id)
)

ALTER TABLE tablamedicamentos ADD id_efectoSec INT;
ALTER TABLE tablamedicamentos ADD FOREIGN KEY (id_efectoSec) REFERENCES TablaMedicamento_efectos(id);

SELECT m.Nombre_medicamento,es.nombre_efecto,
FROM tablamedicamentos m
INNER JOIN TablaMedicamento_efectos ms ON (ms.id_medicamento = m.id)
INNER JOIN Tablaefectos_secundarios es ON (es.id = ms.id)
WHERE es.severidad = 'Grave';

ALTER TABLE tablamedicamentos DROP COLUMN Efectos_secundarios






