namespace magnets.repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v110 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_LABORATORIO",
                c => new
                    {
                        ID_LAB = c.Int(nullable: false, identity: true),
                        NM_LAB = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID_LAB);
            
            CreateTable(
                "dbo.TB_NPS",
                c => new
                    {
                        ID_NPS = c.Int(nullable: false, identity: true),
                        NR_FAP = c.String(nullable: false, maxLength: 12),
                        NR_ATENDIMENTO_NOTA = c.String(nullable: false),
                        NR_INSTALACAO_NOTA = c.String(nullable: false),
                        NR_RECOMENCADAO_NOTA = c.String(nullable: false),
                        DS_AVALIACAO = c.String(),
                        DataAvaliacao = c.DateTime(nullable: false),
                        NR_CELULAR = c.String(nullable: false),
                        ID_LAB = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_NPS)
                .ForeignKey("dbo.TB_LABORATORIO", t => t.ID_LAB, cascadeDelete: true)
                .Index(t => t.ID_LAB);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_NPS", "ID_LAB", "dbo.TB_LABORATORIO");
            DropIndex("dbo.TB_NPS", new[] { "ID_LAB" });
            DropTable("dbo.TB_NPS");
            DropTable("dbo.TB_LABORATORIO");
        }
    }
}
