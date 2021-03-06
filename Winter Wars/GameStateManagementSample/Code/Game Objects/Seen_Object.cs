﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using WWxna.Code.MVC;
using WWxna.Code;


namespace WWxna.Code.Game_Objects
{
    // MAKE ABSTRACT!
    public class Seen_Object
    {
        protected Vector3 center;
        protected Vector3 size; // TopRightcorner-to-LowerLeftcorner
        protected Quaternion rotation;

        private bool marked_for_deletion;

        public Seen_Object() : this(Globals.Game_Obj_Origin , Globals.Game_Obj_Size, Globals.Game_Obj_Quat) { }
        public Seen_Object(Vector3 center_) : this(center_, Globals.Game_Obj_Size, Globals.Game_Obj_Quat) { }
        public Seen_Object(Vector3 center_, Vector3 size_) : this(center_, size_, Globals.Game_Obj_Quat) { }
        public Seen_Object(Vector3 center_, Vector3 size_, Quaternion theta_)
        {
            center = center_;
            size = size_;
            rotation = theta_;
            marked_for_deletion = false;

        }


        public Vector3 Position
        {
            get
            {
                return center;
            }
            protected set
            {
                center = value;
            }
        }


        virtual public void render(Model model, GraphicsDeviceManager graphics, CameraComponent camera)
        {
            if (model == null)
                throw new Exception("Trying to render NULL Model!");

            /*        if (get_animator())
                    {
                        get_animator()->animate(model);
                    }
        */
            // Copy any parent transforms.
            Matrix[] transforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(transforms);

            float modelRotation = 0.0f;


            // Draw the model. A model can have multiple meshes, so loop.
            foreach (ModelMesh mesh in model.Meshes)
            {
                // This is where the mesh orientation is set, as well 
                // as our camera and projection.
                foreach (BasicEffect effect in mesh.Effects)
                {

                    //effect.PreferPerPixelLighting = true;
                    //effect.EnableDefaultLighting();
                    //effect.View = camera.ViewMatrix;
                    //effect.Projection = camera.ProjectionMatrix;
                    //effect.World = modelTransforms[mesh.ParentBone.Index] * world;

                    effect.EnableDefaultLighting();
                    effect.World = transforms[mesh.ParentBone.Index] *
                        Matrix.CreateScale(size) * Matrix.CreateTranslation(center);

                    effect.View = camera.ViewMatrix;
                    effect.Projection = camera.ProjectionMatrix;

                    //OLD
                    //effect.EnableDefaultLighting();

                    //effect.World = transforms[mesh.ParentBone.Index] *
                    //    Matrix.CreateScale(size) 
                    //    * Matrix.CreateTranslation(center)
                    //    ;

                    //effect.View = Matrix.CreateLookAt(camera.Position,
                    //    camera.ViewDirection, camera.);

                    //effect.Projection = Matrix.CreatePerspectiveFieldOfView(
                    //    MathHelper.ToRadians(45.0f), graphics.GraphicsDevice.Viewport.AspectRatio,
                    //    1.0f, 10000.0f);



                }
                // Draw the mesh, using the effects set above.
                mesh.Draw();
            }

        }

        virtual public String get_model_name() { return "Ship"; }

        /// <summary>
        /// true if the object is on the gorund
        /// </summary>
        /// <returns></returns>
        public virtual bool is_on_ground()
        {

			Vector3 bottom_center = center - new Vector3(0, size.Y / 2, 0);

            if (bottom_center.Y < GM_Proxy.Instance.get_World().get_Tile(Position).get_height())
                return true;

            return false;
        }

        /// <summary>
        /// returns true if this object is not supposed to be deleted*/
        /// </summary>
        /// <returns></returns>
        virtual public bool is_alive() { return !marked_for_deletion; }
        public void mark_for_deletion()
        {
            marked_for_deletion = true;
        }
        /*     
             public Point get_bottom_center(){
                 return Point3(center.x, center.y, center.z - size.z/2);
             }
             public Point get_top_center(){
                 return Point3(center.x, center.y, center.z + size.z/2);
             }
     */


        //	    virtual private Animator *get_animator() const
        //		    {return 0;} //default no animator

    }
}
