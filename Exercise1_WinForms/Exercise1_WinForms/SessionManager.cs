using Models;

namespace Exercise1_WinForms
{
    public static class SessionManager
    {
        public static User CurrentUser { get; set; }

        public static bool IsLoggedIn
        {
            get { return CurrentUser != null; }
        }

        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}
