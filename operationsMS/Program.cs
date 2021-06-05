namespace Operations {    
  class Program {        
    static void Main(string[] args) {            
      var process = new OperationsProcess();            
      process.RunAsync(args).Wait();        
    }    
  }
}