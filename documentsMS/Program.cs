namespace Documents {    
  class Program {        
    static void Main(string[] args) {            
      var process = new DocumentsProcess();            
      process.RunAsync(args).Wait();        
    }    
  }
}