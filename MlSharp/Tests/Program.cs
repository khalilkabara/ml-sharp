using System;
using System.Collections.Generic;
using System.IO;
using ml_sharp.Enums.Genetics;
using ml_sharp.Genetics.Entities;
using ml_sharp.Utils;

namespace ml_sharp.Tests
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var traits = CreateMockTraits();
            var entities = CreateMockEntities(traits);
            var f1 = new Generation {Entities = entities};

            // new GeneticEntity().ReproduceBatch(13, 0.1f, .9f,)
            // Save json file
            MlsSerializationUtil.Persist(f1, GetSavePath("test_json"));

            var alice = entities[0];
            var bob = entities[1];

            // var sonOfAlice = alice.ReproduceOne(0.75f,
            //     EMutationEffect.Random,
            //     "Son Of Alice");

            var sonOfAlice = alice.ReproduceOneWithPartner(bob,
                .45f,
                EMutationEffect.Random,
                "Bobbie Jr",
                true);

            MlsSerializationUtil.Persist(sonOfAlice, GetSavePath("son_of_alice"));
            // Console.WriteLine(sonOfAlice.AsJson());
        }

        private static void TestRandoms()
        {
            var rands = new int[10];
            var randsf = new float[10];

            for (var i = 0; i < rands.Length; i++)
            {
                rands[i] = MlsMathUtil.GetRandomBinary(40);
                randsf[i] = MlsMathUtil.GetRandom01(42);
            }

            foreach (var rand in rands) Console.Write(rand + ", ");

            Console.WriteLine();
            foreach (var rand in randsf) Console.Write(rand + ", ");
        }

        private static List<GeneticEntity> CreateMockEntities(List<Trait> traits)
        {
            var alice = new GeneticEntity("Alice", traits);
            var bob = new GeneticEntity("Bob", traits);
            var charlie = new GeneticEntity("Charlie", traits);
            var dave = new GeneticEntity("Dave", traits);
            var ethan = new GeneticEntity("Ethan", traits);
            var felix = new GeneticEntity("Felix", traits);

            alice.AddTrait(new Trait("Unique To Alice", 0.125f));
            bob.AddTrait(new Trait("Unique To Bobby", 0.533f));

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
            var trait3 = new Trait();

            var traits = new List<Trait> {trait1, trait2, trait3};

            return traits;
        }

        private static string GetSavePath(string fileName)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var basePath = currentDirectory.Split(new[] {"\\bin"}, StringSplitOptions.None)[0];

            return basePath + "/Tests/" + fileName + ".json";
        }
    }
}