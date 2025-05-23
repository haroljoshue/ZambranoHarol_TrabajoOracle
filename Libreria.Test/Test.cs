using Libreria.Modelos;
using Libreria.Api.Consumer;

namespace Libreria.Test
{
    internal class Test
    {
        static void Main(string[] args)
        {
            ProbarEventos();
            ProbarParticipantes();
            ProbarPonentes();
            ProbarInscripciones();
            Console.ReadLine();
        }

        private static void ProbarEventos()
        {
            Crud<Evento>.EndPoint = "http://localhost:5221/api/Eventos"; 


            var evento = Crud<Evento>.Create(new Evento
            {
                EventoId = 0,  
                Nombre = "Conferencia de Tecnología",
                FechaInicio = new DateTime(2025, 6, 15, 9, 0, 0),
                FechaFin = new DateTime(2025, 6, 15, 17, 0, 0),
                Precio = 100.50m,
                Tipo = "Conferencia",
                Lugar = "Centro de Convenciones",
                Descripcion = "Una conferencia sobre las últimas tendencias en tecnología.",
                Modalidad = "Presencial"
            }).Result;

            if (evento == null)
            {
                Console.WriteLine("Error: No se pudo crear el evento.");
                return;
            }

            Console.WriteLine($"Evento creado: {evento.Nombre}, Fecha de Inicio: {evento.FechaInicio}");

            // Actualizar el evento
            evento.Nombre = "Conferencia de Tecnología 2025";
            Crud<Evento>.Update(evento.EventoId, evento).Wait();

            // Obtener todos los eventos
            var eventos = Crud<Evento>.GetAll().Result;

            if (eventos == null || eventos.Count == 0)
            {
                Console.WriteLine("Error: No se encontraron eventos.");
                return;
            }

            Console.WriteLine("Eventos encontrados:");
            foreach (var e in eventos)
            {
                Console.WriteLine($"EventoId: {e.EventoId}, Nombre: {e.Nombre}, Tipo: {e.Tipo}, FechaInicio: {e.FechaInicio}, Lugar: {e.Lugar}");
            }

        }

        private static void ProbarPonentes()
        {
            Crud<Ponente>.EndPoint = "http://localhost:5221/api/Ponentes"; // Endpoint correcto

            // Crear un objeto de la clase Ponente
            var ponente = Crud<Ponente>.Create(new Ponente
            {
                PonenteId = 0,   // Para crear un registro nuevo (0 es usualmente usado para indicar que el ID será asignado automáticamente)
                Nombres = "Carlos",
                Apellidos = "Martínez",
                Institucion = "Universidad Nacional",
                Correo = "carlos.martinez@un.edu",
                Especialidad = "Inteligencia Artificial"
            }).Result;

            if (ponente == null)
            {
                Console.WriteLine("Error: No se pudo crear el ponente.");
                return;
            }

            Console.WriteLine($"Ponente creado: {ponente.Nombres} {ponente.Apellidos}, Especialidad: {ponente.Especialidad}");

            // Actualizar el ponente
            ponente.Nombres = "Carlos Actualizado";
            ponente.Especialidad = "Machine Learning";
            Crud<Ponente>.Update(ponente.PonenteId, ponente).Wait();

            // Obtener todos los ponentes
            var ponentes = Crud<Ponente>.GetAll().Result;

            if (ponentes == null || ponentes.Count == 0)
            {
                Console.WriteLine("Error: No se encontraron ponentes.");
                return;
            }

            Console.WriteLine("Ponentes encontrados:");
            foreach (var p in ponentes)
            {
                Console.WriteLine($"PonenteId: {p.PonenteId}, Nombres: {p.Nombres}, Apellidos: {p.Apellidos}, Especialidad: {p.Especialidad}");
            }

            // Eliminar el ponente creado
            Crud<Ponente>.Delete(ponente.PonenteId).Wait();
            Console.WriteLine($"Ponente con ID {ponente.PonenteId} eliminado.");
        }

