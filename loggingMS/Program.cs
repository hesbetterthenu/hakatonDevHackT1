namespace Logging {    
  class Program {        
    static void Main(string[] args) {            
      var process = new LoggingProcess();            
      process.RunAsync(args).Wait();        
    }    
  }
}