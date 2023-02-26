﻿using System.ComponentModel.DataAnnotations;

namespace Framework.Domain;

public abstract class EntityBase
{
    [Key]
    public ulong Id { get; private set; }
    public bool IsDelete { get; private set; }
    public DateTime CreationDate { get; private set; }
    public DateTime LastUpdateDate { get; set; }
    public DateTime? DeletionDate { get; private set; }

    protected EntityBase()
    {
        CreationDate = DateTime.UtcNow;
        IsDelete = false;
    }

    public virtual void Delete()
    {
        IsDelete = true;
        DeletionDate = DateTime.UtcNow;
    }

    public virtual void Active()
    {
        IsDelete = false;
        DeletionDate = null;
    }
}