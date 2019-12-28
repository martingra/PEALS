using System;
using System.Security.Cryptography;

namespace Peals.Utiles
{
    public class Password
    {
        #region Encrypt/ Decrypt Password

        /// <summary>
        /// Encripta una contraseña (pasada por parámetro) en SHA256.
        /// </summary>
        /// <param name="password">Contraseña a encriptar.</param>
        /// <returns>Devuelve la contraseña encriptada en SHA256.</returns>
        public static string HashPassword(string password)
        {
            // aplico el algoritmo de encriptado.
            return ComputeHash(password, new SHA256CryptoServiceProvider());
        }

        /// <summary>
        /// Verifica si las contraseñas son iguales.
        /// </summary>
        /// <param name="hashPass">Contraseña encriptada.</param>
        /// <param name="password">Contraseña sin encriptar.</param>
        /// <returns>Devuelve "True" si coinciden y "False" en caso contrario.</returns>
        public static bool CheckPassword(string hashPass, string password)
        {
            return string.Equals(hashPass, ComputeHash(password, new SHA256Managed()));
        }

        /// <summary>
        /// Aplica un algoritmo de encriptado a un texto pasado por parámetro.
        /// </summary>
        /// <param name="input">Texto a encriptar.</param>
        /// <param name="algorithm">Algoritmo que se aplicara</param>
        /// <returns>Devulve el texto encriptado</returns>
        private static string ComputeHash(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes).Replace("-", "");
        }

        #endregion
    }
}