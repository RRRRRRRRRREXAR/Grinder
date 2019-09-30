using AutoMapper;
using Grinder.BLL.DTO;
using Grinder.BLL.Interfaces;
using Grinder.BLL.MapProfile;
using Grinder.DAL.Entities;
using Grinder.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Grinder.BLL.Services
{
    public class AuthorizationService : IAutharizationService
    {
        readonly IUnitOfWork unit;
        readonly MapperConfiguration config = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new UserProfile());
        });
        public AuthorizationService(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public async Task<UserDTO> GetUserByEmail(string email)
        {
            var mapper = new Mapper(config);
            UserDTO foundedUser = mapper.Map<UserDTO>(await unit.Users.Find(us => us.Email == email));
            return foundedUser;
        }

        public async Task<UserDTO> Login(string password, string email)
        {
            var mapper = new Mapper(config);
            UserDTO foundedUser = mapper.Map<UserDTO>(await unit.Users.Find(us=>us.Email==email));
            if (VerifyHash(password,foundedUser.Password))
            {
                return foundedUser;
            }
            return null;
        }

        public async Task Register(UserDTO user)
        {
            var mapper = new Mapper(config);
            user.Password =ComputeHash(user.Password);
            await unit.Users.Create(mapper.Map<User>(user));
            unit.Save();
        }

        private string ComputeHash(string plainText)
        {
            int minSaltSize = 4;
            int maxSaltSize = 8;
            Random random = new Random();
            int saltSize = random.Next(minSaltSize, maxSaltSize);
            byte[] saltBytes = new byte[saltSize];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(saltBytes);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] plainTextWithSaltBytes = new byte[plainTextBytes.Length+saltBytes.Length];
            for (int i = 0; i < plainTextBytes.Length; i++)
                plainTextWithSaltBytes[i] = plainTextBytes[i];
            for (int i = 0; i < saltBytes.Length; i++)
                plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];
            HashAlgorithm hash = new SHA256Managed();
            byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);
            byte[] hashWithSaltBytes = new byte[hashBytes.Length + saltBytes.Length];
            for (int i = 0; i < hashBytes.Length; i++)
                hashWithSaltBytes[i] = hashBytes[i];
            for (int i = 0; i < saltBytes.Length; i++)
                hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];
            string hashValue = Convert.ToBase64String(hashWithSaltBytes);
            return hashValue;
        }

        private bool VerifyHash(string plainText,string hashValue)
        {
            byte[] hashWithSaltBytes = Convert.FromBase64String(hashValue);
            int hashSizeInBits;
            int hashSizeInBytes;
            hashSizeInBits = 256;
            hashSizeInBytes = hashSizeInBits / 8;
            if (hashWithSaltBytes.Length < hashSizeInBytes)
            {
                return false;
            }
            byte[] saltBytes = new byte[hashWithSaltBytes.Length - hashSizeInBytes];
            for (int i = 0; i < saltBytes.Length; i++)
            {
                saltBytes[i] = hashWithSaltBytes[hashSizeInBytes + i];
            }

            string expectedHashString = ComputeHash(plainText);
            return (hashValue == expectedHashString);
        }
    }
}
