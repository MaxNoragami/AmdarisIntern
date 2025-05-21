using System.Text;
using System.Text.RegularExpressions;


string text = @"In object-oriented programming, encapsulation is a fundamental principle that involves bundling data and methods that operate on that data within a single unit or class. This concept allows for the hiding of implementation details from the outside world and exposing only the necessary interfaces for interacting with the object. By encapsulating data and methods together, we promote code reusability, maintainability, and flexibility.One of the key benefits of encapsulation is the ability to enforce access control on the members of a class. This means we can specify which parts of the class are accessible to the outside world and which are not. By using access modifiers such as public, private, and protected, we can control the visibility of members, ensuring that they are only accessed in appropriate ways. For example, we may have a class representing a bank account with properties such as balance and methods for depositing and withdrawing funds. By making the balance property private and providing public methods for depositing and withdrawing funds, we encapsulate the internal state of the account and ensure that it can only be modified in a controlled manner. Encapsulation also allows us to enforce data validation and maintain invariants within our classes. By providing controlled access to data through methods, we can ensure that it is always in a valid state. For instance, when setting the balance of a bank account, we can check that the new balance is not negative before updating the internal state of the object. Overall, encapsulation is a powerful concept in object-oriented programming that promotes modularity, reusability, and maintainability. By bundling data and methods together within a class and controlling access to them, we can create more robust and flexible software systems.";

//- 1. Display the word count of this string
//- 2. Display the sentence count of this string
//- 3. Display how often the word "encapsulation" appears in this string
//- 4. Display this string in reverse, without using any C# language feature. (Create your own algorithm)
//- 5. In the given string, replace all occurances of "object-oriented programming" with "OOP" and display the new string

Console.WriteLine($"1. Word Count: {WordCountRegex(text)}\n");
Console.WriteLine($"2. Sentence Count: {SentenceCountRegex(text)}\n");
Console.WriteLine($"3. Occurences of 'encapsulation': {WordOccurrencesRegex(text)}\n");
Console.WriteLine($"4. Reverse String: {ReverseString(text)}\n");
Console.WriteLine($"5. Replace String: {ReplaceString(text)}\n");


// Word Count
int WordCountRegex(string inputText)
    => Regex.Replace(inputText, @"[,.!?]+", string.Empty).Split(' ', '-').Length;

int WordCount(string inputText)
{
    foreach(var symbol in new List<char>() { ',', '.', '!', '?' }) inputText.Replace(symbol, '\0');
    return inputText.Split(' ', '-').Length;
}

// Sentence Count
int SentenceCountRegex(string inputText)
    => Regex.Matches(inputText, @"[.?!]+").Count;

int SentenceCount(string inputText)
{
    var sentenceCount = 0;
    foreach (var symbol in inputText)
    {
        if(symbol == '.' || symbol == '!' || symbol == '?') sentenceCount += 1;
    }
    return sentenceCount;  
}

// Word Occurrences
int WordOccurrencesRegex(string inputText, string word = "encapsulation")
    => Regex.Matches(inputText.ToLower(), @"(" + word.ToLower() + @")").Count;

int WordOccurrences(string inputText, string word = "encapsulation")
{
    var occurrences = 0;

    foreach (var symbol in new List<char>() { ',', '.', '!', '?' }) inputText.Replace(symbol, '\0');
    var words = inputText.Split(' ', '-');

    foreach (var w in words)
    {
        if (string.Equals(w, word, StringComparison.OrdinalIgnoreCase)) occurrences += 1;
    }

    return occurrences;
}

// ReverseString
string ReverseString(string inputText)
{
    var reversedText = new StringBuilder();
    for (var i = inputText.Length - 1; i >= 0; i--) reversedText.Append(inputText[i]);
    return reversedText.ToString();
}

// Replace String
string ReplaceString(string inputText, string replaceable = "object-oriented programming", string replacement = "OOP")
    => Regex.Replace(inputText.ToLower(), @"(" + replaceable.ToLower() + @")", replacement);
