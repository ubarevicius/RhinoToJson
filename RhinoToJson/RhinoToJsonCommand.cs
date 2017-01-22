using System;
using System.Collections.Generic;
using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;

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
           
            return Result.Success;
        }
    }
}
