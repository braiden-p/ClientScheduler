using ClientScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientScheduler.Models;
using System.Transactions;
using Microsoft.EntityFrameworkCore;


namespace ClientScheduler.Services
{
    
    public class CustomerService
    {
        private readonly ClientScheduleContext _context;


        public CustomerService(ClientScheduleContext context) 
        {
            _context = context;
        }

        public List<Object> GetCustomersByCountry()
        {
            var customers = _context.Customers
            .Include(c => c.Address) // Load related Address
            .ThenInclude(a => a.City) // Load related City
            .ThenInclude(c => c.Country) // Load related Country
            .GroupBy(c => c.Address.City.Country.CountryName) // Group by Country
            .Select(g => new
            {
                Country = g.Key,
                CustomerCount = g.Count()
            })
            .ToList();
            return customers.Cast<object>().ToList();
        }

        public List<Object> GetAllCustomers()
        {
            var customers = _context.Customers
            .Include(c => c.Address) // Load related Address
            .ThenInclude(a => a.City) // Load related City
            .ThenInclude(c => c.Country) // Load related Country
            .Select(c => new
            {
                c.CustomerId,
                c.CustomerName, // Customer Name
                Address = $"{c.Address.Address1}",
                City = $"{c.Address.City.CityName}",
                Country = $"{c.Address.City.Country.CountryName}",
                ZipCode = $"{c.Address.PostalCode}",
                PhoneNumber = c.Address.Phone // Phone Number from Address
            })
            .OrderBy(c => c.CustomerId)
            .ToList();
            

            return customers.Cast<object>().ToList();
        }



        public void AddCustomer(string customerName, string street, string cityName, string countryName, string phone, string zip)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {

                    // Step 1: Check or Create Country
                    var country = _context.Countries.FirstOrDefault(c => c.CountryName == countryName);
                    if (country == null)
                    {
                        country = new Country { CountryName = countryName, CreateDate = DateTime.UtcNow, CreatedBy = "App", LastUpdate = DateTime.UtcNow, LastUpdateBy = "App" };
                        _context.Countries.Add(country);
                        _context.SaveChanges();
                    }

                    // Step 2: Check or Create City
                    var city = _context.Cities.FirstOrDefault(c => c.CityName == cityName && c.CountryId == country.CountryId);
                    if (city == null)
                    {
                        city = new City { CityName = cityName, CountryId = country.CountryId, CreateDate = DateTime.UtcNow, CreatedBy = "App", LastUpdate = DateTime.UtcNow, LastUpdateBy = "App" };
                        _context.Cities.Add(city);
                        _context.SaveChanges();
                    }

                    // Step 3: Check or Create Address
                    var address = _context.Addresses.FirstOrDefault(a => a.Address1 == street && a.CityId == city.CityId);
                    if (address == null)
                    {
                        address = new Address { Address1 = street, Address2 = "", CityId = city.CityId, PostalCode = zip, Phone = phone, CreateDate = DateTime.UtcNow, CreatedBy = "App", LastUpdate = DateTime.UtcNow, LastUpdateBy = "App" };
                        _context.Addresses.Add(address);
                        _context.SaveChanges();
                    }

                    // Step 4: Create Customer
                    var customer = new Customer { CustomerName = customerName, AddressId = address.AddressId, Active = true, CreateDate = DateTime.UtcNow, CreatedBy = "App", LastUpdate = DateTime.UtcNow, LastUpdateBy = "App" };
                    _context.Customers.Add(customer);
                    _context.SaveChanges();

                    // Commit transaction
                    transaction.Commit();
                    
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void DeleteCustomer(int customerId)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
                    if (customer != null)
                    {   
                        //Checking for appointments to delete first
                        var associatedAppointments = _context.Appointments.Where(a => a.CustomerId == customerId);
                        if (associatedAppointments != null)
                        {
                            _context.Appointments.RemoveRange(associatedAppointments);
                            _context.SaveChanges();
                        }
                        
                        _context.Customers.Remove(customer);
                        _context.SaveChanges();
                    }
                    transaction.Commit();

                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void ModifyCustomer(int customerId, string customerName, string street, string cityName, string countryName, string phone, string zip)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var country = _context.Countries.FirstOrDefault(c => c.CountryName == countryName);
                    if (country == null)
                    {
                        country = new Country { CountryName = countryName, CreateDate = DateTime.UtcNow, CreatedBy = "App", LastUpdate = DateTime.UtcNow, LastUpdateBy = "App" };
                        _context.Countries.Add(country);
                        _context.SaveChanges();
                    }

                    // Step 2: Check or Create City
                    var city = _context.Cities.FirstOrDefault(c => c.CityName == cityName && c.CountryId == country.CountryId);
                    if (city == null)
                    {
                        city = new City { CityName = cityName, CountryId = country.CountryId, CreateDate = DateTime.UtcNow, CreatedBy = "App", LastUpdate = DateTime.UtcNow, LastUpdateBy = "App" };
                        _context.Cities.Add(city);
                        _context.SaveChanges();
                    }

                    // Step 3: Check or Create Address
                    var address = _context.Addresses.FirstOrDefault(a => a.Address1 == street && a.CityId == city.CityId);
                    if (address == null)
                    {
                        address = new Address { Address1 = street, Address2 = "", CityId = city.CityId, PostalCode = zip, Phone = phone, CreateDate = DateTime.UtcNow, CreatedBy = "App", LastUpdate = DateTime.UtcNow, LastUpdateBy = "App" };
                        _context.Addresses.Add(address);
                        _context.SaveChanges();
                    }

                    var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
                    if (customer != null)
                    {
                        customer.CustomerName = customerName;
                        customer.Active = true;
                        customer.LastUpdate = DateTime.Now.ToUniversalTime();
                        customer.LastUpdateBy = "App";
                        customer.AddressId = address.AddressId;

                        _context.SaveChanges();
                    }



                    transaction.Commit();
                    DeleteOrphanData();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void DeleteOrphanData()
        {
            var orphanedAddresses = _context.Addresses
            .Where(a => !_context.Customers.Any(c => c.AddressId == a.AddressId))
            .ToList(); // Fetch orphaned addresses

            if (orphanedAddresses.Any()) // If there are any orphaned addresses, delete them
            {
                _context.Addresses.RemoveRange(orphanedAddresses);
                _context.SaveChanges();
            }


            var orphanedCities = _context.Cities
                .Where(c => !_context.Addresses.Any(a => a.CityId == c.CityId)) // Find cities without addresses
                .ToList();

            if (orphanedCities.Any()) // If there are orphaned cities, delete them
            {
                _context.Cities.RemoveRange(orphanedCities);
                _context.SaveChanges();
            }


        
            var orphanedCountries = _context.Countries
                .Where(c => !_context.Cities.Any(city => city.CountryId == c.CountryId)) // Find countries without cities
                .ToList();

            if (orphanedCountries.Any()) // If there are orphaned countries, delete them
            {
                _context.Countries.RemoveRange(orphanedCountries);
                _context.SaveChanges();
            }

        }



    }
}


