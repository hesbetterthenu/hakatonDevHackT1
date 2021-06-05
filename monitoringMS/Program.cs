namespace Monitoring {    
  class Program {        
    static void Main(string[] args) {            
      var process = new MonitoringProcess();            
      process.RunAsync(args).Wait();        
    }    
  }
}