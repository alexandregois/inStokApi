using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace inStok.Models;

public partial class InStockContext : DbContext
{
    public InStockContext()
    {
    }

    public InStockContext(DbContextOptions<InStockContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ajudum> Ajuda { get; set; }

    public virtual DbSet<Anuncio> Anuncios { get; set; }

    public virtual DbSet<Aula> Aulas { get; set; }

    public virtual DbSet<CategoriaTrilha> CategoriaTrilhas { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<FormaPagamento> FormaPagamentos { get; set; }

    public virtual DbSet<Frequencium> Frequencia { get; set; }

    public virtual DbSet<HistoricoAula> HistoricoAulas { get; set; }

    public virtual DbSet<HistoricoFrequencium> HistoricoFrequencia { get; set; }

    public virtual DbSet<Imagem> Imagems { get; set; }

    public virtual DbSet<ImagemPostagem> ImagemPostagems { get; set; }

    public virtual DbSet<Lembrete> Lembretes { get; set; }

    public virtual DbSet<Mentalizacao> Mentalizacaos { get; set; }

    public virtual DbSet<Modulo> Modulos { get; set; }

    public virtual DbSet<MuralSonho> MuralSonhos { get; set; }

    public virtual DbSet<Notificacao> Notificacaos { get; set; }

    public virtual DbSet<Pagamento> Pagamentos { get; set; }

    public virtual DbSet<Postagem> Postagems { get; set; }

    public virtual DbSet<PostagemCategorium> PostagemCategoria { get; set; }

    public virtual DbSet<Sexo> Sexos { get; set; }

    public virtual DbSet<Trilha> Trilhas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=207.180.246.227;Initial Catalog=inStock;Persist Security Info=False;User ID=instok_user;Password=220101;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ajudum>(entity =>
        {
            entity.HasKey(e => e.AjudaId).HasName("PK__Ajuda__FB3479763AB97F8F");

            entity.Property(e => e.AjudaId).HasColumnName("AjudaID");
            entity.Property(e => e.Titulo).HasMaxLength(100);
        });

        modelBuilder.Entity<Anuncio>(entity =>
        {
            entity.HasKey(e => e.AnuncioId).HasName("PK__Anuncio__155DE72C034E4AFB");

            entity.ToTable("Anuncio");

            entity.Property(e => e.AnuncioId).HasColumnName("AnuncioID");
            entity.Property(e => e.Descricao).HasMaxLength(500);
            entity.Property(e => e.Titulo).HasMaxLength(100);
        });

        modelBuilder.Entity<Aula>(entity =>
        {
            entity.HasKey(e => e.AulaId).HasName("PK__Aula__A8529A186C6F5AE3");

            entity.ToTable("Aula");

            entity.Property(e => e.AulaId).HasColumnName("AulaID");
            entity.Property(e => e.ModuloId).HasColumnName("ModuloID");
            entity.Property(e => e.Titulo).HasMaxLength(100);

            entity.HasOne(d => d.Modulo).WithMany(p => p.Aulas)
                .HasForeignKey(d => d.ModuloId)
                .HasConstraintName("FK__Aula__ModuloID__3B75D760");
        });

        modelBuilder.Entity<CategoriaTrilha>(entity =>
        {
            entity.HasKey(e => e.CategoriaTrilhaId).HasName("PK__Categori__F39E7A40715C0837");

            entity.ToTable("CategoriaTrilha");

            entity.Property(e => e.CategoriaTrilhaId).HasColumnName("CategoriaTrilhaID");
            entity.Property(e => e.Nome).HasMaxLength(100);
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__F353C1C571624542");

            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.Descricao).HasMaxLength(255);
            entity.Property(e => e.Nome).HasMaxLength(100);
        });

        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.ComentarioId).HasName("PK__Comentar__F18449582D94C07C");

            entity.ToTable("Comentario");

