// See https://aka.ms/new-console-template for more information
using System;

class MetricsAgent
{
    static void Main(string[] args)
    {
        // Create an instance of the Metric class
        Metric metric = new Metric();

        // Display the metrics
        Console.WriteLine($"Host Name: {metric.HostName}");
        Console.WriteLine($"Processor Count: {metric.ProcessorCount}");
        Console.WriteLine($"OS Version: {metric.OSVersion}");
        Console.WriteLine($"Total Physical Memory: {metric.TotalPhysicalMemory / (1024 * 1024)} MB");
        Console.WriteLine($"Available Physical Memory: {metric.AvailablePhysicalMemory / (1024 * 1024)} MB");
        Console.WriteLine($"CPU Load: {metric.CPULoad} %");
        Console.WriteLine("Drives:");
        foreach (var drive in metric.Drives)
        {
            Console.WriteLine($"  Drive Name: {drive.Name}");
            Console.WriteLine($"  Drive Type: {drive.Type}");
            Console.WriteLine($"  Volume: {drive.Volume}");
            Console.WriteLine($"  File System: {drive.FileSystem}");
            Console.WriteLine($"  Available Free Space: {drive.AvailableFreeSpace / (1024 * 1024)} MB");
            Console.WriteLine($"  Total Space: {drive.TotalSpace / (1024 * 1024)} MB");
            Console.WriteLine($"  Used Space: {drive.UsedSpace / (1024 * 1024)} MB");
            Console.WriteLine();
        }

        // We basically want to take the information from Metric, JSONIFY it and send it to an external API service.
    }
}
