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
    public class View
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

        public GraphicsDeviceManager get_graphics()
        {
            return graphics;
        }

        public ContentManager get_content()
        {
            return Content;
        }

        public void load_models()
        {
            // Init model map
            model_map.Add("IceTile", Content.Load<Model>("Models\\ice_tile"));
			model_map.Add("Ship", Content.Load<Model>("Models\\blue_player"));
			model_map.Add("Fort", Content.Load<Model>("Models\\fort"));
			model_map.Add("Healing_Pool", Content.Load<Model>("Models\\fort"));
			model_map.Add("Snowman", Content.Load<Model>("Models\\fort"));
			model_map.Add("Snowball", Content.Load<Model>("Models\\snowball"));
			model_map.Add("Snow_Factory", Content.Load<Model>("Models\\fort"));

        }

        public void remove_renderable(Seen_Object obj)
        {
            to_render.Remove(obj);
        }

        public void add_renderable(Seen_Object obj)
        {
            to_render.Add(obj);
        }

		// Add in this order: 1,3,2,4
        public void add_player_view(Player_View pv)
        {
            player_views.Add(pv);
        }

        public void render()
        {
            //int width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            //int height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            int width = graphics.GraphicsDevice.PresentationParameters.BackBufferWidth;
            int height = graphics.GraphicsDevice.PresentationParameters.BackBufferHeight;
			int ySize, xSize;
			int num_players = player_views.Count();


			if (num_players > 1)
				ySize = height / 2;
			else
				ySize = height;

			if (num_players > 2)
				xSize = width / 2;
			else
				xSize = width;
			
			
			Vector2 topLeft = new Vector2(0, 0),
				middle = new Vector2(width / 2, height / 2),
				bottomRight = new Vector2(width, height),
                ySize_v = new Vector2(0, ySize),
                xSize_v = new Vector2(xSize, 0);

			Viewport p1Viewport = new Viewport();
			p1Viewport.X = 0;
			p1Viewport.Y = 0;
			p1Viewport.Width = xSize;
			p1Viewport.Height = ySize;
			p1Viewport.MinDepth = 0;
			p1Viewport.MaxDepth = 1;

			Viewport original = graphics.GraphicsDevice.Viewport;

			render_player(0, topLeft, middle, p1Viewport);

			if (num_players > 1)
			{
				Viewport p2Viewport = new Viewport();
				p2Viewport.X = 0;
				p2Viewport.Y = ySize;
				p2Viewport.Width = xSize;
				p2Viewport.Height = ySize;
				p2Viewport.MinDepth = 0;
				p2Viewport.MaxDepth = 1;

				render_player(1, topLeft + xSize_v, middle + xSize_v, p2Viewport );

				if (num_players > 2)
				{
					Viewport p3Viewport = new Viewport();
					p3Viewport.X = xSize;
					p3Viewport.Y = 0;
					p3Viewport.Width = xSize;
					p3Viewport.Height = ySize;
					p3Viewport.MinDepth = 0;
					p3Viewport.MaxDepth = 1;
			
					render_player(2, topLeft + ySize_v, middle + ySize_v, p3Viewport);
				
					if (num_players > 3)
					{
						Viewport p4Viewport = new Viewport();
						p4Viewport.X = xSize;
						p4Viewport.Y = ySize;
						p4Viewport.Width = xSize;
						p4Viewport.Height = ySize;
						p4Viewport.MinDepth = 0;
						p4Viewport.MaxDepth = 1;
						render_player(3, middle, bottomRight, p4Viewport);
					}
				}
			}
			graphics.GraphicsDevice.Viewport = original;
        }
		
        private void render_player(int player, Vector2 topLeft, Vector2 bottomRight, Viewport viewport)
        {
            cur_View = player_views[player];  // this is the cur player
            //      player_views[player].set_camera(topLeft, bottomRight);


			graphics.GraphicsDevice.Viewport = viewport;
            render_world();
            render_player_hud(player, topLeft, bottomRight);
        }

        private void render_player_hud(int player, Vector2 topLeft, Vector2 bottomRight)
        {
            // render the player's hud
            player_views[player].render_hud(topLeft, bottomRight);

        }

        private void render_world()
        {
            // pass each renderable into render_renderable
            graphics.GraphicsDevice.BlendState = BlendState.Opaque;
            graphics.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
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
                 if (cur_View.player == to_rend)
                       return;

            to_rend.render(model, graphics, cur_View.get_camera());
        }



    }
}