        private static void ProbarParticipantes()
        {
            Crud<Participante>.EndPoint = "http://localhost:5221/api/Participantes"; // Endpoint correcto

            // Crear un objeto de la clase Participante
            var participante = Crud<Participante>.Create(new Participante
            {
                ParticipanteId = 0,   // Para crear un registro nuevo (0 es usado para indicar que el ID será asignado automáticamente)
                Dni = "1234567890",
                Nombres = "Ana",
                Apellidos = "Gomez",
                Institucion = "Universidad Central",
                Correo = "ana.gomez@uc.edu",
                Telefono = "0998765432"
            }).Result;

            if (participante == null)
            {
                Console.WriteLine("Error: No se pudo crear el participante.");
                return;
            }

            Console.WriteLine($"Participante creado: {participante.Nombres} {participante.Apellidos}, Institución: {participante.Institucion}");

            // Actualizar el participante
            participante.Nombres = "Ana Actualizada";
            participante.Telefono = "0991234567";
            Crud<Participante>.Update(participante.ParticipanteId, participante).Wait();

            // Obtener todos los participantes
            var participantes = Crud<Participante>.GetAll().Result;

            if (participantes == null || participantes.Count == 0)
            {
                Console.WriteLine("Error: No se encontraron participantes.");
                return;
            }

            Console.WriteLine("Participantes encontrados:");
            foreach (var p in participantes)
            {
                Console.WriteLine($"ParticipanteId: {p.ParticipanteId}, Nombres: {p.Nombres}, Apellidos: {p.Apellidos}, Institucion: {p.Institucion}, Correo: {p.Correo}, Telefono: {p.Telefono}");
            }

            // Eliminar el participante creado
            Crud<Participante>.Delete(participante.ParticipanteId).Wait();
            Console.WriteLine($"Participante con ID {participante.ParticipanteId} eliminado.");
        }

        private static void ProbarInscripciones()
        {
            Crud<Inscripcion>.EndPoint = "http://localhost:5221/api/Inscripciones"; // Endpoint correcto

            // Crear un objeto de la clase Inscripcion
            var inscripcion = Crud<Inscripcion>.Create(new Inscripcion
            {
                InscripcionId = 0,   // Para crear un registro nuevo (0 es usado para indicar que el ID será asignado automáticamente)
                EstadoPago = true,
                FechaInscripcion = DateTime.Now,
                EventoId = 1,   // ID del evento (asumiendo que el evento con ID 1 existe)
                ParticipanteId = 1  // ID del participante (asumiendo que el participante con ID 1 existe)
            }).Result;

            if (inscripcion == null)
            {
                Console.WriteLine("Error: No se pudo crear la inscripción.");
                return;
            }

            Console.WriteLine($"Inscripción creada: EventoID: {inscripcion.EventoId}, ParticipanteID: {inscripcion.ParticipanteId}, Estado de pago: {inscripcion.EstadoPago}");

            // Actualizar la inscripción
            inscripcion.EstadoPago = false;  // Cambiar estado de pago
            Crud<Inscripcion>.Update(inscripcion.InscripcionId, inscripcion).Wait();

            // Obtener todas las inscripciones
            var inscripciones = Crud<Inscripcion>.GetAll().Result;

            if (inscripciones == null || inscripciones.Count == 0)
            {
                Console.WriteLine("Error: No se encontraron inscripciones.");
                return;
            }

            Console.WriteLine("Inscripciones encontradas:");
            foreach (var i in inscripciones)
            {
                Console.WriteLine($"InscripcionId: {i.InscripcionId}, EventoID: {i.EventoId}, ParticipanteID: {i.ParticipanteId}, EstadoPago: {i.EstadoPago}, FechaInscripcion: {i.FechaInscripcion}");
            }

            // Eliminar la inscripción creada
            Crud<Inscripcion>.Delete(inscripcion.InscripcionId).Wait();
            Console.WriteLine($"Inscripción con ID {inscripcion.InscripcionId} eliminada.");
        }

