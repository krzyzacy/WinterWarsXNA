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
    class Player_View
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

        public Camera get_camera(/*Vector2 topLeft, Vector2 bottomRight*/)
        {         
	//        get_Video().set_3d_view(player.get_camera(), std::make_pair(topLeft, bottomRight));
            return player.Camera;
        }

        public void render_hud(Vector2 topLeft, Vector2 bottomRight)
        {
            float unit_px = (bottomRight.X - topLeft.X) / 480.0f;

            Vector2 textpos = new Vector2(300 * unit_px, 100 * unit_px);
            SpriteFont gameFont = content.Load<SpriteFont>("gamefont");
            String output = "Test String";
            Vector2 FontOrigin = gameFont.MeasureString(output) / 2;
            spriteBatch.Begin();
            spriteBatch.DrawString(gameFont, output, textpos, Color.LightGreen,
                                0, FontOrigin, unit_px, SpriteEffects.None, 0.5f);
            spriteBatch.End();
        }

//	    void render_minimap(Vector2 topLeft, Vector2 bottomRight, std::string avartar);

//	    void render_build(Vector2 topLeft, Vector2 bottomRight);

//	    void render_death(Vector2 topLeft, Vector2 bottomRight);

//	    void render_message(Vector2 topLeft, Vector2 bottomRight, Zeni::String message);

//	    void render_tree_claimed(Vector2 topLeft, Vector2 bottomRight);



    }
}
