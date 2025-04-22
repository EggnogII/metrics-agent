using System;
using System.Diagnostics;
using System.Management;


class Metric{
    public string HostName { get; set; }
    public int ProcessorCount { get; set; }
    public string OSVersion { get; set; }
    public long TotalPhysicalMemory { get; set; }
    public long AvailablePhysicalMemory { get; set; }

    public Metric(){
        HostName = Environment.MachineName;
        ProcessorCount = Environment.ProcessorCount;
        OSVersion = Environment.OSVersion.ToString();
        
        // Query system memory information
        var query = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
        foreach (var obj in query.Get()){
            TotalPhysicalMemory = Convert.ToInt64(obj["TotalVisibleMemorySize"]) * 1024; 
            AvailablePhysicalMemory = Convert.ToInt64(obj["FreePhysicalMemory"]) * 1024; 
        }
    }

}