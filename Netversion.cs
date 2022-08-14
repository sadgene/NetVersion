using System;
using System.Diagnostics;
using Microsoft.Win32;


class NetVersion
{
    static void Main()
    {
        const string subkey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\";

        using (var ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subkey))
        {
            if (ndpKey != null && ndpKey.GetValue("Release") != null)
            {
                Console.WriteLine($".NET Framework Version: {CheckFor45PlusVersion((int)ndpKey.GetValue("Release"))}");
                if (CheckFor45PlusVersion((int)ndpKey.GetValue("Release")) == "0")
                    Console.Write("4.8");
                else
                    Console.Write("Не 4.8");
                System.Diagnostics.Process.Start(@"\\ta03\IPS.InstClient\Files\Framework\ndp48-x86-x64-allos-enu.exe");

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine(".NET Framework Version 4.5 or later is not detected.");
                Console.ReadKey();
            }
        }

    }


    // Checking the version using >= enables forward compatibility.
    static string CheckFor45PlusVersion(int releaseKey)
    {
        if (releaseKey >= 528040)
            // return "4.8 or later";
            return "0";
        if (releaseKey >= 461808)
            return "1";
        //return "4.7.2";
        if (releaseKey >= 461308)
            return "1";
        //return "4.7.1";
        if (releaseKey >= 460798)
            return "1";
        //return "4.7";
        if (releaseKey >= 394802)
            return "1";
        //return "4.6.2";
        if (releaseKey >= 394254)
            return "1";
        // return "4.6.1";
        if (releaseKey >= 393295)
            return "1";
        //return "4.6";
        if (releaseKey >= 379893)
            return "1";
        // return "4.5.2";
        if (releaseKey >= 378675)
            return "1";
        // return "4.5.1";
        if (releaseKey >= 378389)
            return "1";
        //return "4.5";

        // This code should never execute. A non-null release key should mean
        // that 4.5 or later is installed.
        // return "No 4.5 or later version detected";
        return "1";
    }
}