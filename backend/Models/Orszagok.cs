using System.Text.Json.Serialization;

namespace USZO_EB.Models;

public partial class Orszagok
{
    public int Id { get; set; }
    public string Nev { get; set; } = null!;
    public string Nobid { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Versenyzok>? Versenyzoks { get; set; }
}