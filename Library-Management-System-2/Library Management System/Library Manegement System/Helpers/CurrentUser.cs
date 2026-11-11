namespace Library_Manegement_System
{
    public static class CurrentUser
    {
        public static string Username { get; set; } = "admin";
        public static string FullName { get; set; } = "Library Admin";
        public static string Role { get; set; } = "Admin";   // "Admin" or "Subadmin"

        public static bool IsAdmin => string.Equals(Role, "Admin", System.StringComparison.OrdinalIgnoreCase);
        public static bool IsSubadmin => string.Equals(Role, "Subadmin", System.StringComparison.OrdinalIgnoreCase);

        public static void Reset()
        {
            Username = "admin";
            FullName = "Library Admin";
            Role = "Admin";
        }
    }
}
