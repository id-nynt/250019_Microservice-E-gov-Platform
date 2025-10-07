using System;

namespace ParcelTracking.Models
{
    // Domain model for a parcel tracking record
    public class Parcel
    {
        public int Id { get; set; }                          // Primary key
        public string TrackingNumber { get; set; } = "";     // Unique tracking number
        public string Status { get; set; } = "";             // Current status
        public string Location { get; set; } = "";           // Current location
        public DateTime Eta { get; set; }                    // Estimated delivery time (UTC)
        public string History { get; set; } = "[]";          // JSON string, e.g. "[]"
    }
}