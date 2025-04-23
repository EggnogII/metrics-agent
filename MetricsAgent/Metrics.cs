using System;
using System.Diagnostics;
using System.Management;

class Drive{
    public string Name {get; set;}
    public string Type {get; set;}
    public string Volume {get; set;}
    public string FileSystem {get; set;}
    public long AvailableFreeSpace {get; set;}
    public long TotalSpace {get; set;}
    public long UsedSpace {get; set;}

    public Drive(DriveInfo driveInfo) 
    {
        Name = driveInfo.Name;
        Type = driveInfo.DriveType.ToString();
        Volume = driveInfo.VolumeLabel;
        FileSystem = driveInfo.DriveFormat;
        AvailableFreeSpace = driveInfo.AvailableFreeSpace;
        TotalSpace = driveInfo.TotalSize;
        UsedSpace = TotalSpace - AvailableFreeSpace;
    }

}

class Metric{
    public string HostName { get; set; }
    public int ProcessorCount { get; set; }
    public string OSVersion { get; set; }
    
    public float CPULoad {get; set;}
    public long TotalPhysicalMemory { get; set; }
    public long AvailablePhysicalMemory { get; set; }


    public Metric()
    {
        HostName = Environment.MachineName;
        ProcessorCount = Environment.ProcessorCount;
        OSVersion = Environment.OSVersion.ToString();

        // Query system memory information
        GetMemoryLoad();
        CPULoad = GetCPULoad();
    }

    private void GetMemoryLoad()
    {
        var query = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
        foreach (var obj in query.Get())
        {
            TotalPhysicalMemory = Convert.ToInt64(obj["TotalVisibleMemorySize"]) * 1024;
            AvailablePhysicalMemory = Convert.ToInt64(obj["FreePhysicalMemory"]) * 1024;
        }
    }

    private float GetCPULoad(){
        var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        Thread.Sleep(1000); // Wait a second to get a valid reading
        float cpuLoad = cpuCounter.NextValue();
        Thread.Sleep(1000);
        cpuLoad = cpuCounter.NextValue();
        return cpuLoad;
    }
}