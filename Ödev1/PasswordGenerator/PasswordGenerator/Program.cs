Console.WriteLine("**********   Password Generator   **********");
Console.WriteLine("Please answer yes or no.\n");

string password = "";

string numbers = "0123456789";
string lowercaseCharacters = "qwertyuıopğüasdfghjklşizxcvbnmöç";
string uppercaseCharacters = "QWERTYUIOPĞÜASDFGHJKLŞİZXCVBNMÖÇ";
string specialCharacters = "!'^+%&/()=?_-*}][{$#£><|/";

Console.WriteLine("Do you want to include numbers to password?");
var number = Console.ReadLine();

if (number == "yes" || number == "Yes")
    password += numbers;

Console.WriteLine("\nDo you want to include lowercase characters to password?");
var lowercase = Console.ReadLine();

if (lowercase == "yes" || lowercase == "Yes")
    password += lowercaseCharacters;

Console.WriteLine("\nDo you want to include uppercase characters to password?");
var uppercase = Console.ReadLine();

if (uppercase == "yes" || uppercase == "Yes")
    password += uppercaseCharacters;

Console.WriteLine("\nDo you want to special characters to password?");
var special = Console.ReadLine();

if (special == "yes" || special == "Yes")
    password += specialCharacters;

Console.WriteLine("\nHow long is the password length?");
var passwordLength = Convert.ToInt32(Console.ReadLine());

var stringChars = new char[passwordLength];

var random = new Random();

for (int i = 0; i < passwordLength; i++)
{
    stringChars[i] = password[random.Next(password.Length)]; // Next() metodu içinde max alabileceği değeri tutuyor
}

Console.WriteLine("\n" + stringChars);
