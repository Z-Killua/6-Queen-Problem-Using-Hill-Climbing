using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6Queens
{
    public partial class Form1 : Form
    {
        int side, n = 6, moveCounter;
        SixState startState, currentState;
        int[,] hTable;
        ArrayList bMoves;
        Object chosenMove;

        public Form1()
        {
            InitializeComponent();

            side = pictureBox1.Width / n;

            startState = randomSixState();
            currentState = new SixState(startState);

            moveCounter = 0;

            updateUI();
            pictureBox1.Refresh(); //Refresh UI positions
            label1.Text = "Attacking pairs: " + getAttackingPairs(startState);
        }

        private void pictureBox1_Click(object sender, EventArgs e){}

        private void button1_Click(object sender, EventArgs e)
        {
            startState = randomSixState();
            currentState = new SixState(startState);

            moveCounter = 0;

            updateUI();
            pictureBox1.Refresh();
            label1.Text = "Attacking pairs: " + getAttackingPairs(startState);
        }

        private SixState randomSixState()
        {
            Random r = new Random();
            SixState random = new SixState(r.Next(n),
                r.Next(n),
                r.Next(n),
                r.Next(n),
                r.Next(n),
                r.Next(n));

            return random;
        }

        private void updateUI()
        {
            pictureBox2.Refresh();
            label5.Text = "Attacking Pairs: " + getAttackingPairs(currentState);
            label3.Text = "Moves: " + moveCounter;
            hTable = getHeuristicTableForPossibleMoves(currentState);
            bMoves = getBestMoves(hTable);

            listBox1.Items.Clear();

            foreach(Point move in bMoves)
                listBox1.Items.Add(move);

            if (bMoves.Count > 0)
                chosenMove = chooseMove(bMoves);

            label2.Text = "Chosen move: " + chosenMove;
        }

        private ArrayList getBestMoves(int[,] heuristicTable)
        {
            ArrayList bestMoves = new ArrayList();
            int bestHeuristicValue = heuristicTable[0, 0];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (bestHeuristicValue > heuristicTable[i, j])
                    {
                        bestHeuristicValue = heuristicTable[i, j];
                        bestMoves.Clear();
                        if (currentState.Y[i] != j)
                            bestMoves.Add(new Point(i, j));
                    }
                    else if (bestHeuristicValue == heuristicTable[i, j])
                    {
                        if (currentState.Y[i] != j)
                            bestMoves.Add(new Point(i, j));
                    }
                }
            }

            label4.Text = "Possible Moves (H=" + bestHeuristicValue + ")";

            return bestMoves;
        }

        private Object chooseMove(ArrayList possibleMoves)
        {
            int arrayLength = possibleMoves.Count;
            Random r = new Random();
            int randomMove = r.Next(arrayLength);

            return possibleMoves[randomMove];
        }

        private int[,] getHeuristicTableForPossibleMoves(SixState thisState)
        {
            int[,] hStates = new int[n, n];

            for(int i = 0; i < n; i++)  //go through the indices
            {
                for(int j = 0; j < n; j++)  //replace them with a new value
                {
                    // put code here
                    SixState temp = new SixState(thisState);
                    temp.Y[i] = j;
                    hStates[i, j] = getAttackingPairs(temp);
                }
            }

            return hStates;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (getAttackingPairs(currentState) > 0)
                executeMove((Point)chosenMove);
        }

        private void executeMove(Point move)
        {
            for (int i = 0; i < n; i++)
                startState.Y[i] = currentState.Y[i];

            currentState.Y[move.X] = move.Y;
            moveCounter++;

            chosenMove = null;
            updateUI();
        }

        private int getAttackingPairs(SixState f)
        {
            int attackers = 0;

            for (int rf = 0; rf < n; rf++)  //Exploration for every col
            {
                for (int tar = rf + 1; tar < n; tar++)
                {

                    // get horizontal attackers
                    if (f.Y[rf] == f.Y[tar])
                        attackers++;

                }

                for (int tar = rf + 1; tar < n; tar++)
                {

                    // get diagonal down attackers
                    if (f.Y[tar] == f.Y[rf] + tar - rf)
                        attackers++;

                }

                for (int tar = rf + 1; tar < n; tar++)
                {

                    // get diagonal up attackers
                    if (f.Y[rf] == f.Y[tar] + tar - rf)
                        attackers++;

                }
            }

            return attackers;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            while (getAttackingPairs(currentState) > 0)
                executeMove((Point)chosenMove);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // draw squares
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        e.Graphics.FillRectangle(Brushes.Gray, i * side, j * side, side, side);
                    }

                    // draw queens
                    if (j == startState.Y[i])
                        e.Graphics.FillEllipse(Brushes.Teal, i * side, j * side, side, side);
                
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e){}

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            // draw squares
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        e.Graphics.FillRectangle(Brushes.Gray, i * side, j * side, side, side);
                    }

                    // draw queens
                    if (j == startState.Y[i])
                        e.Graphics.FillEllipse(Brushes.Teal, i * side, j * side, side, side);

                }
            }
        }
    }
}
