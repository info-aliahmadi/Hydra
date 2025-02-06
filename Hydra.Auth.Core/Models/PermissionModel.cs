
namespace Hydra.Auth.Models
{
    public class PermissionModel
    {
        //
        // Summary:
        //     Gets or sets the primary key for this permission.
        public int Id { get; set; }

        //
        // Summary:
        //     Gets or sets the name for this permission.
        public string Name { get; set; }

        //
        // Summary:
        //     Gets or sets the normalized name for this permission.
        public string? NormalizedName { get; set; }
    }
}