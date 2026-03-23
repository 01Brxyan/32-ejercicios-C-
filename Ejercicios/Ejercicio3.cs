using System;

class Program
{
    static void Main()
    {
        string password = GeneratePassword();
        Console.WriteLine("Contraseña generada:");
        Console.WriteLine(password);
    }

    static string GeneratePassword()
    {
        Random random = new Random();

        string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string lower = "abcdefghijklmnopqrstuvwxyz";
        string digits = "0123456789";
        string special = "!@#$%&*?+=-/";

        string all = upper + lower + digits + special;

        int length = random.Next(15, 88); // entre 15 y 87

        char[] password = new char[length];

        // Asegurar mínimo 1 de cada tipo
        password[0] = upper[random.Next(upper.Length)];
        password[1] = lower[random.Next(lower.Length)];
        password[2] = digits[random.Next(digits.Length)];
        password[3] = special[random.Next(special.Length)];

        // Rellenar el resto
        for (int i = 4; i < length; i++)
        {
            password[i] = all[random.Next(all.Length)];
        }

        // Mezclar (para que no queden siempre al inicio)
        for (int i = 0; i < password.Length; i++)
        {
            int j = random.Next(password.Length);
            char temp = password[i];
            password[i] = password[j];
            password[j] = temp;
        }

        return new string(password);
    }
}