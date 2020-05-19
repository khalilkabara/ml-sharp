using System;
using System.Collections.Generic;
using System.Text.Json;
using ml_sharp.Genetics;
using ml_sharp.Utils;

namespace ml_sharp.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var traits = new List<Trait>();
            var trait1 = new Trait("Size", 0.25f);
            var trait2 = new Trait("Color",0.70f);
            var trait3 = new Trait("Color");
            
            traits.Add(trait1);
            traits.Add(trait2);
            traits.Add(trait3);
            var geneticNode = new GeneticNode(traits);

            // var nodeAsDict = geneticNode.AsDictionary();
            Console.WriteLine(geneticNode.Id);
            // Console.WriteLine(SerializationUtility.DictionaryToJson(nodeAsDict));
            Console.WriteLine(geneticNode.AsJson());
        }
    }
}