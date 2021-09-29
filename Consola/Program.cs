using System;
using Dominio;
using Persistencia;
using System.Collections.Generic;

namespace Consola
{
    class Program
    {
        private static IRepositorioMunicipio _repomunicipio= new RepositorioMunicipio(new Persistencia.AppContext()) ;
        private static IRepositorioArbitro _repoarbitro= new RepositorioArbitro(new Persistencia.AppContext()) ;
        private static IRepositorioPatrocinador _repopatrocinador= new RepositorioPatrocinador(new Persistencia.AppContext()) ;
        private static IRepositorioCanchaEspacio _repocanchaespacio= new RepositorioCanchaEspacio(new Persistencia.AppContext()) ;
        private static IRepositorioDeportista _repodeportista= new RepositorioDeportista(new Persistencia.AppContext()) ;
        private static IRepositorioEntrenador _repoentrenador= new RepositorioEntrenador(new Persistencia.AppContext()) ;
        private static IRepositorioEquipo _repoequipo= new RepositorioEquipo(new Persistencia.AppContext()) ;
        private static IRepositorioEscenario _repoescenario= new RepositorioEscenario(new Persistencia.AppContext()) ;
        private static IRepositorioEscuelaArbitro _repoescuelaarbitro= new RepositorioEscuelaArbitro(new Persistencia.AppContext()) ;
        private static IRepositorioTorneo _repotorneo= new RepositorioTorneo(new Persistencia.AppContext()) ;
        private static IRepositorioTorneoEquipo _repotorneoequipo= new RepositorioTorneoEquipo(new Persistencia.AppContext()) ;

        

        static void Main(string[] args)
        {
            //---------------------
            // INSTANCIA MUNICIPIOS FINAL
            listarMunicipios();
            //buscarMunicipio();
            //crearMunicipio();
            //eliminarMunicipio();
            //actualizarMunicipio();
            //---------------------


            //---------------------
            // INSTANCIA ARBITROS
            //crearArbitro();
            //listarArbitros();
            //buscarArbitro();
            //---------------------


            //---------------------
            // INSTANCIA PATROCINADOR FINAL
            //crearPatrocinador();
            //eliminarPatrocinador();
            //actualizarPatrocinador();
            //buscarPatrocinador();
            //listarPatrocinadores();
            //eliminarPatrocinador();
            //---------------------


            //---------------------
            //INSTANCIA EQUIPO
            //crearEquipo();
            //listarEquipos();
            //buscarEquipo();
            //actualizarEquipo();
            //eliminarEquipo();

            //---------------------
            // INSTANCIA Entrenador 
            //crearEntrenador();
            //eliminarEntrenador();
            //actualizarEntrenador();
            //buscarEntrenador();
            //listarEntrenadores();
            //eliminarEntrenador();
            //---------------------

        }


        private static void crearArbitro()
        {
            var arbitro= new Arbitro
            {
                Documento= "100",
                Nombres = "Jose",
                Apellidos= "Pitana",
                Genero="Masculino",
                Disciplina="Futbol"
            };

            bool funciono= _repoarbitro.CrearArbitro(arbitro);

            if (funciono)
            {
            Console.WriteLine("Arbitro adicionado con exito.");
            }
                else
            {
            Console.WriteLine("Se ha presentado una falla en el proceso.");
            }

        }

    
        private static void listarArbitros()
        {
            IEnumerable<Arbitro> arbitros=_repoarbitro.ListarArbitros();
            foreach (var arb in arbitros)
            {
                Console.WriteLine(arb.id+" "+arb.Nombres);
            }
        }

    
        private static bool eliminarArbitro()
        {
            bool funciono=_repoarbitro.EliminarArbitro(5);
            if (funciono)
                {
                Console.WriteLine("Arbitro eliminado con exito.");
                }
                else
                {
                Console.WriteLine("Se ha presentado una falla en el proceso.");
                }
            return funciono;
        }

    
        private static bool actualizarArbitro()
        {
            var arbitro = new Arbitro
            {
                id=4,
                Nombres="Armenia"
            };
            bool funciono =_repoarbitro.ActualizarArbitro(arbitro);

            if (funciono)
            {
                Console.WriteLine("Arbitro actualizado con exito.");
                Console.WriteLine("Lista actualizada");
                listarArbitros();

            }
            else
            {
                Console.WriteLine("Se ha presentado una falla en el proceso.");
            }


            return funciono;
        }