        private static void ProbarCertificados()
        {
            Crud<Certificado>.EndPoint = "http://localhost:5221/api/Certificados"; // Endpoint correcto

            // Crear un objeto de la clase Certificado
            var certificado = Crud<Certificado>.Create(new Certificado
            {
                CertificadoId = 0,   // Para crear un registro nuevo (0 es usado para indicar que el ID será asignado automáticamente)
                Detalles = "Certificado de participación en el evento XYZ",
                InscripcionId = 1  // ID de la inscripción (asumiendo que la inscripción con ID 1 existe)
            }).Result;

            if (certificado == null)
            {
                Console.WriteLine("Error: No se pudo crear el certificado.");
                return;
            }

            Console.WriteLine($"Certificado creado: CertificadoID: {certificado.CertificadoId}, Detalles: {certificado.Detalles}, InscripcionID: {certificado.InscripcionId}");

            // Actualizar el certificado
            certificado.Detalles = "Certificado actualizado de participación en el evento XYZ";
            Crud<Certificado>.Update(certificado.CertificadoId, certificado).Wait();

            // Obtener todos los certificados
            var certificados = Crud<Certificado>.GetAll().Result;

            if (certificados == null || certificados.Count == 0)
            {
                Console.WriteLine("Error: No se encontraron certificados.");
                return;
            }

            Console.WriteLine("Certificados encontrados:");
            foreach (var c in certificados)
            {
                Console.WriteLine($"CertificadoId: {c.CertificadoId}, Detalles: {c.Detalles}, InscripcionID: {c.InscripcionId}");
            }

            // Eliminar el certificado creado
            Crud<Certificado>.Delete(certificado.CertificadoId).Wait();
            Console.WriteLine($"Certificado con ID {certificado.CertificadoId} eliminado.");
        }

        private static void ProbarPagos()
        {
            Crud<Pago>.EndPoint = "http://localhost:5221/api/Pagos"; // Ajusta si tu endpoint es diferente

            // Crear un nuevo Pago
            var nuevoPago = Crud<Pago>.Create(new Pago
            {
                PagoId = 0,
                Monto = 50.00m,
                FechaPago = DateTime.Now,
                MetodoPago = "Tarjeta",
                Estado = "Completado",
                ComprobantePago = "CP12345XYZ",
                InscripcionId = 1, // Asegúrate que esta inscripción exista
                EventoId = 1       // Asegúrate que este evento exista
            }).Result;

            if (nuevoPago == null)
            {
                Console.WriteLine("No se pudo crear el pago.");
                return;
            }

            Console.WriteLine($"Pago creado: ID={nuevoPago.PagoId}, Monto={nuevoPago.Monto}, Estado={nuevoPago.Estado}");

            // Actualizar el estado del pago
            nuevoPago.Estado = "Validado";
            Crud<Pago>.Update(nuevoPago.PagoId, nuevoPago).Wait();
            Console.WriteLine("Pago actualizado a 'Validado'.");

            // Obtener todos los pagos
            var pagos = Crud<Pago>.GetAll().Result;

            if (pagos == null || pagos.Count == 0)
            {
                Console.WriteLine("No se encontraron pagos.");
                return;
            }

            Console.WriteLine("Lista de Pagos:");
            foreach (var p in pagos)
            {
                Console.WriteLine($"ID={p.PagoId}, Monto={p.Monto}, Estado={p.Estado}, Comprobante={p.ComprobantePago}");
            }

            // Eliminar el pago creado
            Crud<Pago>.Delete(nuevoPago.PagoId).Wait();
            Console.WriteLine($"Pago con ID {nuevoPago.PagoId} eliminado.");
        }