            entity.Property(e => e.ComentarioId).HasColumnName("ComentarioID");
            entity.Property(e => e.DataComentario)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PostagemId).HasColumnName("PostagemID");
            entity.Property(e => e.Texto).HasMaxLength(500);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Postagem).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.PostagemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comentari__Posta__173876EA");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comentari__Usuar__182C9B23");
        });

        modelBuilder.Entity<FormaPagamento>(entity =>
        {
            entity.HasKey(e => e.FormaPagamentoId).HasName("PK__FormaPag__3FBCDE664D9B236F");

            entity.ToTable("FormaPagamento");

            entity.Property(e => e.FormaPagamentoId).HasColumnName("FormaPagamentoID");
            entity.Property(e => e.Descricao).HasMaxLength(100);
        });

        modelBuilder.Entity<Frequencium>(entity =>
        {
            entity.HasKey(e => e.FrequenciaId).HasName("PK__Frequenc__A668E35AC7E686DB");

            entity.Property(e => e.FrequenciaId).HasColumnName("FrequenciaID");
            entity.Property(e => e.Audio).HasMaxLength(255);
            entity.Property(e => e.Titulo).HasMaxLength(100);
        });

        modelBuilder.Entity<HistoricoAula>(entity =>
        {
            entity.HasKey(e => e.HistoricoAulaId).HasName("PK__Historic__4A561D76C15AD13D");

            entity.ToTable("HistoricoAula");

            entity.Property(e => e.HistoricoAulaId).HasColumnName("HistoricoAulaID");
            entity.Property(e => e.AulaId).HasColumnName("AulaID");
            entity.Property(e => e.DataVisualizacao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.HistoricoId).HasColumnName("HistoricoID");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Aula).WithMany(p => p.HistoricoAulas)
                .HasForeignKey(d => d.AulaId)
                .HasConstraintName("FK__Historico__AulaI__403A8C7D");

            entity.HasOne(d => d.Usuario).WithMany(p => p.HistoricoAulas)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Historico__Usuar__3F466844");
        });

        modelBuilder.Entity<HistoricoFrequencium>(entity =>
        {
            entity.HasKey(e => e.HistoricoFrequanciaId).HasName("PK__Historic__4A561D763222FB45");

            entity.Property(e => e.HistoricoFrequanciaId).HasColumnName("HistoricoFrequanciaID");
            entity.Property(e => e.DataOuvida)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FrequenciaId).HasColumnName("FrequenciaID");
            entity.Property(e => e.HistoricoId).HasColumnName("HistoricoID");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Frequencia).WithMany(p => p.HistoricoFrequencia)
                .HasForeignKey(d => d.FrequenciaId)
                .HasConstraintName("FK__Historico__Frequ__571DF1D5");

            entity.HasOne(d => d.Usuario).WithMany(p => p.HistoricoFrequencia)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Historico__Usuar__5629CD9C");
        });

        modelBuilder.Entity<Imagem>(entity =>
        {
            entity.HasKey(e => e.ImagemId).HasName("PK__Imagem__0CBF2ACE12A006BD");

            entity.ToTable("Imagem");

            entity.Property(e => e.ImagemId).HasColumnName("ImagemID");
            entity.Property(e => e.Imagem1).HasColumnName("Imagem");
            entity.Property(e => e.PostagemId).HasColumnName("PostagemID");

            entity.HasOne(d => d.Postagem).WithMany(p => p.Imagems)
                .HasForeignKey(d => d.PostagemId)
                .HasConstraintName("FK__Imagem__Postagem__2C3393D0");
        });

        modelBuilder.Entity<ImagemPostagem>(entity =>
        {
            entity.HasKey(e => e.ImagemPostagemId).HasName("PK__ImagemPo__2B2CE0A4FAF4A624");

            entity.ToTable("ImagemPostagem");

            entity.Property(e => e.ImagemPostagemId).HasColumnName("ImagemPostagemID");
            entity.Property(e => e.PostagemId).HasColumnName("PostagemID");

            entity.HasOne(d => d.Postagem).WithMany(p => p.ImagemPostagems)
                .HasForeignKey(d => d.PostagemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ImagemPos__Posta__1DE57479");
        });

        modelBuilder.Entity<Lembrete>(entity =>
        {
            entity.HasKey(e => e.LembreteId).HasName("PK__Lembrete__0EF7F7CA078C70C0");

            entity.ToTable("Lembrete");

            entity.Property(e => e.LembreteId).HasColumnName("LembreteID");
            entity.Property(e => e.DataLembrete).HasColumnType("datetime");
            entity.Property(e => e.Descricao).HasMaxLength(500);
            entity.Property(e => e.Titulo).HasMaxLength(100);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Lembretes)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Lembrete__Usuari__1B0907CE");
        });

        modelBuilder.Entity<Mentalizacao>(entity =>
        {
            entity.HasKey(e => e.MentalizacaoId).HasName("PK__Mentaliz__B43C9B6087634301");

            entity.ToTable("Mentalizacao");

            entity.Property(e => e.MentalizacaoId).HasColumnName("MentalizacaoID");
            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.DataCriacao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Descricao).HasMaxLength(255);
            entity.Property(e => e.Titulo).HasMaxLength(100);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Mentalizacaos)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("FK__Mentaliza__Categ__5070F446");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Mentalizacaos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Mentaliza__Usuar__4F7CD00D");
        });

        modelBuilder.Entity<Modulo>(entity =>
        {
            entity.HasKey(e => e.ModuloId).HasName("PK__Modulo__26CEB88FF9639F07");

            entity.ToTable("Modulo");

            entity.Property(e => e.ModuloId).HasColumnName("ModuloID");
            entity.Property(e => e.Descricao).HasMaxLength(255);
            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.TrilhaId).HasColumnName("TrilhaID");

            entity.HasOne(d => d.Trilha).WithMany(p => p.Modulos)
                .HasForeignKey(d => d.TrilhaId)
                .HasConstraintName("FK__Modulo__TrilhaID__38996AB5");
        });

        modelBuilder.Entity<MuralSonho>(entity =>
        {
            entity.HasKey(e => e.MuralId).HasName("PK__MuralSon__A89F4E7052A749FF");

            entity.Property(e => e.MuralId).HasColumnName("MuralID");
            entity.Property(e => e.Descricao).HasMaxLength(255);
            entity.Property(e => e.Imagem).HasMaxLength(255);
            entity.Property(e => e.Titulo).HasMaxLength(100);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.MuralSonhos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__MuralSonh__Usuar__59FA5E80");
        });

        modelBuilder.Entity<Notificacao>(entity =>
        {
            entity.HasKey(e => e.NotificacaoId).HasName("PK__Notifica__FB9B785CEDFFAC9A");

            entity.ToTable("Notificacao");

            entity.Property(e => e.NotificacaoId).HasColumnName("NotificacaoID");
            entity.Property(e => e.DataNotificacao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Mensagem).HasMaxLength(255);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Notificacaos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificac__Usuar__22AA2996");
        });

        modelBuilder.Entity<Pagamento>(entity =>
        {
            entity.HasKey(e => e.PagamentoId).HasName("PK__Pagament__977DE7D375EEE71E");

            entity.ToTable("Pagamento");

            entity.Property(e => e.PagamentoId).HasColumnName("PagamentoID");
            entity.Property(e => e.DataPagamento).HasColumnType("datetime");
            entity.Property(e => e.FormaPagamentoId).HasColumnName("FormaPagamentoID");
            entity.Property(e => e.TrilhaId).HasColumnName("TrilhaID");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.ValorPago).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.FormaPagamento).WithMany(p => p.Pagamentos)
                .HasForeignKey(d => d.FormaPagamentoId)
                .HasConstraintName("FK__Pagamento__Forma__4BAC3F29");

            entity.HasOne(d => d.Trilha).WithMany(p => p.Pagamentos)
                .HasForeignKey(d => d.TrilhaId)
                .HasConstraintName("FK__Pagamento__Trilh__4AB81AF0");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Pagamentos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Pagamento__Usuar__49C3F6B7");
        });

        modelBuilder.Entity<Postagem>(entity =>
        {
            entity.HasKey(e => e.PostagemId).HasName("PK__Postagem__AF36279CD49D2069");

            entity.ToTable("Postagem");

            entity.Property(e => e.PostagemId).HasColumnName("PostagemID");
            entity.Property(e => e.DataPublicacao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Postagems)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Postagem__Usuari__1367E606");
        });

        modelBuilder.Entity<PostagemCategorium>(entity =>
        {
            entity.HasKey(e => e.PostagemCategoriaId);

            entity.Property(e => e.PostagemCategoriaId).HasColumnName("PostagemCategoriaID");
            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.PostagemId).HasColumnName("PostagemID");

            entity.HasOne(d => d.Categoria).WithMany(p => p.PostagemCategoria)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostagemC__Categ__32E0915F");

            entity.HasOne(d => d.Postagem).WithMany(p => p.PostagemCategoria)
                .HasForeignKey(d => d.PostagemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostagemC__Posta__31EC6D26");
        });

        modelBuilder.Entity<Sexo>(entity =>
        {
            entity.ToTable("Sexo");

            entity.Property(e => e.SexoId).HasColumnName("SexoID");
            entity.Property(e => e.NomeSexo)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Trilha>(entity =>
        {
            entity.HasKey(e => e.TrilhaId).HasName("PK__Trilha__7242D1763E9F4E93");

            entity.ToTable("Trilha");

            entity.Property(e => e.TrilhaId).HasColumnName("TrilhaID");
            entity.Property(e => e.CategoriaTrilhaId).HasColumnName("CategoriaTrilhaID");
            entity.Property(e => e.Descricao).HasMaxLength(255);
            entity.Property(e => e.Egratuita).HasColumnName("EGratuita");
            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE7984E07E1DB");

            entity.ToTable("Usuario");

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Apelido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DataNascimento).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.Senha).HasMaxLength(255);
            entity.Property(e => e.SexoId).HasColumnName("SexoID");
            entity.Property(e => e.Sobrenome).HasMaxLength(100);
            entity.Property(e => e.Telefone).HasMaxLength(50);

            entity.HasOne(d => d.Sexo).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.SexoId)
                .HasConstraintName("FK_Usuario_Sexo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
