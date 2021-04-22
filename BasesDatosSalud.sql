CREATE TABLE TablaEpisodios(
	Id INT PRIMARY KEY AUTO_INCREMENT,
	Id_Paciente INT,
	FOREIGN KEY (Id_Paciente) REFERENCES TablaPaciente (Id),
	FechaInicio DATE,
	FechaFinal DATE,
	Motivo VARCHAR(200),
	Causa VARCHAR(200),
	Medicacion VARCHAR(200)
)

CREATE TABLE TablaAntecedentes(
	Id INT PRIMARY KEY AUTO_INCREMENT,
	Id_Paciente INT,
	FOREIGN KEY (Id_Paciente) REFERENCES TablaPaciente (Id),
	Familiar VARCHAR(200),
	Enfermedad VARCHAR(200)
)

CREATE TABLE TablaEspacios(
	Id INT PRIMARY KEY AUTO_INCREMENT,
	Id_Reserva INT,
	FOREIGN KEY (Id_Reserva) REFERENCES TablaReservaEspacios (Id),
	EspacioGeneral VARCHAR(200),
	Mobiliario VARCHAR(200)
)


CREATE TABLE TablaCodigoCIAP(
	Id INT PRIMARY KEY AUTO_INCREMENT,
	Codigo VARCHAR(200),
	Color VARCHAR(200),
	Enfermedad VARCHAR(200)	
)

ALTER TABLE TablaPatologias DROP COLUMN Patologia

ALTER TABLE TablaPatologias ADD FOREIGN KEY (Id_Codigo) REFERENCES TablaCodigoCIAP(Id)