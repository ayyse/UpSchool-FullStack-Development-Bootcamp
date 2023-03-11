using static System.Runtime.InteropServices.JavaScript.JSType;

Console.WriteLine("**********   Password Generator   **********");
Console.WriteLine("Please answer Y/y or N/n.\n");

string password = "";

string numbers = "0123456789";
string lowercaseCharacters = "qwertyuıopğüasdfghjklşizxcvbnmöç";
string uppercaseCharacters = "QWERTYUIOPĞÜASDFGHJKLŞİZXCVBNMÖÇ";
string specialCharacters = "!'^+%&/()=?_-*}][{$#£><|/";



var number = "";
do
{
    Console.WriteLine("Do you want to include numbers to password?");
    number = Console.ReadLine();

    if (number == "Y" || number == "y")
        password += numbers;
    else if (number == "N" || number == "n")
        password += password;
    else
        Console.WriteLine("Please enter Y/y or N/n.");

} while ((number != "Y") & (number != "y") & (number != "N") & (number != "n"));



var lowercase = "";
do
{
    Console.WriteLine("\nDo you want to include lowercase characters to password?");
    lowercase = Console.ReadLine();

    if (lowercase == "Y" || lowercase == "y")
        password += lowercaseCharacters;
    else if (lowercase == "N" || lowercase == "n")
        password += password;
    else
        Console.WriteLine("Please enter Y/y or N/n.");

} while ((lowercase != "Y") & (lowercase != "y") & (lowercase != "N") & (lowercase != "n"));



var uppercase = "";
do
{
    Console.WriteLine("\nDo you want to include uppercase characters to password?");
    uppercase = Console.ReadLine();

    if (uppercase == "Y" || uppercase == "y")
        password += uppercaseCharacters;
    else if (uppercase == "N" || uppercase == "n")
        password += password;
    else
        Console.WriteLine("Please enter Y/y or N/n.");

} while ((uppercase != "Y") & (uppercase != "y") & (uppercase != "N") & (uppercase != "n"));


var special = "";
do
{
    Console.WriteLine("\nDo you want to special characters to password?");
    special = Console.ReadLine();

    if (special == "Y" || special == "y")
        password += specialCharacters;
    else if (special == "N" || special == "n")
        password += password;
    else
        Console.WriteLine("Please enter Y/y or N/n.");

} while ((special != "Y") & (special != "y") & (special != "N") & (special != "n"));


char[] stringChars;
var passwordLength = 0;
do
{
    Console.WriteLine("\nHow long is the password length?");
    passwordLength = Convert.ToInt32(Console.ReadLine());

    stringChars = new char[passwordLength];

    var random = new Random();

    for (int i = 0; i < passwordLength; i++)
    {
        stringChars[i] = password[random.Next(password.Length)]; // Next() metodu içinde max alabileceği değeri tutuyor
    }

    Console.WriteLine(stringChars);

} while (passwordLength > 40);




