using System;
using System.Collections.Generic;
using System.Text;

namespace TeamBuddy.BL.Extensions
{
    public static class PasswordComparer
    {
        public static bool comparePasswords(string enteredPassword, string correctPassword)
        {
            string enteredPasswordHash = PasswordHasher.GetHash(enteredPassword);
            return enteredPasswordHash == correctPassword;

        }
    }
}