        private static void buscarArbitro()
        {
            var arb= _repoarbitro.BuscarArbitro(2);
            if (arb!=null)
            {
                Console.WriteLine("Arbitro encontrado.");
                Console.WriteLine(arb.id+" "+arb.Nombres);
            }
            else
            {
                Console.WriteLine("Arbitro no encontrado.");
                
            }
        }

        
        //-------------------------------------------------------

        // CRUD CANCHASESPACIO

        private static void crearCanchaEspacio()
        {
            var canchaespacio= new CanchaEspacio
            {
                Nombre = "Jose",
              
            };

            bool funciono= _repocanchaespacio.CrearCanchaEspacio(canchaespacio);

            if (funciono)
            {
            Console.WriteLine("CanchaEspacio adicionado con exito.");
            }
                else
            {
            Console.WriteLine("Se ha presentado una falla en el proceso.");
            }

        }

    
        private static void listarCanchaEspacios()
        {
            IEnumerable<CanchaEspacio> canchaespacios=_repocanchaespacio.ListarCanchaEspacios();
            foreach (var can in canchaespacios)
            {
                Console.WriteLine(can.id+" "+can.Nombre);
            }
        }

    
        private static bool eliminarCanchaEspacio()
        {
            bool funciono=_repocanchaespacio.EliminarCanchaEspacio(5);
            if (funciono)
                {
                Console.WriteLine("Cancha-Espacio eliminado con exito.");
                }
                else
                {
                Console.WriteLine("Se ha presentado una falla en el proceso.");
                }
            return funciono;
        }

    
        private static bool actualizarCanchaEspacio()
        {
            var canchaespacio = new CanchaEspacio
            {
                id=4,
                Nombre="Armenia"
            };
            bool funciono =_repocanchaespacio.ActualizarCanchaEspacio(canchaespacio);

            if (funciono)
            {
                Console.WriteLine("Cancha-Espacio actualizado con exito.");
                Console.WriteLine("Lista actualizada");
                listarCanchaEspacios();

            }
            else
            {
                Console.WriteLine("Se ha presentado una falla en el proceso.");
            }


            return funciono;
        }

        private static void buscarCanchaEspacio()
        {
            var can= _repocanchaespacio.BuscarCanchaEspacio(2);
            if (can!=null)
            {
                Console.WriteLine("Cancha-Espacio encontrado.");
                Console.WriteLine(can.id+" "+can.Nombre);
            }
            else
            {
                Console.WriteLine("Cancha-Espacio no encontrado.");
                
            }
        }

        //-------------------------------------------------------

        //CREAR DEPORTISTA

        private static void crearDeportista()
        {
            var deportista= new Deportista
            {
                Documento= "100",
                Nombres = "Jose",
                Apellidos= "Pitana",
                Genero="Masculino",
                Disciplina="Futbol"
            };

            bool funciono= _repodeportista.CrearDeportista(deportista);

            if (funciono)
            {
            Console.WriteLine("Deportista adicionado con exito.");
            }
                else
            {
            Console.WriteLine("Se ha presentado una falla en el proceso.");
            }

        }

        private static void listarDeportistas()
        {
            IEnumerable<Deportista> deportista=_repodeportista.ListarDeportistas();
            foreach (var dep in deportista)
            {
                Console.WriteLine(dep.id+" "+dep.Nombres);
            }
        }

        private static bool eliminarDeportista()
        {
            bool funciono=_repodeportista.EliminarDeportista(5);
            if (funciono)
                {
                Console.WriteLine("Deportista eliminado con exito.");
                }
                else
                {
                Console.WriteLine("Se ha presentado una falla en el proceso.");
                }
            return funciono;
        }

        private static bool actualizarDeportista()
        {
            var deportista = new Deportista
            {
                id=4,
                Nombres="Armenia"
            };
            bool funciono =_repodeportista.ActualizarDeportista(deportista);

            if (funciono)
            {
                Console.WriteLine("Deportista actualizado con exito.");
                Console.WriteLine("Lista actualizada");
                listarDeportistas();

            }
            else
            {
                Console.WriteLine("Se ha presentado una falla en el proceso.");
            }


            return funciono;
        }

