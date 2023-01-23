using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Tennis
{
    public partial class SuperTennis : Form
    {
        SolidBrush tennisballgreen = new SolidBrush(Color.GreenYellow);
        SolidBrush lime = new SolidBrush(Color.Lime);
        SolidBrush green = new SolidBrush(Color.LimeGreen);
        SolidBrush white = new SolidBrush(Color.White);
        SolidBrush black = new SolidBrush(Color.Black);
        SolidBrush p1colour = new SolidBrush(Color.MediumOrchid);
        SolidBrush p2colour = new SolidBrush(Color.Orange);
        SolidBrush trailColour = new SolidBrush(Color.White);

        Pen tennisballline = new Pen(Color.White);
        Pen p1colourPen = new Pen(Color.MediumOrchid, 3);
        Pen p2colourPen = new Pen(Color.Orange, 3);

        Font supertennisBig = new Font("Bauhaus 93", 110, FontStyle.Regular);
        Font supertennisSmall = new Font("Bauhaus 93", 50, FontStyle.Regular);

        Rectangle ground1 = new Rectangle(50, 380, 117, 140);
        Rectangle ground2 = new Rectangle(167, 380, 117, 140);
        Rectangle ground3 = new Rectangle(283, 380, 117, 140);
        Rectangle ground4 = new Rectangle(400, 380, 117, 140);
        Rectangle ground5 = new Rectangle(517, 380, 117, 140);
        Rectangle ground6 = new Rectangle(633, 380, 117, 140);
        Rectangle net = new Rectangle(398, 300, 4, 220);

        Rectangle player1 = new Rectangle(150, 350, 30, 30);
        Rectangle player2 = new Rectangle(620, 350, 30, 30);

        Rectangle ball = new Rectangle(385, 250, 30, 30);
        List<Rectangle> trail = new List<Rectangle>();
        List<Rectangle> powerups = new List<Rectangle>();
        List<int> powerupType = new List<int>();
        List<int> powerupXSpeed = new List<int>();
        List<int> powerupYSpeed = new List<int>();

        int page = 0;

        int p1XSpeed = 0;
        int p1YSpeed = 0;
        int p2XSpeed = 0;
        int p2YSpeed = 0;
        int p1MaxSpeed = 6;
        int p2MaxSpeed = 6;
        int ballXSpeed = 6;
        int ballYSpeed = -10;
        int p1direction = 0;
        int p2direction = 0;
        string ballSide = null;
        int p1Score = 0;
        int p2Score = 0;

        int ballDelayTimer = 0;
        int ballDelayTimer2 = 0;
        int powerupTimer = 1000;

        int bounces = 0;

        bool aDown = false;
        bool dDown = false;
        bool wDown = false;
        bool leftDown = false;
        bool rightDown = false;
        bool upDown = false;

        bool p1grounded = true;
        bool p2grounded = true;

        Random rand = new Random();

        public SuperTennis()
        {
            InitializeComponent();
        }

        private void SuperTennis_Paint(object sender, PaintEventArgs e)
        {
            if (page == 0)
            {
                e.Graphics.FillRectangle(white, 100, 60, Width - 200, 190);
                e.Graphics.FillRectangle(white, 130, 30, Width - 260, 250);

                e.Graphics.FillRectangle(lime, 100, 155, 250, 95);
                e.Graphics.FillRectangle(lime, 130, 155, 250, 125);

                e.Graphics.FillRectangle(lime, Width - 350, 60, 250, 95);
                e.Graphics.FillRectangle(lime, Width - 380, 30, 250, 125);

                e.Graphics.FillEllipse(white, 100, 30, 60, 60);
                e.Graphics.FillEllipse(lime, Width - 160, 30, 60, 60);
                e.Graphics.FillEllipse(lime, 100, 220, 60, 60);
                e.Graphics.FillEllipse(white, Width - 160, 220, 60, 60);

                e.Graphics.DrawString("S", supertennisBig, lime, 120, 10);
                e.Graphics.DrawString("UPER", supertennisSmall, lime, 200, 70);
                e.Graphics.FillRectangle(lime, 180, 43, 230, 29);
                e.Graphics.FillRectangle(lime, 100, 115, 70, 29);

                e.Graphics.DrawString("T", supertennisBig, lime, 410, 134);
                e.Graphics.DrawString("ENNIS", supertennisSmall, lime, 490, 194);
                e.Graphics.FillRectangle(lime, 470, 169, 220, 29);
            }
            else if (page == 1)
            {
                e.Graphics.FillRectangle(black, net);
                e.Graphics.FillRectangle(green, ground1);
                e.Graphics.FillRectangle(green, ground2);
                e.Graphics.FillRectangle(green, ground3);
                e.Graphics.FillRectangle(green, ground4);
                e.Graphics.FillRectangle(green, ground5);
                e.Graphics.FillRectangle(green, ground6);

                if (Math.Abs(ballXSpeed) > 29)
                {
                    trailColour.Color = Color.Red;
                }
                else if (Math.Abs(ballXSpeed) > 24)
                {
                    trailColour.Color = Color.FromArgb(255, 90, 90);
                }
                else if (Math.Abs(ballXSpeed) > 19)
                {
                    trailColour.Color = Color.FromArgb(255, 120, 120);
                }
                else if (Math.Abs(ballXSpeed) > 14)
                {
                    trailColour.Color = Color.FromArgb(255, 150, 150);
                }
                else if (Math.Abs(ballXSpeed) > 9)
                {
                    trailColour.Color = Color.FromArgb(255, 180, 180);
                }
                else if (Math.Abs(ballXSpeed) > 4)
                {
                    trailColour.Color = Color.FromArgb(255, 210, 210);
                }
                else
                {
                    trailColour.Color = Color.FromArgb(255, 240, 240);
                }

                for (int i = 0; i < trail.Count; i++)
                {
                    e.Graphics.FillEllipse(trailColour, trail[i]);
                }

                e.Graphics.FillRectangle(p1colour, player1);
                e.Graphics.FillEllipse(black, player1.X + 22, player1.Y + 2, 6, 12);
                e.Graphics.FillEllipse(black, player1.X + 13, player1.Y + 2, 6, 12);
                e.Graphics.FillRectangle(p1colour, player1.X + 30, player1.Y + 12, 10, 6);
                e.Graphics.FillRectangle(p1colour, player1.X + 36, player1.Y + 5, 4, 15);
                e.Graphics.DrawEllipse(p1colourPen, player1.X + 32, player1.Y - 10, 12, 15);

                e.Graphics.FillRectangle(p2colour, player2);
                e.Graphics.FillEllipse(black, player2.X + player2.Width - 28, player2.Y + 2, 6, 12);
                e.Graphics.FillEllipse(black, player2.X + player2.Width - 19, player2.Y + 2, 6, 12);
                e.Graphics.FillRectangle(p2colour, player2.X - 10, player2.Y + 12, 10, 6);
                e.Graphics.FillRectangle(p2colour, player2.X - 10, player2.Y + 5, 4, 15);
                e.Graphics.DrawEllipse(p2colourPen, player2.X - 15, player2.Y - 10, 12, 15);

                e.Graphics.FillEllipse(tennisballgreen, ball);
                e.Graphics.DrawArc(tennisballline, ball.X - 20, ball.Y, ball.Width, ball.Height, -50, 100);
                e.Graphics.DrawArc(tennisballline, ball.X + 20, ball.Y, ball.Width, ball.Height, 130, 100);

                e.Graphics.DrawString($"{p1Score}", supertennisSmall, p1colour, 30, 30);
                e.Graphics.DrawString($"{p2Score}", supertennisSmall, p2colour, Width - 30 - Convert.ToString(p2Score).Length * 55, 30);
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (page == 1)
            {
                // Move P1

                if (aDown == true)
                {
                    if (p1XSpeed > -p1MaxSpeed)
                    {
                        p1XSpeed--;
                    }
                }
                else if (p1XSpeed < 0 && dDown == false)
                {
                    p1XSpeed++;
                }

                if (dDown == true)
                {
                    if (p1XSpeed < p1MaxSpeed)
                    {
                        p1XSpeed++;
                    }
                }
                else if (p1XSpeed > 0 && aDown == false)
                {
                    p1XSpeed--;
                }

                if (wDown == true)
                {
                    if (p1grounded == true)
                    {
                        p1YSpeed -= 15;
                        p1grounded = false;
                    }
                }

                if (p1grounded == false)
                {
                    p1YSpeed++;
                }

                // P1 moves. It is coded to move a step at a time to prevent glitchy collisions.

                if (p1XSpeed > 0)
                {
                    for (int i = 0; i < p1XSpeed; i++)
                    {
                        player1.X += 1;
                        CheckCollisionsP1();
                    }
                }
                else if (p1XSpeed < 0)
                {
                    for (int i = 0; i < -p1XSpeed; i++)
                    {
                        player1.X -= 1;
                        CheckCollisionsP1();
                    }
                }

                if (p1YSpeed > 0)
                {
                    for (int i = 0; i < p1YSpeed; i++)
                    {
                        player1.Y += 1;
                        CheckCollisionsP1();
                    }
                }
                else if (p1YSpeed < 0)
                {
                    for (int i = 0; i < -p1YSpeed; i++)
                    {
                        player1.Y -= 1;
                        CheckCollisionsP1();
                    }
                }

                // Move P2

                if (leftDown == true)
                {
                    if (p2XSpeed > -p2MaxSpeed)
                    {
                        p2XSpeed--;
                    }
                }
                else if (p2XSpeed < 0 && rightDown == false)
                {
                    p2XSpeed++;
                }

                if (rightDown == true)
                {
                    if (p2XSpeed < p1MaxSpeed)
                    {
                        p2XSpeed++;
                    }
                }
                else if (p2XSpeed > 0 && leftDown == false)
                {
                    p2XSpeed--;
                }

                if (upDown == true)
                {
                    if (p2grounded == true)
                    {
                        p2YSpeed -= 15;
                        p2grounded = false;
                    }
                }

                if (p2grounded == false)
                {
                    p2YSpeed++;
                }

                // P2 moves. It is coded to move a step at a time to prevent glitchy collisions.

                if (p2XSpeed > 0)
                {
                    for (int i = 0; i < p2XSpeed; i++)
                    {
                        player2.X += 1;
                        CheckCollisionsP2();
                    }
                }
                else if (p2XSpeed < 0)
                {
                    for (int i = 0; i < -p2XSpeed; i++)
                    {
                        player2.X -= 1;
                        CheckCollisionsP2();
                    }
                }

                if (p2YSpeed > 0)
                {
                    for (int i = 0; i < p2YSpeed; i++)
                    {
                        player2.Y += 1;
                        CheckCollisionsP2();
                    }
                }
                else if (p2YSpeed < 0)
                {
                    for (int i = 0; i < -p2YSpeed; i++)
                    {
                        player2.Y -= 1;
                        CheckCollisionsP2();
                    }
                }

                // Move ball

                if (ballDelayTimer2 == 0)
                {
                    ballYSpeed++;
                }

                if (ball.X > 384)
                {
                    if (ballSide == "p1")
                    {
                        bounces = 0;
                    }
                    ballSide = "p2";
                }
                else
                {
                    if (ballSide == "p2")
                    {
                        bounces = 0;
                    }
                    ballSide = "p1";
                }

                if (ballYSpeed < -22)
                {
                    ballYSpeed = -22;
                }

                if (ballXSpeed > 0 && ballDelayTimer2 == 0)
                {
                    for (int i = 0; i < Math.Round(Convert.ToDouble(ballXSpeed / 2)); i++)
                    {
                        ball.X += 1;
                        CheckCollisionsBall();
                    }
                }
                else if (ballXSpeed < 0 && ballDelayTimer2 == 0)
                {
                    for (int i = 0; i < Math.Round(Convert.ToDouble(-ballXSpeed / 2)); i++)
                    {
                        ball.X -= 1;
                        CheckCollisionsBall();
                    }
                }

                if (ballYSpeed > 0 && ballDelayTimer2 == 0)
                {
                    for (int i = 0; i < Math.Round(Convert.ToDouble(ballYSpeed / 2)); i++)
                    {
                        ball.Y += 1;
                        CheckCollisionsBall();
                    }
                }
                else if (ballYSpeed < 0 && ballDelayTimer2 == 0)
                {
                    for (int i = 0; i < Math.Round(Convert.ToDouble(-ballYSpeed / 2)); i++)
                    {
                        ball.Y -= 1;
                        CheckCollisionsBall();
                    }
                }

                if (ball.Y > Height + 300)
                {
                    if (bounces > 0)
                    {
                        if (ballSide == "p2")
                        {
                            Serve("p1");
                        }
                        else
                        {
                            Serve("p2");
                        }
                    }
                    else
                    {
                        if (ballSide == "p2")
                        {
                            Serve("p2");
                        }
                        else
                        {
                            Serve("p1");
                        }
                    }
                }

                // Respawn Players

                if (player1.Y > Height + 100)
                {
                    player1.X = 150;
                    player1.Y = 0 - player1.Height;
                    p1YSpeed = 0;
                }
                if (player2.Y > Height + 100)
                {
                    player2.X = 620;
                    player2.Y = 0 - player2.Height;
                    p2YSpeed = 0;
                }

                // Timers

                if (ballDelayTimer > 0)
                {
                    ballDelayTimer--;
                }
                if (ballDelayTimer2 > 0)
                {
                    ballDelayTimer2--;
                }
                if (powerupTimer > 0 && ballDelayTimer2 == 0)
                {
                    powerupTimer--;
                }

                // Ball trail

                trail.Add(ball);
                for (int i = 0; i < trail.Count; i++)
                {
                    int size = trail[i].Width - 1;
                    int x = trail[i].X;
                    int y = trail[i].Y;
                    trail.RemoveAt(i);
                    trail.Insert(i, new Rectangle(x + rand.Next(Math.Abs(Convert.ToInt16(Math.Round(Convert.ToDouble(ballXSpeed / 8)))) * -1, Math.Abs(Convert.ToInt16(Math.Round(Convert.ToDouble(ballXSpeed / 8))))), y + rand.Next(Math.Abs(Convert.ToInt16(Math.Round(Convert.ToDouble(ballXSpeed / 8)))) * -1, Math.Abs(Convert.ToInt16(Math.Round(Convert.ToDouble(ballXSpeed / 8))))), size, size));
                }

                if (trail.Count > 20)
                {
                    trail.RemoveAt(0);
                }

                // Powerups

                if (powerupTimer == 0)
                {
                    powerups.Add(new Rectangle(390, 360, 20, 20));
                    powerupType.Add(1);
                    powerupYSpeed.Add(rand.Next(-20, -9));
                    powerupXSpeed.Add(rand.Next(-3, 4));
                }

                Refresh();
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            playButton.Visible = false;
            playButton.Enabled = false;

            page = 1;
        }

        private void SuperTennis_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.Left:
                    leftDown = true;
                    break;
                case Keys.Right:
                    rightDown = true;
                    break;
                case Keys.Up:
                    upDown = true;
                    break;
            }
        }

        private void SuperTennis_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.Left:
                    leftDown = false;
                    break;
                case Keys.Right:
                    rightDown = false;
                    break;
                case Keys.Up:
                    upDown = false;
                    break;
            }
        }
        public void CheckCollisionsP1()
        {
            // Check if player 1 hits ground

            if (player1.IntersectsWith(ground1))
            {
                if (player1.X > (ground1.X + ground1.Width - 2))
                {
                    player1.X++;
                }
                else if (player1.X + player1.Width < ground1.X + 2)
                {
                    player1.X--;
                }
                if (player1.Y + player1.Height < (ground1.Y + 2))
                {
                    player1.Y--;
                    p1YSpeed = 0;
                }

                p1grounded = true;
            }
            else if (player1.IntersectsWith(ground2))
            {
                if (player1.X > (ground2.X + ground2.Width - 2))
                {
                    player1.X++;
                }
                else if (player1.X + player1.Width < ground2.X + 2)
                {
                    player1.X--;
                }
                if (player1.Y + player1.Height < (ground2.Y + 2))
                {
                    player1.Y--;
                    p1YSpeed = 0;
                }

                p1grounded = true;
            }
            else if (player1.IntersectsWith(ground3))
            {
                if (player1.X + player1.Width < ground3.X + 2)
                {
                    player1.X--;
                }
                if (player1.Y + player1.Height < (ground3.Y + 2))
                {
                    player1.Y--;
                    p1YSpeed = 0;
                }

                p1grounded = true;
            }
            else
            {
                p1grounded = false;
            }

            if (player1.X > Width / 2 - player1.Width)
            {
                player1.X = Width / 2 - player1.Width;
                p1XSpeed = 0;
            }
        }
        public void CheckCollisionsP2()
        {
            // Check if player 2 hits ground

            if (player2.IntersectsWith(ground6))
            {
                if (player2.X > (ground6.X + ground6.Width - 2))
                {
                    player2.X++;
                }
                else if (player2.X + player2.Width < ground6.X + 2)
                {
                    player2.X--;
                }
                if (player2.Y + player2.Height < (ground6.Y + 2))
                {
                    player2.Y--;
                    p2YSpeed = 0;
                }

                p2grounded = true;
            }
            else if (player2.IntersectsWith(ground5))
            {
                if (player2.X > (ground5.X + ground5.Width - 2))
                {
                    player2.X++;
                }
                else if (player2.X + player2.Width < ground5.X + 2)
                {
                    player2.X--;
                }
                if (player2.Y + player2.Height < (ground5.Y + 2))
                {
                    player2.Y--;
                    p2YSpeed = 0;
                }

                p2grounded = true;
            }
            else if (player2.IntersectsWith(ground4))
            {
                if (player2.X > (ground4.X + ground4.Width - 2))
                {
                    player2.X++;
                }
                if (player2.Y + player2.Height < (ground4.Y + 2))
                {
                    player2.Y--;
                    p2YSpeed = 0;
                }

                p2grounded = true;
            }
            else
            {
                p2grounded = false;
            }

            if (player2.X < Width / 2)
            {
                player2.X = Width / 2;
                p2XSpeed = 0;
            }
        }
        public void BallGroundCollision(Rectangle ground)
        {
            if (ball.IntersectsWith(ground))
            {
                bounces++;
                if (bounces < 2)
                {
                    if (ball.Y + ball.Height < (ground.Y + 2))
                    {
                        ballYSpeed--;
                        ballYSpeed *= -1;
                        ball.Y = ground.Y - ball.Height;
                    }
                    else
                    {
                        if (ballXSpeed > 0)
                        {
                            ballXSpeed--;
                            ball.X = ground.X - ball.Width;
                        }
                        else
                        {
                            ballXSpeed++;
                            ball.X = ground.X + ground.Width;
                        }
                        ballXSpeed *= -1;
                    }
                }
            }
        }
        public void BallPlayerCollision(Rectangle player, int pXSpeed, int pYSpeed, int pdirection)
        {
            if (ball.IntersectsWith(player))
            {
                bounces = 1;
                if (ballXSpeed > 0)
                {
                    ballXSpeed--;
                }
                else if (ballXSpeed < 0)
                {
                    ballXSpeed++;
                }
                ballXSpeed *= -1;

                if (ballYSpeed > 0)
                {
                    ballYSpeed--;
                }
                else if (ballYSpeed < 0)
                {
                    ballYSpeed++;
                }
                ballYSpeed *= -1;

                ballXSpeed += pXSpeed;
                ballYSpeed += pYSpeed;

                ballDelayTimer = 20;

                if (ball.IntersectsWith(player1))
                {
                    p1XSpeed = Convert.ToInt16(Math.Round(Convert.ToDouble(ballXSpeed / -2)));
                    p1YSpeed = Convert.ToInt16(Math.Round(Convert.ToDouble(ballYSpeed / -2)));
                }
                else if (ball.IntersectsWith(player2))
                {
                    p2XSpeed = Convert.ToInt16(Math.Round(Convert.ToDouble(ballXSpeed / -2)));
                    p2YSpeed = Convert.ToInt16(Math.Round(Convert.ToDouble(ballYSpeed / -2)));
                }
            }
        }
        public void CheckCollisionsBall()
        {
            BallGroundCollision(ground1);
            BallGroundCollision(ground2);
            BallGroundCollision(ground3);
            BallGroundCollision(ground4);
            BallGroundCollision(ground5);
            BallGroundCollision(ground6);

            if (ball.IntersectsWith(net))
            {
                ballXSpeed = 0;
            }

            if (ballDelayTimer == 0)
            {
                BallPlayerCollision(player1, p1XSpeed, p1YSpeed, p1direction);
                BallPlayerCollision(player2, p2XSpeed, p2YSpeed, p2direction);
            }
        }
        public void Serve(string winner)
        {
            ballDelayTimer2 = 40;
            ball.X = 385;
            ball.Y = 250;
            ballYSpeed = -10;
            bounces = 0;
            powerupTimer = rand.Next(700, 1301);

            player1.X = 150;
            player1.Y = 350;
            player2.X = 620;
            player2.Y = 350;
            p1XSpeed = 0;
            p1YSpeed = 0;
            p2XSpeed = 0;
            p2YSpeed = 0;
            if (winner == "p1")
            {
                ballXSpeed = -6;
                p1Score++;
            }
            else
            {
                ballXSpeed = 6;
                p2Score++;
            }
        }
    }
}
