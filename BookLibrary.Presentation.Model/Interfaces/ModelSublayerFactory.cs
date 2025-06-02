using BookLibrary.Presentation.Model.Objects;

namespace BookLibrary.Presentation.Model.Interfaces
{
    public abstract class ModelSublayerFactory
    {
        public static IModelSublayer CreateModelSublayer()
        {
            return new ModelSublayer();
        }
    }
}
