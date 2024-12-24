using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace FileMonitoring
{
    [RunInstaller(true)] // Mark this class as a service installer
    public partial class InstallerFileMonit : System.Configuration.Install.Installer
    {
        private ServiceProcessInstaller _serviceProcessInstaller;
        private ServiceInstaller _serviceInstaller;

        public InstallerFileMonit()
        {
            InitializeComponent(); // Initialize installer components

            _serviceProcessInstaller = new ServiceProcessInstaller
            {
                Account = ServiceAccount.LocalService // Set the service account type
            };

            _serviceInstaller = new ServiceInstaller
            {
                ServiceName = "FileMonitoringService", // Set the service name
                DisplayName = "File Monitoring Service", // Set the display name
                Description = "This service monitors files and moves them to a new folder with a unique name", // Set the description
                StartType = ServiceStartMode.Automatic, // Set service start type
                ServicesDependedOn=new string[] {"RpcSs","EventLog","LanmanWorckStation"}
            };

            Installers.Add(_serviceProcessInstaller); // Add process installer
            Installers.Add(_serviceInstaller); // Add service installer
        }
    }
}