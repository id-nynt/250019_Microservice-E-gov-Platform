using Microsoft.EntityFrameworkCore;
using ParcelTracking.Models;
using System;

namespace ParcelTracking.Data
{
    // EF Core DbContext for Parcel microservice
    public class ParcelDbContext : DbContext
    {
        public ParcelDbContext(DbContextOptions<ParcelDbContext> options) : base(options) { }

        public DbSet<Parcel> Parcels => Set<Parcel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // All Etas are hard-coded UTC datetimes to keep the model deterministic
            modelBuilder.Entity<Parcel>().HasData(
                new Parcel { Id = 1,  TrackingNumber = "AP100001", Status = "Dispatched",        Location = "Sydney Facility",   Eta = new DateTime(2025,10,10, 8,0,0, DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 2,  TrackingNumber = "AP100002", Status = "In Transit",        Location = "Sydney Hub",        Eta = new DateTime(2025,10,11, 8,0,0, DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 3,  TrackingNumber = "AP100003", Status = "Processed",         Location = "Sydney Hub",        Eta = new DateTime(2025,10,11,12,0,0, DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 4,  TrackingNumber = "AP100004", Status = "Out for Delivery",  Location = "Wollongong Depot",  Eta = new DateTime(2025,10,08,14,0,0, DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 5,  TrackingNumber = "AP100005", Status = "Delivered",         Location = "Wollongong",        Eta = new DateTime(2025,10,07,10,0,0, DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 6,  TrackingNumber = "AP100006", Status = "Delayed",           Location = "Melbourne Hub",     Eta = new DateTime(2025,10,13, 9,0,0, DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 7,  TrackingNumber = "AP100007", Status = "Held at Customs",   Location = "Sydney Airport",    Eta = new DateTime(2025,10,12,16,0,0, DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 8,  TrackingNumber = "AP100008", Status = "In Transit",        Location = "Canberra Facility", Eta = new DateTime(2025,10,09,11,0,0, DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 9,  TrackingNumber = "AP100009", Status = "Processed",         Location = "Brisbane Hub",      Eta = new DateTime(2025,10,10,15,0,0, DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 10, TrackingNumber = "AP100010", Status = "Out for Delivery",  Location = "Canberra Depot",    Eta = new DateTime(2025,10,08,18,0,0, DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 11, TrackingNumber = "AP100011", Status = "Delivered",         Location = "Canberra",          Eta = new DateTime(2025,10,06, 9,0,0, DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 12, TrackingNumber = "AP100012", Status = "Processing",        Location = "Perth Hub",         Eta = new DateTime(2025,10,12,10,0,0, DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 13, TrackingNumber = "AP100013", Status = "In Transit",        Location = "Adelaide Hub",      Eta = new DateTime(2025,10,11,14,0,0, DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 14, TrackingNumber = "AP100014", Status = "Processed",         Location = "Adelaide Hub",      Eta = new DateTime(2025,10,11,16,0,0, DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 15, TrackingNumber = "AP100015", Status = "Delayed",           Location = "Darwin Hub",        Eta = new DateTime(2025,10,14, 8,0,0, DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 16, TrackingNumber = "AP100016", Status = "Dispatched",        Location = "Melbourne Facility",Eta = new DateTime(2025,10,10,13,0,0, DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 17, TrackingNumber = "AP100017", Status = "Out for Delivery",  Location = "Sydney Depot",      Eta = new DateTime(2025,10,08,12,0,0, DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 18, TrackingNumber = "AP100018", Status = "Delivered",         Location = "Sydney",            Eta = new DateTime(2025,10,07,12,0,0, DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 19, TrackingNumber = "AP100019", Status = "Processing",        Location = "Hobart Hub",        Eta = new DateTime(2025,10,13,10,0,0, DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 20, TrackingNumber = "AP100020", Status = "In Transit",        Location = "Gold Coast Hub",    Eta = new DateTime(2025,10,11, 9,0,0, DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 21, TrackingNumber = "AP100021", Status = "Processed",         Location = "Gold Coast Hub",    Eta = new DateTime(2025,10,11,11,0,0, DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 22, TrackingNumber = "AP100022", Status = "Out for Delivery",  Location = "Melbourne Depot",   Eta = new DateTime(2025,10,08,17,0,0, DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 23, TrackingNumber = "AP100023", Status = "Delivered",         Location = "Melbourne",         Eta = new DateTime(2025,10,06,14,0,0, DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 24, TrackingNumber = "AP100024", Status = "Held at Facility",  Location = "Perth Facility",    Eta = new DateTime(2025,10,12,15,0,0, DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 25, TrackingNumber = "AP100025", Status = "In Transit",        Location = "Sydney Hub",        Eta = new DateTime(2025,10,09,10,0,0, DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 26, TrackingNumber = "AP100026", Status = "Processed",         Location = "Sydney Hub",        Eta = new DateTime(2025,10,09,12,0,0, DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 27, TrackingNumber = "AP100027", Status = "Delayed",           Location = "Canberra Hub",      Eta = new DateTime(2025,10,13,16,0,0, DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 28, TrackingNumber = "AP100028", Status = "Processing",        Location = "Brisbane Hub",      Eta = new DateTime(2025,10,10,10,0,0, DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 29, TrackingNumber = "AP100029", Status = "Out for Delivery",  Location = "Brisbane Depot",    Eta = new DateTime(2025,10,08,20,0,0, DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 30, TrackingNumber = "AP100030", Status = "Delivered",         Location = "Brisbane",          Eta = new DateTime(2025,10,05, 9,0,0, DateTimeKind.Utc), History = "[]" }
            );
        }
    }
}