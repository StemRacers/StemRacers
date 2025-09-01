using UnityEngine;

/// <summary>
/// Provides contextual information required for block execution,
/// including access to the associated <see cref="VehicleController"/>.
/// </summary>
public class BlockContext
{
    // Contextual information for block execution
    public VehicleController Vehicle { get; set; }
}