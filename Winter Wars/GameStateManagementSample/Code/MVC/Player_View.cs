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

            Texture2D avartar_Texture = content.Load<Texture2D>("Textures\\HUDTextures\\AvartarFrame");
            Rectangle avartar_rec = new Rectangle(0, 0, (int)(300 * unit_width), (int)(300 * unit_height));

            Texture2D building_Texture = content.Load<Texture2D>("Textures\\HUDTextures\\BuildingFrame");
            Rectangle building_rec = new Rectangle((int)(980 * unit_width), 0, (int)(300 * unit_width), (int)(300 * unit_height));

            Texture2D message_Texture = content.Load<Texture2D>("Textures\\HUDTextures\\MessageBar");
            Rectangle message_rec = new Rectangle(0, (int)(500 * unit_height), (int)(1280 * unit_width), (int)(300 * unit_height));

            Texture2D flake_Texture = content.Load<Texture2D>("Textures\\HUDTextures\\FLAKE");
            Rectangle flake_rec = new Rectangle((int)(600 * unit_width), (int)(360 * unit_height), (int)(80 * unit_width), (int)(80 * unit_height));

            graphics.GraphicsDevice.BlendState = BlendState.NonPremultiplied;
            graphics.GraphicsDevice.DepthStencilState = DepthStencilState.None;

            //Vector2 textpos = new Vector2(300 * unit_px, 100 * unit_px);
            //SpriteFont gameFont = content.Load<SpriteFont>("gamefont");
            //String output = "Test String";
            //Vector2 FontOrigin = gameFont.MeasureString(output) / 2;
            spriteBatch.Begin();
            //spriteBatch.DrawString(gameFont, output, textpos, Color.LightGreen,
            //                    0, FontOrigin, unit_px, SpriteEffects.None, 0.5f);

            spriteBatch.Draw(avartar_Texture, avartar_rec, Color.White);
            spriteBatch.Draw(building_Texture, building_rec, Color.White);
            spriteBatch.Draw(message_Texture, message_rec, Color.White);
            spriteBatch.Draw(flake_Texture, flake_rec, Color.White);

            spriteBatch.End();
        }

//	    void render_minimap(Vector2 topLeft, Vector2 bottomRight, std::string avartar);

//	    void render_build(Vector2 topLeft, Vector2 bottomRight);

//	    void render_death(Vector2 topLeft, Vector2 bottomRight);

//	    void render_message(Vector2 topLeft, Vector2 bottomRight, Zeni::String message);

//	    void render_tree_claimed(Vector2 topLeft, Vector2 bottomRight);



    }
}
