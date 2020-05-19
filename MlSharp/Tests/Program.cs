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
            traits.Add(new Trait("Size", 0.25f));
            traits.Add(new Trait(0.70f));
            traits.Add(new Trait());
            var geneticNode = new GeneticNode(traits);

            var nodeAsDict = geneticNode.NodeAsDictionary();
            Console.WriteLine(SerializationUtility.DictionaryToJson(nodeAsDict));
        }
    }
}