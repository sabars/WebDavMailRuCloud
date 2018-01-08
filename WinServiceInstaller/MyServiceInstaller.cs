﻿using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace WinServiceInstaller
{
    [RunInstaller(true)]
    public class MyServiceInstaller : Installer
    {
        public MyServiceInstaller()
        {
            // Instantiate installers for process and services.
            var processInstaller = new ServiceProcessInstaller
            {
                Account = ServiceAccount.LocalSystem
            };

            var serviceInstaller = new ServiceInstaller
            {
                StartType = ServiceStartMode.Automatic,
                ServiceName = ServiceName,
                DisplayName = DisplayName,
                Description = Description
            };

            Installers.Add(serviceInstaller);
            Installers.Add(processInstaller);
        }

        public static string ServiceName { get; set; }
        public static string DisplayName { get; set; }
        public static string Description { get; set; }
    }
}