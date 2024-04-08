using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;

namespace Infrastructure.Services;

public class AddressService(AddressRepository repository, UserManager<UserEntity> userManager)
{
    private readonly AddressRepository _repository = repository;

    private readonly UserManager<UserEntity> _userManager = userManager;

    public async Task<bool> CreateAddressAsync(AddressModel addressModel)
    {
        try
        {
            var addressEntity = new AddressEntity
            {
                UserId = addressModel.UserId,
                StreetName = addressModel.StreetName,
                SteetName_2 = addressModel.StreetName_2, 
                PostalCode = addressModel.PostalCode,
                City =  addressModel.City
            };

            var createdAddress = await _repository.CreateOneAsync(addressEntity);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return false;
    }


    public async Task<AddressModel> GetAddressAsync(string userId)
    {
        try
        {
            var userAddress = await _repository.GetOneAsync(x => x.UserId == userId);
            if (userAddress != null)
            {
                var addressModel = new AddressModel
                {
                    StreetName = userAddress.StreetName,
                    StreetName_2 = userAddress.SteetName_2,
                    PostalCode = userAddress.PostalCode,
                    City = userAddress.City,

                };

                return addressModel;
            }

            return null!;
                
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public async Task<bool> UpdateAddressAsync(AddressModel updatedAddressModel, string userId)
    {
        try
        {
            var address = await _repository.GetOneAsync(x => x.UserId == userId);
            if (address != null)
            {
                var addressEntity = await _repository.GetOneAsync(x => x.UserId == userId);
                addressEntity.StreetName = updatedAddressModel.StreetName;
                addressEntity.SteetName_2 = updatedAddressModel.StreetName_2;
                addressEntity.PostalCode = updatedAddressModel.PostalCode;
                addressEntity.City = updatedAddressModel.City;

                var updatedAddress = await _repository.UpdateOneAsync(a => a.UserId == addressEntity.UserId, addressEntity);

                return updatedAddress != null;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return false;
    }
}





