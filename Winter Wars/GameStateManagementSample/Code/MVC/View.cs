using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using WWxna.Code.Game_Objects;

namespace WWxna.Code.MVC
{
    class View
    {
        private GraphicsDeviceManager graphics;
        private List<Player_View> player_views;
        private HashSet<Seen_Object> to_render;
        private SortedDictionary<String, Model> model_map;
        private Player_View cur_View;
        private ContentManager Content;


        public View(GraphicsDeviceManager graphics_, ContentManager content)
        {
            graphics = graphics_;
            Content = content;
            player_views = new List<Player_View>();

            model_map = new SortedDictionary<string, Model>();
            to_render = new HashSet<Seen_Object>();

        }


        public void load_models()
        {
            // Init model map
            model_map.Add("Ship", Content.Load<Model>("Models\\blue_player"));

        }

        public void remove_renderable(Seen_Object obj)
        {
            to_render.Remove(obj);
        }

        public void add_renderable(Seen_Object obj)
        {
            to_render.Add(obj);
        }

        public void add_player_view(Player_View pv)
        {
            player_views.Add(pv);
        }

        public void render()
        {
            int width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            int height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            Vector2 topLeft = new Vector2(0, 0),
                middle = new Vector2(width / 2, height / 2),
                bottomRight = new Vector2(width, height),
                ySize = new Vector2(0, height / 2),
                xSize = new Vector2(width / 2, 0);


            render_player(0, topLeft, middle);
            //	        render_player(1, topLeft+xSize, middle+xSize);
            //        render_player(2, topLeft+ySize, middle+ySize);
            //      render_player(3, middle, bottomRight);

        }


        private void render_player(int player, Vector2 topLeft, Vector2 bottomRight)
        {
            cur_View = player_views[player];  // this is the cur player
            //      player_views[player].set_camera(topLeft, bottomRight);


            render_world();
        }

        private void render_player_hud(int player, Vector2 topLeft, Vector2 bottomRight)
        {
            // render the player's hud
            player_views[player].render_hud(topLeft, bottomRight);

        }

        private void render_world()
        {
            // pass each renderable into render_renderable
            foreach (Seen_Object obj in to_render)
            {
                render_renderable(obj);
            }
        }

        private void render_renderable(Seen_Object to_rend)
        {
            Model model;
            if (!model_map.TryGetValue(to_rend.get_model_name(), out model))
                throw new Exception(("Model " + to_rend.get_model_name() + " does not exist."));

            // don't render the current player
            //        if (cur_View.player == to_rend)
            //           return;

            to_rend.render(model, graphics, cur_View.get_camera());
        }



    }
}
