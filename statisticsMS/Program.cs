namespace Statistics {    
  class Program {        
    static void Main(string[] args) {            
      var process = new StatisticsProcess();            
      process.RunAsync(args).Wait();        
    }    
  }
}