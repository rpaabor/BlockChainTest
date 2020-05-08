using System;
using Newtonsoft.Json;

namespace Blockchain_test
{
    class Program
    {
        static void Main(string[] args)
        {
            BlockChain chain = new BlockChain();
            chain.AddBlock(new Block(DateTime.Now, null,"{sender:Joe,reciver:Adam,amount:100"));
            chain.AddBlock(new Block(DateTime.Now, null, "{sender:Adam,reciver:Joe,amount:200"));
            chain.AddBlock(new Block(DateTime.Now, null, "{sender:Joe,reciver:Adam,amount:300"));
            Console.WriteLine(JsonConvert.SerializeObject(chain));

            Console.WriteLine($"Is Chain Valid: {chain.IsValid()}");

            Console.ReadKey();
            Console.WriteLine("Tampering with chain");
            chain.Chain[1].Data = "{sender:Robban,reciver:Linus,amount:101";
            Console.WriteLine($"Is Chain Valid: {chain.IsValid()}");


            Console.ReadKey();
        }
    }
}
