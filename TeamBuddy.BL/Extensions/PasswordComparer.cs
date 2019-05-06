namespace TeamBuddy.BL.Extensions
{
    public static class PasswordComparer
    {
        public static bool ComparePasswords(string enteredPassword, string correctPassword)
        {
            string enteredPasswordHash = PasswordHasher.GetHash(enteredPassword);
            return enteredPasswordHash == correctPassword;

        }
    }
}
