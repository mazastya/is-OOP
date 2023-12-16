using System.Security.Cryptography;
using System.Text;

namespace Models.Users;

public class HashPassword
{
    private readonly string _password;

    public HashPassword(string password)
    {
        _password = password;
    }

    public string CreateHash()
    {
#pragma warning disable CA1305
#pragma warning restore CA1305
        byte[] data =
#pragma warning disable CA5351
            MD5.HashData(Encoding.UTF8.GetBytes(_password)); // Преобразуем сообщение в байтовый массив и вычисляем хэш
#pragma warning restore CA5351

        var builder = new StringBuilder(); // Создаем StringBuilder для хранения хэш-строки

        // Конвертируем каждый байт хэша в его шестнадцатеричное представление и добавляем в StringBuilder
        for (int i = 0; i < data.Length; i++)
        {
#pragma warning disable CA1305
            builder.Append(data[i].ToString($"x2"));
#pragma warning restore CA1305
        }

        string md5HashString = builder.ToString(); // Получаем строку с хэшем
        return md5HashString;
    }
}