﻿using Microsoft.EntityFrameworkCore;
using TaskProject.Domain.Entities;

namespace TaskProject.Service.Abstractions.DataAccess
{
    public interface IApplicationDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<Questions> Questions { get; set; }
    }
}