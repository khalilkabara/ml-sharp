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
            var traits = CreateMockTraits();
            var nodes = CreateMockNodes(traits);
            var f1 = new Generation {Nodes = nodes};

            var f1AsJson = f1.AsJson();

            // Save json file
            System.IO.File.WriteAllText(GetSavePath(), f1AsJson);
            // Console.WriteLine(GetSavePath(f1AsJson));
        }

        private static List<GeneticNode> CreateMockNodes(List<Trait> traits)
        {
            var alice = new GeneticNode("Alice", traits);
            var bob = new GeneticNode("Bob", traits);
            var charlie = new GeneticNode("Charlie", traits);
            var dave = new GeneticNode("Dave", traits);
            var ethan = new GeneticNode("Ethan", traits);
            var felix = new GeneticNode("Felix", traits);
            
            alice.AddTrait( new Trait("Size 2", 0.125f));

            var nodes = new List<GeneticNode>
            {
                alice,
                bob,
                charlie,
                dave,
                ethan,
                felix
            };
            
            return nodes;
        }

        private static List<Trait> CreateMockTraits()
        {
            var trait1 = new Trait("Size", 0.25f);
            var trait2 = new Trait("Color", 0.70f);
            var trait3 = new Trait("Color");

            var traits = new List<Trait> {trait1, trait2, trait3};

            return traits;
        }
        
        private static string GetSavePath()
        {
            var currentDirectory = System.IO.Directory.GetCurrentDirectory();
            var basePath = currentDirectory.Split(new string[] {"\\bin"}, StringSplitOptions.None)[0];
            return basePath + "/Tests/test_json.json";
        }
    }
}