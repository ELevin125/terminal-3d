using Terminal_3D.Geometry;
using Terminal_3D.Rendering;

namespace Terminal_3D.SceneManagement
{
    public class Scene
    {
        public Camera MainCamera;
        public List<Mesh> AllMeshes;
        public Scene()
        {
            MainCamera = new Camera(Vector3.Zero, Vector3.Zero);
        }
    }
}
