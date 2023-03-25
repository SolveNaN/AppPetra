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
        public DbSet<VariableProceso> VariableProcesos { get; set; }
        public DbSet<Prueba> Pruebas { get; set; }
        public DbSet<Alarma> Alarmas { get; set; }
        public DbSet<Registro> Registros { get; set; }
        public DbSet<TipoMovimiento> Movimientos { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Guia> Guias { get; set; }
        public DbSet<Sello> Sellos { get; set; }
        public DbSet<FormatoCarga> FormatoCarroTanquesCargados { get; set; }
        public DbSet<OfertaDiaria> OfertaDiariaProgramacionCarrotanques { get; set; }
        public DbSet<CarroTanque> CarroTanques { get; set; }
        public DbSet<Operario> Operarios { get; set; }
        public DbSet<Destino> Destinos { get; set; }

    }

    
}
