﻿using System.Collections.Generic;

namespace Backlog.Data.Model
{
    public interface IPrioritizable
    {
        int Id { get; set; }
        int? Priority { get; set; }
    }

    public interface IPrioritizer
    {
        void IncrementPriority(List<IPrioritizable> items);
        void DecrementPriority(List<IPrioritizable> items);
    }
}
