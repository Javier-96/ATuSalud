CREATE TABLE TablaRecetas(

       Id INT PRIMARY KEY AUTO_INCREMENT,
       Id_medicamento INT,
       FOREIGN KEY (Id_medicamento) REFERENCES TablaMedicamentos(Id),
       Diagnostico VARCHAR(50),
       Medicamento_generico VARCHAR(50),
       Cantidad VARCHAR(50),
       Dosis VARCHAR(50),
       Duracion VARCHAR(50),
       Fecha DATETIME
       
       )
       
       
      CREATE TABLE TablaMedicamentos(

       Id INT PRIMARY KEY AUTO_INCREMENT,
       Nombre_medicamento VARCHAR(50),
       Forma_farmaceutica VARCHAR(50),
       Efectos_secundarios VARCHAR(50)
       
       )     
       
        
CREATE TABLE TablaPatologias(

       Id INT PRIMARY KEY AUTO_INCREMENT,
       TablaPacienteId INT,
       TablaCodigoCIAPId INT,
       FOREIGN KEY(TablaPacienteId) REFERENCES TablaPaciente(Id),
       FOREIGN KEY(TablaCodigoCIAPId) REFERENCES TablaCodigoCIAP(Id),
       Descripcion VARCHAR(50)
       )
       
       