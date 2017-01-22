using System;
using System.Collections.Generic;
using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;
using Rhino.DocObjects;
using RCva3c;

namespace RhinoToJson
{
    [System.Runtime.InteropServices.Guid("acaad0ad-a761-4798-a4c1-ef19eab4e933")]
    public class RhinoToJsonCommand : Command
    {
        public RhinoToJsonCommand()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static RhinoToJsonCommand Instance
        {
            get; private set;
        }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName
        {
            get { return "RhinoToJson"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            RhinoApp.WriteLine("The {0} will construct JSON representation of your scene.", EnglishName);

            Rhino.DocObjects.ObjRef[] objrefs;
            Result rc = RhinoGet.GetMultipleObjects("Select your scene objects",
                                                                false, Rhino.DocObjects.ObjectType.AnyObject, out objrefs);

           if(objrefs?.Length > 0)
            {
                foreach(var obj in objrefs)
                {

                    switch (obj.Geometry().ObjectType)
                    {
                        case ObjectType.None:
                            break;
                        case ObjectType.Point:
                            break;
                        case ObjectType.PointSet:
                            break;
                        case ObjectType.Curve:
                            break;
                        case ObjectType.Surface:
                            break;
                        case ObjectType.Brep:
                            var mesh = new va3c_Mesh();
                            var brep = obj.Brep();
                            var meshBrep = Mesh.CreateFromBrep(brep);
                            Mesh finalMesh = new Mesh();
                            if(meshBrep?.Length > 0)
                            {
                                foreach(var m in meshBrep)
                                {
                                    finalMesh.Append(m);
                                }
                            }
                            var mat = new RCva3c.Material("json", va3cMaterialType.Mesh);
                            var geom = mesh.GenerateMeshElement(finalMesh, mat, new List<string> { "attrName" }, new List<string> { "attrValue" }) ;

                            var scenecompiler = new va3c_SceneCompiler();
                            string resultatas = scenecompiler.GenerateSceneJson(new List<Element>() { geom });
                            RhinoApp.WriteLine("resultatas");
                            break;
                        case ObjectType.Mesh:
                            break;
                        case ObjectType.Light:
                            break;
                        case ObjectType.Annotation:
                            break;
                        case ObjectType.InstanceDefinition:
                            break;
                        case ObjectType.InstanceReference:
                            break;
                        case ObjectType.TextDot:
                            break;
                        case ObjectType.Grip:
                            break;
                        case ObjectType.Detail:
                            break;
                        case ObjectType.Hatch:
                            break;
                        case ObjectType.MorphControl:
                            break;
                        case ObjectType.BrepLoop:
                            break;
                        case ObjectType.PolysrfFilter:
                            break;
                        case ObjectType.EdgeFilter:
                            break;
                        case ObjectType.PolyedgeFilter:
                            break;
                        case ObjectType.MeshVertex:
                            break;
                        case ObjectType.MeshEdge:
                            break;
                        case ObjectType.MeshFace:
                            break;
                        case ObjectType.Cage:
                            break;
                        case ObjectType.Phantom:
                            break;
                        case ObjectType.ClipPlane:
                            break;
                        case ObjectType.Extrusion:
                            break;
                        case ObjectType.AnyObject:
                            break;
                        default:
                            break;
                    }
                }
            }

            return Result.Success;
        }
    }
}
