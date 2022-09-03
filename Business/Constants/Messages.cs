using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarAdded = "Car Added";
        public static string CarDeleted = "Car Deleted";
        public static string CarUpdated = "Car Updated";
        public static string CarListed = "Cars Are Listed";
        public static string CustomerAdded = "Customer Added";
        public static string CarDescriptionsInvalid = "The car description is invalid";
        public static string MaintenanceTime = "The System Is In Maintenance";
        public static string CarAlreadyRented = "The car rental process failed, the selected car was rented";
        public static string RentalSuccesful = "The Car rental process is successful";
        public static string CouldNotCarAdded = "Could Not Car Added ";
        public static string CarCountOfCategoryError = " Category Count be max 10 ";
        public static string CarDescriptionsAlreadyExist = "Description already exist";
        public static string BrandLimitExceded="Brand Limit exceded";
        public static string AuthorizationDenied = "AuthorizationDenied";
    }
}