        private static void ProbarSesiones()
        {
            Crud<Sesion>.EndPoint = "http://localhost:5221/api/Sesiones"; // Ajusta el endpoint si es necesario

            // Crear una nueva sesión
            var nuevaSesion = Crud<Sesion>.Create(new Sesion
            {
                SesionId = 0,
                Nombre = "Taller de Innovación",
                HoraInicio = DateTime.Today.AddHours(9),
                HoraFin = DateTime.Today.AddHours(11),
                EventoId = 1, // Asegúrate de que este evento exista
                SalaId = 1    // Asegúrate de que esta sala exista
            }).Result;

            if (nuevaSesion == null)
            {
                Console.WriteLine("No se pudo crear la sesión.");
                return;
            }

            Console.WriteLine($"Sesión creada: ID={nuevaSesion.SesionId}, Nombre={nuevaSesion.Nombre}");

            // Modificar nombre de la sesión
            nuevaSesion.Nombre = "Taller de Tecnología";
            Crud<Sesion>.Update(nuevaSesion.SesionId, nuevaSesion).Wait();
            Console.WriteLine("Sesión actualizada a 'Taller de Tecnología'.");

            // Obtener todas las sesiones
            var sesiones = Crud<Sesion>.GetAll().Result;

            if (sesiones == null || sesiones.Count == 0)
            {
                Console.WriteLine("No se encontraron sesiones.");
                return;
            }

            Console.WriteLine("Lista de Sesiones:");
            foreach (var s in sesiones)
            {
                Console.WriteLine($"ID={s.SesionId}, Nombre={s.Nombre}, HoraInicio={s.HoraInicio}, HoraFin={s.HoraFin}");
            }

            // Eliminar la sesión creada
            Crud<Sesion>.Delete(nuevaSesion.SesionId).Wait();
            Console.WriteLine($"Sesión con ID {nuevaSesion.SesionId} eliminada.");
        }

        private static void ProbarSalas()
        {
            Crud<Sala>.EndPoint = "http://localhost:5221/api/Salas"; // Ajusta el endpoint si es necesario

            // Crear una nueva sala
            var nuevaSala = Crud<Sala>.Create(new Sala
            {
                SalaId = 0,
                Nombre = "Sala Magna",
                Capacidad = 100,
                Ubicacion = "Edificio Central, Piso 2"
            }).Result;

            if (nuevaSala == null)
            {
                Console.WriteLine("No se pudo crear la sala.");
                return;
            }

            Console.WriteLine($"Sala creada: ID={nuevaSala.SalaId}, Nombre={nuevaSala.Nombre}");

            // Modificar datos de la sala
            nuevaSala.Capacidad = 120;
            nuevaSala.Nombre = "Sala Magna Actualizada";
            Crud<Sala>.Update(nuevaSala.SalaId, nuevaSala).Wait();
            Console.WriteLine("Sala actualizada correctamente.");

            // Obtener todas las salas
            var salas = Crud<Sala>.GetAll().Result;

            if (salas == null || salas.Count == 0)
            {
                Console.WriteLine("No se encontraron salas.");
                return;
            }

            Console.WriteLine("Lista de Salas:");
            foreach (var s in salas)
            {
                Console.WriteLine($"ID={s.SalaId}, Nombre={s.Nombre}, Capacidad={s.Capacidad}, Ubicación={s.Ubicacion}");
            }

            // Eliminar la sala creada
            Crud<Sala>.Delete(nuevaSala.SalaId).Wait();
            Console.WriteLine($"Sala con ID {nuevaSala.SalaId} eliminada.");
        }

        private static void ProbarAsistencias()
        {
            Crud<Asistencia>.EndPoint = "http://localhost:5221/api/Asistencias"; // Ajusta el endpoint si es necesario

            // Crear una nueva asistencia
            var nuevaAsistencia = Crud<Asistencia>.Create(new Asistencia
            {
                AsistenciaId = 0,
                FechaRegistro = DateTime.Now,
                Estado = true,
                ParticipanteId = 1, // Asegúrate que exista este participante
                SesionId = 1        // Asegúrate que exista esta sesión
            }).Result;

            if (nuevaAsistencia == null)
            {
                Console.WriteLine("No se pudo registrar la asistencia.");
                return;
            }

            Console.WriteLine($"Asistencia registrada: ID={nuevaAsistencia.AsistenciaId}, ParticipanteID={nuevaAsistencia.ParticipanteId}, SesionID={nuevaAsistencia.SesionId}");

            // Actualizar el estado de la asistencia
            nuevaAsistencia.Estado = false;
            Crud<Asistencia>.Update(nuevaAsistencia.AsistenciaId, nuevaAsistencia).Wait();
            Console.WriteLine("Asistencia actualizada.");

            // Obtener todas las asistencias
            var asistencias = Crud<Asistencia>.GetAll().Result;

            if (asistencias == null || asistencias.Count == 0)
            {
                Console.WriteLine("No se encontraron registros de asistencia.");
                return;
            }

            Console.WriteLine("Lista de asistencias:");
            foreach (var a in asistencias)
            {
                Console.WriteLine($"ID={a.AsistenciaId}, Fecha={a.FechaRegistro}, Estado={a.Estado}, ParticipanteID={a.ParticipanteId}, SesionID={a.SesionId}");
            }

            // Eliminar el registro de asistencia
            Crud<Asistencia>.Delete(nuevaAsistencia.AsistenciaId).Wait();
            Console.WriteLine($"Asistencia con ID {nuevaAsistencia.AsistenciaId} eliminada.");
        }

