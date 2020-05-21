using System;

namespace ml_sharp.Utils
{
    public static class RandomUtility
    {
        /// <summary>
        /// Generates a random int value between 0 and 1 both inclusive.
        /// </summary>
        /// <param name="seed">Seed for random generator. This is useful when trying to recreate outputs.</param>
        /// <returns>Returns 0 or 1</returns>
        public static int GetRandomBinary(int seed = 0)
        {
            return seed == 0 ? new Random().Next(0, 2) : new Random(seed).Next(0, 2);
        }
        
        /// <summary>
        /// Generates a random float value between 0 and 1 both inclusive.
        /// </summary>
        /// <param name="seed">Seed for random generator. This is useful when trying to recreate outputs.</param>
        /// <returns>Returns a float that is between 0 and 1 both inclusive</returns>
        public static float GetRandom01(int seed = 0)
        {
            return seed == 0 ? (float) new Random().NextDouble() : (float) new Random(seed).NextDouble();
        }
    }
}