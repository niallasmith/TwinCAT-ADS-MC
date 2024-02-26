namespace TwinCAT_ADS_MC;

public class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    public static MCForm1 MCForm1;
    static void Main()
    {
        //PLC myPLC = new PLC(Convert.ToString(AmsNetId.Local),851);
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        ApplicationConfiguration.Initialize();
        MCForm1 MCform1 = new MCForm1();
        Application.Run(MCform1);
    }    

}