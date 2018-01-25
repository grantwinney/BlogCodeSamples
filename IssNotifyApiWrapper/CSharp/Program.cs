namespace ISS_Notify_Wrapper
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ISS.ShowRoster();

            ISS.ShowUpcomingPasses("41.4984174", "-81.6937287");

            ISS.ShowCurrentLocation();
        }
    }
}
