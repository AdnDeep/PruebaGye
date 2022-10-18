using System;
using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace eMAS.Api.TerrenosComodatos.Data
{
    public partial class COMODATOContext : DbContext
    {
        public COMODATOContext()
        {
        }

        public COMODATOContext(DbContextOptions<COMODATOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SmcAnexoTramite> SmcAnexoTramites { get; set; }
        public virtual DbSet<SmcBeneficiario> SmcBeneficiarios { get; set; }
        public virtual DbSet<SmcBeneficiarioEdit> SmcBeneficiariosEdit { get; set; }
        public virtual DbSet<SmcBeneficiarioPaginado> SmcBeneficiariosPaginado { get; set; }
        public virtual DbSet<SmcDireccion> SmcDireccions { get; set; }
        public virtual DbSet<SmcEstadoTramite> SmcEstadoTramites { get; set; }
        public virtual DbSet<SmcMigraExcel> SmcMigraExcels { get; set; }
        public virtual DbSet<SmcOficioOtrasDireccione> SmcOficioOtrasDirecciones { get; set; }
        public virtual DbSet<SmcTipoContrato> SmcTipoContratos { get; set; }
        public virtual DbSet<SmcTipoTopografiaTerreno> SmcTipoTopografiaTerrenos { get; set; }
        public virtual DbSet<SmcTopografiaTerreno> SmcTopografiaTerrenos { get; set; }
        public virtual DbSet<SmcTramite> SmcTramites { get; set; }
        public virtual DbSet<SmcTramiteEdit> SmcTramitesEdit { get; set; }
        public virtual DbSet<SmcAnexoTramiteEdit> SmcAnexoTramitesEdit { get; set; }
        public virtual DbSet<SmcTramitesDescEdit> SmcTramitesDescsEdit { get; set; }
        public virtual DbSet<SmcTopografiaTerrenoEdit> SmcTopografiaTerrenosEdit { get; set; }
        public virtual DbSet<SmcOficioOtrasDireccioneEdit> SmcOficioOtrasDireccionesEdit { get; set; }
        public virtual DbSet<SmcTramitePaginado> SmcTramitesPaginado { get; set; }
        public virtual DbSet<SmcTramitesDesc> SmcTramitesDescs { get; set; }
        public virtual DbSet<KeyValueSelect> KeyValueSelects { get; set; }
        public virtual DbSet<ExportSingle> ExportsSingle { get; set; }
        public virtual DbSet<SmcValidacionEscritura> SmcValidacionsEscritura { get; set; }    
        public virtual DbSet<SmcValidaDataServidor> SmcValidaDatasServidor { get; set; }
        public virtual DbSet<SmcCatalogoConfiguracion> SmcCatalogosConfiguracion { get; set; }
        public virtual DbSet<SmcNotificacionPendiente> SmcNotificacionPendientes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {optionsBuilder.UseSqlServer("Name=ContextoComodatos");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_100_BIN");

            modelBuilder.Entity<SmcAnexoTramite>(entity =>
            {
                entity.HasKey(e => e.IdAnexoTramite)
                    .HasName("PK__SmcAnexo__AB09BD71B186515F");

                entity.ToTable("SmcAnexoTramite");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.PdpFechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.PdpFechaUltimaModificacion).HasColumnType("datetime");

                entity.Property(e => e.PdpUltimaPcCliente)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUltimaTransaccion)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUsuarioUltimaModificacion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTramiteNavigation)
                    .WithMany(p => p.SmcAnexoTramites)
                    .HasForeignKey(d => d.IdTramite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SmcAnexoT__IdTra__6B24EA82");
            });

            modelBuilder.Entity<SmcBeneficiario>(entity =>
            {
                entity.HasKey(e => e.IdBeneficiario)
                    .HasName("PK__SmcBenef__3D23355F2C830E46");

                entity.ToTable("SmcBeneficiario");

                entity.Property(e => e.Contacto)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NombreRepresentante)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PdpFechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.PdpFechaUltimaModificacion).HasColumnType("datetime");

                entity.Property(e => e.PdpUltimaPcCliente)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUltimaTransaccion)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUsuarioUltimaModificacion)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SmcDireccion>(entity =>
            {
                entity.HasKey(e => e.IdDireccion)
                    .HasName("PK__SmcDirec__1F8E0C760F640E8B");

                entity.ToTable("SmcDireccion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.PdpFechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.PdpFechaUltimaModificacion).HasColumnType("datetime");

                entity.Property(e => e.PdpUltimaPcCliente)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUltimaTransaccion)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUsuarioUltimaModificacion)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SmcEstadoTramite>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__SmcEstad__FBB0EDC1C458FC7D");

                entity.ToTable("SmcEstadoTramite");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PdpFechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.PdpFechaUltimaModificacion).HasColumnType("datetime");

                entity.Property(e => e.PdpUltimaPcCliente)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUltimaTransaccion)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUsuarioUltimaModificacion)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SmcMigraExcel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SmcMigraExcel");

                entity.Property(e => e.Aniosplazo)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ANIOSPLAZO");

                entity.Property(e => e.Aprobacionconcejo)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("APROBACIONCONCEJO");

                entity.Property(e => e.Aprobacionconcejomunicipal)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("APROBACIONCONCEJOMUNICIPAL");

                entity.Property(e => e.Beneficiario)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("BENEFICIARIO");

                entity.Property(e => e.Column6)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Column7)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.D)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DtcyD2019)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DTCyD2019");

                entity.Property(e => e.DtcyD2020)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DTCyD2020");

                entity.Property(e => e.DtcyD2021)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DTCyD2021");

                entity.Property(e => e.Escritura)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ESCRITURA");

                entity.Property(e => e.Estado)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ESTADO");

                entity.Property(e => e.Fechadeinscripcionderevocatorias)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("FECHADEINSCRIPCIONDEREVOCATORIAS");

                entity.Property(e => e.Fechaescritura)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("FECHAESCRITURA");

                entity.Property(e => e.Fechainscripcionregpropiedad)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("FECHAINSCRIPCIONREGPROPIEDAD");

                entity.Property(e => e.Inspeccion2017)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("INSPECCION2017");

                entity.Property(e => e.Inspeccion2018)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("INSPECCION2018");

                entity.Property(e => e.Inspeccion2019)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName(" INSPECCION2019");

                entity.Property(e => e.Inspeccion2020)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("INSPECCION2020");

                entity.Property(e => e.Inspeccion2021)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("INSPECCION2021");

                entity.Property(e => e.Matricula)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MATRICULA");

                entity.Property(e => e.Metros)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("METROS");

                entity.Property(e => e.Modificacionampliacrectif)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MODIFICACIONAMPLIACRECTIF");

                entity.Property(e => e.Mz)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MZ");

                entity.Property(e => e.N)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Notaria)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NOTARIA");

                entity.Property(e => e.Observacion1)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("OBSERVACION1");

                entity.Property(e => e.Observacion2)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("OBSERVACION2");

                entity.Property(e => e.Observacion3)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("OBSERVACION3");

                entity.Property(e => e.Observacion4)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("OBSERVACION4");

                entity.Property(e => e.Observacion5)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("OBSERVACION5");

                entity.Property(e => e.Observacionmodif)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("OBSERVACIONMODIF");

                entity.Property(e => e.Oficiodt2017)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("OFICIODT2017");

                entity.Property(e => e.Oficiodt2018)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("OFICIODT2018");

                entity.Property(e => e.Oficiorevocatoriamodificacion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("OFICIOREVOCATORIAMODIFICACION ");

                entity.Property(e => e.S)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Sector)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("SECTOR");

                entity.Property(e => e.Subidoenelsistema)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("SUBIDOENELSISTEMA");

                entity.Property(e => e.Tipodecontrato)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TIPODECONTRATO");
            });

            modelBuilder.Entity<SmcOficioOtrasDireccione>(entity =>
            {
                entity.HasKey(e => e.IdOficioOtrasDirecciones)
                    .HasName("PK__SmcOfici__32ACA717D498C3A3");

                entity.Property(e => e.FechaEnvio).HasColumnType("datetime");

                entity.Property(e => e.FechaRespuesta).HasColumnType("datetime");

                entity.Property(e => e.Oficio)
                    .IsUnicode(false);

                entity.Property(e => e.OficioRespuesta)
                    .IsUnicode(false);

                entity.Property(e => e.PdpFechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.PdpFechaUltimaModificacion).HasColumnType("datetime");

                entity.Property(e => e.PdpUltimaPcCliente)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUltimaTransaccion)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUsuarioUltimaModificacion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                //entity.HasOne(d => d.IdDireccionNavigation)
                //    .WithMany(p => p.SmcOficioOtrasDirecciones)
                //    .HasForeignKey(d => d.IdDireccion)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__SmcOficio__IdDir__44CA3770");

                //entity.HasOne(d => d.IdTramiteNavigation)
                //    .WithMany(p => p.SmcOficioOtrasDirecciones)
                //    .HasForeignKey(d => d.IdTramite)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__SmcOficio__IdTra__43D61337");
            });

            modelBuilder.Entity<SmcTipoContrato>(entity =>
            {
                entity.HasKey(e => e.IdTipoContrato)
                    .HasName("PK__SmcTipoC__F46C49C2CA1B3C53");

                entity.ToTable("SmcTipoContrato");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.PdpFechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.PdpFechaUltimaModificacion).HasColumnType("datetime");

                entity.Property(e => e.PdpUltimaPcCliente)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUltimaTransaccion)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUsuarioUltimaModificacion)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SmcTipoTopografiaTerreno>(entity =>
            {
                entity.HasKey(e => e.IdTipoTopografiaTerreno)
                    .HasName("PK__SmcTipoT__2C02F7351A95050F");

                entity.ToTable("SmcTipoTopografiaTerreno");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PdpFechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.PdpFechaUltimaModificacion).HasColumnType("datetime");

                entity.Property(e => e.PdpUltimaPcCliente)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUltimaTransaccion)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUsuarioUltimaModificacion)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SmcTopografiaTerreno>(entity =>
            {
                entity.HasKey(e => e.IdTopografiaTerreno)
                    .HasName("PK__SmcTopog__477D8FE051C6C5A6");

                entity.ToTable("SmcTopografiaTerreno");

                entity.Property(e => e.FechaEnvio).HasColumnType("datetime");

                entity.Property(e => e.FechaRespuesta).HasColumnType("datetime");

                entity.Property(e => e.Oficio)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.OficioRespuesta)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.PdpFechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.PdpFechaUltimaModificacion).HasColumnType("datetime");

                entity.Property(e => e.PdpUltimaPcCliente)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUltimaTransaccion)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUsuarioUltimaModificacion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                //entity.HasOne(d => d.IdTipoTopografiaTerrenoNavigation)
                //    .WithMany(p => p.SmcTopografiaTerrenos)
                //    .HasForeignKey(d => d.IdTipoTopografiaTerreno)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__SmcTopogr__IdTip__40058253");

                //entity.HasOne(d => d.IdTramiteNavigation)
                //    .WithMany(p => p.SmcTopografiaTerrenos)
                //    .HasForeignKey(d => d.IdTramite)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__SmcTopogr__IdTra__40F9A68C");
            });

            modelBuilder.Entity<SmcTramite>(entity =>
            {
                entity.HasKey(e => e.IdTramite)
                    .HasName("PK__SmcTrami__8C5ABC3D39D98FA4");

                entity.Property(e => e.AniosPlazo)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.AprobacionConcejoMun)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.AreaSolar).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.BaseOrigen)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAprobConcejoMun).HasColumnType("datetime");

                entity.Property(e => e.FechaEscritura).HasColumnType("datetime");

                entity.Property(e => e.FechaInsRegProp).HasColumnType("datetime");

                entity.Property(e => e.FechaInsRevocatoria).HasColumnType("datetime");

                entity.Property(e => e.ObservacionJuridico).IsUnicode(false);

                entity.Property(e => e.OficioAg).HasMaxLength(100);

                entity.Property(e => e.OficioDase).HasMaxLength(100);

                entity.Property(e => e.OficioRevocatoriaMod)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PdpFechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.PdpFechaUltimaModificacion).HasColumnType("datetime");

                entity.Property(e => e.PdpUltimaPcCliente)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUltimaTransaccion)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUsuarioUltimaModificacion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBeneficiarioNavigation)
                    .WithMany(p => p.SmcTramites)
                    .HasForeignKey(d => d.IdBeneficiario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SmcTramit__IdBen__6754599E");

                entity.HasOne(d => d.IdDireccionNavigation)
                    .WithMany(p => p.SmcTramites)
                    .HasForeignKey(d => d.IdDireccion)
                    .HasConstraintName("FK__SmcTramit__IdDir__45BE5BA9");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.SmcTramites)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SmcTramit__IdEst__2180FB33");

                entity.HasOne(d => d.IdTipoContratoNavigation)
                    .WithMany(p => p.SmcTramites)
                    .HasForeignKey(d => d.IdTipoContrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SmcTramit__IdTip__245D67DE");
            });

            modelBuilder.Entity<SmcTramitesDesc>(entity =>
            {
                entity.HasKey(e => e.IdTramiteDesc)
                    .HasName("PK__SmcTrami__AFEE5D8BFD304AFD");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Observacion)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.PdpFechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.PdpFechaUltimaModificacion).HasColumnType("datetime");

                entity.Property(e => e.PdpUltimaPcCliente)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUltimaTransaccion)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PdpUsuarioUltimaModificacion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTramiteNavigation)
                    .WithMany(p => p.SmcTramitesDescs)
                    .HasForeignKey(d => d.IdTramite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SmcTramit__IdTra__6A30C649");
            });

            modelBuilder.Entity<SmcBeneficiarioEdit>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<SmcValidaDataServidor>(entity => 
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<SmcAnexoTramiteEdit>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<SmcTramitesDescEdit>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<SmcTopografiaTerrenoEdit>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<SmcOficioOtrasDireccioneEdit>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<SmcBeneficiarioPaginado>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<SmcTramiteEdit>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<SmcTramitePaginado>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<KeyValueSelect>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<ExportSingle>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<SmcValidacionEscritura>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<SmcCatalogoConfiguracion>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<SmcNotificacionPendiente>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.HasSequence("contacts_seq");

            modelBuilder.HasSequence<int>("TestSeq").HasMin(1);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
