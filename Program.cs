namespace HashTable
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hash Table Program");

            string sentence = "To be or not to be";
            string[] words = sentence.Split(' ');

            FindWordFrequency<string, int> frequency = new FindWordFrequency<string, int>(words.Length);

            foreach (string word in words)
            {
                int count = frequency.Get(word);
                if (count == default(int))
                {
                    count = 0;
                }
                frequency.Add(word, count + 1);
            }

            frequency.Display();

        }


    }
}