        private static void buscarDeportista()
        {
            var dep= _repodeportista.BuscarDeportista(2);
            if (dep!=null)
            {
                Console.WriteLine("Deportista encontrado.");
                Console.WriteLine(dep.id+" "+dep.Nombres);
            }
            else
            {
                Console.WriteLine("Deportista no encontrado.");
                
            }
        }

        //-------------------------------------------------------

        //CREAR ENTRENADOR

        private static void crearEntrenador()
        {
            var entrenador= new Entrenador
            {
                Documento="1005",
                Nombres = "Miguel Angel",
                Apellidos="Zapata",
                Genero="Masculino",
                DisciplinaDeportiva="Futbol",
                EquipoId=3
            };

            bool funciono= _repoentrenador.CrearEntrenador(entrenador);

            if (funciono)
            {
            Console.WriteLine("Entrenador adicionado con exito.");
            }
                else
            {
            Console.WriteLine("Se ha presentado una falla en el proceso.");
            }

        }

        private static void listarEntrenadores()
        {
            IEnumerable<Entrenador> entrenadores=_repoentrenador.ListarEntrenadores();
            foreach (var ent in entrenadores)
            {
                Console.WriteLine(ent.id+" "+ent.Nombres);
            }
        }

        private static bool eliminarEntrenador()
        {
            bool funciono=_repoentrenador.EliminarEntrenador(5);
            if (funciono)
                {
                Console.WriteLine("Entrenador eliminado con exito.");
                }
                else
                {
                Console.WriteLine("Se ha presentado una falla en el proceso.");
                }
            return funciono;
        }

        private static bool actualizarEntrenador()
        {
            var entrenador = new Entrenador
            {
                id=3,
                Documento="1005",
                Nombres = "Miguel Angel",
                Apellidos="Zapata",
                Genero="Masculino",
                DisciplinaDeportiva="Futbol",
                EquipoId=3
            };
            bool funciono =_repoentrenador.ActualizarEntrenador(entrenador);

            if (funciono)
            {
                Console.WriteLine("Entrenador actualizado con exito.");
                Console.WriteLine("Lista actualizada");
                listarEntrenadores();

            }
            else
            {
                Console.WriteLine("Se ha presentado una falla en el proceso.");
            }


            return funciono;
        }

        private static void buscarEntrenador()
        {
            var ent= _repoentrenador.BuscarEntrenador(2);
            if (ent!=null)
            {
                Console.WriteLine("Entrenador encontrado.");
                Console.WriteLine(ent.id+" "+ent.Nombres);
            }
            else
            {
                Console.WriteLine("Entrenador no encontrado.");
                
            }
        }

        //-------------------------------------------------------

        //CREAR EQUIPO

        private static void crearEquipo()
        {
            var equipo= new Equipo
            {
                Nombre = "Deportes Tolima",
                CantidadDeportistas= 18,
                Disciplina="Futbol",
                PatrocinadorId=3
            };

            bool funciono= _repoequipo.CrearEquipo(equipo);

            if (funciono)
            {
            Console.WriteLine("Equipo adicionado con exito.");
            }
                else
            {
            Console.WriteLine("Se ha presentado una falla en el proceso.");
            }

        }

        private static void listarEquipos()
        {
            IEnumerable<Equipo> equipos=_repoequipo.ListarEquipos();
            foreach (var equ in equipos)
            {
                Console.WriteLine(equ.id+" "+equ.Nombre);
            }
        }

        private static bool eliminarEquipo()
        {
            bool funciono=_repoequipo.EliminarEquipo(5);
            if (funciono)
                {
                Console.WriteLine("Equipo eliminado con exito.");
                }
                else
                {
                Console.WriteLine("Se ha presentado una falla en el proceso.");
                }
            return funciono;
        }

        private static bool actualizarEquipo()
        {
            var equipo = new Equipo
            {
                Nombre = "Real Magdalena",
                CantidadDeportistas= 12,
                Disciplina="Futbol",
                PatrocinadorId=6
            };
            bool funciono =_repoequipo.ActualizarEquipo(equipo);

            if (funciono)
            {
                Console.WriteLine("Equipo actualizado con exito.");
                Console.WriteLine("Lista actualizada");
                listarEquipos();

            }
            else
            {
                Console.WriteLine("Se ha presentado una falla en el proceso.");
            }


            return funciono;
        }

