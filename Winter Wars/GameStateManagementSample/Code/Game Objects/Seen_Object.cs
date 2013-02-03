﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using WWxna.Code.MVC;


namespace WWxna.Code.Game_Objects
{
    // MAKE ABSTRACT!
    class Seen_Object
    {
        protected Vector3 center;
        protected Vector3 size; // TopRightcorner-to-LowerLeftcorner
        protected Quaternion rotation;

        private bool marked_for_deletion;

        public Seen_Object() : this(Vector3.Zero, new Vector3(1, 1, 1), new Quaternion(0, 0, 1, 0)) { }
        public Seen_Object(Vector3 center_) : this(center_, new Vector3(1, 1, 1), new Quaternion(0, 0, 1, 0)) { }
        public Seen_Object(Vector3 center_, Vector3 size_) : this(center_, size_, new Quaternion(0, 0, 1, 0)) { }
        public Seen_Object(Vector3 center_, Vector3 size_, Quaternion theta_)
        {
            center = center_;
            size = size_;
            rotation = theta_;
            marked_for_deletion = false;
        }

        virtual public void render(Model model, GraphicsDeviceManager graphics, Camera camera)
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
                    effect.EnableDefaultLighting();

                    effect.World = transforms[mesh.ParentBone.Index] *
                        Matrix.CreateRotationY(modelRotation)
                        * Matrix.CreateTranslation(center)
                        * Matrix.CreateScale(size);

                    effect.View = Matrix.CreateLookAt(camera.pos,
                        camera.facing, camera.up);

                    effect.Projection = Matrix.CreatePerspectiveFieldOfView(
                        MathHelper.ToRadians(45.0f), graphics.GraphicsDevice.Viewport.AspectRatio,
                        1.0f, 10000.0f);
                }
                // Draw the mesh, using the effects set above.
                mesh.Draw();
            }

        }

        virtual public String get_model_name() { return "Ship"; }

        public bool is_on_ground()
        {
            //return true if Object is on the ground

            // if my bottom is less than the top of the tile im one
            // MAGIC NUMBER 35.0 here, modify when model fixed.
            // also @ moveable.cpp line 64.
            //        if(get_bottom_center().z <= Game_Model::get().get_World()->get_tile(center)->get_top_center().z + 10.0f)
            //	        return true;

            return false;
        }

        /*returns true if this object is not supposed to be deleted*/
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