public partial class AddRatingMig : DbMigration
{
    public override void Up()
    {
        AddColumn("dbo.Movies", "Rating", c => c.String());
    }
    
    public override void Down()
    {
        DropColumn("dbo.Movies", "Rating");
    }
}