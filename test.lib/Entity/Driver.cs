using System;
using System.Collections.Generic;

namespace test.lib.Entity;

public partial class Driver
{
    public int Id { get; set; }

    public string UniqueId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Route { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool IsDeleted { get; set; }
}
