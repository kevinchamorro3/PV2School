using Modelo;
using Modelo.Escuela;
using System;
using System.Collections.Generic;
using static Escenarios.Escenario;

namespace Escenarios
{
    public class Escenario02 : Escenario, IEscenario
    {
        public Dictionary<ListaTipo, IEnumerable<IDBEntity>> Carga()
        {
            // .- Creación de los períodos
            Periodo per2020_PAO2 = new()
            {
                Estado = "Cerrado",
                FechaInicio = new DateTime(2020, 9, 1),
                FechaFin = new DateTime(2021, 3, 1)
            };
            Periodo per2021_PAO1 = new(){Estado = "Cerrado",FechaInicio = new DateTime(2021, 4, 1),FechaFin = new DateTime(2021, 9, 1)};
            Periodo per2021_PAO2 = new(){Estado = "Abierto",FechaInicio = new DateTime(2021, 9, 1),FechaFin = new DateTime(2022, 3, 1)};
            List<Periodo> listaPeriodos = new() { per2020_PAO2, per2021_PAO1, per2021_PAO2 };
            datos.Add(ListaTipo.Periodos, listaPeriodos);

            // .- Configuración de los datos de la escuela
            Configuracion configuracion = new()
            {
                EscuelaNombre = "Escuela Nacional Quito",
                CreditosMaximo = 24,
                NotaMinima = 7.00f,
                PesoNota1 = 0.30f,
                PesoNota2 = 0.30f,
                PesoNota3 = 0.40f,
                PeriodoVigente = per2021_PAO2
            };
            List<Configuracion> listaConfiguracion = new() { configuracion };
            datos.Add(ListaTipo.Configuracion, listaConfiguracion);

            // .- Registro de los estudiantes
            Estudiante estPedro = new() { Nombre = "Pedro Infante" };
            Estudiante estJuan = new() { Nombre = "Juan Mera" };
            Estudiante estMaria = new() { Nombre = "María Brito" };
            List<Estudiante> lstEstudiantes = new(){estJuan, estMaria, estPedro};
            datos.Add(ListaTipo.Estudiantes, lstEstudiantes);

            // .- Registro de las carreras de la oferta académica
            Carrera carSistemas = new()
            {
                Nombre = "Análisis de Sistemas",
                CostoCredito = 34.50f
            };
            Carrera carComercio = new(){Nombre = "Comercio Electrónico",CostoCredito = 35.12f};
            List<Carrera> listaCarreras = new() { carComercio, carSistemas};
            datos.Add(ListaTipo.Carreras, listaCarreras);

            //.- Registro de las materias de la carrera de Comercio Electrónico
            Materia matDisenio = new Materia()
            {
                Area = "Diseño Gráfico",                
                Nombre = "Diseño Web",
                Creditos = 3
            };
            Materia matAdminDB = new() { Area = "Sistemas", Nombre = "Admin BBDD",  Creditos = 3 };
            Materia matLogProg = new() { Area = "Sistemas", Nombre = "Lógica de Prog",  Creditos = 3 };
            Materia matProdDig = new() { Area = "Marketing", Nombre = "Productos Digitales",  Creditos = 2 };
            Materia matProgWeb = new() { Area = "Web", Nombre = "Programación Web",  Creditos = 3 };
            Materia matELearng = new() { Area = "Marketing", Nombre = "E-Learning",  Creditos = 2 };
            Materia matVideoMk = new() { Area = "Marketing", Nombre = "Video Marketing",  Creditos = 3 };
            List<Materia> lstMaterias = new()
            {
                matAdminDB, matDisenio, matELearng, matLogProg, matProdDig, matProgWeb, matVideoMk
            };
            datos.Add(ListaTipo.Materias, lstMaterias);

            // .- Registro de las relaciones en la malla
            Malla mallaProdDig = new()
            {
                Carrera = carComercio,
                Nivel = "3do",
                Materia = matProdDig
            };
            Malla mallaDisenio = new() { Carrera = carComercio, Nivel = "2do", Materia = matDisenio };
            Malla mallaAdminDB = new() { Carrera = carComercio, Nivel = "2do", Materia = matAdminDB };
            Malla mallaLogProg = new() { Carrera = carComercio, Nivel = "3ro", Materia = matLogProg };
            Malla mallaVideoMk = new() { Carrera = carComercio, Nivel = "3ro", Materia = matVideoMk };
            Malla mallaProgWeb = new() { Carrera = carComercio, Nivel = "4ro", Materia = matProgWeb };
            Malla mallaELearng = new() { Carrera = carComercio, Nivel = "4ro", Materia = matELearng };
            List<Malla> lstMallas = new() 
            {
                mallaAdminDB, mallaDisenio, mallaELearng, mallaLogProg, mallaProgWeb, mallaVideoMk, mallaProdDig
            };
            datos.Add(ListaTipo.Mallas, lstMallas);

            // .- Registro de los pre requisitos de cada malla
            Prerequisito preProgWeb_Disenio = new Prerequisito()
            {
                Malla = mallaDisenio,
                Materia = matProgWeb
            };
            Prerequisito preProgWeb_AdminDB = new(){Malla = mallaAdminDB,Materia = matProgWeb};
            Prerequisito preProgWeb_LogProg = new(){Malla = mallaLogProg,Materia = matProgWeb};
            Prerequisito preELearng_ProdDig = new(){Malla = mallaProdDig,Materia = matELearng};
            Prerequisito preELearng_VideoMk = new(){Malla = mallaVideoMk,Materia = matELearng};
            List<Prerequisito> lstPrerequisitos = new List<Prerequisito>() {
                preProgWeb_AdminDB, preProgWeb_Disenio, 
                preProgWeb_LogProg,
                preELearng_ProdDig, preELearng_VideoMk};
            datos.Add(ListaTipo.PreRequisitos, lstPrerequisitos);

            // .- Registro de los cursos
            Curso N2D_2020PAO2_Disenio = new Curso()
            {
                Carrera = carComercio,
                Periodo = per2020_PAO2,
                Materia = matDisenio,
                FechaInicio = new DateTime(2020, 5, 1),
                FechaFin = new DateTime(2020, 6, 30),
                Jornada = "Diurna",
                Nombre = "Nivel 2 Diurna de Diseño Web"
            };
            Curso N2D_2020PAO2_AdminDB = new Curso()
            {
                Carrera = carComercio,
                Periodo = per2020_PAO2,
                Materia = matAdminDB,
                Jornada = "Diurno",
                Nombre = "Nivel 2 Diurno de Administración BBDD",
                FechaInicio = new DateTime(2020, 5, 1),
                FechaFin = new DateTime(2020, 6, 15)
            };
            Curso N3D_2021PAO1_LogProg = new Curso()
            {
                Carrera = carComercio,
                Periodo = per2021_PAO1,
                Materia = matLogProg,
                Jornada = "Diurno",
                Nombre = "Nivel 3 Diurno de Lógica de Programación",
                FechaInicio = new DateTime(2020, 11, 1),
                FechaFin = new DateTime(2021, 1, 30)
            };
            Curso N3D_2021PAO1_ProdDig = new Curso()
            {
                Carrera = carComercio,
                Periodo = per2021_PAO1,
                Materia = matProdDig,
                Jornada = "Diurno",
                Nombre = "Nivel 3 Diurno de Productos Digitales",
                FechaInicio = new DateTime(2020, 2, 10),
                FechaFin = new DateTime(2021, 3, 28)
            };
            Curso N3D_2021PAO1_VideoMk = new Curso()
            {
                Carrera = carComercio,
                Periodo = per2021_PAO1,
                Materia = matVideoMk,
                Jornada = "Diurno",
                Nombre = "Nivel 3 Diurno de Video Marketing",
                FechaInicio = new DateTime(2020, 4, 7),
                FechaFin = new DateTime(2021, 6, 8)
            };
            Curso N4D_2021PAO2_ProgWeb = new Curso()
            {
                Carrera = carComercio,
                Periodo = per2021_PAO2,
                Materia = matProgWeb,
                Jornada = "Diurno",
                Nombre = "Nivel 4 Diurno de Programación Web",
                FechaInicio = new DateTime(2021, 11, 1),
                FechaFin = new DateTime(2021, 12, 21)
            };
            Curso N4D_2021PAO2_Elearng = new Curso()
            {
                Carrera = carComercio,
                Periodo = per2021_PAO2,
                Materia = matELearng,
                Jornada = "Diurno",
                Nombre = "Nivel 4 Diurno de E-Learning",
                FechaInicio = new DateTime(2022, 1, 4),
                FechaFin = new DateTime(2022, 2, 27)
            };
            List<Curso> lstCursos = new List<Curso>() {
                // Nivel 2
                N2D_2020PAO2_AdminDB, N2D_2020PAO2_Disenio,  
                // Nivel 3
                N3D_2021PAO1_LogProg, N3D_2021PAO1_ProdDig, N3D_2021PAO1_VideoMk,
                // Nivel 4
                N4D_2021PAO2_Elearng, N4D_2021PAO2_ProgWeb
            };
            datos.Add(ListaTipo.Cursos, lstCursos);

            // Retorna el diccionario 
            return datos;
        }

    }
}
