using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace USZO_EB.Models;

public partial class Szamok
{
    public int Id { get; set; }
    public string Nev { get; set; } = null!;
    public int? VersenyzoId { get; set; }

    [JsonIgnore]
    public virtual Versenyzok? Versenyzo { get; set; }
}
