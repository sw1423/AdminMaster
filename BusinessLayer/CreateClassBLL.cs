using DataAccessLayer;

namespace BusinessLayer
{
    public class CreateClassBLL 
    {
        private CreateClass dal = new CreateClass();
        public void CreateEntityClass()
        {
            dal.CreateEntityClass();
        }
    }
}
