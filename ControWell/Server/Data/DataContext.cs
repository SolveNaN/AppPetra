namespace ControWell.Server.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pozo>().HasData(
                new Pozo
                {
                    Id = 1,
                    NombrePozo = "CH-245 B",
                    Ubicacion = "Chichimene",
                    Operadora = "Ecopetrol",
                    Comentario = "Pozo en produccion"
                },

        new Pozo
        {
            Id = 2,
            NombrePozo = "CH-215 A2",
            Ubicacion = "Chichimene",
            Operadora = "Halliburton",
            Comentario = "Pozo en suspendido"
        },

        new Pozo
        {
            Id = 3,
            NombrePozo = "CH-98",
            Ubicacion = "Chichimene",
            Operadora = "Ecopetrol",
            Comentario = "Pozo en pruebas extensas"
        }
                );


            modelBuilder.Entity<Tanque>().HasData(

                new Tanque
                {
                    Id = 1,
                    NombreTanque = "TK-915 NF",
                    Capacidad = "1000",
                    TipoFluido = "Nafta"

                },

                new Tanque
                {
                    Id = 2,
                    NombreTanque = "TK-98 OL",
                    Capacidad = "2000",
                    TipoFluido = "Petroleo"

                },

                new Tanque
                {
                    Id = 3,
                    NombreTanque = "TK-103 WT",
                    Capacidad = "1000",
                    TipoFluido = "Agua"

                }
                );

            modelBuilder.Entity<AforoTK>().HasData(

               new AforoTK
               {
                   Id = 1,
                   TanqueId=2,
                   Nivel = 100,
                   Volunen = 1000,
                   TempBase = 120,
                   Material = "acero"

               }
                          
               
               );


            modelBuilder.Entity<Usuario>().HasData(

                new Usuario
                {
                Id = 1,
                Cedula = 1002,
                Nombre = "Dagoberto",
                Apellido = "Sanchez",
                Cargo = "Inpector de medicion",
                TipoAcceso = 1


            },
            new Usuario
            {
                Id = 2,
                Cedula = 1245,
                Nombre = "Angelo",
                Apellido = "Rojas",
                Cargo = "Gefe de personal",
                TipoAcceso = 2

            },
            new Usuario
            {
                Id = 3,
                Cedula = 850014,
                Nombre = "Fabian",
                Apellido = "Morales",
                Cargo = "Lider de medicion",
                TipoAcceso = 3

            }


              );
            modelBuilder.Entity<Comic>().HasData(
                 new Comic { Id = 1, Name = "Marvel" },
                 new Comic { Id = 2, Name = "DC" }
                );
            modelBuilder.Entity<SuperHero>().HasData(
                new SuperHero
                {
                    Id = 1,
                    FirstName = "Peter",
                    LastName = "Parker",
                    HeroName = "Spiderman",                    
                    ComicId = 1
                },
            new SuperHero
            {
                Id = 2,
                FirstName = "Bruce",
                LastName = "Wayne",
                HeroName = "Batman",                
                ComicId = 2
            }
               );
            modelBuilder.Entity<VariableProceso>().HasData(
                
                new VariableProceso
                {
                    Id = 1,
                    Nombre="Presion Cabeza",
                    Unidad="psia"
                }

                );

            modelBuilder.Entity<Prueba>().HasData(
                new Prueba
                {
                    Id = 1,
                    Nombre="Autorizado"
                }
                
                );
            modelBuilder.Entity<Alarma>().HasData(
                new Alarma
                {
                    Id = 1,
                    PozoId= 1,
                    VariableProcesoId= 2,
                    Max=500,
                    Min=30,
                }
                );
            modelBuilder.Entity<Registro>().HasData(
                new Registro
                {
                    Id= 1,
                    
                    PozoId = 1,
                    VariableProcesoId= 2,
                    Medida= 45
                }
                );
        }
        public DbSet<Pozo> Pozos { get; set; }
        public DbSet<Tanque> Tanques { get; set; }
        public DbSet<AforoTK> AforoTKs { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<Comic> Comics { get; set; }
        public DbSet<VariableProceso> VariableProcesos { get; set; }
        public DbSet<Prueba> Pruebas { get; set; }
        public DbSet<Alarma> Alarmas { get; set; }
        public DbSet<Registro> Registros { get; set; }
        public DbSet<TipoMovimiento> Movimientos { get; set; }
        public DbSet<Balance> Balances { get; set; }
    }

    
}
