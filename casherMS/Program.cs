namespace Casher {    
  class Program {        
    static void Main(string[] args) {            
      var process = new CasherProcess();            
      process.RunAsync(args).Wait();        
    }    
  }
}