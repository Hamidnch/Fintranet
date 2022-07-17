﻿namespace _1_Fintranet.Common.Interfaces;

/// <summary>
/// Represents a soft-deleted (without actually deleting from storage) entity
/// </summary>
public interface ISoftDeletedEntity
{
    /// <summary>
    /// Gets or sets a value indicating whether the entity has been deleted
    /// </summary>
    bool Deleted { get; set; }
}