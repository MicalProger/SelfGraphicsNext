using SelfGraphicsNext.RayGraphics.Graphics3D.Rendering;
using SFML.Graphics;

namespace SelfGraphicsNext.RayGraphics.Graphics3D.Geometry
{
    public class PolygonGroup
    {
        public Color Color { get; set; }

        public List<Polygon> Surface;

        public string Name;

        public PolygonGroup(List<Polygon> surface)
        {
            Surface = surface;
        }

        public PolygonGroup() => Surface = new List<Polygon>();
        public ColisionResult Colide(Ray3 ray)
        {
            Point3 colision = new Point3();
            ColisionResult colResult = new ColisionResult();
            List<ColisionResult> results = new List<ColisionResult>();
            for (int i = 0; i < Surface.Count; i++)
            {
                Polygon polygon = Surface[i];
                if (polygon.Colide(ray, out Point3 col))
                {
                    results.Add(new ColisionResult() { ColidedPoligon = polygon, Colision = col});
                    //ppp.Add(col, polygon);
                }
            }                
            if (results.Count > 0)
            {
                colResult = results.MinBy(i => i.Colision.Distance);
                colResult.GroupName = Name;
                colResult.RaySource = ray.Position;
                colResult.Color = Color;
                colResult.Codiled = true;
                return colResult;
            }
            colResult.Codiled = false;
            return colResult;
        }
        public ColisionResult ColideIns(Ray3 ray, Polygon pol)
        {
            Point3 colision = new Point3();
            ColisionResult colResult = new ColisionResult();
            List<ColisionResult> results = new List<ColisionResult>();
            for (int i = 0; i < Surface.Count; i++)
            {
                Polygon polygon = Surface[i];
                if (polygon == pol)
                    continue;
                if (polygon.Colide(ray, out Point3 col))
                {
                    results.Add(new ColisionResult() { ColidedPoligon = polygon, Colision = col });
                    //ppp.Add(col, polygon);
                }
            }
            if (results.Count > 0)
            {
                colResult = results.MinBy(i => i.Colision.Distance);
                colResult.GroupName = Name;
                colResult.RaySource = ray.Position;
                colResult.Color = Color;
                colResult.Codiled = true;
                return colResult;
            }
            colResult.Codiled = false;
            return colResult;
        }
    }
}
