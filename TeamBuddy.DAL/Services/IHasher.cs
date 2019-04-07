using System;
using System.Collections.Generic;
using System.Text;

namespace TeamBuddy.DAL.Services
{
    public interface IHasher
    {
        string GetHash(string input);
    }
}
