namespace Users {    
  class Program {        
    static void Main(string[] args) {            
      var process = new UsersProcess();            
      process.RunAsync(args).Wait();        
    }    
  }
}