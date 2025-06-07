using LibraryBusinessLayer.Interfaces;
using LiibraryDataAccessLayer.DTOs;
using LiibraryDataAccessLayer.Interfaces;
using LiibraryDataAccessLayer.Models;
using Org.BouncyCastle.Crypto.Generators;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;
    public UserService(IUserRepository repo) => _repo = repo;

    public List<UserDto> GetAll() =>
        _repo.GetAll().Select(u => new UserDto
        {
            UserID = u.UserId,
            Name = u.Name,
            ContactInformation = u.ContactInformation,
            LibraryCardNumber = u.LibraryCardNumber,
            Username = u.Username
        }).ToList();

    public UserDto? GetById(int id)
    {
        var u = _repo.GetById(id);
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

  

    public void Update(UserDto dto)
    {
        var user = _repo.GetById(dto.UserID);
        if (user == null) return;

        user.Name = dto.Name;
        user.ContactInformation = dto.ContactInformation;
        user.LibraryCardNumber = dto.LibraryCardNumber;
        user.Username = dto.Username;

        _repo.Update(user);
        _repo.Save();
    }

    public void Delete(int id)
    {
        _repo.Delete(id);
        _repo.Save();
    }
}