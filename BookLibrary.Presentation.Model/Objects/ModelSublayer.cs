using BookLibrary.Data.Interfaces;
using BookLibrary.Logic.Interfaces;
using BookLibrary.Presentation.Model.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace BookLibrary.Presentation.Model.Objects
{
    internal class ModelSublayer : IModelSublayer
    {

        private readonly ILogic logic;

        public ModelSublayer(ILogic? logicLayer = default)
        {

            logic = logicLayer ?? LogicLayerFactory.CreateLogicLayer();
        }

        public void AddUser(string dni, string name)
        {
            logic.ServiceUser.AddUser(new PresentationToLogicUser(new ModelUser(dni, name)));
        }

        public IEnumerable<IModelUser> GetAllUsers()
        {
            return logic.ServiceUser.GetAllUsers().Select(u => new LogicToPresentationUser(u)).ToList(); ;
        }


        private class PresentationToLogicUser : ILogicUser
        {
            public string DNI { get; }
            public string Name { get; }

            public PresentationToLogicUser(IModelUser user)
            {
                DNI = user.DNI;
                Name = user.Name;
            }
        }
        private class LogicToPresentationUser : IModelUser
        {
            public string DNI { get; set; }
            public string Name { get; set; }

            public LogicToPresentationUser(ILogicUser user)
            {
                DNI = user.DNI;
                Name = user.Name;
            }
        }
    }
}
