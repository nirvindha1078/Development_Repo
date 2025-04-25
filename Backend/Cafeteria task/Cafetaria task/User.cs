using Cafetaria_task;
using System.Text.RegularExpressions;

public class User
{
    public void Checkout()
    {
        string name = GetUserInput("Enter your name:");
        if (!IsValidName(name))
        {
            Console.WriteLine("Invalid name. Name should contain only letters and spaces.");
            return;
        }

        string phoneNumber = GetUserInput("Enter your phone number:");
        if (!IsValidPhoneNumber(phoneNumber))
        {
            Console.WriteLine("Invalid phone number. Please enter a valid phone number (e.g., 1234567890).");
            return;
        }

        string email = GetUserInput("Enter your email:");

        if (!IsValidEmail(email))
        {
            Console.WriteLine("Invalid email address. Please enter a valid email.");
            return;
        }

        UserProfile.UserProfiles.Add(new UserProfile(name, phoneNumber, email));

        SelectDrink();
    }

    private string GetUserInput(string prompt)
    {
        string input;
        do
        {
            Console.WriteLine(prompt);
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty. Please try again.");
            }
        } while (string.IsNullOrWhiteSpace(input));

        return input;
    }

    private void SelectDrink()
    {
        Console.WriteLine("Please choose a drink:");
        Console.WriteLine("1. Tea");
        Console.WriteLine("2. Coffee");
        Console.WriteLine("3. Hot Chocolate");

        string drinkChoice = Console.ReadLine();
        string drinkType = string.Empty;

        switch (drinkChoice)
        {
            case "1":
                drinkType = "Tea";
                break;
            case "2":
                drinkType = "Coffee";
                break;
            case "3":
                drinkType = "Hot Chocolate";
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        string size = GetUserInput("Choose size: Small, Medium, Large");
        string milkType = GetUserInput("Choose milk type: Regular, Soy, Almond");

        int sugar = GetSugarAmount();

        bool wantsAdditionalOptions = GetAdditionalOptionsConfirmation();

        string additionalOptions = string.Empty;

        if (wantsAdditionalOptions)
        {
            additionalOptions = GetAdditionalOptions(drinkType);
        }
        else
        {
            additionalOptions = "-";  
        }

        Order order = new Order();

        order.OrderPrepared += () =>
        {
            Console.WriteLine("Order has been prepared and is ready!");
            Console.WriteLine("---------------------------------------------");
        };

        OrderPreparationDelegate orderPrepDelegate = order.PrepareOrder;

        orderPrepDelegate.Invoke(drinkType, size, milkType, sugar, additionalOptions);
    }

    private int GetSugarAmount()
    {
        int sugar = -1;
        while (sugar < 0)
        {
            Console.WriteLine("How many tablespoons of sugar?");
            string sugarInput = Console.ReadLine();

            try
            {
                sugar = int.Parse(sugarInput);
                if (sugar < 0)
                {
                    Console.WriteLine("Sugar cannot be negative. Please enter a valid amount.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number for sugar.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("The number is too large or too small. Please enter a valid amount of sugar.");
            }
        }
        return sugar;
    }

    private bool IsValidEmail(string email)
    {
        var emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        return emailRegex.IsMatch(email);
    }

    private bool IsValidName(string name)
    {
        var nameRegex = new Regex(@"^[a-zA-Z\s]+$");
        return nameRegex.IsMatch(name);
    }

    private bool IsValidPhoneNumber(string phoneNumber)
    {
        var phoneRegex = new Regex(@"^\d{10}$");
        return phoneRegex.IsMatch(phoneNumber);
    }

    private bool GetAdditionalOptionsConfirmation()
    {
        Console.WriteLine("Would you like to customize your drink with additional options? (yes/no)");

        string input = Console.ReadLine().ToLower();  

        while (input != "yes" && input != "no")
        {
            Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
            input = Console.ReadLine().ToLower();
        }

        return input == "yes"; 
    }


    private string GetAdditionalOptions(string drinkType)
    {
        string additionalOptions = string.Empty;

        if (drinkType == "Tea")
        {
            Console.WriteLine("Choose an additional option: Cardamon or Ginger");
            additionalOptions = GetUserInput("Cardamon or Ginger?");
        }
        else if (drinkType == "Coffee")
        {
            Console.WriteLine("Choose an additional option: Strong or Light");
            additionalOptions = GetUserInput("Strong or Light?");
        }
        else if (drinkType == "Hot Chocolate")
        {
            Console.WriteLine("Choose an additional option: With Ice Cream or Without Ice Cream");
            additionalOptions = GetUserInput("With Ice Cream or Without Ice Cream?");
        }

        return additionalOptions;
    }
}
