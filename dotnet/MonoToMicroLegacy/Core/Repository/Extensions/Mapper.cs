using MonoToMicroLegacy.Models;

namespace MonoToMicroLegacy.Core.Repository.Extensions
{
    public static class Mapper
    {
        private static void MapBaseModel(BaseModel serviceModel, Data.Models.BaseModel model)
        {
            serviceModel.Active = model.Active == 1;
            serviceModel.Id = model.Id;
            serviceModel.CreatedByUserId = model.CreatedByUserId;
            serviceModel.CreationDate = model.CreationDate;
            serviceModel.LastModifiedDate = model.LastModifiedDate;
            serviceModel.LastModifiedByUserId = model.LastModifiedByUserId;
        }
        public static Unicorn ToModel(this Data.Models.Unicorn model)
        {
            var u = new Unicorn()
            {
                Name = model.Name,
                Uuid = model.Uuid,
                Description = model.Description,
                Price = (double?)model.Price,
                Image =  model.Image
            };

            MapBaseModel(u, model);
            
            return u;
        }
        
        public static UnicornBasket ToModel(this Data.Models.UnicornBasket model)
        {
            return new UnicornBasket()
            {

            };
        }
        
        public static User ToModel(this Data.Models.UnicornUser model)
        {
            var u = new User()
            {
                Email = model.Email,
                Uuid = model.Uuid,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            MapBaseModel(u, model);

            return u;
        }
    }
}