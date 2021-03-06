﻿using System;
using System.Collections.Generic;
using System.Text.Json;
using ml_sharp.Genetics;
using ml_sharp.Genetics.Entities;
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

        private static List<GeneticEntity> CreateMockNodes(List<Trait> traits)
        {
            var alice = new GeneticEntity("Alice", traits);
            var bob = new GeneticEntity("Bob", traits);
            var charlie = new GeneticEntity("Charlie", traits);
            var dave = new GeneticEntity("Dave", traits);
            var ethan = new GeneticEntity("Ethan", traits);
            var felix = new GeneticEntity("Felix", traits);
            
            alice.AddTrait( new Trait("Size 2", 0.125f));

            var nodes = new List<GeneticEntity>
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
            var trait4 = new Trait();

            var traits = new List<Trait> {trait1, trait2, trait3, trait4};

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