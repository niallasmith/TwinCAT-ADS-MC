// TWINCAT-ADS-MC
// Written by Niall Smith
// Jan 2024 to Apr 2024

namespace TwinCAT_ADS_MC;

public class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    public static MCForm1 MCForm1;
    static void Main()
    {
        // Main start point of code
        Application.SetHighDpiMode(HighDpiMode.SystemAware); // should scale the GUI to fit with high DPI screens - not sure this works as intended?
        ApplicationConfiguration.Initialize();
        MCForm1 MCform1 = new MCForm1();
        Application.Run(MCform1); // opens main GUI (MCForm1)
    }    

}