using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using ContosoBooks.Models;

namespace ContosoBooks.Migrations
{
    [ContextType(typeof(BookContext))]
    partial class BookContextModelSnapshot : ModelSnapshot
    {
        public override IModel Model
        {
            get
            {
                var builder = new BasicModelBuilder()
                    .Annotation("SqlServer:ValueGeneration", "Sequence");
                
                builder.Entity("ContosoBooks.Models.Author", b =>
                    {
                        b.Property<int>("AuthorID")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 0)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("FirstMidName")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<string>("LastName")
                            .Annotation("OriginalValueIndex", 2);
                        b.Key("AuthorID");
                    });
                
                builder.Entity("ContosoBooks.Models.Book", b =>
                    {
                        b.Property<int>("AuthorID")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<int>("BookID")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 1)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("Genre")
                            .Annotation("OriginalValueIndex", 2);
                        b.Property<decimal>("Price")
                            .Annotation("OriginalValueIndex", 3);
                        b.Property<string>("Title")
                            .Annotation("OriginalValueIndex", 4);
                        b.Property<int>("Year")
                            .Annotation("OriginalValueIndex", 5);
                        b.Key("BookID");
                    });
                
                builder.Entity("ContosoBooks.Models.Book", b =>
                    {
                        b.ForeignKey("ContosoBooks.Models.Author", "AuthorID");
                    });
                
                return builder.Model;
            }
        }
    }
}
