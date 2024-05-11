using Terminal_3D.Geometry;
using Terminal_3D.Rendering;

namespace Terminal_3D.SceneManagement
{
    public abstract class Scene
    {
        public Camera MainCamera;
        public List<Mesh> AllMeshes = new List<Mesh>();

        protected Scene()
        {
            MainCamera = SetupMainCamera();
            InitializeScene();
        }

        protected abstract void InitializeScene();

        protected abstract Camera SetupMainCamera();
    }
}
