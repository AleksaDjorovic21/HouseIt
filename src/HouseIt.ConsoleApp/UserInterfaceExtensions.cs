using System.ComponentModel;

namespace HouseIt.ConsoleApp;

public static class UserInterfaceExtensions
{
    public static T GetValueFromUser<T>(this IUserInterface userInterface, string message, string errorMessage = "Wrong entry!")
    {
        userInterface.WriteLine(message);
        var value = userInterface.ReadLine();

        if (value.TryConvert(out T? convertedValue) && convertedValue != null)
        {
            return convertedValue;
        }

        userInterface.WriteLine(errorMessage);

        return userInterface.GetValueFromUser<T>(message, errorMessage);
    }

    public static bool TryConvert<T>(this string? value, out T? convertedValue)
    {
        convertedValue = default;

        if (string.IsNullOrEmpty(value))
        {
            return false;
        }

        var type = typeof(T);
        var converter = TypeDescriptor.GetConverter(type);

        if (converter.IsValid(value))
        {
            convertedValue = (T?)converter.ConvertFromString(value);
            return true;
        }

        return false;
    }
}

