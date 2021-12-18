using Asteroid.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroid
{
    public class Menu
    {
       static internal Form _SplashScreen = null;


        public void Init(Form form)
        {           
            CreateButton(form);
            _SplashScreen = form;
        }


        private void GamePlay_Click(object sender, EventArgs e)
        {

            clear();

            //перед  созданием игры спрашиваем имя
            //var forma = sender as Form;
            UserData();

            Form form = new Form();
            form = StartForm.CreatForms(form);//создание типовых форм
            form.FormClosed += Form_FormClosed;
            form.KeyPress += Form_KeyPress;//управление клав.в игре
            form.KeyPreview = true;
            StartForm.GrafBuff(form);//создать граф обьект
            Game.Init(form);
            form.Show();
            _SplashScreen.Hide();
        }

        private void UserData()
        {
           
            Form Dialog = new Form();
            TextBox t1 = new TextBox();
            Button ok = new Button();
            Button close = new Button();
            close.Click += Cancel_Click;
            close.Size = Size.Empty;
            Dialog.Width = 0;
            Dialog.Height = 0;
            Dialog.AutoSize = true;
            Dialog.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Dialog.MaximizeBox = false;
            Dialog.MinimizeBox = false;
            Dialog.StartPosition = FormStartPosition.CenterParent;
            Dialog.ShowInTaskbar = false;
            Dialog.AcceptButton = ok;
            Dialog.CancelButton = close;
            Dialog.Text = "Ваше Имя";
            ok.Text = "Сохранить и продолжить";
            ok.Click += ClickB;
            t1.Text = "";
            t1.TextChanged += TextBoxName;
            t1.Width = 350;
            ok.Left = t1.Right + 5;
            Dialog.Controls.Add(ok);
            Dialog.Controls.Add(close);
            Dialog.Controls.Add(t1);
            Dialog.ShowDialog();
            Dialog.Dispose();
            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            //if (testDialog.ShowDialog(form) == DialogResult.OK)
            //{
            //    // Read the contents of testDialog's TextBox.
            //    //this.txtResult.Text = testDialog.TextBox1.Text;
            //}
            //else  
            //{
            //    //this.txtResult.Text = "Cancelled";
            //}
            //testDialog.Dispose();
        }

        private void TextBoxName(object sender, EventArgs e)
        {
            TextBox t1 = sender as TextBox;
            t1.Parent.Tag = t1.Text;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            var b = sender as Button;
            b?.Parent.Dispose();
        }



        private void ClickB(object sender, EventArgs e)
        {
             Button b = sender as Button;
            if (b.Parent.Tag != null)
            {
                var Name = b.Parent.Tag.ToString();
                var UserName = System.Text.RegularExpressions.Regex.Replace(Name, "[^a-zA-ZА-Яа-я]", "");

                
                while (UserName.Length>2)
                {
                        Game.NameUser = Name;//имя
                    b.Parent.Dispose();
                    break;                 
                }
                
            }
            
        }

        private void clear()
        {
            
            Game.TimerGame.Text = "";
            Game.Sec = new DateTime(0, 0);
            Game.count = 0;
           
        }

        private void Form_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27) //ESC 
            {
                var t = MessageBox.Show("Покинуть игру", "Результат не будет сохранен", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                if (t == DialogResult.OK)
                {
                    StopGame(sender);
                    var senders = sender as Form;
                    senders.Close();
                    try
                    {
                        senders.Dispose();
                    }
                    catch (Exception)
                    {
                        Debug.WriteLine("Обработка исключения");//прог.не падает))
                    }
                }
            }

        }
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopGame(sender);
        }

        public void StopGame(object sender)
        {
            SaveResult();

            Game.count = 0;
            _SplashScreen.Show();
           
            Game.timer.Stop();

        }

        private void SaveResult()
        {
            var write = new Result()
            {
                Name = Game.NameUser,
                Time= Game.TimerGame.Text,
                Count = Game.count

             };

           
            List<Result> list = new List<Result>();
            list.Add(write);
            if (File.Exists(puth))
            {
                try
                {
                    //не знаю  кк дописывать всегда делаю так, если умеете ,научите меня
                using (StreamReader file = File.OpenText(puth))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    var massResult = (List<Result>)serializer.Deserialize(file, typeof(List<Result>));
                    list.AddRange(massResult);
                }
                    writeFile(list, puth);
                   
                }
                catch (Exception)
                {
                    //или файл открыт уже где то...
                    //не json
                }
            }
            else
            {
                writeFile(list, puth);
            }

          
        }
        static string puth = "Result.json";
        private void writeFile(List<Result> list, string puth)
        {
            try
            {
                var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText(puth, JsonConvert.SerializeObject(list));
            }
            catch (Exception)
            {
            }
          
        }

        private void Resalt_Click(object sender, EventArgs e)
        {
            Form res= new Form();
            res = StartForm.CreatForms(res);//создание типовых форм

            List<Result> list = new List<Result>();
            if (File.Exists(puth))
            {
                try
                {
                    
                    using (StreamReader file = File.OpenText(puth))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        var massResult = (List<Result>)serializer.Deserialize(file, typeof(List<Result>));
                        list.AddRange(massResult);
                    }

                }
                catch (Exception)
                {
                    //или файл открыт уже где то...
                    //не json
                }

                DataGridView dataGrid = new DataGridView();
                dataGrid.Location = new Point(1, 1);
                dataGrid.MinimumSize = new Size(res.Width, res.Height);
                dataGrid.DataSource = list;
                res.Controls.Add(dataGrid);
                res.Show();
            }

           
            // MessageBox.Show("Пока нет времени", "Пока нет времени");
            //Form form = new Form();// форма с результатами  не релиз.
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            
            //_SplashScreen.Close();
            Environment.Exit(0);    
        }

        public void  CreateButton(Form form)
        {
            #region Button add

            List<Button> buttons = new List<Button>();// вдруг их  будет очень много))) 
            Button GamePlay = new Button();
            GamePlay.Cursor = System.Windows.Forms.Cursors.Hand;
            GamePlay.DialogResult = DialogResult.No;
            GamePlay.Click += GamePlay_Click;
            GamePlay.Text = "GamePlay";
            GamePlay.Font = new Font(form.Font, FontStyle.Bold);
            GamePlay.Location = new Point(350, 150);
            GamePlay.Size = new Size(100, 35);
            buttons.Add(GamePlay);
            
            Button Resalt = new Button();
            Resalt.Cursor = System.Windows.Forms.Cursors.Hand;
            Resalt.DialogResult = DialogResult.No;
            Resalt.Click += Resalt_Click;
            Resalt.Text = "Resalt";
            Resalt.Font = new Font(form.Font, FontStyle.Bold);
            Resalt.Location = new Point(350, 210);
            Resalt.Size = new Size(100, 35);
            buttons.Add(Resalt);

            Button Exit = new Button();
            Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            Exit.DialogResult = DialogResult.No;
            Exit.Click += Exit_Click;
            Exit.Text = "Exit";
            Exit.Font = new Font(form.Font, FontStyle.Bold);
            Exit.Location = new Point(form.Height+50, 500);
            Exit.Size = new Size(100, 35);
            buttons.Add(Exit);

            foreach (var item in buttons)
            {
                form.Controls.Add(item);
            }
            #endregion
        }

    }
}
