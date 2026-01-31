using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using nago_reforged_api.Models;

namespace nago_reforged_api.Context;

public partial class ReforgedContext : DbContext
{
    public ReforgedContext()
    {
    }

    public ReforgedContext(DbContextOptions<ReforgedContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Bom> Boms { get; set; }

    public virtual DbSet<BuyOrder> BuyOrders { get; set; }

    public virtual DbSet<BuyOrderItem> BuyOrderItems { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Dpnc> Dpncs { get; set; }

    public virtual DbSet<DpncItem> DpncItems { get; set; }

    public virtual DbSet<DpncSolution> DpncSolutions { get; set; }

    public virtual DbSet<Enterprise> Enterprises { get; set; }

    public virtual DbSet<Layout> Layouts { get; set; }

    public virtual DbSet<Machine> Machines { get; set; }

    public virtual DbSet<MonthlySchedule> MonthlySchedules { get; set; }

    public virtual DbSet<Odp> Odps { get; set; }

    public virtual DbSet<OdpItem> OdpItems { get; set; }

    public virtual DbSet<OdpProcessBom> OdpProcessBoms { get; set; }

    public virtual DbSet<OdpProcessBomRegister> OdpProcessBomRegisters { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Process> Processes { get; set; }

    public virtual DbSet<ProcessBom> ProcessBoms { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<ProviderService> ProviderServices { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceOrder> ServiceOrders { get; set; }

    public virtual DbSet<ServiceOrderItem> ServiceOrderItems { get; set; }

    public virtual DbSet<Turn> Turns { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    public virtual DbSet<WeeklySchedule> WeeklySchedules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("dpnc_solution", new[] { "REJECTED", "REPROCESSED", "RECLASIFICATED", "REPROCESSES_PROVIDER", "RECYCLED", "HAND_TO_HAND" })
            .HasPostgresEnum("dpnc_status", new[] { "PENDING", "COMPLETED" })
            .HasPostgresEnum("machine_status", new[] { "ACTIVE", "INACTIVE", "MAINTENANCE" })
            .HasPostgresEnum("odp_status", new[] { "IN_PROCESS", "COMPLETED", "CANCELLED", "FREEDOM", "PENDING" })
            .HasPostgresEnum("odp_type", new[] { "BASIC", "COMBO", "PAINTING", "DPNC BASIC", "DPNC PAINTING" })
            .HasPostgresEnum("orders_status", new[] { "PENDING", "IN_PROGRESS", "COMPLETED", "CANCELLED" })
            .HasPostgresEnum("payment_method", new[] { "CASH", "CREDIT_CARD", "DEBIT_CARD", "TRANSFER", "OTHER" })
            .HasPostgresEnum("payment_status", new[] { "PENDING", "PAID", "REFUNDED" })
            .HasPostgresEnum("process_status", new[] { "ACTIVE", "INACTIVE" })
            .HasPostgresEnum("product_status", new[] { "ACTIVE", "DISCONTINUED", "INACTIVE" })
            .HasPostgresEnum("product_type", new[] { "PP", "PT", "MP", "INPUT", "TOOL", "COMBO" })
            .HasPostgresEnum("profile_status", new[] { "ACTIVE", "INACTIVE" })
            .HasPostgresEnum("provider_calification", new[] { "EXCELLENT", "GOOD", "AVERAGE", "BAD", "VERY_BAD" })
            .HasPostgresEnum("provider_type", new[] { "INTERNAL", "PROVIDER" })
            .HasPostgresEnum("role_area", new[] { "OPERATIVE", "ADMIN" })
            .HasPostgresEnum("schedule_status", new[] { "PENDING", "IN_PROGRESS", "COMPLETED", "CANCELLED" })
            .HasPostgresEnum("status_enterprises", new[] { "ACTIVE", "INACTIVE" })
            .HasPostgresEnum("unit_measure_type", new[] { "KG", "CM", "MT", "GR", "ML", "UN" })
            .HasPostgresEnum("warehouse_status", new[] { "ACTIVE", "INACTIVE" });

        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("areas_pkey");

            entity.ToTable("areas");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Bom>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("bom");

            entity.HasIndex(e => new { e.IdReference, e.IdComponent, e.Recipe }, "bom_id_reference_id_component_recipe_key").IsUnique();

            entity.Property(e => e.IdComponent).HasColumnName("id_component");
            entity.Property(e => e.IdReference).HasColumnName("id_reference");
            entity.Property(e => e.Quantity)
                .HasPrecision(13, 4)
                .HasDefaultValueSql("0.0")
                .HasColumnName("quantity");
            entity.Property(e => e.Recipe)
                .HasDefaultValue((short)1)
                .HasColumnName("recipe");

            entity.HasOne(d => d.IdComponentNavigation).WithMany()
                .HasForeignKey(d => d.IdComponent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bom_id_component_fkey");

            entity.HasOne(d => d.IdReferenceNavigation).WithMany()
                .HasForeignKey(d => d.IdReference)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bom_id_reference_fkey");
        });

        modelBuilder.Entity<BuyOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("buy_orders_pkey");

            entity.ToTable("buy_orders");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.IdProvider).HasColumnName("id_provider");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdProviderNavigation).WithMany(p => p.BuyOrders)
                .HasForeignKey(d => d.IdProvider)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("buy_orders_id_provider_fkey");
        });

        modelBuilder.Entity<BuyOrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("buy_order_items_pkey");

            entity.ToTable("buy_order_items");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdBuyOrder).HasColumnName("id_buy_order");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.Quantity)
                .HasPrecision(13, 4)
                .HasDefaultValueSql("0.0")
                .HasColumnName("quantity");
            entity.Property(e => e.QuantityReceived)
                .HasPrecision(13, 4)
                .HasDefaultValueSql("0.0")
                .HasColumnName("quantity_received");
            entity.Property(e => e.RecievedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("recieved_date");

            entity.HasOne(d => d.IdBuyOrderNavigation).WithMany(p => p.BuyOrderItems)
                .HasForeignKey(d => d.IdBuyOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("buy_order_items_id_buy_order_fkey");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.BuyOrderItems)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("buy_order_items_id_product_fkey");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("contacts_pkey");

            entity.ToTable("contacts");

            entity.HasIndex(e => e.Email, "contacts_email_key").IsUnique();

            entity.HasIndex(e => e.Phone, "contacts_phone_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("firstname");
            entity.Property(e => e.IdProvider).HasColumnName("id_provider");
            entity.Property(e => e.Lastname)
                .HasMaxLength(150)
                .HasColumnName("lastname");
            entity.Property(e => e.Middlename)
                .HasMaxLength(50)
                .HasColumnName("middlename");
            entity.Property(e => e.Phone)
                .HasMaxLength(21)
                .HasColumnName("phone");

            entity.HasOne(d => d.IdProviderNavigation).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.IdProvider)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contacts_id_provider_fkey");
        });

        modelBuilder.Entity<Dpnc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dpnc_pkey");

            entity.ToTable("dpnc");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.FinishedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("finished_at");
            entity.Property(e => e.Odp).HasColumnName("odp");

            entity.HasOne(d => d.OdpNavigation).WithMany(p => p.Dpncs)
                .HasForeignKey(d => d.Odp)
                .HasConstraintName("dpnc_odp_fkey");
        });

        modelBuilder.Entity<DpncItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dpnc_items_pkey");

            entity.ToTable("dpnc_items");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdDpnc).HasColumnName("id_dpnc");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.IsCompleted)
                .HasDefaultValue(false)
                .HasColumnName("is_completed");
            entity.Property(e => e.Quantity)
                .HasPrecision(13, 4)
                .HasDefaultValueSql("0.0")
                .HasColumnName("quantity");

            entity.HasOne(d => d.IdDpncNavigation).WithMany(p => p.DpncItems)
                .HasForeignKey(d => d.IdDpnc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dpnc_items_id_dpnc_fkey");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.DpncItems)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dpnc_items_id_product_fkey");
        });

        modelBuilder.Entity<DpncSolution>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dpnc_solutions_pkey");

            entity.ToTable("dpnc_solutions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.HandToHandFile)
                .HasMaxLength(256)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("hand_to_hand_file");
            entity.Property(e => e.IdDpncItem).HasColumnName("id_dpnc_item");
            entity.Property(e => e.OdpId).HasColumnName("odp_id");
            entity.Property(e => e.Quantity)
                .HasPrecision(13, 4)
                .HasDefaultValueSql("0.0")
                .HasColumnName("quantity");
            entity.Property(e => e.SolvedBy).HasColumnName("solved_by");

            entity.HasOne(d => d.IdDpncItemNavigation).WithMany(p => p.DpncSolutions)
                .HasForeignKey(d => d.IdDpncItem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dpnc_solutions_id_dpnc_item_fkey");

            entity.HasOne(d => d.SolvedByNavigation).WithMany(p => p.DpncSolutions)
                .HasForeignKey(d => d.SolvedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dpnc_solutions_solved_by_fkey");
        });

        modelBuilder.Entity<Enterprise>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enterprises_pkey");

            entity.ToTable("enterprises");

            entity.HasIndex(e => e.Email, "enterprises_email_key").IsUnique();

            entity.HasIndex(e => e.Nit, "enterprises_nit_key").IsUnique();

            entity.HasIndex(e => e.Phone, "enterprises_phone_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(512)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Nit)
                .HasMaxLength(256)
                .HasColumnName("nit");
            entity.Property(e => e.Phone)
                .HasMaxLength(21)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Layout>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("layout_pkey");

            entity.ToTable("layout");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.MachineId).HasColumnName("machine_id");
            entity.Property(e => e.PositionX)
                .HasDefaultValue(0)
                .HasColumnName("position_x");
            entity.Property(e => e.PositionY)
                .HasDefaultValue(0)
                .HasColumnName("position_y");
            entity.Property(e => e.PositionZ)
                .HasDefaultValue(0)
                .HasColumnName("position_z");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Visible)
                .HasDefaultValue(true)
                .HasColumnName("visible");

            entity.HasOne(d => d.Machine).WithMany(p => p.Layouts)
                .HasForeignKey(d => d.MachineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("layout_machine_id_fkey");
        });

        modelBuilder.Entity<Machine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("machines_pkey");

            entity.ToTable("machines");

            entity.HasIndex(e => e.Name, "machines_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Brand)
                .HasMaxLength(256)
                .HasColumnName("brand");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.LastMaintenance)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_maintenance");
            entity.Property(e => e.Model)
                .HasMaxLength(300)
                .HasColumnName("model");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MonthlySchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("monthly_schedule_pkey");

            entity.ToTable("monthly_schedule");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Quantity)
                .HasPrecision(13, 4)
                .HasDefaultValueSql("0.0")
                .HasColumnName("quantity");
            entity.Property(e => e.ReferenceId).HasColumnName("reference_id");
            entity.Property(e => e.ScheduleDate).HasColumnName("schedule_date");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Reference).WithMany(p => p.MonthlySchedules)
                .HasForeignKey(d => d.ReferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("monthly_schedule_reference_id_fkey");
        });

        modelBuilder.Entity<Odp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("odp_pkey");

            entity.ToTable("odp");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.FinishedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("finished_at");
        });

        modelBuilder.Entity<OdpItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("odp_items_pkey");

            entity.ToTable("odp_items");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdOdp).HasColumnName("id_odp");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.Quantity)
                .HasPrecision(13, 4)
                .HasDefaultValueSql("0.0")
                .HasColumnName("quantity");
            entity.Property(e => e.RecipeNumber)
                .HasDefaultValue((short)1)
                .HasColumnName("recipe_number");

            entity.HasOne(d => d.IdOdpNavigation).WithMany(p => p.OdpItems)
                .HasForeignKey(d => d.IdOdp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("odp_items_id_odp_fkey");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.OdpItems)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("odp_items_id_product_fkey");
        });

        modelBuilder.Entity<OdpProcessBom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("odp_process_bom_pkey");

            entity.ToTable("odp_process_bom");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.IdOdpItem).HasColumnName("id_odp_item");
            entity.Property(e => e.IdProcessBom).HasColumnName("id_process_bom");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdOdpItemNavigation).WithMany(p => p.OdpProcessBoms)
                .HasForeignKey(d => d.IdOdpItem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("odp_process_bom_id_odp_item_fkey");

            entity.HasOne(d => d.IdProcessBomNavigation).WithMany(p => p.OdpProcessBoms)
                .HasForeignKey(d => d.IdProcessBom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("odp_process_bom_id_process_bom_fkey");
        });

        modelBuilder.Entity<OdpProcessBomRegister>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("odp_process_bom_register_pkey");

            entity.ToTable("odp_process_bom_register");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.IdMachine).HasColumnName("id_machine");
            entity.Property(e => e.IdOdpProcessBom).HasColumnName("id_odp_process_bom");
            entity.Property(e => e.Quantity)
                .HasPrecision(13, 4)
                .HasDefaultValueSql("0.0")
                .HasColumnName("quantity");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.IdMachineNavigation).WithMany(p => p.OdpProcessBomRegisters)
                .HasForeignKey(d => d.IdMachine)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("odp_process_bom_register_id_machine_fkey");

            entity.HasOne(d => d.IdOdpProcessBomNavigation).WithMany(p => p.OdpProcessBomRegisters)
                .HasForeignKey(d => d.IdOdpProcessBom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("odp_process_bom_register_id_odp_process_bom_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.OdpProcessBomRegisters)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("odp_process_bom_register_user_id_fkey");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("payments_pkey");

            entity.ToTable("payments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasPrecision(11, 2)
                .HasDefaultValueSql("0.0")
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.IdBuyOrder).HasColumnName("id_buy_order");
            entity.Property(e => e.IdServiceOrder).HasColumnName("id_service_order");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdBuyOrderNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.IdBuyOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payments_id_buy_order_fkey");

            entity.HasOne(d => d.IdServiceOrderNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.IdServiceOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payments_id_service_order_fkey");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("permissions_pkey");

            entity.ToTable("permissions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateAreas)
                .HasDefaultValue(false)
                .HasColumnName("create_areas");
            entity.Property(e => e.CreateBom)
                .HasDefaultValue(false)
                .HasColumnName("create_bom");
            entity.Property(e => e.CreateContacts)
                .HasDefaultValue(false)
                .HasColumnName("create_contacts");
            entity.Property(e => e.CreateDpnc)
                .HasDefaultValue(false)
                .HasColumnName("create_dpnc");
            entity.Property(e => e.CreateEnterprises)
                .HasDefaultValue(false)
                .HasColumnName("create_enterprises");
            entity.Property(e => e.CreateMachines)
                .HasDefaultValue(false)
                .HasColumnName("create_machines");
            entity.Property(e => e.CreateOc)
                .HasDefaultValue(false)
                .HasColumnName("create_oc");
            entity.Property(e => e.CreateOdp)
                .HasDefaultValue(false)
                .HasColumnName("create_odp");
            entity.Property(e => e.CreateOs)
                .HasDefaultValue(false)
                .HasColumnName("create_os");
            entity.Property(e => e.CreatePayments)
                .HasDefaultValue(false)
                .HasColumnName("create_payments");
            entity.Property(e => e.CreateProcesses)
                .HasDefaultValue(false)
                .HasColumnName("create_processes");
            entity.Property(e => e.CreateProducts)
                .HasDefaultValue(false)
                .HasColumnName("create_products");
            entity.Property(e => e.CreateProviders)
                .HasDefaultValue(false)
                .HasColumnName("create_providers");
            entity.Property(e => e.CreateReception)
                .HasDefaultValue(false)
                .HasColumnName("create_reception");
            entity.Property(e => e.CreateReportOdp)
                .HasDefaultValue(false)
                .HasColumnName("create_report_odp");
            entity.Property(e => e.CreateRoles)
                .HasDefaultValue(false)
                .HasColumnName("create_roles");
            entity.Property(e => e.CreateSchedule)
                .HasDefaultValue(false)
                .HasColumnName("create_schedule");
            entity.Property(e => e.CreateServices)
                .HasDefaultValue(false)
                .HasColumnName("create_services");
            entity.Property(e => e.CreateSolutionDpnc)
                .HasDefaultValue(false)
                .HasColumnName("create_solution_dpnc");
            entity.Property(e => e.CreateTurn)
                .HasDefaultValue(false)
                .HasColumnName("create_turn");
            entity.Property(e => e.CreateUser)
                .HasDefaultValue(false)
                .HasColumnName("create_user");
            entity.Property(e => e.DeleteAreas)
                .HasDefaultValue(false)
                .HasColumnName("delete_areas");
            entity.Property(e => e.DeleteBom)
                .HasDefaultValue(false)
                .HasColumnName("delete_bom");
            entity.Property(e => e.DeleteContacts)
                .HasDefaultValue(false)
                .HasColumnName("delete_contacts");
            entity.Property(e => e.DeleteDpnc)
                .HasDefaultValue(false)
                .HasColumnName("delete_dpnc");
            entity.Property(e => e.DeleteEnterprises)
                .HasDefaultValue(false)
                .HasColumnName("delete_enterprises");
            entity.Property(e => e.DeleteMachines)
                .HasDefaultValue(false)
                .HasColumnName("delete_machines");
            entity.Property(e => e.DeleteOc)
                .HasDefaultValue(false)
                .HasColumnName("delete_oc");
            entity.Property(e => e.DeleteOdp)
                .HasDefaultValue(false)
                .HasColumnName("delete_odp");
            entity.Property(e => e.DeleteOs)
                .HasDefaultValue(false)
                .HasColumnName("delete_os");
            entity.Property(e => e.DeletePayments)
                .HasDefaultValue(false)
                .HasColumnName("delete_payments");
            entity.Property(e => e.DeleteProcesses)
                .HasDefaultValue(false)
                .HasColumnName("delete_processes");
            entity.Property(e => e.DeleteProducts)
                .HasDefaultValue(false)
                .HasColumnName("delete_products");
            entity.Property(e => e.DeleteProviders)
                .HasDefaultValue(false)
                .HasColumnName("delete_providers");
            entity.Property(e => e.DeleteReception)
                .HasDefaultValue(false)
                .HasColumnName("delete_reception");
            entity.Property(e => e.DeleteReportOdp)
                .HasDefaultValue(false)
                .HasColumnName("delete_report_odp");
            entity.Property(e => e.DeleteRoles)
                .HasDefaultValue(false)
                .HasColumnName("delete_roles");
            entity.Property(e => e.DeleteSchedule)
                .HasDefaultValue(false)
                .HasColumnName("delete_schedule");
            entity.Property(e => e.DeleteServices)
                .HasDefaultValue(false)
                .HasColumnName("delete_services");
            entity.Property(e => e.DeleteSolutionDpnc)
                .HasDefaultValue(false)
                .HasColumnName("delete_solution_dpnc");
            entity.Property(e => e.DeleteTurn)
                .HasDefaultValue(false)
                .HasColumnName("delete_turn");
            entity.Property(e => e.DeleteUser)
                .HasDefaultValue(false)
                .HasColumnName("delete_user");
            entity.Property(e => e.GeneratedReports)
                .HasDefaultValue(false)
                .HasColumnName("generated_reports");
            entity.Property(e => e.ProfileId).HasColumnName("profile_id");
            entity.Property(e => e.ReadAreas)
                .HasDefaultValue(false)
                .HasColumnName("read_areas");
            entity.Property(e => e.ReadBom)
                .HasDefaultValue(false)
                .HasColumnName("read_bom");
            entity.Property(e => e.ReadContacts)
                .HasDefaultValue(false)
                .HasColumnName("read_contacts");
            entity.Property(e => e.ReadDpnc)
                .HasDefaultValue(false)
                .HasColumnName("read_dpnc");
            entity.Property(e => e.ReadEnterprises)
                .HasDefaultValue(false)
                .HasColumnName("read_enterprises");
            entity.Property(e => e.ReadMachines)
                .HasDefaultValue(false)
                .HasColumnName("read_machines");
            entity.Property(e => e.ReadOc)
                .HasDefaultValue(false)
                .HasColumnName("read_oc");
            entity.Property(e => e.ReadOdp)
                .HasDefaultValue(false)
                .HasColumnName("read_odp");
            entity.Property(e => e.ReadOs)
                .HasDefaultValue(false)
                .HasColumnName("read_os");
            entity.Property(e => e.ReadPayments)
                .HasDefaultValue(false)
                .HasColumnName("read_payments");
            entity.Property(e => e.ReadProcesses)
                .HasDefaultValue(false)
                .HasColumnName("read_processes");
            entity.Property(e => e.ReadProducts)
                .HasDefaultValue(false)
                .HasColumnName("read_products");
            entity.Property(e => e.ReadProviders)
                .HasDefaultValue(false)
                .HasColumnName("read_providers");
            entity.Property(e => e.ReadReception)
                .HasDefaultValue(false)
                .HasColumnName("read_reception");
            entity.Property(e => e.ReadReportOdp)
                .HasDefaultValue(false)
                .HasColumnName("read_report_odp");
            entity.Property(e => e.ReadReports)
                .HasDefaultValue(false)
                .HasColumnName("read_reports");
            entity.Property(e => e.ReadRoles)
                .HasDefaultValue(false)
                .HasColumnName("read_roles");
            entity.Property(e => e.ReadSchedule)
                .HasDefaultValue(false)
                .HasColumnName("read_schedule");
            entity.Property(e => e.ReadServices)
                .HasDefaultValue(false)
                .HasColumnName("read_services");
            entity.Property(e => e.ReadSolutionDpnc)
                .HasDefaultValue(false)
                .HasColumnName("read_solution_dpnc");
            entity.Property(e => e.ReadTurn)
                .HasDefaultValue(false)
                .HasColumnName("read_turn");
            entity.Property(e => e.ReadUser)
                .HasDefaultValue(false)
                .HasColumnName("read_user");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UpdateAreas)
                .HasDefaultValue(false)
                .HasColumnName("update_areas");
            entity.Property(e => e.UpdateBom)
                .HasDefaultValue(false)
                .HasColumnName("update_bom");
            entity.Property(e => e.UpdateContacts)
                .HasDefaultValue(false)
                .HasColumnName("update_contacts");
            entity.Property(e => e.UpdateDpnc)
                .HasDefaultValue(false)
                .HasColumnName("update_dpnc");
            entity.Property(e => e.UpdateEnterprises)
                .HasDefaultValue(false)
                .HasColumnName("update_enterprises");
            entity.Property(e => e.UpdateMachines)
                .HasDefaultValue(false)
                .HasColumnName("update_machines");
            entity.Property(e => e.UpdateOc)
                .HasDefaultValue(false)
                .HasColumnName("update_oc");
            entity.Property(e => e.UpdateOdp)
                .HasDefaultValue(false)
                .HasColumnName("update_odp");
            entity.Property(e => e.UpdateOs)
                .HasDefaultValue(false)
                .HasColumnName("update_os");
            entity.Property(e => e.UpdatePayments)
                .HasDefaultValue(false)
                .HasColumnName("update_payments");
            entity.Property(e => e.UpdateProcesses)
                .HasDefaultValue(false)
                .HasColumnName("update_processes");
            entity.Property(e => e.UpdateProducts)
                .HasDefaultValue(false)
                .HasColumnName("update_products");
            entity.Property(e => e.UpdateProviders)
                .HasDefaultValue(false)
                .HasColumnName("update_providers");
            entity.Property(e => e.UpdateReception)
                .HasDefaultValue(false)
                .HasColumnName("update_reception");
            entity.Property(e => e.UpdateReportOdp)
                .HasDefaultValue(false)
                .HasColumnName("update_report_odp");
            entity.Property(e => e.UpdateRoles)
                .HasDefaultValue(false)
                .HasColumnName("update_roles");
            entity.Property(e => e.UpdateSchedule)
                .HasDefaultValue(false)
                .HasColumnName("update_schedule");
            entity.Property(e => e.UpdateServices)
                .HasDefaultValue(false)
                .HasColumnName("update_services");
            entity.Property(e => e.UpdateSolutionDpnc)
                .HasDefaultValue(false)
                .HasColumnName("update_solution_dpnc");
            entity.Property(e => e.UpdateTurn)
                .HasDefaultValue(false)
                .HasColumnName("update_turn");
            entity.Property(e => e.UpdateUser)
                .HasDefaultValue(false)
                .HasColumnName("update_user");

            entity.HasOne(d => d.Profile).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.ProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("permissions_profile_id_fkey");

            entity.HasOne(d => d.Role).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("permissions_role_id_fkey");
        });

        modelBuilder.Entity<Process>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("processes_pkey");

            entity.ToTable("processes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(300)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ProcessBom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("process_bom_pkey");

            entity.ToTable("process_bom");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.IdReference).HasColumnName("id_reference");
            entity.Property(e => e.ProcessId).HasColumnName("process_id");
            entity.Property(e => e.RecipeNumber).HasColumnName("recipe_number");
            entity.Property(e => e.Sam)
                .HasPrecision(6, 2)
                .HasColumnName("sam");

            entity.HasOne(d => d.IdReferenceNavigation).WithMany(p => p.ProcessBoms)
                .HasForeignKey(d => d.IdReference)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("process_bom_id_reference_fkey");

            entity.HasOne(d => d.Process).WithMany(p => p.ProcessBoms)
                .HasForeignKey(d => d.ProcessId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("process_bom_process_id_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("products_pkey");

            entity.ToTable("products");

            entity.HasIndex(e => e.Reference, "products_reference_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cost)
                .HasPrecision(11, 2)
                .HasDefaultValueSql("0.0")
                .HasColumnName("cost");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Gtin)
                .HasMaxLength(256)
                .HasColumnName("gtin");
            entity.Property(e => e.Image)
                .HasMaxLength(300)
                .HasColumnName("image");
            entity.Property(e => e.MaximalPoint)
                .HasPrecision(13, 4)
                .HasDefaultValueSql("0.0")
                .HasColumnName("maximal_point");
            entity.Property(e => e.MinimalPoint)
                .HasPrecision(13, 4)
                .HasDefaultValueSql("0.0")
                .HasColumnName("minimal_point");
            entity.Property(e => e.Reference)
                .HasMaxLength(256)
                .HasColumnName("reference");
            entity.Property(e => e.SalePrice)
                .HasPrecision(11, 2)
                .HasDefaultValueSql("0.0")
                .HasColumnName("sale_price");
            entity.Property(e => e.Weight)
                .HasPrecision(13, 4)
                .HasColumnName("weight");
            entity.Property(e => e.X)
                .HasPrecision(6, 2)
                .HasDefaultValueSql("0.0")
                .HasColumnName("x");
            entity.Property(e => e.Y)
                .HasPrecision(6, 2)
                .HasDefaultValueSql("0.0")
                .HasColumnName("y");
            entity.Property(e => e.Z)
                .HasPrecision(6, 2)
                .HasDefaultValueSql("0.0")
                .HasColumnName("z");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("profiles_pkey");

            entity.ToTable("profiles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.EnterpriceId).HasColumnName("enterprice_id");
            entity.Property(e => e.LeaderId).HasColumnName("leader_id");
            entity.Property(e => e.SalaryHour)
                .HasPrecision(11, 2)
                .HasDefaultValueSql("0.00")
                .HasColumnName("salary_hour");
            entity.Property(e => e.TurnId).HasColumnName("turn_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Area).WithMany(p => p.Profiles)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("profiles_area_id_fkey");

            entity.HasOne(d => d.Enterprice).WithMany(p => p.Profiles)
                .HasForeignKey(d => d.EnterpriceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("profiles_enterprice_id_fkey");

            entity.HasOne(d => d.Turn).WithMany(p => p.Profiles)
                .HasForeignKey(d => d.TurnId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("profiles_turn_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Profiles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("profiles_user_id_fkey");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("providers_pkey");

            entity.ToTable("providers");

            entity.HasIndex(e => e.Email, "providers_email_key").IsUnique();

            entity.HasIndex(e => e.Phone, "providers_phone_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(512)
                .HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Nit)
                .HasMaxLength(256)
                .HasColumnName("nit");
            entity.Property(e => e.Phone)
                .HasMaxLength(21)
                .HasColumnName("phone");
            entity.Property(e=> e.Type)
                .HasColumnName("type");
        });

        modelBuilder.Entity<ProviderService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("provider_service_pkey");

            entity.ToTable("provider_service");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProviderId).HasColumnName("provider_id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Value)
                .HasPrecision(11, 2)
                .HasDefaultValueSql("0.0")
                .HasColumnName("value");

            entity.HasOne(d => d.Product).WithMany(p => p.ProviderServices)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("provider_service_product_id_fkey");

            entity.HasOne(d => d.Provider).WithMany(p => p.ProviderServices)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("provider_service_provider_id_fkey");

            entity.HasOne(d => d.Service).WithMany(p => p.ProviderServices)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("provider_service_service_id_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.HasIndex(e => e.Name, "roles_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e=> e.Type)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("services_pkey");

            entity.ToTable("services");

            entity.HasIndex(e => e.Name, "services_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ServiceOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("service_orders_pkey");

            entity.ToTable("service_orders");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.IdProvider).HasColumnName("id_provider");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdProviderNavigation).WithMany(p => p.ServiceOrders)
                .HasForeignKey(d => d.IdProvider)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("service_orders_id_provider_fkey");
        });

        modelBuilder.Entity<ServiceOrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("service_order_items_pkey");

            entity.ToTable("service_order_items");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.IdService).HasColumnName("id_service");
            entity.Property(e => e.IdServiceOrder).HasColumnName("id_service_order");
            entity.Property(e => e.Quantity)
                .HasPrecision(13, 4)
                .HasDefaultValueSql("0.0")
                .HasColumnName("quantity");
            entity.Property(e => e.QuantityReceived)
                .HasPrecision(13, 4)
                .HasDefaultValueSql("0.0")
                .HasColumnName("quantity_received");
            entity.Property(e => e.RecievedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("recieved_date");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.ServiceOrderItems)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("service_order_items_id_product_fkey");

            entity.HasOne(d => d.IdServiceNavigation).WithMany(p => p.ServiceOrderItems)
                .HasForeignKey(d => d.IdService)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("service_order_items_id_service_fkey");

            entity.HasOne(d => d.IdServiceOrderNavigation).WithMany(p => p.ServiceOrderItems)
                .HasForeignKey(d => d.IdServiceOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("service_order_items_id_service_order_fkey");
        });

        modelBuilder.Entity<Turn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("turns_pkey");

            entity.ToTable("turns");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.FromTime).HasColumnName("from_time");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.ToTime).HasColumnName("to_time");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.HasIndex(e => e.Phone, "users_phone_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Lastname)
                .HasMaxLength(150)
                .HasColumnName("lastname");
            entity.Property(e => e.Middlename)
                .HasMaxLength(100)
                .HasColumnName("middlename");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(256)
                .HasColumnName("password_hash");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.PhotoUrl).HasColumnName("photo_url");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("warehouse_pkey");

            entity.ToTable("warehouse");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.IdProvider).HasColumnName("id_provider");
            entity.Property(e => e.QuantityAvailable)
                .HasPrecision(13, 4)
                .HasDefaultValueSql("0.0")
                .HasColumnName("quantity_available");
            entity.Property(e => e.QuantityReservate)
                .HasPrecision(13, 4)
                .HasDefaultValueSql("0.0")
                .HasColumnName("quantity_reservate");

            entity.HasOne(d => d.IdProviderNavigation).WithMany(p => p.Warehouses)
                .HasForeignKey(d => d.IdProvider)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("warehouse_id_provider_fkey");
        });

        modelBuilder.Entity<WeeklySchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("weekly_schedule_pkey");

            entity.ToTable("weekly_schedule");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MonthlyScheduleId).HasColumnName("monthly_schedule_id");
            entity.Property(e => e.Quantity)
                .HasPrecision(13, 4)
                .HasDefaultValueSql("0.0")
                .HasColumnName("quantity");
            entity.Property(e => e.ScheduleDate).HasColumnName("schedule_date");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.MonthlySchedule).WithMany(p => p.WeeklySchedules)
                .HasForeignKey(d => d.MonthlyScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("weekly_schedule_monthly_schedule_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
