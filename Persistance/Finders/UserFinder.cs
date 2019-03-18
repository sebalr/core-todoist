using System;
using todoist.infraestructure.Entities;

namespace todoist.Persistance.finders
{
    public interface IUserFinder : IBaseFinder<User>
    {
        void log();
    }

    public class UserFinder : BaseFinder<User>, IUserFinder
    {
        public UserFinder(BaseContext baseContext) : base(baseContext) { }

        public void log()
        {
            Console.WriteLine("Hello from user service!");
        }
    }
}