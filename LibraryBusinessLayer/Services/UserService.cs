using LibraryBusinessLayer.Interfaces;
using LiibraryDataAccessLayer.DTOs;
using LiibraryDataAccessLayer.Interfaces;
using LiibraryDataAccessLayer.Models;
using Org.BouncyCastle.Crypto.Generators;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;
    public UserService(IUserRepository repo) => _repo = repo;

    public async Task<List<UserDto>> GetAllAsync()
    {
        var user = await _repo.GetAllAsync();
        return user.Select(u => new UserDto
        {
            UserID = u.UserId,
            Name = u.Name,
            ContactInformation = u.ContactInformation,
            LibraryCardNumber = u.LibraryCardNumber,
            Username = u.Username
        }).ToList();
    }

    public async Task <UserDto?> GetByIdAsync(int id)
    {
        var u = await _repo.GetByIdAsync(id);
        if (u == null) return null;

        return new UserDto
        {
            UserID = u.UserId,
            Name = u.Name,
            ContactInformation = u.ContactInformation,
            LibraryCardNumber = u.LibraryCardNumber,
            Username = u.Username
        };
    }

  

    public async Task UpdateAsync(UserDto dto)
    {
        var user = await _repo.GetByIdAsync(dto.UserID);
        if (user == null) return;

        user.Name = dto.Name;
        user.ContactInformation = dto.ContactInformation;
        user.LibraryCardNumber = dto.LibraryCardNumber;
        user.Username = dto.Username;

      await  _repo.UpdateAsync(user);
       await _repo.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
       await _repo.DeleteAsync(id);
     await   _repo.SaveAsync();
    }
}