        private static void buscarEquipo()
        {
            var equ= _repoequipo.BuscarEquipo(1);
            if (equ!=null)
            {
                Console.WriteLine("Equipo encontrado.");
                Console.WriteLine(equ.id+" "+equ.Nombre);
            }
            else
            {
                Console.WriteLine("Equipo no encontrado.");
                
            }
        }

        //-------------------------------------------------------

        //CREAR ESCENARIO

        private static void crearEscenario()
        {
            var escenario= new Escenario
            {
                Nombre = "Jose",
            };

            bool funciono= _repoescenario.CrearEscenario(escenario);

            if (funciono)
            {
            Console.WriteLine("Escenario adicionado con exito.");
            }
                else
            {
            Console.WriteLine("Se ha presentado una falla en el proceso.");
            }

        }

        private static void listarEscenarios()
        {
            IEnumerable<Escenario> escenarios=_repoescenario.ListarEscenarios();
            foreach (var esc in escenarios)
            {
                Console.WriteLine(esc.id+" "+esc.Nombre);
            }
        }

        private static bool eliminarEscenario()
        {
            bool funciono=_repoescenario.EliminarEscenario(5);
            if (funciono)
                {
                Console.WriteLine("Escenario eliminado con exito.");
                }
                else
                {
                Console.WriteLine("Se ha presentado una falla en el proceso.");
                }
            return funciono;
        }

        private static bool actualizarEscenario()
        {
            var escenario = new Escenario
            {
                id=4,
                Nombre="Armenia"
            };
            bool funciono =_repoescenario.ActualizarEscenario(escenario);

            if (funciono)
            {
                Console.WriteLine("Escenario actualizado con exito.");
                Console.WriteLine("Lista actualizada");
                listarEscenarios();

            }
            else
            {
                Console.WriteLine("Se ha presentado una falla en el proceso.");
            }


            return funciono;
        }

        private static void buscarEscenario()
        {
            var esc= _repoescenario.BuscarEscenario(2);
            if (esc!=null)
            {
                Console.WriteLine("Escenario encontrado.");
                Console.WriteLine(esc.id+" "+esc.Nombre);
            }
            else
            {
                Console.WriteLine("Escenario no encontrado.");
                
            }
        }

        //-------------------------------------------------------

        //CREAR ESCUELA-ARBITRO

        private static void crearEscuelaArbitro()
        {
            var escuelaarbitro= new EscuelaArbitro
            {
                Nombre = "Jose",
            };

            bool funciono= _repoescuelaarbitro.CrearEscuelaArbitro(escuelaarbitro);

            if (funciono)
            {
            Console.WriteLine("Escuela-Arbitro adicionado con exito.");
            }
                else
            {
            Console.WriteLine("Se ha presentado una falla en el proceso.");
            }

        }

        private static void listarEscuelaArbitros()
        {
            IEnumerable<EscuelaArbitro> escuelaarbitros=_repoescuelaarbitro.ListarEscuelaArbitros();
            foreach (var esc in escuelaarbitros)
            {
                Console.WriteLine(esc.id+" "+esc.Nombre);
            }
        }

        private static bool eliminarEscuelaArbitro()
        {
            bool funciono=_repoescuelaarbitro.EliminarEscuelaArbitro(5);
            if (funciono)
                {
                Console.WriteLine("Escuela-Arbitro eliminado con exito.");
                }
                else
                {
                Console.WriteLine("Se ha presentado una falla en el proceso.");
                }
            return funciono;
        }

        private static bool actualizarEscuelaArbitro()
        {
            var escuelaarbitro = new EscuelaArbitro
            {
                id=4,
                Nombre="Armenia"
            };
            bool funciono =_repoescuelaarbitro.ActualizarEscuelaArbitro(escuelaarbitro);

            if (funciono)
            {
                Console.WriteLine("EscuelaArbitro actualizado con exito.");
                Console.WriteLine("Lista actualizada");
                listarEscuelaArbitros();

            }
            else
            {
                Console.WriteLine("Se ha presentado una falla en el proceso.");
            }


            return funciono;
        }

        private static void buscarEscuelaArbitro()
        {
            var esc= _repoescuelaarbitro.BuscarEscuelaArbitro(2);
            if (esc!=null)
            {
                Console.WriteLine("Escuela-Arbitro encontrado.");
                Console.WriteLine(esc.id+" "+esc.Nombre);
            }
            else
            {
                Console.WriteLine("Escuela-Arbitro no encontrado.");
                
            }
        }

