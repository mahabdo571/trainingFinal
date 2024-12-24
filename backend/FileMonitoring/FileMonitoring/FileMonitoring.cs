using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace FileMonitoring
{
    public partial class FileMonitoring : ServiceBase
    {
        // Configuration values for source, destination, and log folders
        public static string sourceFolder = ConfigurationManager.AppSettings["SourceFolder"];
        public static string DestinationFolder = ConfigurationManager.AppSettings["DestinationFolder"];
        public static string LogFolder = ConfigurationManager.AppSettings["LogFolder"];
        FileSystemWatcher watcher;
        public FileMonitoring()
        {
            InitializeComponent(); // Initialize service components
            watcher = new FileSystemWatcher(); // Initialize file system watcher
        }

        protected override void OnStart(string[] args)
        {
            LogEvent("Service Started"); // Log the service start
            if (Environment.UserInteractive) // Check if running in console mode
            {
                _monitor(); // Start monitoring files
                Console.WriteLine("Monitoring started. Press Enter to exit.");
                Console.ReadLine(); // Wait for user input to exit
            }

            _monitor(); // Start monitoring files
        }

        protected override void OnStop()
        {
            watcher.IncludeSubdirectories = false;
            watcher.Dispose();
            LogEvent("Service Stopped"); // Log the service stop
        }

        private void _monitor()
        {
            

            if (!string.IsNullOrEmpty(sourceFolder)) // Validate source folder
            {
                try
                {
                    if (!Directory.Exists(sourceFolder)) // Check if folder exists
                    {
                        Directory.CreateDirectory(sourceFolder); // Create folder if not existing
                    }
                }
                catch (Exception ex)
                {
                    LogEvent(ex.Message); // Log any exception
                    return;
                }
            }

            watcher.Path = sourceFolder; // Set folder to monitor

            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.Size; // Set filters for monitoring

            watcher.Created += OnCreated; // Add event handler for file creation

            watcher.EnableRaisingEvents = true; // Enable events
        }

        private static void OnCreated(object source, FileSystemEventArgs e)
        {
            LogEvent("File Created"); // Log file creation event

            string fileName = Path.GetFileName(e.FullPath); // Extract file name

            string fileExtension = Path.GetExtension(e.FullPath); // Extract file extension

            string newFileName = $"{Guid.NewGuid()}{fileExtension}"; // Generate new unique file name

            if (!string.IsNullOrEmpty(DestinationFolder)) // Validate destination folder
            {
                try
                {
                    if (!Directory.Exists(DestinationFolder)) // Check if folder exists
                    {
                        Directory.CreateDirectory(DestinationFolder); // Create folder if not existing
                    }
                }
                catch (Exception ex)
                {
                    LogEvent(ex.Message); // Log any exception
                    return;
                }
            }

            string newFilePath = Path.Combine(Path.GetDirectoryName(DestinationFolder), newFileName); // Construct new file path

            try
            {
                File.Move(e.FullPath, newFilePath); // Move the file to the destination
                LogEvent($"File deleted from ({sourceFolder})"); // Log file deletion from source
                LogEvent($"File moved from {e.FullPath} -> {newFilePath}"); // Log file movement
            }
            catch (Exception ex)
            {
                LogEvent(ex.Message); // Log any exception
            }
        }

        static void LogEvent(string message)
        {
            try
            {
                if (!Directory.Exists(LogFolder)) // Check if log folder exists
                {
                    Directory.CreateDirectory(LogFolder); // Create log folder if not existing
                }

                string filePath = $"{LogFolder}/logs.txt"; // Define log file path

                using (StreamWriter writer = new StreamWriter(filePath, true)) // Open log file for writing
                {
                    writer.WriteLine($"[{DateTime.Now}] {message}"); // Write log message with timestamp
                }
            }
            catch (Exception ex)
            {
                // Log file write failures (disabled in this example)
            }
        }

        public void startConsole()
        {
            OnStart(null); // Start the service in console mode
            Console.WriteLine("Press enter to stop the service"); // Prompt user to stop the service
            Console.ReadLine(); // Wait for user input to stop
            OnStop(); // Stop the service
            Console.ReadKey(); // Wait for user key press
        }
    }
}
