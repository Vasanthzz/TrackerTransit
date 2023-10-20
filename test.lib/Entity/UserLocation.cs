using System;
using System.Collections.Generic;

namespace test.lib.Entity;

public partial class UserLocation
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }
}