        //-------------------------------------------------------

        //CREAR TORNEO

        private static void crearTorneo()
        {
            var torneo= new Torneo
            {
                Nombre = "Jose",
            };

            bool funciono= _repotorneo.CrearTorneo(torneo);

            if (funciono)
            {
            Console.WriteLine("Torneo adicionado con exito.");
            }
                else
            {
            Console.WriteLine("Se ha presentado una falla en el proceso.");
            }

        }

        private static void listarTorneos()
        {
            IEnumerable<Torneo> torneos=_repotorneo.ListarTorneos();
            foreach (var tor in torneos)
            {
                Console.WriteLine(tor.id+" "+tor.Nombre);
            }
        }

        private static bool eliminarTorneo()
        {
            bool funciono=_repotorneo.EliminarTorneo(5);
            if (funciono)
                {
                Console.WriteLine("Torneo eliminado con exito.");
                }
                else
                {
                Console.WriteLine("Se ha presentado una falla en el proceso.");
                }
            return funciono;
        }

        private static bool actualizarTorneo()
        {
            var torneo = new Torneo
            {
                id=4,
                Nombre="Armenia"
            };
            bool funciono =_repotorneo.ActualizarTorneo(torneo);

            if (funciono)
            {
                Console.WriteLine("Torneo actualizado con exito.");
                Console.WriteLine("Lista actualizada");
                listarTorneos();

            }
            else
            {
                Console.WriteLine("Se ha presentado una falla en el proceso.");
            }


            return funciono;
        }

        private static void buscarTorneo()
        {
            var tor= _repotorneo.BuscarTorneo(2);
            if (tor!=null)
            {
                Console.WriteLine("Torneo encontrado.");
                Console.WriteLine(tor.id+" "+tor.Nombre);
            }
            else
            {
                Console.WriteLine("Torneo no encontrado.");
                
            }
        }

        //-------------------------------------------------------

        //CREAR TORNEO-EQUIPO

        private static void crearTorneoEquipo()
        {
            var torneoEquipo= new TorneoEquipo
            {
                
            };

            bool funciono= _repotorneoequipo.CrearTorneoEquipo(torneoEquipo);

            if (funciono)
            {
            Console.WriteLine("Torneo-Equipo adicionado con exito.");
            }
                else
            {
            Console.WriteLine("Se ha presentado una falla en el proceso.");
            }

        }

        private static void listarTorneoEquipos()
        {
            IEnumerable<TorneoEquipo> torneoequipo=_repotorneoequipo.ListarTorneoEquipos();
            foreach (var tor in torneoequipo)
            {
                Console.WriteLine("");
            }
        }

        private static bool eliminarTorneoEquipo()
        {
            bool funciono=_repotorneoequipo.EliminarTorneoEquipo(5);
            if (funciono)
                {
                Console.WriteLine("Torneo-Equipo eliminado con exito.");
                }
                else
                {
                Console.WriteLine("Se ha presentado una falla en el proceso.");
                }
            return funciono;
        }

        private static bool actualizarTorneoEquipo()
        {
            var torneoequipo = new TorneoEquipo
            {
                
            };
            bool funciono =_repotorneoequipo.ActualizarTorneoEquipo(torneoequipo);

            if (funciono)
            {
                Console.WriteLine("Torneo-Equipo actualizado con exito.");
                Console.WriteLine("Lista actualizada");
                listarTorneoEquipos();

            }
            else
            {
                Console.WriteLine("Se ha presentado una falla en el proceso.");
            }


            return funciono;
        }

        private static void buscarTorneoEquipo()
        {
            var tor= _repotorneoequipo.BuscarTorneoEquipo(2);
            if (tor!=null)
            {
                Console.WriteLine("TorneoEquipo encontrado.");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("TorneoEquipo no encontrado.");
                
            }
        }

        //-------------------------------------------------------



        // CRUD MUNICIPIO

