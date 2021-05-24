using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoryWriter.Models;

namespace StoryWriter.Services.Statement
{
    public interface IStatementService
    {
        Task<List<PayStatement>> GetStatementHistoryAsync();
    }
}
