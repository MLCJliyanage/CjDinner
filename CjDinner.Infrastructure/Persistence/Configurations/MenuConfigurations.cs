using CjDinner.Domain.HostAggregate.ValueObjects;
using CjDinner.Domain.MenuAggregate;
using CjDinner.Domain.MenuAggregate.Entities;
using CjDinner.Domain.MenuAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CjDinner.Infrastructure.Persistence.Configurations;

public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
        ConfigureMenuSectionTable(builder);
        ConfigureMenuDinnerIdsTable(builder);
        ConfigureMenuReviewIdsTable(builder);
    }

    private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.MenuReviewIds, mri =>
        {
            mri.ToTable("MenuReviewIds");
            mri.WithOwner().HasForeignKey("MenuId");

            mri.HasKey("Id");
            mri.Property(d => d.Value)
                .HasColumnName("DinnerId");
            // .ValueGeneratedNever();


        });

        builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.DinnerIds, di =>
        {
            di.ToTable("MenuDinnerIds");
            di.WithOwner().HasForeignKey("MenuId");

            di.HasKey("Id");
            di.Property(d => d.Value)
                .HasColumnName("DinnerId");
            // .ValueGeneratedNever();


        });

        builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuSectionTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.Sections, sb =>
        {
            sb.ToTable("MenuSections");

            sb.WithOwner().HasForeignKey("MenuId");

            sb.HasKey("Id", "MenuId");

            sb.Property(s => s.Id)
                .HasColumnName("MenuSectionId")
                // .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuSectionId.Create(value)
                );

            sb.Property(s => s.Name)
            .HasMaxLength(100);

            sb.Property(s => s.Description)
            .HasMaxLength(100);

            sb.OwnsMany(s => s.Items, ib =>
            {
                ib.ToTable("MenuItems");

                ib.WithOwner().HasForeignKey("MenuSectionId", "MenuId");

                ib.HasKey(nameof(MenuItem.Id), "MenuSectionId", "MenuId");

                ib.Property(i => i.Id)
                 .HasColumnName("MenuItemId")
                //  .ValueGeneratedNever()
                 .HasConversion(
                     id => id.Value,
                     value => MenuItemId.Create(value)
                 );

                ib.Property(i => i.Name)
                    .HasMaxLength(100);

                ib.Property(i => i.Description)
                    .HasMaxLength(100);
            });
            sb.Navigation(s => s.Items).Metadata.SetField("_items");
            sb.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
        });

        builder.Metadata.FindNavigation(nameof(Menu.Sections))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            // .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MenuId.Create(value)
            );
        builder.Property(m => m.Name)
            .HasMaxLength(100);
        builder.Property(m => m.Description)
            .HasMaxLength(100);
        builder.OwnsOne(m => m.AverageRating);
        builder.Property(m => m.HostId)
            //.ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value)
            );
    }
}
