using System;
using System.Collections.Generic;

namespace test.lib.Entity;

public partial class Control
{
    public int Id { get; set; }

    public string? ControlName { get; set; }

    public string ControlValue { get; set; } = null!;

    public bool IsDeleted { get; set; }
}
