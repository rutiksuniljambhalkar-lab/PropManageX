using Microsoft.EntityFrameworkCore;
using PropManageX.Models.Entities;

namespace PropManageX.Models.Context
{
    public class PropManageXContext : DbContext
    {
        public PropManageXContext()
        {
            
        }
        public PropManageXContext(DbContextOptions<PropManageXContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
            }
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<PropertyModel> Properties { get; set; }
        public DbSet<UnitModel> Units { get; set; }
        public DbSet<LeadModel> Leads { get; set; }
        public DbSet<SiteVisitModel> SiteVisits { get; set; }
        public DbSet<DealModel> Deals { get; set; }
        public DbSet<ContractModel> Contracts { get; set; }
        public DbSet<InvoiceModel> Invoices { get; set; }
        public DbSet<NotificationModel> Notifications { get; set; }
        public DbSet<AmenityModel> Amenities { get; set; }
        public DbSet<DocumentModel> Documents { get; set; }
        public DbSet<MaintenanceRequestModel> MaintenanceRequests { get; set; }
        public DbSet<RenewalModel> Renewals { get; set; }
        public DbSet<RevenueReportModel> RevenueReports { get; set; }

        public DbSet<VendorAssignmentModel> VendorAssignments { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Deal → Lead (Disable cascade)
			modelBuilder.Entity<DealModel>()
				.HasOne(d => d.LeadModel)
				.WithMany(l => l.Deals)
				.HasForeignKey(d => d.LeadID)
				.OnDelete(DeleteBehavior.Restrict);

			// Deal → Unit (Disable cascade)
			modelBuilder.Entity<DealModel>()
				.HasOne(d => d.UnitModel)
				.WithMany(u => u.Deals)
				.HasForeignKey(d => d.UnitID)
				.OnDelete(DeleteBehavior.Restrict);

            // Deal → Contract
            modelBuilder.Entity<ContractModel>()
                .HasOne(c => c.DealModel)
                .WithMany(d => d.Contracts)
                .HasForeignKey(c => c.DealID)
                .OnDelete(DeleteBehavior.Restrict);

            // Contract → Invoice
            modelBuilder.Entity<InvoiceModel>()
                .HasOne(i => i.Contracts)
                .WithMany(c => c.Invoices)
                .HasForeignKey(i => i.ContractID)
                .OnDelete(DeleteBehavior.Restrict);

        }



	}
}
