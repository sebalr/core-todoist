using System;
using todoist.infraestructure.entities;

namespace todoist.persistance.finders
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