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
    public class Player_View
    {
        public H_Player player;
        SpriteBatch spriteBatch;
        ContentManager content;
        GraphicsDeviceManager graphics;

        public Player_View(H_Player p, GraphicsDeviceManager graphics_, ContentManager content_)
        { 
            player = p;
            graphics = graphics_;
            content = content_;
            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
        }

        public CameraComponent get_camera(/*Vector2 topLeft, Vector2 bottomRight*/)
        {         
	//        get_Video().set_3d_view(player.get_camera(), std::make_pair(topLeft, bottomRight));
            return player.Camera_p;
        }

        public void render_hud(Vector2 topLeft, Vector2 bottomRight)
        {
            float unit_width = (bottomRight.X - topLeft.X) / 1280.0f;
            float unit_height = (bottomRight.Y - topLeft.Y) / 800.0f;

            List<Texture2D> Texturelist = new List<Texture2D>();
            List<Rectangle> Reclist = new List<Rectangle>();

            // avartar
            Texturelist.Add(content.Load<Texture2D>("Textures\\HUDTextures\\AvartarFrame"));
            Reclist.Add(new Rectangle(0, 0, (int)(300 * unit_width), (int)(300 * unit_height)));

            // building
            Texturelist.Add(content.Load<Texture2D>("Textures\\HUDTextures\\BuildingFrame"));
            Reclist.Add(new Rectangle((int)(980 * unit_width), 0, (int)(300 * unit_width), (int)(300 * unit_height)));

            // message bar
            Texturelist.Add(content.Load<Texture2D>("Textures\\HUDTextures\\MessageBar"));
            Reclist.Add(new Rectangle(0, (int)(500 * unit_height), (int)(1280 * unit_width), (int)(300 * unit_height)));

            // flake
            Texturelist.Add(content.Load<Texture2D>("Textures\\HUDTextures\\Flake"));
            Reclist.Add(new Rectangle((int)(600 * unit_width), (int)(360 * unit_height), (int)(80 * unit_width), (int)(80 * unit_height)));

            // building sprite
            Texturelist.Add(content.Load<Texture2D>(Globals.structure_icon[player.structure_wheel_pos]));
            Reclist.Add(new Rectangle((int)(1100 * unit_width), (int)(40 * unit_height), (int)(150 * unit_width), (int)(150 * unit_height)));

            graphics.GraphicsDevice.BlendState = BlendState.NonPremultiplied;
            graphics.GraphicsDevice.DepthStencilState = DepthStencilState.None;

			Vector2 textpos = new Vector2(1130f * unit_width, 5f * unit_height);
            SpriteFont gameFont = content.Load<SpriteFont>("gamefont");
            //String output = "Test String";
            //  Vector2 FontOrigin = gameFont.m(output) / 2;
            spriteBatch.Begin();
            // spriteBatch.DrawString(gameFont, output, textpos, Color.LightGreen,
			//					0, FontOrigin, unit_px, SpriteEffects.None, 0.5f);
			int price = Globals.structure_cost[player.structure_wheel_pos];

			spriteBatch.DrawString(gameFont, price.ToString(), textpos, Color.Red,
								0, new Vector2(0,0), unit_width / 1.25f, SpriteEffects.None, 0.5f);

            for (int i = 0; i < Texturelist.Count; i++)
                spriteBatch.Draw(Texturelist[i], Reclist[i], Color.White);

            if (player.Mini_Map)
            {
                render_minimap(topLeft, bottomRight, spriteBatch);
            }

            spriteBatch.End();
        }

        void render_minimap(Vector2 topLeft, Vector2 bottomRight, SpriteBatch spriteBatch)
        {
            float unit_width = (bottomRight.X - topLeft.X) / 1280.0f;
            float unit_height = (bottomRight.Y - topLeft.Y) / 800.0f;

            float scale_size = 0.11f;


            Texture2D tile_Texture;

            for (int row = 0; row < GM_Proxy.Instance.get_World().get_height(); row++)
            {
                for (int col = 0; col < GM_Proxy.Instance.get_World().get_width(); col++)
                {
                    if (GM_Proxy.Instance.get_World().get_Tile(row, col).get_tile_name() == "Void") 
                        continue;
                    if (GM_Proxy.Instance.get_World().get_Tile(row, col).get_tile_name() == "Boundary")
                        tile_Texture = content.Load<Texture2D>("Textures\\minimap\\Cliff_hexagon");
                    else
                        tile_Texture = content.Load<Texture2D>("Textures\\minimap\\Neutral_hexagon");

                    Vector3 tilePos = GM_Proxy.Instance.get_World().get_Tile(row, col).get_top_center();
                    Rectangle tile_rec = new Rectangle((int)((3200 + tilePos.X) * unit_width * scale_size), (int)((1600 + tilePos.Z) * unit_height * scale_size), (int)(75 * unit_width), (int)(75 * unit_height));
                    spriteBatch.Draw(tile_Texture, tile_rec, Color.White);
                }
            }
        }

//	    void render_death(Vector2 topLeft, Vector2 bottomRight);

//	    void render_message(Vector2 topLeft, Vector2 bottomRight, Zeni::String message);

//	    void render_tree_claimed(Vector2 topLeft, Vector2 bottomRight);



    }
}