        private static void crearMunicipio()
        {
            var municipio= new Municipio
            {
                Nombre = "Ibague"
            };
            bool funciono= _repomunicipio.CrearMunicipio(municipio);

            if (funciono)
            {
            Console.WriteLine("Municipio adicionado con exito.");
            }
                else
            {
            Console.WriteLine("Se ha presentado una falla en el proceso.");
            }

        }

    
        private static void listarMunicipios()
        {
            IEnumerable<Municipio> municipios=_repomunicipio.ListarMunicipios();
            foreach (var mun in municipios)
            {
                Console.WriteLine(mun.id+" "+mun.Nombre);
            }
        }

    
        private static bool eliminarMunicipio()
        {
            bool funciono=_repomunicipio.EliminarMunicipio(6);
            if (funciono)
                {
                Console.WriteLine("Municipio eliminado con exito.");
                }
                else
                {
                Console.WriteLine("Se ha presentado una falla en el proceso.");
                }
            return funciono;
        }

    
        private static bool actualizarMunicipio()
        {
            var municipio = new Municipio
            {
                id=4,
                Nombre="Armenia"
            };
            bool funciono =_repomunicipio.ActualizarMunicipio(municipio);

            if (funciono)
            {
                Console.WriteLine("Municipio actualizado con exito.");
                Console.WriteLine("Lista actualizada");
                listarMunicipios();

            }
            else
            {
                Console.WriteLine("Se ha presentado una falla en el proceso.");
            }


            return funciono;
        }

        private static void buscarMunicipio()
        {
            var mun= _repomunicipio.BuscarMunicipio(2);
            if (mun!=null)
            {
                Console.WriteLine("Municipio encontrado.");
                Console.WriteLine(mun.id+" "+mun.Nombre);
            }
            else
            {
                Console.WriteLine("Municipio no encontrado.");
                
            }
        }

        //-------------------------------------------------------

        // CRUD PATROCINADOR

        private static void crearPatrocinador()
        {
            var patrocinador= new Patrocinador
            {
                Identificacion="104",
                Nombre = "WPlay",
                tipoPersona="Juridica",
                Direccion="calle 5",
                Telefono="31004"
            };
            bool funciono= _repopatrocinador.CrearPatrocinador(patrocinador);

            if (funciono)
            {
            Console.WriteLine("Patrocinador adicionado con exito.");
            }
                else
            {
            Console.WriteLine("Se ha presentado una falla en el proceso.");
            }

        }

    
        private static void listarPatrocinadores()
        {
            IEnumerable<Patrocinador> patrocinadores=_repopatrocinador.ListarPatrocinadores();
            foreach (var pat in patrocinadores)
            {
                Console.WriteLine(pat.id+" "+pat.Nombre);
            }
        }

    
        private static bool eliminarPatrocinador()
        {
            bool funciono=_repopatrocinador.EliminarPatrocinador(4);
            if (funciono)
                {
                Console.WriteLine("Patrocinador eliminado con exito.");
                }
                else
                {
                Console.WriteLine("Se ha presentado una falla en el proceso.");
                }
            return funciono;
        }

    
        private static bool actualizarPatrocinador()
        {
            var patrocinador = new Patrocinador
            {
                id=3,
                Identificacion="100",
                Nombre = "BetPlay",
                tipoPersona="Juridica",
                Direccion="calle 1",
                Telefono="31000"
            };
            bool funciono =_repopatrocinador.ActualizarPatrocinador(patrocinador);

            if (funciono)
            {
                Console.WriteLine("Patrocinador actualizado con exito.");
                Console.WriteLine("Lista actualizada");
                listarPatrocinadores();

            }
            else
            {
                Console.WriteLine("Se ha presentado una falla en el proceso.");
            }


            return funciono;
        }

        private static void buscarPatrocinador()
        {
            var pat= _repopatrocinador.BuscarPatrocinador(4);
            if (pat!=null)
            {
                Console.WriteLine("Patrocinador encontrado.");
                Console.WriteLine(pat.id+" "+pat.Nombre);
            }
            else
            {
                Console.WriteLine("Patrocinador no encontrado.");
                
            }
        }

        //-------------------------------------------------------


        private static void ingresarDatos()
        {
            string nombre ="";
            Console.WriteLine("Ingrese el nombre del municipio que desea crear");
            nombre= Console.ReadLine();
            var municipio = new Municipio
            {
               Nombre = nombre
            };
            bool funciono = _repomunicipio.CrearMunicipio(municipio);
            if (funciono)
            {
                Console.WriteLine("Municipio adicionado con exito.");
            }
            else
            {
                Console.WriteLine("Se ha presentado una falla en el proceso.");
            }
        }

    }
}
