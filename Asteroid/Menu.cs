using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroid
{
    public class Menu
    {


        public void Init(Form form)
        {
            StartForm.GrafBuff(form);//создать граф обьект            
        }

        private void GamePlay_Click(object sender, EventArgs e)
        {
            Form form = new Form();

            Game.Init(form);
            //Game.Draw();
            Application.Run(form);
        }
        private void Resalt_Click(object sender, EventArgs e)
        {
            Form form = new Form();

            Game.Init(form);
            //Game.Draw();
            Application.Run(form);
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);    
        }

        public void  CreateButton(Form form)
        {
            List<Button> buttons = new List<Button>();
            Button GamePlay = new Button();
            GamePlay.Cursor = System.Windows.Forms.Cursors.Hand;
            GamePlay.DialogResult = DialogResult.No;
            GamePlay.Click += GamePlay_Click;
            GamePlay.Text = "GamePlay";
            GamePlay.Font = new Font(form.Font, FontStyle.Bold);
            GamePlay.Location = new Point(320, 150);
            GamePlay.Size = new Size(100, 35);
            buttons.Add(GamePlay);
            
            Button Resalt = new Button();
            Resalt.Cursor = System.Windows.Forms.Cursors.Hand;
            Resalt.DialogResult = DialogResult.No;
            Resalt.Click += Resalt_Click;
            Resalt.Text = "Resalt";
            Resalt.Font = new Font(form.Font, FontStyle.Bold);
            Resalt.Location = new Point(320, 190);
            Resalt.Size = new Size(100, 35);
            buttons.Add(Resalt);

            Button Exit = new Button();
            Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            Exit.DialogResult = DialogResult.No;
            Exit.Click += Exit_Click;
            Exit.Text = "Exit";
            Exit.Font = new Font(form.Font, FontStyle.Bold);
            Exit.Location = new Point(320, 250);
            Exit.Size = new Size(100, 35);
            buttons.Add(Exit);

            foreach (var item in buttons)
            {
                form.Controls.Add(item);
            }
        }

    }
}
