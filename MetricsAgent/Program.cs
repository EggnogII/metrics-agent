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

        // We basically want to take the information from Metric, JSONIFY it and send it to an external API service.
    }
}
