using System;

namespace HackerRank._30DaysOfCode
{
    public class ClassVsInstance
    {
        public class Person
        {
            public int age;
            public Person(int initialAge)
            {
                this.Age = initialAge;
            }

            public int Age
            {
                get => this.age;
                set
                {
                    if (value < 0)
                    {
                        Console.WriteLine("Age is not valid, setting age to 0.");
                        this.age = 0;
                    }
                    else
                    {
                        this.age = value;
                    }
                }
            }
            public void amIOld()
            {
                var text = "";

                if (age < 13)
                {
                    text = "You are young.";
                } else if (age >= 13 && age < 18)
                {
                    text = "You are a teenager.";
                }
                else
                {
                    text = "You are old.";
                }

                Console.WriteLine(text);
            }

            public void yearPasses()
            {
                this.Age++;
            }
        }

    }
}