        private static void ProbarHistorialEventos()
        {
            Crud<HistorialEvento>.EndPoint = "http://localhost:5221/api/HistorialEventos"; // Ajusta el endpoint según tu API

            // Crear un nuevo historial de evento
            var nuevoHistorial = Crud<HistorialEvento>.Create(new HistorialEvento
            {
                HistolialEventoId = 0,
                Fecha = DateTime.Now,
                participantes = 100,
                recaudacion = 1500.75m,
                certificados = 90,
                EventoId = 1 // Asegúrate que este ID de evento exista
            }).Result;

            if (nuevoHistorial == null)
            {
                Console.WriteLine("No se pudo crear el historial del evento.");
                return;
            }

            Console.WriteLine($"Historial creado: ID={nuevoHistorial.HistolialEventoId}, Participantes={nuevoHistorial.participantes}, Recaudación={nuevoHistorial.recaudacion}");

            // Actualizar el historial
            nuevoHistorial.certificados = 95;
            Crud<HistorialEvento>.Update(nuevoHistorial.HistolialEventoId, nuevoHistorial).Wait();
            Console.WriteLine("Historial actualizado.");

            // Obtener todos los historiales
            var historiales = Crud<HistorialEvento>.GetAll().Result;

            if (historiales == null || historiales.Count == 0)
            {
                Console.WriteLine("No se encontraron historiales.");
                return;
            }

            Console.WriteLine("Lista de historiales:");
            foreach (var h in historiales)
            {
                Console.WriteLine($"ID={h.HistolialEventoId}, Fecha={h.Fecha}, Participantes={h.participantes}, Recaudación={h.recaudacion}, Certificados={h.certificados}");
            }

            // Eliminar el historial
            Crud<HistorialEvento>.Delete(nuevoHistorial.HistolialEventoId).Wait();
            Console.WriteLine($"Historial con ID {nuevoHistorial.HistolialEventoId} eliminado.");
        }

        private static void ProbarEventoPonente()
        {
            Crud<EventoPonente>.EndPoint = "http://localhost:5221/api/EventoPonente"; // Ajusta si tu ruta es diferente

            // Crear nueva relación Evento-Ponente
            var nuevaRelacion = Crud<EventoPonente>.Create(new EventoPonente
            {
                EventoPonenteId = 0,
                EventoId = 1,    // Asegúrate de que este evento exista
                PonenteId = 1    // Asegúrate de que este ponente exista
            }).Result;

            if (nuevaRelacion == null)
            {
                Console.WriteLine("No se pudo crear la relación Evento-Ponente.");
                return;
            }

            Console.WriteLine($"Relación creada: ID={nuevaRelacion.EventoPonenteId}, EventoID={nuevaRelacion.EventoId}, PonenteID={nuevaRelacion.PonenteId}");

            // Obtener todas las relaciones
            var relaciones = Crud<EventoPonente>.GetAll().Result;
            if (relaciones == null || relaciones.Count == 0)
            {
                Console.WriteLine("No se encontraron relaciones Evento-Ponente.");
                return;
            }

            Console.WriteLine("Lista de relaciones Evento-Ponente:");
            foreach (var ep in relaciones)
            {
                Console.WriteLine($"ID={ep.EventoPonenteId}, EventoID={ep.EventoId}, PonenteID={ep.PonenteId}");
            }

            // Eliminar la relación
            Crud<EventoPonente>.Delete(nuevaRelacion.EventoPonenteId).Wait();
            Console.WriteLine($"Relación con ID {nuevaRelacion.EventoPonenteId} eliminada.");
        }

    }
}
