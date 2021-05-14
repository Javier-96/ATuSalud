# ATuSalud
OceanoAtlantico Salud

# Instrucciones de instalación v1.0

-Crear base de datos Mysql con gestor de bases de datos.

-Crear nueva conexion con IP 192.168.1.232  y usuario oceanosalud con password = 1111.

-Enlazar la base de datos dentro de visual studio en appsettings.json.

-Ejecutar el programa.

![image](https://user-images.githubusercontent.com/82440555/118230782-77036900-b48e-11eb-91d9-2a46f6890826.png)


Figura 1 – Diagrama de casos de uso.

A continuación, se definirán los requerimientos extraídos de las funcionalidades analizadas de los casos de uso anteriores:

•	El sistema debe dar la posibilidad al usuario de gestionar las citas de todos los pacientes dados de alta en la base de datos.
 
•	El sistema debe dar la posibilidad al usuario de gestionar los profesionales junto con sus especialidades y vincularlos a la atención de cada paciente.

•	El sistema debe proporcionar al usuario una interfaz sobre la que visualizar toda la información de las citas de los pacientes junto con sus profesionales asociados.

•	El sistema debe permitir al usuario añadir, modificar, actualizar y eliminar cualquier registro de la base de datos relacionado con gestión de citas, pacientes y profesionales.

•	El sistema debe poder ser accedido a través de credenciales que identifiquen el tipo de usuario y sus permisos sobre la aplicación.

•	El sistema debe permitir al usuario gestionar el historial clínico vinculado a un paciente concreto y visualizar su información por pantalla.

•	El sistema debe permitir al usuario poder importar datos a través de plantillas en formato Excel para cumplimentar los diversos datos y campos de cada paciente y profesional.

•	El sistema dividirá el historial clínico de cada paciente en subsecciones relacionadas con las patologías y episodios de cada paciente, medicamentos y recetas, antecedentes y datos físicos de importancia.

SPRINT 2:
Modificaciones realizadas sobre la base de datos:

•ALTER TABLE tablacitaspaciente ADD Asistencia VARCHAR(200) NOT NULL
			CHECK(Asistencia IN('Si','No'))
			DEFAULT 'No'

•CREATE TABLE Incompatibilidades(
	id INT PRIMARY KEY AUTO_INCREMENT,
	id_medicamento INT,
	id_medicamento_incompatible INT,
	CONSTRAINT medicamento FOREIGN KEY (id_medicamento) 
				REFERENCES tablamedicamentos(id),
	CONSTRAINT medicamento_inc FOREIGN KEY (id_medicamento_incompatible) 
				REFERENCES tablamedicamentos(id)			
)

•ALTER TABLE tablarecetas ADD dias_regenerado INT NOT NULL DEFAULT 0;

•CREATE TABLE tablaCentros(
	id INT PRIMARY KEY AUTO_INCREMENT,
	nombre VARCHAR(200),
	direccion VARCHAR(200)
);

•ALTER TABLE tablaprofesional ADD id_centro INT;
•ALTER TABLE tablaprofesional ADD FOREIGN KEY (id_centro) REFERENCES tablaCentros(id);


•CREATE TABLE TablaEfectos_secundarios(
	id INT PRIMARY KEY AUTO_INCREMENT,
	nombre_efecto VARCHAR(200),
	severidad VARCHAR(200) CHECK (severidad IN('Grave','Medio','Leve')) 
	DEFAULT 'Leve'
);

•CREATE TABLE TablaMedicamento_efectos(
	id INT PRIMARY KEY AUTO_INCREMENT,
	id_medicamento INT,
	id_efectoSec INT,
	FOREIGN KEY (id_medicamento) 
		REFERENCES tablamedicamentos(id),
	FOREIGN KEY (id_efectoSec)
		REFERENCES TablaEfectos_secundarios(id)
)

•ALTER TABLE tablamedicamentos ADD id_efectoSec INT;
•ALTER TABLE tablamedicamentos ADD FOREIGN KEY (id_efectoSec) REFERENCES TablaMedicamento_efectos(id);

•ALTER TABLE tablamedicamentos DROP COLUMN Efectos_secundarios
